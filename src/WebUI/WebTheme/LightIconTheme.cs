using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebIcon;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// A tutorial theme used to demonstrate the light icon set. It carries
    /// the <c>[IconTheme(TypeIconTheme.Light)]</c> declaration so the icon
    /// theme picker on <see cref="WebApp.WebPage.VisualTreeWebApp"/> emits
    /// <c>&lt;html data-icon-theme="light"&gt;</c> and the JS / server icon
    /// resolution switches to the lightweight SVG variants shipped via
    /// <c>webexpress.webui.icon.css</c>.
    ///
    /// The theme is intentionally minimal - no <c>[ThemeStyle]</c> override
    /// is declared so the framework default css stays in place; the only
    /// observable effect is the icon swap.
    /// </summary>
    [Name("webexpress.Tutorial.webui:theme.lighticon.name")]
    [Description("webexpress.Tutorial.webui:theme.lighticon.description")]
    [IconTheme(TypeIconTheme.Light)]
    public sealed class LightIconTheme : IThemeWebApp
    {
    }
}
