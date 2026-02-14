using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the message queue control for the tutorial.
    /// </summary>
    [Title("Message Queue Status")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class MessageQueueStatus : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">
        /// The context of the page where the table control is used.
        /// </param>
        /// <param name="sitemapManager">
        /// The sitemap manager for managing site navigation.
        /// </param>
        public MessageQueueStatus(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `MessageQueueStatus` control visualizes the current WebSocket connection state used by the `WebExpress.WebApp` message queue. For each connected client, `WebExpress.WebApp` establishes a dedicated WebSocket through which messages can be exchanged in real time. The control provides a clear and accessible representation of whether this connection is open, closed, reconnecting, or experiencing errors, enabling users to monitor the communication channel that delivers queue messages.";

            Stage.Control = new ControlMessageQueueStatus();

            Stage.Code = @"new ControlMessageQueueStatus()";

            Stage.DarkControls = null;
        }
    }
}