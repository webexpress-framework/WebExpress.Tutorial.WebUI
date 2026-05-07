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
    /// Represents the dropdown control for the tutorial.  
    /// </summary>  
    [Title("Dropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Dropdown : PageControl
    {
        private readonly IControlDropdownItem _item1 = new ControlDropdownItemHeader() { Text = _ => "Header" };
        private readonly IControlDropdownItem _item2 = new ControlDropdownItemLink() { Text = _ => "First Entry", Icon = _ => new IconWrench() };
        private readonly IControlDropdownItem _item3 = new ControlDropdownItemLink() { Text = _ => "Second Entry" };
        private readonly IControlDropdownItem _item4 = new ControlDropdownItemDivider();
        private readonly IControlDropdownItem _item5 = new ControlDropdownItemLink() { Text = _ => "Third Entry", PrimaryAction = _ => new ActionModal("myModal") };

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Dropdown(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"
            The `Dropdown` control is a versatile and interactive component for web applications.  
            It allows users to select options or navigate seamlessly, ensuring a smooth and intuitive user experience.  
            The control supports extensive customization for various use cases, making it adaptable to diverse requirements.  
            The `Dropdown` provides a button with a dropdown menu, offering a clean and efficient design.";

            Stage.Controls = [
                new ControlDropdown()
                {
                    Text = _ => "Dropdown",
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Color =_ =>  new PropertyColorButton(TypeColorButton.Primary),
                }
                    .Add(_item1)
                    .Add(_item2)
                    .Add(_item3)
                    .Add(_item4)
                    .Add(_item5),
                new ControlModalRemoteForm("myModal")
                {
                    Header = _ => "My modal",
                    Size = TypeModalSize.ExtraLarge,
                    Uri = sitemapManager.GetUri<Index>(pageContext.ApplicationContext),
                    Selector = "#conformationform"
                }
            ];

            Stage.DarkControls = [
               new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                {
                    Text = _ => "Dropdown",
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                }
           ];

            Stage.Code = @"
            new ControlDropdown()
            {
                Text = ""Dropdown"",
                TextColor = new PropertyColorText(TypeColorText.Default),
                BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
            }
                .Add(new ControlDropdownItemHeader() { Text = _ => ""Header"" }) 
                .Add(new ControlDropdownItemLink() { Text = _ => ""First Entry"", Icon = _ => new IconWrench() })
                .Add(new ControlDropdownItemLink() { Text = _ => ""Second Entry"" })
                .Add(new ControlDropdownItemDivider())
                .Add(new ControlDropdownItemLink() { Text = _ => ""Third Entry"",  PrimaryAction = _ => new ActionModal(""myModal"") });";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "Color = _ => new PropertyColorButton(TypeColorButton.Primary)",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Default",
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Primary",
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Info",
                        Color = _ => new PropertyColorButton(TypeColorButton.Info),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Success",
                        Color = _ => new PropertyColorButton(TypeColorButton.Success),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Warning",
                        Color = _ => new PropertyColorButton(TypeColorButton.Warning),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Danger",
                        Color = _ => new PropertyColorButton(TypeColorButton.Danger),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Dark",
                        Color = _ => new PropertyColorButton(TypeColorButton.Dark),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Light",
                        Color = _ => new PropertyColorButton(TypeColorButton.Light),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Custom",
                        Color = _ => new PropertyColorButton("gold"),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button.",
                "Outline = _ => true",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Default",
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Primary",
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Info",
                        Color = _ => new PropertyColorButton(TypeColorButton.Info),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Success",
                        Color = _ => new PropertyColorButton(TypeColorButton.Success),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Warning",
                        Color = _ => new PropertyColorButton(TypeColorButton.Warning),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Danger",
                        Color = _ => new PropertyColorButton(TypeColorButton.Danger),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Dark",
                        Color = _ => new PropertyColorButton(TypeColorButton.Dark),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Light",
                        Color = _ => new PropertyColorButton(TypeColorButton.Light),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Custom",
                        Color = _ => new PropertyColorButton("gold"),
                        Outline = _ => true,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = _ => TypeSizeButton.Small",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Small",
                        Size = _ => TypeSizeButton.Small,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Default",
                        Size = _ => TypeSizeButton.Default,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Large",
                        Size = _ => TypeSizeButton.Large,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = _ => new IconHome()",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Home",
                        Icon = _ => new IconHome(),
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Custom",
                        Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = _ => TypeBlockButton.Block",
               new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
               {
                   Text = _ => "Block",
                   Block = _ => TypeBlockButton.Block,
                   Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                   Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
               }
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the active state of the button.",
                "Active = _ => TypeActive.Active",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "None",
                        Active = _ => TypeActive.None,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Active",
                        Active = _ => TypeActive.Active,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Disabled",
                        Active = _ => TypeActive.Disabled,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddProperty
            (
                "Toggle",
                "An indicator that shows a menu is available.",
                "Toggle = _ => TypeToggleDropdown.Toggle",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "None",
                        Toggle = _ => TypeToggleDropdown.None,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Toggle",
                        Toggle = _ => TypeToggleDropdown.Toggle,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddProperty
            (
                "MenuAlignment",
                "Determines how the menu should be aligned relative to the button.",
                "AlignmentMenu = _ => TypeAlignmentDropdownMenu.Right",
                new ControlPanelFlex
                (
                    null,
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Default",
                        AlignmentMenu = _ => TypeAlignmentDropdownMenu.Default,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    },
                    new ControlDropdown(null, _item1, _item2, _item3, _item4, _item5)
                    {
                        Text = _ => "Right",
                        AlignmentMenu = _ => TypeAlignmentDropdownMenu.Right,
                        Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                    }
                )
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center
                }
            );

            Stage.AddItem
            (
                typeof(ControlDropdownItemLink),
                "ControlDropdownItemLink",
                "This item is displayed inside the dropdown menu and represents a selectable link that triggers a navigation or action.",
                "new ControlDropdownItemLink()",
                new ControlDropdown(null)
                {
                    Text = _ => "ItemLink",
                    AlignmentMenu = _ => TypeAlignmentDropdownMenu.Default,
                    Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                }
                    .Add(new ControlDropdownItemLink() { Text = _ => "First Entry", Icon = _ => new IconWrench() })
            );

            Stage.AddItem
            (
                typeof(ControlDropdownItemHeader),
                "ControlDropdownItemHeader",
                "This item is displayed inside the dropdown menu and serves as a non-interactive header used to group related actions.",
                "new ControlDropdownItemHeader()",
                new ControlDropdown(null)
                {
                    Text = _ => "ItemHeader",
                    AlignmentMenu = _ => TypeAlignmentDropdownMenu.Default,
                    Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                }
                    .Add(new ControlDropdownItemHeader() { Text = _ => "Header" })
            );

            Stage.AddItem
            (
                typeof(ControlDropdownItemDivider),
                "ControlDropdownItemDivider",
                "This item is displayed inside the dropdown menu and is used as a visual divider to separate groups of related actions.",
                "new ControlDropdownItemDivider()",
                new ControlDropdown(null)
                {
                    Text = _ => "ItemDivider",
                    AlignmentMenu = _ => TypeAlignmentDropdownMenu.Default,
                    Color = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                }
                    .Add(new ControlDropdownItemDivider() { })
            );
        }
    }
}
