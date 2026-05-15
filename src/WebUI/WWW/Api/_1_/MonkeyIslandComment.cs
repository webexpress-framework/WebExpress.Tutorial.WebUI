using System;
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
    /// Provides a Monkey Island themed comment REST endpoint. Seeds the
    /// in-memory store with a thread between Guybrush, Elaine, Stan and the
    /// Voodoo Lady so the tutorial page has content to render on first
    /// load. Routing of the sub-paths (<c>/likes</c>, <c>/pin</c>,
    /// <c>/reactions</c>, <c>/replies</c>) is handled by the
    /// <see cref="RestApiComment"/> base class.
    /// </summary>
    [Segment("comments")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Comments")]
    public sealed class MonkeyIslandComment : RestApiComment<Character>
    {
        private static readonly object _syncRoot = new();
        private static readonly List<RestApiCommentItem> _store = Seed();
        private static int _nextId = 100;

        /// <summary>
        /// Retrieves all comments from memory in a thread‑safe manner.
        /// </summary>
        /// <param name="query">
        /// The query that defines the criteria for selecting Scrum items. Cannot 
        /// be null.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed, providing additional 
        /// information or constraints. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request context.
        /// </param>
        /// <returns>
        /// A collection of cloned comment elements.
        /// </returns>
        protected override IEnumerable<RestApiCommentItem> RetrieveComments(IQuery<Character> query, IQueryContext context, IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _store.Select(Clone)];
            }
        }

        /// <summary>
        /// Creates a new comment from the provided payload and adds it to the store.
        /// </summary>
        /// <param name="payload">
        /// The comment data including body, category, and labels.
        /// </param>
        /// <param name="request">
        /// The HTTP request used to resolve the current user.
        /// </param>
        /// <returns>A cloned copy of the newly created comment item.</returns>
        protected override RestApiCommentItem CreateComment(RestApiCommentPayload payload, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = new RestApiCommentItem
                {
                    Id = "c" + System.Threading.Interlocked.Increment(ref _nextId),
                    Author = ResolveCurrentUser(request) ?? "guybrush",
                    Body = payload?.Body ?? string.Empty,
                    Category = payload?.Category ?? "general",
                    Labels = payload?.Labels?.ToList() ?? [],
                    Likes = [],
                    Reactions = new Dictionary<string, IEnumerable<string>>(),
                    Replies = [],
                    When = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm")
                };

                _store.Add(item);
                return Clone(item);
            }
        }

        /// <summary>
        /// Updates a comment with the specified ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the comment to update.
        /// </param>
        /// <param name="payload">
        /// The payload containing the fields to be updated.
        /// </param>
        /// <param name="request">
        /// The request used to resolve the current user.
        /// </param>
        /// <returns>
        /// The updated comment, or <see langword="null"/> if no comment with the 
        /// specified ID was found.
        /// </returns>
        protected override RestApiCommentItem UpdateComment(string id, RestApiCommentPayload payload, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = _store.FirstOrDefault(x => x.Id == id);
                if (item is null)
                {
                    return null;
                }

                item.Body = payload?.Body ?? item.Body;
                item.Category = payload?.Category ?? item.Category;
                item.Labels = payload?.Labels?.ToList() ?? item.Labels;
                item.Edited = new RestApiCommentEditInfo
                {
                    When = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm"),
                    By = ResolveCurrentUser(request) ?? item.Author
                };
                return Clone(item);
            }
        }

        /// <summary>
        /// Deletes a comment by its ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the comment to delete.
        /// </param>
        /// <param name="request">
        /// The request context.
        /// </param>
        /// <returns>
        /// true if the comment was found and deleted; otherwise, false.
        /// </returns>
        protected override bool DeleteComment(string id, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = _store.FirstOrDefault(x => x.Id == id);
                if (item is null)
                {
                    return false;
                }

                _store.Remove(item);
                return true;
            }
        }

        /// <summary>
        /// Toggles a like for a user on an item. If the user has already liked 
        /// the item, the like is removed; otherwise, it is added.
        /// </summary>
        /// <param name="id">The identifier of the item.</param>
        /// <param name="userId">The identifier of the user toggling the like.</param>
        /// <param name="request">The request context.</param>
        /// <returns>
        /// A collection of user identifiers who have liked the item, or 
        /// <see langword="null"/> if the item is not found.
        /// </returns>
        protected override IEnumerable<string> ToggleLike(string id, string userId, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = _store.FirstOrDefault(x => x.Id == id);
                if (item is null)
                {
                    return null;
                }

                var likes = item.Likes?.ToList() ?? [];
                if (!string.IsNullOrEmpty(userId))
                {
                    if (likes.Contains(userId))
                    {
                        likes.Remove(userId);
                    }
                    else
                    {
                        likes.Add(userId);
                    }
                }

                item.Likes = likes;
                return likes.ToList();
            }
        }

        /// <summary>
        /// Toggles the pin state of the item with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the item to toggle.</param>
        /// <param name="request">The request context.</param>
        /// <returns>
        /// <see langword="true"/> if the item is now pinned; 
        /// <see langword="false"/> if the item is now unpinned; <see
        /// langword="null"/> if the item was not found.
        /// </returns>
        protected override bool? TogglePin(string id, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = _store.FirstOrDefault(x => x.Id == id);
                if (item is null)
                {
                    return null;
                }

                item.Pinned = !item.Pinned;
                return item.Pinned;
            }
        }

        /// <summary>
        /// Toggles a user's reaction on an item.
        /// </summary>
        /// <remarks>
        /// This method is thread‑safe.
        /// </remarks>
        /// <param name="id">
        /// The identifier of the item.
        /// </param>
        /// <param name="emoji">
        /// The emoji reaction to toggle.
        /// </param>
        /// <param name="userId">
        /// The user identifier. If null or empty, no changes are applied.
        /// </param>
        /// <param name="request">
        /// The request context.
        /// </param>
        /// <returns>
        /// A dictionary of reactions with their associated user lists, or null if the item was not found.
        /// </returns>
        protected override IDictionary<string, IEnumerable<string>> ToggleReaction(string id, string emoji, string userId, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = _store.FirstOrDefault(x => x.Id == id);
                if (item is null)
                {
                    return null;
                }

                var reactions = item.Reactions?.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value.ToList())
                    ?? [];

                if (!reactions.TryGetValue(emoji, out var users))
                {
                    users = [];
                }

                var list = users.ToList();
                if (!string.IsNullOrEmpty(userId))
                {
                    if (list.Contains(userId))
                    {
                        list.Remove(userId);
                    }
                    else
                    {
                        list.Add(userId);
                    }
                }

                if (list.Count == 0)
                {
                    reactions.Remove(emoji);
                }
                else
                {
                    reactions[emoji] = list;
                }

                item.Reactions = reactions;
                return reactions.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value.ToList());
            }
        }

        /// <summary>
        /// Appends a reply to the comment with the specified identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of the comment to append the reply to.
        /// </param>
        /// <param name="body">
        /// The text content of the reply.
        /// </param>
        /// <param name="request">
        /// The request context used to resolve the current user.
        /// </param>
        /// <returns>
        /// The newly created reply, or <see langword="null"/> if the comment 
        /// was not found.
        /// </returns>
        protected override RestApiCommentReply AppendReply(string id, string body, IRequest request)
        {
            lock (_syncRoot)
            {
                var item = _store.FirstOrDefault(x => x.Id == id);
                if (item is null)
                {
                    return null;
                }

                var reply = new RestApiCommentReply
                {
                    Id = "r" + System.Threading.Interlocked.Increment(ref _nextId),
                    Author = ResolveCurrentUser(request) ?? "guybrush",
                    Body = body,
                    When = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm")
                };

                var replies = item.Replies?.ToList() ?? [];
                replies.Add(reply);
                item.Replies = replies;
                return reply;
            }
        }

        /// <summary>
        /// Resolves the current user identifier from the request.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>Always returns the hardcoded value "guybrush".</returns>
        protected override string ResolveCurrentUser(IRequest request) => "guybrush";

        /// <summary>
        /// Builds the seed thread shown when the page is opened for the
        /// first time.
        /// </summary>
        /// <returns>The seeded comments.</returns>
        private static List<RestApiCommentItem> Seed() =>
        [
            new RestApiCommentItem
            {
                Id = "c1",
                Author = "guybrush",
                Category = "question",
                Labels = ["sword-master", "carla"],
                Body = "<p>How do you defeat Carla, the Sword Master of Mêlée Island? She keeps countering my <em>insults</em>!</p>",
                When = "1990-10-15 09:42",
                Likes = ["elaine"],
                Reactions = new Dictionary<string, IEnumerable<string>>
                {
                    ["⚔️"] = new List<string> { "elaine", "stan" }
                },
                Replies =
                [
                    new RestApiCommentReply { Id = "r1", Author = "voodoolady", Body = "Listen carefully to the pirates on the docks — every insult has a matching retort.", When = "1990-10-15 10:01" },
                    new RestApiCommentReply { Id = "r2", Author = "elaine",     Body = "Practice on the lowlife pirates outside the SCUMM Bar first.",                            When = "1990-10-15 10:14" }
                ],
                Pinned = true
            },
            new RestApiCommentItem
            {
                Id = "c2",
                Author = "elaine",
                Category = "hint",
                Labels = ["voodoo", "monkey-island"],
                Body = "<p>Captain LeChuck is haunting the Caribbean again. The Voodoo Lady can tell you where to find the <strong>three trials</strong>.</p>",
                When = "1990-10-15 11:23",
                Likes = ["guybrush"],
                Reactions = new Dictionary<string, IEnumerable<string>>
                {
                    ["💀"] = new List<string> { "guybrush" }
                },
                Replies = []
            },
            new RestApiCommentItem
            {
                Id = "c3",
                Author = "stan",
                Category = "decision",
                Labels = ["ship", "shopping"],
                Body = "<p>Have I got a <strong>ship</strong> for you! Today only — extended warranty included, free anchor, no questions asked!</p>",
                When = "1990-10-15 13:05",
                Likes = [],
                Reactions = new Dictionary<string, IEnumerable<string>>
                {
                    ["💰"] = new List<string> { "guybrush" },
                    ["🙄"] = new List<string> { "elaine", "voodoolady" }
                },
                Replies =
                [
                    new RestApiCommentReply { Id = "r3", Author = "guybrush", Body = "Stan, last time the hull was held together with chewing gum.", When = "1990-10-15 13:11" }
                ]
            },
            new RestApiCommentItem
            {
                Id = "c4",
                Author = "voodoolady",
                Category = "solution",
                Labels = ["root-beer", "ghost"],
                Body = "<p>Remember — only a flask of <em>root beer</em> can banish the ghost pirate LeChuck. Brew it well.</p>",
                When = "1990-10-15 18:30",
                Likes = ["guybrush", "elaine"],
                Reactions = new Dictionary<string, IEnumerable<string>>
                {
                    ["🍺"] = new List<string> { "guybrush" },
                    ["✨"] = new List<string> { "elaine" }
                },
                Replies = []
            }
        ];

        /// <summary>
        /// Returns a shallow copy of the supplied comment so mutations on
        /// the response cannot leak back into the in-memory store.
        /// </summary>
        /// <param name="source">The source comment.</param>
        /// <returns>A copy.</returns>
        private static RestApiCommentItem Clone(RestApiCommentItem source) => new()
        {
            Id = source.Id,
            Author = source.Author,
            Category = source.Category,
            Labels = source.Labels?.ToList(),
            Body = source.Body,
            When = source.When,
            Likes = source.Likes?.ToList(),
            Reactions = source.Reactions?.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value.ToList()),
            Replies = source.Replies?.Select(r => new RestApiCommentReply
            {
                Id = r.Id,
                Author = r.Author,
                Body = r.Body,
                When = r.When
            }).ToList(),
            Pinned = source.Pinned,
            Edited = source.Edited is null ? null : new RestApiCommentEditInfo { When = source.Edited.When, By = source.Edited.By }
        };
    }
}
