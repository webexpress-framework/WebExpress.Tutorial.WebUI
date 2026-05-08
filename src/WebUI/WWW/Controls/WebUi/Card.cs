using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the Card control for the tutorial.
    /// </summary>
    [Title("Card")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Card : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        public Card(IApplicationContext applicationContext)
        {
            Stage.Description = @"A `Card` is a versatile UI container used to present content in a well-structured, bordered rectangle. It is ideal for grouping related information, actions, or media elements in a compact, visually distinct format.";

            Stage.Control = new ControlPanelCard()
            {
            }
                .Add(new ControlText() { Text = _ => "This is a sample card!" });

            Stage.Code = @"
            new ControlPanelCard()
            {
            }
                .Add(new ControlText() { Text = _ => ""This is a sample card!"" });";

            Stage.AddProperty
            (
                "BackgroundColor",
                "The `BackgroundColor` property defines the background fill color of the component. It plays a key role in determining the visual appearance and helps visually separate the component from surrounding content or reinforce semantic meaning (e.g., success, warning, error).",
                "BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlPanelCard()
                {

                }
                    .Add(new ControlText() { Text = _ => "Without specifying a background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The primary background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The secondary background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The info background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The success background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The warning background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The danger background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The dark background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The light background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.White),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The white background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The transparent background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = _ => new PropertyColorBackground("gold"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "The custom background color." })
            );

            Stage.AddProperty
            (
                "Header",
                "The `Header` property defines the content displayed in the top section of the component. It typically serves as a title bar or introductory element that summarizes or labels the component’s purpose.",
                "Header = _ => \"Header\"",
                new ControlPanelCard()
                {
                    Header = _ => "Header",
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a specified header text." })
            );

            Stage.AddProperty
            (
                "HeaderImage",
                "The `HeaderImage` property specifies an image resource that is displayed in the top section of the component. It enhances visual appeal and can provide contextual, thematic, or branding value.",
                "HeaderImage = _ => applicationContext.Route.Concat(\"/assets/img/ufo.png\").ToUri()",
                new ControlPanelCard()
                {
                    Header = _ => "Header",
                    HeaderImage = _ => applicationContext.Route.Concat("/assets/img/ufo.png").ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a specified header text." })
            );

            Stage.AddProperty
            (
                "Headline",
                "The `Headline` property defines a prominent title element that draws the user's attention and communicates the primary message or purpose of the component at a glance.",
                "Headline = _ => \"Headline\"",
                new ControlPanelCard()
                {
                    Headline = _ => "Headline",
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a specified headline text." })
            );

            Stage.AddProperty
            (
                "Footer",
                "The `Footer` property defines the content area displayed at the bottom of the component. It is typically used to present supplementary information or actionable elements that relate to the overall content.",
                "Footer = _ => \"Footer\"",
                new ControlPanelCard()
                {
                    Footer = _ => "Footer",
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a specified footer text." })
            );

            Stage.AddProperty
            (
                "FooterImage",
                "The `Footer` property defines the content area displayed at the bottom of the component. It is typically used to present supplementary information or actionable elements that relate to the overall content.",
                "FooterImage = _ => applicationContext.Route.Concat(\"/assets/img/ufo.png\").ToUri()",
                new ControlPanelCard()
                {
                    Footer = _ => "Footer",
                    FooterImage = _ => applicationContext.Route.Concat("/assets/img/ufo.png").ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a specified footer text." })
            );
        }
    }
}
