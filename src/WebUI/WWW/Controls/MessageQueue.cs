using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the message queue control for the tutorial.
    /// </summary>
    [Title("Message Queue")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class MessageQueue : PageControl
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
        public MessageQueue(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `MessageQueue` control is designed to display a queue (FIFO) of messages (such as notifications, events, or chat messages) possibly received dynamically, for example via a WebSocket connection. This control provides a structured, accessible, and customizable way to render and manage multiple messages within a web application.";

            Stage.Control = new ControlMessageQueue()
            {
                Uri = sitemapManager.GetUri<WebSocket.Message>(pageContext.ApplicationContext)
            };

            Stage.Code = @"
            new ControlMessageQueue()
            {
            }";

            Stage.DarkControls = null;
        }
    }
}