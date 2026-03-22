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
using WebExpress.WebUI.WebControl;

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
            // register demo events that the list control can emit
            Stage.AddEvent(Event.CHANGE_FILTER_EVENT);

            Stage.Description = @"The `Quickfilter` control provides a lightweight and intuitive way to filter data using predefined criteria. Each filter can be activated individually or as part of a group, including support for exclusive groups where only one filter may be active at a time. The control is designed to integrate seamlessly with REST-based data sources and can be combined with other UI elements to create flexible, context-aware filtering experiences.";

            Stage.Controls =
            [
                new ControlRestQuickfilter("myQickfilter")
                {
                    RestUri = sitemapManager.GetUri<Api._1_.MonkeyIslandGamesQuickfilter>(pageContext.ApplicationContext)
                },
                new ControlRestTile("myTile")
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandGamesTile>(pageContext.ApplicationContext),
                    Bind = new Binding().Add(new BindFilter())
                }
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlRestQuickfilter(""myQickfilter"")
            {
                RestUri = sitemapManager.GetUri<Api._1_.MonkeyIslandGamesQuickfilter>(pageContext.ApplicationContext)
            }";
        }
    }
}