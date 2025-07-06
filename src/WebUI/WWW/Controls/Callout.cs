using WebExpress.Toutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Toutorial.WebUI.WebPage;
using WebExpress.Toutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Toutorial.WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the callout control for the tutorial.
    /// </summary>
    [Title("Callout")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Callout : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Callout()
        {
            Stage.Description = @"A `Callout` control is a reusable, visually distinct UI element used to draw the user's attention to important information, contextual messages, or status updates. It is non-blocking and embedded directly within the layout, making it ideal for inline alerts or hints.";

            Stage.Control = new ControlPanelCallout()
            {
            }
                .Add(new ControlText() { Text = "This is a sample callout!" });

            Stage.Code = @"
            new ControlPanelCallout()
            {
            }
                .Add(new ControlText() { Text = ""This is a sample callout!"" });";

            Stage.AddProperty
                (
                    "Title",
                    "The title of a callout control acts as a concise heading that immediately communicates the purpose or meaning of the accompanying content to the user. It is displayed in a highlighted format above the main content and serves as a key element in the visual hierarchy.",
                    "Title = \"Success\"",
                    new ControlPanelCallout()
                    {
                        Title = "Success",
                        Color = new PropertyColorCallout(TypeColorCallout.Success),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    }
                        .Add(new ControlText() { Text = "With a title." }),
                    new ControlPanelCallout()
                    {
                        Color = new PropertyColorCallout(TypeColorCallout.Success),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    }
                        .Add(new ControlText() { Text = "Without a title." })
                );

            Stage.AddProperty
            (
                "Color",
                "The color property defines the semantic color variant of a callout control and primarily determines the color of its left border, providing a visual cue for the type or urgency of the message.",
                "Color = new PropertyColorCallout(TypeColorCallout.Primary)",
                new ControlPanelCallout()
                {
                    Title = "Standard",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Info",
                    Color = new PropertyColorCallout(TypeColorCallout.Info),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Primary",
                    Color = new PropertyColorCallout(TypeColorCallout.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Secondary",
                    Color = new PropertyColorCallout(TypeColorCallout.Secondary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Success",
                    Color = new PropertyColorCallout(TypeColorCallout.Success),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Warning",
                    Color = new PropertyColorCallout(TypeColorCallout.Warning),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Danger",
                    Color = new PropertyColorCallout(TypeColorCallout.Danger),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Dark",
                    Color = new PropertyColorCallout(TypeColorCallout.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Light",
                    Color = new PropertyColorCallout(TypeColorCallout.Light),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = "Custom",
                    Color = new PropertyColorCallout("gold"),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "Hello World!" })
            );

            Stage.AddProperty
            (
                "TextColor",
                "The textColor property defines the foreground color used for the text content of a callout control. This allows for tailored styling, accessibility enhancements, and clear emphasis of the message being displayed.",
                "TextColor = new PropertyColorText(TypeColorText.Success)",
                new ControlPanelCallout()
                {
                    Title = "Success",
                    Color = new PropertyColorCallout(TypeColorCallout.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Success),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "With a success text color." })
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "The backgroundColor property defines the fill color of the CallOut container. It visually separates the callout from its surrounding content and can be used to emphasize tone, importance, or branding.",
                "BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)",
                new ControlPanelCallout()
                {
                    Title = "Success",
                    Color = new PropertyColorCallout(TypeColorCallout.Success),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "With a warning background." })
            );


            Stage.AddProperty
                (
                    "Direction",
                    "The direction property defines the layout flow or text orientation of the callout's content. This can be used to support internationalization, custom UI flow, or aesthetic variation.",
                    "BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)",
                    new ControlPanelCallout()
                    {
                        Title = "Default",
                        Color = new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = TypeDirection.Default
                    }
                        .Add(new ControlText() { Text = "With a default direction." }),
                    new ControlPanelCallout()
                    {
                        Title = "Horizontal",
                        Color = new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = TypeDirection.Horizontal
                    }
                        .Add(new ControlText() { Text = "With a horizontal direction." })
                        ,
                    new ControlPanelCallout()
                    {
                        Title = "HorizontalReverse",
                        Color = new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = TypeDirection.HorizontalReverse
                    }
                        .Add(new ControlText() { Text = "With a horizontal reverse direction." }),
                    new ControlPanelCallout()
                    {
                        Title = "Vertical",
                        Color = new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = TypeDirection.Vertical
                    }
                        .Add(new ControlText() { Text = "With a vertical direction." })
                        ,
                    new ControlPanelCallout()
                    {
                        Title = "VerticalReverse",
                        Color = new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = TypeDirection.VerticalReverse
                    }
                        .Add(new ControlText() { Text = "With a vertical reverse direction." })
                );
        }
    }
}
