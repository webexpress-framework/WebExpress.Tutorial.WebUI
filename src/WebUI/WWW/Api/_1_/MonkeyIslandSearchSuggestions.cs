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

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API that supplies the suggestions of a search box: the Monkey Island
    /// characters matching the typed term, each one linking to its own page.
    /// </summary>
    /// <remarks>
    /// The suggestion search consumes the dropdown contract, so this endpoint derives from
    /// <see cref="RestApiDropdown{TIndexItem}"/> rather than from a search specific base: the
    /// term arrives in q, the entry cap in l, and the answer is the items envelope.
    /// </remarks>
    [Title("Monkey Island search suggestions")]
    public sealed class MonkeyIslandSearchSuggestions : RestApiDropdown<Character>
    {
        private readonly IUri _characterUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandSearchSuggestions(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            _characterUri = sitemapManager.GetUri<Characters.Index>(applicationContext);
        }

        /// <summary>
        /// Retrieves the suggestions that match the specified query criteria.
        /// </summary>
        /// <param name="query">
        /// An object containing the query parameters used to filter and select index items.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// An enumerable collection of RestApiDropdownItem objects that match the specified
        /// query and context. The collection may be empty if no items are found.
        /// </returns>
        protected override IEnumerable<RestApiDropdownItem> RetrieveItems(IQuery<Character> query, IQueryContext context, IRequest request)
        {
            // the projection is run in memory rather than in the query, because building the
            // link target is not something the expression tree can carry
            var items = query.Apply(ViewModel.MonkeyIslandCharacters.AsQueryable())
                .AsEnumerable()
                .Select(x => new RestApiDropdownItem()
                {
                    Id = x.Id,
                    Text = x.Name,
                    // a suggestion is a link, so every entry carries the page it opens;
                    // an entry without one would only adopt its label as the term
                    Uri = _characterUri?.BindParameters(new CharacterIdParameter(x.Id.ToString()))?.ToString()
                });

            // lead the suggestions with a non-clickable caption so the tutorial shows how an
            // endpoint groups what it offers
            return new RestApiDropdownItem[] { new RestApiDropdownItemHeader("Crew") }
                .Concat(items);
        }

        /// <summary>
        /// Applies the specified filter criteria to the given query object.
        /// </summary>
        /// <param name="filter">
        /// A string representing the term the user typed. It is empty on the first focus,
        /// which is the cue to offer the default entries rather than nothing.
        /// </param>
        /// <param name="query">
        /// The query object to which the filter will be applied.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// A query representing the filtered set of items that match the criteria defined by
        /// the filter statement.
        /// </returns>
        protected override IQuery<Character> Filter(string filter, IQuery<Character> query, IRequest request)
        {
            if (string.IsNullOrWhiteSpace(filter) || filter == "null")
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
