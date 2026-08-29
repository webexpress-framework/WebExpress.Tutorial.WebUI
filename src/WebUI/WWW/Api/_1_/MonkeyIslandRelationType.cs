using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRelation;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Administers the relation types of the demo. Storing a definition goes
    /// through the same door a plugin uses - <see cref="RelationRegistry.RegisterType"/> -
    /// so a relation an administrator invents here and one a plugin ships are
    /// indistinguishable to the link surface that renders them.
    ///
    /// The demo has no database, so the registry is the store; a real
    /// application persists the definition next to publishing it.
    /// </summary>
    [Segment("link-types")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Relation Types")]
    public sealed class MonkeyIslandRelationType : RestApiRelationType
    {
        /// <summary>
        /// The relations WebExpress ships. They may be edited and deactivated
        /// but never dropped, because the links that reference them would lose
        /// their meaning.
        /// </summary>
        private static readonly HashSet<string> _shipped =
        [
            RelationType.Blocks, RelationType.Causes, RelationType.References, RelationType.Similar,
            RelationType.Duplicate, RelationType.Parent, RelationType.Replaces, RelationType.WebLink
        ];

        /// <summary>
        /// Returns the administered relations.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The relations.</returns>
        protected override IEnumerable<IRelationType> RetrieveTypes(IRequest request)
        {
            return RelationRegistry.Types;
        }

        /// <summary>
        /// Publishes a created or edited relation, which makes it available to
        /// every surface at once.
        /// </summary>
        /// <param name="type">The relation to store.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The stored relation.</returns>
        protected override IRelationType StoreType(RelationType type, IRequest request)
        {
            return RelationRegistry.RegisterType(type);
        }

        /// <summary>
        /// Removes a relation.
        /// </summary>
        /// <param name="id">The id of the relation.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns><see langword="true"/> when the relation existed.</returns>
        protected override bool RemoveType(string id, IRequest request)
        {
            return RelationRegistry.UnregisterType(id);
        }

        /// <summary>
        /// Returns how many stored links carry the relation.
        /// </summary>
        /// <param name="id">The id of the relation.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The number of links.</returns>
        protected override int RetrieveUsage(string id, IRequest request)
        {
            return MonkeyIslandRelationStore.Usage(id);
        }

        /// <summary>
        /// Returns the classes of the demo world, which the editor renders as
        /// its target class checkboxes.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The classes.</returns>
        protected override IEnumerable<RestApiRelationClassItem> RetrieveClasses(IRequest request)
        {
            return
            [
                new() { Id = "Quest", Label = "Quest" },
                new() { Id = "Item", Label = "Item" },
                new() { Id = "Character", Label = "Character" }
            ];
        }

        /// <summary>
        /// Determines whether a relation is shipped by the framework.
        /// </summary>
        /// <param name="type">The relation.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns><see langword="true"/> when the relation is shipped.</returns>
        protected override bool IsBuiltin(IRelationType type, IRequest request)
        {
            return _shipped.Contains(type.Id);
        }
    }
}
