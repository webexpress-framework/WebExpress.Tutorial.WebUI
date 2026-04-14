using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.WebConverter;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebCore.WebDomain;
using WebExpress.WebCore.WebIdentity;
using WebExpress.WebIndex;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a data entity for a table.
    /// </summary>
    public class Character : IIndexItem, IDomain, IIdentity
    {
        /// <summary>
        /// Gets or sets the identifier of the table data.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        [ValidateRequired()]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description associated with the object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the context or entity where this item appears.
        /// </summary>
        [RestConverter<AppearsConverter>()]
        public IEnumerable<Game> AppearsIn { get; set; }

        /// <summary>
        /// Gets or sets the icon associated with this character.
        /// </summary>
        public ImageIcon Icon { get; set; }

        /// <summary>
        /// Gets the email address associated with the user.
        /// </summary>
        public string Email => "";

        /// <summary>
        /// Gets the hashed representation of the user's password.
        /// </summary>
        public string PasswordHash => "";

        /// <summary>
        /// Gets or sets the collection of identity groups associated with the current user.
        /// </summary>
        public IEnumerable<IIdentityGroup> Groups { get; set; }

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
