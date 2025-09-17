using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment.FragmentPage
{
    /// <summary>
    /// Represents a fragment control for the tutorial.
    /// </summary>
    [Section<SectionToolbarPrimary>]
    [Scope<IScopeFragment>]
    [Cache]
    public sealed class SectionToolbarPrimaryFragment : FragmentControlToolbarItemButton
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionToolbarPrimaryFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Label = "SectionToolbarPrimary";
        }
    }
}
