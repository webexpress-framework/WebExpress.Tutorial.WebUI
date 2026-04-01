using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island characters.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableSelection : RestApiTable<Character>
    {
        private readonly IUri _selectionUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandCharacterTableSelection(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            _selectionUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(applicationContext);
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
                Id = "locations",
                Name = "Locations",
                Label = "Locations",
                Visible = true,
                Template = new RestApiTableColumnTemplateRestSelection(true)
                {
                    Uri = _selectionUri
                }
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
                            Content = "Name"
                        },
                        new RestApiTableCell()
                        {
                            Content = string.Join(";", ViewModel.GetMonkeyIslandLocations().Take(1).Select(x => x.Id))
                        }
                    },
                    Image = (x.Icon is ImageIcon)
                        ? x.Icon.Uri.ToString()
                        : null
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
    }
}