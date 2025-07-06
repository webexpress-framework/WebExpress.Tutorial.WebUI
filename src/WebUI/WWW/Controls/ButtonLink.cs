using WebExpress.Toutorial.WebUI.WebControl;
using WebExpress.Toutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Toutorial.WebUI.WebPage;
using WebExpress.Toutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Toutorial.WebUI.WWW.Controls
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
                    Text = "Hello World!",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Hello World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Hello World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                }
            ];

            Stage.Code = @"
            new ControlButtonLink()  
            {  
                Text = ""Hello World!"",
                Uri = pageContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)",
                new ControlButtonLink()
                {
                    Text = "Default",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
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
                new ControlButtonLink()
                {
                    Text = "Default",
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButton()
                {
                    Text = "Secondary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = true
                },
                new ControlButtonLink()
                {
                    Text = "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Outline = true,
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
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
                new ControlButtonLink()
                {
                    Text = "Small",
                    Size = TypeSizeButton.Small,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Default",
                    Size = TypeSizeButton.Default,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
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
                new ControlButtonLink()
                {
                    Text = "Home",
                    Icon = new IconHome(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Uri = pageContext.ApplicationContext.Route.ToUri()
                },
                new ControlButtonLink()
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
               new ControlButtonLink()
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
                new ControlButtonLink()
                {
                    Text = "None",
                    Active = TypeActive.None,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
                {
                    Text = "Active",
                    Active = TypeActive.Active,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlButtonLink()
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
                "Modal",
                "Displays a dialog.",
                "Modal = new ControlModal(...)",
                new ControlButtonLink()
                {
                    Text = "Click me!",
                    Modal = "modal",
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
