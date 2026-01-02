using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API dropdown for managing and retrieving data about Monkey Island inventory items.
    /// </summary>
    [Title("Monkey Island inventory")]
    public sealed class MonkeyIslandInventoriesDropdown : RestApiDropdown<Inventory>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandInventoriesDropdown()
        {
        }

        /// <summary>
        /// Retrieves a collection of index items that match the specified filter 
        /// and request parameters.
        /// </summary>
        /// <param name="filter">
        /// A string used to filter the results. The format and supported values 
        /// depend on the implementation. Can be null or empty to indicate no filtering.
        /// </param>
        /// <param name="request">
        /// An object containing additional parameters that influence the data 
        /// retrieval operation. Cannot be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of index items of type TIndexItem that 
        /// satisfy the filter and request criteria. The collection may be 
        /// empty if no items match.
        /// </returns>
        public override IEnumerable<Inventory> GetData(string filter, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return ViewModel.MonkeyIslandInventories;
            }

            return ViewModel.MonkeyIslandInventories
                .Where
                (
                    x => x.Text.Contains(filter, System.StringComparison.InvariantCultureIgnoreCase)
                );
        }
    }
}
