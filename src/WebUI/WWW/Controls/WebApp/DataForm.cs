using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
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
    [WebIcon<IconControlForm>]
    [Title("DataForm")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataForm : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public DataForm(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `REST form` is used to capture user input in a structured way, validate it, and exchange it with the server via a REST API. Instead of transmitting data through a traditional POST submit as in classic web applications, the form communicates directly with the corresponding endpoint and operates entirely event‑driven. It combines various input elements such as text fields, dropdowns, or buttons, ensuring an intuitive and consistent user experience. Input is validated on the client side so that only correct and complete data is processed. All operations for transmitting, validating, creating, modifying, and updating records (CRUD) are handled through a REST route. The data is sent as a JSON payload, and the server’s responses are evaluated in real time to update the UI dynamically. This results in a modern, reactive form behavior without traditional page reloads. In this example, the form loads and saves the greeting through a REST endpoint, which confirms every save with a notification.";

            Stage.Control = new ControlDataForm("myform")
                .Service("data", svc => svc
                    .Uri(_ => sitemapManager.GetUri<DataFormGreeting>(pageContext)))
                .Add(new ControlFormItemInputText("regards")
                {
                    Required = _ => true,
                    Label = _ => "Greetings",
                    Icon = _ => new IconFont(),
                    Help = _ => "This is the associated help text."
                }
                    .Initialize(args => args.Value.Text = "Hello World!"))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlDataForm(""myform"")
                .Service(""data"", svc => svc
                    .Uri(_ => sitemapManager.GetUri<DataFormGreeting>(pageContext)))
                .Add(new ControlFormItemInputText(""regards"")
                {
                    Required = _ => true,
                    Label = _ => ""Greetings"",
                    Icon = _ => new IconFont(),
                    Help = _ => ""This is the associated help text.""
                }
                    .Initialize(args => args.Value.Text = ""Hello World!""))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "SuccessAction",
                "The `SuccessAction` property decides what the form does once the server accepted it. By default the form stays where it is, and a dialog around it closes. `Reload` reloads the page, so everything it shows reflects the saved record; `FollowUri` navigates to the `uri` of the JSON answer, such as the page of a record that was just created. The action runs a tick after the form's own success handling, so the dialog is closed and the notification shown first. This form reloads the page after a save.",
                "SuccessAction = _ => TypeRestFormSuccess.Reload",
                new ControlDataForm("myReloadForm")
                {
                    SuccessAction = _ => TypeRestFormSuccess.Reload
                }
                    .Service("data", svc => svc
                        .Uri(_ => sitemapManager.GetUri<DataFormGreeting>(pageContext)))
                    .Add(new ControlFormItemInputText("regards")
                    {
                        Required = _ => true,
                        Label = _ => "Greetings",
                        Icon = _ => new IconFont()
                    }
                        .Initialize(args => args.Value.Text = "Hello World!"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
