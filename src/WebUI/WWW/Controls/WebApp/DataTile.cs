using System.Net.Http;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
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
    /// Represents the tile control for the tutorial.
    /// </summary>
    [Title("DataTile")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataTile : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataTile(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register demo events that the tile control can emit
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `DataTile` control is a user interface component that retrieves data from a REST API and exposes CRUD-oriented interactions in a tile-based representation. The control automatically fetches data from the API and renders the items as tiles.";

            // the scope owns the state, the service and the central tiles
            // resource; the tile panel inside it is a pure view bound to that
            // resource. the endpoint resolves through the sitemap.
            Stage.Controls =
            [
                new ControlViewState("myTile", new ControlDataTile("myTileView") { Resource = _ => "tiles" })
                    .Service("data", svc => svc.Endpoint<MonkeyIslandGamesTile>().Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Resource("tiles", r => r
                        .Param("page").Param("pageSize")
                        .Param("search").Param("wql").Param("filter")
                        .Param("orderBy").Param("orderDir")),
                new ControlModalExample("modal")
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlViewState(""myTile"", new ControlDataTile(""myTileView"") { Resource = _ => ""tiles"" })
                .Service(""data"", svc => svc.Endpoint<MonkeyIslandGamesTile>().Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                .Resource(""tiles"", r => r
                    .Param(""page"").Param(""pageSize"")
                    .Param(""search"").Param(""wql"").Param(""filter"")
                    .Param(""orderBy"").Param(""orderDir""))";
        }
    }
}
