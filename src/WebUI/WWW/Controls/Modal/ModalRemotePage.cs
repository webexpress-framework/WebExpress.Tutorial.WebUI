using WebApp.WWW;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls.Modal
{
    /// <summary>    
    /// Represents the modal remote page control for the tutorial.    
    /// </summary>    
    [Title("ModalRemotePage")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    public sealed class ModalRemotePage : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the modal remote page control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public ModalRemotePage(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"A modal remote page dynamically retrieves and displays content from another page within a modal dialog. This allows users to interact with external or additional information without navigating away from the current view. Modal pages are ideal for loading details, or dynamic content, providing a seamless and focused user experience while maintaining the main application's context.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myModal"
                },
                new ControlModalRemotePage("myModal")
                {
                    Header = "My modal",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)
                }
            ];

            Stage.Code = @"
            new ControlButton()
            {
                Text = ""Activator"",
                Icon = new IconPenToSquare(),
                BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                Modal = ""myModal""
            },
            new ControlModalPage(""myModal"")
            {
                Header = ""My modal"",
                Size = TypeModalSize.ExtraLarge,
                Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)
            }";

            Stage.AddProperty
            (
               "Uri",
                @"The `Uri` property in the context of ModalPage defines the external source from which content is retrieved. It enables dynamically loading and displaying information from another page within a modal dialog.",
                "When loading remote content from a different domain, browsers may reject the request due to security restrictions if the target server does not provide the appropriate CORS (Cross-Origin Resource Sharing) headers. Specifically, the server must return Access-Control-Allow-Origin: * or explicitly allow the requesting domain in its response headers. Without this configuration, the browser blocks the request to protect against potential security vulnerabilities. If external content needs to be integrated, ensure that the remote server is properly set up to permit cross-origin access.",
                "Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)",
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myModalUri"
                },
                new ControlModalRemotePage("myModalUri")
                {
                    Header = "Header",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)
                }
            );

            Stage.AddProperty
            (
               "Selector",
                @"The Selector property defines the element or identifier used to locate and load content into the modal. It allows specifying a target source, such as a CSS selector or element reference, from which data will be retrieved and displayed dynamically within the modal dialog.",
                "Selector = \"#wx-content\"",
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myModalSelector"
                },
                new ControlModalRemotePage("myModalSelector")
                {
                    Header = "Header",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext),
                    Selector = "#wx-content"
                }
            );
        }
    }
}
