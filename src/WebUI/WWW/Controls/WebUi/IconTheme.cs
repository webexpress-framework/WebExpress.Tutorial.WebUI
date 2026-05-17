using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WebTheme;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebTheme;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Demonstrates how a page can swap the active theme to the
    /// <see cref="LightIconTheme"/> so the lightweight SVG icon set kicks
    /// in. The page calls <c>visualTree.UseTheme&lt;LightIconTheme&gt;()</c>
    /// before the base content is rendered; this propagates to:
    /// <list type="bullet">
    ///   <item><description>
    ///     <c>&lt;html data-icon-theme="light"&gt;</c> on the rendered root, so JS controls
    ///     (modal close, sidebar, etc.) pick the light variants up via
    ///     <c>webexpress.webui.IconTheme.current()</c>.
    ///   </description></item>
    ///   <item><description>
    ///     Server-rendered icons that take <c>renderContext.GetIconTheme()</c>
    ///     emit <c>wx-icon-light wx-icon-light-*</c> instead of FontAwesome.
    ///   </description></item>
    /// </list>
    /// The page is otherwise a regular tutorial page - constructor sets up
    /// the description, the showcase controls and the snippet; the override
    /// just inserts the theme switch.
    /// </summary>
    [Title("IconTheme")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class IconTheme : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public IconTheme()
        {
            Stage.Description = @"WebExpress ships two icon sets:

* **Default** - the FontAwesome glyph font used out of the box (`fas fa-*`).
* **Light** - the lightweight SVG variants defined in `webexpress.webui.icon.css` (`wx-icon-light wx-icon-light-*`).

Which set is active is decided by the **theme** attached to the request. A theme declares its preference with `[IconTheme(TypeIconTheme.Light)]`; the chosen theme then surfaces through `IApplicationContext.DefaultTheme` (set declaratively via `[Theme<TTheme>]` on the application class) **or** through a per-request override:

```csharp
public override void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
{
    visualTree.UseTheme<LightIconTheme>();   // <- swap to a theme carrying [IconTheme(Light)]
    base.Process(renderContext, visualTree);
}
```

This page calls `UseTheme<LightIconTheme>()` in its `Process` override. As a result, the example controls below render their icons with the light SVG masks, and the root `<html>` element carries `data-icon-theme=""light""`, which the JS controls (modal close, search-bar clear, etc.) pick up automatically. The framework still falls back to FontAwesome for any icon the light set does not ship.";

            Stage.Controls =
            [
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
                            Icon = renderContext => new IconHome(renderContext.GetIconTheme()),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        },
                        new ControlButton()
                        {
                            Text = _ => "New",
                            Icon = renderContext => new IconPlus(renderContext.GetIconTheme()),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        },
                        new ControlButton()
                        {
                            Text = _ => "Edit",
                            Icon = renderContext => new IconPen(renderContext.GetIconTheme()),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Secondary),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        },
                        new ControlButton()
                        {
                            Text = _ => "Delete",
                            Icon = renderContext => new IconTrash(renderContext.GetIconTheme()),
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                            Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                        }
                    ),
                new ControlAlert("themeNotice")
                {
                    Head = _ => "Light icon theme active",
                    Text = _ => "The buttons above were rendered with the light SVG icons because the visual tree was switched to LightIconTheme at the start of Process.",
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Info),
                    Dismissibility = _ => TypeDismissibilityAlert.Dismissible
                }
            ];

            Stage.Code = @"
            // 1. Declare a theme that opts into the light icon set:
            [Name(""LightIconTheme"")]
            [IconTheme(TypeIconTheme.Light)]
            public sealed class LightIconTheme : IThemeWebApp { }

            // 2. Override Process on the tutorial page to swap the active theme:
            public override void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
            {
                visualTree.UseTheme<LightIconTheme>();
                base.Process(renderContext, visualTree);
            }

            // 3. Build the showcase controls; icons read the current theme so
            //    server-rendered glyphs render with the light SVG masks:
            new ControlButton
            {
                Text = _ => ""Home"",
                Icon = renderContext => new IconHome(renderContext.GetIconTheme()),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
            };";

            Stage.AddProperty
            (
                "Default theme via [Theme<TTheme>]",
                "An application can declare its default theme declaratively. The theme - and therefore its icon-theme preference - is picked up automatically by every visual tree; no per-page `UseTheme<>` call is needed.",
                @"[Theme<LightIconTheme>]
public sealed class MyApplication : IApplication { }",
                new ControlText()
                {
                    Text = _ => "When the application carries `[Theme<LightIconTheme>]`, every page of that application renders with the light icon set out of the box. The per-page `UseTheme<>` API only needs to be invoked when a single page wants a *different* theme than the application default.",
                    Format = _ => TypeFormatText.Markdown
                }
            );

            Stage.AddProperty
            (
                "Resolution order",
                "The visual tree picks the active theme in the following order: 1) the theme passed via `UseTheme<TTheme>()`, 2) the application's declared `[Theme<TTheme>]`, 3) the first theme registered for the application (legacy fallback), 4) none - icon theme falls back to `TypeIconTheme.Default`.",
                string.Empty,
                new ControlText()
                {
                    Text = _ => "Both the JS side (`<html data-icon-theme=\"...\">` → `webexpress.webui.IconTheme.current()`) and the server side (`renderContext.GetIconTheme()`) read from the same resolved theme, so the choice is consistent across all icons on the page.",
                    Format = _ => TypeFormatText.Markdown
                }
            );
        }

        /// <summary>
        /// Switches the visual tree to <see cref="LightIconTheme"/> before
        /// the default tutorial rendering runs. The override is the entire
        /// point of this page - it is the single hook the framework offers
        /// to demonstrate <c>UseTheme&lt;TTheme&gt;()</c> in a controlled
        /// way without affecting the rest of the tutorial.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public override void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.UseTheme<LightIconTheme>();
            base.Process(renderContext, visualTree);
        }
    }
}
