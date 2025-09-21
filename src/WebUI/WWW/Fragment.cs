using WebExpress.Tutorial.WebUI.WebFragment.FragmentPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW
{
    /// <summary>
    /// Represents the fragment page for the tutorial.
    /// </summary>
    [WebIcon<IconExpand>]
    [Title("webexpress.tutorial.webui:fragmentpage.label")]
    [Description("webexpress.tutorial.webui:fragmentpage.description")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeFragment>]
    public sealed class Fragment : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class with the specified page context.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Fragment(IPageContext pageContext)
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
