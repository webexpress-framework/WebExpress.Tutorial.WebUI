using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API for managing and retrieving data about 
    /// a Monkey Island character.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacter : RestApiCrud<Character>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandCharacter()
        {
            Data = ViewModel.MonkeyIslandCharacters;
        }

        /// <summary>
        /// Validate the data for create or update operations. When creating, existingItem will 
        /// be null and proposedItem contains the values to create. When updating, existingItem 
        /// is the currently persisted entity and proposedItem contains the incoming values to 
        /// validate.
        /// </summary>
        /// <param name="existingItem">
        /// The currently persisted item (null for create).
        /// </param>
        /// <param name="payload">
        /// The dynamic payload containing updated fields.
        /// </param>
        /// <param name="request">
        /// The HTTP request providing additional context.
        /// </param>
        /// <returns>
        /// An IRestApiValidationResult indicating validation success or errors.
        /// </returns>
        public override IRestApiValidationResult ValidateData(Character existingItem, RestApiCrudFormData payload, Request request)
        {
            return new RestApiValidationResult();
        }

        /// <summary>
        /// Updates the data record.
        /// </summary>
        /// <param name="existingItem">
        /// The currently persisted item.
        /// </param>
        /// <param name="payload">
        /// The dynamic payload containing updated fields.
        /// </param>
        /// <param name="request">
        /// The HTTP request providing additional context.
        /// </param>
        public override IRestApiCrudResultUpdate UpdateData(Character existingItem, RestApiCrudFormData payload, Request request)
        {
            existingItem.Name = payload[nameof(Character.Name)]?.ToString();

            return new RestApiCrudResultUpdate()
            {
                Message = "Updated"
            };
        }

        /// <summary>
        /// Deletes the specified resource.
        /// </summary>
        /// <param name="existingItem">
        /// The currently persisted item that is to be deleted.
        /// </param>
        /// <param name="request">
        /// The HTTP request providing additional context for the delete operation.
        /// </param>
        /// <returns>
        /// A result object containing information about the delete operation.
        /// </returns>
        public override IRestApiCrudResultDelete DeleteData(Character existingItem, Request request)
        {
            return new RestApiCrudResultDelete()
            {
                Message = "Deleted"
            };
        }
    }
}
