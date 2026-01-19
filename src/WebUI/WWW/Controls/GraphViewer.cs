using System.Drawing;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

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
                .Add(new ControlGraphItemEdge("5") { Source = "A", Target = "D", Label = "Edge 4", Color = new PropertyColorGraph(TypeColorGraph.Danger) });

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
                .Add(new ControlGraphItemEdge(""5"") { Source = ""A"", Target = ""D"", Label = ""Edge 4"", Color = new PropertyColorGraph(TypeColorGraph.Danger) });";

            Stage.DarkControls = null;
        }
    }
}
