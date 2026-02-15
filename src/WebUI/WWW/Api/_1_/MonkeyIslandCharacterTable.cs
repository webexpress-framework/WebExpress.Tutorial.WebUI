using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebParamter;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island characters.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTable : RestApiTable<Character>
    {
        private readonly IUri _formEditUri;
        private readonly IUri _formDeleteUri;
        private readonly IUri _restApi;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandCharacterTable(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            _formEditUri = sitemapManager.GetUri<Characters.Edit>(applicationContext);
            _formDeleteUri = sitemapManager.GetUri<Characters.Delete>(applicationContext);
            _restApi = sitemapManager.GetUri<MonkeyIslandCharacter>(applicationContext);
        }

        /// <summary>
        /// Gets the REST API endpoint URI associated with the specified request and index item.
        /// </summary>
        /// <param name="row">
        /// The index item that provides context for determining the appropriate REST API endpoint.
        /// </param>
        /// <param name="request">
        /// The request for which to retrieve the REST API endpoint.
        /// </param>
        /// <returns>
        /// An <see cref="IUri"/> representing the REST API endpoint for the given request 
        /// and index item, or null if no endpoint is available.
        /// </returns>
        public override IUri GetRestApiForInlineEdit(Character row, IRequest request)
        {
            return _restApi?.Add(new UriQuery("id", row.Id.ToString()));
        }

        /// <summary>
        /// Retrieves a collection of options.
        /// </summary>
        /// <param name="row">
        /// The row object for which options are being retrieved. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request object containing the criteria for retrieving options. Cannot be null.
        /// </param>
        public override IEnumerable<RestApiOption> GetOptions(Character row, IRequest request)
        {
            var restEditApi = _formEditUri?.SetParameters
            (
                new CharacterIdParameter(row.Id.ToString())
            );

            var restDeleteApi = _formDeleteUri?.SetParameters
            (
                new CharacterIdParameter(row.Id.ToString())
            );

            yield return new RestApiOptionHeader(request)
            {
                Text = "webexpress.webapp:header.setting.label"
            };

            yield return new RestApiOptionEdit(request)
            {
                PrimaryAction = new ActionModal
                (
                    "myTableFormEdit",
                    restEditApi,
                    TypeModalSize.ExtraLarge
                )
            };

            yield return new RestApiOptionSeperator(request);
            yield return new RestApiOptionDelete(request)
            {
                Uri = restDeleteApi?.ToString(),
                PrimaryAction = new ActionModal("myTableFormEdit")
            };
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
        protected override IQueryable<Character> Retrieve(IQuery<Character> query, IQueryContext context, IRequest request)
        {
            return query.Apply(ViewModel.MonkeyIslandCharacters.AsQueryable());
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
        protected override void Filter(string filter, IQuery<Character> query, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return;
            }

            query.WhereContainsIgnoreCase
            (
                x => x.Name, filter
            );
        }
    }
}