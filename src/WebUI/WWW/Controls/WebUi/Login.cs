using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the login control for the tutorial.
    /// </summary>
    [Title("Login")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Login : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Login()
        {
            Stage.Description = @"Provides a login control that prompts the user to enter credentials for authentication.";

            Stage.Control = new ControlLogin();

            Stage.Code = @"
            new ControlLogin()";

            Stage.AddProperty
            (
                "Username",
                "Defines the username that is prefilled when the login control is displayed, allowing users to see an example credential or start typing immediately.",
                "Username = \"WebExpress\"",
                new ControlLogin()
                {
                    Username = "WebExpress"
                }
            );

            Stage.AddProperty
            (
                "Title",
                "Defines the title shown in the login control, helping users identify the purpose of the form.",
                "Title = \"WebExpress\"",
                new ControlLogin()
                {
                    Title = "WebExpress"
                }
            );
        }
    }
}
