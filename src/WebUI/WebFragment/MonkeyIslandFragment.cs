using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Offers the Monkey Island icon set in the user menu.
    /// </summary>
    /// <remarks>
    /// An icon set is a stylesheet of mask rules, so choosing one is adding a link element -
    /// which is why this entry needs no round trip and takes effect on every page at once.
    /// The switching itself lives in <c>assets/js/monkeyisland.js</c>, bound by a delegated
    /// listener to the data attributes added below, so the menu item carries no behaviour of
    /// its own.
    /// <para>
    /// The same drawings are also available the theme way, through
    /// <see cref="WebTheme.MonkeyIslandTheme"/>; both read the same override stylesheet.
    /// </para>
    /// </remarks>
    [Section<SectionAppAvatarPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Cache]
    public sealed class MonkeyIslandFragment : FragmentControlDropdownItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public MonkeyIslandFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Icon = _ => new IconSkull();
            Text = _ => "webexpress.tutorial.webui:iconset.monkeyisland.label";
            Tooltip = _ => "webexpress.tutorial.webui:iconset.monkeyisland.tooltip";
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            // the include mechanism mounts a plugin's assets under the plugin id, but this
            // plugin's assets are the application's own and are served from the application
            // route, so the script has to be linked the way the tutorial's controls link theirs
            visualTree.AddHeaderScriptLink(renderContext.PageContext.ApplicationContext.Route.Concat("assets/js/monkeyisland.js").ToString());

            var html = base.Render(renderContext, visualTree) as IHtmlElement;

            // the dropdown rebuilds its items from the server markup and keeps only data
            // attributes - a class would be dropped, and a wx-prefixed one would even be
            // mistaken for a background colour
            html?.AddUserAttribute("data-wx-iconset", "monkeyisland");

            // the stylesheet is an asset of the application, not of the plugin that ships the
            // script, so only the server knows its address; deriving it client-side from the
            // script url lands on the plugin mount point instead
            html?.AddUserAttribute
            (
                "data-wx-iconset-href",
                renderContext.PageContext.ApplicationContext.Route.Concat("assets/css/monkeyisland.icons.css").ToString()
            );

            return html;
        }
    }
}
