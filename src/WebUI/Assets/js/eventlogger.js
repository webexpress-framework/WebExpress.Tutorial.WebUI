/**
 * WebExpress WebUI Event Logger Class using jQuery Events
 *
 * This class listens to specific events and updates the associated DOM element
 * with the message from the triggered event.
 */
webexpress.webui.EventLoggerCtrl = class extends webexpress.webui.Ctrl {
    /**
     * Constructor
     * @param {HTMLElement} element - The DOM element associated with the instance.
     *  - events: A space-separated list of event IDs to be monitored by the Event Logger.
     */
    constructor(element) {
        super(element);

        // Parse the "events" attribute into an array of event IDs
        this._events = (element.getAttribute('events') || "")
            .split(' ')
            .map(eventId => eventId.trim())
            .filter(eventId => eventId !== "");

        // Remove the "events" attribute and clear content
        element.innerHTML = "";
        element.removeAttribute('events');

        // Internal structure for tracking event listeners and divs
        this._listenerRefs = [];
        this.subscribeToEvents();
    }

    /**
     * Subscribes to all events specified in the "events" property.
     */
    subscribeToEvents() {
        // Remove all existing log entries
        this._element.innerHTML = "";
        this._listenerRefs = [];

        this._events.forEach(eventId => {
            // Create a div for the event log entry
            const div = document.createElement("div");
            div.innerHTML = `<b>Event-Typ:</b> <span class="text-primary">${eventId}</span>,<br><b>Data:</b> <span class="text-light">null</span>`;
            this._element.appendChild(div);

            // Handler for the event
            const handler = (event) => {
                // For jQuery compatibility: try to extract detail if it's a CustomEvent, else raw event data
                let data = null;
                if (event.detail !== undefined) {
                    data = event.detail;
                } else if (event.data !== undefined) {
                    data = event.data;
                }
                // Logging
                console.log(eventId, event, data);
                div.innerHTML = `<b>Event-Typ:</b> <span class="text-primary">${eventId}</span>,<br><b>Data:</b> <span class="text-light"><pre>${JSON.stringify(data, null, 4)}</pre></span>`;
                // Move this div to the top
                if (this._element.firstChild !== div) {
                    this._element.insertBefore(div, this._element.firstChild);
                }
            };

            // Event registration on document
            document.addEventListener(eventId, handler);
            this._listenerRefs.push({ eventId, handler });
        });
    }

    /**
     * Unsubscribes from all registered events.
     * This is useful for cleanup when the control is destroyed.
     */
    unsubscribeFromEvents() {
        this._listenerRefs.forEach(ref => {
            document.removeEventListener(ref.eventId, ref.handler);
        });
        this._listenerRefs = [];
    }

    /**
     * Renders the Event Logger Control.
     */
    render() {
        // No-op for now: UI updates are handled in subscribeToEvents
    }

    /**
     * Destroys the control and cleans up resources.
     */
    destroy() {
        this.unsubscribeFromEvents();
        super.destroy();
    }

    /**
     * Gets the list of events the logger is listening to.
     * @returns {string[]} - Array of event IDs.
     */
    get events() {
        return this._events;
    }

    /**
     * Sets a new list of events for the logger.
     * Automatically unsubscribes from old events and subscribes to the new ones.
     * @param {string[]} eventList - Array of new event IDs.
     */
    set events(eventList) {
        this.unsubscribeFromEvents();
        this._events = eventList
            .map(eventId => eventId.trim())
            .filter(eventId => eventId !== "");
        this.subscribeToEvents();
        this.render();
    }
};

// Register the class in the controller
webexpress.webui.Controller.registerClass('wx-webui-eventlogger', webexpress.webui.EventLoggerCtrl);