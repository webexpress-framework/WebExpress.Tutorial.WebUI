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
    /// Represents the e-mail template of a table control for the tutorial.
    /// </summary>
    [WebIcon<IconEnvelope>]
    [Title("Email-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Email : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Email()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Email` template shows the e-mail address of a cell as a link that writes to it in ReadOnly mode, and edits it in an e-mail field in Edit mode.";

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
                    .AddColumns(new ControlTableColumnTemplate(""myColumn1"", new ControlTableTemplateEmail()))
                    .AddRows(...)";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode, where the address is entered in an e-mail field the browser checks.",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the column of the table.
        /// </summary>
        /// <param name="editable">A value indicating whether the cells can be edited.</param>
        /// <returns>The columns of the table.</returns>
        private static IEnumerable<IControlTableColumn> CreateColumns(bool editable = false)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateEmail()
            {
                Editable = _ => editable,
                Placeholder = _ => "name@example.com"
            })
            {
                Title = _ => "E-mail",
                Icon = _ => new IconEnvelope()
            };
        }

        /// <summary>
        /// Generates the rows of the table.
        /// </summary>
        /// <returns>The rows of the table.</returns>
        private static IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1").Add(new ControlTableCell() { Text = _ => "guybrush@melee-island.example" });
            yield return new ControlTableRow("myRow2").Add(new ControlTableCell() { Text = _ => "elaine@governor.example" });
            yield return new ControlTableRow("myRow3").Add(new ControlTableCell() { Text = _ => "stan@used-ships.example" });
        }
    }
}
