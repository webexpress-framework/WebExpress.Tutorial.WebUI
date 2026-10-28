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
    /// Represents the phone template of a table control for the tutorial.
    /// </summary>
    [WebIcon<IconPhone>]
    [Title("Phone-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Phone : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Phone()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Phone` template shows the telephone number of a cell with the flag of its country, as a link that dials it, in ReadOnly mode, and edits it with the phone field and its country picker in Edit mode. A cell holds the number in E.164 form.";

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
                    .AddColumns(new ControlTableColumnTemplate(""myColumn1"", new ControlTableTemplatePhone()))
                    .AddRows(...)";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode, where the number is entered with the phone field.",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Country",
                "The `Country` property sets the country an empty edited cell starts in.",
                "Country = _ => \"JM\"",
                new ControlTable().AddColumns(CreateColumns(true, "JM")).AddRows(new ControlTableRow("myRow4").Add(new ControlTableCell() { Text = _ => "" }))
            );
        }

        /// <summary>
        /// Creates the column of the table.
        /// </summary>
        /// <param name="editable">A value indicating whether the cells can be edited.</param>
        /// <param name="country">The country an empty edited cell starts in.</param>
        /// <returns>The columns of the table.</returns>
        private static IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, string country = null)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplatePhone()
            {
                Editable = _ => editable,
                Country = _ => country
            })
            {
                Title = _ => "Phone",
                Icon = _ => new IconPhone()
            };
        }

        /// <summary>
        /// Generates the rows of the table.
        /// </summary>
        /// <returns>The rows of the table.</returns>
        private static IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1").Add(new ControlTableCell() { Text = _ => "+18765550100" });
            yield return new ControlTableRow("myRow2").Add(new ControlTableCell() { Text = _ => "+12425550100" });
            yield return new ControlTableRow("myRow3").Add(new ControlTableCell() { Text = _ => "+4930123456" });
        }
    }
}
