using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
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
                .Add(new ControlFormItemInputRange
                {
                    Label = _ => "Label",
                    Description = _ => "Range description",
                    Min = _ => 0,
                    Max = _ => 10,
                    Step = _ => 1
                }
                    .Initialize(args => args.Value.Number = 3)
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value.Number}"))
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.DarkControls = [new ControlText()];
        }
    }
}
