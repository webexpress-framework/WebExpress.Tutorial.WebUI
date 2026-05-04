using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// Represents a form for managing Monkey Island game data, including title, description, release year, and remake status.
    /// </summary>
    public class ControlRestFormGame : ControlForm
    {
        /// <summary>
        /// Gets or sets the title of the game.
        /// </summary>
        public ControlFormItemInputText GameTitle { get; } = new ControlFormItemInputText
        {
            Label = _ => "Title",
            Name = _ => nameof(Game.Name),
            Placeholder = "Enter the game's title",
            Required = _ => true,
            MaxLength = 100,
            Help = _ => "The official title of the Monkey Island game. This field is required."
        };

        /// <summary>
        /// Gets or sets the description of the game.
        /// </summary>
        public ControlFormItemInputText Description { get; } = new ControlFormItemInputText
        {
            Label = _ => "Description",
            Name = _ => nameof(Game.Description),
            Format = TypeEditTextFormat.Wysiwyg,
            Placeholder = "Enter a brief description of the game",
            Required = _ => true,
            MaxLength = 500,
            Help = _ => "A short summary of the game's story, gameplay, or notable features."
        };

        /// <summary>
        /// Gets or sets the release year of the game.
        /// </summary>
        public ControlFormItemInputText ReleaseYear { get; } = new ControlFormItemInputText
        {
            Label = _ => "Release Year",
            Name = _ => nameof(Game.ReleaseYear),
            Placeholder = "Enter the year the game was released",
            Required = _ => true,
            MaxLength = 4,
            Icon = _ => new IconCalendar(),
            Help = _ => "The year the game was first published. Use four digits (e.g., 1990)."
        };

        /// <summary>
        /// Indicates whether the game is a remake.
        /// </summary>
        public ControlFormItemInputCheck IsRemake { get; } = new ControlFormItemInputCheck
        {
            Label = _ => "Is Remake?",
            Name = _ => nameof(Game.IsRemake),
            Help = _ => "Check this box if the game is a remake or special edition of an earlier title."
        };

        /// <summary>
        /// Gets the submit button control for the form.
        /// </summary>
        public ControlFormItemButtonSubmit Submit { get; } = new ControlFormItemButtonSubmit
        {
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the form control.</param>
        public ControlRestFormGame(string id)
            : base(id)
        {
            Enable = false;

            Add(GameTitle);
            Add(Description);
            Add(ReleaseYear);
            Add(IsRemake);
            AddPrimaryButton(Submit);
        }
    }
}