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
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed interactive gantt chart: the project
    /// plan for Guybrush's quest to become a mighty pirate and rescue Elaine.
    /// </summary>
    [WebIcon<IconChartGantt>]
    [Title("DataGantt")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataGantt : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataGantt(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent
            (
                Event.GANTT_TASK_CREATE_EVENT,
                Event.GANTT_TASK_UPDATE_EVENT,
                Event.GANTT_TASK_DELETE_EVENT,
                Event.GANTT_LINK_CREATE_EVENT,
                Event.GANTT_LINK_UPDATE_EVENT,
                Event.GANTT_LINK_DELETE_EVENT,
                Event.GANTT_SELECT_EVENT,
                Event.GANTT_SANDBOX_ENTER_EVENT,
                Event.GANTT_SANDBOX_LEAVE_EVENT
            );

            Stage.Description = @"The `Gantt` control renders an interactive project plan: a task grid on the left and a scrollable timeline on the right, drawn from a pure JSON model of tasks and dependency links. Tasks carry a start date, an end date, a duration, a progress percentage and resources; tasks with children act as containers whose dates and progress are rolled up from the subtree. Bars are dragged to reschedule, their edges resize the duration, a handle adjusts the progress, and dragging a port at a bar edge onto another bar creates a typed dependency (finish-to-start, start-to-start, …) drawn as an orthogonal connector. New tasks are added through the toolbar or a double-click on a free spot in the timeline; the grid cells are edited inline. The timeline switches between a day, week and month scale and zooms, and every mutation is persisted REST-fully and raised as an event. Select a connector to change its FS, SS, FF or SF relationship. The endpoint supplies working weekdays and a project closure on July 15 as calendar data; task durations exclude these non-working days.";

            Stage.Controls =
            [
                new ControlDataGantt("monkeyIslandGantt")
                {
                    Scale = _ => "week",
                    Scales = _ => "day,week,month"
                }
                    .DataService<MonkeyIslandGantt>()
            ];

            Stage.Code = @"
            new ControlDataGantt(""monkeyIslandGantt"")
            {
                Scale = _ => ""week"",
                Scales = _ => ""day,week,month""
            }
                .DataService<MonkeyIslandGantt>()";

            Stage.AddProperty
            (
                "Sandbox",
                "The `Sandbox` property adds a sandbox button with a flask icon to the toolbar. Inside the sandbox every change stays on the client, so Guybrush can try out a rescheduling - swap the order of the trials, move the voyage to Monkey Island - without the stored plan seeing the steps in between. A strip below the toolbar counts the pending changes. **End sandbox** asks what to do with them: **Save all changes** sends the net result, one request per touched task or link, while **Discard changes** restores the plan as it was when the sandbox opened. If the server refuses part of a save, the sandbox stays open with exactly the changes that were not stored yet. The mutation events still fire inside the sandbox and carry `sandbox: true` in their detail.",
                "Leaving the page with pending sandbox changes makes the browser ask for confirmation, so the unsaved plan is not lost by accident.",
                @"Sandbox = _ => true",
                new ControlDataGantt("monkeyIslandGanttSandbox")
                {
                    Scale = _ => "week",
                    Sandbox = _ => true
                }
                    .DataService<MonkeyIslandGantt>()
            );
        }
    }
}
