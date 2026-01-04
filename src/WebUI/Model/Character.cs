using System;
using System.Collections.Generic;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebCore.WebDomain;
using WebExpress.WebIndex;
using WebExpress.WebUI.WebControl;

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
        [RestTableColumnHidden()]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Returns or sets the name associated with the object.
        /// </summary>
        [RestTableColumnName("Name")]
        //[Require]
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
        [RestTableJoin(';')]
        [RestApiTableColumnTemplateTag(true, TypeColorTag.Warning, "appears in")]
        public IEnumerable<string> AppearsIn { get; set; }

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
