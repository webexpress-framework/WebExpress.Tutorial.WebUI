using WebExpress.Tutorial.WebUI.WWW;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Makes the landing example discoverable from the tutorial navigation.
    /// </summary>
    [Section<SectionAppNavigationPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Scope<IScopeLogin>]
    public sealed class LandingNavigationFragment : FragmentControlNavigationItemLink
    {
        /// <summary>
        /// Resolves the example destination from the application sitemap.
        /// </summary>
        /// <param name="componentHub">The component hub providing sitemap access.</param>
        /// <param name="fragmentContext">The navigation fragment registration.</param>
        public LandingNavigationFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = _ => "webexpress.tutorial.webui:landing.title";
            Uri = _ => componentHub.SitemapManager.GetUri<Landing>(fragmentContext.ApplicationContext);
        }
    }
}
