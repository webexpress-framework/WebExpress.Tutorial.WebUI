using System.Collections.Generic;
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
    /// Represents the html template of a table control for the tutorial.
    /// </summary>
    [Title("Html-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Html : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Html()
        {
            Stage.Description = @"The `Html` template renders the cell value as raw HTML. The content must come from a trusted source such as the server; data that may contain user input belongs in the `Text` or `Markdown` template instead, which escape the value. The template is read-only.";

            Stage.Controls =
            [
                new ControlTable("myTable")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.DarkControls =
            [
                new ControlTable("myTableDark")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.Code = @"
                new ControlTable(""myTable"")
                    .AddColumns(new ControlTableColumnTemplate(""myColumn1"", new ControlTableTemplateHtml()))
                    .AddRows(...)";
        }

        /// <summary>
        /// Creates the table columns carrying the html template.
        /// </summary>
        /// <returns>
        /// An enumerable collection of columns objects representing the configured table
        /// columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns()
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateHtml())
            {
                Title = _ => "My column",
                Icon = _ => new IconBowlingBall()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows with html cell content.
        /// </summary>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = _ => "<b>Guybrush Threepwood</b> &ndash; <i>mighty pirate</i>" }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = _ => "<span class=\"badge bg-success\">Melee Island</span>" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = _ => "<a href=\"https://example.com\" target=\"_blank\" rel=\"noopener\">Voodoo shop</a>" }
                );
        }
    }
}
