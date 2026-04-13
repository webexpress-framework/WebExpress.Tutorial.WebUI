using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebPage;

namespace WebExpress.Tutorial.WebUI.WebPage
{
    /// <summary>
    /// Represents the login page for the web application, providing logic for rendering and processing user
    /// authentication input.
    /// </summary>
    public sealed class PageLogin : PageWebAppLogin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PageLogin()
        {
        }

        /// <summary>
        /// Processing of the page.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree control to be processed.</param>
        public override void Process(IRenderContext renderContext, VisualTreeWebAppLogin visualTree)
        {
            base.Process(renderContext, visualTree);
        }
    }
}
