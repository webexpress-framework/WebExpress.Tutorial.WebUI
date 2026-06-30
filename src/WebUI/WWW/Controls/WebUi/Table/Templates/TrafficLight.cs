using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table.Templates
{
    /// <summary>
    /// Represents the traffic light template of a table control for the tutorial.
    /// </summary>
    [Title("Traffic Light-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class TrafficLight : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public TrafficLight()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `TrafficLight` template renders a column value as a traffic light. In ReadOnly mode the lamp simply visualizes the status, while in Edit mode the user can change the status directly within the cell. Cell values are the lamp tokens `red`, `yellow`, `green` or empty for off.";

            Stage.Controls =
            [
                new ControlTable("myTable")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.DarkControls =
            [
                new ControlTableReorderable("myTableDark")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.Code = @"
                new ControlTable(""myTable"")
                    .AddColumns(...)
                    .AddRows(...)";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode. In ReadOnly mode the status is shown as a static lamp; in Edit mode the user can change the status inline.",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Orientation",
                "Defines whether the lamps within the cell are stacked vertically or lined up horizontally. The horizontal layout fits the limited height of a table row well.",
                "Orientation = _ => TypeOrientationTrafficLight.Horizontal",
                new ControlTable().AddColumns(CreateColumns(false, TypeOrientationTrafficLight.Horizontal)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates a collection of table columns configured with the specified editability and
        /// orientation.
        /// </summary>
        /// <param name="editable">Whether the column renders an editable traffic light input.</param>
        /// <param name="orientation">How the lamps within the cell are arranged.</param>
        /// <returns>
        /// An enumerable collection of column objects representing the configured table columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, TypeOrientationTrafficLight orientation = TypeOrientationTrafficLight.Vertical)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateTrafficLight()
            {
                Editable = _ => editable,
                Orientation = _ => orientation
            })
            {
                Title = _ => "Status",
                Icon = _ => new IconTrafficLight()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows holding traffic light tokens.
        /// </summary>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = _ => "red" }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = _ => "yellow" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = _ => "green" }
                );
        }
    }
}
