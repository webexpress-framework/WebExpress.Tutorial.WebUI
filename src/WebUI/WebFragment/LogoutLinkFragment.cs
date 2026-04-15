using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebCondition;
using WebExpress.WebApp.WebFragment;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment.HomePage
{
    /// <summary>
    /// Represents a navigation item link for the home page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to create a navigation link to the home page (Index) with an icon and label.
    /// </remarks>
    [Section<SectionAppAvatarPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Condition<ConditionLogin>]
    [Cache]
    public sealed class LogoutLinkFragment : FragmentControlDropdownItemLinkLogout
    {
        private readonly IComponentHub _componentHub;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LogoutLinkFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            _componentHub = componentHub;
            Text = "webexpress.tutorial.webui:logout.label";
            Icon = new IconPowerOff();
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var logoutUri = _componentHub.SitemapManager.GetUri<Session>(renderContext?.PageContext.ApplicationContext);

            return base.Render(renderContext, visualTree, logoutUri);
        }
    }
}