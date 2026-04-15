using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the rest login control for the tutorial.
    /// </summary>
    [Title("RestLogin")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestLogin : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestLogin(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"Provides a rest login control that prompts the user to enter credentials for authentication.";

            Stage.Control = new ControlRestLogin()
            {
                RestUri = sitemapManager.GetUri<WWW.Api._1_.Session>(pageContext.ApplicationContext)
            };

            Stage.Code = @"
            new ControlRestLogin()
            {
                RestUri = sitemapManager.GetUri<Login>(pageContext.ApplicationContext)
            };";
        }
    }
}
