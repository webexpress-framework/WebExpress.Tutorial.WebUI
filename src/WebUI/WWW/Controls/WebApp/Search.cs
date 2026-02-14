using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the search control for the tutorial.
    /// </summary>
    [Title("Search")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Search : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public Search(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register demo events that the list control can emit
            Stage.AddEvent(Event.CHANGE_FILTER_EVENT);

            Stage.Description = @"The `Search` control provides a flexible search interface that can operate in two modes: a simple text-based search and an advanced WQL-based query mode. Users can switch between these modes to refine how search criteria are entered and processed. In addition, the control allows arbitrary UI elements to be added as content, which are displayed next to the active search field and can be used to extend or customize the search experience.";

            Stage.Controls =
            [
                new WebExpress.WebApp.WebControl.ControlSearch("mySearch")
                {
                    RestUri = sitemapManager.GetUri<Api._1_.MonkeyIslandBoatWql>(pageContext.ApplicationContext)
                }
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            ";
        }
    }
}