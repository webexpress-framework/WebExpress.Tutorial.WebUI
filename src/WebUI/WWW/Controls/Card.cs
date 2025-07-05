using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls
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
                .Add(new ControlText() { Text = "This is a sample card!" });

            Stage.Code = @"
            new ControlPanelCard()
            {
            }
                .Add(new ControlText() { Text = ""This is a sample card!"" });";

            Stage.AddProperty
            (
                "BackgroundColor",
                "The `BackgroundColor` property defines the background fill color of the component. It plays a key role in determining the visual appearance and helps visually separate the component from surrounding content or reinforce semantic meaning (e.g., success, warning, error).",
                "BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlPanelCard()
                {

                }
                    .Add(new ControlText() { Text = "Without specifying a background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The primary background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Secondary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The secondary background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Info),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The info background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The success background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The warning background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The danger background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark),
                    TextColor = new PropertyColorText(TypeColorText.White),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The dark background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The light background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.White),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The white background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Transparent),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The transparent background color." }),
                new ControlPanelCard()
                {
                    BackgroundColor = new PropertyColorBackground("gold"),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = "The custom background color." })
            );

            Stage.AddProperty
            (
                "Header",
                "The `Header` property defines the content displayed in the top section of the component. It typically serves as a title bar or introductory element that summarizes or labels the component’s purpose.",
                "Header = \"Header\"",
                new ControlPanelCard()
                {
                    Header = "Header",
                    TextColor = new PropertyColorText(TypeColorText.White),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = "With a specified header text." })
            );

            Stage.AddProperty
            (
                "HeaderImage",
                "The `HeaderImage` property specifies an image resource that is displayed in the top section of the component. It enhances visual appeal and can provide contextual, thematic, or branding value.",
                "HeaderImage = applicationContext.Route.Concat(\"/assets/img/rocket.png\").ToUri()",
                new ControlPanelCard()
                {
                    Header = "Header",
                    HeaderImage = applicationContext.Route.Concat("/assets/img/rocket.png").ToUri(),
                    TextColor = new PropertyColorText(TypeColorText.White),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = "With a specified header text." })
            );

            Stage.AddProperty
            (
                "Headline",
                "The `Headline` property defines a prominent title element that draws the user's attention and communicates the primary message or purpose of the component at a glance.",
                "Headline = \"Headline\"",
                new ControlPanelCard()
                {
                    Headline = "Headline",
                    TextColor = new PropertyColorText(TypeColorText.White),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = "With a specified headline text." })
            );

            Stage.AddProperty
            (
                "Footer",
                "The `Footer` property defines the content area displayed at the bottom of the component. It is typically used to present supplementary information or actionable elements that relate to the overall content.",
                "Footer = \"Footer\"",
                new ControlPanelCard()
                {
                    Footer = "Footer",
                    TextColor = new PropertyColorText(TypeColorText.White),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = "With a specified footer text." })
            );

            Stage.AddProperty
            (
                "FooterImage",
                "The `Footer` property defines the content area displayed at the bottom of the component. It is typically used to present supplementary information or actionable elements that relate to the overall content.",
                "FooterImage = applicationContext.Route.Concat(\"/assets/img/rocket.png\").ToUri()",
                new ControlPanelCard()
                {
                    Footer = "Footer",
                    FooterImage = applicationContext.Route.Concat("/assets/img/rocket.png").ToUri(),
                    TextColor = new PropertyColorText(TypeColorText.White),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = "With a specified footer text." })
            );
        }
    }
}
