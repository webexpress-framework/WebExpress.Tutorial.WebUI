using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebSection;

namespace WebExpress.Tutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Fills the secondary section of the tutorial's composed box, which puts it after the
    /// content the box adds itself.
    /// </summary>
    /// <remarks>
    /// It is scoped to <see cref="ControlBoxComposed"/> rather than to <see cref="ControlBox"/>
    /// because the sections resolve against the runtime type of the box, and the tutorial has
    /// many plain boxes this line does not belong in.
    /// </remarks>
    [Section<SectionBoxSecondary>]
    [Scope<ControlBoxComposed>]
    [Cache]
    public sealed class SectionBoxSecondaryFragment : FragmentControlText
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionBoxSecondaryFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = _ => "SectionBoxSecondary — contributed by a fragment, rendered after the content the box adds itself.";
            Format = _ => TypeFormatText.Small;
            TextColor = _ => new PropertyColorText(TypeColorText.Secondary);
        }
    }
}
