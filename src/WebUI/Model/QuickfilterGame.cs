using System;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebIndex;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a single quickfilter entry.
    /// </summary>
    public class QuickfilterGame : IIndexItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the filter.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the current filter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the icon shown on the filter chip. Authored as a typed
        /// icon; the REST layer serializes it into a css class or image uri.
        /// </summary>
        public IIcon Icon { get; set; }

        /// <summary>
        /// Gets or sets the chip color. Authored as a typed color; the REST
        /// layer serializes it into a button css class or raw color value.
        /// </summary>
        public PropertyColorButton Color { get; set; }

        /// <summary>
        /// Gets or sets the filter logic applied to a game.
        /// </summary>
        public Func<Game, bool> Predicate { get; set; }

        /// <summary>
        /// Returns the specified query.
        /// </summary>
        /// <param name="query"
        /// >The query to be returned.
        /// </param>
        /// <returns>
        /// The instance that was provided as the <paramref name="query"/>
        /// parameter.
        /// </returns>
        public static IQuery<QuickfilterGame> Apply(IQuery<QuickfilterGame> query)
        {
            return query;
        }

    }
}
