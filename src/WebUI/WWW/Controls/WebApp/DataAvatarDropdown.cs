using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the avatar dropdown control for the tutorial.
    /// </summary>    
    [Title("DataAvatarDropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataAvatarDropdown : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        /// <param name="pageContext">The context of the page where the line control is used.</param>
        public DataAvatarDropdown(ISitemapManager sitemapManager, IPageContext pageContext)
        {
            Stage.Description = @"The `DataAvatarDropdown` control is the REST-enabled variant of the standard `AvatarDropdown`. It displays an avatar that opens an interactive dropdown menu, but the menu items are retrieved dynamically from a REST API endpoint.";

            Stage.Control = new ControlDataAvatarDropdown()
                .DataService<AvatarDropdown>();

            Stage.Code = @"
            new ControlDataAvatarDropdown()
                .DataService<AvatarDropdown>();";
        }
    }
}
