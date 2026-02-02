using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the rest form control for the tutorial.    
    /// </summary>    
    [Title("RestWqlPrompt")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestWqlPrompt : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public RestWqlPrompt(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `WqlPrompt` control provides an input field that emulates the behavior of a Linux terminal, supporting features such as auto-completion, multi-line editing, and navigation through previously submitted expressions. Suggestions for attributes, operators, and values are retrieved from a REST API and are cached client-side to reduce network load. The control validates expressions via the server and displays syntax errors in real time. Users can insert new lines with Ctrl+Enter, submit expressions with Enter, and navigate history using Page Up and Page Down. The input supports editing at any cursor position and displays hints and alternative completions to assist with complex WQL queries.";

            Stage.Control = new ControlRestWqlPrompt("myPrompt")
            {
                RestUri = sitemapManager.GetUri<WWW.Api._1_.MonkeyIslandBoatWql>(pageContext.ApplicationContext)
            };

            Stage.Code = @"
            new ControlRestWqlPrompt(""myPrompt"")
            {
                RestUri = sitemapManager.GetUri<WWW.Api._1_.MonkeyIslandBoatWql>(pageContext)
            };";
        }
    }
}
