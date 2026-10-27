using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTheme;

namespace WebExpress.Tutorial.WebUI.WebTheme
{
    /// <summary>
    /// A tutorial colour scheme in the sixteen EGA colours of Monkey Island 1, with the pirate
    /// drawings, reskinning the application without touching a single control.
    /// </summary>
    /// <remarks>
    /// Colours are tokens and icons are css masks selected by class, so a stylesheet can
    /// redefine both and every control follows. The dark mode is night on Melee Island -
    /// black, the blue sky, cyan and magenta - and the default, since that is the picture the
    /// game is remembered by; the light mode is white with EGA blue. Twenty everyday icons
    /// become pirate motifs: the house an island, the cog a ship's wheel, the lock a chest.
    /// <para>
    /// The stylesheet named here replaces the framework default instead of adding to it,
    /// which is why <c>monkeyisland.theme.css</c> imports the framework sheet on its first
    /// line before overriding anything.
    /// </para>
    /// </remarks>
    [Name("webexpress.tutorial.webui:theme.monkeyisland.name")]
    [Description("webexpress.tutorial.webui:theme.monkeyisland.description")]
    [ThemeMode(ThemeMode.Dark)]
    [ThemeStyle("assets/css/monkeyisland.theme.css")]
    public sealed class MonkeyIslandTheme : IThemeWebApp
    {
    }
}
