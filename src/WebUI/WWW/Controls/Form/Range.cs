using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the range control for the tutorial.    
    /// </summary>    
    [Title("Range")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Range : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page on which the CheckBox control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Range(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"A `Range` control is a graphical user interface element that allows users to select a numeric value from a continuous interval by sliding a handle along a horizontal track. It supports minimum, maximum, and step values to define the range and precision of input. This control is commonly used for settings such as volume, brightness, or price filters, where a gradual adjustment is preferred over discrete choices.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputRange { Label = "Label", Description = "Range description" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputRange { Label = ""Label"", Description = ""Range description"" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the checkbox field serves as a short description and is displayed in the main area of the control. It ensures a clear and concise presentation of the range.",
                "Label = \"Volume\"",
                new ControlForm(null, new ControlFormItemInputRange(null)
                {
                    Label = "Volume"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the range.",
                "Help = \"You can unsubscribe anytime from your account settings.\"",
                new ControlForm(null, new ControlFormItemInputRange(null)
                {
                    Help = "Use the slider to adjust the playback volume. Values range from 0 (mute) to 100 (maximum), in steps of 5."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the range field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconPaperPlane()",
                new ControlForm(null, new ControlFormItemInputRange(null)
                {
                    Icon = new IconPaperPlane()
                })
            );

            Stage.AddProperty
               (
                   "Disabled",
                   "The `disabled` property is used to make a check box non interactive and visually grayed out. It signals to users that the option is currently not available.",
                   @"Disabled = true",
                   new ControlForm()
                       .Add(new ControlFormItemInputRange
                       {
                           Label = "Volume",
                           Icon = new IconPaperPlane(),
                           Description = "Adjust the playback volume from silent to maximum",
                           Help = "Use the slider to adjust the playback volume. Values range from 0 (mute) to 100 (maximum), in steps of 5.",
                           Disabled = true
                       })
                       .AddPrimaryButton(new ControlFormItemButtonSubmit())
               );

            Stage.AddProperty
                (
                    "Min",
                    "The `min` attribute of a `Range` control defines the lowest possible value that the user can select using the slider. It sets the starting point of the range and works in conjunction with the `max` and `step` attributes to determine the behavior and precision of the control.",
                    "Min = 5",
                    new ControlForm()
                        .Add(new ControlFormItemInputRange
                        {
                            Label = "Min",
                            Description = "Range description",
                            Min = 5

                        })
                        .AddPrimaryButton(new ControlFormItemButtonSubmit())
                );

            Stage.AddProperty
                (
                    "Max",
                    "The `max` attribute of a `Range` control specifies the highest value a user can select using the slider. It defines the upper boundary of the range and works together with the `min` and `step` attributes to control the scale and precision of input.",
                    "Max = 50",
                    new ControlForm()
                        .Add(new ControlFormItemInputRange
                        {
                            Label = "Max",
                            Description = "Range description",
                            Max = 50

                        })
                        .AddPrimaryButton(new ControlFormItemButtonSubmit())
                );

            Stage.AddProperty
                (
                    "Step",
                    "The `step` attribute of a `Range` control determines the incremental intervals between selectable values on the slider. It defines how much the value changes with each movement of the slider handle, allowing for fine or coarse adjustments depending on the use case.",
                    "Step = 2",
                    new ControlForm()
                        .Add(new ControlFormItemInputRange
                        {
                            Label = "Step",
                            Description = "Range description",
                            Step = 2

                        })
                        .AddPrimaryButton(new ControlFormItemButtonSubmit())
                );
        }
    }
}
