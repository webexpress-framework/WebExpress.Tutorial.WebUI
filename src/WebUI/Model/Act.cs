using System.Collections.Generic;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents an "Act" in the grand stage of controls, including its cast, main number, supporting acts, and script.
    /// This class provides metadata and example code for creating an engaging performance of controls.
    /// </summary>
    public class Act
    {
        /// <summary>
        /// Returns or sets the name of the act.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Returns the list of controls associated with this descriptor.
        /// </summary>
        public IEnumerable<IControl> Controls { get; set; } = [];

        /// <summary>  
        /// Returns or sets the dark mode controls of the main act.  
        /// This property allows access to the controls in the main act or assigns a new control to it.  
        /// </summary>  
        public IEnumerable<IControl> DarkControls { get; set; } = [];

        /// <summary>
        /// Gets or sets the description text for the control descriptor.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the callout text providing additional information or hints.
        /// </summary>
        public string Callout { get; set; }

        /// <summary>
        /// Gets or sets the example code associated with the control descriptor.
        /// </summary>
        public string Code { get; set; }
    }
}
