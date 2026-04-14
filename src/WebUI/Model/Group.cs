using System;
using System.Collections.Generic;
using WebExpress.WebCore.WebIdentity;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a group identity with a unique identifier, name, and associated policies.
    /// </summary>
    public class Group : IIdentityGroup
    {
        /// <summary>
        /// Gets or sets the unique identifier for this instance.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name associated with this instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of policy names that are required for access.
        /// </summary>
        public IEnumerable<string> Policies { get; set; }
    }
}
