using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API selection for managing and retrieving data about Monkey Island locations.
    /// </summary>
    [Title("Monkey Island location")]
    [Method(CrudMethod.GET)]
    public sealed class MonkeyIslandLocations : RestApiCrudSelection<Location>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandLocations(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            Data = ViewModel.MonkeyIslanLocations;
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
        public override IEnumerable<Location> GetData(string filter, Request request)
        {
            if (filter == null || filter == "null")
            {
                return Data;
            }

            return Data
                .Where
                (
                    x => x.Text.Contains(filter, System.StringComparison.InvariantCultureIgnoreCase)
                );
        }
    }
}
