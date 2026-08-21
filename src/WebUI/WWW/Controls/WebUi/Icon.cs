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

            Stage.Controls = [.. icons.Select(x => new ControlIcon()
            {
                Icon = _ =>x,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                TextColor = _ => new PropertyColorText(TypeColorText.Info),
                Title = _ =>x.GetType().Name,
            })];

            Stage.Code = @"
            new ControlIcon() 
            { 
                Icon = _ =>new IconClone(), 
                TextColor = _ => new PropertyColorText(TypeColorText.Info), 
                Title = _ => \""IconClone\"" 
            };";

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
