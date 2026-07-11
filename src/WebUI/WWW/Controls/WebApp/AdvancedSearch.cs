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
    /// Represents the search control for the tutorial.
    /// </summary>
    [Title("AdvancedSearch")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class AdvancedSearch : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public AdvancedSearch(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `AdvancedSearch` control provides a flexible search interface that can operate in a simple text mode or an advanced WQL query mode. Inside a `ControlViewState` a search or WQL change writes into the shared `search` and `wql` state keys and re-queries the bound resource, so the tile panel re-renders without a `BindSearch` wire. The search keeps its own service for suggestions and analysis and drives the games resource with `Resource<T>().Model(...)`.";

            // the search backs its suggestions and analysis through its own service
            // and, bound to the games resource, writes the query into the shared
            // state and re-queries it - so no BindSearch is needed
            var search = new ControlAdvancedSearch("mySearch")
                .DataService<MonkeyIslandGameWql>();
            search.Resource<GamesResource>().Model("search");

            // the tile panel renders the games resource and re-renders whenever the
            // search re-queries it
            var tile = new ControlDataTile("myTileView").Resource<GamesResource>();

            Stage.Controls =
            [
                new ControlViewState<DataQueryState>("mySearchViewState")
                    .State(s => { })
                    .Service<MonkeyIslandGamesTile>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Resource<GamesResource>(r => r
                        .Service<MonkeyIslandGamesTile>()
                        .Page().PageSize().Search().Wql().Filter().OrderBy().OrderDir()),
                search,
                tile
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            var search = new ControlAdvancedSearch(""mySearch"")
                .DataService<MonkeyIslandGameWql>();
            search.Resource<GamesResource>().Model(""search"");

            var tile = new ControlDataTile(""myTileView"").Resource<GamesResource>();

            new ControlViewState<DataQueryState>(""mySearchViewState"")
                .State(s => { })
                .Service<MonkeyIslandGamesTile>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                .Resource<GamesResource>(r => r
                    .Service<MonkeyIslandGamesTile>()
                    .Page().PageSize().Search().Wql().Filter().OrderBy().OrderDir()),
            search,
            tile";
        }
    }
}
