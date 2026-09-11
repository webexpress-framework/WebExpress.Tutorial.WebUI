using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST login dialog for the tutorial: the login dialog of WebUI
    /// framing the REST login, which is how the tutorial itself signs its users in.
    /// </summary>
    [WebIcon<IconControlLogin>]
    [Title("DataModalLogin")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataModalLogin : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DataModalLogin()
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"`ControlDataModalLogin` is the `ControlModalLogin` of WebUI framing the REST-backed `ControlDataLogin`: the credentials are submitted to the session endpoint - with the rate limiting and the lockout the REST login brings - and the page is reloaded once the session cookie is set, or moved on to `RedirectUri`. The service is declared on the dialog the way every data control declares it and is emitted on the framed login, where the REST login controller reads it. The tutorial's own login - the entry in the avatar menu - is this dialog.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("myDataLoginModal")
                },
                new ControlDataModalLogin("myDataLoginModal")
                    .DataService<Session>()
            ];

            Stage.DarkControls =
            [
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("myDarkDataLoginModal")
                },
                new ControlDataModalLogin("myDarkDataLoginModal")
                    .DataService<Session>()
            ];

            Stage.Code = @"
            new ControlButton()
            {
                Text = _ => ""Sign in"",
                Icon = _ => new IconRightToBracket(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                PrimaryAction = _ => new ActionModal(""myDataLoginModal"")
            },
            new ControlDataModalLogin(""myDataLoginModal"")
                .DataService<Session>()";
        }
    }
}
