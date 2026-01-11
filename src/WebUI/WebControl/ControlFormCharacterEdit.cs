using WebExpress.Tutorial.WebUI.Model;
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
    public class ControlFormCharacterEdit : ControlRestFormEdit
    {
        /// <summary>
        /// Returns or sets the name associated with the object.
        /// </summary>
        public ControlFormItemInputText CharacterName { get; } = new ControlFormItemInputText
        {
            Label = "Name",
            Name = nameof(Character.Name),
            Placeholder = "Enter the character's name",
            Required = true,
            MaxLength = 100,
            Icon = new IconUser(),
            Help = "The name of the character. This is a required field and should be unique."
        };

        /// <summary>
        /// Returns or sets the description associated with the object.
        /// </summary>
        public ControlFormItemInputText Description { get; } = new ControlFormItemInputText
        {
            Label = "Description",
            Name = nameof(Character.Description),
            Format = TypeEditTextFormat.Wysiwyg,
            Placeholder = "Enter a brief description of the character",
            Required = true,
            MaxLength = 500,
            Help = "A brief description of the character. This field is required and can include details about the character's role, personality, and background."
        };

        /// <summary>
        /// Returns or sets the name of the context or entity where this item appears.
        /// </summary>
        public ControlFormItemInputTag AppearsIn { get; } = new ControlFormItemInputTag
        {
            Label = "Appears In",
            Name = nameof(Character.AppearsIn),
            Placeholder = "Enter the name of the game or context where this character appears",
            Required = true,
            Help = "The name of the game or context where this character appears. This field is required and should specify the game or narrative context in which the character is involved."
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the form control.</param>
        public ControlFormCharacterEdit(string id)
            : base(id)
        {
            Enable = false;

            Add(CharacterName);
            Add(Description);
            Add(AppearsIn);
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
