using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the button control for the tutorial.  
    /// </summary>  
    [Title("Button")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Button : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        public Button(IPageContext pageContext)
        {
            Stage.Description = @"The `Button` control is an intuitive and versatile tool designed for triggering actions, submitting forms, or navigating in web applications. It ensures user interactions are handled effectively, using dynamic styling and functionality to enhance user experience. Built for flexibility, the control can be customized to suit various use cases.";

            Stage.Controls = [
                new ControlButton()
                {
                    Text = (c) =>"Hallo World!"
                },
                new ControlButton()
                {
                    Text = (c) =>"Hallo World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info)
                },
                new ControlButton()
                {
                    Text = (c) =>"Hallo World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning)
                }
            ];

            Stage.Code = @"
            new ControlButton()  
            {  
                Text = (c) => ""Hallo World!"",
                BackgroundColor = new PropertyColorButton(TypeColorButton.Info)
            };";

            Stage.AddProperty
            (
                "Text",
                "Sets the text of the button.",
                "Text = (c) => \"WebExpress\"",
                new ControlButton()
                {
                    Text = (c) => "WebExpress"
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)",
                new ControlButton()
                {
                    Text = (c) => "Default"
                },
                new ControlButton()
                {
                    Text = (c) => "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                },
                new ControlButton()
                {
                    Text = (c) => "Secondary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Secondary)
                },
                new ControlButton()
                {
                    Text = (c) => "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info)
                },
                new ControlButton()
                {
                    Text = (c) => "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success)
                },
                new ControlButton()
                {
                    Text = (c) => "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning)
                },
                new ControlButton()
                {
                    Text = (c) => "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger)
                },
                new ControlButton()
                {
                    Text = (c) => "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark)
                },
                new ControlButton()
                {
                    Text = (c) => "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light)
                },
                new ControlButton()
                {
                    Text = (c) => "Highlight",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Highlight)
                },
                new ControlButton()
                {
                    Text = (c) => "Custom",
                    BackgroundColor = new PropertyColorButton("gold")
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = _ => true",
                new ControlButton()
                {
                    Text = (c) => "Default",
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Secondary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Highlight",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Highlight),
                    Outline = _ => true
                },
                new ControlButton()
                {
                    Text = (c) => "Custom",
                    BackgroundColor = new PropertyColorButton("gold"),
                    Outline = _ => true
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = TypeSizeButton.Small",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlButton()
                {
                    Text = (c) => "Default",
                    Size = TypeSizeButton.Default,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                },
                new ControlText() { Text = "Small", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlButton()
                {
                    Text = (c) => "Small",
                    Size = TypeSizeButton.Small,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                },
                new ControlText() { Text = "Large", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlButton()
                {
                    Text = (c) => "Large",
                    Size = TypeSizeButton.Large,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = new IconHome()",
                new ControlButton()
                {
                    Text = (c) => "Home",
                    Icon = _ => new IconHome(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                },
                new ControlButton()
                {
                    Text = (c) => "Custom",
                    Icon = _ => new ImageIconWebExpress(pageContext.ApplicationContext),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = TypeBlockButton.Block",
               new ControlButton()
               {
                   Text = (c) => "Block",
                   Block = TypeBlockButton.Block,
                   BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
               }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the activity property of the button.",
                "Active = TypeActive.Active",
                new ControlButton()
                {
                    Text = (c) => "None",
                    Active = TypeActive.None,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlButton()
                {
                    Text = (c) => "Active",
                    Active = TypeActive.Active,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlButton()
                {
                    Text = (c) => "Disabled",
                    Active = TypeActive.Disabled,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = new ActionModal(\"modal\")",
                new ControlButton()
                {
                    Text = (c) => "Click me!",
                    PrimaryAction = _ => new ActionModal("modal"),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                new ControlButton()
                {
                    Text = (c) => "Double-click me!",
                    SecondaryAction = _ => new ActionModal("modal"),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
