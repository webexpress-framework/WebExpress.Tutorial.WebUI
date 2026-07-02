using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table.Templates
{
    /// <summary>
    /// Represents the REST combo template of a table control for the tutorial.
    /// </summary>
    [Title("RestCombo-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class RestCombo : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestCombo()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `RestCombo` template is the single-choice sibling of the `DataSelection` template: the selectable options are loaded from a REST endpoint, the read-only cell shows the chosen value and the editable cell offers a service-backed picker. Use it when a column holds exactly one value drawn from a dynamic, server-provided list.";

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
                "Editable",
                "The `Editable` property switches the column between ReadOnly mode (the chosen value is displayed) and Edit mode (a service-backed single-select picker lets the user change it).",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the text shown while no value is chosen, guiding the user toward the expected input.",
                "Placeholder = _ => \"Choose a location\"",
                new ControlTable().AddColumns(CreateColumns(true, "Choose a location")).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the rest combo template column.
        /// </summary>
        /// <param name="editable">Whether the column is editable.</param>
        /// <param name="placeholder">The optional placeholder text.</param>
        /// <returns>The configured table columns.</returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, string placeholder = null)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateRestCombo()
            {
                Editable = _ => editable,
                Placeholder = _ => placeholder
            }
                .DataService<MonkeyIslandLocationsSelection>())
            {
                Title = _ => "My column",
                Icon = _ => new IconLocationDot()
            };
        }

        /// <summary>
        /// Generates the demo rows, each holding a single location id.
        /// </summary>
        /// <returns>The generated rows.</returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1").Add(new ControlTableCell() { Text = _ => "28DF7324-0DDE-40B3-B6E4-0CDD107D324A" });
            yield return new ControlTableRow("myRow2").Add(new ControlTableCell() { Text = _ => "64D99FDF-9828-40EB-92CA-D55DDA6BD9F4" });
            yield return new ControlTableRow("myRow3").Add(new ControlTableCell() { Text = _ => "28DF7324-0DDE-40B3-B6E4-0CDD107D324A" });
        }
    }
}
