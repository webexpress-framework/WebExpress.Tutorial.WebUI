using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebIcon;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// Companion to <see cref="LightIconTheme"/> that opts back into the
    /// default FontAwesome glyph set, declared explicitly so the theme
    /// selector on the tutorial page has more than one option and the
    /// user can freely toggle between the two icon sets.
    /// </summary>
    [Name("webexpress.Tutorial.webui:theme.defaulticon.name")]
    [Description("webexpress.Tutorial.webui:theme.defaulticon.description")]
    [IconTheme(TypeIconTheme.Default)]
    public sealed class DefaultIconTheme : IThemeWebApp
    {
    }
}
