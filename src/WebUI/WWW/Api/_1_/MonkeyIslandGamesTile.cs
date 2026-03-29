using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebIndex.Queries;
using WebExpress.WebIndex.Wql;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API tile for managing and retrieving data about Monkey Island games.
    /// </summary>
    [Title("Monkey Island Games")]
    public sealed class MonkeyIslandGamesTile : RestApiTile<Game>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager used to retrieve URIs for the application context.</param>
        /// <param name="applicationContext">The application context containing the current state of the application.</param>
        public MonkeyIslandGamesTile(ISitemapManager sitemapManager, IApplicationContext applicationContext)
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
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable{TIndexItem}"/> representing the filtered set of index items. The 
        /// result may be empty if no items match the query.
        /// </returns>
        protected override IEnumerable<RestApiTileItem> RetrieveItems(IQuery<Game> query, IQueryContext context, IRequest request)
        {
            return query.Apply(ViewModel.MonkeyIslandGames.AsQueryable())
                .Select(x => new RestApiTileItem()
                {
                    Id = x.Id.ToString(),
                    Title = x.Name,
                    Text = x.Description,
                    SecondaryAction = GetSecondaryAction(request).ToJson()
                });
        }

        /// <summary>
        /// Applies filtering criteria to the specified query based on the provided WQL statement.
        /// </summary>
        /// <param name="wqlStatement">
        /// The WQL statement that defines the filtering conditions to apply to the query. Cannot 
        /// be null.
        /// </param>
        /// <param name="query">
        /// The query object to which the filtering criteria will be applied. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context for resolving
        /// the appropriate REST API URI.
        /// </param>
        /// <returns>
        /// A query representing the filtered set of items that match the criteria defined by 
        /// the WQL statement.
        /// </returns>
        protected override IQuery<Game> Filter(IWqlStatement<Game> wqlStatement, IQuery<Game> query, IRequest request)
        {
            if (wqlStatement is null || wqlStatement.HasErrors)
            {
                return query;
            }

            return wqlStatement.ToQuery();
        }

        /// <summary>
        /// Applies the specified filter criteria to the given query object.
        /// </summary>
        /// <param name="search">
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
        /// <returns>
        /// A query representing the filtered set of items that match the criteria defined by 
        /// the filter statement.
        /// </returns>
        protected override IQuery<Game> Filter(string search, IQuery<Game> query, IRequest request)
        {
            if (string.IsNullOrEmpty(search) || search == "null")
            {
                return query;
            }

            return query.Where(x => x.Name.Contains(search));
        }

        /// <summary>
        /// Applies the specified filter criteria to the given query object.
        /// </summary>
        /// <param name="filters">
        /// A collection of quickfilter identifiers that should be applied in addition to the WQL criteria.
        /// </param>
        /// <param name="query">
        /// The query object to which the filter will be applied.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context for resolving
        /// the appropriate REST API URI.
        /// </param>
        /// <returns>
        /// A query representing the filtered set of items that match the criteria defined by 
        /// the filter statement.
        /// </returns>
        protected override IQuery<Game> Filter(IEnumerable<string> filters, IQuery<Game> query, IRequest request)
        {
            foreach (var filter in filters)
            {
                var qf = ViewModel.MonkeyIslandQuickfilterGames
                    .Where(x => x.Id.ToString().Equals(filter, StringComparison.CurrentCultureIgnoreCase));

                query = query.Where(x => qf.Any(f => f.Predicate(x)));
            }

            return query;
        }

        /// <summary>
        /// Retrieves the secondary action associated with the specified game 
        /// item, using the provided request context.
        /// </summary>
        /// <param name="request">
        /// The request context that may influence the retrieval of 
        /// the secondary action. Cannot be null.
        /// </param>
        /// <returns>
        /// An <see cref="IAction"/> representing the secondary action 
        /// for the specified game item, or null if no secondary 
        /// action is available.
        /// </returns>
        private IAction GetSecondaryAction(IRequest request)
        {
            return new ActionModal
            (
                "modal",
                TypeModalSize.ExtraLarge
            );
        }
    }
}