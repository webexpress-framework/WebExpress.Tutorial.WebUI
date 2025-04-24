/**
 * WebExpress WebUI Event Logger Class using jQuery Events
 *
 * This class listens to specific events and updates the associated DOM element
 * with the message from the triggered event.
 */
EventLoggerCtrl = class extends webexpress.webui.Ctrl {
    /**
     * Constructor
     * @param {HTMLElement} element - The DOM element associated with the instance.
     *  - events: A comma-separated list of event IDs to be monitored by the Event Logger.
     */
    constructor(element) {
        super(element); // Call the base Control class constructor

        // Parse the "events" attribute into an array of event IDs
        this._events = ($(element).attr('events') || "")
            .split(' ')
            .map(eventId => eventId.trim())
            .filter(eventId => eventId !== ""); // Filter out empty strings

        // Remove the "events" attribute to clean up the DOM
        $(element).empty().removeAttr('events');

        // Register event listeners
        this.subscribeToEvents();
    }

    /**
     * Subscribes to all events specified in the "events" property.
     */
    subscribeToEvents() {
        this._events.forEach(eventId => {
            const div = $("<div>").html(`<b>Event-Typ:</b> <span style="color: var(--bs-code-color);">${eventId}</span><br><b>Data:</b> <code>null</code><hr>`);
            $(this._element).append(div);
            // Attach an event listener to the document for each event ID
            $(document).on(eventId, (event, data) => {
                console.log(eventId, event, data);
                div.html(`<b>Event-Typ:</b> <span style="color: var(--bs-code-color);">${eventId}</span><br><b>Data:</b> <pre>${JSON.stringify(data, null, 4)}</pre><hr>`);
                $(this._element).prepend(div);
            });
        });
    }

    /**
     * Unsubscribes from all registered events.
     * This is useful for cleanup when the control is destroyed.
     */
    unsubscribeFromEvents() {
        this._events.forEach(eventId => {
            $(document).off(eventId); // Unbind all listeners for the event ID
        });
    }

    /**
     * Renders the Event Logger Control.
     * Displays the current state of the logger in the DOM element.
     */
    render() {
    }

    /**
     * Destroys the control and cleans up resources.
     * Unsubscribes from all events and calls the base class's destroy method.
     */
    destroy() {
        this.unsubscribeFromEvents();
        super.destroy(); // Call the base class's destroy method
    }

    // Getter and setter for the "events" property

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
        this.unsubscribeFromEvents(); // Unsubscribe from old events
        this._events = eventList
            .map(eventId => eventId.trim())
            .filter(eventId => eventId !== ""); // Filter out empty strings
        this.subscribeToEvents(); // Subscribe to new events
        this.render(); // Re-render the logger
    }
};

// Register the class in the controller
webexpress.webui.Controller.registerClass('wx-eventlogger', EventLoggerCtrl);