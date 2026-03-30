using System;
using WebExpress.WebIndex;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a single quickfilter entry.
    /// </summary>
    public class QuickfilterGame : IIndexItem
    {
        /// <summary>
        /// Returns or sets the unique identifier for the filter.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Returns or sets the name associated with the current filter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns or sets the filter logic applied to a game.
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
