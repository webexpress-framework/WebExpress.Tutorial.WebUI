using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Table
{
    /// <summary>
    /// Represents the table control for the tutorial.
    /// </summary>
    [WebIcon<IconControlTable>]
    [Title("DataTable")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Index : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">
        /// The context of the page where the table control is used.
        /// </param>
        /// <param name="sitemapManager">
        /// The sitemap manager for managing site navigation.
        /// </param>
        public Index(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent
            (
                Event.TABLE_SORT_EVENT,
                Event.COLUMN_REORDER_EVENT,
                Event.ROW_REORDER_EVENT,
                Event.UPDATED_EVENT,
                Event.SELECTION_CHANGED_EVENT
            );

            Stage.Description = @"A `DataTable` control is a user interface component that retrieves data from a REST API and operates based on the CRUD principle, which encompasses creating, reading, updating, and processing data. The control automatically fetches data from the API and displays it in a tabular format. Users can add, modify, or delete entries in the table, with each action being synchronized directly with the API. Additionally, the control provides sorting and filtering functionalities to enhance data presentation and accessibility.

The table also exposes a fully implemented column management: dragging a column header reorders the columns, the column-settings modal toggles visibility, and the resize handle on each header changes the width. Every interaction is sent back to the server through `RestApiTable.Configure` (PUT) as `{ ""c"": [{ ""id"", ""visible"", ""width"" }, ...] }`. The accompanying `MonkeyIslandCharacterTable` persists the received layout in memory and replays it from `RetrieveColums`, so reloading the page restores the order, width and visibility chosen previously.";

            // the data service, its endpoint and the query/response mapping are
            // authored in C# through the fluent data surface; the endpoint resolves
            // through the sitemap, so no endpoint knowledge lives in JavaScript.
            Stage.Controls =
            [
                new ControlDataTable("myTable")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTable>(),
                new ControlModalExample("modal")
            ];

            Stage.Code = @"
            new ControlDataTable(""myTable"")
            {
                PageSize = _=> 5
            }
                .DataService<MonkeyIslandCharacterTable>()

            // server-side persistence of the layout the user produces in the browser
            protected override void UpdateColumns(IEnumerable<RestApiTableColumn> columns, IRequest request)
            {
                // columns is the full ordered list with user-defined Visible / Width,
                // columns the client omitted are appended at the tail as hidden.
                _layout = columns.ToList();
            }";

            Stage.AddProperty
            (
                "MultiSelect",
                "The `MultiSelect` property lets the user choose rows for a bulk action. A checkbox column chooses single rows, the checkbox in the header chooses every row on screen, and a click with Ctrl (Cmd on a Mac) or Shift adds a row or a range of rows. The controls added with `AddSelectionAction` appear in a bar above the rows while at least one row is chosen; the bar names how many are. Every change of the choice is announced with the selection changed event, which carries the ids of the chosen rows, and the table exposes them as `selection`. A plain click still selects the row as before, since the selected row and the chosen rows are two separate things.",
                @"
                new ControlDataTable(""myMultiSelectTable"")
                {
                    PageSize = _ => 5,
                    MultiSelect = _ => true
                }
                    .AddSelectionAction(new ControlButton(""assign"")
                    {
                        Text = _ => ""Assign to a crew"",
                        BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                    })
                    .DataService<MonkeyIslandCharacterTable>()",
                new ControlDataTable("myMultiSelectTable")
                {
                    PageSize = _ => 5,
                    MultiSelect = _ => true
                }
                    .AddSelectionAction(new ControlButton("assign")
                    {
                        Text = _ => "Assign to a crew",
                        BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                    })
                    .DataService<MonkeyIslandCharacterTable>()
            );

            Stage.AddProperty
            (
                "DragKind",
                "The `DragKind` property makes the rows sources of the drag-and-drop protocol that the data controls share. A row carries its id and the given kind, by which a target accepts or refuses it, and a drag that starts on a chosen row carries every chosen row. `DropKind` makes the rows targets in turn. The page receives the bubbling drop event with the dragged ids and the target; the data tree tutorial drops characters onto locations. A table with `MovableRow` keeps its own row moves and ignores the drag kind.",
                @"DragKind = _ => ""character""",
                new ControlDataTable("myDragKindTable")
                {
                    PageSize = _ => 5,
                    DragKind = _ => "character"
                }
                    .DataService<MonkeyIslandCharacterTable>()
            );
        }
    }
}
