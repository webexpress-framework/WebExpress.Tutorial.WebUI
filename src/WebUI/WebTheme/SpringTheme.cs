using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Provides seasonal spring surfaces and accents through shared control tokens.
    /// </summary>
    [Name("webexpress.tutorial.webui:theme.spring.name")]
    [Description("webexpress.tutorial.webui:theme.spring.description")]
    [ThemeMode(ThemeMode.Light)]
    [ThemeStyle("assets/css/spring.theme.css")]
    public sealed class SpringTheme : IThemeWebApp
    {
    }
}
