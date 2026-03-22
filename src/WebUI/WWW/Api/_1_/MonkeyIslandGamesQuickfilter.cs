using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API quickfilter for managing and retrieving data about Monkey Island games.
    /// </summary>
    public sealed class MonkeyIslandGamesQuickfilter : RestApiQuickfilter<QuickfilterGame>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandGamesQuickfilter()
        {
        }

        /// <summary>
        /// Retrieves a queryable collection of index items.
        /// </summary>
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
        protected override IEnumerable<QuickfilterGame> Retrieve(IQueryContext context, IRequest request)
        {
            return ViewModel.MonkeyIslandQuickfilterGames;
        }
    }
}