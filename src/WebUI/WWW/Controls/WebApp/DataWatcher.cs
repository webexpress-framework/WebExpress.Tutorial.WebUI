using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the watcher demo page for the tutorial.
    /// Hosts a <see cref="ControlDataWatcher"/> connected to the
    /// <see cref="MonkeyIslandWatcher"/> REST endpoint (for the
    /// add / list / remove operations) and the
    /// <see cref="MonkeyIslandWatcherUsers"/> endpoint (for the user
    /// search in the "+" dropdown). The seed crew watching the quest log
    /// are Guybrush Threepwood and Elaine Marley; the directory also
    /// contains Stan, the Voodoo Lady, LeChuck, Wally, Herman Toothrot
    /// and Murray.
    /// </summary>
    [Title("DataWatcher")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataWatcher : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataWatcher(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlWatcher` renders a row of avatars representing the watchers of an object. The control only emits the host element; the actual avatar row, the click-to-remove behavior, the ""+"" affordance and the search dropdown are built by the client-side `webexpress.webapp.WatcherCtrl`.";

            Stage.Controls =
            [
                new ControlDataWatcher("tutorial-watcher-quest")
                {
                    MaxVisible = _ => 6
                }
                    .DataService<MonkeyIslandWatcher>()
                    .UsersService<MonkeyIslandWatcherUsers>()
            ];

            Stage.Code = @"
            new ControlDataWatcher(""tutorial-watcher-quest"")
            {
                MaxVisible = _ => 6
            }
                .DataService<MonkeyIslandWatcher>()
                .UsersService<MonkeyIslandWatcherUsers>();";
        }
    }
}
