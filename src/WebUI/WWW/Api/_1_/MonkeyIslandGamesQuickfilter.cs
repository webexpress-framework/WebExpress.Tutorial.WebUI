using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API quickfilter for managing and retrieving data about Monkey Island games.
    /// </summary>
    public sealed class MonkeyIslandGamesQuickfilter : RestApiQuickfilter<QuickfilterGame>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandGamesQuickfilter()
        {
        }

        /// <summary>
        /// Retrieves a queryable collection of index items.
        /// </summary>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional information or constraints 
        /// for the retrieval operation. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// An enumerable collection of quick filter items that match the 
        /// specified context and request. The collection may be empty if 
        /// no items are found.
        /// </returns>
        protected override IEnumerable<RestApiQuickfilterItem> RetrieveItems(IQueryContext context, IRequest request)
        {
            // narrow the option set on the server by the search query, so a large
            // catalog is filtered before it reaches the dropdown
            var q = request?.GetParameter("q")?.Value ?? string.Empty;

            return ViewModel.MonkeyIslandQuickfilterGames
                .Where(x => string.IsNullOrWhiteSpace(q)
                    || (x.Name ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase))
                .Select(x => new RestApiQuickfilterItem()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Icon = x.Icon,
                    Color = x.Color,
                    // the badge previews how many games the filter would match
                    Badge = ViewModel.MonkeyIslandGames.Count(g => x.Predicate(g)).ToString()
                });
        }
    }
}