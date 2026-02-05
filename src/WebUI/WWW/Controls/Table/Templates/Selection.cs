using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Table.Templates
{
    /// <summary>    
    /// Represents the selection template of a table control for the tutorial.    
    /// </summary>    
    [Title("Selection-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Selection : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        public Selection()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Selection` template provides an interactive way to present and choose values within a column. It supports both ReadOnly mode for displaying selections and Edit mode for modifying them. This enables values to be highlighted with tags, icons, or colors while allowing users to view or actively change the selected option.";

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
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode. In ReadOnly mode, values are shown as static tags for clear visualization. In Edit mode, users can directly modify the values within the column, enabling interactive data editing.",
                "Editable = true",
                new ControlText() { Text = "false", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = "true", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the default text or tag shown when no value is provided within the `Tag` template column. It helps guide users by indicating the expected input or by visually marking empty fields.",
                "Placeholder = \"Enter value\"",
                new ControlTable().AddColumns(CreateColumns(true, null, "Enter value")).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
               "MultiSelect",
               "The `MultiSelect` property enables selecting multiple values within a `Selection` template column. When activated, users can choose more than one option, allowing the column to represent sets of values instead of a single entry.",
               "MultiSelect = \"true\"",
               new ControlTable().AddColumns(CreateColumns(true, null, null, true)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates a collection of table columns configured with the specified editability 
        /// and color tag.
        /// </summary>
        /// <param name="editable">
        /// A value indicating whether the returned columns are editable. If true, columns 
        /// can be modified by the user; otherwise, they are read-only.
        /// </param>
        /// <param name="color">
        /// An optional color tag to associate with the columns. If color is null,
        /// no color is applied.
        /// </param>
        /// <param name="placeholder">The placeholder text.</param>
        /// <param name="multiSelect">
        /// A value indicating whether multiple selections are allowed.
        /// </param>
        /// <returns>
        /// An enumerable collection of columns objects representing the configured table
        /// columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, PropertyColorTag color = null, string placeholder = null, bool multiSelect = false)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateSelection()
            {
                Editable = editable,
                Placeholder = placeholder,
                MultiSelect = multiSelect
            }
                .Add(new ControlFormItemInputSelectionItem("a") { Text = "Option A", Content = new ControlText() { Text = "Option A" }, LabelColor = TypeColorSelection.Primary })
                .Add(new ControlFormItemInputSelectionItem("b") { Text = "Option B", Content = new ControlText() { Text = "Option B" }, LabelColor = TypeColorSelection.Success })
                .Add(new ControlFormItemInputSelectionItem("c") { Text = "Option C", Content = new ControlText() { Text = "Option C" }, LabelColor = TypeColorSelection.Info })
                .Add(new ControlFormItemInputSelectionItem("d") { Text = "Option D", Content = new ControlText() { Text = "Option D" }, LabelColor = TypeColorSelection.Warning }))
            {
                Title = "My column",
                Icon = new IconBowlingBall()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows with optional cell text content.
        /// </summary>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = "a;d" }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = "b" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = "c" }
                );
        }
    }
}
