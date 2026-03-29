using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the workflow editor control for the tutorial.
    /// </summary>
    [Title("RestWorkflow")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestWorkflow : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public RestWorkflow(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<WebExpress.Tutorial.WebUI.WWW.Api._1_.MonkeyIslandWorkflow>(pageContext);

            Stage.AddEvent(Event.CLICK_EVENT, Event.DOUBLE_CLICK_EVENT);

            Stage.Description = @" The `Workflow` control provides a visual container for rendering workflow structures composed of stages, transitions, and decision points. It is designed for process flows, state machines, approval chains, or any scenario where sequential or branching progression needs to be represented clearly. The control acts as a flexible canvas that can be extended with custom rendering logic, layout algorithms, and interactive behaviors.";

            Stage.Control = new ControlRestWorkflow()
            {
                RestUri = uri
            };

            Stage.Code = @"
            new ControlRestWorkflow()
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandWorkflow>(pageContext)
            };";
        }
    }
}
