using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment.FragmentPage
{
    /// <summary>
    /// Represents a fragment control for the tutorial.
    /// </summary>
    [Section<SectionAppQuickcreateSecondary>]
    [Scope<IScopeFragment>]
    [Cache]
    public sealed class SectionAppQuickcreateSecondaryFragment : FragmentControlSplitButtonItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionAppQuickcreateSecondaryFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "SectionAppQuickcreateSecondary";
        }
    }
}
