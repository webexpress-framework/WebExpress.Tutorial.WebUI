using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// The framework's own colours, light or dark like every other colour scheme of the tutorial.
    /// </summary>
    /// <remarks>
    /// It ships no stylesheet, so the framework palette applies in both modes. The declared
    /// mode is only the default for a visitor who has not chosen light or dark.
    /// </remarks>
    [Name("webexpress.tutorial.webui:theme.standard.name")]
    [Description("webexpress.tutorial.webui:theme.standard.description")]
    [ThemeMode(ThemeMode.Light)]
    public sealed class StandardTheme : IThemeWebApp
    {
    }
}
