using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment.LoginPage
{
    /// <summary>
    /// Fragment that renders a dark mode toggle button next to the login link.
    /// </summary>
    /// <remarks>
    /// The button is wired up via the client-side "darkmode" action
    /// registered in `action/default.js`. The action reads the current mode
    /// from <c>webexpress.webui.DarkMode</c>, swaps the icon between moon
    /// and sun, and toggles the mode on click.
    /// </remarks>
    [Section<SectionAppAvatarPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Cache]
    public sealed class DarkModeFragment : FragmentControlDropdownItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public DarkModeFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Icon = new IconMoon();
            PrimaryAction = new ActionDarkmode();
            Text = "webexpress.tutorial.webui:darkmode.label";
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            if (!FragmentContext.Conditions.Check(renderContext?.Request))
            {
                return null;
            }

            var textLight = I18N.Translate(renderContext, "webexpress.webui:darkmode.text.light");
            var textDark = I18N.Translate(renderContext, "webexpress.webui:darkmode.text.dark");

            Text = textLight;
            ((ActionDarkmode)PrimaryAction).TextLight = textLight;
            ((ActionDarkmode)PrimaryAction).TextDark = textDark;

            return base.Render(renderContext, visualTree);
        }
    }
}
