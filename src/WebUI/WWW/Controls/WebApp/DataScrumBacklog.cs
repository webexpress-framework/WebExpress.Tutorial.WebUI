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

            Stage.Description = @"The `ScrumBacklog` control provides an interactive view of the product backlog. It groups user stories into structured sections and supports planning actions such as adding, editing, reordering, and assigning items to a sprint.";

            // the data service and its endpoint are authored in C# through the
            // fluent data surface; the endpoint resolves through the sitemap.
            Stage.Controls =
            [
                new ControlDataScrumBacklog("monkeyIslandBacklog")
                {
                    Title = _ => "Monkey Island Product Backlog",
                    Selectable = _ => true,
                    IconActive = _ => "fas fa-skull-crossbones",
                    IconPlanned = _ => "fas fa-hourglass-half",
                    IconBacklog = _ => "fas fa-map",
                    IconMoveToBacklog = _ => "fas fa-anchor",
                    IconMoveToSprint = _ => "fas fa-ship",
                    IconStartSprint = _ => "fas fa-play",
                    IconCompleteSprint = _ => "fas fa-flag-checkered",
                    IconEditSprint = _ => "fas fa-pen",
                    IconDeleteSprint = _ => "fas fa-bomb"
                }
                    .DataService<RestApiScrum>()
            ];

            Stage.Code = @"
            new ControlDataScrumBacklog(""monkeyIslandBacklog"")
            {
                Title = _ => ""Monkey Island Product Backlog""
            }
                .DataService<RestApiScrum>();";
        }
    }
}
