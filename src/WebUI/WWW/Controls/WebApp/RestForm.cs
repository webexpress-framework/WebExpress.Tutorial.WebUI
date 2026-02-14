using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the rest form control for the tutorial.    
    /// </summary>    
    [Title("RestForm")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestForm : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public RestForm(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `REST form` is used to capture user input in a structured way, validate it, and exchange it with the server via a REST API. Instead of transmitting data through a traditional POST submit as in classic web applications, the form communicates directly with the corresponding endpoint and operates entirely event‑driven. It combines various input elements such as text fields, dropdowns, or buttons, ensuring an intuitive and consistent user experience. Input is validated on the client side so that only correct and complete data is processed. All operations for transmitting, validating, creating, modifying, and updating records (CRUD) are handled through a REST route. The data is sent as a JSON payload, and the server’s responses are evaluated in real time to update the UI dynamically. This results in a modern, reactive form behavior without traditional page reloads.";

            Stage.Control = new ControlRestForm("myform")
                .Add(new ControlFormItemInputText("regards")
                {
                    Required = true,
                    Label = "Greetings",
                    Icon = new IconFont(),
                    Help = "This is the associated help text."
                }
                    .Initialize(args => args.Value.Text = "Hello World!"))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlRestForm(""myform"")
                .Add(new ControlFormItemInputText(""regards"")
                {
                    Required = true,
                    Label = ""Greetings"",
                    Icon = new IconFont(),
                    Help = ""This is the associated help text.""
                }
                    .Initialize(args => args.Value.Text = ""Hello World!""))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";
        }
    }
}
