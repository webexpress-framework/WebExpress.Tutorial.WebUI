using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// The confirmation form of the tutorial: an ordinary form that additionally demonstrates
    /// what a form's footer sections are for.
    /// </summary>
    /// <remarks>
    /// The footer sections are resolved against the <b>runtime type</b> of the form control, so
    /// a fragment can only be aimed at one particular form by giving that form a type of its
    /// own. Without this subclass a footer fragment would have to be scoped to
    /// <see cref="ControlForm"/> and would appear beneath every plain form in the tutorial.
    /// <para>
    /// The form is also what the modal tutorial pages load, which is where the footer shows the
    /// behaviour worth seeing: it is lifted onto the dialog's own footer bar beside the submit
    /// button instead of scrolling away at the end of the body.
    /// </para>
    /// </remarks>
    public class ControlFormConformation : ControlForm
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The form items.</param>
        public ControlFormConformation(string id, params IControlFormItem[] items)
            : base(id, items)
        {
        }
    }
}
