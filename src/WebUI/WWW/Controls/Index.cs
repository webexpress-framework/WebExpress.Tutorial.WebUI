using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebUI.WebFragment.ControlPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the home page for the tutorial.
    /// </summary>
    [Title("webui:controlpage.label")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : IPage<VisualTreeWebApp>, IScopeGeneral, IScopeControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Index()
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {

        }
    }
}