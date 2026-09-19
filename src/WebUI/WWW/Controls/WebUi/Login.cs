using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the login control for the tutorial.
    /// </summary>
    [WebIcon<IconControlLogin>]
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

            // the dialog sits under the section headings of this page, so its title steps down
            Stage.Control = new ControlLogin() { HeadingLevel = _ => 5 };

            Stage.Code = @"
            new ControlLogin()";

            Stage.AddProperty
            (
                "Username",
                "Defines the username that is prefilled when the login control is displayed, allowing users to see an example credential or start typing immediately.",
                "Username = _ => \"WebExpress\"",
                new ControlLogin()
                {
                    Username = _ => "WebExpress",
                    HeadingLevel = _ => 5
                }
            );

            Stage.AddProperty
            (
                "Title",
                "Defines the title shown in the login control, helping users identify the purpose of the form.",
                "Title = _ => \"WebExpress\"",
                new ControlLogin()
                {
                    Title = _ => "WebExpress",
                    HeadingLevel = _ => 5
                }
            );

            Stage.AddProperty
            (
                "HeadingLevel",
                "Sets the outline level of the title. On a page of its own the dialog is the page and its title a second-level heading; embedded under other headings, as on this page, a deeper level keeps the outline of the page in order.",
                "HeadingLevel = _ => 5",
                new ControlLogin()
                {
                    HeadingLevel = _ => 5
                }
            );
        }
    }
}
