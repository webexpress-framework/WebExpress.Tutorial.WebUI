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
        private readonly List<Act> _propertyActs = [];
        private readonly List<Act> _itemActs = [];
        private readonly List<Event> _events = [];

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
        /// Returns or sets the controls of the Main Act.  
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
        /// Returns the collection of property acts associated with the stage.  
        /// </summary>  
        public IEnumerable<Act> PropertyActs => _propertyActs;

        /// <summary>  
        /// Returns the collection of item acts associated with the stage.  
        /// </summary>  
        public IEnumerable<Act> ItemActs => _itemActs;

        /// <summary>  
        /// Returns the collection of events associated with the stage.  
        /// </summary>  
        public IEnumerable<Event> Events => _events;

        /// <summary>  
        /// Adds a new property act to the stage.  
        /// </summary>  
        /// <param name="propertyName">The name of the property associated with the act.</param>  
        /// <param name="description">A description of the act, providing context or details.</param>  
        /// <param name="code">The example code or script associated with the act.</param>  
        /// <param name="controls">The controls that are part of this act.</param>  
        public void AddProperty(string propertyName, string description, string code, params IControl[] controls)
        {
            AddProperty(propertyName, description, null, code, controls);
        }

        /// <summary>  
        /// Adds a new property act to the stage.  
        /// </summary>  
        /// <param name="propertyName">The name of the property associated with the act.</param>  
        /// <param name="description">A description of the act, providing context or details.</param>  
        /// <param name="callout">The callout text providing additional information or hints.</param>  
        /// <param name="code">The example code or script associated with the act.</param>  
        /// <param name="controls">The controls that are part of this act.</param>  
        public void AddProperty(string propertyName, string description, string callout, string code, params IControl[] controls)
        {
            _propertyActs.Add(new Act()
            {
                Name = propertyName,
                Description = description,
                Callout = callout,
                Code = code,
                Controls = controls
            });
        }

        /// <summary>  
        /// Adds a new item act to the stage.  
        /// </summary>  
        /// <param name="propertyName">The name of the property associated with the act.</param>  
        /// <param name="description">A description of the act, providing context or details.</param>  
        /// <param name="code">The example code or script associated with the act.</param>  
        /// <param name="controls">The controls that are part of this act.</param>  
        public void AddItem(string propertyName, string description, string code, params IControl[] controls)
        {
            AddItem(propertyName, description, null, code, controls);
        }

        /// <summary>  
        /// Adds a new item act to the stage.  
        /// </summary>  
        /// <param name="propertyName">The name of the property associated with the act.</param>  
        /// <param name="description">A description of the act, providing context or details.</param>  
        /// <param name="callout">The callout text providing additional information or hints.</param>  
        /// <param name="code">The example code or script associated with the act.</param>  
        /// <param name="controls">The controls that are part of this act.</param>  
        public void AddItem(string propertyName, string description, string callout, string code, params IControl[] controls)
        {
            _itemActs.Add(new Act()
            {
                Name = propertyName,
                Description = description,
                Callout = callout,
                Code = code,
                Controls = controls
            });
        }

        /// <summary>  
        /// Adds one or more events to the stage.  
        /// </summary>  
        /// <param name="events">The events to add to the stage.</param>  
        public void AddEvent(params Event[] events)
        {
            _events.AddRange(events);
        }
    }
}
