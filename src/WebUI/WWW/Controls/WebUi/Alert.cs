using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the alert control for the tutorial.
    /// </summary>
    [Title("Alert")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Alert : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Alert()
        {
            Stage.Description = @"The `Alert` control is an intuitive and versatile tool designed for displaying notifications, warnings, or status updates in web applications. It ensures critical messages are delivered clearly and effectively, using dynamic styling and functionality to grab user attention. Built for flexibility, the control can be customized to suit various use cases.";

            Stage.Control = new ControlAlert()
            {
                Text = _ => "This is a sample alert!",
                Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                Fade = _ => TypeFade.FadeShow,
                BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Info)
            };

            Stage.Code = @"
            new ControlAlert() 
            { 
                Text = _=> ""This is a sample alert!"", 
                Dismissibility = _=> TypeDismissibilityAlert.Dismissible, 
                Fade = _=> TypesFade.FadeShow, 
                BackgroundColor = _=> new PropertyColorBackground(TypeColorBackgroundAlert.Info) 
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the alert, allowing customization for different contexts.",
                "BackgroundColor = _=> new PropertyColorBackgroundAlert(TypeColorBackground.Primary)",
                new ControlAlert()
                {
                    Text = _ => "This is a default alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow
                },
                new ControlAlert()
                {
                    Text = _ => "This is a primary alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Primary)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a secondary alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Secondary)
                },
                new ControlAlert()
                {
                    Text = _ => "This is an info alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Info)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a success alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a warning alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Warning)
                },
                new ControlAlert()
                {
                    Text = _ => "This is an error alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Danger)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a dark alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Dark)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a light alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Light)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a white alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.White)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a transparent alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Transparent)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a highlight alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Highlight)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a custom alert!",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    TextColor = _ => new PropertyColorText("red"),
                    BackgroundColor = _ => new PropertyColorBackgroundAlert("gold")
                }
            );

            Stage.AddProperty
            (
                "Dismissibility",
                "Determines whether the alert can be closed (hidden) by the user.",
                "Dismissibility = _=> TypeDismissibilityAlert.Dismissible",
                new ControlAlert()
                {
                    Text = _ => "This is a success alert that cannot be dismissed.",
                    Dismissibility = _ => TypeDismissibilityAlert.None,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a success alert that can be dismissed.",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                }
            );

            Stage.AddProperty
            (
                "Fade",
                "Specifies the type of fade effect used to display the alert.",
                "Fade = _=> TypeFade.FadeShow",
                new ControlAlert()
                {
                    Text = _ => "This is a success alert without animation.",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.None,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                },
                new ControlAlert()
                {
                    Text = _ => "This is a success alert with full animation.",
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible,
                    Fade = _ => TypeFade.FadeShow,
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                }
            );
        }
    }
}
