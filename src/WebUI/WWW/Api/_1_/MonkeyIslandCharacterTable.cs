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
using WebExpress.WebUI.WebIcon;

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
        /// Retrieves the collection of columns available for the specified 
        /// REST API request.
        /// </summary>
        /// <param name="request">
        /// The request for which to retrieve the available table columns.
        /// </param>
        /// <returns>
        /// An enumerable collection of columns describing the structure of 
        /// the data returned by the REST API for the specified request.
        /// </returns>
        protected override IEnumerable<RestApiTableColumn> RetrieveColums(IRequest request)
        {
            yield return new RestApiTableColumn()
            {
                Id = "name",
                Name = "Name",
                Label = "Name",
                Visible = true
            };

            yield return new RestApiTableColumn()
            {
                Id = "description",
                Name = "Description",
                Label = "Description",
                Visible = true
            };

            yield return new RestApiTableColumn()
            {
                Id = "appearsin",
                Name = "AppearsIn",
                Label = "Appears in",
                Visible = true,
                Template = new RestApiTableColumnTemplateTag(true)
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
        /// <param name="columns">
        /// The collection of columns available for the specified REST API request.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// An enumerable collection of table rows that satisfy the query and 
        /// context. The collection may be empty if no rows match the criteria.
        /// </returns>
        protected override IQueryable<RestApiTableRow> RetrieveRows(IQuery<Character> query, IQueryContext context, IEnumerable<RestApiTableColumn> columns, IRequest request)
        {
            return query.Apply(ViewModel.MonkeyIslandCharacters.AsQueryable())
                .Select(x => new RestApiTableRow()
                {
                    Id = x.Id.ToString(),
                    Cells = new[]
                    {
                        new RestApiTableCell()
                        {
                            Content = x.Name
                        },
                        new RestApiTableCell()
                        {
                            Content = x.Description
                        },
                        new RestApiTableCell()
                        {
                            Content = string.Join(";", x.AppearsIn.Select(x => x.Name))
                        }
                    },
                    Options = GetOptions(x.Id.ToString(), request).Select(o => o.ToJson()),
                    Image = (x.Icon is ImageIcon)
                        ? x.Icon.Uri.ToString()
                        : null,
                    RestApi = GetRestApiForInlineEdit(x.Id.ToString(), request).ToString()
                });
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
        /// <returns>
        /// A query representing the filtered set of items that match the criteria defined by 
        /// the filter statement.
        /// </returns>
        protected override IQuery<Character> Filter(string filter, IQuery<Character> query, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return query;
            }

            return query.WhereContainsIgnoreCase
            (
                x => x.Name, filter
            );
        }

        /// <summary>
        /// Gets the REST API endpoint URI associated with the specified request and index item.
        /// </summary>
        /// <param name="id">
        /// The id that provides context for determining the appropriate REST API endpoint.
        /// </param>
        /// <param name="request">
        /// The request for which to retrieve the REST API endpoint.
        /// </param>
        /// <returns>
        /// An <see cref="IUri"/> representing the REST API endpoint for the given request 
        /// and index item, or null if no endpoint is available.
        /// </returns>
        private IUri GetRestApiForInlineEdit(string id, IRequest request)
        {
            return _restApi?.Add(new UriQuery("id", id));
        }

        /// <summary>
        /// Retrieves a collection of options.
        /// </summary>
        /// <param name="id">
        /// The id for which options are being retrieved. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request object containing the criteria for retrieving options. Cannot be null.
        /// </param>
        private IEnumerable<RestApiOption> GetOptions(string id, IRequest request)
        {
            var restEditApi = _formEditUri?.BindParameters
            (
                new CharacterIdParameter(id)
            );

            var restDeleteApi = _formDeleteUri?.BindParameters
            (
                new CharacterIdParameter(id)
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

            yield return new RestApiOptionSeparator(request);
            yield return new RestApiOptionDelete(request)
            {
                Uri = restDeleteApi,
                PrimaryAction = new ActionModal("myTableFormEdit")
            };
        }
    }
}