using System.Net.Http;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed Scrum backlog board.
    /// </summary>
    [Title("DataScrumBacklog")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataScrumBacklog : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataScrumBacklog(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.DATA_REQUESTED_EVENT, Event.DATA_ARRIVED_EVENT, Event.MOVE_EVENT, Event.SELECT_ITEM_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The `ScrumBacklog` control provides an interactive view of the product backlog. It groups user stories into structured sections and supports planning actions such as adding, editing, reordering, and moving items between the backlog and sprints. Each item shows its story-point estimate and, when assigned, the assignee's avatar; a context-menu action (`Assign & estimate…`) opens a dialog to assign a person from the users service and adjust the estimate.";

            // the data service and its endpoint are authored in C# through the
            // fluent data surface; the endpoint resolves through the sitemap.
            // the backlog is created separately and bound to the backlog
            // resource and the users service by type; the ViewState declares both
            // services and the resource by type.
            var backlog = new ControlDataScrumBacklog("monkeyIslandBacklogView")
            {
                Title = _ => "Monkey Island Product Backlog",
                Selectable = _ => true,
                IconActive = _ => "wx-icon-light wx-icon-light-skull-crossbones",
                IconPlanned = _ => "wx-icon-light wx-icon-light-hourglass-half",
                IconBacklog = _ => "wx-icon-light wx-icon-light-map",
                IconMoveToBacklog = _ => "wx-icon-light wx-icon-light-anchor",
                IconMoveToSprint = _ => "wx-icon-light wx-icon-light-ship",
                IconStartSprint = _ => "wx-icon-light wx-icon-light-play",
                IconCompleteSprint = _ => "wx-icon-light wx-icon-light-flag-checkered",
                IconEditSprint = _ => "wx-icon-light wx-icon-light-pen",
                IconDeleteSprint = _ => "wx-icon-light wx-icon-light-bomb",
                EstimationScale = _ => [1, 2, 3, 5, 8, 13, 20, 40]
            }
                .Resource<BacklogResource>()
                .UsersService<MonkeyIslandWatcherUsers>();

            Stage.Controls =
            [
                new ControlViewState<EmptyState>("monkeyIslandBacklog")
                    .Service<RestApiScrum>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Service<MonkeyIslandWatcherUsers>(svc => svc.Method(HttpMethod.Get))
                    .Resource<BacklogResource>(r => r.Service<RestApiScrum>()),
                backlog
            ];

            Stage.Code = @"
            var backlog = new ControlDataScrumBacklog(""monkeyIslandBacklogView"")
            {
                Title = _ => ""Monkey Island Product Backlog"",
                EstimationScale = _ => [1, 2, 3, 5, 8, 13, 20, 40]
            }
                .Resource<BacklogResource>()
                .UsersService<MonkeyIslandWatcherUsers>();

            new ControlViewState<EmptyState>(""monkeyIslandBacklog"")
                .Service<RestApiScrum>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                .Service<MonkeyIslandWatcherUsers>(svc => svc.Method(HttpMethod.Get))
                .Resource<BacklogResource>(r => r.Service<RestApiScrum>()),
            backlog";
        }
    }
}
