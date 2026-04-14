using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the avatar dropdown control for the tutorial.
    /// </summary>    
    [Title("RestAvatarDropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestAvatarDropdown : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        /// <param name="pageContext">The context of the page where the line control is used.</param>
        public RestAvatarDropdown(ISitemapManager sitemapManager, IPageContext pageContext)
        {
            Stage.Description = @"The `RestAvatarDropdown` control is the REST-enabled variant of the standard `AvatarDropdown`. It displays an avatar that opens an interactive dropdown menu, but the menu items are retrieved dynamically from a REST API endpoint.";

            Stage.Control = new ControlRestAvatarDropdown()
            {
                RestUri = sitemapManager.GetUri<AvatarDropdown>(pageContext.ApplicationContext)
            };

            Stage.Code = @"
            new ControlRestAvatarDropdown()
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandInventoriesDropdown>(pageContext.ApplicationContext)
            };";
        }
    }
}
