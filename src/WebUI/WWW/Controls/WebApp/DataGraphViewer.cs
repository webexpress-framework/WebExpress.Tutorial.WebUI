using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed REST-backed graph: the islands, ships
    /// and characters of the Caribbean and the routes between them.
    /// </summary>
    [WebIcon<IconControlGraphViewer>]
    [Title("DataGraphViewer")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataGraphViewer : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataGraphViewer(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent
            (
                Event.DATA_REQUESTED_EVENT,
                Event.DATA_ARRIVED_EVENT,
                Event.UPDATED_EVENT,
                Event.CLICK_EVENT,
                Event.DOUBLE_CLICK_EVENT
            );

            Stage.Description = @"The `DataGraphViewer` control renders a network graph – nodes and the edges between them – loaded from a REST endpoint. It is the data-bound counterpart of the `GraphViewer`: instead of authoring the nodes and edges as controls, the server answers a single `GET` with a `{ nodes, edges }` payload, and the client draws it onto an SVG canvas with pan, zoom, node dragging and the fit, centre and zoom controls in the lower left corner. A node carries a label, an icon or an image, a shape and its colors; an edge carries a label, a stroke, a dash pattern and optional waypoints it is routed through. Nodes that arrive without coordinates are placed by a spring-mass layout simulation, which settles by itself and then costs nothing. The viewer is read-only – a graph that is also authored belongs in the workflow editor.";

            Stage.Controls =
            [
                new ControlDataGraphViewer("monkeyIslandGraph")
                {
                    EdgeStyle = _ => TypeStyleGraphEdge.Smooth,
                    Label = _ => "Map of the Caribbean"
                }
                    .DataService<MonkeyIslandGraph>()
            ];

            Stage.Code = @"
            new ControlDataGraphViewer(""monkeyIslandGraph"")
            {
                EdgeStyle = _ => TypeStyleGraphEdge.Smooth,
                Label = _ => ""Map of the Caribbean""
            }
                .DataService<MonkeyIslandGraph>()";

            Stage.AddProperty
            (
                "NodeStyle",
                "The `NodeStyle` property sets the layout of the nodes that carry no layout of their own, so a graph gets a consistent look without repeating the setting on every node the endpoint delivers. `TypeStyleGraphNode.LabelBelow` places the label under the icon or shape, which keeps the shapes small and is the readable choice for a dense graph; the default draws the label inside the node.",
                @"
                new ControlDataGraphViewer(""monkeyIslandGraphNodeStyle"")
                {
                    NodeStyle = _ => TypeStyleGraphNode.LabelBelow
                }
                    .DataService<MonkeyIslandGraph>()",
                new ControlDataGraphViewer("monkeyIslandGraphNodeStyle")
                {
                    NodeStyle = _ => TypeStyleGraphNode.LabelBelow
                }
                    .DataService<MonkeyIslandGraph>()
            );

            Stage.AddProperty
            (
                "EdgeStyle",
                "The `EdgeStyle` property selects how the edges are routed. The default draws straight segments and rounds the corner at each waypoint, which keeps a waypoint readable as the deliberate routing decision it is. `TypeStyleGraphEdge.Straight` keeps the corners sharp and `TypeStyleGraphEdge.Smooth` bends the whole run into a bezier.",
                @"
                new ControlDataGraphViewer(""monkeyIslandGraphEdgeStyle"")
                {
                    EdgeStyle = _ => TypeStyleGraphEdge.Straight
                }
                    .DataService<MonkeyIslandGraph>()",
                new ControlDataGraphViewer("monkeyIslandGraphEdgeStyle")
                {
                    EdgeStyle = _ => TypeStyleGraphEdge.Straight
                }
                    .DataService<MonkeyIslandGraph>()
            );

            Stage.AddProperty
            (
                "Physics",
                "The `Physics` property controls the layout simulation that places the nodes arriving without coordinates. It is on unless switched off. A graph whose endpoint delivers every position is better served with `Physics = _ => false`, because the simulation would otherwise move the authored layout; a node without coordinates then stays where the renderer put it.",
                "Only the nodes without a position take part in the simulation. It stops itself once nothing moves any more, so an idle graph costs nothing.",
                @"
                new ControlDataGraphViewer(""monkeyIslandGraphPhysics"")
                {
                    Physics = _ => false
                }
                    .DataService<MonkeyIslandGraph>()",
                new ControlDataGraphViewer("monkeyIslandGraphPhysics")
                {
                    Physics = _ => false
                }
                    .DataService<MonkeyIslandGraph>()
            );

            Stage.AddProperty
            (
                "Grid",
                "The `Grid` property draws a background grid with the given cell size, and `GridSnap` makes a dragged node snap to it. The grid pans and zooms with the content, so its cells stay aligned to the model coordinates. It is off by default, because a grid is a reading aid rather than a property of the graph.",
                @"
                new ControlDataGraphViewer(""monkeyIslandGraphGrid"")
                {
                    Grid = _ => 25,
                    GridSnap = _ => true
                }
                    .DataService<MonkeyIslandGraph>()",
                new ControlDataGraphViewer("monkeyIslandGraphGrid")
                {
                    Grid = _ => 25,
                    GridSnap = _ => true
                }
                    .DataService<MonkeyIslandGraph>()
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property names the canvas for assistive technology. The canvas is a single tab stop whose content is pure geometry, so without a name a screen reader has nothing to announce it by.",
                @"
                new ControlDataGraphViewer(""monkeyIslandGraphLabel"")
                {
                    Label = _ => ""Map of the Caribbean""
                }
                    .DataService<MonkeyIslandGraph>()",
                new ControlDataGraphViewer("monkeyIslandGraphLabel")
                {
                    Label = _ => "Map of the Caribbean"
                }
                    .DataService<MonkeyIslandGraph>()
            );
        }
    }
}
