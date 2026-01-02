using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
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
        /// Retrieves a collection of objects based on the specified WQL statement and request.
        /// </summary>
        /// <param name="filter">
        /// The filter used to query the data. This parameter defines the filtering and selection criteria.
        /// </param>
        /// <param name="request">
        /// The request context containing additional information for the operation.
        /// </param>
        /// <returns>
        /// An enumerable containing the objects that match the query criteria.
        /// </returns>
        public override IEnumerable<Location> GetData(string filter, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return ViewModel.MonkeyIslandLocations;
            }

            return ViewModel.MonkeyIslandLocations
                .Where
                (
                    x => x.Text.Contains(filter, System.StringComparison.InvariantCultureIgnoreCase)
                );
        }
    }
}
