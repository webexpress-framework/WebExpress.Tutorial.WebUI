using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the dashboard control for the tutorial.
    /// </summary>
    [Title("RestDashboard")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestDashboard : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public RestDashboard(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<WebExpress.Tutorial.WebUI.WWW.Api._1_.MonkeyIslandDashboard>(pageContext);

            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"The `Dashboard` control organizes widgets into columns. Each widget provides metadata (title, icon, color, column) and can optionally contain content controls.";

            var dashboard = new ControlRestDashboard(RandomId.Create())
            {
                RestUri = uri
            };

            Stage.Control = dashboard;

            Stage.Code = @"
            new ControlRestDashboard(RandomId.Create())
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandDashboard>(pageContext)
            };";
        }
    }
}