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
    /// Represents the IP address input control for the tutorial.
    /// </summary>
    [WebIcon<IconNetworkWired>]
    [Title("Ip")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Ip : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the IP control is used.</param>
        public Ip(IPageContext pageContext)
        {
            Stage.Description = @"An `Ip` control takes an IPv4 or IPv6 address. An IPv4 address must have four parts without leading zeros; an IPv6 address reaches the page in its canonical, compressed form, so `2001:0DB8:0:0::1` arrives as `2001:db8::1`.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputIp { Label = _ => "Address", Icon = _ => new IconNetworkWired() })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputIp { Label = _ => ""Address"", Icon = _ => new IconNetworkWired() })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Version",
                "The `Version` property asks for one version of the internet protocol; the placeholder shows an example of it, and an address of the other version is refused with a message saying which one is expected.",
                "Version = _ => TypeIpVersion.Version6",
                new ControlForm()
                    .Add(new ControlFormItemInputIp { Label = _ => "IPv4", Version = _ => TypeIpVersion.Version4 })
                    .Add(new ControlFormItemInputIp { Label = _ => "IPv6", Version = _ => TypeIpVersion.Version6 })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "AllowPrefix",
                "The `AllowPrefix` property accepts a prefix length in CIDR notation, to enter a network rather than a single host - at most 32 for IPv4 and 128 for IPv6.",
                "AllowPrefix = _ => true",
                new ControlForm()
                    .Add(new ControlFormItemInputIp { Label = _ => "Network", AllowPrefix = _ => true })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
