using System.Collections.Generic;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebUri;

namespace WebExpress.Tutorial.WebUI.WebUri
{
    /// <summary>
    /// The address segment of a location on Monkey Island, which stands for more than one step of
    /// the breadcrumb: the island, the area and the location itself. The breadcrumb tutorial
    /// appends it to the address of its page to show how a single segment contributes several
    /// crumbs, one of them with a menu of its neighbours.
    /// </summary>
    /// <param name="value">The value of the segment, the location.</param>
    public sealed class UriPathSegmentLocationTrail(string value) : IUriPathSegmentTrail
    {
        /// <summary>
        /// Gets the id of the segment.
        /// </summary>
        public string Id => Value;

        /// <summary>
        /// Gets the value of the segment.
        /// </summary>
        public string Value { get; } = value;

        /// <summary>
        /// Gets no tag.
        /// </summary>
        public object Tag => null;

        /// <summary>
        /// Gets that the segment is not empty.
        /// </summary>
        public bool IsEmpty => string.IsNullOrWhiteSpace(Value);

        /// <summary>
        /// Gets or sets whether the segment is hidden.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets the address the segment links to.
        /// </summary>
        public IUri Uri { get; set; }

        /// <summary>
        /// Tells whether a value of an address is this segment.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True for the same value.</returns>
        public bool IsMatched(string value)
        {
            return value == Value;
        }

        /// <summary>
        /// Copies the segment with its own type, as an address copies its segments.
        /// </summary>
        /// <returns>The copy.</returns>
        public IUriPathSegment Copy()
        {
            return new UriPathSegmentLocationTrail(Value) { IsHidden = IsHidden, Uri = Uri };
        }

        /// <summary>
        /// Compares the values of two segments.
        /// </summary>
        /// <param name="obj">The other segment.</param>
        /// <returns>True for the same value.</returns>
        public bool Equals(IUriPathSegment obj)
        {
            return obj?.Value == Value;
        }

        /// <summary>
        /// Returns the crumbs the segment contributes: the island, the area with a menu of the
        /// other areas, and the location.
        /// </summary>
        /// <param name="renderContext">The context of the page.</param>
        /// <returns>The crumbs, from the outermost to the innermost.</returns>
        public IEnumerable<UriTrailCrumb> GetTrail(IRenderContext renderContext)
        {
            yield return new UriTrailCrumb { Text = "Mêlée Island", Uri = new UriEndpoint("#melee-island") };
            yield return new UriTrailCrumb
            {
                Text = "Mêlée Island Village",
                Uri = new UriEndpoint("#village"),
                Menu =
                [
                    new UriTrailCrumb { Text = "Docks", Uri = new UriEndpoint("#docks") },
                    new UriTrailCrumb { Text = "Forest", Uri = new UriEndpoint("#forest") },
                    new UriTrailCrumb { Text = "Lookout Point", Uri = new UriEndpoint("#lookout-point") }
                ]
            };
            yield return new UriTrailCrumb { Text = Value, Uri = new UriEndpoint("#" + Value.ToLowerInvariant().Replace(' ', '-')) };
        }

        /// <summary>
        /// Returns the value.
        /// </summary>
        /// <returns>The value.</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
