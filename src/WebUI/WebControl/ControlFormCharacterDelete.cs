using WebExpress.Tutorial.WebUI.WebParamter;
using WebExpress.WebApp.WebControl;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// Represents a form for managing character data, including their name, 
    /// description, and context of appearance.
    /// </summary>
    /// <remarks>
    /// This class provides a structured form for inputting and managing 
    /// information about a character.
    /// </remarks>
    public class ControlFormCharacterDelete : ControlRestForm
    {
        /// <summary>
        /// Returns the submit button control for the form.
        /// </summary>
        public ControlFormItemButtonSubmit Submit { get; } = new ControlFormItemButtonSubmit
        {
            Text = "Delete",
            Icon = new IconTrash(),
            Color = new PropertyColorButton(TypeColorButton.Danger)
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the form control.</param>
        public ControlFormCharacterDelete(string id)
            : base(id)
        {
            Enable = false;

            AddPrimaryButton(Submit);
        }

        /// <summary>
        /// Renders the control as an HTML node.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var id = renderContext.Request.GetParameter<CharacterIdParameter>();

            return base.Render(renderContext, visualTree, Items, id?.Value);
        }
    }
}
