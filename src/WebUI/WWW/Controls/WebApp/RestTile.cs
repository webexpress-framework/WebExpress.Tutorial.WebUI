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
    /// Represents the tile control for the tutorial.
    /// </summary>
    [Title("RestTile")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestTile : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestTile(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register demo events that the tile control can emit
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `RestTile` control is a user interface component that retrieves data from a REST API and exposes CRUD-oriented interactions in a tile-based representation. The control automatically fetches data from the API and renders the items as tiles.";

            Stage.Controls =
            [
                new ControlRestTile("myTile")
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandGamesTile>(pageContext.ApplicationContext)
                }
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlRestTile(""myTile"")
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandGamesList>(pageContext.ApplicationContext)
            }";
        }
    }
}