using System.Net;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the e-mail input control for the tutorial.
    /// </summary>
    [WebIcon<IconEnvelope>]
    [Title("Email")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Email : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the e-mail control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public Email(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"An `Email` control takes an e-mail address. The browser offers the addresses it knows and checks the notation while the user types; the server applies the same rule and passes the address to the page with its domain in lower case.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputEmail { Label = _ => "E-mail", Icon = _ => new IconEnvelope() }
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, x.Context.Request, $"Value: {WebUtility.HtmlEncode(x.Value.Text)}", durability: 5000)))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputEmail { Label = _ => ""E-mail"", Icon = _ => new IconEnvelope() }
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, x.Context.Request, $""Value: {WebUtility.HtmlEncode(x.Value.Text)}"", durability: 5000)))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Domains",
                "The `Domains` property accepts addresses of the given domains and their sub-domains only, as a company form might ask for a work address.",
                "Domains = _ => [\"melee-island.example\"]",
                new ControlForm()
                    .Add(new ControlFormItemInputEmail { Label = _ => "Work e-mail", Domains = _ => ["melee-island.example"] })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property sets the text shown while the field is empty.",
                "Placeholder = _ => \"name@example.com\"",
                new ControlForm(null, new ControlFormItemInputEmail(null) { Placeholder = _ => "name@example.com" })
            );

            Stage.AddProperty
            (
                "Required",
                "The `Required` property makes the address mandatory; an empty field is refused with a message naming the field.",
                "Required = _ => true",
                new ControlForm()
                    .Add(new ControlFormItemInputEmail { Label = _ => "E-mail", Required = _ => true })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
