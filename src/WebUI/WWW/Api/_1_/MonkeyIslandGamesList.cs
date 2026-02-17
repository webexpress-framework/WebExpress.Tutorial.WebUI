using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API list for managing and retrieving data about Monkey Island games.
    /// </summary>
    [Title("Monkey Island Games")]
    public sealed class MonkeyIslandGamesList : RestApiList<Game>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager used to retrieve URIs for the application context.</param>
        /// <param name="applicationContext">The application context containing the current state of the application.</param>
        public MonkeyIslandGamesList(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
        }

        /// <summary>
        /// Returns a collection of REST API options available for the specified 
        /// game and request context.
        /// </summary>
        /// <param name="row">
        /// The game entity for which to retrieve available REST API options.
        /// </param>
        /// <param name="request">
        /// The current request context that influences which options are generated.
        /// </param>
        /// <returns>
        /// An enumerable collection representing the available actions for the
        /// specified game and request. The collection may include options such as 
        /// editing, deleting, or modifying settings.
        /// </returns>
        public override IEnumerable<RestApiOption> GetOptions(Game row, IRequest request)
        {
            yield return new RestApiOptionHeader(request)
            {
                Text = "webexpress.webapp:header.setting.label"
            };

            yield return new RestApiOptionEdit(request)
            {
                PrimaryAction = new ActionModal
                (
                    "modal",
                    TypeModalSize.ExtraLarge
                )
            };

            yield return new RestApiOptionSeperator(request);
            yield return new RestApiOptionDelete(request);
        }

        /// <summary>
        /// Retrieves the secondary action associated with the specified game 
        /// item, using the provided request context.
        /// </summary>
        /// <param name="item">
        /// The game item for which to retrieve the secondary action. 
        /// Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request context that may influence the retrieval of 
        /// the secondary action. Cannot be null.
        /// </param>
        /// <returns>
        /// An <see cref="IAction"/> representing the secondary action 
        /// for the specified game item, or null if no secondary 
        /// action is available.
        /// </returns>
        public override IAction GetSecondaryAction(Game item, IRequest request)
        {
            return new ActionModal
            (
                "modal",
                TypeModalSize.ExtraLarge
            );
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
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable{TIndexItem}"/> representing the filtered set of index items. The 
        /// result may be empty if no items match the query.
        /// </returns>
        protected override IEnumerable<Game> Retrieve(IQuery<Game> query, IQueryContext context, IRequest request)
        {
            return query.Apply(ViewModel.MonkeyIslandGames.AsQueryable());
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
        protected override void Filter(string filter, IQuery<Game> query, IRequest request)
        {
            if (string.IsNullOrEmpty(filter) || filter == "null")
            {
                return;
            }

            query.Where(x => x.Name.Contains(filter));
        }
    }
}