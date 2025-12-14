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
        /// Returns or sets the title of the game.
        /// </summary>
        public ControlFormItemInputText GameTitle { get; } = new ControlFormItemInputText
        {
            Label = "Title",
            Name = nameof(Game.Name),
            Placeholder = "Enter the game's title",
            Required = true,
            MaxLength = 100,
            Help = "The official title of the Monkey Island game. This field is required."
        };

        /// <summary>
        /// Returns or sets the description of the game.
        /// </summary>
        public ControlFormItemInputText Description { get; } = new ControlFormItemInputText
        {
            Label = "Description",
            Name = nameof(Game.Description),
            Format = TypeEditTextFormat.Wysiwyg,
            Placeholder = "Enter a brief description of the game",
            Required = true,
            MaxLength = 500,
            Help = "A short summary of the game's story, gameplay, or notable features."
        };

        /// <summary>
        /// Returns or sets the release year of the game.
        /// </summary>
        public ControlFormItemInputText ReleaseYear { get; } = new ControlFormItemInputText
        {
            Label = "Release Year",
            Name = nameof(Game.ReleaseYear),
            Placeholder = "Enter the year the game was released",
            Required = true,
            MaxLength = 4,
            Icon = new IconCalendar(),
            Help = "The year the game was first published. Use four digits (e.g., 1990)."
        };

        /// <summary>
        /// Indicates whether the game is a remake.
        /// </summary>
        public ControlFormItemInputCheck IsRemake { get; } = new ControlFormItemInputCheck
        {
            Label = "Is Remake?",
            Name = nameof(Game.IsRemake),
            Help = "Check this box if the game is a remake or special edition of an earlier title."
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