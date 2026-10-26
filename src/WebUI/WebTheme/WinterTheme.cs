using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Provides seasonal winter surfaces and accents through shared control tokens.
    /// </summary>
    [Name("webexpress.tutorial.webui:theme.winter.name")]
    [Description("webexpress.tutorial.webui:theme.winter.description")]
    [ThemeMode(ThemeMode.Light)]
    [ThemeStyle("assets/css/winter.theme.css")]
    public sealed class WinterTheme : IThemeWebApp
    {
    }
}
