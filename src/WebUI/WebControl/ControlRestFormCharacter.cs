using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebControl;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// Represents a form for managing character data, including their name, description, and context of
    /// appearance.
    /// </summary>
    /// <remarks>This class provides a structured form for inputting and managing information about a
    /// character.</remarks>
    public class ControlRestFormCharacter : ControlRestForm
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
        public ControlFormItemInputText AppearsIn { get; } = new ControlFormItemInputText
        {
            Label = "Appears In",
            Name = nameof(Character.AppearsIn),
            Placeholder = "Enter the name of the game or context where this character appears",
            Required = true,
            MaxLength = 100,
            Help = "The name of the game or context where this character appears. This field is required and should specify the game or narrative context in which the character is involved."
        };

        /// <summary>
        /// Returns the submit button control for the form.
        /// </summary>
        public ControlFormItemButtonSubmit Submit { get; } = new ControlFormItemButtonSubmit
        {

        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the form control.</param>
        public ControlRestFormCharacter(string id)
            : base(id)
        {
            Enable = false;

            Add(CharacterName);
            Add(Description);
            Add(AppearsIn);
            AddPrimaryButton(Submit);
        }
    }
}
