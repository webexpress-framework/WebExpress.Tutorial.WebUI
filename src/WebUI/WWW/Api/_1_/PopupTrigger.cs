using System;
using System.Globalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Tutorial helper endpoint that manually triggers a popup notification.
    /// Called by the buttons on the
    /// <c>WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.PopupNotification</c>
    /// demo page so the WebSocket-based popup pipeline can be exercised in
    /// the browser.
    /// </summary>
    /// <remarks>
    /// Query parameters:
    /// <list type="bullet">
    ///   <item><c>type</c> - bootstrap alert class (e.g. <c>alert-success</c>).</item>
    ///   <item><c>heading</c> - alert heading text.</item>
    ///   <item><c>message</c> - alert body html.</item>
    ///   <item><c>durability</c> - lifetime in ms (-1 = indefinite).</item>
    ///   <item><c>scope</c> - <c>global</c> or <c>session</c>.</item>
    /// </list>
    /// </remarks>
    [Title("Popup Notification Trigger")]
    public sealed class PopupTrigger : IRestApi
    {
        private readonly IComponentHub _componentHub;
        private readonly IApplicationContext _applicationContext;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="applicationContext">The application context.</param>
        public PopupTrigger(IComponentHub componentHub, IApplicationContext applicationContext)
        {
            _componentHub = componentHub;
            _applicationContext = applicationContext;
        }

        /// <summary>
        /// Creates a popup notification with the parameters carried in the
        /// query string and lets the
        /// <c>PopupNotificationDispatcher</c> push it through the WebSocket.
        /// </summary>
        /// <param name="request">The request.</param>
        [Method(RequestMethod.GET)]
        public Response Trigger(Request request)
        {
            var manager = _componentHub?.GetComponentManager<NotificationManager>();
            if (manager == null)
            {
                return new ResponseOK();
            }

            string Parameter(string name)
            {
                return request.GetParameter(name)?.Value;
            }

            var rawType = Parameter("type") ?? "Light";
            if (!Enum.TryParse<TypeNotification>(rawType, true, out var type))
            {
                type = TypeNotification.Light;
            }

            var heading = Parameter("heading") ?? "Tutorial Notification";
            var message = Parameter("message") ?? "This popup was triggered through the WebSocket pipeline.";

            var durability = -1;
            var rawDurability = Parameter("durability");
            if (!string.IsNullOrEmpty(rawDurability))
            {
                int.TryParse(rawDurability, NumberStyles.Integer, CultureInfo.InvariantCulture, out durability);
            }

            var scope = Parameter("scope") ?? "global";

            if (string.Equals(scope, "session", StringComparison.OrdinalIgnoreCase))
            {
                manager.AddNotification
                (
                    _applicationContext,
                    request,
                    message,
                    durability,
                    heading,
                    icon: null,
                    type: type
                );
            }
            else
            {
                manager.AddNotification
                (
                    _applicationContext,
                    message,
                    durability,
                    heading,
                    icon: null,
                    type: type
                );
            }

            // Send the caller back to the originating tutorial page so the
            // popup that just arrived through the WebSocket pipeline is the
            // first thing they see.
            var returnUrl = Parameter("return");
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return new ResponseMovedTemporarily(new UriEndpoint(returnUrl));
            }

            return new ResponseOK
            {
                Content = "{\"status\":\"ok\"}"
            }.AddHeaderContentType("application/json");
        }
    }
}
