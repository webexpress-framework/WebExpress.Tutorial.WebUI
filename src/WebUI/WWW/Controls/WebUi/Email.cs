using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the e-mail control for the tutorial.
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
        /// <param name="pageContext">The context of the page where the e-mail control is used.</param>
        public Email(IPageContext pageContext)
        {
            Stage.Description = @"The `Email` control is a read-only component that shows an e-mail address as a link that writes to it. The address is normalized - its domain in lower case - and an invalid address leaves the display empty rather than linking nowhere.";

            Stage.Controls = [
                new ControlEmail()
                {
                    Email = _ => "guybrush@melee-island.example"
                }
            ];

            Stage.Code = @"
            new ControlEmail()
            {
                Email = _ => ""guybrush@melee-island.example""
            };";

            Stage.AddProperty
            (
                "Email",
                "The `Email` property sets the address. The local part keeps its case, the domain is shown in lower case, because only the receiving server may decide whether the local part's case matters.",
                "Email = _ => \"Elaine.Marley@GOVERNOR.example\"",
                new ControlEmail() { Email = _ => "Elaine.Marley@GOVERNOR.example" }
            );
        }
    }
}
