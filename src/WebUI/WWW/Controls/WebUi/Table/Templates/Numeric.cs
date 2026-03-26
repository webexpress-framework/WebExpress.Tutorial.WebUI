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
    /// Represents the numeric template of a table control for the tutorial.    
    /// </summary>    
    [Title("Numeric-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Numeric : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        public Numeric()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = Stage.Description = @"The `Numeric` template defines how numeric values are displayed within a table column. It supports both a ReadOnly mode for presenting formatted numbers and an Edit mode that allows users to modify the value directly within the table. The template is suitable for integer and decimal inputs, inline editing scenarios, and cases where placeholders, numeric validation, or color‑based highlighting are required.";

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
                "Color",
                "The `Color` property defines the visual color applied to all selected tags within the `Tag` template component. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "Color = new PropertyColorTag(TypeColorTag.Warning)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Default))).AddRows(CreateRows()),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Primary))).AddRows(CreateRows()),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Secondary))).AddRows(CreateRows()),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Info))).AddRows(CreateRows()),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Success))).AddRows(CreateRows()),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Warning))).AddRows(CreateRows()),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Danger))).AddRows(CreateRows()),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Light))).AddRows(CreateRows()),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText(TypeColorText.Dark))).AddRows(CreateRows()),
                new ControlText() { Text = "User defind", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorText("gold"))).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the default text or tag shown when no value is provided within the `Tag` template column. It helps guide users by indicating the expected input or by visually marking empty fields.",
                "Placeholder = \"Enter value\"",
                new ControlTable().AddColumns(CreateColumns(true, null, "Enter value")).AddRows(CreateRows(true))
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
        /// <returns>
        /// An enumerable collection of columns objects representing the configured table
        /// columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, PropertyColorText color = null, string placeholder = null)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateNumeric()
            {
                Editable = editable,
                Color = color,
                Placeholder = placeholder
            })
            {
                Title = "My column",
                Icon = new IconBowlingBall()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows with optional cell text content.
        /// </summary>
        /// <param name="empty">
        /// If set to true, the cell text values will be null; otherwise, each cell 
        /// will contain a predefined string.
        /// </param>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows(bool empty = false)
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = !empty ? "10" : "" }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = !empty ? "20" : "" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = !empty ? "30" : "" }
                );
        }
    }
}
