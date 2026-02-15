using System;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a Monkey Island game entry.
    /// </summary>
    public class Game : IIndexItem
    {
        /// <summary>
        /// The unique identifier of the game.
        /// </summary>
        [RestHidden]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The title of the game.
        /// </summary>
        [RestText]
        public string Name { get; set; }

        /// <summary>
        /// The release year of the game.
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// A short description of the game.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the game is a remake or original.
        /// </summary>
        public bool IsRemake { get; set; }
    }
}