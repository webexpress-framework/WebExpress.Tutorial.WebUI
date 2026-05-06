using System.Linq;
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
        /// Gets or sets the name associated with the object.
        /// </summary>
        public ControlFormItemInputText CharacterName { get; } = new ControlFormItemInputText
        {
            Label = _ => "Name",
            Name = _ => nameof(Character.Name),
            Placeholder = _ => "Enter the character's name",
            Required = _ => true,
            MaxLength = _ => 100,
            Icon = _ => new IconUser(),
            Help = _ => "The name of the character. This is a required field and should be unique."
        };

        /// <summary>
        /// Gets or sets the description associated with the object.
        /// </summary>
        public ControlFormItemInputText Description { get; } = new ControlFormItemInputText
        {
            Label = _ => "Description",
            Name = _ => nameof(Character.Description),
            Format = _ => TypeEditTextFormat.Wysiwyg,
            Placeholder = _ => "Enter a brief description of the character",
            Required = _ => true,
            MaxLength = _ => 500,
            Help = _ => "A brief description of the character. This field is required and can include details about the character's role, personality, and background."
        };

        /// <summary>
        /// Gets or sets the name of the context or entity where this item appears.
        /// </summary>
        public IControlFormItemInputSelection AppearsIn { get; } = new ControlFormItemInputSelection
        {
            Label = _ => "Appears In",
            MultiSelect = _ => true,
            Name = _ => nameof(Character.AppearsIn),
            Placeholder = _ => "Enter the name of the game or context where this character appears",
            Required = _ => true,
            Help = _ => "The name of the game or context where this character appears. This field is required and should specify the game or narrative context in which the character is involved."
        }
            .Add(ViewModel.MonkeyIslandGames.Select(x => new ControlFormItemInputSelectionItem(x.Id.ToString())
            {
                Text = _ => x.Name,
                Color = _ => TypeColorSelection.Primary
            }));

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the form control.</param>
        public ControlFormCharacterEdit(string id)
            : base(id)
        {
            Enable = _ => false;

            Add(CharacterName);
            Add(Description);
            Add(AppearsIn);

            ItemId = renderContext => renderContext.Request.GetParameter<CharacterIdParameter>()?.Value;
        }

        /// <summary>
        /// Renders the control as an HTML node.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext, IVisualTreeControl visualTree)
        {
            return base.Render(renderContext, visualTree);
        }
    }
}
