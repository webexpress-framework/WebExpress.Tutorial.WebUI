using System.Net;
using WebExpress.Tutorial.WebUI.Model;
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
    /// Represents the domain input control for the tutorial.
    /// </summary>
    [WebIcon<IconUserLock>]
    [Title("Domain")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Domain : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the domain control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public Domain(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"A `Domain` control takes an account in a domain: a button with the chosen domain beside a field for the user name, composed into `DOMAIN\user` or `user@domain.tld`. An account typed in full selects its domain itself. The server checks the limits of a directory such as Active Directory - a NetBIOS domain of at most 15 characters, a logon name of at most 20 and none of the characters it reserves.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputDomain { Label = _ => "Account", Domains = _ => ["MELEE", "MONKEY", "scummbar.example"] }
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, x.Context.Request, $"Value: {WebUtility.HtmlEncode(x.Value.Text)}", durability: 5000)))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputDomain { Label = _ => ""Account"", Domains = _ => [""MELEE"", ""MONKEY"", ""scummbar.example""] }
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, x.Context.Request, $""Value: {WebUtility.HtmlEncode(x.Value.Text)}"", durability: 5000)))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Domains",
                "The `Domains` property names the domains offered; an account of another domain is refused. A domain with a dot makes a principal name (`user@scummbar.example`), one without a down-level name (`MELEE\\user`). Left unset, the field takes the whole account as text.",
                "Domains = _ => [\"MELEE\", \"MONKEY\"]",
                new ControlForm(null, new ControlFormItemInputDomain(null) { Domains = _ => ["MELEE", "MONKEY"] }),
                new ControlForm(null, new ControlFormItemInputDomain(null))
            );

            Stage.AddProperty
            (
                "Domain",
                "The `Domain` property sets the domain the picker starts with. Without `Domains`, a bare user name is completed with it, because users of a single domain rarely type it.",
                "Domain = _ => \"MONKEY\"",
                new ControlForm(null, new ControlFormItemInputDomain(null) { Domains = _ => ["MELEE", "MONKEY"], Domain = _ => "MONKEY" })
            );

            Stage.AddProperty
            (
                "Format",
                "The `Format` property fixes the notation - `DownLevel` for `DOMAIN\\user`, `Principal` for `user@domain.tld` - whatever the domain looks like.",
                "Format = _ => TypeDomainFormat.Principal",
                new ControlForm(null, new ControlFormItemInputDomain(null) { Domains = _ => ["melee.example"], Format = _ => TypeDomainFormat.Principal }),
                new ControlForm(null, new ControlFormItemInputDomain(null) { Format = _ => TypeDomainFormat.DownLevel })
            );

            Stage.AddProperty
            (
                "Account",
                "The `Account` property preselects an account as long as the form has no value of its own.",
                "Account = _ => \"MONKEY\\\\guybrush\"",
                new ControlForm(null, new ControlFormItemInputDomain(null) { Domains = _ => ["MELEE", "MONKEY"], Account = _ => "MONKEY\\guybrush" })
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property locks both the domain button and the user field.",
                "Disabled = _ => true",
                new ControlForm(null, new ControlFormItemInputDomain(null) { Domains = _ => ["MELEE"], Account = _ => "MELEE\\elaine", Disabled = _ => true })
            );
        }
    }
}
