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
    /// Represents the estimate input control for the tutorial.
    /// </summary>
    [Title("Estimate")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Estimate : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the estimate control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public Estimate(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CLICK_EVENT);

            Stage.Description = @"The `Estimate` control lets users pick an effort estimate from a configurable scale of chips. The default scale is a rounded Fibonacci sequence, the established scale for agile story-point estimation, so authoring a scale is only required to deviate from that default.";

            Stage.Control = new ControlForm("myform", new ControlFormItemInputEstimate(null)
            {
                Icon = _ => new IconChartBar(),
                Label = _ => "Estimate",
                Help = _ => "Estimate the effort here.",
                Name = _ => "mEstimateCtrl"
            }
                    .Initialize(args => args.Value.Number = 5)
                    .Process
                    (
                        x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
                    )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlFormItemInputEstimate(null)
            {
                Icon = _ => new IconChartBar(),
                Label = _ => ""Estimate"",
                Help = _ => ""Estimate the effort here."",
                Name = _ => ""mEstimateCtrl""
            }
                    .Initialize(args => args.Value.Number = 5)
                    .Process
                    (
                        x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
                    )";

            Stage.AddProperty
            (
                "Scale",
                "The `Scale` property defines the estimation values offered as chips. When it is not set, the control falls back to a rounded Fibonacci sequence, so a scale is only authored to deviate from that default.",
                "new ControlFormItemInputEstimate(null) { Scale = _ => [1, 2, 3, 5, 8, 13] }",
                new ControlForm(null, new ControlFormItemInputEstimate(null)
                {
                    Scale = _ => [1, 2, 3, 5, 8, 13]
                })
            );

            Stage.AddProperty
            (
                "AllowClear",
                "The `AllowClear` property controls whether re-selecting the active chip clears the estimate, which lets a user remove an estimate they previously set.",
                "new ControlFormItemInputEstimate(null) { AllowClear = _ => true }",
                new ControlForm(null, new ControlFormItemInputEstimate(null)
                {
                    AllowClear = _ => true
                })
            );

            Stage.AddProperty
            (
                "Colors",
                "The `Colors` property colour-codes the chips, one color per scale value in order, for example a green-to-red effort heat scale. Each entry accepts a system color or a user-defined color; the active chip then keeps its own color and is marked with a ring.",
                "new ControlFormItemInputEstimate(null) { Scale = _ => [1, 2, 3, 5, 8, 13], Colors = _ => [new PropertyColorBackground(TypeColorBackground.Success), /* … */ new PropertyColorBackground(TypeColorBackground.Danger)] }",
                new ControlForm(null, new ControlFormItemInputEstimate(null)
                {
                    Scale = _ => [1, 2, 3, 5, 8, 13],
                    Colors = _ =>
                    [
                        new PropertyColorBackground(TypeColorBackground.Success),
                        new PropertyColorBackground(TypeColorBackground.Success),
                        new PropertyColorBackground(TypeColorBackground.Info),
                        new PropertyColorBackground(TypeColorBackground.Warning),
                        new PropertyColorBackground(TypeColorBackground.Warning),
                        new PropertyColorBackground(TypeColorBackground.Danger)
                    ]
                })
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of an `Estimate` control labels the field in the form and is shown alongside the chips.",
                "new ControlFormItemInputEstimate(\"a\") { Label = _ => \"Estimate\" }",
                new ControlForm(null, new ControlFormItemInputEstimate("a")
                {
                    Label = _ => "Estimate"
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to the estimate field.",
                "new ControlFormItemInputEstimate(\"a\") { Icon = _ => new IconHome() }",
                new ControlForm(null, new ControlFormItemInputEstimate("a")
                {
                    Icon = _ => new IconHome()
                })
            );
        }
    }
}
