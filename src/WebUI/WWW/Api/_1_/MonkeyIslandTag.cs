using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Manages the tags (labels) attached to the Monkey Island quest log using
    /// a thread-safe in-memory store, and serves autocomplete suggestions from
    /// a fixed vocabulary of well-known Monkey Island themes. The same endpoint
    /// answers both: without a <c>q</c> query parameter it returns the attached
    /// tags, with a <c>q</c> parameter it returns matching suggestions.
    /// </summary>
    [Segment("tags")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Tags")]
    public sealed class MonkeyIslandTag : RestApiTag
    {
        private static readonly object _syncRoot = new();

        private static readonly List<RestApiTagItem> _store =
        [
            new() { Value = "pirate" },
            new() { Value = "grog" }
        ];

        private static readonly string[] _vocabulary =
        [
            "pirate", "grog", "insult-swordfighting", "voodoo", "treasure",
            "monkey", "ghost", "governor", "lechuck", "scumm-bar", "rubber-chicken"
        ];

        /// <summary>
        /// Retrieves the tags currently attached to the quest log.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A snapshot of the attached tags.</returns>
        protected override IEnumerable<RestApiTagItem> RetrieveTags(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _store.Select(Clone)];
            }
        }

        /// <summary>
        /// Returns the vocabulary entries matching the search term that are not
        /// already attached.
        /// </summary>
        /// <param name="term">The search term.</param>
        /// <param name="request">The request context.</param>
        /// <returns>The matching suggestions.</returns>
        protected override IEnumerable<RestApiTagItem> SuggestTags(string term, IRequest request)
        {
            lock (_syncRoot)
            {
                var attached = _store.Select(x => x.Value).ToHashSet(StringComparer.OrdinalIgnoreCase);

                return _vocabulary
                    .Where(v => v.Contains(term, StringComparison.OrdinalIgnoreCase) && !attached.Contains(v))
                    .Select(v => new RestApiTagItem { Value = v })
                    .ToList();
            }
        }

        /// <summary>
        /// Adds a tag to the quest log unless an equal value is already present.
        /// </summary>
        /// <param name="payload">The create payload.</param>
        /// <param name="request">The request context.</param>
        /// <returns>The created (or already existing) tag.</returns>
        protected override RestApiTagItem CreateTag(RestApiTagPayload payload, IRequest request)
        {
            var value = payload.Value.Trim();

            lock (_syncRoot)
            {
                var existing = _store.FirstOrDefault(x => string.Equals(x.Value, value, StringComparison.OrdinalIgnoreCase));
                if (existing is not null)
                {
                    return Clone(existing);
                }

                var item = new RestApiTagItem { Value = value };
                _store.Add(item);
                return Clone(item);
            }
        }

        /// <summary>
        /// Removes the tag with the specified value from the quest log.
        /// </summary>
        /// <param name="value">The value of the tag to remove.</param>
        /// <param name="request">The request context.</param>
        /// <returns>
        /// <see langword="true"/> when the tag existed and was removed; otherwise
        /// <see langword="false"/>.
        /// </returns>
        protected override bool DeleteTag(string value, IRequest request)
        {
            lock (_syncRoot)
            {
                var existing = _store.FirstOrDefault(x => string.Equals(x.Value, value, StringComparison.OrdinalIgnoreCase));
                if (existing is null)
                {
                    return false;
                }

                _store.Remove(existing);
                return true;
            }
        }

        /// <summary>
        /// Returns a shallow copy of the supplied tag so mutations on the
        /// response cannot leak back into the in-memory store.
        /// </summary>
        /// <param name="source">The source tag.</param>
        /// <returns>A copy.</returns>
        private static RestApiTagItem Clone(RestApiTagItem source) => new()
        {
            Value = source.Value,
            Color = source.Color
        };
    }
}
