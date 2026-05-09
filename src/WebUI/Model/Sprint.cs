using System;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a sprint in the Monkey Island Scrum sample.
    /// </summary>
    public class Sprint : IIndexItem
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sprint name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sprint goal.
        /// </summary>
        public string Goal { get; set; }

        /// <summary>
        /// Gets or sets the sprint status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the start date in yyyy-MM-dd format.
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Gets or sets the end date in yyyy-MM-dd format.
        /// </summary>
        public string End { get; set; }

        /// <summary>
        /// Gets or sets the sprint capacity.
        /// </summary>
        public int Capacity { get; set; }
    }
}
