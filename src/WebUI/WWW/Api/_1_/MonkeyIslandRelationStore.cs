using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRelation;
using WebExpress.WebApp.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The in-memory world the link demo works on: the quest items of Monkey
    /// Island and the relations between them. It is shared by the link, the
    /// target and the type endpoint, so all three agree on the same data - the
    /// endpoints themselves stay thin and only translate between HTTP and this
    /// store.
    /// </summary>
    internal static class MonkeyIslandRelationStore
    {
        private static readonly object _syncRoot = new();

        /// <summary>
        /// The quest item the link surface of the demo belongs to.
        /// </summary>
        public const string Subject = "QST-00123";

        /// <summary>
        /// The items a link may point at, keyed by their business key.
        /// </summary>
        private static readonly Dictionary<string, RestApiRelationReference> _objects = new(StringComparer.OrdinalIgnoreCase)
        {
            ["QST-00123"] = new() { Key = "QST-00123", Class = "Quest", Title = "Become a mighty pirate", Uri = "#", Status = "In progress", StatusColor = "info" },
            ["QST-00045"] = new() { Key = "QST-00045", Class = "Quest", Title = "Win the sword fight against the Sword Master", Uri = "#", Status = "Open", StatusColor = "warning" },
            ["QST-00041"] = new() { Key = "QST-00041", Class = "Quest", Title = "Find the treasure of Mêlée Island", Uri = "#", Status = "Done", StatusColor = "success" },
            ["ITM-00318"] = new() { Key = "ITM-00318", Class = "Item", Title = "Rubber chicken with a pulley in the middle", Uri = "#", Status = "In inventory", StatusColor = "secondary" },
            ["ITM-00204"] = new() { Key = "ITM-00204", Class = "Item", Title = "Root beer", Uri = "#", Status = "In inventory", StatusColor = "secondary" },
            ["CHR-00321"] = new() { Key = "CHR-00321", Class = "Character", Title = "LeChuck", Uri = "#", Status = "Undead", StatusColor = "danger" },
            ["CHR-00007"] = new() { Key = "CHR-00007", Class = "Character", Title = "Stan, the used ship salesman", Uri = "#", Status = "Alive", StatusColor = "success" }
        };

        /// <summary>
        /// The relations that already exist when the demo is opened.
        /// </summary>
        private static readonly List<Relation> _links =
        [
            Seed("l1", "QST-00123", "QST-00045", RelationType.Blocks, new DateTime(2026, 8, 19), "no crew follows a pirate who cannot fence"),
            Seed("l2", "QST-00041", "QST-00123", RelationType.Causes, new DateTime(2026, 8, 17), null),
            Seed("l3", "QST-00123", "ITM-00318", RelationType.References, new DateTime(2026, 8, 18), "the pulley is needed later"),
            Seed("l4", "QST-00123", "ITM-00204", RelationType.References, new DateTime(2026, 8, 18), null),
            Seed("l5", "QST-00123", "CHR-00321", RelationType.Similar, new DateTime(2026, 8, 12), null),
            External("l6", "QST-00123", "https://www.scummbar.com/", "The SCUMM Bar", new DateTime(2026, 8, 11)),
            External("l7", "QST-00123", "https://en.wikipedia.org/wiki/Monkey_Island", "Monkey Island (series)", new DateTime(2026, 8, 10))
        ];

        /// <summary>
        /// The number the next created link takes its identity from.
        /// </summary>
        private static int _sequence = 100;

        /// <summary>
        /// Returns the reference of the demo quest the surface belongs to.
        /// </summary>
        /// <returns>The reference.</returns>
        public static RelationReference SubjectReference()
        {
            return Resolve(Subject);
        }

        /// <summary>
        /// Determines whether an item exists in the demo world.
        /// </summary>
        /// <param name="key">The business key.</param>
        /// <returns><see langword="true"/> when the item exists.</returns>
        public static bool Exists(string key)
        {
            return !string.IsNullOrWhiteSpace(key) && _objects.ContainsKey(key);
        }

        /// <summary>
        /// Returns the reference of an item.
        /// </summary>
        /// <param name="key">The business key.</param>
        /// <returns>The reference, or <see langword="null"/> when the item is unknown.</returns>
        public static RelationReference Resolve(string key)
        {
            if (key == null || !_objects.TryGetValue(key, out var item))
            {
                return null;
            }

            return new RelationReference
            {
                Key = item.Key,
                Class = item.Class,
                Title = item.Title,
                Uri = item.Uri,
                Status = item.Status,
                StatusColor = item.StatusColor
            };
        }

        /// <summary>
        /// Returns the items matching a search term, as the target search of the
        /// add dialog offers them. An empty term answers the whole world, which
        /// is what the dialog shows before anything was typed.
        /// </summary>
        /// <param name="search">The search term, possibly empty.</param>
        /// <returns>The candidates.</returns>
        public static IEnumerable<RestApiRelationReference> Search(string search)
        {
            lock (_syncRoot)
            {
                return _objects.Values
                    .Where(x => string.IsNullOrEmpty(search)
                        || x.Key.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || x.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || x.Class.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .Select(Clone)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a snapshot of the stored links.
        /// </summary>
        /// <returns>The links.</returns>
        public static IEnumerable<Relation> All()
        {
            lock (_syncRoot)
            {
                return [.. _links];
            }
        }

        /// <summary>
        /// Returns a single stored link.
        /// </summary>
        /// <param name="id">The identity of the link.</param>
        /// <returns>The link, or <see langword="null"/>.</returns>
        public static Relation Find(string id)
        {
            lock (_syncRoot)
            {
                return _links.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Stores a validated link under a generated identity and resolves its
        /// target, so the surface renders the title and the state of the linked
        /// item rather than a bare key.
        /// </summary>
        /// <param name="link">The validated link.</param>
        /// <returns>The stored link.</returns>
        public static Relation Add(Relation link)
        {
            lock (_syncRoot)
            {
                link.Id = $"l{++_sequence}";
                link.Source = Resolve(link.Source?.Key) ?? link.Source;

                var target = Resolve(link.Target?.Key);
                if (target != null)
                {
                    target.Title = string.IsNullOrWhiteSpace(link.Target.Title) ? target.Title : link.Target.Title;
                    link.Target = target;
                }

                _links.Add(link);

                return link;
            }
        }

        /// <summary>
        /// Removes a link.
        /// </summary>
        /// <param name="id">The identity of the link.</param>
        /// <returns><see langword="true"/> when the link existed.</returns>
        public static bool Remove(string id)
        {
            lock (_syncRoot)
            {
                var link = _links.FirstOrDefault(x => x.Id == id);

                return link != null && _links.Remove(link);
            }
        }

        /// <summary>
        /// Returns how many stored links carry a relation, which the type
        /// administration renders as the usage of the row.
        /// </summary>
        /// <param name="type">The id of the relation.</param>
        /// <returns>The number of links.</returns>
        public static int Usage(string type)
        {
            lock (_syncRoot)
            {
                return _links.Count(x => string.Equals(x.Type, type, StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Builds a seeded link between two items of the demo world.
        /// </summary>
        /// <param name="id">The identity.</param>
        /// <param name="source">The key of the source.</param>
        /// <param name="target">The key of the target.</param>
        /// <param name="type">The id of the relation.</param>
        /// <param name="created">The moment the link was established.</param>
        /// <param name="comment">The note on the link.</param>
        /// <returns>The link.</returns>
        private static Relation Seed(string id, string source, string target, string type, DateTime created, string comment)
        {
            return new Relation
            {
                Id = id,
                System = RelationSystem.Object,
                Type = type,
                Source = Resolve(source),
                Target = Resolve(target),
                Created = created,
                CreatedBy = "guybrush",
                Comment = comment
            };
        }

        /// <summary>
        /// Builds a seeded link to an address outside the application.
        /// </summary>
        /// <param name="id">The identity.</param>
        /// <param name="source">The key of the source.</param>
        /// <param name="address">The external address.</param>
        /// <param name="title">The title the address is shown under.</param>
        /// <param name="created">The moment the link was established.</param>
        /// <returns>The link.</returns>
        private static Relation External(string id, string source, string address, string title, DateTime created)
        {
            return new Relation
            {
                Id = id,
                System = RelationSystem.Web,
                Type = RelationType.WebLink,
                Direction = RelationDirection.Unidirectional,
                Source = Resolve(source),
                Target = new RelationReference { Uri = address, Title = title },
                Created = created,
                CreatedBy = "guybrush"
            };
        }

        /// <summary>
        /// Returns a copy of a reference, so a caller cannot mutate the store.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns>The copy.</returns>
        private static RestApiRelationReference Clone(RestApiRelationReference reference)
        {
            return new RestApiRelationReference
            {
                Key = reference.Key,
                Class = reference.Class,
                Title = reference.Title,
                Uri = reference.Uri,
                Status = reference.Status,
                StatusColor = reference.StatusColor
            };
        }
    }
}
