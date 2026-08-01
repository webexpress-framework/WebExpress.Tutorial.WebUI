using System.Collections.Generic;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a Monkey Island themed graph endpoint: the islands, ships and
    /// characters of the Caribbean and the routes between them. Backs the data
    /// service of the <c>ControlDataGraphViewer</c> control, which queries
    /// <c>GET {uri}</c> once and renders the nodes and edges.
    /// </summary>
    /// <remarks>
    /// The graph is static, so it needs no store: the viewer is read-only and
    /// never sends anything back.
    /// </remarks>
    [Segment("graph")]
    [Title("Monkey Island Graph")]
    public sealed class MonkeyIslandGraph : RestApiGraph
    {
        /// <summary>
        /// Retrieves the places and characters of the map. Most carry a
        /// position, so the map always looks the same; LeChuck's ghost ship is
        /// left without one, which hands its placement to the layout simulation
        /// and lets it drift as a ghost ship should.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The nodes of the graph.</returns>
        protected override IEnumerable<RestApiGraphNode> RetrieveNodes(IRequest request)
        {
            return
            [
                new()
                {
                    Id = "melee",
                    Label = "Mêlée Island",
                    Icon = "fas fa-map-location-dot",
                    X = 80,
                    Y = 180,
                    BackgroundColor = "#eef6fb",
                    ForegroundColor = "#0077be"
                },
                new()
                {
                    Id = "scumm",
                    Label = "Scumm Bar",
                    Icon = "fas fa-beer-mug-empty",
                    X = 80,
                    Y = 340,
                    BackgroundColor = "#fff4e5",
                    ForegroundColor = "#b26a00"
                },
                new()
                {
                    Id = "guybrush",
                    Label = "Guybrush Threepwood",
                    Shape = "circle",
                    Layout = "label-below",
                    Icon = "fas fa-hat-cowboy",
                    X = 330,
                    Y = 330,
                    BackgroundColor = "#e8f5e9",
                    ForegroundColor = "#146c43"
                },
                new()
                {
                    Id = "seamonkey",
                    Label = "Sea Monkey",
                    Icon = "fas fa-sailboat",
                    X = 340,
                    Y = 170,
                    BackgroundColor = "#e3f2fd",
                    ForegroundColor = "#0d6efd"
                },
                new()
                {
                    Id = "monkey",
                    Label = "Monkey Island",
                    Icon = "fas fa-tree",
                    X = 600,
                    Y = 180,
                    BackgroundColor = "#e8f5e9",
                    ForegroundColor = "#146c43"
                },
                new()
                {
                    Id = "elaine",
                    Label = "Elaine Marley",
                    Shape = "circle",
                    Layout = "label-below",
                    Icon = "fas fa-crown",
                    X = 610,
                    Y = 360,
                    BackgroundColor = "#f3e5f5",
                    ForegroundColor = "#6f42c1"
                },
                new()
                {
                    // no position: the layout simulation places the ghost ship
                    Id = "lechuck",
                    Label = "LeChuck's Ghost Ship",
                    Shape = "circle",
                    Layout = "label-below",
                    Icon = "fas fa-skull-crossbones",
                    BackgroundColor = "#fdecea",
                    ForegroundColor = "#b02a37"
                }
            ];
        }

        /// <summary>
        /// Retrieves the routes and relations between the places and characters.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The edges of the graph.</returns>
        protected override IEnumerable<RestApiGraphEdge> RetrieveEdges(IRequest request)
        {
            return
            [
                new() { Id = "e1", From = "melee", To = "scumm", Label = "harbour road", Color = "#0077be" },
                new() { Id = "e2", From = "scumm", To = "guybrush", Label = "wants to be a pirate", Color = "#146c43" },
                new() { Id = "e3", From = "guybrush", To = "seamonkey", Label = "crews", Color = "#0d6efd" },
                new()
                {
                    Id = "e4",
                    From = "seamonkey",
                    To = "monkey",
                    Label = "sets sail",
                    Color = "#0d6efd",
                    Waypoints = [new() { X = 470, Y = 120 }]
                },
                new() { Id = "e5", From = "monkey", To = "elaine", Label = "held captive", Color = "#6f42c1", DashArray = "5,3" },
                new() { Id = "e6", From = "lechuck", To = "elaine", Label = "abducts", Color = "#b02a37", DashArray = "4,4" },
                new() { Id = "e7", From = "lechuck", To = "guybrush", Label = "nemesis", Color = "#b02a37", DashArray = "4,4" }
            ];
        }
    }
}
