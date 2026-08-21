using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Companion to <see cref="LightModeTheme"/> declaring the dark colour scheme, so the
    /// theme selector has more than one option and the switch is observable on the page.
    /// </summary>
    [Name("webexpress.Tutorial.webui:theme.darkmode.name")]
    [Description("webexpress.Tutorial.webui:theme.darkmode.description")]
    [ThemeMode(ThemeMode.Dark)]
    public sealed class DarkModeTheme : IThemeWebApp
    {
    }
}
