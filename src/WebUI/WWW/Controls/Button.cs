using WebExpress.Toutorial.WebUI.WebControl;
using WebExpress.Toutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Toutorial.WebUI.WebPage;
using WebExpress.Toutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Toutorial.WebUI.WWW.Controls
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
        public Button()
        {
            Stage.Description = @"The `Button` control is an intuitive and versatile tool designed for triggering actions, submitting forms, or navigating in web applications. It ensures user interactions are handled effectively, using dynamic styling and functionality to enhance user experience. Built for flexibility, the control can be customized to suit various use cases.";

            Stage.Controls = [
                new ControlButton()
                {
                    Text = "Hallo World!"
                },
                new ControlButton()
                {
                    Text = "Hallo World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info)
                },
                new ControlButton()
                {
                    Text = "Hallo World!",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning)
                }
            ];

            Stage.Code = @"
            new ControlButton()  
            {  
                Text = ""Hallo World!"",
                BackgroundColor = new PropertyColorButton(TypeColorButton.Info)
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "Color = new PropertyColorButton(TypeColorButton.Primary)",
                new ControlButton()
                {
                    Text = "Default"
                },
                new ControlButton()
                {
                    Text = "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                },
                new ControlButton()
                {
                    Text = "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info)
                },
                new ControlButton()
                {
                    Text = "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success)
                },
                new ControlButton()
                {
                    Text = "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning)
                },
                new ControlButton()
                {
                    Text = "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger)
                },
                new ControlButton()
                {
                    Text = "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark)
                },
                new ControlButton()
                {
                    Text = "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light)
                },
                new ControlButton()
                {
                    Text = "Custom",
                    BackgroundColor = new PropertyColorButton("gold")
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = true",
                new ControlButton()
                {
                    Text = "Default",
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Primary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Secondary",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Secondary),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Info",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Success",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Warning",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Danger",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Dark",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Light",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                    Outline = true
                },
                new ControlButton()
                {
                    Text = "Custom",
                    BackgroundColor = new PropertyColorButton("gold"),
                    Outline = true
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = TypeSizeButton.Small",
                new ControlButton()
                {
                    Text = "Small",
                    Size = TypeSizeButton.Small,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                },
                new ControlButton()
                {
                    Text = "Default",
                    Size = TypeSizeButton.Default,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                },
                new ControlButton()
                {
                    Text = "Large",
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
                    Text = "Home",
                    Icon = new IconHome(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                },
                new ControlButton()
                {
                    Text = "Custom",
                    //Icon = new Icon(Uri.Root.Append("/Assets/img/Icon16.png")),
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
                   Text = "Block",
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
                    Text = "None",
                    Active = TypeActive.None,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlButton()
                {
                    Text = "Active",
                    Active = TypeActive.Active,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlButton()
                {
                    Text = "Disabled",
                    Active = TypeActive.Disabled,
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Modal",
                "Displays a dialog.",
                "Modal = new ControlModal(...)",
                new ControlButton()
                {
                    Text = "Click me!",
                    Modal = "modal",
                    TextColor = new PropertyColorText(TypeColorText.Default),
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
