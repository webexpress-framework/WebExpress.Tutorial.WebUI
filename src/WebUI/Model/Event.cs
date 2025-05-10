namespace WebUI.Model
{
    /// <summary>
    /// Represents various events that can occur in the WebUI.
    /// </summary>
    public enum Event
    {
        /// <summary>
        /// Event triggered when the visibility of an element changes.
        /// </summary>
        CHANGE_VISIBILITY_EVENT,

        /// <summary>
        /// Event triggered when an element is clicked.
        /// </summary>
        CLICK_EVENT,

        /// <summary>
        /// Event triggered when a filter changes, typically in search or filter controls.
        /// </summary>
        CHANGE_FILTER_EVENT,

        /// <summary>
        /// Event triggered when a dropdown menu is shown.
        /// </summary>
        DROPDOWN_SHOW_EVENT,

        /// <summary>
        /// Event triggered when a dropdown menu is hidden.
        /// </summary>
        DROPDOWN_HIDDEN_EVENT,

        /// <summary>
        /// Event triggered when a favorite changes.
        /// </summary>
        CHANGE_FAVORITE_EVENT,

        /// <summary>
        /// Event triggered when columns are reordered in a table control.
        /// </summary>
        COLUMN_REORDER_EVENT,

        /// <summary>
        /// Event triggered when a table is sorted.
        /// </summary>
        TABLE_SORT_EVENT,

        /// <summary>
        /// Event triggered when the value of an input or control changes.
        /// </summary>
        CHANGE_VALUE_EVENT,

        /// <summary>
        /// Event triggered when a node is moved in a tree control.
        /// </summary>
        MOVE_EVENT,

        /// <summary>
        /// Event triggered when the page changes in a pagination control.
        /// </summary>
        CHANGE_PAGE_EVENT,

        /// <summary>
        /// Event triggered when a modal is shown.
        /// </summary>
        MODAL_SHOW_EVENT,

        /// <summary>
        /// Event triggered when a modal is hidden.
        /// </summary>
        MODAL_HIDE_EVENT
    }

    /// <summary>
    /// Provides extension methods for the <see cref="Event"/> enum.
    /// </summary>
    public static class EventsExtentions
    {
        /// <summary>
        /// Returns the string representation of the event name for the specified <see cref="Event"/> type.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <returns>The string representation of the event name.</returns>
        public static string GetEventName(this Event eventType)
        {
            return eventType switch
            {
                Event.CHANGE_VISIBILITY_EVENT => "webexpress.webui.change.visibility",
                Event.CLICK_EVENT => "webexpress.webui.click",
                Event.CHANGE_FILTER_EVENT => "webexpress.webui.change.filter",
                Event.DROPDOWN_SHOW_EVENT => "webexpress.webui.dropdown.show",
                Event.DROPDOWN_HIDDEN_EVENT => "webexpress.webui.dropdown.hidden",
                Event.CHANGE_FAVORITE_EVENT => "webexpress.webui.change.favorite",
                Event.COLUMN_REORDER_EVENT => "webexpress.webui.table.column.reorder",
                Event.TABLE_SORT_EVENT => "webexpress.webui.table.sorted",
                Event.CHANGE_VALUE_EVENT => "webexpress.webui.change.value",
                Event.MOVE_EVENT => "webexpress.webui.tree.node.move",
                Event.CHANGE_PAGE_EVENT => "webexpress.webui.change.page",
                Event.MODAL_SHOW_EVENT => "webexpress.webui.modal.show",
                Event.MODAL_HIDE_EVENT => "webexpress.webui.modal.hide",
                _ => ""
            };
        }

        /// <summary>
        /// Returns the description of the event for the specified <see cref="Event"/> type.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <returns>The description of the event.</returns>
        public static string GetDescription(this Event eventType)
        {
            return eventType switch
            {
                Event.CHANGE_VISIBILITY_EVENT => "Event triggered when the visibility of an element changes.",
                Event.CLICK_EVENT => "Event triggered when an element is clicked.",
                Event.CHANGE_FILTER_EVENT => "Event triggered when a filter changes, typically in search or filter controls.",
                Event.DROPDOWN_SHOW_EVENT => "Event triggered when a dropdown menu is shown.",
                Event.DROPDOWN_HIDDEN_EVENT => "Event triggered when a dropdown menu is hidden.",
                Event.CHANGE_FAVORITE_EVENT => "Event triggered when a favorite changes.",
                Event.COLUMN_REORDER_EVENT => "Event triggered when columns are reordered in a table control.",
                Event.TABLE_SORT_EVENT => "Event triggered when a table is sorted.",
                Event.CHANGE_VALUE_EVENT => "Event triggered when the value of an input or control changes.",
                Event.MOVE_EVENT => "Event triggered when a node is moved in a tree control.",
                Event.CHANGE_PAGE_EVENT => "Event triggered when the page changes in a pagination control.",
                Event.MODAL_SHOW_EVENT => "Event triggered when a modal is shown.",
                Event.MODAL_HIDE_EVENT => "Event triggered when a modal is hidden.",
                _ => ""
            };
        }
    }
}
