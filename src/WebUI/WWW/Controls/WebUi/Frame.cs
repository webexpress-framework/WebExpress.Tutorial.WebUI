using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the frame control for the tutorial.    
    /// </summary>    
    [Title("Frame")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Frame : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Frame(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Frame` control is used to embed external HTML content into the current page. It behaves similarly to an iframe, but allows for fine-grained integration such as targeting specific fragments by ID or selector.";

            Stage.Control = new ControlFrame()
            {
                Uri = pageContext.ApplicationContext.Route.ToUri()
            };

            Stage.Code = @"
            new ControlFrame()
            {
                Uri = pageContext.ApplicationContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "Uri",
                "The `Uri` property defines the source of the external HTML content to be embedded. It can point to a full HTML page or a partial fragment that will be integrated into the current view—similar to an iframe, but with DOM-level control.",
                "Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)",
                new ControlFrame()
                {
                    Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)
                }
            );

            Stage.AddProperty
            (
                "Selector",
                "The `Selector` property allows you to specify a CSS selector—such as an `id` or `class`—to extract only a specific fragment from the loaded HTML content. This enables precise embedding of partial views rather than full pages.",
                "Selector = \"#wx-content-main\"",
                new ControlFrame()
                {
                    Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext),
                    Selector = "#wx-content-main"
                }
            );
        }
    }
}
