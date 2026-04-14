using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Represents a navigation item link for the info page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to create a navigation link to the Info page with an icon and label.
    /// </remarks>
    [Section<SectionAppAvatar>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Cache]
    public sealed class AvatarFragment : FragmentControlAvatar
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public AvatarFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
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

        /// <summary>
        /// Retrieves the URI for the default avatar image used in the application.
        /// </summary>
        /// <param name="renderContext">
        /// The rendering context that provides access to the current page and application context. 
        /// Cannot be null.
        /// </param>
        /// <returns>
        /// An object representing the URI of the default avatar image. Returns null if the application 
        /// context is unavailable.
        /// </returns>
        public override IUri GetImage(IRenderControlContext renderContext)
        {
            var identity = WebEx.ComponentHub.IdentityManager.GetCurrentIdentity(renderContext.Request);

            if (identity is not null)
            {
                return new ImageIconWebExpress(renderContext?.PageContext?.ApplicationContext)?.Uri;
            }

            return base.GetImage(renderContext);
        }
    }
}