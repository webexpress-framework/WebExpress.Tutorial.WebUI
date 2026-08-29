using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRelation;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Searches the items a link may point at. The relation travels with the
    /// query, so a relation that is narrowed to certain classes does not offer
    /// the others in the first place - the dialog then cannot even propose a
    /// target the validation would reject.
    /// </summary>
    [Segment("link-targets")]
    [Title("Monkey Island Relation Targets")]
    public sealed class MonkeyIslandRelationTarget : RestApiRelationTarget
    {
        /// <summary>
        /// Returns the candidates for a search term, narrowed to the classes the
        /// picked relation accepts.
        /// </summary>
        /// <param name="search">The search term, possibly empty.</param>
        /// <param name="type">The id of the relation the link will carry.</param>
        /// <param name="system">The id of the link system.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The candidates.</returns>
        protected override IEnumerable<RestApiRelationReference> RetrieveTargets(string search, string type, string system, IRequest request)
        {
            var accepted = RelationRegistry.GetType(type)?.TargetClasses?.ToList() ?? [];

            return MonkeyIslandRelationStore.Search(search)
                .Where(x => accepted.Count == 0 || accepted.Contains(x.Class));
        }
    }
}
