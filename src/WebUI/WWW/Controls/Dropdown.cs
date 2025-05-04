using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the dropdown control for the tutorial.  
    /// </summary>  
    [Title("Dropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    public sealed class Dropdown : PageControl
    {
        private readonly IControlDropdownItem _item1 = new ControlDropdownItemHeader() { Text = "Header" };
        private readonly IControlDropdownItem _item2 = new ControlDropdownItemLink() { Text = "First Entry", Icon = new IconWrench() };
        private readonly IControlDropdownItem _item3 = new ControlDropdownItemLink() { Text = "Second Entry" };
        private readonly IControlDropdownItem _item4 = new ControlDropdownItemDivider();
        private readonly IControlDropdownItem _item5 = new ControlDropdownItemLink() { Text = "Third Entry" };

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
                    Text = "Dropdown",
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                        Text = "Default",
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Primary",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Info",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Success",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Warning",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Danger",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Dark",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Light",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Custom",
                        BackgroundColor = new PropertyColorButton("gold"),
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
                        Text = "Default",
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Primary",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Info",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Info),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Success",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Success),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Warning",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Warning),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Danger",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Danger),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Dark",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Light",
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Light),
                        Outline = true,
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Custom",
                        BackgroundColor = new PropertyColorButton("gold"),
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
                        Text = "Small",
                        Size = TypeSizeButton.Small,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Default",
                        Size = TypeSizeButton.Default,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Large",
                        Size = TypeSizeButton.Large,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                        Text = "Home",
                        Icon = new IconHome(),
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Custom",
                        Icon = new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                   Text = "Block",
                   Block = TypeBlockButton.Block,
                   BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                        Text = "None",
                        Active = TypeActive.None,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Active",
                        Active = TypeActive.Active,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Disabled",
                        Active = TypeActive.Disabled,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                        Text = "None",
                        Toggle = TypeToggleDropdown.None,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Toggle",
                        Toggle = TypeToggleDropdown.Toggle,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
                        Text = "None",
                        //AlignmentMenu = TypeAlignmentDropdownMenu.Default,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = "Right",
                        //AlignmentMenu = TypeAlignmentDropdownMenu.Right,
                        BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
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
