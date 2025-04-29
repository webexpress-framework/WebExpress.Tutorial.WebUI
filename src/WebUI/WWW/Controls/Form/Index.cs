using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the selection control for the tutorial.    
    /// </summary>    
    [Title("Form")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    public sealed class Index : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the selection control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Index(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"A `Form` control is used to structure, validate, and submit user input to a server. It organizes various fields such as text boxes, dropdowns, and buttons, ensuring a seamless and user-friendly experience. Additionally, it incorporates validation mechanisms to maintain data accuracy and prevent errors before sending the information for processing.";

            Stage.Control = new ControlForm()
            {
            }.AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
            {
            }.AddPrimaryButton(new ControlFormItemButtonSubmit());";
        }
    }
}
