using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRelation;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Serves the links of the demo quest. The base class does the whole
    /// generic half - the filtering, the grouping by relation, the perspective
    /// that decides which of the two labels applies and the validation against
    /// the link registry - so this endpoint only answers where the links and the
    /// items live.
    /// </summary>
    [Segment("links")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Links")]
    public sealed class MonkeyIslandRelation : RestApiRelation
    {
        /// <summary>
        /// Returns the quest the surface belongs to. A real application resolves
        /// it from the route; the demo has exactly one.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The quest.</returns>
        protected override RelationReference RetrieveSubject(IRequest request)
        {
            return MonkeyIslandRelationStore.SubjectReference();
        }

        /// <summary>
        /// Returns the links matching the filter. The in-memory store cannot
        /// push the criteria into a query, so the shared filter narrows them.
        /// </summary>
        /// <param name="filter">The criteria, with the category already removed.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The links.</returns>
        protected override IEnumerable<Relation> RetrieveLinks(RestApiRelationFilter filter, IRequest request)
        {
            return MonkeyIslandRelationStore.All()
                .Where(x => filter.Source == null || Touches(x, filter.Source))
                .Where(x => filter.Matches(x, KindOf(x)));
        }

        /// <summary>
        /// Returns a single stored link.
        /// </summary>
        /// <param name="id">The identity of the link.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The link, or <see langword="null"/>.</returns>
        protected override Relation RetrieveLink(string id, IRequest request)
        {
            return MonkeyIslandRelationStore.Find(id);
        }

        /// <summary>
        /// Stores a validated link.
        /// </summary>
        /// <param name="link">The validated link.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The stored link.</returns>
        protected override Relation CreateLink(Relation link, IRequest request)
        {
            return MonkeyIslandRelationStore.Add(link);
        }

        /// <summary>
        /// Confirms the changes of a link the store already holds by reference.
        /// </summary>
        /// <param name="link">The validated link.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The stored link.</returns>
        protected override Relation UpdateLink(Relation link, IRequest request)
        {
            return link;
        }

        /// <summary>
        /// Removes a link.
        /// </summary>
        /// <param name="id">The identity of the link.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns><see langword="true"/> when the link existed.</returns>
        protected override bool DeleteLink(string id, IRequest request)
        {
            return MonkeyIslandRelationStore.Remove(id);
        }

        /// <summary>
        /// Resolves whether an item exists, so a link can never be stored
        /// against a key that was mistyped.
        /// </summary>
        /// <param name="reference">The reference to resolve.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns><see langword="true"/> when the item exists.</returns>
        protected override bool Exists(RelationReference reference, IRequest request)
        {
            return !reference.IsObject() || MonkeyIslandRelationStore.Exists(reference.Key);
        }

        /// <summary>
        /// Determines whether a link touches an item with either of its ends.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns><see langword="true"/> when one of the ends is the item.</returns>
        private static bool Touches(Relation link, string key)
        {
            return link.Source?.Key == key || link.Target?.Key == key;
        }
    }
}
