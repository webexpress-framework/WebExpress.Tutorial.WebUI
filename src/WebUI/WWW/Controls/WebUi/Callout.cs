using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
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
                .Add(new ControlText() { Text = _ => "This is a sample callout!" });

            Stage.Code = @"
            new ControlPanelCallout()
            {
            }
                .Add(new ControlText() { Text = _ => ""This is a sample callout!"" });";

            Stage.AddProperty
                (
                    "Title",
                    "The title of a callout control acts as a concise heading that immediately communicates the purpose or meaning of the accompanying content to the user. It is displayed in a highlighted format above the main content and serves as a key element in the visual hierarchy.",
                    "Title = _ => \"Success\"",
                    new ControlPanelCallout()
                    {
                        Title = _ => "Success",
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Success),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    }
                        .Add(new ControlText() { Text = _ => "With a title." }),
                    new ControlPanelCallout()
                    {
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Success),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    }
                        .Add(new ControlText() { Text = _ => "Without a title." })
                );

            Stage.AddProperty
            (
                "Color",
                "The color property defines the semantic color variant of a callout control and primarily determines the color of its left border, providing a visual cue for the type or urgency of the message.",
                "Color = _ => new PropertyColorCallout(TypeColorCallout.Primary)",
                new ControlPanelCallout()
                {
                    Title = _ => "Standard",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Info",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Info),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Primary",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Secondary",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Secondary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Success",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Warning",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Warning),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Danger",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Danger),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Dark",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Light",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Light),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" }),
                new ControlPanelCallout()
                {
                    Title = _ => "Highlight",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Highlight),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Color is supplied exclusively via --wx-highlight." }),
                new ControlPanelCallout()
                {
                    Title = _ => "Custom",
                    Color = _ => new PropertyColorCallout("gold"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Hello World!" })
            );

            Stage.AddProperty
            (
                "TextColor",
                "The textColor property defines the foreground color used for the text content of a callout control. This allows for tailored styling, accessibility enhancements, and clear emphasis of the message being displayed.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Success)",
                new ControlPanelCallout()
                {
                    Title = _ => "Success",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "With a success text color." })
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "The backgroundColor property defines the fill color of the CallOut container. It visually separates the callout from its surrounding content and can be used to emphasize tone, importance, or branding.",
                "BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)",
                new ControlPanelCallout()
                {
                    Title = _ => "Success",
                    Color = _ => new PropertyColorCallout(TypeColorCallout.Success),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "With a warning background." })
            );


            Stage.AddProperty
                (
                    "Direction",
                    "The direction property defines the layout flow or text orientation of the callout's content. This can be used to support internationalization, custom UI flow, or aesthetic variation.",
                    "Direction = _ => TypeDirection.Default",
                    new ControlPanelCallout()
                    {
                        Title = _ => "Default",
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = _ => TypeDirection.Default
                    }
                        .Add(new ControlText() { Text = _ => "With a default direction." }),
                    new ControlPanelCallout()
                    {
                        Title = _ => "Horizontal",
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = _ => TypeDirection.Horizontal
                    }
                        .Add(new ControlText() { Text = _ => "With a horizontal direction." })
                        ,
                    new ControlPanelCallout()
                    {
                        Title = _ => "HorizontalReverse",
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = _ => TypeDirection.HorizontalReverse
                    }
                        .Add(new ControlText() { Text = _ => "With a horizontal reverse direction." }),
                    new ControlPanelCallout()
                    {
                        Title = _ => "Vertical",
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = _ => TypeDirection.Vertical
                    }
                        .Add(new ControlText() { Text = _ => "With a vertical direction." })
                        ,
                    new ControlPanelCallout()
                    {
                        Title = _ => "VerticalReverse",
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Primary),
                        Direction = _ => TypeDirection.VerticalReverse
                    }
                        .Add(new ControlText() { Text = _ => "With a vertical reverse direction." })
                );
        }
    }
}
