using System;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebCore.WebUri;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a data entity for a dropdown.
    /// </summary>
    public class Inventory : IIndexItem
    {
        /// <summary>
        /// Returns or sets the identifier of the table data.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Returns or sets the name associated with the object.
        /// </summary>
        [RestText]
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets the description associated with the object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets the URI as a string.
        /// </summary>
        public IUri Uri { get; set; }

        /// <summary>
        /// Returns a string representation of the object, including its name, description, and appearances.
        /// </summary>
        /// <returns>A string containing the object's name, description, and the context in which it appears, formatted as
        /// multiple lines.</returns>
        public override string ToString()
        {
            return $"Text: {Text}\nDescription: {Description}";
        }
    }
}
