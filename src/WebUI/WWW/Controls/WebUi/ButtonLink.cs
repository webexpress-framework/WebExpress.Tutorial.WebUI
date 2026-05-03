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
    /// Represents the ButtonLink control for the tutorial.  
    /// </summary>  
    [Title("ButtonLink")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ButtonLink : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the link control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public ButtonLink(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `ButtonLink` control is an intuitive and versatile tool designed for triggering actions, submitting forms, or navigating in web applications. It ensures user interactions are handled effectively, using dynamic styling and functionality to enhance user experience. Built for flexibility, the control can be customized to suit various use cases.";

            Stage.Controls = [
                new ControlButtonLink()
                {
                    Text = _ => "Hello World!",
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Hello World!",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Info),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Hello World!",
                    BackgroundColor =_ =>  new PropertyColorButton(TypeColorButton.Warning),
                    Uri = _ => pageContext.Route.ToUri()
                }
            ];

            Stage.Code = @"
            new ControlButtonLink()  
            {  
                Text = _ => ""Hello World!"",
                Uri = _ => pageContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)",
                new ControlButtonLink()
                {
                    Text = _ => "Default",
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Primary",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Info",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Info),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Success",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Warning",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Danger",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Dark",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Dark),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Light",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Light),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Custom",
                    BackgroundColor = _ => new PropertyColorButton("gold"),
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = _ => true",
                new ControlButtonLink()
                {
                    Text = _ => "Default",
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Primary",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButton()
                {
                    Text = _ => "Secondary",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = _ => true
                },
                new ControlButtonLink()
                {
                    Text = _ => "Info",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Info),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Success",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Warning",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Danger",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Dark",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Dark),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Light",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Light),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Custom",
                    BackgroundColor = _ => new PropertyColorButton("gold"),
                    Outline = _ => true,
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = _ => TypeSizeButton.Small",
                new ControlButtonLink()
                {
                    Text = _ => "Small",
                    Size = _ => TypeSizeButton.Small,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Default",
                    Size = _ => TypeSizeButton.Default,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Large",
                    Size = _ => TypeSizeButton.Large,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = _ => new IconHome()",
                new ControlButtonLink()
                {
                    Text = _ => "Home",
                    Icon = _ => new IconHome(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Uri = _ => pageContext.ApplicationContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Custom",
                    Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Warning),
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = _ => TypeBlockButton.Block",
               new ControlButtonLink()
               {
                   Text = _ => "Block",
                   Block = _ => TypeBlockButton.Block,
                   BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                   Uri = _ => pageContext.Route.ToUri()
               }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the active state of the button.",
                "Active = _ => TypeActive.Active",
                new ControlButtonLink()
                {
                    Text = _ => "None",
                    Active = _ => TypeActive.None,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Active",
                    Active = _ => TypeActive.Active,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = _ => "Disabled",
                    Active = _ => TypeActive.Disabled,
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = _ => new ActionModal(\"modal\")",
                new ControlButtonLink()
                {
                    Text = (c) => "Click me!",
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
                new ControlButtonLink()
                {
                    Text = (c) => "Double-click me!",
                    SecondaryAction = _ => new ActionModal("modal"),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
