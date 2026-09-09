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
    /// Represents the REST disjunctive normal form template of a table control for
    /// the tutorial.
    /// </summary>
    [WebIcon<IconControlDnf>]
    [Title("DataDnf-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class DataDnf : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DataDnf()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `DataDnf` template is the `Dnf` template with its terms queried from an endpoint instead of travelling with the table. That is the right choice for a term set shared across the rows or too large to embed; a short, table specific list belongs in the static `Dnf` template.

Because the cells store term ids, the read state first renders the ids and relabels itself once the terms arrive. A filter that rendered as nothing while its request is open would claim the rows are unfiltered - the one thing it must never say falsely.

In Edit mode every conjunction becomes a REST backed selection of its own: it loads when its picker is opened and searches server side, so two conjunctions can be searched independently.";

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
                new ControlTableColumnTemplate(""myColumn1"", new ControlTableTemplateRestDnf()
                {
                    Editable = _ => true
                }
                    .DataService<MonkeyIslandLocationsSelection>())";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode. In Edit mode the cell becomes a Smart Edit whose editor is the REST backed `DataDnf` control; the read view it returns to is rebuilt once the terms arrive, so a finished edit never falls back to showing raw ids.",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the text shown in a conjunction that holds no term yet.",
                "Placeholder = _ => \"Pick a location\"",
                new ControlTable().AddColumns(CreateColumns(true, "Pick a location")).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "MaxGroups",
                "The `MaxGroups` property caps the number of conjunctions a cell may hold. Once the cap is reached the add button is disabled.",
                "MaxGroups = _ => 2",
                new ControlTable().AddColumns(CreateColumns(true, null, 2)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the columns of the demonstration table.
        /// </summary>
        /// <param name="editable">
        /// A value indicating whether the column can be edited in place.
        /// </param>
        /// <param name="placeholder">The placeholder of an empty conjunction.</param>
        /// <param name="maxGroups">
        /// The maximum number of conjunctions, or a value of zero or less for an
        /// unlimited number.
        /// </param>
        /// <returns>The configured columns.</returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, string placeholder = null, int maxGroups = -1)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateRestDnf()
            {
                Editable = _ => editable,
                Placeholder = _ => placeholder,
                MaxGroups = _ => maxGroups
            }
                .DataService<MonkeyIslandLocationsSelection>())
            {
                Title = _ => "Applies to",
                Icon = _ => new IconFilter()
            };
        }

        /// <summary>
        /// Generates the rows of the demonstration table, each holding an expression
        /// of a different shape over the location ids the endpoint serves.
        /// </summary>
        /// <returns>The generated rows.</returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add(new ControlTableCell() { Text = _ => "28DF7324-0DDE-40B3-B6E4-0CDD107D324A;64D99FDF-9828-40EB-92CA-D55DDA6BD9F4" });

            yield return new ControlTableRow("myRow2")
                .Add(new ControlTableCell() { Text = _ => "28DF7324-0DDE-40B3-B6E4-0CDD107D324A|64D99FDF-9828-40EB-92CA-D55DDA6BD9F4" });

            yield return new ControlTableRow("myRow3")
                .Add(new ControlTableCell() { Text = _ => "28DF7324-0DDE-40B3-B6E4-0CDD107D324A" });
        }
    }
}
