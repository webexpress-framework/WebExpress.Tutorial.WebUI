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
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island characters.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTable : RestApiTable<Character>
    {
        private readonly IUri _formEditUri;
        private readonly IUri _formDeleteUri;

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
            _formEditUri = sitemapManager.GetUri<Characters.Edit>(applicationContext); ;
            _formDeleteUri = sitemapManager.GetUri<Characters.Delete>(applicationContext);
        }

        /// <summary>
        /// Retrieves a collection of options.
        /// </summary>
        /// <param name="request">
        /// The request object containing the criteria for retrieving options. Cannot be null.
        /// </param>
        /// <param name="row">
        /// The row object for which options are being retrieved. Cannot be null.
        /// </param>
        public override IEnumerable<RestApiOption> GetOptions(IRequest request, Character row)
        {
            yield return new RestApiOptionHeader(request)
            {
                Label = "webexpress.webapp:header.setting.label"
            };

            yield return new RestApiOptionEdit(request)
            {
                Uri = _formEditUri?.SetParameters
                (
                    new CharacterIdParameter(row.Id.ToString())
                )?
                    .ToString(),
                Modal = new ModalTarget("myTableFormEdit", TypeModalSize.ExtraLarge)
            };

            yield return new RestApiOptionSeperator(request);
            yield return new RestApiOptionDelete(request)
            {
                Uri = _formDeleteUri?.SetParameters
                (
                    new CharacterIdParameter(row.Id.ToString())
                )?
                    .ToString(),
                Modal = new ModalTarget("myTableFormEdit")
            };
        }

        /// <summary>
        /// Retrieves a collection of index items that match the specified filter 
        /// and request parameters.
        /// </summary>
        /// <param name="filter">
        /// A string used to filter the results. The format and supported values 
        /// depend on the implementation. Can be null or empty to indicate no filtering.
        /// </param>
        /// <param name="request">
        /// An object containing additional parameters that influence the data 
        /// retrieval operation. Cannot be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of index items of type TIndexItem that 
        /// satisfy the filter and request criteria. The collection may be 
        /// empty if no items match.
        /// </returns>
        public override IEnumerable<Character> GetData(string filter, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return ViewModel.MonkeyIslandCharacters;
            }

            return ViewModel.MonkeyIslandCharacters
                .Where
                (
                    x => x.Name.Contains(filter) ||
                    x.Description.Contains(filter) ||
                    x.AppearsIn.Contains(filter)
                );
        }
    }
}
