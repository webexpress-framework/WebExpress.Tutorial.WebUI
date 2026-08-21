using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// A tutorial theme used to demonstrate theme switching. It declares the light colour
    /// scheme so the picker on the theme page has a visible effect without shipping a
    /// stylesheet of its own.
    /// </summary>
    [Name("webexpress.Tutorial.webui:theme.lightmode.name")]
    [Description("webexpress.Tutorial.webui:theme.lightmode.description")]
    [ThemeMode(ThemeMode.Light)]
    public sealed class LightModeTheme : IThemeWebApp
    {
    }
}
