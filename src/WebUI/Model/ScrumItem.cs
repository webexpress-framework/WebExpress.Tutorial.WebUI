using System;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a scrum backlog item in the Monkey Island sample.
    /// </summary>
    public class ScrumItem : IIndexItem
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the icon css class.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the external key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the priority label.
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Gets or sets the story points.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Gets or sets the sprint identifier.
        /// </summary>
        public Guid? SprintId { get; set; }

        /// <summary>
        /// Gets or sets the workflow status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the rank within sprint/backlog.
        /// </summary>
        public int Rank { get; set; }
    }
}
