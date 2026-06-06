using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WebTheme;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Demonstrates the runtime theme picker. The page hosts a
    /// <see cref="ControlDataSelectionTheme"/> wired to the tutorial's
    /// <see cref="ThemeApi"/> endpoint, and a row of icon-bearing controls
    /// that re-render with the icon set of the chosen theme.
    /// <para>
    /// Choosing an entry in the selector PUTs <c>v=&lt;themeId&gt;</c> to the
    /// REST endpoint. The endpoint (a tutorial-side subclass of
    /// <see cref="WebApp.WebRestApi.RestApiTheme"/>) writes the value to
    /// <see cref="ThemeStore"/> - in-memory user-defined storage. The JS
    /// layer reloads the page; on the next request <see cref="Process"/>
    /// reads from the same store and calls
    /// <c>visualTree.UseTheme&lt;TTheme&gt;()</c> so the visual tree adopts
    /// the chosen theme. Server-side icons resolved against the chosen
    /// theme show through the same <see cref="ThemeStore"/> lookup.
    /// </para>
    /// </summary>
    [Title("DataSelectionTheme")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataSelectionTheme : PageControl
    {
        private readonly IPageContext _pageContext;
        private readonly ISitemapManager _sitemapManager;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager used to resolve the ThemeApi uri.</param>
        public DataSelectionTheme(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            _pageContext = pageContext;
            _sitemapManager = sitemapManager;

            Stage.Description = @"WebExpress ships two icon sets:

* **Default** - the FontAwesome glyph font used out of the box (`fas fa-*`).
* **Light** - the lightweight SVG variants defined in `webexpress.webui.icon.css` (`wx-icon-light wx-icon-light-*`).

The set in effect is decided by the **theme** attached to the request. A theme declares its preference with `[IconTheme(TypeIconTheme.Light)]`; the resolved theme is then picked up automatically by `VisualTreeWebApp` (which emits `<html data-icon-theme=""..."">`) and by server-side icon factories (`renderContext.GetIconTheme()`).

The selector below uses **`ControlDataSelectionTheme`** - a REST-backed picker that lists the themes registered for the current application via the tutorial's `ThemeApi` endpoint. Picking an entry calls the tutorial's `ThemeApi`, which writes the value into a user-defined `ThemeStore`; the page's `Process` override reads the same store on the next request and informs the visual tree via `visualTree.UseTheme<TTheme>()`. Try toggling between `DefaultIconTheme` and `LightIconTheme` - the four buttons below swap between FontAwesome and the light SVG glyphs.";

            Stage.Controls =
            [
                // ControlDataSelectionTheme is a standalone dropdown that
                // shows the active theme as its label and always keeps
                // exactly one entry selected; no surrounding form is needed.
                new ControlDataSelectionTheme("themeSelector")
                {
                    RestUri = _ => _sitemapManager.GetUri<ThemeApi>(_pageContext?.ApplicationContext),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Three, PropertySpacing.Space.None)
                },
                new ControlPanelFlex()
                {
                    Direction = _ => TypeDirection.Horizontal,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add
                    (
                        new ControlButton()
                        {
                            Text = _ => "Home",
                            Icon = _ => new IconHome(),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        },
                        new ControlButton()
                        {
                            Text = _ => "New",
                            Icon = _ => new IconPlus(),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        },
                        new ControlButton()
                        {
                            Text = _ => "Edit",
                            Icon = _ => new IconPen(),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Secondary),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        },
                        new ControlButton()
                        {
                            Text = _ => "Delete",
                            Icon = _ => new IconTrash(),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        }
                    )
            ];

            Stage.Code = @"
            // 1. Declare a theme that opts into the light icon set:
            [Name(""LightIconTheme"")]
            [IconTheme(TypeIconTheme.Light)]
            public sealed class LightIconTheme : IThemeWebApp { }

            // 2. Hold the per-client selection somewhere the application
            //    controls - here, a static dictionary keyed by remote IP:
            public static class ThemeStore
            {
                private static readonly ConcurrentDictionary<string, string> _selections = new();
                public static string Get(IRequest r) => _selections.TryGetValue(Key(r), out var v) ? v : null;
                public static void Set(IRequest r, string v) { _selections[Key(r)] = v; }
                private static string Key(IRequest r) => r?.RemoteEndPoint?.Address?.ToString();
            }

            // 3. Subclass RestApiTheme so its persistence hooks talk to
            //    the application's own store:
            [Title(""Theme Selector"")]
            public sealed class ThemeApi : RestApiTheme
            {
                protected override string GetActiveThemeId(IQueryContext c, IRequest r) => ThemeStore.Get(r);
                protected override void PersistSelection(string v, IQueryContext c, IRequest r) => ThemeStore.Set(r, v);
            }

            // 4. Drop the standalone dropdown onto the page wired to the
            //    endpoint - no surrounding ControlForm is required:
            new ControlDataSelectionTheme(""themeSelector"")
            {
                RestUri = _ => sitemapManager.GetUri<ThemeApi>(applicationContext)
            };

            // 5. On every render, read the stored selection and hand it to
            //    the visual tree so it picks the right theme:
            public override void Process(IRenderContext ctx, VisualTreeWebApp visualTree)
            {
                if (ThemeStore.Get(ctx.Request) == typeof(LightIconTheme).FullName?.ToLower())
                    visualTree.UseTheme<LightIconTheme>();
                else
                    visualTree.UseTheme<DefaultIconTheme>();
                base.Process(ctx, visualTree);
            }";

            Stage.AddProperty
            (
                "Default theme via [Theme<TTheme>]",
                "An application can declare its default theme declaratively. The theme - and therefore its icon-theme preference - is picked up automatically by every visual tree; no per-page `UseTheme<>` call is needed. User-side persistence (as demonstrated here) overrides that default for the current user.",
                @"[Theme<LightIconTheme>]
public sealed class MyApplication : IApplication { }",
                new ControlText()
                {
                    Text = _ => "When the application carries `[Theme<LightIconTheme>]`, every page of that application renders with the light icon set out of the box. The per-page `UseTheme<>` call (wired from a user-defined store) overrides the application default.",
                    Format = _ => TypeFormatText.Markdown
                }
            );

            Stage.AddProperty
            (
                "Resolution order",
                "The visual tree picks the active theme in the following order: 1) the explicit override `visualTree.UseTheme<TTheme>()` (typically called from the page's `Process` override using whatever the application stored), 2) the application's declared `[Theme<TTheme>]`, 3) the first theme registered for the application (legacy fallback), 4) none - icon theme falls back to `TypeIconTheme.Default`. The framework deliberately does NOT consult cookies, sessions, or identities - persistence belongs to the application.",
                string.Empty,
                new ControlText()
                {
                    Text = _ => "Both the JS side (`<html data-icon-theme=\"...\">` → `webexpress.webui.IconTheme.current()`) and the server side (controls that pass the resolved theme into their icons) read from the same `visualTree.Theme`, so the choice is consistent across all icons on the page.",
                    Format = _ => TypeFormatText.Markdown
                }
            );
        }

        /// <summary>
        /// Reads the stored selection from <see cref="ThemeStore"/> and
        /// activates the matching theme on <paramref name="visualTree"/>
        /// before delegating to the default rendering pipeline. The icons
        /// embedded in <see cref="Stage.Controls"/> consult the same store
        /// through <see cref="ResolveIconTheme"/>.
        /// </summary>
        /// <param name="renderContext">The render context.</param>
        /// <param name="visualTree">The visual tree to swap.</param>
        public override void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var stored = ThemeStore.Get(renderContext?.Request);
            if (string.Equals(stored, typeof(LightIconTheme).FullName?.ToLower(), System.StringComparison.OrdinalIgnoreCase))
            {
                visualTree.UseTheme<LightIconTheme>();
            }
            else if (string.Equals(stored, typeof(DefaultIconTheme).FullName?.ToLower(), System.StringComparison.OrdinalIgnoreCase))
            {
                visualTree.UseTheme<DefaultIconTheme>();
            }

            base.Process(renderContext, visualTree);
        }

    }
}
