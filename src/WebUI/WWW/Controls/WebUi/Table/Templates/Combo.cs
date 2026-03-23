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
    /// Represents the combo template of a table control for the tutorial.    
    /// </summary>    
    [Title("Combo-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Combo : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        public Combo()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The Combo template provides an interactive dropdown for selecting values within a column. It supports both ReadOnly mode for displaying the current choice and Edit mode for modifying it. This allows values to be presented compactly while enabling users to quickly view or change the selected option.";

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
               "MultiSelect",
               "The `MultiSelect` property enables selecting multiple values within a `Selection` template column. When activated, users can choose more than one option, allowing the column to represent sets of values instead of a single entry.",
               "MultiSelect = \"true\"",
               new ControlTable().AddColumns(CreateColumns(true, true)).AddRows(CreateRows())
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
        /// <param name="multiSelect">
        /// A value indicating whether multiple selections are allowed.
        /// </param>
        /// <returns>
        /// An enumerable collection of columns objects representing the configured table
        /// columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, bool multiSelect = false)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateCombo()
            {
                Editable = editable,
                MultiSelect = multiSelect
            }
                .Add(new ControlFormItemInputComboItem() { Value = "a", Text = "Option A", })
                .Add(new ControlFormItemInputComboItem() { Value = "b", Text = "Option B", })
                .Add(new ControlFormItemInputComboItem() { Value = "c", Text = "Option C", })
                .Add(new ControlFormItemInputComboItem() { Value = "d", Text = "Option D", }))
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
                    new ControlTableCell() { Text = "a" }
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
