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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed interactive gantt chart: the project
    /// plan for Guybrush's quest to become a mighty pirate and rescue Elaine.
    /// </summary>
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
                Event.GANTT_LINK_DELETE_EVENT,
                Event.GANTT_SELECT_EVENT
            );

            Stage.Description = @"The `Gantt` control renders an interactive project plan: a task grid on the left and a scrollable timeline on the right, drawn from a pure JSON model of tasks and dependency links. Tasks carry a start date, an end date, a duration, a progress percentage and resources; tasks with children act as containers whose dates and progress are rolled up from the subtree. Bars are dragged to reschedule, their edges resize the duration, a handle adjusts the progress, and dragging a port at a bar edge onto another bar creates a typed dependency (finish-to-start, start-to-start, …) drawn as an orthogonal connector. New tasks are added through the toolbar or a double-click on a free spot in the timeline; the grid cells are edited inline. The timeline switches between a day, week and month scale and zooms, and every mutation is persisted REST-fully and raised as an event.";

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
        }
    }
}
