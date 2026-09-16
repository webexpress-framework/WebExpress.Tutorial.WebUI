using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// The box of the tutorial whose body is composed from fragments: an ordinary box that
    /// only exists to have a type of its own.
    /// </summary>
    /// <remarks>
    /// The box sections are resolved against the <b>runtime type</b> of the box control, so a
    /// fragment can only be aimed at one particular box by giving that box a type of its own.
    /// Without this subclass a contributing fragment would have to be scoped to
    /// <see cref="ControlBox"/> and would appear inside every plain box in the tutorial.
    /// </remarks>
    public class ControlBoxComposed : ControlBox
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="controls">The child controls that make up the box body.</param>
        public ControlBoxComposed(string id = null, params IControl[] controls)
            : base(id, controls)
        {
        }
    }
}
