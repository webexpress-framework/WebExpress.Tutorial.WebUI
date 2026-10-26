using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Demonstrates a scoped banner configured and registered entirely in C#.
    /// </summary>
    [Section<SectionBodySecondary>]
    [Scope<IScopeCookieBannerExample>]
    public sealed class CookieBannerFragment : FragmentControlCookieBanner
    {
        /// <summary>
        /// Configures a notice fragment with the application's privacy destination.
        /// </summary>
        /// <param name="componentHub">The component hub resolving the application sitemap.</param>
        /// <param name="fragmentContext">The scope and conditions supplied by fragment discovery.</param>
        public CookieBannerFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Mode = _ => TypeCookieBannerMode.Notice;
            StorageKey = _ => "tutorial:cookie-fragment";
            PrivacyUri = _ => componentHub.SitemapManager.GetUri<Privacy>(fragmentContext.ApplicationContext);
            PrivacyLabel = _ => "webexpress.tutorial.webui:privacy.title";
        }
    }
}
