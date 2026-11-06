using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The endpoint of the data tree tutorial: the islands of Monkey Island as the first level and
    /// their locations below them. The hierarchy is kept in memory, so the moves made on the
    /// tutorial page last until the server restarts and every visitor sees the same tree.
    /// </summary>
    [Title("Monkey Island locations")]
    public sealed class MonkeyIslandLocationTree : RestApiTree<Location>
    {
        private static readonly object _gate = new();
        private static Dictionary<string, List<string>> _children;
        private static Dictionary<string, string> _labels;

        /// <summary>
        /// Returns the children of a node in their order.
        /// </summary>
        /// <param name="parentId">The parent, or null for the islands.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns>The children.</returns>
        protected override IEnumerable<RestApiTreeNode> RetrieveChildren(string parentId, IQueryContext context, IRequest request)
        {
            lock (_gate)
            {
                Seed();

                return [.. (_children.TryGetValue(parentId ?? "", out var ids) ? ids : []).Select(id => new RestApiTreeNode
                {
                    Id = id,
                    Label = _labels[id],
                    Icon = id.StartsWith("island-", StringComparison.Ordinal) ? "wx-icon-light wx-icon-light-map" : "wx-icon-light wx-icon-light-location-dot",
                    HasChildren = _children.TryGetValue(id, out var below) && below.Count > 0
                })];
            }
        }

        /// <summary>
        /// Returns the parent of a node.
        /// </summary>
        /// <param name="id">The node.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns>The parent, or null for an island.</returns>
        protected override string RetrieveParent(string id, IQueryContext context, IRequest request)
        {
            lock (_gate)
            {
                Seed();

                var parent = _children.FirstOrDefault(x => x.Value.Contains(id)).Key;

                return string.IsNullOrEmpty(parent) ? null : parent;
            }
        }

        /// <summary>
        /// Stores a move in the in-memory hierarchy. An island stays on the first level, because
        /// the sea does not move.
        /// </summary>
        /// <param name="node">The moved node.</param>
        /// <param name="target">The node it was dropped on.</param>
        /// <param name="position">Where it is placed relative to the target.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns>True when the move was stored.</returns>
        protected override bool MoveNode(string node, string target, RestApiTreeMovePosition position, IQueryContext context, IRequest request)
        {
            lock (_gate)
            {
                Seed();

                var to = position == RestApiTreeMovePosition.Child
                    ? target
                    : _children.FirstOrDefault(x => x.Value.Contains(target)).Key;

                if (to is null || !_labels.ContainsKey(node) ||
                    node.StartsWith("island-", StringComparison.Ordinal) != (to == ""))
                {
                    return false;
                }

                foreach (var list in _children.Values)
                {
                    list.Remove(node);
                }

                var siblings = _children.TryGetValue(to, out var existing) ? existing : _children[to] = [];
                var at = siblings.IndexOf(target);
                siblings.Insert(position switch
                {
                    RestApiTreeMovePosition.Above when at >= 0 => at,
                    RestApiTreeMovePosition.Below when at >= 0 => at + 1,
                    _ => siblings.Count
                }, node);

                return true;
            }
        }

        /// <summary>
        /// Turns a name into an id that an address carries without escaping.
        /// </summary>
        /// <param name="name">The name, such as Mêlée Island.</param>
        /// <returns>The id, such as melee-island.</returns>
        private static string Slug(string name)
        {
            var letters = name.Normalize(NormalizationForm.FormD)
                .Where(x => CharUnicodeInfo.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(letters).ToLowerInvariant().Replace(' ', '-');
        }

        /// <summary>
        /// Builds the hierarchy from the locations of the view model on first use.
        /// </summary>
        private static void Seed()
        {
            if (_children is not null)
            {
                return;
            }

            _children = new Dictionary<string, List<string>> { [""] = [] };
            _labels = [];

            foreach (var location in ViewModel.MonkeyIslandLocations)
            {
                var island = "island-" + Slug(location.Island);
                if (!_labels.ContainsKey(island))
                {
                    _labels[island] = location.Island;
                    _children[""].Add(island);
                    _children[island] = [];
                }

                var id = location.Id.ToString();
                _labels[id] = location.Text;
                _children[island].Add(id);
            }
        }
    }
}
