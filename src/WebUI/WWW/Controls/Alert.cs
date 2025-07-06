using WebExpress.Toutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Toutorial.WebUI.WebPage;
using WebExpress.Toutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Toutorial.WebUI.WWW.Controls
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
                Dismissible = TypeDismissibleAlert.Dismissible,
                Fade = TypeFade.FadeShow,
                BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Info)
            };

            Stage.Code = @"
            new ControlAlert() 
            { 
                Text = ""This is a sample alert!"", 
                Dismissible = TypesDismissibleAlert.Dismissible, 
                Fade = TypesFade.FadeShow, 
                BackgroundColor = new PropertyColorBackground(TypesBackgroundColor.Info) 
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the alert, allowing customization for different contexts.",
                "BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Primary)",
                new ControlAlert()
                {
                    Text = "This is a default alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow
                },
                new ControlAlert()
                {
                    Text = "This is a primary alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Primary)
                },
                new ControlAlert()
                {
                    Text = "This is a secondary alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Secondary)
                },
                new ControlAlert()
                {
                    Text = "This is an info alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Info)
                },
                new ControlAlert()
                {
                    Text = "This is a success alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                },
                new ControlAlert()
                {
                    Text = "This is a warning alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Warning)
                },
                new ControlAlert()
                {
                    Text = "This is an error alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Danger)
                },
                new ControlAlert()
                {
                    Text = "This is a dark alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Dark)
                },
                new ControlAlert()
                {
                    Text = "This is a light alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Light)
                },
                new ControlAlert()
                {
                    Text = "This is a white alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.White)
                },
                new ControlAlert()
                {
                    Text = "This is a transparent alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Transparent)
                },
                new ControlAlert()
                {
                    Text = "This is a custom alert!",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    TextColor = new PropertyColorText("red"),
                    BackgroundColor = new PropertyColorBackgroundAlert("gold")
                }
            );

            Stage.AddProperty
            (
                "Dismissible",
                "Determines whether the alert can be closed (hidden) by the user.",
                "Dismissible = TypeDismissibleAlert.Dismissible",
                new ControlAlert()
                {
                    Text = "This is a success alert that cannot be dismissed.",
                    Dismissible = TypeDismissibleAlert.None,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                },
                new ControlAlert()
                {
                    Text = "This is a success alert that can be dismissed.",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
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
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.None,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                },
                new ControlAlert()
                {
                    Text = "This is a success alert with full animation.",
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow,
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                }
            );
        }
    }
}
