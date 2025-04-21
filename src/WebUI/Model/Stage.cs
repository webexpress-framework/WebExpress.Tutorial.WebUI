using System.Collections.Generic;
using System.Linq;
using WebExpress.WebUI.WebControl;

namespace WebUI.Model
{
    /// <summary>
    /// Represents the grand "Stage" where the acts (Main Act and Supporting Acts) come to life.
    /// This class serves as the foundation for orchestrating the performances of controls.
    /// </summary>
    public class Stage
    {
        private readonly Act _mainAct = new();
        private readonly List<Act> _supportingActs = [];

        /// <summary>
        /// Returns or sets the description of the Main Act.
        /// This property provides a convenient way to access or modify the description of the Main Act directly.
        /// </summary>
        public string Description
        {
            get { return _mainAct.Description; }
            set { _mainAct.Description = value; }
        }

        /// <summary>
        /// Returns or sets the control sof the Main Act.
        /// This property allows access to the controls in the Main Act or assigns a new control to it.
        /// </summary>
        public IEnumerable<IControl> Controls
        {
            get { return _mainAct.Controls; }
            set { _mainAct.Controls = value; }
        }

        /// <summary>
        /// Returns or sets the primary control of the Main Act.
        /// This property allows access to the first control in the Main Act or assigns a new control to it.
        /// </summary>
        public IControl Control
        {
            get { return _mainAct.Controls?.FirstOrDefault(); }
            set { _mainAct.Controls = [value]; }
        }

        /// <summary>
        /// Returns or sets the example code associated with the Main Act.
        /// This property allows for the retrieval or assignment of the code snippet
        /// that represents the Main Act's functionality or behavior.
        /// </summary>
        public string Code
        {
            get { return _mainAct.Code; }
            set { _mainAct.Code = value; }
        }

        /// <summary>
        /// Returns the collection of supporting acts associated with the stage.
        /// </summary>
        public IEnumerable<Act> SupportedActs => _supportingActs;

        /// <summary>
        /// Adds a new supporting act to the stage.
        /// </summary>
        /// <param name="propertyName">The name of the property associated with the act.</param>
        /// <param name="description">A description of the act, providing context or details.</param>
        /// <param name="code">The example code or script associated with the act.</param>
        /// <param name="controls">The controls that are part of this act.</param>
        public void Add(string propertyName, string description, string code, params IControl[] controls)
        {
            Add(propertyName, description, null, code, controls);
        }

        /// <summary>
        /// Adds a new supporting act to the stage.
        /// </summary>
        /// <param name="propertyName">The name of the property associated with the act.</param>
        /// <param name="description">A description of the act, providing context or details.</param>
        /// <param name="callout">The callout text providing additional information or hints.</param>
        /// <param name="code">The example code or script associated with the act.</param>
        /// <param name="controls">The controls that are part of this act.</param>
        public void Add(string propertyName, string description, string callout, string code, params IControl[] controls)
        {
            _supportingActs.Add(new Act()
            {
                Name = propertyName,
                Description = description,
                Callout = callout,
                Code = code,
                Controls = controls
            });
        }
    }
}
