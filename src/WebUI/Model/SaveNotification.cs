using System.Net;
using WebExpress.WebCore;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Confirms a save of the tutorial's REST endpoints with a popup notification, so a store
    /// that happens without a page reload still gets the same visible answer as a submitted form.
    /// </summary>
    /// <remarks>
    /// The notification is bound to the session of the saving visitor: the tutorial is shared,
    /// and another visitor has nothing to learn from somebody else's save. It expires on its own
    /// because a confirmation that waits to be dismissed would pile up with every save.
    /// </remarks>
    internal static class SaveNotification
    {
        private const int Durability = 5000;

        /// <summary>
        /// Announces that the named record has been saved.
        /// </summary>
        /// <param name="request">The request that carried the save.</param>
        /// <param name="name">The name of the saved record, shown to the visitor.</param>
        public static void Notify(IRequest request, string name)
        {
            if (request?.Session is null)
            {
                return;
            }

            // the message is rendered as markup, and the name may come straight from the visitor
            var message = string.IsNullOrWhiteSpace(name)
                ? "Your changes have been saved."
                : $"<b>{WebUtility.HtmlEncode(name)}</b> has been saved.";

            WebEx.ComponentHub?
                .GetComponentManager<NotificationManager>()?
                .AddNotification
                (
                    request.ApplicationContext,
                    request,
                    message,
                    Durability,
                    "Saved",
                    type: TypeNotification.Success
                );
        }
    }
}
