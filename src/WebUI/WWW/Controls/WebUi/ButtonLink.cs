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
                    Text = (c) =>"Hello World!",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) =>"Hello World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) =>"Hello World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                }
            ];

            Stage.Code = @"
            new ControlButtonLink()  
            {  
                Text = (c) => ""Hello World!"",
                Uri = pageContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)",
                new ControlButtonLink()
                {
                    Text = (c) => "Default",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Custom",
                    BackgroundColor = new PropertyColorButton("gold"),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = _ => true",
                new ControlButtonLink()
                {
                    Text = (c) => "Default",
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButton()
                {
                    Text = (c) => "Secondary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = _ => true
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Custom",
                    BackgroundColor = new PropertyColorButton("gold"),
                    Outline = _ => true,
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = TypeSizeButton.Small",
                new ControlButtonLink()
                {
                    Text = (c) => "Small",
                    Size = TypeSizeButton.Small,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Default",
                    Size = TypeSizeButton.Default,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Large",
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
                new ControlButtonLink()
                {
                    Text = (c) => "Home",
                    Icon = _ => new IconHome(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.ApplicationContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Custom",
                    Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = TypeBlockButton.Block",
               new ControlButtonLink()
               {
                   Text = (c) => "Block",
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
                new ControlButtonLink()
                {
                    Text = (c) => "None",
                    Active = TypeActive.None,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Active",
                    Active = TypeActive.Active,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = (c) => "Disabled",
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
                "PrimaryAction = _ => new ActionModal(\"modal\")",
                new ControlButtonLink()
                {
                    Text = (c) => "Click me!",
                    PrimaryAction = _ => new ActionModal("modal"),
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
                "SecondaryAction = _ => new ActionModal(\"modal\")",
                new ControlButtonLink()
                {
                    Text = (c) => "Double-click me!",
                    SecondaryAction = _ => new ActionModal("modal"),
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
