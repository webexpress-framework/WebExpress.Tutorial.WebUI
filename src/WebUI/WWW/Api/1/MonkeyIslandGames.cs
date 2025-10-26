using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WWW.Controls;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island games.
    /// </summary>
    [Title("Monkey Island Games")]
    [Method(CrudMethod.GET)]
    [Method(CrudMethod.DELETE)]
    [Method(CrudMethod.PUT)]
    public sealed class MonkeyIslandGames : RestApiCrudList<Game>
    {
        private readonly string _formUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager used to retrieve URIs for the application context.</param>
        /// <param name="applicationContext">The application context containing the current state of the application.</param>
        public MonkeyIslandGames(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            var uri = sitemapManager.GetUri<RestList>(applicationContext);
            _formUri = uri?.SetFragment("myListForm")?.ToString();

            Data = ViewModel.MonkeyIslandGames;
        }

        /// <summary>
        /// Retrieves a collection of options.
        /// </summary>
        public override IEnumerable<RestApiCrudOption> GetOptions(Request request, Game row)
        {
            yield return new RestApiCrudOptionHeader(request)
            {
                Label = "webexpress.webapp:header.setting.label"
            };

            yield return new RestApiCrudOptionEdit(request)
            {
                Uri = _formUri
            };

            yield return new RestApiCrudOptionSeperator(request);
            yield return new RestApiCrudOptionDelete(request);
        }

        /// <summary>
        /// Retrieves a collection of games based on the specified filter.
        /// </summary>
        public override IEnumerable<Game> GetData(string filter, Request request)
        {
            if (string.IsNullOrEmpty(filter) || filter == "null")
            {
                return Data;
            }

            return Data.Where(x => x.Name.Contains(filter));
        }

        /// <summary>
        /// Performs validation before updating game data.
        /// </summary>
        public override RestApiValidationResult ValidateUpdateData(Game item, Request request)
        {
            return new RestApiValidator(request)
                .Require(nameof(Game.Name))
                .MinLength(nameof(Game.Name), 3)
                .Require(nameof(Game.ReleaseYear))
                .Result;
        }

        /// <summary>
        /// Updates the game data record.
        /// </summary>
        public override void UpdateData(Game item, Request request)
        {
            item.Name = request.GetParameter(nameof(Game.Name))?.Value;
            item.Description = request.GetParameter(nameof(Game.Description))?.Value;
            item.ReleaseYear = int.TryParse(request.GetParameter(nameof(Game.ReleaseYear))?.Value, out var year) ? year : 0;
        }

        /// <summary>
        /// Deletes a game entry.
        /// </summary>
        public override void DeleteData(string id, Request request)
        {
            ViewModel.MonkeyIslandGames.RemoveAll(x => x.Id.ToString() == id);
        }
    }
}