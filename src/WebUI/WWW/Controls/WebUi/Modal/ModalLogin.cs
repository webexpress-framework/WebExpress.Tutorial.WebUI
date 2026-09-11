using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Modal
{
    /// <summary>
    /// Represents the login dialog for the tutorial: the login control framed by a modal,
    /// so signing in happens on top of the page instead of on a page of its own.
    /// </summary>
    [WebIcon<IconControlLogin>]
    [Title("ModalLogin")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ModalLogin : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ModalLogin()
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"`ControlModalLogin` frames the `ControlLogin` with a dialog, so the login process is modal-based: the user signs in on top of the page they are on instead of being sent to a login page. The dialog lends the login what its card would otherwise supply - the title bar names it, the footer carries the submit button ahead of the close button, which is rightmost as on every dialog - and leaves the login what is its: the fields, the request and what follows success and failure. The login inside is a real `ControlLogin`, which is why a variant of the login is framed by deriving from the dialog and handing that variant to its protected constructor.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("myLoginModal")
                },
                new ControlModalLogin("myLoginModal")
            ];

            Stage.DarkControls =
            [
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("myDarkLoginModal")
                },
                new ControlModalLogin("myDarkLoginModal")
            ];

            Stage.Code = @"
            new ControlButton()
            {
                Text = _ => ""Sign in"",
                Icon = _ => new IconRightToBracket(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                PrimaryAction = _ => new ActionModal(""myLoginModal"")
            },
            new ControlModalLogin(""myLoginModal"")";

            Stage.AddProperty
            (
                "Header",
                @"The header names the dialog and stands in for the title the login control draws on its card. It defaults to the login title and takes an i18n key.",
                "Header = _ => \"Welcome back\"",
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("headerLoginModal")
                },
                new ControlModalLogin("headerLoginModal")
                {
                    Header = _ => "Welcome back"
                }
            );

            Stage.AddProperty
            (
                "Username",
                @"The username the dialog opens with. A name the page already knows - the one a session expired for, say - spares the user typing it again; the caret then goes straight into the password field when the dialog is shown.",
                "Username = _ => \"WebExpress\"",
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("usernameLoginModal")
                },
                new ControlModalLogin("usernameLoginModal")
                {
                    Username = _ => "WebExpress"
                }
            );

            Stage.AddProperty
            (
                "Content",
                @"Further content reads below the fields - a hint, or a link to a password reset. It is added the way content is added to every modal.",
                @"new ControlModalLogin(""contentLoginModal"")
                    .Add(new ControlText() { Text = _ => ""Forgot your password? Ask the administrator."", Format = _ => TypeFormatText.Small })",
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("contentLoginModal")
                },
                new ControlModalLogin("contentLoginModal")
                    .Add(new ControlText()
                    {
                        Text = _ => "Forgot your password? Ask the administrator.",
                        Format = _ => TypeFormatText.Small,
                        TextColor = _ => new PropertyColorText(TypeColorText.Secondary)
                    })
            );

            Stage.AddProperty
            (
                "Size",
                @"The size of the dialog, as with every modal. A login needs little room, so the small dialog fits it well.",
                "Size = _ => TypeModalSize.Small",
                new ControlButton()
                {
                    Text = _ => "Sign in",
                    Icon = _ => new IconRightToBracket(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("sizeLoginModal")
                },
                new ControlModalLogin("sizeLoginModal")
                {
                    Size = _ => TypeModalSize.Small
                }
            );
        }
    }
}
