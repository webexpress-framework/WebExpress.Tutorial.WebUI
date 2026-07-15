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
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the quickfilter control for the tutorial.
    /// </summary>
    [Title("Quickfilter")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Quickfilter : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public Quickfilter(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Quickfilter` control provides a lightweight and intuitive way to filter data using predefined criteria. Inside a `ControlViewState` the quickfilter writes the active filter set into the shared state and re-queries the bound resource, so every control that renders it - here a tile panel - re-renders without a `BindFilter` wire. It shows both the REST-loaded filter chips and authored dropdown items - a multi-select (Games) and a single-select (Platform) - whose selections flow into the same shared filter.";

            // the quickfilter loads its filter definitions through its own service
            // and, bound to the games resource, writes the active filter into the
            // shared state and re-queries it - so no BindFilter is needed
            var quickfilter = new ControlDataQuickfilter("myQuickfilter")
                .DataService<MonkeyIslandGamesQuickfilter>();

            // authored dropdown items load their options from a REST endpoint; the
            // multi-select keeps several values, the single-select only one, and
            // both toggle the same filter set the quickfilter writes to the state
            quickfilter.Add
            (
                new ControlDataQuickfilterItemDropdown("games")
                {
                    Text = _ => "Games",
                    Icon = _ => new IconGamepad(),
                    Multiple = _ => true,
                    RestEndpoint = _ => sitemapManager.GetUri<MonkeyIslandGamesQuickfilter>(pageContext)
                },
                new ControlDataQuickfilterItemDropdown("platform")
                {
                    Text = _ => "Platform",
                    Icon = _ => new IconLaptop(),
                    RestEndpoint = _ => sitemapManager.GetUri<MonkeyIslandPlatformQuickfilter>(pageContext)
                }
            );

            quickfilter.Resource<GamesResource>().Model("filter");

            // the tile panel renders the games resource and re-renders whenever the
            // quickfilter re-queries it
            var tile = new ControlDataTile("myTileView").Resource<GamesResource>();

            Stage.Controls =
            [
                new ControlViewState<DataQueryState>("myQuickfilterViewState")
                    .State(s => { })
                    .Service<MonkeyIslandGamesTile>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Resource<GamesResource>(r => r
                        .Service<MonkeyIslandGamesTile>()
                        .Page().PageSize().Search().Wql().Filter().OrderBy().OrderDir()),
                quickfilter,
                tile
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            var quickfilter = new ControlDataQuickfilter(""myQuickfilter"")
                .DataService<MonkeyIslandGamesQuickfilter>();

            quickfilter.Add
            (
                new ControlDataQuickfilterItemDropdown(""games"")
                {
                    Text = _ => ""Games"",
                    Icon = _ => new IconGamepad(),
                    Multiple = _ => true,
                    RestEndpoint = _ => sitemapManager.GetUri<MonkeyIslandGamesQuickfilter>(pageContext)
                },
                new ControlDataQuickfilterItemDropdown(""platform"")
                {
                    Text = _ => ""Platform"",
                    Icon = _ => new IconLaptop(),
                    RestEndpoint = _ => sitemapManager.GetUri<MonkeyIslandPlatformQuickfilter>(pageContext)
                }
            );

            quickfilter.Resource<GamesResource>().Model(""filter"");

            var tile = new ControlDataTile(""myTileView"").Resource<GamesResource>();

            new ControlViewState<DataQueryState>(""myQuickfilterViewState"")
                .State(s => { })
                .Service<MonkeyIslandGamesTile>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                .Resource<GamesResource>(r => r
                    .Service<MonkeyIslandGamesTile>()
                    .Page().PageSize().Search().Wql().Filter().OrderBy().OrderDir()),
            quickfilter,
            tile";
        }
    }
}
