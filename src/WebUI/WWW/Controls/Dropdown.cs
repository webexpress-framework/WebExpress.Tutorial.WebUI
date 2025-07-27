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
    /// Represents the dropdown control for the tutorial.  
    /// </summary>  
    [Title("Dropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Dropdown : PageControl
    {
        private readonly IControlDropdownItem _item1 = new ControlDropdownItemHeader() { Text = "Header" };
        private readonly IControlDropdownItem _item2 = new ControlDropdownItemLink() { Label = "First Entry", Icon = new IconWrench() };
        private readonly IControlDropdownItem _item3 = new ControlDropdownItemLink() { Label = "Second Entry" };
        private readonly IControlDropdownItem _item4 = new ControlDropdownItemDivider();
        private readonly IControlDropdownItem _item5 = new ControlDropdownItemLink() { Label = "Third Entry" };

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Dropdown(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Dropdown` control is a versatile and interactive component for web applications.  
            It allows users to select options or navigate seamlessly, ensuring a smooth and intuitive user experience.  
            The control supports extensive customization for various use cases, making it adaptable to diverse requirements.  
            The `Dropdown` provides a button with a dropdown menu, offering a clean and efficient design.";

            Stage.Controls = [
                new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                {
                    Label = "Dropdown",
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Color = new PropertyColorButton(TypeColorButton.Primary),
                }
            ];

            Stage.Code = @"
            new ControlDropdown
            (
                null, 
                new ControlDropdownItemHeader() { Text = ""Header"" }, 
                new ControlDropdownItemLink() { Text = ""First Entry"", Icon = new IconWrench() }, 
                new ControlDropdownItemLink() { Text = ""Second Entry"" }, 
                new ControlDropdownItemDivider(),
                new ControlDropdownItemLink() { Text = ""Third Entry"" }
            )
            {
                Text = ""Dropdown"",
                TextColor = new PropertyColorText(TypeColorText.Default),
                BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
            };";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "Color = new PropertyColorButton(TypeColorButton.Primary)",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Default",
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Primary",
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Info",
                        Color = new PropertyColorButton(TypeColorButton.Info),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Success",
                        Color = new PropertyColorButton(TypeColorButton.Success),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Warning",
                        Color = new PropertyColorButton(TypeColorButton.Warning),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Danger",
                        Color = new PropertyColorButton(TypeColorButton.Danger),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Dark",
                        Color = new PropertyColorButton(TypeColorButton.Dark),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Light",
                        Color = new PropertyColorButton(TypeColorButton.Light),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Custom",
                        Color = new PropertyColorButton("gold"),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = true",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Default",
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Primary",
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Info",
                        Color = new PropertyColorButton(TypeColorButton.Info),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Success",
                        Color = new PropertyColorButton(TypeColorButton.Success),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Warning",
                        Color = new PropertyColorButton(TypeColorButton.Warning),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Danger",
                        Color = new PropertyColorButton(TypeColorButton.Danger),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Dark",
                        Color = new PropertyColorButton(TypeColorButton.Dark),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Light",
                        Color = new PropertyColorButton(TypeColorButton.Light),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Custom",
                        Color = new PropertyColorButton("gold"),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = TypeSizeButton.Small",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Small",
                        Size = TypeSizeButton.Small,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Default",
                        Size = TypeSizeButton.Default,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Large",
                        Size = TypeSizeButton.Large,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = new IconHome()",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Home",
                        Icon = new IconHome(),
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Custom",
                        Icon = new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = TypeBlockButton.Block",
               new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
               {
                   Label = "Block",
                   Block = TypeBlockButton.Block,
                   Color = new PropertyColorButton(TypeColorButton.Primary),
                   Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
               }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the active state of the button.",
                "Active = TypeActive.Active",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "None",
                        Active = TypeActive.None,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Active",
                        Active = TypeActive.Active,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Disabled",
                        Active = TypeActive.Disabled,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );

            Stage.AddProperty
            (
                "Toggle",
                "An indicator that shows a menu is available.",
                "Toggle = TypeToggleDropdown.Toggle",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "None",
                        Toggle = TypeToggleDropdown.None,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Toggle",
                        Toggle = TypeToggleDropdown.Toggle,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );

            Stage.AddProperty
            (
                "MenuAlignment",
                "Determines how the menu should be aligned relative to the button.",
                "AlignmentMenu = TypeAlignmentDropdownMenu.Right",
                new ControlPanelFlexbox
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "None",
                        AlignmentMenu = TypeAlignmentDropdownMenu.Default,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Label = "Right",
                        AlignmentMenu = TypeAlignmentDropdownMenu.Right,
                        Color = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center
                }
            );
        }
    }
}
