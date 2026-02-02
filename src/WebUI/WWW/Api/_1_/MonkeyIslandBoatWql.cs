using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
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
    }
}