using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WebFragment.FragmentPage
{
    /// <summary>
    /// Represents a fragment control for the tutorial.
    /// </summary>
    [Section<SectionAppSearch>]
    [Scope<IScopeFragment>]
    [Cache]
    public sealed class SectionAppSearchFragment : FragmentControlSearch
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionAppSearchFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Placeholder = _ => "SectionAppSearch";
            Icon = _ => new IconMagnifyingGlass();
        }
    }
}
