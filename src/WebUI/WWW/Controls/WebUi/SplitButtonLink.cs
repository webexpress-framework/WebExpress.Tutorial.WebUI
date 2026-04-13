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
                    Text = "Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemLink()
                    {
                        Text = "Action"
                    })
            ];

            Stage.Code = @"
            new ControlSplitButtonLink()
                {
                    Text = ""Hello World!"",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemLink()
                    {
                        Text = ""Action 1""
                    })";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)",
                new ControlSplitButtonLink()
                {
                    Text = "Default",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Custom",
                    BackgroundColor = new PropertyColorButton("gold"),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = true",
                new ControlSplitButtonLink()
                {
                    Text = "Default",
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Secondary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = true
                },
                new ControlSplitButtonLink()
                {
                    Text = "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Custom",
                    BackgroundColor = new PropertyColorButton("gold"),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = TypeSizeButton.Small",
                new ControlSplitButtonLink()
                {
                    Text = "Small",
                    Size = TypeSizeButton.Small,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Default",
                    Size = TypeSizeButton.Default,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Large",
                    Size = TypeSizeButton.Large,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = new IconHome()",
                new ControlSplitButtonLink()
                {
                    Text = "Home",
                    Icon = new IconHome(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.ApplicationContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Custom",
                    Icon = new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = TypeBlockButton.Block",
               new ControlSplitButtonLink()
               {
                   Text = "Block",
                   Block = TypeBlockButton.Block,
                   BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                   Uri = pageContext.Route.ToUri()
               }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the active state of the button.",
                "Active = TypeActive.Active",
                new ControlSplitButtonLink()
                {
                    Text = "None",
                    Active = TypeActive.None,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Active",
                    Active = TypeActive.Active,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlSplitButtonLink()
                {
                    Text = "Disabled",
                    Active = TypeActive.Disabled,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = new ActionModal(\"modal\")",
                new ControlSplitButtonLink()
                {
                    Text = "Click me!",
                    PrimaryAction = new ActionModal("modal"),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddProperty
            (
                "SecondaryAction",
                "Defines the secondary user action, often triggered by a double‑click to open a dialog or perform an alternative operation.",
                "SecondaryAction = new ActionModal(\"modal\")",
                new ControlSplitButtonLink()
                {
                    Text = "Double-click me!",
                    SecondaryAction = new ActionModal("modal"),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
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
                    Text = "Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemLink()
                    {
                        Text = "Action"
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
                    Text = "Hello World!",
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
                    Text = "Hello World!",
                    Uri = pageContext.Route.ToUri()
                }
                    .Add(new ControlSplitButtonItemDivider())
            );
        }
    }
}
