using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island games.
    /// </summary>
    [Title("Monkey Island Games")]
    public sealed class MonkeyIslandGamesList : RestApiList<Game>
    {
        private readonly string _formUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager used to retrieve URIs for the application context.</param>
        /// <param name="applicationContext">The application context containing the current state of the application.</param>
        public MonkeyIslandGamesList(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            //var uri = sitemapManager.GetUri<RestList>(applicationContext);
            //_formUri = uri?.SetFragment("myListForm")?.ToString();
        }

        /// <summary>
        /// Retrieves a collection of options.
        /// </summary>
        public override IEnumerable<RestApiOption> GetOptions(Request request, Game row)
        {
            yield return new RestApiOptionHeader(request)
            {
                Label = "webexpress.webapp:header.setting.label"
            };

            yield return new RestApiOptionEdit(request)
            {
                Uri = _formUri
            };

            yield return new RestApiOptionSeperator(request);
            yield return new RestApiOptionDelete(request);
        }

        /// <summary>
        /// Retrieves a collection of games based on the specified filter.
        /// </summary>
        public override IEnumerable<Game> GetData(string filter, Request request)
        {
            if (string.IsNullOrEmpty(filter) || filter == "null")
            {
                return ViewModel.MonkeyIslandGames;
            }

            return ViewModel.MonkeyIslandGames
                .Where(x => x.Name.Contains(filter));
        }
    }
}