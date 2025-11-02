using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Modal
{
    /// <summary>    
    /// Represents the modal remote form control for the tutorial.    
    /// </summary>    
    [Title("ModalRemoteForm")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ModalRemoteForm : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the modal remote form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public ModalRemoteForm(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"The `ModalRemoteForm` is a specialized modal dialog that allows a form to be dynamically loaded from an external source and displayed within the modal. This approach enables seamless interaction with remote services or pages without requiring the user to navigate away from the current view. Instead of embedding the form directly into the main application, it is retrieved at runtime and integrated into the modal, providing flexibility and improved user experience.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myModal"
                },
                new ControlModalRemoteForm("myModal")
                {
                    Header = "My modal",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Form.Index>(pageContext.ApplicationContext),
                    Selector = "conformationform"
                }
            ];

            Stage.DarkControls =
            [
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myDarkModal"
                },
                new ControlModalRemoteForm("myDarkModal")
                {
                    Header = "My modal",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Form.Index>(pageContext.ApplicationContext),
                    Selector = "#conformationform"
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
                Uri = sitemapManager.GetUri<Form.Index>(pageContext.ApplicationContext),
                Selector = ""conformationform""
            }";

            Stage.AddProperty
            (
               "Uri",
                @"The `Uri` property in the context of ModalPage defines the external source from which content is retrieved. It enables dynamically loading and displaying information from another page within a modal dialog.",
                "When attempting to load remote content from a different domain, the browser may block the request due to security restrictions. This occurs if the target server does not explicitly allow cross-origin access through CORS (Cross-Origin Resource Sharing) headers. To prevent this issue, the server must include Access-Control-Allow-Origin: * or specify permitted domains in the response headers. Without proper CORS configuration, the content cannot be retrieved, ensuring security against unauthorized data access.",
                "Uri = sitemapManager.GetUri<Info>(pageContext.ApplicationContext)",
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myModalUri"
                },
                new ControlModalRemoteForm("myModalUri")
                {
                    Header = "Header",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Form.Index>(pageContext.ApplicationContext),
                    Selector = "conformationform"
                }
            );

            Stage.AddProperty
            (
               "Selector",
                @"The Selector property defines the element or identifier used to locate and load content into the modal. It allows specifying a target source, such as a CSS selector or element reference, from which data will be retrieved and displayed dynamically within the modal dialog.",
                "Selector = \"conformationform\"",
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "conformationform"
                },
                new ControlModalRemoteForm("myModalSelector")
                {
                    Header = "Header",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Form.Index>(pageContext.ApplicationContext),
                    Selector = "conformationform"
                }
            );
        }
    }
}
