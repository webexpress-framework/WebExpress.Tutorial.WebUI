using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the canvas control for the tutorial.
    /// </summary>
    [WebIcon<IconControlCanvas>]
    [Title("Canvas")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Canvas : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the canvas control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public Canvas(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Canvas` control provides a raw drawing surface. It renders an empty `canvas` element and leaves the painting to JavaScript, which makes it the foundation for custom visualizations - diagrams, signatures, image processing - that no dedicated control covers. Give the control an id to address it from a script, and size it through the layout properties.";

            Stage.Control = new ControlCanvas("example")
            {
                BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                Styles = ["width: 20em; height: 10em;"]
            };

            Stage.Code = @"
                new ControlCanvas(""example"")
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                    Styles = [""width: 20em; height: 10em;""]
                };";

            Stage.AddProperty
            (
                "Styles",
                "Sizes the drawing surface. A canvas has no intrinsic size, so without an explicit width and height the browser falls back to its default of 300 × 150 pixels.",
                "Styles = [\"width: 20em; height: 10em;\"]",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCanvas()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Sized", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCanvas()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                    Styles = ["width: 30em; height: 6em;"]
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Defines the background color of the drawing surface. Everything a script paints is drawn on top of it.",
                "BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light)",
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCanvas()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                    Styles = ["width: 20em; height: 5em;"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCanvas()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark),
                    Styles = ["width: 20em; height: 5em;"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCanvas()
                {
                    BackgroundColor = _ => new PropertyColorBackground("gold"),
                    Styles = ["width: 20em; height: 5em;"]
                }
            );

            Stage.AddProperty
            (
                "Border",
                "Frames the drawing surface, which makes the otherwise invisible bounds of an empty canvas apparent.",
                "Border = _ => new PropertyBorder(true)",
                new ControlCanvas()
                {
                    Border = _ => new PropertyBorder(true),
                    Styles = ["width: 20em; height: 5em;"]
                }
            );
        }
    }
}
