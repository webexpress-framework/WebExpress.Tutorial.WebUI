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
    /// Represents the country template of a table control for the tutorial.
    /// </summary>
    [WebIcon<IconFlag>]
    [Title("Country-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Country : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Country()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Country` template defines the visual representation of countries within a column. A cell holds ISO 3166-1 alpha-2 codes, several separated by a semicolon. In ReadOnly mode each country is shown with its flag and name, in Edit mode it is chosen with a searchable country picker. The names follow the language of the visitor.";

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
                    .AddColumns(new ControlTableColumnTemplate(""myColumn1"", new ControlTableTemplateCountry()))
                    .AddRows(...)";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode. In ReadOnly mode, the countries are shown with flag and name. In Edit mode, users choose the countries of a cell with the country picker.",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(editable: true, multiSelect: true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Countries",
                "The `Countries` property limits the countries the picker offers when a cell is edited. Left unset, all countries of ISO 3166-1 are offered.",
                "Countries = _ => [\"BB\", \"BS\", \"CU\", \"GD\", \"JM\", \"LC\", \"TT\"]",
                new ControlTable().AddColumns(CreateColumns(editable: true, multiSelect: true, countries: ["BB", "BS", "CU", "GD", "JM", "LC", "TT"])).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "ShowName",
                "The `ShowName` property decides whether the name is shown beside the flag. Without it, the flags keep a narrow column readable; the names remain as tooltips and for screen readers.",
                "ShowName = _ => false",
                new ControlTable().AddColumns(CreateColumns(showName: false)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the column of the table, configured with the given template settings.
        /// </summary>
        /// <param name="editable">A value indicating whether the cells can be edited.</param>
        /// <param name="multiSelect">A value indicating whether a cell can hold several countries.</param>
        /// <param name="showName">A value indicating whether the name is shown beside the flag.</param>
        /// <param name="countries">The codes offered when a cell is edited, or null for all.</param>
        /// <returns>The columns of the table.</returns>
        private static IEnumerable<IControlTableColumn> CreateColumns
        (
            bool editable = false,
            bool multiSelect = false,
            bool showName = true,
            IEnumerable<string> countries = null
        )
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateCountry()
            {
                Editable = _ => editable,
                MultiSelect = _ => multiSelect,
                ShowName = _ => showName,
                Countries = _ => countries
            })
            {
                Title = _ => "Ports of call",
                Icon = _ => new IconFlag()
            };
        }

        /// <summary>
        /// Generates the rows of the table, each holding the codes of one or more countries.
        /// </summary>
        /// <returns>The rows of the table.</returns>
        private static IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add(new ControlTableCell() { Text = _ => "JM" });
            yield return new ControlTableRow("myRow2")
                .Add(new ControlTableCell() { Text = _ => "BS;CU" });
            yield return new ControlTableRow("myRow3")
                .Add(new ControlTableCell() { Text = _ => "TT;GD;LC" });
        }
    }
}
