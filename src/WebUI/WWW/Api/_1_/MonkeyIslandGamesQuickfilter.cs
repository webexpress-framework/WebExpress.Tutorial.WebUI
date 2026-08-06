using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API quickfilter for managing and retrieving data about Monkey Island games.
    /// </summary>
    public sealed class MonkeyIslandGamesQuickfilter : RestApiQuickfilter<QuickfilterGame>
    {
        // the tutorial keeps the user's own filters in memory, which is enough to
        // show the round trip; a real endpoint would store them per user
        private static readonly List<RestApiQuickfilterItem> _userFilters = [];
        private static int _nextUserFilter = 1;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandGamesQuickfilter()
        {
        }

        /// <summary>
        /// Creates a filter of the user's own. The criteria are a plain substring
        /// of the game title here; the framework never looks into them.
        /// </summary>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <param name="payload">The values the client supplied.</param>
        /// <returns>The created filter.</returns>
        protected override RestApiQuickfilterItem CreateItem(IQueryContext context, IRequest request, RestApiQuickfilterPayload payload)
        {
            var item = new RestApiQuickfilterItem()
            {
                Id = $"user-{_nextUserFilter++}",
                Name = payload.Name,
                Icon = new IconStar(),
                Color = string.IsNullOrWhiteSpace(payload.Color) ? null : new PropertyColorButton(payload.Color),
                Criteria = payload.Criteria,
                Custom = true
            };

            _userFilters.Add(item);

            return WithBadge(item);
        }

        /// <summary>
        /// Changes a filter of the user's own.
        /// </summary>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <param name="payload">The values the client supplied.</param>
        /// <returns>The updated filter, or null when it is unknown.</returns>
        protected override RestApiQuickfilterItem UpdateItem(IQueryContext context, IRequest request, RestApiQuickfilterPayload payload)
        {
            var item = _userFilters.FirstOrDefault(x => x.Id == payload.Id);

            if (item is null)
            {
                return null;
            }

            item.Name = payload.Name;
            item.Criteria = payload.Criteria;
            item.Color = string.IsNullOrWhiteSpace(payload.Color) ? null : new PropertyColorButton(payload.Color);

            return WithBadge(item);
        }

        /// <summary>
        /// Removes a filter of the user's own.
        /// </summary>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <param name="id">The id of the filter to remove.</param>
        /// <returns>True when the filter was removed.</returns>
        protected override bool DeleteItem(IQueryContext context, IRequest request, string id)
        {
            return _userFilters.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Refreshes the badge of a user-defined filter, so it previews how many
        /// games its criteria match just like an application filter does.
        /// </summary>
        /// <param name="item">The filter to refresh.</param>
        /// <returns>The filter.</returns>
        private static RestApiQuickfilterItem WithBadge(RestApiQuickfilterItem item)
        {
            item.Badge = ViewModel.MonkeyIslandGames.Count(g => Matches(g, item.Criteria)).ToString();

            return item;
        }

        /// <summary>
        /// Applies the criteria of a user-defined filter to a game. The tutorial
        /// reads them as a substring of the title; an application is free to put
        /// a query or a serialized object in them instead.
        /// </summary>
        /// <param name="game">The game to test.</param>
        /// <param name="criteria">The criteria of the filter.</param>
        /// <returns>True when the game matches.</returns>
        private static bool Matches(Game game, string criteria)
        {
            return string.IsNullOrWhiteSpace(criteria)
                || (game.Name ?? string.Empty).Contains(criteria, StringComparison.OrdinalIgnoreCase);
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

            var items = ViewModel.MonkeyIslandQuickfilterGames
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

            // the user's own filters follow the application's, so a bar reads
            // from the given to the self-made
            return items.Concat(_userFilters
                .Where(x => string.IsNullOrWhiteSpace(q)
                    || (x.Name ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase))
                .Select(WithBadge));
        }
    }
}