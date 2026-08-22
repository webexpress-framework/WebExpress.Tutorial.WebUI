using System;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST-backed service level agreement demo page for the
    /// tutorial. Hosts a <see cref="ControlDataSla"/> connected to the
    /// <see cref="MonkeyIslandSla"/> endpoint, which serves the current state
    /// (GET) and applies a transition (POST).
    /// </summary>
    [WebIcon<IconControlSla>]
    [Title("DataSla")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataSla : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public DataSla(IPageContext pageContext)
        {
            Stage.AddEvent
            (
                Event.SLA_STATUS_CHANGE_EVENT,
                Event.SLA_ACTION_EVENT,
                Event.SLA_CYCLE_EVENT,
                Event.CHANGE_STATUS_EVENT
            );

            Stage.Description = @"`ControlDataSla` is the `Sla` agreement with its state **sourced from data**: it loads the state from a REST endpoint (GET) and requests a pause, a resume or a manual settlement there (POST), adopting the state the endpoint answers with. Everything else - the countdown, the move between the states, the cycle rollover, the localisation - is inherited unchanged from the static agreement, which is what keeps the two from ever disagreeing about what a status means. Whatever is configured statically stays the fallback the widget shows until - and if - the endpoint answers; seeding it with the last known state is what keeps the tile from flashing an empty frame on every page load. The endpoint, the authentication headers and the retry policy are not properties here: they belong to the service descriptor that `DataService<TEndpoint>()` emits as a `wx-service` island, which is the one place the framework authors an endpoint.";

            Stage.Control = new ControlDataSla("tutorialDataSla")
            {
                Label = _ => "Answer the governor's summons",
                Description = _ => "Loaded from the endpoint; every button persists.",
                Target = _ => TimeSpan.FromHours(4),
                Recurrence = _ => TypeRecurrenceSla.Daily,
                Cycles = _ => 5
            }
                .DataService<MonkeyIslandSla>();

            Stage.Code = @"
            new ControlDataSla(""tutorialDataSla"")
            {
                Label = _ => ""Answer the governor's summons"",
                Description = _ => ""Loaded from the endpoint; every button persists."",
                Target = _ => TimeSpan.FromHours(4),
                Recurrence = _ => TypeRecurrenceSla.Daily,
                Cycles = _ => 5
            }
                .DataService<MonkeyIslandSla>();";

            Stage.AddProperty
            (
                "DataService",
                @"`DataService<TEndpoint>()` declares the standard service of the agreement: it loads the state with `GET` and requests a transition with `POST`, because a pause or a settlement is an action the endpoint applies to the agreement rather than a new representation the client dictates. The endpoint type is the only thing the page contributes; the uri is resolved through the sitemap at render time. The endpoint answers with the state that resulted - `target`, `elapsed`, `period`, `cycle`, `cycles`, `paused` and `settled` - and the widget adopts it.",
                @"
                new ControlDataSla(""slaService"")
                    .DataService<MonkeyIslandSla>();",
                new ControlDataSla("slaService")
                {
                    Label = _ => "Answer the governor's summons",
                    Target = _ => TimeSpan.FromHours(4)
                }
                    .DataService<MonkeyIslandSla>()
            );

            Stage.AddProperty
            (
                "RefreshInterval",
                @"Without a refresh interval the widget loads once and then counts on its own, which is correct as long as it is the only thing changing the agreement. A poll is what keeps several visitors of the same agreement in step - open this page twice and pause one of them to watch the other follow.",
                "The interval is a poll, not a stream. It costs one request per widget and interval, so a wall display of thirty agreements is better served by one longer interval than by thirty short ones.",
                @"
                new ControlDataSla(""slaPolled"")
                {
                    RefreshInterval = _ => 10
                }
                    .DataService<MonkeyIslandSla>();",
                new ControlDataSla("slaPolled")
                {
                    Label = _ => "Answer the governor's summons",
                    Description = _ => "Re-read from the endpoint every ten seconds.",
                    Target = _ => TimeSpan.FromHours(4),
                    RefreshInterval = _ => 10
                }
                    .DataService<MonkeyIslandSla>()
            );

            Stage.AddProperty
            (
                "Read-only",
                @"`ShowActions` drops the buttons, which turns the widget into a pure view of the endpoint: it loads and follows the state but never changes it. That is what a wall display wants, and what a visitor without the permission to pause an agreement should see.",
                @"
                new ControlDataSla(""slaReadonly"")
                {
                    ShowActions = _ => false
                }
                    .DataService<MonkeyIslandSla>();",
                new ControlDataSla("slaReadonly")
                {
                    Label = _ => "Answer the governor's summons",
                    Description = _ => "Loaded, but never changed from here.",
                    Target = _ => TimeSpan.FromHours(4),
                    ShowActions = _ => false
                }
                    .DataService<MonkeyIslandSla>()
            );
        }
    }
}
