using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the host name input control for the tutorial.
    /// </summary>
    [WebIcon<IconGlobe>]
    [Title("Fqdn")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Fqdn : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the host name control is used.</param>
        public Fqdn(IPageContext pageContext)
        {
            Stage.Description = @"An `Fqdn` control takes a fully qualified domain name, such as `server01.example.com`. An internationalized name like `bücher.de` is accepted; the page receives the name in lower case without a trailing root dot. A single label such as `localhost` is no fully qualified name and is refused.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputFqdn { Label = _ => "Host", Icon = _ => new IconGlobe() })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputFqdn { Label = _ => ""Host"", Icon = _ => new IconGlobe() })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Wildcard",
                "The `Wildcard` property accepts a leading `*.`, as the name of a certificate may carry it.",
                "Wildcard = _ => true",
                new ControlForm()
                    .Add(new ControlFormItemInputFqdn { Label = _ => "Certificate name", Wildcard = _ => true })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Domains",
                "The `Domains` property limits the names to the given domains, the domains themselves included.",
                "Domains = _ => [\"example.com\"]",
                new ControlForm()
                    .Add(new ControlFormItemInputFqdn { Label = _ => "Host", Domains = _ => ["example.com"] })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
