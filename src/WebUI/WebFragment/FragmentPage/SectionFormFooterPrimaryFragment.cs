using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebSection;

namespace WebExpress.Tutorial.WebUI.WebFragment.FragmentPage
{
    /// <summary>
    /// Fills the footer section of the tutorial's confirmation form.
    /// </summary>
    /// <remarks>
    /// The form footer is where a form states what comments on the decision its buttons take -
    /// a save state, a hint, a validation summary - so it is rendered on the same bar as those
    /// buttons rather than at the end of the body. Opening the same form through
    /// <c>ModalRemoteForm</c> shows that this holds in a dialog too: the footer is lifted onto
    /// the dialog's footer bar and takes the space to the left of the buttons.
    /// <para>
    /// It is scoped to <see cref="ControlFormConformation"/> rather than to
    /// <see cref="ControlForm"/> because the sections resolve against the runtime type of the
    /// form, and the tutorial has many plain forms this note does not belong under.
    /// </para>
    /// </remarks>
    [Section<SectionFormFooterPrimary>]
    [Scope<ControlFormConformation>]
    [Cache]
    public sealed class SectionFormFooterPrimaryFragment : FragmentControlText
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionFormFooterPrimaryFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = _ => "SectionFormFooterPrimary — rendered on the form's footer, and on the dialog's footer bar when the form is opened as a modal.";
            Format = _ => TypeFormatText.Small;
            TextColor = _ => new PropertyColorText(TypeColorText.Secondary);
        }
    }
}
