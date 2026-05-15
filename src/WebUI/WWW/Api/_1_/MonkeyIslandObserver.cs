using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Manages watchers for Monkey Island characters using a thread‑safe 
    /// in‑memory store.
    /// </summary>
    [Segment("observers")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Observers")]
    public sealed class MonkeyIslandObserver : RestApiObserver<Character>
    {
        private static readonly object _syncRoot = new();
        private static readonly List<RestApiObserverItem> _store =
        [
            new() { Id = "guybrush",   Name = "Guybrush Threepwood", Team = "Mighty Pirates",   Initials = "GT", Color = "#1d4ed8" },
            new() { Id = "elaine",     Name = "Elaine Marley",       Team = "Governor's Office", Initials = "EM", Color = "#7c3aed" }
        ];

        /// <summary>
        /// Retrieves all observers from memory in a thread-safe manner.
        /// </summary>
        /// <param name="query">
        /// An object containing the query parameters used to filter and select 
        /// index items. Cannot be null.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional 
        /// information or constraints for the retrieval operation. Cannot 
        /// be null.
        /// </param>
        /// <param name="request">The request context.</param>
        /// <returns>A snapshot of the observer list.</returns>
        protected override IEnumerable<RestApiObserverItem> RetrieveObservers(IQuery<Character> query, IQueryContext context, IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _store.Select(Clone)];
            }
        }

        /// <summary>
        /// Resolves the user against the Monkey Island directory and adds
        /// the corresponding observer record to the store.
        /// </summary>
        /// <param name="userId">The id of the user to be added.</param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional 
        /// information or constraints for the retrieval operation. Cannot 
        /// be null.
        /// </param>
        /// <param name="request">The request context.</param>
        /// <returns>The added observer, or <see langword="null"/> when no character matches the id.</returns>
        protected override RestApiObserverItem AddObserver(string userId, IQueryContext context, IRequest request)
        {
            var user = MonkeyIslandObserverDirectory.FindById(userId);
            if (user is null)
            {
                return null;
            }

            lock (_syncRoot)
            {
                if (_store.Any(x => x.Id == userId))
                {
                    return Clone(user);
                }

                _store.Add(Clone(user));
                return Clone(user);
            }
        }

        /// <summary>
        /// Removes the observer with the specified id from the store.
        /// </summary>
        /// <param name="userId">The id of the user to be removed.</param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional 
        /// information or constraints for the retrieval operation. Cannot 
        /// be null.
        /// </param>
        /// <param name="request">The request context.</param>
        /// <returns>
        /// <see langword="true"/> when the observer existed and was
        /// removed; otherwise <see langword="false"/>.
        /// </returns>
        protected override bool RemoveObserver(string userId, IQueryContext context, IRequest request)
        {
            lock (_syncRoot)
            {
                var existing = _store.FirstOrDefault(x => x.Id == userId);
                if (existing is null)
                {
                    return false;
                }

                _store.Remove(existing);
                return true;
            }
        }

        /// <summary>
        /// Returns a shallow copy of the supplied observer so mutations on
        /// the response cannot leak back into the in-memory store.
        /// </summary>
        /// <param name="source">The source observer.</param>
        /// <returns>A copy.</returns>
        private static RestApiObserverItem Clone(RestApiObserverItem source) => new()
        {
            Id = source.Id,
            Name = source.Name,
            Team = source.Team,
            Initials = source.Initials,
            Color = source.Color
        };
    }
}
