using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents the sidebar fragment for the control page.
    /// This fragment is used to display the primary sidebar section in the control page.
    /// </summary>
    [Section<SectionSidebarPrimary>]
    [Scope<IScopeControl>]
    [Cache]
    [Order(3)]
    public sealed class ControlSidebarFragmentWebAppHeader : FragmentControlSidebarItemHeader
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">
        /// The context of the fragment, providing access to the current state and dependencies.
        /// </param>
        public ControlSidebarFragmentWebAppHeader(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "WebExpress.WebApp";
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return base.Render(renderContext, visualTree);
        }
    }
}
