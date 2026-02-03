using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API wql prompt retrieving data about Monkey Island boats.
    /// </summary>
    public sealed class MonkeyIslandBoatWql : RestApiWqlPrompt<Game>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager used to retrieve URIs for the application context.</param>
        /// <param name="applicationContext">The application context containing the current state of the application.</param>
        public MonkeyIslandBoatWql(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
        }

        /// <summary>
        /// Retrieves a collection of historical entries associated with the specified request.
        /// </summary>
        /// <remarks>
        /// Override this method in a derived class to provide custom history retrieval
        /// logic.
        /// </remarks>
        /// <param name="request">
        /// The request for which to retrieve history. Cannot be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of strings representing the history entries for the 
        /// specified request. The collection is empty if no history is available.
        /// </returns>
        protected override IEnumerable<string> GetHistory(IRequest request)
        {
            yield return "Name ~ \"Monkey\" AND BoatType ~ \"Ghost Ship\"";
            yield return "BoatType ~ \"Ghost Ship\"";
            yield return "Name ~ \"Monkey\"";
        }
    }
}