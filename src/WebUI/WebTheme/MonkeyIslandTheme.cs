using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// A tutorial theme that reskins part of the icon set without touching a single control.
    /// </summary>
    /// <remarks>
    /// Icons are applied as css masks selected by class, so a theme can point a class at a
    /// different drawing and every control that already asks for it follows. This theme does
    /// that for eight everyday icons - the house becomes an island, the cog a ship's wheel,
    /// the magnifier a spyglass - and changes nothing else.
    /// <para>
    /// The stylesheet named here replaces the framework default instead of adding to it,
    /// which is why <c>monkeyisland.icon.css</c> imports the framework sheet on its first
    /// line before overriding anything.
    /// </para>
    /// </remarks>
    [Name("webexpress.Tutorial.webui:theme.monkeyisland.name")]
    [Description("webexpress.Tutorial.webui:theme.monkeyisland.description")]
    [ThemeMode(ThemeMode.Light)]
    [ThemeStyle("assets/css/monkeyisland.icon.css")]
    public sealed class MonkeyIslandTheme : IThemeWebApp
    {
    }
}
