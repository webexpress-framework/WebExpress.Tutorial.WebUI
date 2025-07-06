using System.Collections.Generic;
using System.Linq;
using WebExpress.Toutorial.WebUI.Model;
using WebExpress.Toutorial.WebUI.WWW.Controls;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebSitemap;


namespace WebExpress.Toutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island characters.
    /// </summary>
    [Title("Monkey Island characters")]
    [Method(CrudMethod.GET)]
    [Method(CrudMethod.DELETE)]
    [Method(CrudMethod.PUT)]
    public sealed class MonkeyIslandCharacters : RestApiCrudTable<Character>
    {
        private readonly string _formUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandCharacters(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            var uri = sitemapManager.GetUri<RestTable>(applicationContext);
            _formUri = uri?.SetFragment("myTableForm")?.ToString();

            Data = ViewModel.MonkeyIslandCharacters;
        }

        /// <summary>
        /// Retrieves a collection of options.
        /// </summary>
        /// <param name="request">The request object containing the criteria for retrieving options. Cannot be null.</param>
        /// <param name="row">The row object for which options are being retrieved. Cannot be null.</param>
        public override IEnumerable<RestApiCrudTableRowOption> GetOptions(Request request, Character row)
        {
            yield return new RestApiCrudTableRowOptionHeader(request)
            {
                Label = "webexpress.webapp:header.setting.label"
            };

            yield return new RestApiCrudTableRowOptionEdit(request)
            {
                Uri = _formUri
            };

            yield return new RestApiCrudTableRowOptionSeperator(request);
            yield return new RestApiCrudTableRowOptionDelete(request);
        }

        /// <summary>
        /// Retrieves a collection of objects based on the specified WQL statement and request.
        /// </summary>
        /// <param name="filter">The filter used to query the data. This parameter defines the filtering and selection criteria.</param>
        /// <param name="request">The request context containing additional information for the operation.</param>
        /// <returns>An enumerable containing the objects that match the
        /// query criteria.</returns>
        public override IEnumerable<Character> GetData(string filter, Request request)
        {
            if (filter == null || filter == "null")
            {
                return Data;
            }

            return Data
                .Where
                (
                    x => x.Name.Contains(filter) ||
                    x.Description.Contains(filter) ||
                    x.AppearsIn.Contains(filter)
                );
        }

        /// <summary>
        /// Performs validation before updating data.
        /// </summary>
        /// <param name="item"> The item containing the updated data.</param>
        /// <param name="request">The HTTP request containing input data and parameters.</param>
        /// <returns>
        /// A <see cref="RestApiValidationResult"/> containing any validation errors 
        /// encountered during the update process. If the operation completes successfully, 
        /// the result will contain no errors.
        /// </returns>
        public override RestApiValidationResult ValidateUpdateData(Character item, Request request)
        {
            return new RestApiValidator(request)
                .Require(nameof(Character.Name))
                .MinLength(nameof(Character.Name), 3)
                .Result;
        }

        /// <summary>
        /// Updates the data record identified by the specified ID.
        /// </summary>
        /// <param name="item"> The item containing the updated data.</param>
        /// <param name="request">The HTTP request containing the update parameters.</param>
        public override void UpdateData(Character item, Request request)
        {
            item.Name = request.GetParameter(nameof(Character.Name))?.Value;
        }

        /// <summary>
        /// Deletes data.
        /// </summary>
        /// <param name="id">The id of the data to delete.</param>
        /// <param name="request">The request.</param>
        public override void DeleteData(string id, Request request)
        {
            ViewModel.MonkeyIslandCharacters.RemoveAll(x => x.Id.ToString() == id);
        }
    }
}
