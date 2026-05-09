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
    /// Represents a Monkey Island themed Scrum backlog board.
    /// </summary>
    [Title("RestScrumBacklog")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestScrumBacklog : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public RestScrumBacklog(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.DATA_REQUESTED_EVENT, Event.DATA_ARRIVED_EVENT, Event.MOVE_EVENT, Event.SELECT_ITEM_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The `ScrumBacklog` control provides an interactive view of the product backlog. It groups user stories into structured sections and supports planning actions such as adding, editing, reordering, and assigning items to a sprint.";

            Stage.Controls =
            [
                new ControlRestScrumBacklog("monkeyIslandBacklog")
                {
                    RestUri = _=> sitemapManager.GetUri<RestApiScrum>(pageContext.ApplicationContext),
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
            ];

            Stage.Code = @"
            new ControlRestScrumBacklog(""monkeyIslandBacklog"")
            {
                RestUri = _=> sitemapManager.GetUri<RestApiScrumBacklog>(pageContext.ApplicationContext),
                Title = _ => ""Monkey Island Product Backlog""
            };";
        }
    }
}
