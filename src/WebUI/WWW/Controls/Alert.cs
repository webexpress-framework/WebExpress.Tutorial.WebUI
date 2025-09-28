using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
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
                Text = "This is a sample alert!",
                Dismissibility = TypeDismissibilityAlert.Dismissible,
                Fade = TypeFade.FadeShow,
                BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Info)
            };

            Stage.Code = @"
            new ControlAlert() 
            { 
                Text = ""This is a sample alert!"", 
                Dismissibility = TypeDismissibilityAlert.Dismissible, 
                Fade = TypesFade.FadeShow, 
                BackgroundColor = new PropertyColorBackground(TypeColorBackgroundAlert.Info) 
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the alert, allowing customization for different contexts.",
                "BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Primary)",
                new ControlAlert()
                {
                    Text = "This is a default alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow
                },
                new ControlAlert()
                {
                    Text = "This is a primary alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Primary)
                },
                new ControlAlert()
                {
                    Text = "This is a secondary alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Secondary)
                },
                new ControlAlert()
                {
                    Text = "This is an info alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Info)
                },
                new ControlAlert()
                {
                    Text = "This is a success alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                },
                new ControlAlert()
                {
                    Text = "This is a warning alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Warning)
                },
                new ControlAlert()
                {
                    Text = "This is an error alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Danger)
                },
                new ControlAlert()
                {
                    Text = "This is a dark alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Dark)
                },
                new ControlAlert()
                {
                    Text = "This is a light alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Light)
                },
                new ControlAlert()
                {
                    Text = "This is a white alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.White)
                },
                new ControlAlert()
                {
                    Text = "This is a transparent alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Transparent)
                },
                new ControlAlert()
                {
                    Text = "This is a custom alert!",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    TextColor = new PropertyColorText("red"),
                    BackgroundColor = new PropertyColorBackgroundAlert("gold")
                }
            );

            Stage.AddProperty
            (
                "Dismissibility",
                "Determines whether the alert can be closed (hidden) by the user.",
                "Dismissibility = TypeDismissibilityAlert.Dismissible",
                new ControlAlert()
                {
                    Text = "This is a success alert that cannot be dismissed.",
                    Dismissibility = TypeDismissibilityAlert.None,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                },
                new ControlAlert()
                {
                    Text = "This is a success alert that can be dismissed.",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                }
            );

            Stage.AddProperty
            (
                "Fade",
                "Specifies the type of fade effect used to display the alert.",
                "Fade = TypeFade.FadeShow",
                new ControlAlert()
                {
                    Text = "This is a success alert without animation.",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.None,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                },
                new ControlAlert()
                {
                    Text = "This is a success alert with full animation.",
                    Dismissibility = TypeDismissibilityAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                }
            );
        }
    }
}
