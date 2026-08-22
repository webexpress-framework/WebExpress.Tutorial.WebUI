using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the icon control for the tutorial.  
    /// </summary>  
    [WebIcon<IconControlIcon>]
    [Title("Icon")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Icon : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the icon control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public Icon(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            var icons = GetAllIcons();

            Stage.Description = @"The ControlIcon is a versatile feature designed to display visual elements either sourced from a system-defined icon library or customized to fit specific needs. By offering seamless integration of both standard and personalized images, it enhances the visual appeal and functionality of applications.";

            // each icon is shown with the symbolic name below it, because that name is what
            // a caller actually types; the class name stays on the tooltip
            // the gallery is long, and the only way to judge a drawing is to see it at the
            // size it will be used; the slider drives a custom property that both the icon
            // and the tile width read, so the grid reflows instead of overlapping
            // the page renders Stage.Controls twice - live and as an html listing - so nothing
            // here may depend on an id being unique or on the element existing at parse time
            var sizeControl = new ControlText()
            {
                Format = _ => TypeFormatText.Raw,
                Text = _ => @"<style>
.wx-gallery { display: flex; flex-wrap: wrap; align-items: flex-start; gap: .25rem; }
.wx-gallery-tile {
    display: flex; flex-direction: column; align-items: center; justify-content: flex-start;
    gap: .4rem; padding: .55rem .2rem; text-align: center; font-size: .62rem;
    line-height: 1.15; word-break: break-word;
    width: calc(var(--wx-gallery-size, 20px) + 4rem);
}
.wx-gallery-icon { font-size: var(--wx-gallery-size, 20px) !important; }
.wx-gallery-sizer { display: flex; align-items: center; gap: .75rem; margin: 0 0 1.25rem; }
.wx-gallery-sizer output { font-variant-numeric: tabular-nums; min-width: 3.5em; }
</style>
<div class=""wx-gallery-sizer"">
  <label for=""wxGallerySize"">Size</label>
  <input type=""range"" id=""wxGallerySize"" data-wx-gallery-size min=""12"" max=""72"" step=""2"" value=""20"">
  <output data-wx-gallery-size-out>20 px</output>
</div>
<script>
(function () {
    if (window.wxGallerySizerReady) { return; }
    window.wxGallerySizerReady = true;

    var apply = function (px) {
        document.documentElement.style.setProperty(""--wx-gallery-size"", px + ""px"");
        document.querySelectorAll(""[data-wx-gallery-size-out]"").forEach(function (o) { o.textContent = px + "" px""; });
        document.querySelectorAll(""[data-wx-gallery-size]"").forEach(function (i) { i.value = px; });
        try { localStorage.setItem(""wx-gallery-size"", px); } catch (e) { }
    };

    // delegated, so it works no matter when the slider enters the dom
    document.addEventListener(""input"", function (e) {
        if (e.target && e.target.matches && e.target.matches(""[data-wx-gallery-size]"")) { apply(e.target.value); }
    });

    var saved = null;
    try { saved = localStorage.getItem(""wx-gallery-size""); } catch (e) { }
    apply(saved || 20);
})();
</script>"
            };

            var tiles = icons.Select(x => (IControl)new ControlPanel
            (
                null,
                new ControlIcon()
                {
                    Icon = _ => x,
                    TextColor = _ => new PropertyColorText(TypeColorText.Info),
                    Title = _ => x.GetType().Name,
                    Classes = ["wx-gallery-icon"]
                },
                new ControlText()
                {
                    Text = _ => (x as WebExpress.WebUI.WebIcon.Icon)?.Symbol ?? x.GetType().Name,
                    Format = _ => TypeFormatText.Small
                }
            )
            {
                Classes = ["wx-gallery-tile"]
            }).ToArray();

            // one container holds every tile, so the grid does not depend on how the stage
            // happens to wrap its direct children
            Stage.Controls = [sizeControl, new ControlPanel(null, tiles) { Classes = ["wx-gallery"] }];

            Stage.Code = @"
            new ControlIcon() 
            { 
                Icon = _ =>new IconClone(), 
                TextColor = _ => new PropertyColorText(TypeColorText.Info), 
                Title = _ => \""IconClone\"" 
            };";

            // the swapped drawings of the Monkey Island theme, shown next to the defaults so the
            // mechanism is visible without having to activate the theme first
            var monkeyBase = pageContext?.ApplicationContext?.Route?.Concat("assets/icons/monkeyisland")?.ToString();
            var monkeyNames = new[] { "home", "user", "magnifying-glass", "gear", "star", "envelope", "bookmark", "check" };

            var monkeyStyle = "<style>"
                + ".wx-mi-demo{display:flex;flex-wrap:wrap;gap:1.25rem}"
                + ".wx-mi-pair{display:flex;flex-direction:column;align-items:center;gap:.4rem;font-size:.62rem}"
                + ".wx-mi-row{display:flex;align-items:center;gap:.5rem}"
                + ".wx-mi-row i{font-size:1.6rem}"
                + ".wx-mi-arrow{opacity:.45}"
                + ".wx-mi{display:inline-block;width:1.6rem;height:1.6rem;background-color:currentColor;"
                + "-webkit-mask-size:contain;mask-size:contain;-webkit-mask-repeat:no-repeat;mask-repeat:no-repeat;"
                + "-webkit-mask-position:center;mask-position:center}"
                + string.Concat(monkeyNames.Select(x =>
                    ".wx-mi-" + x + "{-webkit-mask-image:url('" + monkeyBase + "/" + x + ".svg');"
                    + "mask-image:url('" + monkeyBase + "/" + x + ".svg')}"))
                + "</style>";

            var monkeyDemo = "<div class='wx-mi-demo'>"
                + string.Concat(monkeyNames.Select(x =>
                    "<div class='wx-mi-pair'><div class='wx-mi-row'>"
                    + "<i class='wx-icon-light wx-icon-light-" + x + "'></i>"
                    + "<span class='wx-mi-arrow'>&rarr;</span>"
                    + "<span class='wx-mi wx-mi-" + x + "'></span>"
                    + "</div><span>" + x + "</span></div>"))
                + "</div>";

            Stage.AddProperty
            (
                "Icon theme",
                "An icon is drawn by a css mask that a class selects. A theme can point that class at a different "
                + "drawing, and every control that already asks for the class follows - without knowing the theme "
                + "exists and without a line of control code. The Monkey Island theme of this tutorial does exactly "
                + "that for eight everyday icons: the house becomes an island, the cog a ship's wheel, the magnifier "
                + "a spyglass. One catch: a theme stylesheet replaces the framework default instead of adding to it, "
                + "so it has to import the framework sheet before overriding anything.",
                "[ThemeStyle(\"assets/css/monkeyisland.icon.css\")]",
                new ControlText()
                {
                    Format = _ => TypeFormatText.Raw,
                    Text = _ => monkeyStyle + monkeyDemo
                }
            );

            Stage.AddProperty
            (
               "Icon (System)",
               "Adds a system icon.",
               "Icon = _ => new IconHome()",
               new ControlIcon()
               {
                   Icon = _ => new IconHome(),
                   Title = _ => "Home",
                   Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                   TextColor = _ => new PropertyColorText(TypeColorText.Warning)
               }
            );

            Stage.AddProperty
            (
               "Icon (Custom)",
               "Adds a custom icon.",
               "Icon = _ => new ImageIcon(pageContext.ApplicationContext.ContextPath.Concat(\"assets/img/webui.svg\").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em))",
               new ControlIcon()
               {
                   Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                   Title = _ => "Custom",
                   Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                   TextColor = _ => new PropertyColorText(TypeColorText.Primary)
               }
            );

            Stage.AddProperty
            (
                "Size",
                "Sets the size of the icon.",
                "Size = _ => new PropertySizeText(TypeSizeText.Small)",
                new ControlText() { Text = _ => "Extra Small", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Extra Small",
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraSmall),
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Small", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Small",
                    Size = _ => new PropertySizeText(TypeSizeText.Small),
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Standard", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Standard",
                    Size = _ => new PropertySizeText(TypeSizeText.Default),
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Large", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Large",
                    Size = _ => new PropertySizeText(TypeSizeText.Large),
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Extra Large", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Extra Large",
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraLarge),
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Custom", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Custom",
                    Size = _ => new PropertySizeText(3.1f),
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Sets the color of the text, but it only affects system icons. Custom icons are not influenced by this property, as their appearance is determined by the original image design.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Default", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Default",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Primary", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Primary",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Secondary", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Secondary",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Secondary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Info", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Info",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Success", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Success",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Warning", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Warning",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Warning),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Danger", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Danger",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Light", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Light",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Light),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Dark", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Dark",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Muted", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Muted",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Muted),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "White", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "White",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = _ => "Custom", Format = _ => TypeFormatText.Span, TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = _ => "Custom",
                    Icon = _ => new IconHome(),
                    TextColor = _ => new PropertyColorText("gold"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color.",
                "BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)",
                [.. GetAllIcons().Take(5).Select(x => new ControlIcon()
                {
                    Icon = _ => x,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Three),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                })]
            );

            Stage.AddProperty
            (
                "Title",
                "Specifies a text to be displayed as a tooltip.",
                "Title = _ => \"Hello World!\"",
                [.. GetAllIcons().Take(5).Select(x => new ControlIcon()
                {
                    Icon =_ =>  x,
                    Title = _ => x.GetType().Name,
                    Margin =_ =>  new PropertySpacingMargin(PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger),
                })]
            );
        }

        /// <summary>
        /// Retrieves all icon types from the namespace "WebExpress.WebUI.WebIcon" and creates instances.
        /// </summary>
        /// <returns>A list of instantiated icons.</returns>
        private static IEnumerable<IIcon> GetAllIcons()
        {
            var iconType = typeof(WebExpress.WebUI.WebIcon.Icon);
            var assembly = Assembly.GetAssembly(iconType);

            return assembly.GetTypes()
                .Where(t => iconType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IIcon>();
        }
    }
}
