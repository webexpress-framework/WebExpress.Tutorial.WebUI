using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Provides airy surfaces and seaside summer accents through shared control tokens.
    /// </summary>
    [Name("webexpress.tutorial.webui:theme.summer.name")]
    [Description("webexpress.tutorial.webui:theme.summer.description")]
    [ThemeMode(ThemeMode.Light)]
    [ThemeStyle("assets/css/summer.theme.css")]
    public sealed class SummerTheme : IThemeWebApp
    {
    }
}
