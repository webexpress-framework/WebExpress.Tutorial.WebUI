using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// Represents a control that logs events occurring within the web application.
    /// </summary>
    public class ControlEventLogger : Control
    {
        private IEnumerable<string> _events = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlEventLogger"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the control.</param>
        /// <param name="events">The list of event names to be logged.</param>
        public ControlEventLogger(string id, params string[] events)
            : base(id)
        {
            _events = events;
        }

        /// <summary>
        /// Adds an event to the logger.
        /// </summary>
        /// <param name="eventName">The name of the event to add.</param>
        public void Add(string eventName)
        {
            if (!_events.Contains(eventName))
            {
                var eventsList = _events.ToList();
                eventsList.Add(eventName);
                _events = eventsList;
            }
        }

        /// <summary>
        /// Removes an event from the logger.
        /// </summary>
        /// <param name="eventName">The name of the event to remove.</param>
        public void Remove(string eventName)
        {
            if (_events.Contains(eventName))
            {
                var eventsList = _events.ToList();
                eventsList.Remove(eventName);
                _events = eventsList;
            }
        }

        /// <summary>
        /// Renders the control as an HTML node.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            visualTree.AddHeaderScriptLink(renderContext.PageContext.ApplicationContext.Route.Concat("assets/js/eventlogger.js").ToString());

            var html = new HtmlElementTextContentDiv()
            {
                Id = Id,
                Class = Css.Concatenate("wx-webui-eventlogger", GetClasses())
            };

            // Adds a custom data attribute to store the events as a space-separated string.
            html.AddUserAttribute("events", string.Join(" ", _events));

            return html;
        }
    }
}
