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
    /// Represents the markdown template of a table control for the tutorial.
    /// </summary>
    [Title("Markdown-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Markdown : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Markdown()
        {
            Stage.Description = @"The `Markdown` template renders the cell value as a markdown subset (headings, emphasis, code, links and lists). The raw value is escaped before the markup is rewritten, so markdown data cannot inject HTML. The template is read-only; content that is authored as HTML belongs in the `Html` template instead.";

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
                    .AddColumns(new ControlTableColumnTemplate(""myColumn1"", new ControlTableTemplateMarkdown()))
                    .AddRows(...)";
        }

        /// <summary>
        /// Creates the table columns carrying the markdown template.
        /// </summary>
        /// <returns>
        /// An enumerable collection of columns objects representing the configured table
        /// columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns()
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateMarkdown())
            {
                Title = _ => "My column",
                Icon = _ => new IconBowlingBall()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows with markdown cell content.
        /// </summary>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = _ => "**Guybrush Threepwood** is a *mighty* pirate." }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = _ => "# Heading\n- LeChuck\n- Elaine\n- Stan" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = _ => "Use `root beer` against ghost pirates, see [manual](https://example.com)." }
                );
        }
    }
}
