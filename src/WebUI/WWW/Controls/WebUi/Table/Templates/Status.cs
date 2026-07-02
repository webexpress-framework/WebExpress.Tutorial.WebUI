using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table.Templates
{
    /// <summary>
    /// Represents the status (dot) template of a table control for the tutorial.
    /// </summary>
    [Title("Status-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Status : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Status()
        {
            Stage.Description = @"The `Status` template condenses a cell value into a single colored dot: **red** for an error, **green** for done, **yellow** for a warning, **blue** for a running task and **gray** for a pending one. It is the read-only table analog of the `ControlStatusTask` dot and reuses the same palette. The cell value carries the status token (`pending`, `running`, `warning`, `error`, `done`) or an empty string for none.";

            Stage.Controls =
            [
                new ControlTable("myTable")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.Code = @"
                new ControlTable(""myTable"")
                    .AddColumns(...)
                    .AddRows(...)";

            Stage.AddProperty
            (
                "ShowLabel",
                "The `ShowLabel` property renders the translated status name as a caption next to the dot. When disabled only the dot is shown and the name travels as the tooltip.",
                "ShowLabel = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the status template column.
        /// </summary>
        /// <param name="showLabel">Whether the status name is shown next to the dot.</param>
        /// <returns>The configured table columns.</returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool showLabel = false)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateStatus()
            {
                ShowLabel = _ => showLabel
            })
            {
                Title = _ => "Status",
                Icon = _ => new IconCircleCheck()
            };
        }

        /// <summary>
        /// Generates the demo rows, one per status token.
        /// </summary>
        /// <returns>The generated rows.</returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1").Add(new ControlTableCell() { Text = _ => "done" });
            yield return new ControlTableRow("myRow2").Add(new ControlTableCell() { Text = _ => "running" });
            yield return new ControlTableRow("myRow3").Add(new ControlTableCell() { Text = _ => "warning" });
            yield return new ControlTableRow("myRow4").Add(new ControlTableCell() { Text = _ => "error" });
            yield return new ControlTableRow("myRow5").Add(new ControlTableCell() { Text = _ => "pending" });
        }
    }
}
