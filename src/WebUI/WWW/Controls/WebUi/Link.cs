using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebParameter;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the link control for the tutorial.  
    /// </summary>  
    [Title("Link")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Link : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the link control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public Link(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Link` control is a simple and effective tool for navigation in web applications. It allows users to move between pages or external resources seamlessly, ensuring a smooth user experience. The control supports customization for various use cases.";

            Stage.Controls = [
                new ControlLink()
                   {
                       Text = _ => pageContext.PageTitle,
                       Icon = _ => new IconClone(),
                       Uri = _ => pageContext.Route.ToUri()
                   }
            ];

            Stage.Code = $"new ControlLink() {{ Text = \"{pageContext.PageTitle}\", Icon = new IconClone(), Uri = new UriEndpoint(\"{pageContext.Route.ToUri()}\") }};";

            Stage.AddProperty
            (
                "Text",
                "Sets the text of the link",
                "Text = _ => \"Hello World!\"",
                new ControlLink()
                {
                    Text = _ => "Hello World!",
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Content",
                "Sets the content of the link",
                "new ControlLink(this, new ControlText(this) { Text = _ => \"Hello World!\", Format = _ => TypeFormatText.Italic }, new ControlBadge(this) { Value = _ => \"1\", BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger) })",
                new ControlLink(null, new ControlText() { Text = _ => "Hello World!", Format = _ => TypeFormatText.Italic }, new ControlBadge() { Value = _ => "1", BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger) })
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Title",
                "Sets a tooltip.",
                "Title = _ => \"Hello World!\"",
                new ControlLink()
                {
                    Text = _ => "Try it out",
                    Uri = _ => pageContext.Route.ToUri(),
                    Title = _ => "Hello World!",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Target",
                "Sets the target of the link.",
                "Target = _ => TypeTarget.Blank",
                new ControlLink()
                {
                    Text = _ => "Try it out",
                    Uri = _ => pageContext.Route.ToUri(),
                    Target = _ => TypeTarget.Blank,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Sets the address of the link.",
                "Uri = _ => pageContext.Route.ToUri()",
                new ControlLink()
                {
                    Text = _ => "With URI",
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Without URI",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the link.",
                "Icon = _ => new IconHome()",
                new ControlLink()
                {
                    Text = _ => "Home",
                    Icon = _ => new IconHome(),
                    Uri = _ => pageContext.ApplicationContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Controls",
                    Icon = _ => new IconClone(),
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Info",
                    Icon = _ => new IconInfoCircle(),
                    Uri = _ => sitemapManager.GetUri<Info>(pageContext.ApplicationContext),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Custom",
                    Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the active state of the link.",
                "This property does not affect all contexts. See ControlTab",
                "Active = _ => TypeActive.Active",
                new ControlLink()
                {
                    Text = _ => "None",
                    Active = _ => TypeActive.None,
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Active",
                    Active = _ => TypeActive.Active,
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Disabled",
                    Active = _ => TypeActive.Disabled,
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Decoration",
                "Determines whether the link is underlined on hover.",
                "Decoration = _ => TypeTextDecoration.None",
                new ControlLink()
                {
                    Text = _ => "Default",
                    Decoration = _ => TypeTextDecoration.Default,
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "None",
                    Decoration = _ => TypeTextDecoration.None,
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the link.",
                "Size = _ => TypeSizeButton.Small",
                new ControlLink()
                {
                    Text = _ => "Extra Small",
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraSmall),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Small",
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => new PropertySizeText(TypeSizeText.Small),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Standard",
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => new PropertySizeText(TypeSizeText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Large",
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => new PropertySizeText(TypeSizeText.Large),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Extra Large",
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraLarge),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Custom",
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => new PropertySizeText(3.1f),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Sets the text color.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlLink()
                {
                    Text = _ => "Default",
                    Uri = _ => pageContext.Route.ToUri(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Primary",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Info",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Success",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Success),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Warning",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Warning),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Danger",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Dark",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Light",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Light),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Muted",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Muted),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "White",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlLink()
                {
                    Text = _ => "Custom",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText("red"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            // Properties
            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color.",
                "BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlLink()
                {
                    Text = _ => "Default",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Default),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Primary",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Secondary",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Info",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Success",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Warning",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Danger",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Dark",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.White),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Light",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "White",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.White),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Transparent",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                },
                new ControlLink()
                {
                    Text = _ => "Custom",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText("red"),
                    BackgroundColor = _ => new PropertyColorBackground("gold"),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Auto)
                }
            );

            var linkParam = new ControlLink()
            {
                Text = _ => "With Parameters",
                Uri = _ => pageContext.Route.ToUri(),
                Active = _ => TypeActive.Active,
                Params = _ => [
                    new Parameter("param1", 1, ParameterScope.Parameter),
                    new Parameter("param2", "two", ParameterScope.Parameter)
                ]
            };

            Stage.AddProperty
            (
                "Param",
                "Link with parameters",
                "Params.Add(new Parameter(\"param1\", 1))",
                linkParam
            );

            Stage.AddProperty
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = _ => new ActionModal(\"modal\")",
                new ControlLink()
                {
                    Text = _ => "Click me!",
                    PrimaryAction = _ => new ActionModal("modal"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddProperty
            (
                "SecondaryAction",
                "Defines the secondary user action, often triggered by a double‑click to open a dialog or perform an alternative operation.",
                "SecondaryAction = _ => new ActionModal(\"modal\")",
                new ControlLink()
                {
                    Text = _ => "Double-click me!",
                    SecondaryAction = _ => new ActionModal("modal"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
