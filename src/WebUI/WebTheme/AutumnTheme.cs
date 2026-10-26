using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Provides warm pastel surfaces and autumn accents through shared control tokens.
    /// </summary>
    [Name("webexpress.tutorial.webui:theme.autumn.name")]
    [Description("webexpress.tutorial.webui:theme.autumn.description")]
    [ThemeMode(ThemeMode.Light)]
    [ThemeStyle("assets/css/autumn.theme.css")]
    public sealed class AutumnTheme : IThemeWebApp
    {
    }
}
