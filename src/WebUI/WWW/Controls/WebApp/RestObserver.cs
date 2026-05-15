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
    /// Represents the observer (watcher) demo page for the tutorial.
    /// Hosts a <see cref="ControlRestObserver"/> connected to the
    /// <see cref="MonkeyIslandObserver"/> REST endpoint (for the
    /// add / list / remove operations) and the
    /// <see cref="MonkeyIslandObserverUsers"/> endpoint (for the user
    /// search in the "+" dropdown). The seed crew watching the quest log
    /// are Guybrush Threepwood and Elaine Marley; the directory also
    /// contains Stan, the Voodoo Lady, LeChuck, Wally, Herman Toothrot
    /// and Murray.
    /// </summary>
    [Title("RestObserver")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestObserver : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public RestObserver(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<MonkeyIslandObserver>(pageContext);
            var usersUri = sitemapManager.GetUri<MonkeyIslandObserverUsers>(pageContext);

            Stage.Description = @"`ControlObserver` renders a row of avatars representing the watchers / observers of an object. The control only emits the host element; the actual avatar row, the click-to-remove behavior, the ""+"" affordance and the search dropdown are built by the client-side `webexpress.webapp.ObserverCtrl`.";

            Stage.Controls =
            [
                new ControlRestObserver("tutorial-observer-quest")
                {
                    RestUri = _ => uri,
                    UsersUri = _ => usersUri,
                    MaxVisible = _ => 6
                }
            ];

            Stage.Code = @"
            new ControlObserver(""tutorial-observer-quest"")
            {
                RestUri = _ => sitemapManager.GetUri<MonkeyIslandObserver>(pageContext),
                UsersUri = _ => sitemapManager.GetUri<MonkeyIslandObserverUsers>(pageContext),
                MaxVisible = _ => 6
            };";
        }
    }
}
