using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST-backed tree control for the tutorial, which loads one level per expansion.
    /// </summary>
    [WebIcon<IconControlTree>]
    [Title("DataTree")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataTree : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the tree control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataTree(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            var monkeyHead = ViewModel.MonkeyIslandLocations.First(x => x.Text == "Giant Stone Monkey Head").Id.ToString();

            Stage.AddEvent
            (
                Event.CHANGE_VALUE_EVENT,
                Event.CLICK_EVENT,
                Event.SELECT_ITEM_EVENT,
                Event.CHANGE_VISIBILITY_EVENT,
                Event.MOVE_EVENT,
                Event.DROP_EVENT
            );

            Stage.Description = @"A `DataTree` control shows a hierarchy that a REST API delivers one level at a time. The static tree renders every node into the page; the data tree asks the endpoint for the children of a node only when the node is opened, so a hierarchy of any size opens as fast as its first level. It keeps its expansion across reloads, selects and reveals a node by id, follows the ARIA tree pattern and, when movable, moves its nodes by drag and drop. The endpoint derives from `RestApiTree<T>`: here `MonkeyIslandLocationTree` answers the islands as the first level and their locations below them. The tree opens at the Giant Stone Monkey Head, which is not on the first level, so the tree reveals it with a single request and opens Monkey Island on the way.";

            Stage.Controls =
            [
                new ControlDataTree("myDataTree")
                {
                    Selected = _ => monkeyHead
                }
                    .DataService<MonkeyIslandLocationTree>()
            ];

            Stage.Code = @"
            new ControlDataTree(""myDataTree"")
            {
                Selected = _ => monkeyHead
            }
                .DataService<MonkeyIslandLocationTree>();

            public sealed class MonkeyIslandLocationTree : RestApiTree<Location>
            {
                protected override IEnumerable<RestApiTreeNode> RetrieveChildren(string parentId, IQueryContext context, IRequest request)
                    => ChildrenOf(parentId).Select(id => new RestApiTreeNode { Id = id, Label = LabelOf(id), HasChildren = HasChildren(id) });

                protected override string RetrieveParent(string id, IQueryContext context, IRequest request)
                    => ParentOf(id);
            }";

            Stage.AddProperty
            (
                "Movable",
                "The `Movable` property lets the user move a location by drag and drop: onto another location to nest it, or above and below one to reorder the siblings. The move is shown at once, stored through the `PUT` of the endpoint, which calls `MoveNode`, and the touched levels are read back, because the endpoint decides where a node ends up. A move is stored the way any control stores a change it applies at once: a listener of the before-save event can veto it, and a move the endpoint refuses is reported and taken back. This endpoint keeps the islands on the first level, so dropping a location next to an island is refused.",
                "Movable = _ => true",
                new ControlDataTree("myMovableDataTree")
                {
                    Movable = _ => true,
                    Expanded = _ => ["island-melee-island"]
                }
                    .DataService<MonkeyIslandLocationTree>()
            );

            Stage.AddProperty
            (
                "Expanded",
                "The `Expanded` property names the nodes that are open when the tree loads, so a page shows the part of the hierarchy it is about. The levels open from the top down, and the expansion survives every reload of the tree, including the one a data change of the service triggers.",
                @"Expanded = _ => [""island-melee-island"", ""island-monkey-island""]",
                new ControlDataTree("myExpandedDataTree")
                {
                    Expanded = _ => ["island-melee-island", "island-monkey-island"]
                }
                    .DataService<MonkeyIslandLocationTree>()
            );

            Stage.AddProperty
            (
                "Drop targets",
                "Every node of the data tree is a target of the drag-and-drop protocol that the data controls share. A table, a tile panel or a list whose `DragKind` is set lets its rows be dragged onto a node; the tree leaves such a drop to the page, which receives the bubbling drop event with the dragged ids and the target node. Drag a character of the table onto a location and watch the event log. A drag that starts on a chosen row carries every chosen row.",
                @"
                new ControlDataTable(""myDragTable"")
                {
                    PageSize = _ => 5,
                    MultiSelect = _ => true,
                    DragKind = _ => ""character""
                }
                    .DataService<MonkeyIslandCharacterTable>(),
                new ControlDataTree(""myDropDataTree"")
                    .DataService<MonkeyIslandLocationTree>()",
                new ControlDataTable("myDragTable")
                {
                    PageSize = _ => 5,
                    MultiSelect = _ => true,
                    DragKind = _ => "character"
                }
                    .DataService<MonkeyIslandCharacterTable>(),
                new ControlDataTree("myDropDataTree")
                    .DataService<MonkeyIslandLocationTree>()
            );
        }
    }
}
