using System;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a location entity for a selection control within "The Secret of Monkey Island".
    /// </summary>
    public class Location : IIndexItem
    {
        /// <summary>
        /// Returns or sets the unique identifier of the location.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Returns or sets the display name of the location.
        /// </summary>
        [RestText]
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets a short description of the location.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets the island the location belongs to (e.g., "Melee Island", "Monkey Island").
        /// </summary>
        public string Island { get; set; }

        /// <summary>
        /// Returns a string representation including name, description, and island.
        /// </summary>
        /// <returns>A multi-line string describing the location.</returns>
        public override string ToString()
        {
            return $"Text: {Text}\nDescription: {Description}\nIsland: {Island}";
        }
    }
}
