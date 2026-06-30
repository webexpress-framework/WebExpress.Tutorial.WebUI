using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the read-only traffic light control for the tutorial.
    /// </summary>
    [Title("Traffic Light")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class TrafficLight : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public TrafficLight()
        {
            Stage.Description = @"The `TrafficLight` control is a read-only status indicator. It lights one of its three lamps — red, yellow or green — to communicate a state at a glance, for example the health of a build, a service or a workflow step.";

            Stage.Control = new ControlTrafficLight()
            {
                State = _ => TypeTrafficLight.Green
            };

            Stage.Code = @"
                new ControlTrafficLight()
                {
                    State = _ => TypeTrafficLight.Green
                };";

            Stage.AddProperty
            (
                "State",
                "The `State` property defines which lamp is lit. `Off` keeps every lamp dark, while `Red`, `Yellow` and `Green` light the matching lamp.",
                "State = _ => TypeTrafficLight.Red",
                new ControlText() { Text = _ => "Off", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Off },
                new ControlText() { Text = _ => "Red", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Red },
                new ControlText() { Text = _ => "Yellow", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Yellow },
                new ControlText() { Text = _ => "Green", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Green }
            );

            Stage.AddProperty
            (
                "Orientation",
                "The `Orientation` property arranges the lamps either vertically, like a physical signal, or horizontally to save vertical space.",
                "Orientation = _ => TypeOrientationTrafficLight.Horizontal",
                new ControlText() { Text = _ => "Vertical", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight()
                {
                    State = _ => TypeTrafficLight.Yellow,
                    Orientation = _ => TypeOrientationTrafficLight.Vertical
                },
                new ControlText() { Text = _ => "Horizontal", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight()
                {
                    State = _ => TypeTrafficLight.Yellow,
                    Orientation = _ => TypeOrientationTrafficLight.Horizontal
                }
            );

            Stage.AddProperty
            (
                "Size",
                "The `Size` property scales the lamps. The default is intentionally compact so the control fits inline; the larger steps suit a prominent status display.",
                "Size = _ => TypeSizeTrafficLight.Large",
                new ControlText() { Text = _ => "ExtraSmall", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Green, Size = _ => TypeSizeTrafficLight.ExtraSmall },
                new ControlText() { Text = _ => "Small", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Green, Size = _ => TypeSizeTrafficLight.Small },
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Green, Size = _ => TypeSizeTrafficLight.Default },
                new ControlText() { Text = _ => "Large", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Green, Size = _ => TypeSizeTrafficLight.Large },
                new ControlText() { Text = _ => "ExtraLarge", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTrafficLight() { State = _ => TypeTrafficLight.Green, Size = _ => TypeSizeTrafficLight.ExtraLarge }
            );

            Stage.AddProperty
            (
                "Tooltip",
                "The `Tooltip` property attaches a native tooltip that explains what the current state means when the user hovers the control.",
                "Tooltip = _ => \"All systems operational\"",
                new ControlTrafficLight()
                {
                    State = _ => TypeTrafficLight.Green,
                    Tooltip = _ => "All systems operational"
                }
            );
        }
    }
}
