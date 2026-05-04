using WebExpress.Tutorial.WebUI.WebControl;
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
    /// Represents the SplitButtonLink control for the tutorial.  
    /// </summary>
    [Title("SplitButtonLink")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class SplitButtonLink : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the link control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public SplitButtonLink(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `SplitButtonLink` control provides a primary clickable action—typically a navigation link—combined with a dropdown of optional secondary actions. It is ideal for scenarios where a single main action is required, but additional related actions should be easily accessible. The control supports icons, tooltips, and customizable styling, and integrates seamlessly into the WebExpress UI framework. It is designed to enhance usability by grouping related actions while keeping the primary interaction clear and prominent.";

            Stage.Controls = [
                new ControlSplitButtonLink()
                {
                    Text = _ =>"Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemLink()
                    {
                        Text = _ => "Action"
                    })
            ];

            Stage.Code = @"
            new ControlSplitButtonLink()
                {
                    Text = _ => ""Hello World!"",
                    Uri = _ => pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemLink()
                    {
                        Text = _ => ""Action 1""
                    })";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Default",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Primary",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Info",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Success",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Warning",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Danger",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Dark",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Dark),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Light",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Light),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Custom",
                    BackgroundColor = _ => new PropertyColorButton("gold"),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = _ => true",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Default",
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Primary",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Secondary",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = _ => true
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Info",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Info),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Success",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Warning",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Danger",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Dark",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Dark),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Light",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Light),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Custom",
                    BackgroundColor = _ => new PropertyColorButton("gold"),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = _ => TypeSizeButton.Small",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Small",
                    Size = _ => TypeSizeButton.Small,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Default",
                    Size = _ => TypeSizeButton.Default,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Large",
                    Size = _ => TypeSizeButton.Large,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = _ => new IconHome()",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Home",
                    Icon = _ => new IconHome(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.ApplicationContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Custom",
                    Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = _ => TypeBlockButton.Block",
               new ControlSplitButtonLink()
               {
                   Text = _ => "Block",
                   Block = _ => TypeBlockButton.Block,
                   BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                   Uri = pageContext.Route.ToUri()
               }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the active state of the button.",
                "Active = _ => TypeActive.Active",
                new ControlSplitButtonLink()
                {
                    Text = _ => "None",
                    Active = _ => TypeActive.None,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Active",
                    Active = _ => TypeActive.Active,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = _ => "Disabled",
                    Active = _ => TypeActive.Disabled,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = _ => new ActionModal(\"modal\")",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Click me!",
                    PrimaryAction = _ => new ActionModal("modal"),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
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
                new ControlSplitButtonLink()
                {
                    Text = _ => "Double-click me!",
                    SecondaryAction = _ => new ActionModal("modal"),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddItem
            (
                typeof(ControlSplitButtonItemLink),
                "ControlSplitButtonItemLink",
                "This item is displayed inside the dropdown section of the split button.",
                "new ControlSplitButtonItemLink()",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemLink()
                    {
                        Text = _ => "Action"
                    })
            );

            Stage.AddItem
            (
                typeof(ControlSplitButtonItemHeader),
                "ControlSplitButtonItemHeader",
                "This item is displayed as a non-interactive header inside the dropdown section of the split button and is used to group related actions.",
                "new ControlSplitButtonItemHeader()",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemHeader()
                    {
                        Text = "Header"
                    })
            );

            Stage.AddItem
            (
                typeof(ControlSplitButtonItemDivider),
                "ControlSplitButtonItemDivider",
                "This item is displayed as a visual divider inside the dropdown section of the split button and is used to separate groups of related actions.",
                "new ControlSplitButtonItemDivider()",
                new ControlSplitButtonLink()
                {
                    Text = _ => "Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemDivider())
            );
        }
    }
}
