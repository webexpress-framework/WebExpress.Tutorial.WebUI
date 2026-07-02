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
    /// Represents the REST tag template of a table control for the tutorial.
    /// </summary>
    [Title("RestTag-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class RestTag : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestTag()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `RestTag` template shows a cell's tags and, in Edit mode, offers a free-text tag input whose autocomplete suggestions are served by a REST endpoint (via the `q` query parameter). The read-only display needs no service - a tag is its own label - so only editing consults the endpoint. It is the service-backed sibling of the `Tag` template.";

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
                "The `Editable` property switches the column between ReadOnly mode (the tags are shown as static chips) and Edit mode (a tag input with REST-backed autocomplete lets the user add and remove tags).",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the hint shown in the empty tag input, guiding the user toward the expected input.",
                "Placeholder = _ => \"Add a tag\"",
                new ControlTable().AddColumns(CreateColumns(true, "Add a tag")).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the rest tag template column.
        /// </summary>
        /// <param name="editable">Whether the column is editable.</param>
        /// <param name="placeholder">The optional placeholder text.</param>
        /// <returns>The configured table columns.</returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, string placeholder = null)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateRestTag()
            {
                Editable = _ => editable,
                Placeholder = _ => placeholder
            }
                .DataService<MonkeyIslandTag>())
            {
                Title = _ => "Tags",
                Icon = _ => new IconTags()
            };
        }

        /// <summary>
        /// Generates the demo rows, each holding a semicolon-separated tag list.
        /// </summary>
        /// <returns>The generated rows.</returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1").Add(new ControlTableCell() { Text = _ => "pirate;grog" });
            yield return new ControlTableRow("myRow2").Add(new ControlTableCell() { Text = _ => "voodoo" });
            yield return new ControlTableRow("myRow3").Add(new ControlTableCell() { Text = _ => "treasure;monkey" });
        }
    }
}
