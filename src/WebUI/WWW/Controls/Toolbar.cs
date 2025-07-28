using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the toolbar control for the tutorial.  
    /// </summary>  
    [Title("Toolbar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Toolbar : PageControl
    {
        private readonly IControlToolbarItem[] _items =
        [
            new ControlToolbarItemButton("item1") { Label = "Home", Icon = new IconHome() },
            new ControlToolbarItemDivider(),
            new ControlToolbarItemButton("item2")
            {
                Label = "Server",
                Icon = new IconServer(),
                Color = new PropertyColorText(TypeColorText.Warning)
            },
            new ControlToolbarItemDropdown("item3")
            {
                Label = "Users",
                Icon = new IconUsers(),
                Color = new PropertyColorText(TypeColorText.Danger),
            }
                .Add
                (
                    new ControlDropdownItemLink("item3-1") { Label = "Profile", Icon = new IconUser()},
                    new ControlDropdownItemLink("item3-2") { Label = "Preferences", Icon = new IconStar() },
                    new ControlDropdownItemLink("item3-3") { Label = "Logout", Icon = new IconPowerOff()}
                ),
            new ControlToolbarItemButton("item4")
            {
                Label = "Setting",
                Icon = new IconCog(),
                Alignment = TypeToolbarItemAlignment.Right
            },
            new ControlToolbarItemCombo("item5")
            {
                Label = "Vehicle",
                Icon = new IconCar(),
                Color = new PropertyColorText(TypeColorText.Primary),
                Alignment = TypeToolbarItemAlignment.Right
            }
                .Add
                (
                    new ControlFormItemInputComboItem() { Text = "Car"},
                    new ControlFormItemInputComboItem() { Text = "Bicycle"},
                    new ControlFormItemInputComboItem() { Text = "Train"}
                ),
            new ControlToolbarItemDivider() { Alignment = TypeToolbarItemAlignment.Right },
            new ControlToolbarItemLabel("item6")
            {
                Label = "webexpress.WebUI:plugin.name",
                Color = new PropertyColorText(TypeColorText.Success),
                Alignment = TypeToolbarItemAlignment.Right
            }
        ];

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Toolbar(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Toolbar` control is a horizontal container that organizes frequently used actions — like buttons, menus, or icons — in a single, accessible location. It improves usability by grouping related commands and offering quick access to core functionality.";

            Stage.Controls =
            [
                new ControlToolbar("myToolbar")
                    .Add(_items)
                    .AddMore(new ControlDropdownItemLink() { Label = "Calculator", Icon = new IconCalculator()})
            ];

            Stage.DarkControls =
            [
                new ControlToolbar("myDarkToolbar")
                    .Add(_items)
                    .AddMore(new ControlDropdownItemLink() { Label = "Calculator", Icon = new IconCalculator()})
            ];

            Stage.Code = @"
            new ControlToolbar(""myToolbar"")
                .Add
                (
                    new ControlToolbarItemButton(""item1"") { Text = ""Home"", Icon = new IconHome()  },
                    ...
                );";

            Stage.AddItem
            (
                "Label",
                "The `Label` property specifies the visible text accompanying a toolbar icon. It helps users understand the purpose of the toolbar item at a glance, especially when the icon alone may not be intuitive.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Label = \"abc\" })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Label = "button label" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label" }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Label = "dropdown label" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label" }
                )
            );

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the image shown within a toolbar item to visually represent its function. It enables users to quickly identify the intended action and contributes to an intuitive, user friendly interface.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Icon = new IconHome() })",
                new ControlText() { Text = "System", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome() },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Icon = new IconHome() }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome() }
                ),
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new ImageIconWebExpress(pageContext.ApplicationContext) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Icon = new ImageIconWebExpress(pageContext.ApplicationContext) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new ImageIconWebExpress(pageContext.ApplicationContext) }
                )
            );

            Stage.AddItem
            (
                "Tooltip",
                "The `Tooltip` property provides a concise message that appears when a user hovers over a toolbar item. It offers additional context or instructions for the associated action, especially useful when the icon or label isn't entirely self-explanatory.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Tooltip = \"tooltip\" })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Tooltip = "tooltip" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Icon = new IconHome(), Tooltip = "tooltip" }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Tooltip = "tooltip" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Tooltip = "tooltip" }
                )
            );

            Stage.AddItem
            (
                "Color",
                "The `Color` property controls the visual appearance of a toolbar item by specifying its foreground (text/icon). It can be used to highlight important actions, indicate states (e.g. active/inactive), or harmonize the toolbar with the overall UI theme.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Color = new PropertyColorText(TypeColorText.Primary) })",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Default) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Default) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Default) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Default) }
                ),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Primary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Primary) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Primary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Primary) }
                ),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Secondary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Secondary) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Secondary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Secondary) }
                ),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Info) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Info) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Info) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Info) }
                ),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Success) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Success) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Success) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Success) }
                ),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Warning) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Warning) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Warning) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Warning) }
                ),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Danger) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Danger) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Danger) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Danger) }
                ),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Light) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Light) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Light) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Light) }
                ),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Dark) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Dark) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Dark) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Dark) }
                ),
                new ControlText() { Text = "White", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.White) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.White) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.White) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.White) }
                ),
                new ControlText() { Text = "Muted", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Muted) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Muted) }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText(TypeColorText.Muted) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText(TypeColorText.Muted) }
                ),
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Color = new PropertyColorText("gold") },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Icon = new IconHome(), Color = new PropertyColorText("gold") }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Color = new PropertyColorText("gold") },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Color = new PropertyColorText("gold") }
                )

            );

            Stage.AddItem
            (
                "Alignment",
                "The `Alignment` property determines how a toolbar item is positioned inside its parent container or toolbar strip. It influences whether the item appears left-aligned or right-aligned.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Alignment = TypeToolbarItemAlignment.Right })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Alignment = TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemDivider() { Alignment = TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemCombo() { Label = "combo label", Alignment = TypeToolbarItemAlignment.Right }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider() { Alignment = TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Alignment = TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemDivider() { Alignment = TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemLabel() { Label = "label", Alignment = TypeToolbarItemAlignment.Right }
                )
            );

            Stage.AddItem
            (
                "Disabled",
                "The `Active` property controls the interactivity state of a toolbar item. When set to disabled, the item appears visually dimmed and is functionally deactivated—meaning users cannot click or activate it. This is often used to reflect application state, user permissions, or conditional logic.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Active = TypeActive.Disabled })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Active = TypeActive.Disabled },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Active = TypeActive.Disabled }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Active = TypeActive.Disabled },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Label = "label", Disabled = true }
                )
            );

            Stage.AddItem
            (
                "Active",
                "The `Active` property reflects whether a toolbar item is currently selected or engaged.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Active = TypeActive.Active })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome(), Active = TypeActive.Active },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Label = "combo label", Active = TypeActive.Active }.Add(new ControlFormItemInputComboItem() { Text = "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = new IconHome(), Active = TypeActive.Active }
                )
            );

            Stage.AddItem
            (
                "Toggle",
                "The toggle indicator is an interactive UI element that visually signals whether additional content is collapsed or expanded. It typically consists of a labeled button accompanied by a directional arrow icon. It's commonly used in dropdown menus.",
                "new ControlToolbar().Add(new ControlToolbarItemDropdown() { Toggle = TypeToggleDropdown.Toggle })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemDropdown()
                    {
                        Icon = new IconHome(),
                        Toggle = TypeToggleDropdown.Toggle
                    }
                )
            );

            Stage.AddItem
            (
                "Add",
                "The `Add` method allows insertion of toolbar elements into the toolbar.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Icon = new IconHome() })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = new IconHome() }
                )
            );

            Stage.AddItem
            (
                "AddMore",
                "The `AddMore` method enhances the toolbar by appending extra actions that are grouped behind a consolidated entry point \"…\".",
                "new ControlToolbar().AddMore(new ControlDropdownItemLink() { Label = \"Calculator\", Icon = new IconCalculator()})",
                new ControlToolbar().AddMore
                (
                    new ControlDropdownItemLink() { Label = "Calculator", Icon = new IconCalculator() }
                )
            );
        }
    }
}
