using System;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the service level agreement control for the tutorial: the
    /// crew's promise to answer a summons from the governor in time.
    /// </summary>
    [Title("Sla")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Sla : PageControl
    {
        // the state gallery is anchored on a fixed moment so one page can show
        // every state at once instead of whichever one the clock happens to be in
        private static readonly DateTime _anchor = new(2026, 8, 1, 8, 0, 0);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager the endpoint uri is resolved through.</param>
        public Sla(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent
            (
                Event.SLA_STATUS_CHANGE_EVENT,
                Event.SLA_ACTION_EVENT,
                Event.SLA_CYCLE_EVENT
            );

            Stage.Description = @"The `Sla` control shows the state of a **service level agreement**: a coloured status, a meter of the consumed budget, the time left, the cycle of a periodic agreement and the actions that pause, resume or settle it. The status is derived rather than set - an agreement with time to spare is **fulfilled**, one past its warning threshold is **at risk**, one whose budget ran out is **violated** and one whose clock was stopped is **paused**. A periodic agreement starts over with a fresh budget every day, week or month and counts its cycles, and a pause stops the clock for the reset as well, so a paused agreement cannot slide into its next cycle while nobody is working on it. The widget renders complete on the server, which makes it correct in the first paint and readable without JavaScript; the client only takes over the passing of time. It holds no data of its own: where the state lives is the business of whoever owns it, and `ActionUri` is the one seam through which a requested transition is reported back.

The control has **two readings**, and which one it takes is decided by whether agreements were added to it: empty it is one agreement, filled it is the **panel** that frames them - see *Framing several agreements* below. The counterpart that loads its state over REST is `ControlDataSla`.";

            Stage.Control = new ControlSla("monkeyIslandSla")
            {
                Label = _ => "Answer the governor's summons",
                Description = _ => "The crew answers within four hours, every day, for five days.",
                Start = _ => DateTime.Now.AddHours(-3),
                Target = _ => TimeSpan.FromHours(4),
                WarningThreshold = _ => 0.6,
                Recurrence = _ => TypeRecurrenceSla.Daily,
                Cycles = _ => 5,
                ActionUri = _ => sitemapManager.GetUri<MonkeyIslandSla>(pageContext)
            };

            Stage.Code = @"
            new ControlSla(""monkeyIslandSla"")
            {
                Label = _ => ""Answer the governor's summons"",
                Description = _ => ""The crew answers within four hours, every day, for five days."",
                Start = _ => DateTime.Now.AddHours(-3),
                Target = _ => TimeSpan.FromHours(4),
                WarningThreshold = _ => 0.6,
                Recurrence = _ => TypeRecurrenceSla.Daily,
                Cycles = _ => 5,
                ActionUri = _ => sitemapManager.GetUri<MonkeyIslandSla>(pageContext)
            };";

            Stage.AddProperty
            (
                "Start, Target and WarningThreshold",
                @"`Start` is the moment the clock began, `Target` the time budget it grants and `WarningThreshold` the fraction of that budget after which the agreement counts as at risk. The default warns after four fifths, which leaves an operator a fifth of the time to react; `0.5` warns at half time. A non-positive target leaves the agreement without budget and reports as violated at once, so a widget that was never configured is impossible to miss on a dashboard.",
                @"
                new ControlSla(""slaThreshold"")
                {
                    Label = _ => ""Warns at half time"",
                    Start = _ => new DateTime(2026, 8, 1, 8, 0, 0),
                    Target = _ => TimeSpan.FromHours(4),
                    WarningThreshold = _ => 0.5
                };",
                CreateStatic("slaThresholdDefault", "Warns after four fifths", 150),
                CreateStatic("slaThresholdHalf", "Warns at half time", 150, threshold: 0.5)
            );

            Stage.AddProperty
            (
                "Status",
                @"The four states are exhaustive and mutually exclusive, so a dashboard can colour a whole wall of agreements without ever falling back on an *unknown* tile. Their precedence is fixed: a manually settled cycle wins over everything, because settling it is a statement about the outcome rather than about the clock; a stopped clock wins over the remaining time; and only then does the budget decide between violated, at risk and on track.",
                "The status is carried by the coloured left edge as well as by the text of the badge, so the tile stays readable for a visitor who cannot separate the colours.",
                @"
                new ControlSla(""slaViolated"")
                {
                    Label = _ => ""Return the borrowed shovel"",
                    Start = _ => new DateTime(2026, 8, 1, 8, 0, 0),
                    Target = _ => TimeSpan.FromHours(4),
                    Now = _ => new DateTime(2026, 8, 1, 13, 30, 0)
                };",
                CreateStatic("slaFulfilled", "Repair the ship", 60),
                CreateStatic("slaAtRisk", "Find the treasure map", 210),
                CreateStatic("slaViolated", "Return the borrowed shovel", 330),
                CreateStatic("slaPaused", "Escort the governor", 330, paused: true)
            );

            Stage.AddProperty
            (
                "Recurrence and Cycles",
                @"A periodic agreement starts over with a fresh budget every `Daily`, `Weekly` or `Monthly` interval, and `Cycles` says how often - `0` runs it indefinitely. Monthly cycles are walked on the calendar rather than derived from a fixed number of days, so they inherit the unequal length of the months they fall into. A budget larger than the interval is capped to it, because a cycle that resets before its budget runs out could never be violated. Once the last cycle is reached the agreement stops resetting and its final window keeps running, so a missed last cycle stays visible as a violation instead of quietly disappearing.",
                "A manual settlement is remembered as the cycle it happened in rather than as a timestamp, which is why a periodic agreement forgets it exactly when it starts over.",
                @"
                new ControlSla(""slaCycle"")
                {
                    Label = _ => ""Swab the deck"",
                    Start = _ => new DateTime(2026, 8, 1, 8, 0, 0),
                    Target = _ => TimeSpan.FromHours(4),
                    Recurrence = _ => TypeRecurrenceSla.Daily,
                    Cycles = _ => 5
                };",
                new ControlSla("slaCycle")
                {
                    Label = _ => "Swab the deck",
                    Description = _ => "Daily, on the third of five days.",
                    Start = _ => _anchor,
                    Target = _ => TimeSpan.FromHours(4),
                    Recurrence = _ => TypeRecurrenceSla.Daily,
                    Cycles = _ => 5,
                    Now = _ => _anchor.AddHours(50),
                    Live = _ => false,
                    ShowActions = _ => false
                },
                new ControlSla("slaCycleWeekly")
                {
                    Label = _ => "Count the grog barrels",
                    Description = _ => "Weekly, indefinitely.",
                    Start = _ => _anchor,
                    Target = _ => TimeSpan.FromDays(2),
                    Recurrence = _ => TypeRecurrenceSla.Weekly,
                    Cycles = _ => 0,
                    Now = _ => _anchor.AddDays(15),
                    Live = _ => false,
                    ShowActions = _ => false
                }
            );

            Stage.AddProperty
            (
                "ActionUri",
                @"The widget persists nothing by itself. Pointed at an endpoint, the client posts `{ ""action"": ""pause"" }` there on a click and adopts the state the endpoint answers with; without one the transition is applied in the browser and raised as an event, which is enough for a page that handles it itself. The transition is applied locally first - the visitor asked for it and the outcome is known, so waiting for a round trip to grey out a paused agreement would make the button feel broken.",
                @"
                new ControlSla(""slaAction"")
                {
                    ActionUri = _ => sitemapManager.GetUri<MonkeyIslandSla>(pageContext)
                };",
                new ControlSla("slaAction")
                {
                    Label = _ => "Answer the governor's summons",
                    Start = _ => DateTime.Now.AddHours(-3),
                    Target = _ => TimeSpan.FromHours(4),
                    Recurrence = _ => TypeRecurrenceSla.Daily,
                    Cycles = _ => 5,
                    ActionUri = _ => sitemapManager.GetUri<MonkeyIslandSla>(pageContext)
                }
            );

            Stage.AddProperty
            (
                "Bind",
                @"`SlaDefinition` is the model the evaluation and the transitions work on, and the shape a store or a REST endpoint keeps its agreements in. `Bind` adopts one in a single call instead of restating every property by hand. Its transitions - `Pause`, `Resume`, `Fulfill` and `Restart` - return a new instance rather than mutating the one they were called on, so a definition that is being rendered can never change underneath the renderer.",
                @"
                var definition = new SlaDefinition
                {
                    Start = new DateTime(2026, 8, 1, 8, 0, 0),
                    Target = TimeSpan.FromHours(4),
                    Recurrence = TypeRecurrenceSla.Weekly,
                    Cycles = 4
                }
                    .Pause(new DateTime(2026, 8, 1, 9, 0, 0));

                new ControlSla(""slaBound"") { Label = _ => ""Guard the treasure"" }.Bind(definition);",
                new ControlSla("slaBound")
                {
                    Label = _ => "Guard the treasure",
                    Description = _ => "Paused after one hour of a four hour budget.",
                    Now = _ => _anchor.AddHours(3),
                    Live = _ => false,
                    ShowActions = _ => false
                }
                    .Bind(new SlaDefinition
                    {
                        Start = _anchor,
                        Target = TimeSpan.FromHours(4),
                        Recurrence = TypeRecurrenceSla.Weekly,
                        Cycles = 4
                    }
                        .Pause(_anchor.AddHours(1)))
            );

            Stage.AddProperty
            (
                "ShowActions and Live",
                @"`ShowActions` drops the buttons, which is what a read-only tile on a wall display wants. With `Live` switched off the widget stays exactly as the server rendered it: no countdown, no status changes, no cycle rollover - which is what a printable report and a table of many rows want, and what every frozen example on this page uses.",
                @"
                new ControlSla(""slaStatic"")
                {
                    ShowActions = _ => false,
                    Live = _ => false
                };",
                CreateStatic("slaStatic", "Frozen at the moment of rendering", 200)
            );

            Stage.AddProperty
            (
                "Framing several agreements",
                @"Agreements added to the control turn it into the **panel** that gathers them: a heading, a summary of how they are doing, and the tiles below it. A dashboard that shows more than one agreement should show them as one thing - rendered on their own, five of them read as five unrelated widgets that happen to sit next to each other; inside the panel they sit under a shared heading, indented and separated by a hairline, so the eye reads one panel. Neither rendering draws a box of its own - the frame belongs to whatever hosts the widget, here the card around the example. The panel takes the colour of its **worst** agreement, because one that showed the best of them would hide what it exists to surface.",
                @"
                new ControlSla
                (
                    ""slaPanel"",
                    new ControlSla(""slaPanelCrew"") { Label = _ => ""Answer the governor's summons"", /* ... */ },
                    new ControlSla(""slaPanelShip"") { Label = _ => ""Repair the ship"", /* ... */ },
                    new ControlSla(""slaPanelShovel"") { Label = _ => ""Return the borrowed shovel"", /* ... */ }
                )
                {
                    Label = _ => ""Promises of the Sea Monkey"",
                    Description = _ => ""What the crew owes the Caribbean this week.""
                };",
                new ControlSla
                (
                    "slaPanel",
                    CreateStatic("slaPanelCrew", "Answer the governor's summons", 210),
                    CreateStatic("slaPanelShip", "Repair the ship", 60),
                    CreateStatic("slaPanelShovel", "Return the borrowed shovel", 330),
                    CreateStatic("slaPanelGrog", "Restock the grog", 60)
                )
                {
                    Label = _ => "Promises of the Sea Monkey",
                    Description = _ => "What the crew owes the Caribbean this week."
                }
            );

            Stage.AddProperty
            (
                "ShowSummary",
                @"The summary counts the framed agreements per status with the empty counts left out, and reports the ones that need attention first, because a summary is read from the left. It is computed on the server from the same evaluation the tiles render and kept current by the client as they change status, so it can never disagree with what is shown underneath it. `ShowSummary` drops it - a panel of two agreements that speak for themselves does not need one.",
                "The panel only turns grey when **every** agreement is paused: a single stopped clock among running ones says nothing about the set. An empty panel says so rather than showing an empty count.",
                @"
                new ControlSla(""slaPanelQuiet"", /* ... */)
                {
                    Label = _ => ""Quiet promises"",
                    ShowSummary = _ => false
                };",
                new ControlSla
                (
                    "slaPanelQuiet",
                    CreateStatic("slaPanelQuietA", "Sharpen the cutlasses", 60),
                    CreateStatic("slaPanelQuietB", "Feed the parrot", 60)
                )
                {
                    Label = _ => "Quiet promises",
                    ShowSummary = _ => false
                },
                new ControlSla
                (
                    "slaPanelPaused",
                    CreateStatic("slaPanelPausedA", "Careen the hull", 330, paused: true),
                    CreateStatic("slaPanelPausedB", "Chart the reef", 330, paused: true)
                )
                {
                    Label = _ => "Shore leave",
                    Description = _ => "Every clock stopped, so the panel is stopped too."
                }
            );

            Stage.AddProperty
            (
                "Fragment",
                @"`FragmentControlSla` is the same control as a fragment, so an agreement can be contributed to a section instead of being added to a page by hand - which is what lets an agreement owned by one plugin appear on a dashboard owned by another without either knowing the other. The id of the tile is derived from the fragment id, and the conditions of the fragment context are honoured: a fragment whose conditions do not hold renders nothing at all rather than an empty tile.",
                @"
                [Section<SectionContentPrimary>]
                [Scope<IScopeDashboard>]
                public sealed class SlaFragment : FragmentControlSla
                {
                    public SlaFragment(IFragmentContext fragmentContext, IAgreementStore store)
                        : base(fragmentContext)
                    {
                        Label = _ => ""First response"";
                        Start = _ => store.FirstResponse.StartedAt;
                        Target = _ => TimeSpan.FromHours(4);
                    }
                }"
            );
        }

        /// <summary>
        /// Creates a frozen agreement for the galleries: the same four hour
        /// budget, rendered at the moment that puts it into the state to show.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="label">The name of the agreement.</param>
        /// <param name="minutes">The minutes elapsed at the moment of rendering.</param>
        /// <param name="paused">Whether the agreement was paused after one hour.</param>
        /// <param name="threshold">The warning threshold.</param>
        /// <returns>The control.</returns>
        private static ControlSla CreateStatic(string id, string label, int minutes, bool paused = false, double threshold = 0.8)
        {
            return new ControlSla(id)
            {
                Label = _ => label,
                Start = _ => _anchor,
                Target = _ => TimeSpan.FromHours(4),
                WarningThreshold = _ => threshold,
                Now = _ => _anchor.AddMinutes(minutes),
                PausedSince = _ => paused ? _anchor.AddHours(1) : null,
                Live = _ => false,
                ShowActions = _ => false
            };
        }
    }
}
