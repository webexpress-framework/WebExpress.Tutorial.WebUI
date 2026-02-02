using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API selection for managing and retrieving data about Monkey Island locations.
    /// </summary>
    [Title("Monkey Island location")]
    public sealed class MonkeyIslandLocationsSelection : RestApiSelection<Location>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandLocationsSelection()
        {
        }

        /// <summary>
        /// Retrieves a queryable collection of index items that match the specified query criteria.
        /// </summary>
        /// <param name="query">
        /// An object containing the query parameters used to filter and select index items. Cannot 
        /// be null.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional information or constraints 
        /// for the retrieval operation. Cannot be null.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable{TIndexItem}"/> representing the filtered set of index items. The 
        /// result may be empty if no items match the query.
        /// </returns>
        protected override IQueryable<Location> Retrieve(IQuery<Location> query, IQueryContext context)
        {
            return query.Apply(ViewModel.MonkeyIslandLocations.AsQueryable());
        }

        /// <summary>
        /// Applies the specified filter criteria to the given query object.
        /// </summary>
        /// <param name="filter">
        /// A string representing the filter expression to apply. The format and supported 
        /// operators depend on the implementation.
        /// </param>
        /// <param name="query">
        /// The query object to which the filter will be applied.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context for resolving
        /// the appropriate REST API URI.
        /// </param>
        protected override void Filter(string filter, IQuery<Location> query, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return;
            }

            query.WhereContainsIgnoreCase
            (
                x => x.Text, filter
            );
        }
    }
}
