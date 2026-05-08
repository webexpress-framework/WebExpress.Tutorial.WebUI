using System.Drawing;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the graph viewer control for the tutorial.
    /// </summary>
    [Title("GraphViewer")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class GraphViewer : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public GraphViewer(IPageContext pageContext)
        {
            var uri = pageContext.Route.ToUri();

            Stage.Description = @"The `GraphViewer` control provides a visual container for rendering graphs consisting of nodes and edges. It is ideal for network diagrams, dependency structures, flow representations, or any data that benefits from a node‑edge visualization. The control acts as a flexible canvas that can be extended with custom rendering logic, layout algorithms, and interactive behaviors.";

            Stage.AddEvent(Event.CLICK_EVENT, Event.DOUBLE_CLICK_EVENT);

            Stage.Control = new ControlGraphViewer()
            {
            }
                .Add(new ControlGraphItemNode("A") { Label = _ => "Node A", Uri = _ => uri, Point = _ => new Point(10, 20), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                .Add(new ControlGraphItemNode("B") { Label = _ => "Node B", Point = _ => new Point(150, 180), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Secondary) })
                .Add(new ControlGraphItemNode("C") { Label = _ => "Node C", Point = _ => new Point(50, 280), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Success) })
                .Add(new ControlGraphItemNode("D") { Label = _ => "Node D", Point = _ => new Point(-10, 390), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                .Add(new ControlGraphItemEdge("1") { Source = _ => "A", Target = _ => "B", Label = _ => "Edge 1", Color = _ => new PropertyColorGraph(TypeColorGraph.Primary) })
                .Add(new ControlGraphItemEdge("2") { Source = _ => "B", Target = _ => "C", Label = _ => "Edge 2", Color = _ => new PropertyColorGraph(TypeColorGraph.Secondary) })
                .Add(new ControlGraphItemEdge("3") { Source = _ => "C", Target = _ => "D", Label = _ => "Edge 3", Color = _ => new PropertyColorGraph(TypeColorGraph.Success) })
                .Add(new ControlGraphItemEdge("4") { Source = _ => "A", Target = _ => "C", Label = _ => "Edge 4", Color = _ => new PropertyColorGraph(TypeColorGraph.Warning) })
                .Add(new ControlGraphItemEdge("5") { Source = _ => "A", Target = _ => "D", Label = _ => "Edge 5", Color = _ => new PropertyColorGraph(TypeColorGraph.Danger) });

            Stage.Code = @"
            new ControlGraphViewer()
            {
            }
                .Add(new ControlGraphItemNode(""A"") { Label = _ => ""Node A"", Uri = p_ => ageContext.Route.ToUri(), Point = _ => new Point(10, 20), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                .Add(new ControlGraphItemNode(""B"") { Label = _ => ""Node B"", Point = _ => new Point(150, 180), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Secondary) })
                .Add(new ControlGraphItemNode(""C"") { Label = _ => ""Node C"", Point = _ => new Point(50, 280), _ => BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Success) })
                .Add(new ControlGraphItemNode(""D"") { Label = _ => ""Node D"", Point = _ => new Point(-10, 390), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                .Add(new ControlGraphItemEdge(""1"") { Source = _ => ""A"", Target = _ => ""B"", Label = _ => ""Edge 1"", Color = new PropertyColorGraph(TypeColorGraph.Primary) })
                .Add(new ControlGraphItemEdge(""2"") { Source = _ => ""B"", Target = _ => ""C"", Label = _ => ""Edge 2"", Color = new PropertyColorGraph(TypeColorGraph.Secondary) })
                .Add(new ControlGraphItemEdge(""3"") { Source = _ => ""C"", Target = _ => ""D"", Label = _ => ""Edge 3"", Color = new PropertyColorGraph(TypeColorGraph.Success) })
                .Add(new ControlGraphItemEdge(""4"") { Source = _ => ""A"", Target = _ => ""C"", Label = _ => ""Edge 4"", Color = _ => new PropertyColorGraph(TypeColorGraph.Warning) })
                .Add(new ControlGraphItemEdge(""5"") { Source = _ => ""A"", Target = _ => ""D"", Label = _ => ""Edge 5"", Color = n_ => ew PropertyColorGraph(TypeColorGraph.Danger) });";

            Stage.DarkControls =
            [
                Stage.Control = new ControlGraphViewer()
                {
                }
                    .Add(new ControlGraphItemNode("A") { Label = _ => "Node A", Point = _ => new Point(10, 20), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                    .Add(new ControlGraphItemNode("B") { Label = _ => "Node B", Point = _ => new Point(150, 180), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Secondary) })
                    .Add(new ControlGraphItemNode("C") { Label = _ => "Node C", Point = _ => new Point(50, 280), BackgroundColor =_ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Success) })
                    .Add(new ControlGraphItemNode("D") { Label = _ => "Node D", Point = _ => new Point(-10, 390), BackgroundColor = _ =>  new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                    .Add(new ControlGraphItemEdge("1") { Source = _ => "A", Target = _ => "B", Label = _ => "Edge 1", Color = _ => new PropertyColorGraph(TypeColorGraph.Primary) })
                    .Add(new ControlGraphItemEdge("2") { Source = _ => "B", Target = _ => "C", Label = _ => "Edge 2", Color = _ => new PropertyColorGraph(TypeColorGraph.Secondary) })
                    .Add(new ControlGraphItemEdge("3") { Source = _ => "C", Target = _ => "D", Label = _ => "Edge 3", Color = _ => new PropertyColorGraph(TypeColorGraph.Success) })
                    .Add(new ControlGraphItemEdge("4") { Source = _ => "A", Target = _ => "C", Label = _ => "Edge 4", Color = _ => new PropertyColorGraph(TypeColorGraph.Warning) })
                    .Add(new ControlGraphItemEdge("5") { Source = _ => "A", Target = _ => "D", Label = _ => "Edge 5", Color = _ => new PropertyColorGraph(TypeColorGraph.Danger) })
            ];

            Stage.AddProperty(
                "Icon",
                "The `Icon` property defines a visual symbol (typically from a font icon set like Font Awesome) that is rendered inside the node. It enhances visual recognition and can be used to represent the semantic role or type of the node (e.g., user, server, database).",
                "Icon = _ => new IconDatabase()",
                new ControlGraphViewer()
                    .Add(new ControlGraphItemNode("A")
                    {
                        Label = _ => "Database",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = _ => new IconDatabase()
                    })
                    .Add(new ControlGraphItemNode("B")
                    {
                        Label = _ => "User",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = _ => new IconUser()
                    })
                    .Add(new ControlGraphItemNode("C")
                    {
                        Label = _ => "Server",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = _ => new IconServer()
                    })
                    .Add(new ControlGraphItemEdge("1") { Source = _ => "A", Target = _ => "B", Label = _ => "Edge 1", Color = _ => new PropertyColorGraph(TypeColorGraph.Primary) })
                    .Add(new ControlGraphItemEdge("2") { Source = _ => "B", Target = _ => "C", Label = _ => "Edge 2", Color = _ => new PropertyColorGraph(TypeColorGraph.Secondary) })
                    .Add(new ControlGraphItemEdge("3") { Source = _ => "C", Target = _ => "A", Label = _ => "Edge 3", Color = _ => new PropertyColorGraph(TypeColorGraph.Success) })
            );

            Stage.AddProperty(
                "NodeStyle",
                "The `NodeStyle` property defines the visual layout of a node, including how its label and icon are positioned relative to the shape. It allows for flexible presentation styles such as inline labels, external labels, or icon-only representations. This is especially useful for adapting the graph to different semantic or spatial requirements.",
                "NodeStyle = _ => TypeStyleGraphNode.LabelBelow",
                new ControlGraphViewer()
                {
                    NodeStyle = _ => TypeStyleGraphNode.LabelBelow
                }
                    .Add(new ControlGraphItemNode("A")
                    {
                        Label = _ => "Database",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = _ => new IconDatabase()
                    })
                    .Add(new ControlGraphItemNode("B")
                    {
                        Label = _ => "User",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = _ => new IconUser()
                    })
                    .Add(new ControlGraphItemNode("C")
                    {
                        Label = _ => "Server",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = _ => new IconServer()
                    })
                    .Add(new ControlGraphItemEdge("1") { Source = _ => "A", Target = _ => "B", Label = _ => "Edge 1", Color = _ => new PropertyColorGraph(TypeColorGraph.Primary) })
                    .Add(new ControlGraphItemEdge("2") { Source = _ => "B", Target = _ => "C", Label = _ => "Edge 2", Color = _ => new PropertyColorGraph(TypeColorGraph.Secondary) })
                    .Add(new ControlGraphItemEdge("3") { Source = _ => "C", Target = _ => "A", Label = _ => "Edge 3", Color = _ => new PropertyColorGraph(TypeColorGraph.Success) })
            );

            Stage.AddProperty(
                "Shape",
                "The `Shape` property defines the geometric form used to render a node or edge endpoint. It influences the visual identity of the graph element and can be used to convey semantic meaning or differentiate types. Common shapes include circle, rectangle, diamond, and hexagon.",
                "Shape = _ => TypeShapeGraphNode.Circle",
                new ControlGraphViewer()
                    .Add(new ControlGraphItemNode("A") { Label = _ => "Circle", Point = _ => new Point(50, 50), Shape = _ => TypeShapeGraphNode.Circle, BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                    .Add(new ControlGraphItemNode("B") { Label = _ => "Rectangle", Point = _ => new Point(180, 50), Shape = _ => TypeShapeGraphNode.Rect, BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                    .Add(new ControlGraphItemEdge("E") { Source = _ => "A", Target = _ => "B", Color = _ => new PropertyColorGraph(TypeColorGraph.Danger) })
            );

            Stage.AddProperty
            (
                "Waypoints",
                "The `Waypoints` defines intermediate points along the edge path. It allows precise control over the routing of edges between nodes, enabling custom shapes such as elbows, curves, or detours. Each waypoint is a coordinate pair (`x`, `y`) that the edge will pass through in order.",
                "new ControlGraphItemEdge(\"E2\").Add([ new Point(100, 100), new Point(200, 150) ])",
                 new ControlGraphViewer()
                    .Add(new ControlGraphItemNode("A") { Label = _ => "A", Point = _ => new Point(50, 50), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                    .Add(new ControlGraphItemNode("B") { Label = _ => "B", Point = _ => new Point(250, 50), BackgroundColor = _ => new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                    .Add(new ControlGraphItemEdge("E2")
                    {
                        Source = _ => "A",
                        Target = _ => "B",
                        Color = _ => new PropertyColorGraph(TypeColorGraph.Warning)
                    }.Add
                    ([
                        new Point(88, 15),
                        new Point(200, 250)
                    ]))
            );
        }
    }
}
