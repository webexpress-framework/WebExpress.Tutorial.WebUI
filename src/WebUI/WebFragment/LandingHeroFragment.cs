using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WWW;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Supplies the reference website's hero as scoped WebExpress controls.
    /// </summary>
    [Section<SectionLandingHero>]
    [Scope<Landing>]
    public sealed class LandingHeroFragment : FragmentControlPanel
    {
        /// <summary>
        /// Composes the example independently of the landing page's process method.
        /// </summary>
        /// <param name="componentHub">The component hub resolving local sitemap destinations.</param>
        /// <param name="fragmentContext">The registration restricting the fragment to this example.</param>
        public LandingHeroFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            var content = new LandingExampleContent(componentHub, fragmentContext);
            Add(content.CreateHero());
        }
    }
}
