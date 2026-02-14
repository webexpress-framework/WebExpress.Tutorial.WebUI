using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the attribute control for the tutorial.    
    /// </summary>    
    [Title("Attribute")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Attribute : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the line control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Attribute(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Attribute` control displays a single attribute as a key-value pair, where the key represents the attribute name and the value its corresponding data.";

            Stage.Control = new ControlAttribute()
            {
                Key = "Example",
                Value = "This is an example of the ControlAttribute."
            };

            Stage.Code = @"
            new ControlAttribute()
            {
                Key = ""Example"",
                Value = ""This is an example of the ControlAttribute.""
            };";

            Stage.AddProperty
            (
                "Key",
                "Returns or sets the key of the attribute, representing the name or identifier in the key-value pair.",
                @"Key = ""Example""",
                new ControlAttribute()
                {
                    Key = "Example"
                }
            );

            Stage.AddProperty
           (
               "Value",
               "Returns or sets the value associated with the specified key.",
               @"Value = ""This is an example of the ControlAttribute.""",
               new ControlAttribute()
               {
                   Value = "This is an example of the ControlAttribute."
               }
           );

            Stage.AddProperty
            (
                "Color",
                "Sets the color of the property.",
                "Color = new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Default),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Primary),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Secondary),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Info),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Success),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Warning),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Danger),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Dark),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText(TypeColorText.Light),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = new PropertyColorText("gold"),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                }
            );

            Stage.AddProperty
            (
                "KeyColor",
                "Sets the color of the key property.",
                "KeyColor = new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Default),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Primary),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Secondary),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Info),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Success),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Warning),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Danger),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Dark),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText(TypeColorText.Light),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = new PropertyColorText("gold"),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute.",
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Returns or sets the background color of the attribute.",
                "BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Default"
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Primary",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Primary",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Info",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Success",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Warning",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Danger",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Dark",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Light",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = "Transparent", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Transparent",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = "Custom",
                    BackgroundColor = new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Returns or sets the icon associated with the attribute, typically used to visually represent the attribute's meaning or category.",
                @"
                new ControlAttribute()
                {
                    Icon = new IconHome()
                }",
                new ControlAttribute()
                {
                    Icon = new IconHome(),
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute."
                }
            );

            Stage.AddProperty
            (
                "Separator",
                "Returns or sets the character used to separate the key and value in the displayed attribute. Common separators include ':' or '='.",
                @"
                new ControlAttribute()
                {
                    Separator = '='
                }",
                new ControlAttribute()
                {
                    Separator = '=',
                    Key = "Example",
                    Value = "This is an example of the ControlAttribute."
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Returns or sets the URI associated with the attribute's value.",
                @"
                new ControlAttribute()
                {
                    Uri = pageContext.Route.ToUri()
                }",
                new ControlAttribute()
                {
                    Key = "With URI",
                    Value = "This is an example of the ControlAttribute.",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlAttribute()
                {
                    Key = "Without URI",
                    Value = "This is an example of the ControlAttribute."
                }
            );
        }
    }
}
