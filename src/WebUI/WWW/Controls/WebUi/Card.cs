using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

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
                "HeaderIcon",
                "The `HeaderIcon` property places an `IIcon` next to the header text. Any `IIcon` is accepted, so both image-based icons (such as `ImageIcon`) and CSS-based glyphs (such as the bundled FontAwesome icons) work the same way.",
                "HeaderIcon = _ => new ImageIcon(applicationContext.Route.Concat(\"/assets/img/ufo.png\").ToUri())",
                new ControlPanelCard()
                {
                    Header = _ => "Header",
                    HeaderIcon = _ => new ImageIcon(applicationContext.Route.Concat("/assets/img/ufo.png").ToUri()),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a header text and an image-based header icon." }),
                new ControlPanelCard()
                {
                    Header = _ => "Header",
                    HeaderIcon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "With a header text and a CSS-based header icon." })
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
                "FooterIcon",
                "The `FooterIcon` property places an `IIcon` next to the footer text. Like `HeaderIcon`, both image-based icons (`ImageIcon`) and CSS-based glyphs are supported.",
                "FooterIcon = _ => new ImageIcon(applicationContext.Route.Concat(\"/assets/img/ufo.png\").ToUri())",
                new ControlPanelCard()
                {
                    Footer = _ => "Footer",
                    FooterIcon = _ => new ImageIcon(applicationContext.Route.Concat("/assets/img/ufo.png").ToUri()),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add(new ControlText() { Text = _ => "With a footer text and an image-based footer icon." }),
                new ControlPanelCard()
                {
                    Footer = _ => "Footer",
                    FooterIcon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "With a footer text and a CSS-based footer icon." })
            );

            Stage.AddProperty
            (
                "HeaderBackgroundColor / HeaderTextColor",
                "The `HeaderBackgroundColor` and `HeaderTextColor` properties style the header row independently of the card body. They accept both system colors (`TypeColorBackground.*`, `TypeColorText.*`) and free-form CSS values such as `\"gold\"`.",
                "HeaderBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary), HeaderTextColor = _ => new PropertyColorText(TypeColorText.White)",
                new ControlPanelCard()
                {
                    Header = _ => "Primary",
                    HeaderBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary),
                    HeaderTextColor = _ => new PropertyColorText(TypeColorText.White)
                }
                    .Add(new ControlText() { Text = _ => "Header in primary, body untouched." }),
                new ControlPanelCard()
                {
                    Header = _ => "Danger",
                    HeaderIcon = _ => new IconHome(),
                    HeaderBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger),
                    HeaderTextColor = _ => new PropertyColorText(TypeColorText.White),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Header in danger with icon, body untouched." }),
                new ControlPanelCard()
                {
                    Header = _ => "Custom",
                    HeaderBackgroundColor = _ => new PropertyColorBackground("gold"),
                    HeaderTextColor = _ => new PropertyColorText("#222"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Header with a custom CSS color." })
            );

            Stage.AddProperty
            (
                "FooterBackgroundColor / FooterTextColor",
                "The `FooterBackgroundColor` and `FooterTextColor` properties style the footer row independently of the card body. Combine them with the header colors to create distinct banded cards.",
                "FooterBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success), FooterTextColor = _ => new PropertyColorText(TypeColorText.White)",
                new ControlPanelCard()
                {
                    Footer = _ => "Success",
                    FooterBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    FooterTextColor = _ => new PropertyColorText(TypeColorText.White)
                }
                    .Add(new ControlText() { Text = _ => "Footer in success, body untouched." }),
                new ControlPanelCard()
                {
                    Header = _ => "Status",
                    HeaderBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info),
                    HeaderTextColor = _ => new PropertyColorText(TypeColorText.White),
                    Footer = _ => "OK",
                    FooterBackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    FooterTextColor = _ => new PropertyColorText(TypeColorText.White),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Independently coloured header and footer." })
            );
        }
    }
}
