using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.WebConverter;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebApp.WebRestApi.WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebDomain;
using WebExpress.WebIndex;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a data entity for a table.
    /// </summary>
    public class Character : IIndexItem, IDomain
    {
        /// <summary>
        /// Returns or sets the identifier of the table data.
        /// </summary>
        [RestHidden()]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Returns or sets the name associated with the object.
        /// </summary>
        [RestTableColumnName("Name")]
        [ValidateRequired()]
        public string Name { get; set; }

        /// <summary>
        /// Returns or sets the description associated with the object.
        /// </summary>
        [RestTableColumnName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets the name of the context or entity where this item appears.
        /// </summary>
        [RestTableColumnName("Appears in")]
        [RestApiTableColumnTemplateTag(true, TypeColorTag.Warning, "appears in")]
        [RestConverter<AppearsConverter>()]
        public IEnumerable<Game> AppearsIn { get; set; }

        /// <summary>
        /// Returns the icon associated with this character.
        /// </summary>
        [RestHidden]
        [RestIcon]
        [RestConverter<RestValueConverterImageIcon>]
        public ImageIcon Icon { get; set; }

        /// <summary>
        /// Returns a string representation of the object, including its name, description, and appearances.
        /// </summary>
        /// <returns>A string containing the object's name, description, and the context in which it appears, formatted as
        /// multiple lines.</returns>
        public override string ToString()
        {
            return $"Name: {Name}\nDescription: {Description}\nAppears in: {AppearsIn}";
        }
    }
}
