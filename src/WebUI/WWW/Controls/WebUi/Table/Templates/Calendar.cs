using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Represents the calendar template of a table control for the tutorial.    
    /// </summary>    
    [Title("Calendar-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Calendar : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        public Calendar()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Calendar` template defines the visual representation of date values within a column. It supports both a ReadOnly mode for displaying dates and an Edit mode for directly modifying them.";

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
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Default))).AddRows(CreateRows()),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Primary))).AddRows(CreateRows()),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Secondary))).AddRows(CreateRows()),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Info))).AddRows(CreateRows()),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Success))).AddRows(CreateRows()),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Warning))).AddRows(CreateRows()),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Danger))).AddRows(CreateRows()),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Light))).AddRows(CreateRows()),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate(TypeColorDate.Dark))).AddRows(CreateRows()),
                new ControlText() { Text = "User defind", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, new PropertyColorDate("gold"))).AddRows(CreateRows())
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
                "Format",
                "The `Format` property defines how date values are visually represented within the `Date` template column. By specifying a format string (e.g., `dd/MM/yyyy`), you can control the appearance of the date, ensuring consistency and clarity across the user interface.",
                "Format = \"dd/MM/yyyy\"",
                new ControlTable().AddColumns(CreateColumns(true, null, null, "dd.MM.yyyy")).AddRows(CreateRows("dd.MM.yyyy"))
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
        private IEnumerable<IControlTableColumn> CreateColumns
        (
            bool editable = false,
            PropertyColorDate color = null,
            string placeholder = null,
            string format = null
        )
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateCalendar()
            {
                Editable = editable,
                Color = color,
                Placeholder = placeholder,
                Format = format
            })
            {
                Title = "My column",
                Icon = new IconBowlingBall()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows with optional cell text content.
        /// </summary>
        /// <param name="format">The date format.</param>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows(string format = "yyyy-MM-dd")
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = DateTime.Now.AddDays(-5).ToString(format, CultureInfo.InvariantCulture) }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = DateTime.Now.ToString(format) }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = DateTime.Now.AddDays(5).ToString(format) }
                );
        }
    }
}
