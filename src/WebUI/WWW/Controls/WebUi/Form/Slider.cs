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
    /// Represents the dual-handle slider control for the tutorial.
    /// </summary>
    [Title("Slider")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Slider : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the slider control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public Slider(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT);

            Stage.Description = @"A `Slider` control is a dual-handle range picker. In contrast to a single-handle `Range` control it lets the user select an interval bounded by a lower and an upper handle. Both handles are connected by a colored band, the scale is generic so the same control supports plain numbers, temperatures, percentages, durations and clock times.";

            Stage.Control = new ControlForm("sliderform")
                .Add(new ControlFormItemInputSlider("temperature")
                {
                    Icon = _ => new IconTemperatureHigh(),
                    Label = _ => "Comfort range",
                    Help = _ => "Drag the two handles to pick the lower and upper comfort temperature.",
                    Min = _ => 10,
                    Max = _ => 30,
                    Step = _ => 0.5f,
                    Unit = _ => "temperature",
                    Color = _ => new PropertyColorSlider("linear-gradient(90deg, #28a745 0%, #dc3545 100%)")
                }
                    .Initialize(args =>
                    {
                        args.Value.MinValue = 18f;
                        args.Value.MaxValue = 24f;
                    })
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $"Range: {x.Value.MinValue}…{x.Value.MaxValue} °C")))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlFormItemInputSlider(""temperature"")
            {
                Icon = _ => new IconTemperatureHigh(),
                Label = _ => ""Comfort range"",
                Help = _ => ""Drag the two handles to pick the lower and upper comfort temperature."",
                Min = _ => 10,
                Max = _ => 30,
                Step = _ => 0.5f,
                Unit = _ => ""temperature"",
                Color = _ => new PropertyColorSlider(""linear-gradient(90deg, #28a745 0%, #dc3545 100%)"")
            }
                .Initialize(args =>
                {
                    args.Value.MinValue = 18f;
                    args.Value.MaxValue = 24f;
                })
                .Process(x => componentHub
                    .GetComponentManager<NotificationManager>()
                    .AddNotification(pageContext.ApplicationContext, $""Range: {x.Value.MinValue}…{x.Value.MaxValue} °C""))";

            Stage.AddProperty
            (
                "Default (no Min/Max)",
                "Without any configuration the slider uses the default bounds `0..100` with a step size of `1`. Useful for percentages or any other 0-100 metric.",
                @"new ControlFormItemInputSlider(""percent"")
                {
                    Label = _ => ""Volume range"",
                    Unit = _ => ""percent""
                }",
                new ControlForm(null, new ControlFormItemInputSlider("percent")
                {
                    Label = _ => "Volume range",
                    Unit = _ => "percent"
                })
            );

            Stage.AddProperty
            (
                "Min / Max",
                "Use `Min` and `Max` to define the lower and upper bound of the track. The bounds are honored both server-side (clamping of initial values) and client-side (drag interaction). Negative values are supported.",
                @"new ControlFormItemInputSlider(""altitude"") { Min = _ => -500, Max = _ => 8848 }",
                new ControlForm(null, new ControlFormItemInputSlider("altitude")
                {
                    Label = _ => "Altitude (m)",
                    Min = _ => -500,
                    Max = _ => 8848
                })
            );

            Stage.AddProperty
            (
                "Step",
                "Step controls the snap grid. Integer steps produce integer labels, fractional steps automatically increase the number of decimals in the label.",
                @"new ControlFormItemInputSlider(""step025"") { Step = _ => 0.25f }",
                new ControlText() { Text = _ => "Step = 1 (integer)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("step1")
                {
                    Min = _ => 0,
                    Max = _ => 20,
                    Step = _ => 1
                }),
                new ControlText() { Text = _ => "Step = 0.25 (fractional)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("step025")
                {
                    Min = _ => 0,
                    Max = _ => 10,
                    Step = _ => 0.25f
                }),
                new ControlText() { Text = _ => "Step = 5 (coarse)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("step5")
                {
                    Min = _ => 0,
                    Max = _ => 100,
                    Step = _ => 5
                })
            );

            Stage.AddProperty
            (
                "Unit",
                "The `Unit` property selects the client-side label formatter. Built-in formatters: `number`, `temperature`, `percent`, `duration` (minutes as `Hh Mm`) and `time` (minutes since midnight as `HH:mm`). Anything else is treated as a literal suffix (e.g. `kg`).",
                @"new ControlFormItemInputSlider(""time"") { Unit = _ => ""time"", Min = _ => 0, Max = _ => 1440, Step = _ => 15 }",
                new ControlText() { Text = _ => "Temperature (°C)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("temp")
                {
                    Min = _ => -20,
                    Max = _ => 40,
                    Step = _ => 1,
                    Unit = _ => "temperature"
                }),
                new ControlText() { Text = _ => "Clock time (HH:mm)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("time")
                {
                    Min = _ => 0,
                    Max = _ => 1440,
                    Step = _ => 15,
                    Unit = _ => "time"
                }),
                new ControlText() { Text = _ => "Duration (Hh Mm)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("duration")
                {
                    Min = _ => 0,
                    Max = _ => 240,
                    Step = _ => 5,
                    Unit = _ => "duration"
                }),
                new ControlText() { Text = _ => "Custom unit (kg)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("weight")
                {
                    Min = _ => 0,
                    Max = _ => 250,
                    Step = _ => 0.5f,
                    Unit = _ => "kg"
                })
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property styles both handles and the connecting band as a single unit. Pass a `TypeColorSlider` for one of the built-in theme colors, or any CSS background expression (e.g. a `linear-gradient(...)`) via `new PropertyColorSlider(string)`.",
                @"new ControlFormItemInputSlider(""color"") { Color = _ => new PropertyColorSlider(TypeColorSlider.Success) }",
                new ControlText() { Text = _ => "TypeColorSlider.Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("color-primary")
                {
                    Color = _ => new PropertyColorSlider(TypeColorSlider.Primary)
                }),
                new ControlText() { Text = _ => "TypeColorSlider.Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("color-success")
                {
                    Color = _ => new PropertyColorSlider(TypeColorSlider.Success)
                }),
                new ControlText() { Text = _ => "TypeColorSlider.Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("color-warning")
                {
                    Color = _ => new PropertyColorSlider(TypeColorSlider.Warning)
                }),
                new ControlText() { Text = _ => "TypeColorSlider.Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("color-danger")
                {
                    Color = _ => new PropertyColorSlider(TypeColorSlider.Danger)
                }),
                new ControlText() { Text = _ => "User color (custom gradient)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSlider("color-user")
                {
                    Color = _ => new PropertyColorSlider("linear-gradient(90deg, #28a745 0%, #ffc107 50%, #dc3545 100%)")
                })
            );

            Stage.AddProperty
            (
                "ShowLabels",
                "Disable the per-handle value labels for a compact rendering. The handle title (tooltip) still exposes the current value.",
                @"new ControlFormItemInputSlider(""compact"") { ShowLabels = _ => false }",
                new ControlForm(null, new ControlFormItemInputSlider("compact")
                {
                    ShowLabels = _ => false
                })
            );

            Stage.AddProperty
            (
                "Validation",
                "Use `Validate` to plug in server-side validation. The example below requires the selected range to span at least 10 units.",
                @"new ControlFormItemInputSlider(""validated"")
                {
                    Min = _ => 0,
                    Max = _ => 100,
                    Step = _ => 1
                }
                    .Initialize(args => { args.Value.MinValue = 45; args.Value.MaxValue = 50; })
                    .Validate(args => args.Add(args.Value.MaxValue - args.Value.MinValue < 10, ""Range must span at least 10 units.""))",
                new ControlForm("validatedform", new ControlFormItemInputSlider("validated")
                {
                    Label = _ => "Validated range",
                    Help = _ => "The range must span at least 10 units.",
                    Min = _ => 0,
                    Max = _ => 100,
                    Step = _ => 1
                }
                    .Initialize(args =>
                    {
                        args.Value.MinValue = 45f;
                        args.Value.MaxValue = 50f;
                    })
                    .Validate(args => args.Add(args.Value.MaxValue - args.Value.MinValue < 10, "Range must span at least 10 units.")))
                .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property locks the control and visually grays it out. The hidden input is also disabled so the value is not posted back.",
                @"new ControlFormItemInputSlider(""disabled"") { Disabled = _ => true }",
                new ControlForm(null, new ControlFormItemInputSlider("disabled")
                {
                    Label = _ => "Read only",
                    Disabled = _ => true
                }
                    .Initialize(args =>
                    {
                        args.Value.MinValue = 25f;
                        args.Value.MaxValue = 75f;
                    }))
            );

            Stage.DarkControls = [new ControlText()];
        }
    }
}
