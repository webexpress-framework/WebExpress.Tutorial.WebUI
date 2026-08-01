using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the schedule control for the tutorial: the voyage calendar of
    /// Guybrush's quest through the Caribbean.
    /// </summary>
    [Title("Schedule")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Schedule : PageControl
    {
        // the calendar is anchored on a fixed month so the example always shows
        // the same, populated period rather than an empty current month
        private static readonly DateTime _anchor = new(2026, 8, 15);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Schedule(IPageContext pageContext)
        {
            Stage.AddEvent
            (
                Event.CLICK_EVENT,
                Event.DOUBLE_CLICK_EVENT,
                Event.SELECT_ITEM_EVENT,
                Event.CHANGE_PAGE_EVENT,
                Event.MOVE_EVENT,
                Event.UPDATED_EVENT
            );

            Stage.Description = @"The `Schedule` control is a calendar for time-based items (appointments, events or tasks) that carry a start, an end and may span several days. It offers three views over the same set of items: a **month** grid with compact chips per day and continuous bars for multi-day entries, a **week** grid with an optional time axis on which timed items are stretched by their hours and overlapping items share the width of the day, and an **agenda**, a chronological list grouped by day, week or month. Navigation steps between periods, jumps to today and (with the mini calendar) straight to a date. Localisation runs through `Intl`, so one culture tag drives the month and weekday names, the date and time formats, the week start, the weekend days and even the calendar system; week numbers follow ISO 8601 on request. Regional holidays are passed as static data and are marked in every view. The control is purely static: its items and holidays come from its properties. The data-driven counterpart that loads and updates its items over REST is `ControlDataSchedule`.";

            Stage.Control = BuildSchedule("monkeyIslandSchedule", TypeViewSchedule.Month);

            Stage.Code = @"
            new ControlSchedule(""monkeyIslandSchedule"")
            {
                View = _ => TypeViewSchedule.Month,
                Culture = _ => ""de-DE"",
                IsoWeek = _ => true,
                ShowWeekNumbers = _ => true,
                MiniCalendar = _ => true,
                Date = _ => new DateTime(2026, 8, 15)
            }
                .Add(new ControlScheduleItem(""standup"")
                {
                    Title = _ => ""Crew meeting"",
                    Start = _ => new DateTime(2026, 8, 12, 9, 0, 0),
                    End = _ => new DateTime(2026, 8, 12, 9, 30, 0),
                    Icon = _ => new IconCompass(),
                    Category = _ => ""crew""
                })
                .Add(new ControlScheduleItem(""voyage"")
                {
                    Title = _ => ""Voyage to Monkey Island"",
                    Start = _ => new DateTime(2026, 8, 5),
                    End = _ => new DateTime(2026, 8, 9),
                    AllDay = _ => true,
                    Icon = _ => new IconSailboat(),
                    Color = _ => new PropertyColorBackground(TypeColorBackground.Success)
                })
                .Add(new ControlScheduleHoliday()
                {
                    Date = _ => new DateTime(2026, 8, 15),
                    Name = _ => ""Assumption Day"",
                    Region = _ => ""BY"",
                    Type = _ => TypeHolidaySchedule.Public
                });";

            Stage.AddProperty
            (
                "View",
                "The `View` property selects the view the schedule opens in. The **month** grid shows the widest period at once and is the default; the **week** grid resolves the hours of a day; the **agenda** lists the items chronologically and is the view that stays readable on a narrow screen. `Views` narrows the switcher to a subset – a schedule that only ever makes sense as an agenda simply offers nothing else.",
                @"
                new ControlSchedule(""scheduleWeek"")
                {
                    View = _ => TypeViewSchedule.Week,
                    Culture = _ => ""de-DE"",
                    Date = _ => new DateTime(2026, 8, 15)
                }",
                BuildSchedule("scheduleWeek", TypeViewSchedule.Week),
                BuildSchedule("scheduleAgenda", TypeViewSchedule.Agenda)
            );

            Stage.AddProperty
            (
                "Culture",
                "The `Culture` property is a BCP-47 tag that drives everything which differs between regions: the month and weekday names, the date and time formats, the day a week starts on and the days that count as the weekend. A tag may carry the Unicode calendar extension to present a calendar other than the Gregorian one, for example `th-TH-u-ca-buddhist` or `ja-JP-u-ca-japanese`.",
                "The grid arithmetic stays proleptic Gregorian; the calendar extension changes how the dates are presented, not how the weeks are computed.",
                @"
                new ControlSchedule(""scheduleCulture"")
                {
                    Culture = _ => ""en-US"",
                    Date = _ => new DateTime(2026, 8, 15)
                }",
                BuildSchedule("scheduleCultureUs", TypeViewSchedule.Month, culture: "en-US"),
                BuildSchedule("scheduleCultureTh", TypeViewSchedule.Month, culture: "th-TH-u-ca-buddhist")
            );

            Stage.AddProperty
            (
                "WeekStart",
                "The `WeekStart` property overrides the day a week starts on, which is otherwise derived from the culture. It is what makes a schedule start on Sunday in the United States and on Monday in Germany without the page having to know the rule – set it only where the regional default is not what is wanted.",
                @"
                new ControlSchedule(""scheduleWeekStart"")
                {
                    Culture = _ => ""de-DE"",
                    WeekStart = _ => DayOfWeek.Sunday,
                    Date = _ => new DateTime(2026, 8, 15)
                }",
                BuildSchedule("scheduleWeekStart", TypeViewSchedule.Month, weekStart: DayOfWeek.Sunday)
            );

            Stage.AddProperty
            (
                "IsoWeek",
                "The `IsoWeek` property counts week numbers the ISO 8601 way, where week one is the week containing the first Thursday. It is independent of `WeekStart`, because a region may well display Sunday-first weeks and still count them the ISO way. `ShowWeekNumbers` decides whether the numbers are drawn at all.",
                @"
                new ControlSchedule(""scheduleIsoWeek"")
                {
                    Culture = _ => ""de-DE"",
                    IsoWeek = _ => true,
                    ShowWeekNumbers = _ => true,
                    Date = _ => new DateTime(2026, 1, 4)
                }",
                BuildSchedule("scheduleIsoWeek", TypeViewSchedule.Month, date: new DateTime(2026, 1, 4))
            );

            Stage.AddProperty
            (
                "TimeAxis",
                "The `TimeAxis` property decides how the week view lays its items out. With the axis on – the default – a timed item is placed and stretched by its hours and overlapping items share the width of the day; `HourStart` and `HourEnd` bound the axis so the working hours stay legible instead of spending most of the height on the night. With the axis off, the items of a day are stacked as chips, which suits a schedule of mostly all-day entries.",
                @"
                new ControlSchedule(""scheduleHours"")
                {
                    View = _ => TypeViewSchedule.Week,
                    HourStart = _ => 8,
                    HourEnd = _ => 20,
                    Date = _ => new DateTime(2026, 8, 15)
                }",
                BuildSchedule("scheduleHours", TypeViewSchedule.Week, hourStart: 8, hourEnd: 20),
                BuildSchedule("scheduleNoAxis", TypeViewSchedule.Week, timeAxis: false)
            );

            Stage.AddProperty
            (
                "Holidays",
                "Holidays are passed as static data and marked in every view. A holiday carries its date, its name, the region it applies to and its kind – `Public`, `Bank`, `School`, `Observance` or `Optional` – which decides how prominently the day is marked. `ShowHolidays` switches the marking off without removing the data, which is useful for a view that is about capacity rather than about the calendar.",
                @"
                new ControlSchedule(""scheduleHolidays"")
                {
                    Culture = _ => ""de-DE"",
                    Date = _ => new DateTime(2026, 8, 15)
                }
                    .Add(new ControlScheduleHoliday()
                    {
                        Date = _ => new DateTime(2026, 8, 15),
                        Name = _ => ""Assumption Day"",
                        Region = _ => ""BY"",
                        Type = _ => TypeHolidaySchedule.Public
                    });",
                BuildSchedule("scheduleHolidays", TypeViewSchedule.Month),
                BuildSchedule("scheduleNoHolidays", TypeViewSchedule.Month, showHolidays: false)
            );

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property lets an entry be dragged onto another day. The time of day and the duration are preserved, so a move never silently changes how long an item lasts. The control only raises the move event; persisting it is the business of whoever owns the data, which is why a static schedule stays editable without becoming data bound.",
                "Use `ControlDataSchedule` when the move should be written back to a REST endpoint.",
                @"
                new ControlSchedule(""scheduleEditable"")
                {
                    Editable = _ => true,
                    Date = _ => new DateTime(2026, 8, 15)
                }",
                BuildSchedule("scheduleEditable", TypeViewSchedule.Month, editable: true)
            );

            Stage.AddProperty
            (
                "AgendaGrouping",
                "The `AgendaGrouping` property groups the agenda by day, week or month. The agenda always lists every item the model holds; the grouping only decides where the headings fall, so a long horizon stays navigable without paging.",
                @"
                new ControlSchedule(""scheduleAgendaWeek"")
                {
                    View = _ => TypeViewSchedule.Agenda,
                    AgendaGrouping = _ => TypeGroupingScheduleAgenda.Week
                }",
                BuildSchedule("scheduleAgendaWeek", TypeViewSchedule.Agenda, grouping: TypeGroupingScheduleAgenda.Week)
            );
        }

        /// <summary>
        /// Builds a schedule populated with the voyage of the tutorial, so every
        /// example on the page shows the same data under a different setting.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="view">The view the schedule opens in.</param>
        /// <param name="culture">The culture tag.</param>
        /// <param name="weekStart">The day a week starts on.</param>
        /// <param name="date">The date the schedule opens on.</param>
        /// <param name="grouping">The agenda grouping.</param>
        /// <param name="hourStart">The first hour of the time axis.</param>
        /// <param name="hourEnd">The last hour of the time axis.</param>
        /// <param name="timeAxis">Whether the week view carries a time axis.</param>
        /// <param name="showHolidays">Whether holidays are marked.</param>
        /// <param name="editable">Whether items can be dragged.</param>
        /// <returns>The configured schedule.</returns>
        private static ControlSchedule BuildSchedule
        (
            string id,
            TypeViewSchedule view,
            string culture = "de-DE",
            DayOfWeek? weekStart = null,
            DateTime? date = null,
            TypeGroupingScheduleAgenda grouping = TypeGroupingScheduleAgenda.Default,
            int? hourStart = null,
            int? hourEnd = null,
            bool timeAxis = true,
            bool showHolidays = true,
            bool editable = false
        )
        {
            var schedule = new ControlSchedule(id)
            {
                View = _ => view,
                Culture = _ => culture,
                WeekStart = _ => weekStart,
                IsoWeek = _ => true,
                ShowWeekNumbers = _ => true,
                MiniCalendar = _ => true,
                AgendaGrouping = _ => grouping,
                Date = _ => date ?? _anchor,
                HourStart = _ => hourStart,
                HourEnd = _ => hourEnd,
                TimeAxis = _ => timeAxis,
                ShowHolidays = _ => showHolidays,
                Editable = _ => editable
            };

            schedule.Add([.. BuildItems()]);
            schedule.Add([.. BuildHolidays()]);

            return schedule;
        }

        /// <summary>
        /// Builds the appointments of the quest: single timed entries, a
        /// multi-day voyage and an all-day showdown.
        /// </summary>
        /// <returns>The items.</returns>
        private static IEnumerable<IControlScheduleItem> BuildItems()
        {
            return
            [
                new ControlScheduleItem("standup")
                {
                    Title = _ => "Crew meeting",
                    Start = _ => new DateTime(2026, 8, 12, 9, 0, 0),
                    End = _ => new DateTime(2026, 8, 12, 9, 30, 0),
                    Icon = _ => new IconCompass(),
                    Category = _ => "crew"
                },
                new ControlScheduleItem("insult")
                {
                    Title = _ => "Insult sword fighting",
                    Start = _ => new DateTime(2026, 8, 12, 10, 0, 0),
                    End = _ => new DateTime(2026, 8, 12, 12, 0, 0),
                    Icon = _ => new IconHatCowboy(),
                    Color = _ => new PropertyColorBackground(TypeColorBackground.Warning),
                    Category = _ => "training"
                },
                new ControlScheduleItem("grog")
                {
                    Title = _ => "Grog at the Scumm Bar",
                    Start = _ => new DateTime(2026, 8, 12, 11, 0, 0),
                    End = _ => new DateTime(2026, 8, 12, 13, 0, 0),
                    Icon = _ => new IconBeerMugEmpty(),
                    Color = _ => new PropertyColorBackground("#8b5cf6"),
                    Category = _ => "crew"
                },
                new ControlScheduleItem("navigation")
                {
                    Title = _ => "Navigation lessons",
                    Start = _ => new DateTime(2026, 8, 12, 15, 0, 0),
                    End = _ => new DateTime(2026, 8, 12, 16, 30, 0),
                    Icon = _ => new IconMap(),
                    Category = _ => "training"
                },
                new ControlScheduleItem("voyage")
                {
                    Title = _ => "Voyage to Monkey Island",
                    Start = _ => new DateTime(2026, 8, 5),
                    End = _ => new DateTime(2026, 8, 9),
                    AllDay = _ => true,
                    Icon = _ => new IconSailboat(),
                    Color = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    Category = _ => "voyage",
                    Metadata = _ => new Dictionary<string, string> { ["ship"] = "Sea Monkey" }
                },
                new ControlScheduleItem("showdown")
                {
                    Title = _ => "Showdown mit LeChuck",
                    Start = _ => new DateTime(2026, 8, 20),
                    End = _ => new DateTime(2026, 8, 22),
                    AllDay = _ => true,
                    Icon = _ => new IconSkullCrossbones(),
                    Color = _ => new PropertyColorBackground(TypeColorBackground.Danger),
                    Category = _ => "quest"
                },
                new ControlScheduleItem("wedding")
                {
                    Title = _ => "Wedding with Elaine",
                    Start = _ => new DateTime(2026, 9, 3, 14, 0, 0),
                    End = _ => new DateTime(2026, 9, 3, 18, 0, 0),
                    Icon = _ => new IconTrophy(),
                    Category = _ => "quest"
                }
            ];
        }

        /// <summary>
        /// Builds the regional holidays the calendar marks.
        /// </summary>
        /// <returns>The holidays.</returns>
        private static IEnumerable<IControlScheduleHoliday> BuildHolidays()
        {
            return
            [
                new ControlScheduleHoliday()
                {
                    Date = _ => new DateTime(2026, 8, 15),
                    Name = _ => "Assumption Day",
                    Region = _ => "BY",
                    Type = _ => TypeHolidaySchedule.Public
                },
                new ControlScheduleHoliday()
                {
                    Date = _ => new DateTime(2026, 8, 8),
                    Name = _ => "Talk Like a Pirate Day",
                    Region = _ => "Caribbean",
                    Type = _ => TypeHolidaySchedule.Observance
                },
                new ControlScheduleHoliday()
                {
                    Date = _ => new DateTime(2026, 1, 1),
                    Name = _ => "New Year",
                    Region = _ => "DE",
                    Type = _ => TypeHolidaySchedule.Public
                }
            ];
        }
    }
}
