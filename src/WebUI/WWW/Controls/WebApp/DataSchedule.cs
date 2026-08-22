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
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed REST-backed calendar: the appointments
    /// of Guybrush's quest, loaded per period and persisted on every move.
    /// </summary>
    [WebIcon<IconControlSchedule>]
    [Title("DataSchedule")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataSchedule : PageControl
    {
        // the calendar is anchored on a fixed month so the example always opens
        // on a populated period rather than on an empty current month
        private static readonly DateTime _anchor = new(2026, 8, 15);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataSchedule(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent
            (
                Event.DATA_REQUESTED_EVENT,
                Event.DATA_ARRIVED_EVENT,
                Event.CHANGE_VALUE_EVENT,
                Event.CHANGE_PAGE_EVENT,
                Event.CLICK_EVENT,
                Event.DOUBLE_CLICK_EVENT,
                Event.SELECT_ITEM_EVENT,
                Event.MOVE_EVENT,
                Event.UPDATED_EVENT
            );

            Stage.Description = @"The `DataSchedule` control is the data-driven calendar: it extends the static `Schedule` with the data path. The items of the shown period and the holidays of the years it touches are loaded from REST endpoints, the matching range is loaded again whenever the visitor navigates or switches the view, and every move is persisted with a `PUT`. The views, the calendar cultures, the navigation and the interaction are entirely those of the base control – the two share one visual and functional concept and differ only in where the data comes from. A range that has already been loaded is served from the client cache, so stepping back to a month costs no request; an explicit refresh, a periodic reload and a data-change notification bypass it. Holidays are requested per year and region, because they change once a year while the appointments change constantly. When a load fails the last good state stays on screen and a `DATA_ERROR_EVENT` is raised – an empty calendar would read as *there is nothing*, which is exactly the wrong conclusion when the endpoint is unreachable.";

            Stage.Controls =
            [
                new ControlDataSchedule("monkeyIslandSchedule")
                {
                    View = _ => TypeViewSchedule.Month,
                    Culture = _ => "de-DE",
                    IsoWeek = _ => true,
                    ShowWeekNumbers = _ => true,
                    MiniCalendar = _ => true,
                    Editable = _ => true,
                    Creatable = _ => true,
                    Deletable = _ => true,
                    HolidayRegion = _ => "Caribbean",
                    Date = _ => _anchor
                }
                    .DataService<MonkeyIslandSchedule>()
                    .HolidayService<MonkeyIslandHolidays>()
            ];

            Stage.Code = @"
            new ControlDataSchedule(""monkeyIslandSchedule"")
            {
                View = _ => TypeViewSchedule.Month,
                Culture = _ => ""de-DE"",
                IsoWeek = _ => true,
                ShowWeekNumbers = _ => true,
                MiniCalendar = _ => true,
                Editable = _ => true,
                Creatable = _ => true,
                Deletable = _ => true,
                HolidayRegion = _ => ""Caribbean"",
                Date = _ => new DateTime(2026, 8, 15)
            }
                .DataService<MonkeyIslandSchedule>()
                .HolidayService<MonkeyIslandHolidays>()";

            Stage.AddProperty
            (
                "DataService",
                "The `DataService` declares the endpoint the items come from. It is queried with the half-open range the current view shows – `from` is the first day, `to` the day after the last – and the same base persists the mutations: `POST` to create, `PUT` to update and `DELETE` to remove. The endpoint URL, the authentication headers, the retry policy and the change domains that drive the live updates all live on this descriptor, which is the one place the framework authors an endpoint.",
                "A source that cannot narrow by range may ignore `from` and `to`; the client renders only what falls into the shown period either way.",
                @"
                new ControlDataSchedule(""scheduleService"")
                {
                    Date = _ => new DateTime(2026, 8, 15)
                }
                    .DataService<MonkeyIslandSchedule>(svc => svc
                        .WithHeader(""X-Api-Key"", token)
                        .WithRetry(2, 250))",
                new ControlDataSchedule("scheduleService")
                {
                    View = _ => TypeViewSchedule.Week,
                    Culture = _ => "de-DE",
                    Date = _ => _anchor
                }
                    .DataService<MonkeyIslandSchedule>()
            );

            Stage.AddProperty
            (
                "HolidayService",
                "The `HolidayService` declares a second endpoint that answers the holidays of one year and one region, selected with `HolidayRegion`. It is separate from the items because holidays change once a year while the appointments change constantly, and the two are almost never owned by the same source. A year that has been loaded is never requested again, and a range crossing new year fetches both years – otherwise the January days of a December view would come back without their holidays. A schedule whose item endpoint already returns the holidays of the period simply omits the second service.",
                @"
                new ControlDataSchedule(""scheduleHolidays"")
                {
                    HolidayRegion = _ => ""Caribbean"",
                    Date = _ => new DateTime(2026, 8, 15)
                }
                    .DataService<MonkeyIslandSchedule>()
                    .HolidayService<MonkeyIslandHolidays>()",
                new ControlDataSchedule("scheduleHolidays")
                {
                    Culture = _ => "de-DE",
                    HolidayRegion = _ => "Caribbean",
                    Date = _ => _anchor
                }
                    .DataService<MonkeyIslandSchedule>()
                    .HolidayService<MonkeyIslandHolidays>()
            );

            Stage.AddProperty
            (
                "AutoLoad / ReloadOnNavigate / Cache",
                "These three decide when the calendar talks to the endpoint. `AutoLoad` loads the shown period on the first paint; switching it off leaves the statically added items on screen until an explicit refresh, which is the seam a deferred or offline mode uses. `ReloadOnNavigate` loads the new range when the visitor steps to another period or switches the view – without it a calendar queried by range shows an empty month as soon as it is navigated. `Cache` serves a range that has already been loaded from the client instead of requesting it again; a calendar over data that changes by the minute switches it off.",
                @"
                new ControlDataSchedule(""scheduleNoCache"")
                {
                    Cache = _ => false,
                    Date = _ => new DateTime(2026, 8, 15)
                }
                    .DataService<MonkeyIslandSchedule>()",
                new ControlDataSchedule("scheduleNoCache")
                {
                    Culture = _ => "de-DE",
                    Cache = _ => false,
                    Date = _ => _anchor
                }
                    .DataService<MonkeyIslandSchedule>()
            );

            Stage.AddProperty
            (
                "RefreshInterval",
                "The `RefreshInterval` reloads the shown period every few seconds, but only while the control is visible. It is meant for sources that cannot announce a change; a calendar whose service declares change domains is notified instead and needs no polling at all.",
                @"
                new ControlDataSchedule(""scheduleRefresh"")
                {
                    RefreshInterval = _ => 60,
                    Date = _ => new DateTime(2026, 8, 15)
                }
                    .DataService<MonkeyIslandSchedule>()",
                new ControlDataSchedule("scheduleRefresh")
                {
                    Culture = _ => "de-DE",
                    RefreshInterval = _ => 60,
                    Date = _ => _anchor
                }
                    .DataService<MonkeyIslandSchedule>()
            );

            Stage.AddProperty
            (
                "Editable / Creatable / Deletable",
                "`Editable` lets an entry be dragged onto another day; the move is sent as a `PUT` and the server's version of the item wins, so an id it assigns or a value it normalises is what the calendar goes on showing. `Creatable` and `Deletable` open the `createItem` and `deleteItem` paths. A `PUT` for an unknown id must answer `404` rather than `200` – a successful answer would leave the moved entry where the user dropped it and the next reload would silently put it back.",
                "The write handlers of `RestApiSchedule` refuse by default, so a read-only calendar needs no override and never silently accepts a change it does not persist.",
                @"
                new ControlDataSchedule(""scheduleEditable"")
                {
                    Editable = _ => true,
                    Creatable = _ => true,
                    Deletable = _ => true,
                    Date = _ => new DateTime(2026, 8, 15)
                }
                    .DataService<MonkeyIslandSchedule>()",
                new ControlDataSchedule("scheduleEditable")
                {
                    Culture = _ => "de-DE",
                    Editable = _ => true,
                    Creatable = _ => true,
                    Deletable = _ => true,
                    Date = _ => _anchor
                }
                    .DataService<MonkeyIslandSchedule>()
            );
        }
    }
}
