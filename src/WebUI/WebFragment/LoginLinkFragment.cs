using WebExpress.WebApp.WebCondition;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment.HomePage
{
    /// <summary>
    /// Represents a navigation item link for the home page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to create a log in link to the home page (Index) with an icon and label.
    /// </remarks>
    [Section<SectionAppAvatarPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Condition<ConditionLogout>]
    [Cache]
    public sealed class LoginLinkFragment : FragmentControlDropdownItemLink
    {
        private readonly IComponentHub _componentHub;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LoginLinkFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            _componentHub = componentHub;
        }

        /// <summary>
        /// Convert the control to HTML.
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