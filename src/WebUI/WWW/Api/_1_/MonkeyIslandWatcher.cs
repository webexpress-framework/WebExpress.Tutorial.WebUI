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
    [Segment("watchers")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Watchers")]
    public sealed class MonkeyIslandWatcher : RestApiWatcher<Character>
    {
        private static readonly object _syncRoot = new();
        private static readonly List<RestApiWatcherItem> _store =
        [
            new() { Id = "guybrush",   Name = "Guybrush Threepwood", Team = "Mighty Pirates",   Initials = "GT", Color = "#1d4ed8" },
            new() { Id = "elaine",     Name = "Elaine Marley",       Team = "Governor's Office", Initials = "EM", Color = "#7c3aed" }
        ];

        /// <summary>
        /// Retrieves all watchers from memory in a thread-safe manner.
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
        /// <returns>A snapshot of the watcher list.</returns>
        protected override IEnumerable<RestApiWatcherItem> RetrieveWatchers(IQuery<Character> query, IQueryContext context, IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _store.Select(Clone)];
            }
        }

        /// <summary>
        /// Resolves the user against the Monkey Island directory and adds
        /// the corresponding watcher record to the store.
        /// </summary>
        /// <param name="userId">The id of the user to be added.</param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional 
        /// information or constraints for the retrieval operation. Cannot 
        /// be null.
        /// </param>
        /// <param name="request">The request context.</param>
        /// <returns>The added watcher, or <see langword="null"/> when no character matches the id.</returns>
        protected override RestApiWatcherItem AddWatcher(string userId, IQueryContext context, IRequest request)
        {
            var user = MonkeyIslandWatcherDirectory.FindById(userId);
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
        /// Removes the watcher with the specified id from the store.
        /// </summary>
        /// <param name="userId">The id of the user to be removed.</param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional 
        /// information or constraints for the retrieval operation. Cannot 
        /// be null.
        /// </param>
        /// <param name="request">The request context.</param>
        /// <returns>
        /// <see langword="true"/> when the watcher existed and was
        /// removed; otherwise <see langword="false"/>.
        /// </returns>
        protected override bool RemoveWatcher(string userId, IQueryContext context, IRequest request)
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
        /// Returns a shallow copy of the supplied watcher so mutations on
        /// the response cannot leak back into the in-memory store.
        /// </summary>
        /// <param name="source">The source watcher.</param>
        /// <returns>A copy.</returns>
        private static RestApiWatcherItem Clone(RestApiWatcherItem source) => new()
        {
            Id = source.Id,
            Name = source.Name,
            Team = source.Team,
            Initials = source.Initials,
            Color = source.Color
        };
    }
}
