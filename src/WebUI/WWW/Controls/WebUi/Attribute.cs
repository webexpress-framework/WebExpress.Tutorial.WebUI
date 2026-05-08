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
                Key = _ => "Example",
                Value = _ => "This is an example of the ControlAttribute."
            };

            Stage.Code = @"
            new ControlAttribute()
            {
                Key = _=> ""Example"",
                Value = _=> ""This is an example of the ControlAttribute.""
            };";

            Stage.AddProperty
            (
                "Key",
                "Returns or sets the key of the attribute, representing the name or identifier in the key-value pair.",
                @"Key = _=> ""Example""",
                new ControlAttribute()
                {
                    Key = _ => "Example"
                }
            );

            Stage.AddProperty
           (
               "Value",
               "Returns or sets the value associated with the specified key.",
               @"Value = _=> ""This is an example of the ControlAttribute.""",
               new ControlAttribute()
               {
                   Value = _ => "This is an example of the ControlAttribute."
               }
           );

            Stage.AddProperty
            (
                "Color",
                "Sets the color of the property.",
                "Color = _=> new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Default),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Primary),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Secondary),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Info),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Success),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Warning),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Danger),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Dark),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Light),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Color = _ => new PropertyColorText("gold"),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                }
            );

            Stage.AddProperty
            (
                "KeyColor",
                "Sets the color of the key property.",
                "KeyColor = _=> new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Default),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Primary),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Secondary),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Info),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Success),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Warning),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Danger),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Dark),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText(TypeColorText.Light),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    KeyColor = _ => new PropertyColorText("gold"),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute.",
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Returns or sets the background color of the attribute.",
                "BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Default"
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Primary",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Primary",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Info",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Success",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Warning",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Danger",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Dark",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Light",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = _ => "Transparent", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Transparent",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAttribute()
                {
                    Value = _ => "Custom",
                    BackgroundColor = _ => new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Returns or sets the icon associated with the attribute, typically used to visually represent the attribute's meaning or category.",
                @"
                new ControlAttribute()
                {
                    Icon = _=> new IconHome()
                }",
                new ControlAttribute()
                {
                    Icon = _ => new IconHome(),
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute."
                }
            );

            Stage.AddProperty
            (
                "Separator",
                "Returns or sets the character used to separate the key and value in the displayed attribute. Common separators include ':' or '='.",
                @"
                new ControlAttribute()
                {
                    Separator = _=> '='
                }",
                new ControlAttribute()
                {
                    Separator = _ => '=',
                    Key = _ => "Example",
                    Value = _ => "This is an example of the ControlAttribute."
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Returns or sets the URI associated with the attribute's value.",
                @"
                new ControlAttribute()
                {
                    Uri = _=> pageContext.Route.ToUri()
                }",
                new ControlAttribute()
                {
                    Key = _ => "With URI",
                    Value = _ => "This is an example of the ControlAttribute.",
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlAttribute()
                {
                    Key = _ => "Without URI",
                    Value = _ => "This is an example of the ControlAttribute."
                }
            );
        }
    }
}
