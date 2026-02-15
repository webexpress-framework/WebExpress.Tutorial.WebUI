using System;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a Monkey Island boat or ship entry.
    /// </summary>
    public class Boat : IIndexItem
    {
        /// <summary>
        /// The unique identifier of the boat.
        /// </summary>
        [RestHidden()]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The name of the boat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type or class of the boat (e.g., Galleon, Dinghy, Ghost Ship).
        /// </summary>
        public string BoatType { get; set; }

        /// <summary>
        /// The faction, crew, or owner associated with the boat.
        /// </summary>
        public string Affiliation { get; set; }

        /// <summary>
        /// A short description of the boat.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the boat is supernatural (e.g., ghost ship, cursed vessel).
        /// </summary>
        public bool IsSupernatural { get; set; }

        /// <summary>
        /// The Monkey Island game in which the boat appears.
        /// </summary>
        public string AppearsIn { get; set; }

        /// <summary>
        /// A short description of the crew associated with the boat.
        /// </summary>
        public string Crew { get; set; }

    }
}
