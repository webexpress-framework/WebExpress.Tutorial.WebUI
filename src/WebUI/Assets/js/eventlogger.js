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
            div.className = "wx-eventlogger-entry";
            const value = this._renderEntry(div, eventId);
            value.textContent = "null";
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
                const pre = document.createElement("pre");
                pre.textContent = JSON.stringify(webexpress.webui.EventLoggerCtrl.describe(data), null, 4);
                this._renderEntry(div, eventId).appendChild(pre);
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
     * Writes the frame of a log entry and returns the element that takes the data.
     * The event id and the data are text, so a payload that carries markup is shown
     * rather than interpreted.
     * @param {HTMLElement} div - The entry element.
     * @param {string} eventId - The event id.
     * @returns {HTMLElement} The data element.
     */
    _renderEntry(div, eventId) {
        const typeLabel = document.createElement("b");
        typeLabel.textContent = "Event-Typ:";
        const type = document.createElement("span");
        type.className = "wx-eventlogger-type";
        type.textContent = eventId;
        const dataLabel = document.createElement("b");
        dataLabel.textContent = "Data:";
        const value = document.createElement("span");
        value.className = "wx-eventlogger-value";
        div.replaceChildren(typeLabel, " ", type, ",", document.createElement("br"), dataLabel, " ", value);
        return value;
    }

    /**
     * Turns an event payload into a value JSON can write. A payload may hold DOM nodes
     * and records that point back at their owners (a table row and its element, a tree
     * row and its parent), which JSON cannot follow; a node is shown by its tag, and a
     * record already open further up is shown as circular.
     * @param {*} value - The payload.
     * @param {Array<object>} [open=[]] - The records being described further up.
     * @param {number} [depth=0] - The nesting depth.
     * @returns {*} A JSON-safe copy.
     */
    static describe(value, open = [], depth = 0) {
        if (value === null || typeof value !== "object") {
            return typeof value === "function" ? "[Function]" : value;
        }
        if (typeof Node !== "undefined" && value instanceof Node) {
            return "<" + (value.nodeName || "node").toLowerCase() + (value.id ? "#" + value.id : "") + ">";
        }
        if (open.includes(value)) {
            return "[Circular]";
        }
        if (depth >= 8) {
            return "[...]";
        }

        const inner = open.concat([value]);
        if (Array.isArray(value)) {
            return value.map((item) => webexpress.webui.EventLoggerCtrl.describe(item, inner, depth + 1));
        }

        const copy = {};
        for (const key of Object.keys(value)) {
            copy[key] = webexpress.webui.EventLoggerCtrl.describe(value[key], inner, depth + 1);
        }
        return copy;
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