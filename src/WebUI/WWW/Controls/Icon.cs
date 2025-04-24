using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the icon control for the tutorial.  
    /// </summary>  
    [Title("Icon")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
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

            Stage.Controls = [.. icons.Select(x => new ControlIcon()
            {
                Icon = x,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                TextColor = new PropertyColorText(TypeColorText.Info),
                Title = x.GetType().Name,
            })];

            Stage.Code = @"
            new ControlIcon() 
            { 
                Icon = new IconClone(), 
                TextColor = new PropertyColorText(TypeColorText.Info), 
                Title = \""IconClone\"" 
            };";

            Stage.AddProperty
            (
               "Icon (System)",
               "Adds a system icon.",
               "Icon = new IconHome()",
               new ControlIcon()
               {
                   Icon = new IconHome(),
                   Title = "Home",
                   Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                   TextColor = new PropertyColorText(TypeColorText.Warning)
               }
            );

            Stage.AddProperty
            (
               "Icon (Custom)",
               "Adds a custom icon.",
               "Icon = new ImageIcon(pageContext.ApplicationContext.ContextPath.Concat(\"assets/img/webui.svg\").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em))",
               new ControlIcon()
               {
                   Icon = new ImageIcon(pageContext.ApplicationContext.ContextPath.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                   Title = "Custom",
                   Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                   TextColor = new PropertyColorText(TypeColorText.Primary)
               }
            );

            Stage.AddProperty
            (
                "Size",
                "Sets the size of the icon.",
                "Size = new PropertySizeText(TypeSizeText.Small)",
                new ControlText() { Text = "Extra Small", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Extra Small",
                    Size = new PropertySizeText(TypeSizeText.ExtraSmall),
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Small", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Small",
                    Size = new PropertySizeText(TypeSizeText.Small),
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Standard", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Standard",
                    Size = new PropertySizeText(TypeSizeText.Default),
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Large", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Large",
                    Size = new PropertySizeText(TypeSizeText.Large),
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Extra Large", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Extra Large",
                    Size = new PropertySizeText(TypeSizeText.ExtraLarge),
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Custom", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Custom",
                    Size = new PropertySizeText(3.1f),
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Sets the color of the text, but it only affects system icons. Custom icons are not influenced by this property, as their appearance is determined by the original image design.",
                "TextColor = new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Default", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Default",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Primary", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Primary",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Secondary", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Secondary",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Secondary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Info", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Info",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Info),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Success", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Success",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Success),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Warning", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Warning",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Warning),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Danger", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Danger",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Danger),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Light", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Light",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Light),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Dark", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Dark",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Muted", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Muted",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.Muted),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "White", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "White",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText(TypeColorText.White),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlText() { Text = "Custom", Format = TypeFormatText.Span, TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlIcon()
                {
                    Title = "Custom",
                    Icon = new IconHome(),
                    TextColor = new PropertyColorText("gold"),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color.",
                "BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)",
                [.. GetAllIcons().Take(5).Select(x => new ControlIcon()
                {
                    Icon = x,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Three),
                    TextColor = new PropertyColorText(TypeColorText.White),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                })]
            );

            Stage.AddProperty
            (
                "Title",
                "Specifies a text to be displayed as a tooltip.",
                "Title = \"Hello World!\"",
                [.. GetAllIcons().Take(5).Select(x => new ControlIcon()
                {
                    Icon = x,
                    Title = x.GetType().Name,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Danger),
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
