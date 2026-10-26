using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;

namespace WebExpress.Tutorial.WebUI.WWW
{
    /// <summary>
    /// Recreates the public WebExpress website using the independent landing layout and scoped fragments.
    /// </summary>
    [Title("webexpress.tutorial.webui:landing.title")]
    [Segment("landing")]
    [Scope<IScopeCookieBannerExample>]
    public sealed class Landing : IPage<VisualTreeWebAppLanding>, IScopeCookieBannerExample
    {
        /// <summary>
        /// Keeps composition in registered fragments so each landing section can be replaced independently.
        /// </summary>
        /// <param name="renderContext">The request and application context.</param>
        /// <param name="visualTree">The independent landing layout for this example.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebAppLanding visualTree)
        {
        }
    }
}
