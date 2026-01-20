using System.Drawing;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
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
        public GraphViewer()
        {
            Stage.Description = @"The `GraphViewer` control provides a visual container for rendering graphs consisting of nodes and edges. It is ideal for network diagrams, dependency structures, flow representations, or any data that benefits from a node‑edge visualization. The control acts as a flexible canvas that can be extended with custom rendering logic, layout algorithms, and interactive behaviors.";

            Stage.AddEvent(Event.CLICK_EVENT, Event.DOUBLE_CLICK_EVENT);

            Stage.Control = new ControlGraphViewer()
            {
            }
                .Add(new ControlGraphItemNode("A") { Label = "Node A", Point = new Point(10, 20), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                .Add(new ControlGraphItemNode("B") { Label = "Node B", Point = new Point(150, 180), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Secondary) })
                .Add(new ControlGraphItemNode("C") { Label = "Node C", Point = new Point(50, 280), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Success) })
                .Add(new ControlGraphItemNode("D") { Label = "Node D", Point = new Point(-10, 390), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                .Add(new ControlGraphItemEdge("1") { Source = "A", Target = "B", Label = "Edge 1", Color = new PropertyColorGraph(TypeColorGraph.Primary) })
                .Add(new ControlGraphItemEdge("2") { Source = "B", Target = "C", Label = "Edge 2", Color = new PropertyColorGraph(TypeColorGraph.Secondary) })
                .Add(new ControlGraphItemEdge("3") { Source = "C", Target = "D", Label = "Edge 3", Color = new PropertyColorGraph(TypeColorGraph.Success) })
                .Add(new ControlGraphItemEdge("4") { Source = "A", Target = "C", Label = "Edge 4", Color = new PropertyColorGraph(TypeColorGraph.Warning) })
                .Add(new ControlGraphItemEdge("5") { Source = "A", Target = "D", Label = "Edge 5", Color = new PropertyColorGraph(TypeColorGraph.Danger) });

            Stage.Code = @"
            new ControlGraphViewer()
            {
            }
                .Add(new ControlGraphItemNode(""A"") { Label = ""Node A"", Point = new Point(10, 20), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                .Add(new ControlGraphItemNode(""B"") { Label = ""Node B"", Point = new Point(150, 180), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Secondary) })
                .Add(new ControlGraphItemNode(""C"") { Label = ""Node C"", Point = new Point(50, 280), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Success) })
                .Add(new ControlGraphItemNode(""D"") { Label = ""Node D"", Point = new Point(-10, 390), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                .Add(new ControlGraphItemEdge(""1"") { Source = ""A"", Target = ""B"", Label = ""Edge 1"", Color = new PropertyColorGraph(TypeColorGraph.Primary) })
                .Add(new ControlGraphItemEdge(""2"") { Source = ""B"", Target = ""C"", Label = ""Edge 2"", Color = new PropertyColorGraph(TypeColorGraph.Secondary) })
                .Add(new ControlGraphItemEdge(""3"") { Source = ""C"", Target = ""D"", Label = ""Edge 3"", Color = new PropertyColorGraph(TypeColorGraph.Success) })
                .Add(new ControlGraphItemEdge(""4"") { Source = ""A"", Target = ""C"", Label = ""Edge 4"", Color = new PropertyColorGraph(TypeColorGraph.Warning) })
                .Add(new ControlGraphItemEdge(""5"") { Source = ""A"", Target = ""D"", Label = ""Edge 5"", Color = new PropertyColorGraph(TypeColorGraph.Danger) });";

            Stage.DarkControls =
            [
                Stage.Control = new ControlGraphViewer()
                {
                }
                    .Add(new ControlGraphItemNode("A") { Label = "Node A", Point = new Point(10, 20), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                    .Add(new ControlGraphItemNode("B") { Label = "Node B", Point = new Point(150, 180), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Secondary) })
                    .Add(new ControlGraphItemNode("C") { Label = "Node C", Point = new Point(50, 280), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Success) })
                    .Add(new ControlGraphItemNode("D") { Label = "Node D", Point = new Point(-10, 390), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                    .Add(new ControlGraphItemEdge("1") { Source = "A", Target = "B", Label = "Edge 1", Color = new PropertyColorGraph(TypeColorGraph.Primary) })
                    .Add(new ControlGraphItemEdge("2") { Source = "B", Target = "C", Label = "Edge 2", Color = new PropertyColorGraph(TypeColorGraph.Secondary) })
                    .Add(new ControlGraphItemEdge("3") { Source = "C", Target = "D", Label = "Edge 3", Color = new PropertyColorGraph(TypeColorGraph.Success) })
                    .Add(new ControlGraphItemEdge("4") { Source = "A", Target = "C", Label = "Edge 4", Color = new PropertyColorGraph(TypeColorGraph.Warning) })
                    .Add(new ControlGraphItemEdge("5") { Source = "A", Target = "D", Label = "Edge 5", Color = new PropertyColorGraph(TypeColorGraph.Danger) })
            ];

            Stage.AddProperty(
                "Icon",
                "The `Icon` property defines a visual symbol (typically from a font icon set like Font Awesome) that is rendered inside the node. It enhances visual recognition and can be used to represent the semantic role or type of the node (e.g., user, server, database).",
                "Icon = new IconDatabase()",
                new ControlGraphViewer()
                    .Add(new ControlGraphItemNode("A")
                    {
                        Label = "Database",
                        Color = new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = new IconDatabase()
                    })
                    .Add(new ControlGraphItemNode("B")
                    {
                        Label = "User",
                        Color = new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = new IconUser()
                    })
                    .Add(new ControlGraphItemNode("C")
                    {
                        Label = "Server",
                        Color = new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = new IconServer()
                    })
                    .Add(new ControlGraphItemEdge("1") { Source = "A", Target = "B", Label = "Edge 1", Color = new PropertyColorGraph(TypeColorGraph.Primary) })
                    .Add(new ControlGraphItemEdge("2") { Source = "B", Target = "C", Label = "Edge 2", Color = new PropertyColorGraph(TypeColorGraph.Secondary) })
                    .Add(new ControlGraphItemEdge("3") { Source = "C", Target = "A", Label = "Edge 3", Color = new PropertyColorGraph(TypeColorGraph.Success) })
            );

            Stage.AddProperty(
                "NodeStyle",
                "The `NodeStyle` property defines the visual layout of a node, including how its label and icon are positioned relative to the shape. It allows for flexible presentation styles such as inline labels, external labels, or icon-only representations. This is especially useful for adapting the graph to different semantic or spatial requirements.",
                "NodeStyle = TypeStyleGraphNode.LabelBelow",
                new ControlGraphViewer()
                {
                    NodeStyle = TypeStyleGraphNode.LabelBelow
                }
                    .Add(new ControlGraphItemNode("A")
                    {
                        Label = "Database",
                        Color = new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = new IconDatabase()
                    })
                    .Add(new ControlGraphItemNode("B")
                    {
                        Label = "User",
                        Color = new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = new IconUser()
                    })
                    .Add(new ControlGraphItemNode("C")
                    {
                        Label = "Server",
                        Color = new PropertyColorGraph(TypeColorGraph.Success),
                        BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary),
                        Icon = new IconServer()
                    })
                    .Add(new ControlGraphItemEdge("1") { Source = "A", Target = "B", Label = "Edge 1", Color = new PropertyColorGraph(TypeColorGraph.Primary) })
                    .Add(new ControlGraphItemEdge("2") { Source = "B", Target = "C", Label = "Edge 2", Color = new PropertyColorGraph(TypeColorGraph.Secondary) })
                    .Add(new ControlGraphItemEdge("3") { Source = "C", Target = "A", Label = "Edge 3", Color = new PropertyColorGraph(TypeColorGraph.Success) })
            );

            Stage.AddProperty(
                "Shape",
                "The `Shape` property defines the geometric form used to render a node or edge endpoint. It influences the visual identity of the graph element and can be used to convey semantic meaning or differentiate types. Common shapes include circle, rectangle, diamond, and hexagon.",
                "Shape = TypeShapeGraphNode.Circle",
                new ControlGraphViewer()
                    .Add(new ControlGraphItemNode("A") { Label = "Circle", Point = new Point(50, 50), Shape = TypeShapeGraphNode.Circle, BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                    .Add(new ControlGraphItemNode("B") { Label = "Rectangle", Point = new Point(180, 50), Shape = TypeShapeGraphNode.Rect, BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Warning) })
                    .Add(new ControlGraphItemEdge("E") { Source = "A", Target = "B", Color = new PropertyColorGraph(TypeColorGraph.Danger) })
            );

            Stage.AddProperty
            (
                "Waypoints",
                "The `Waypoints` defines intermediate points along the edge path. It allows precise control over the routing of edges between nodes, enabling custom shapes such as elbows, curves, or detours. Each waypoint is a coordinate pair (`x`, `y`) that the edge will pass through in order.",
                "new ControlGraphItemEdge(\"E2\").Add([ new Point(100, 100), new Point(200, 150) ])",
                 new ControlGraphViewer()
                    .Add(new ControlGraphItemNode("A") { Label = "A", Point = new Point(50, 50), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                    .Add(new ControlGraphItemNode("B") { Label = "B", Point = new Point(250, 50), BackgroundColor = new PropertyColorBackgroundGraph(TypeColorBackgroundGraph.Primary) })
                    .Add(new ControlGraphItemEdge("E2")
                    {
                        Source = "A",
                        Target = "B",
                        Color = new PropertyColorGraph(TypeColorGraph.Warning)
                    }.Add
                    ([
                        new Point(88, 15),
                        new Point(200, 250)
                    ]))
            );
        }
    }
}
