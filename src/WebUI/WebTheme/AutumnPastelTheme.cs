using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Provides warm pastel surfaces and autumn accents through shared control tokens.
    /// </summary>
    [Name("webexpress.tutorial.webui:theme.autumnpastel.name")]
    [Description("webexpress.tutorial.webui:theme.autumnpastel.description")]
    [ThemeMode(ThemeMode.Light)]
    [ThemeStyle("assets/css/autumnpastel.theme.css")]
    public sealed class AutumnPastelTheme : IThemeWebApp
    {
    }
}
