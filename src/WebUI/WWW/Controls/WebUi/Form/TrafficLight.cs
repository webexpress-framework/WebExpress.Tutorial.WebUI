using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the traffic light input control for the tutorial.
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
        /// <param name="pageContext">The context of the page where the traffic light control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public TrafficLight(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CLICK_EVENT);

            Stage.Description = @"The `TrafficLight` input lets users pick a status by clicking the red, yellow or green lamp. It is ideal for capturing a quick, three-level assessment such as a severity, a priority or a go / hold / stop decision. The selected lamp token is submitted with the form.";

            Stage.Control = new ControlForm("myform", new ControlFormItemInputTrafficLight(null)
            {
                Icon = _ => new IconTrafficLight(),
                Label = _ => "Status",
                Help = _ => "Select the current status here.",
                Name = _ => "mTrafficLightCtrl"
            }
                    .Initialize(args => args.Value.Text = "green")
                    .Process
                    (
                        x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
                    )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlFormItemInputTrafficLight(null)
            {
                Icon = _ => new IconTrafficLight(),
                Label = _ => ""Status"",
                Help = _ => ""Select the current status here."",
                Name = _ => ""mTrafficLightCtrl""
            }
                    .Initialize(args => args.Value.Text = ""green"")
                    .Process
                    (
                        x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
                    )";

            Stage.AddProperty
            (
                "Orientation",
                "The `Orientation` property arranges the selectable lamps either vertically or horizontally.",
                "new ControlFormItemInputTrafficLight(null) { Orientation = _ => TypeOrientationTrafficLight.Horizontal }",
                new ControlForm(null, new ControlFormItemInputTrafficLight(null)
                {
                    Orientation = _ => TypeOrientationTrafficLight.Horizontal
                })
            );

            Stage.AddProperty
            (
                "AllowOff",
                "The `AllowOff` property controls whether clicking the lit lamp clears the selection back to off. Set it to `false` when a status must always be selected.",
                "new ControlFormItemInputTrafficLight(null) { AllowOff = _ => false }",
                new ControlForm(null, new ControlFormItemInputTrafficLight(null)
                {
                    AllowOff = _ => false
                })
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property describes the field and is shown next to the control. When the label is defined as an internationalization key, the matching translation is resolved.",
                "new ControlFormItemInputTrafficLight(\"a\") { Label = _ => \"Status Label\" }",
                new ControlForm(null, new ControlFormItemInputTrafficLight("a")
                {
                    Label = _ => "Status Label"
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to the field.",
                "new ControlFormItemInputTrafficLight(\"a\") { Icon = _ => new IconTrafficLight() }",
                new ControlForm(null, new ControlFormItemInputTrafficLight("a")
                {
                    Icon = _ => new IconTrafficLight()
                })
            );
        }
    }
}
