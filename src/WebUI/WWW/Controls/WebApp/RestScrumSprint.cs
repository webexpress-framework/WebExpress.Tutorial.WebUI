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
    /// Represents a Monkey Island themed Scrum sprint overview board.
    /// </summary>
    [Title("RestScrumSprint")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestScrumSprint : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public RestScrumSprint(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.DATA_REQUESTED_EVENT, Event.DATA_ARRIVED_EVENT, Event.MOVE_EVENT, Event.SELECT_ITEM_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The `ScrumSprint` control provides an overview of the active sprint, including its goal, capacity, progress, and burndown data. It visualizes the current state of the sprint and highlights key metrics relevant to tracking ongoing work.";

            Stage.Controls =
            [
                new ControlRestScrumSprint("monkeyIslandSprint")
                {
                    RestUri = _=> sitemapManager.GetUri<RestApiScrumSprint>(pageContext.ApplicationContext)
                }
            ];

            Stage.Code = @"
            new ControlRestScrumSprint(""monkeyIslandSprint"")
            {
                RestUri = _=> sitemapManager.GetUri<RestApiScrumSprint>(pageContext.ApplicationContext)
            }";
        }
    }
}
