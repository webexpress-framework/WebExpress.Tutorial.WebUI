using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>  
    /// Represents the grand "Stage" where the acts (main act and supporting acts) come to life.  
    /// This class serves as the foundation for orchestrating the performances of controls.  
    /// </summary>  
    public class Stage
    {
        private readonly Act _mainAct = new();
        private readonly List<Act> _propertyActs = [];
        private readonly List<Act> _itemActs = [];
        private readonly List<Act> _itemPropertyActs = [];
        private readonly List<Event> _events = [];

        /// <summary>  
        /// Returns or sets the description of the main act.  
        /// This property provides a convenient way to access or modify the description of the Main Act directly.  
        /// </summary>  
        public string Description
        {
            get { return _mainAct.Description; }
            set { _mainAct.Description = value; }
        }

        /// <summary>  
        /// Returns or sets the controls of the main act.  
        /// This property allows access to the controls in the Main Act or assigns a new control to it.  
        /// </summary>  
        public IEnumerable<IControl> Controls
        {
            get { return _mainAct.Controls; }
            set { _mainAct.Controls = value; }
        }

        /// <summary>  
        /// Returns or sets the primary control of the main act.  
        /// This property allows access to the first control in the main act or assigns a new control to it.  
        /// </summary>  
        public IControl Control
        {
            get { return _mainAct.Controls?.FirstOrDefault(); }
            set { _mainAct.Controls = [value]; }
        }

        /// <summary>  
        /// Returns or sets the dark mode controls of the main act.  
        /// This property allows access to the controls in the main act or assigns a new control to it.  
        /// </summary>  
        public IEnumerable<IControl> DarkControls
        {
            get { return _mainAct.DarkControls; }
            set { _mainAct.DarkControls = value; }
        }

        /// <summary>  
        /// Returns or sets the example code associated with the main act.  
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
        /// Returns the collection of item acts associated with the stage.  
        /// </summary>  
        public IEnumerable<Act> ItemPropertyActs => _itemPropertyActs;

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
        /// <param name="itemType">
        /// The type of the item to which the property is associated.
        /// </param>
        /// <param name="propertyName">The name of the property associated with the act.</param>  
        /// <param name="description">A description of the act, providing context or details.</param>  
        /// <param name="code">The example code or script associated with the act.</param>  
        /// <param name="controls">The controls that are part of this act.</param>  
        public void AddItem(Type itemType, string propertyName, string description, string code, params IControl[] controls)
        {
            AddItem(itemType, propertyName, description, null, code, controls);
        }

        /// <summary>  
        /// Adds a new item act to the stage.  
        /// </summary>  
        /// <param name="itemType">
        /// The type of the item to which the property is associated.
        /// </param>
        /// <param name="propertyName">The name of the property associated with the act.</param>  
        /// <param name="description">A description of the act, providing context or details.</param>  
        /// <param name="callout">The callout text providing additional information or hints.</param>  
        /// <param name="code">The example code or script associated with the act.</param>  
        /// <param name="controls">The controls that are part of this act.</param>  
        public void AddItem(Type itemType, string propertyName, string description, string callout, string code, params IControl[] controls)
        {
            _itemActs.Add(new Act()
            {
                Name = propertyName,
                Description = description,
                Callout = callout,
                Code = code,
                Controls = controls,
                Type = itemType
            });
        }

        /// <summary>
        /// Adds a property definition to the item, including metadata and 
        /// associated controls.
        /// </summary>
        /// <param name="itemType">
        /// The type of the item to which the property is associated.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property to add.
        /// </param>
        /// <param name="description">
        /// A description of the property's purpose or usage.
        /// </param>
        /// <param name="code">
        /// A code or identifier for the property.
        /// </param>
        /// <param name="controls">
        /// An array of controls associated with the property. Can be empty if no 
        /// controls are required.
        /// </param>
        public void AddItemProperty(Type itemType, string propertyName, string description, string code, params IControl[] controls)
        {
            _itemPropertyActs.Add(new Act()
            {
                Name = propertyName,
                Description = description,
                Code = code,
                Controls = controls,
                Type = itemType
            });
        }

        /// <summary>
        /// Adds a property definition to the item, including metadata and 
        /// associated controls.
        /// </summary>
        /// <param name="itemType">
        /// The type of the item to which the property is associated.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property to add.
        /// </param>
        /// <param name="description">
        /// A description of the property's purpose or usage.
        /// </param>
        /// <param name="callout">
        /// An optional callout or additional information related to the property.
        /// </param>
        /// <param name="code">
        /// A code or identifier for the property.
        /// </param>
        /// <param name="controls">
        /// An array of controls associated with the property. Can be empty if no 
        /// controls are required.
        /// </param>
        public void AddItemProperty(Type itemType, string propertyName, string description, string callout, string code, params IControl[] controls)
        {
            _itemPropertyActs.Add(new Act()
            {
                Name = propertyName,
                Description = description,
                Callout = callout,
                Code = code,
                Controls = controls,
                Type = itemType
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
