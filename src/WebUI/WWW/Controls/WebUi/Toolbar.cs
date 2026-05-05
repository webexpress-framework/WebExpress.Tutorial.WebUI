using System.Collections.Generic;
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
            new ControlToolbarItemButton("item1") { Text = _ => "Home", Icon =_ =>  new IconHome() },
            new ControlToolbarItemDivider(),
            new ControlToolbarItemButton("item2")
            {
                Text = _ => "Server",
                Icon = _ => new IconServer(),
                Color = _ => new PropertyColorText(TypeColorText.Warning)
            },
            new ControlToolbarItemDropdown("item3")
            {
                Text = _ => "Users",
                Icon = _ => new IconUsers(),
                Color = _ => new PropertyColorText(TypeColorText.Danger),
            }
                .Add
                (
                    new ControlDropdownItemLink("item3-1") { Text = "Profile", Icon = new IconUser()},
                    new ControlDropdownItemLink("item3-2") { Text = "Preferences", Icon = new IconStar() },
                    new ControlDropdownItemLink("item3-3") { Text = "Logout", Icon = new IconPowerOff()}
                ),
            new ControlToolbarItemButton("item4")
            {
                Text = _ => "Setting",
                Icon = _ => new IconCog(),
                Alignment = _ => TypeToolbarItemAlignment.Right
            },
            new ControlToolbarItemButton("item5") { Text = _ => "Item 5", Icon =_ =>  new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item6") { Text = _ => "Item 6", Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item7") { Text = _ => "Item 7", Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item8") { Text = _ => "Item 8", Icon = _ => new IconHome(), Alignment  =_ => TypeToolbarItemAlignment.Right },
            new ControlToolbarItemButton("item9") { Text = _ => "Item 9", Icon = _ => new IconHome() , Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item10") { Text = _ => "Item 10", Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right },
            new ControlToolbarItemButton("item11") { Text = _ => "Item 11", Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right },
            new ControlToolbarItemButton("item12") { Text = _ => "Item 12", Icon = _ => new IconHome() , Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item13") { Text = _ => "Item 13", Icon = _ => new IconHome() , Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item14") { Text = _ => "Item 14", Icon =_ =>  new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right },
            new ControlToolbarItemButton("item15") { Text = _ => "Item 15", Icon = _ => new IconHome() , Alignment = _ => TypeToolbarItemAlignment.Right},
            new ControlToolbarItemButton("item16") { Text = _ => "Item 16", Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right },
            new ControlToolbarItemCombo("item17")
            {
                Text = _ => "Vehicle",
                Icon = _ => new IconCar(),
                Color = _ => new PropertyColorText(TypeColorText.Primary),
                Alignment = _ => TypeToolbarItemAlignment.Right
            }
                .Add
                (
                    new ControlFormItemInputComboItem() { Text = _ => "Car"},
                    new ControlFormItemInputComboItem() { Text = _ => "Bicycle"},
                    new ControlFormItemInputComboItem() { Text = _ => "Train"}
                ),
            new ControlToolbarItemDivider() { Alignment = _ => TypeToolbarItemAlignment.Right },
            new ControlToolbarItemLabel("item18")
            {
                Text = _ => "webexpress.WebUI:plugin.name",
                Color = _ => new PropertyColorText(TypeColorText.Success),
                Alignment = _ => TypeToolbarItemAlignment.Right
            },

             new ControlToolbarItemButton("item19") { Text = _ => "Item 19", Icon = _ => new IconHome() },
             new ControlToolbarItemButton("item20") { Text = _ => "Item 20", Icon = _ => new IconHome() },
             new ControlToolbarItemButton("item21") { Text = _ => "Item 21", Icon =_ =>  new IconHome() },
        ];

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Toolbar(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Toolbar` control is a horizontal container that organizes frequently used actions, like buttons, menus, or icons, in a single, accessible location. It improves usability by grouping related commands and offering quick access to core functionality.";

            Stage.Controls =
            [
                new ControlToolbar("myToolbar")
                    .Add(CreateItems(25))
                    .AddMore(new ControlDropdownItemLink() { Text = "Calculator", Icon = new IconCalculator()})
            ];

            Stage.DarkControls =
            [
                new ControlToolbar("myDarkToolbar")
                    .Add(CreateItems(25))
                    .AddMore(new ControlDropdownItemLink() { Text = "Calculator", Icon = new IconCalculator()})
            ];

            Stage.Code = @"
            new ControlToolbar(""myToolbar"")
                .Add(CreateItems(25))
                .AddMore(new ControlDropdownItemLink() { Text = _ => ""Calculator"", Icon = _ => new IconCalculator()})";

            Stage.AddItem
            (
                typeof(ControlToolbarItemButton),
                "ControlToolbarItemButton",
                "A `ControlToolbarItemButton` represents an interactive action element within a toolbar. It is typically used to trigger commands such as creating, saving, refreshing, or navigating. Each button can display an icon, a text label, or both, providing a clear and accessible way for users to understand the available actions. Toolbar buttons are designed to be compact, consistent, and easy to recognize, ensuring that frequently used operations remain quickly accessible across the interface. By combining visual cues with optional descriptive text, `ControlToolbarItemButton` supports intuitive and efficient user workflows.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Label = _ => \"abc\" })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Text = _ => "button label" }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Label",
                "The `Label` property specifies the visible text accompanying a toolbar icon. It helps users understand the purpose of the toolbar item at a glance, especially when the icon alone may not be intuitive.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Label = _ => \"abc\" })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Text = _ => "button label" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label" }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Text = _ => "dropdown label" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label" }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Icon",
                "The `Icon` property defines the image shown within a toolbar item to visually represent its function. It enables users to quickly identify the intended action and contributes to an intuitive, user friendly interface.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Icon = _ => new IconHome() })",
                new ControlText() { Text = "System", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome() },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Icon = _ => new IconHome() }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome() }
                ),
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new ImageIconWebExpress(pageContext.ApplicationContext) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Icon = _ => new ImageIconWebExpress(pageContext.ApplicationContext) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new ImageIconWebExpress(pageContext.ApplicationContext) }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Tooltip",
                "The `Tooltip` property provides a concise message that appears when a user hovers over a toolbar item. It offers additional context or instructions for the associated action, especially useful when the icon or label isn't entirely self-explanatory.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Tooltip = _ => \"tooltip\" })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Tooltip = _ => "tooltip" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Icon = _ => new IconHome(), Tooltip = _ => "tooltip" }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Tooltip = _ => "tooltip" },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Tooltip = _ => "tooltip" }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Color",
                "The `Color` property controls the visual appearance of a toolbar item by specifying its foreground (text/icon). It can be used to highlight important actions, indicate states (e.g. active/inactive), or harmonize the toolbar with the overall UI theme.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Color = _ => new PropertyColorText(TypeColorText.Primary) })",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Default) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Default) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Default) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Default) }
                ),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Primary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Primary) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Primary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Primary) }
                ),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Secondary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Secondary) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Secondary) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Secondary) }
                ),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Info) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Info) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Info) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Info) }
                ),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Success) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Success) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Success) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Success) }
                ),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Warning) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Warning) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Warning) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Warning) }
                ),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Danger) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Danger) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Danger) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Danger) }
                ),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Light) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Light) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Light) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Light) }
                ),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Dark) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Dark) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Dark) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Dark) }
                ),
                new ControlText() { Text = "White", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.White) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.White) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.White) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.White) }
                ),
                new ControlText() { Text = "Muted", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Muted) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Muted) }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText(TypeColorText.Muted) },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText(TypeColorText.Muted) }
                ),
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText("gold") },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Icon = _ => new IconHome(), Color = _ => new PropertyColorText("gold") }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Color = _ => new PropertyColorText("gold") },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Color = _ => new PropertyColorText("gold") }
                )

            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Alignment",
                "The `Alignment` property determines how a toolbar item is positioned inside its parent container or toolbar strip. It influences whether the item appears left-aligned or right-aligned.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Alignment = _ => TypeToolbarItemAlignment.Right })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemDivider() { Alignment = _ => TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Alignment = _ => TypeToolbarItemAlignment.Right }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider() { Alignment = _ => TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Alignment = _ => TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemDivider() { Alignment = _ => TypeToolbarItemAlignment.Right },
                    new ControlToolbarItemLabel() { Text = _ => "label", Alignment = _ => TypeToolbarItemAlignment.Right }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Disabled",
                "The `Active` property controls the interactivity state of a toolbar item. When set to disabled, the item appears visually dimmed and is functionally deactivated—meaning users cannot click or activate it. This is often used to reflect application state, user permissions, or conditional logic.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Active = _ => TypeActive.Disabled })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Active = _ => TypeActive.Disabled },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Active = _ => TypeActive.Disabled }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Active = _ => TypeActive.Disabled },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemLabel() { Text = _ => "label", Disabled = _ => true }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Active",
                "The `Active` property reflects whether a toolbar item is currently selected or engaged.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Active = _ => TypeActive.Active })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome(), Active = _ => TypeActive.Active },
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemCombo() { Text = _ => "combo label", Active = _ => TypeActive.Active }.Add(new ControlFormItemInputComboItem() { Text = _ => "combo" }),
                    new ControlToolbarItemDivider(),
                    new ControlToolbarItemDropdown() { Icon = _ => new IconHome(), Active = _ => TypeActive.Active }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Toggle",
                "The toggle indicator is an interactive UI element that visually signals whether additional content is collapsed or expanded. It typically consists of a labeled button accompanied by a directional arrow icon. It's commonly used in dropdown menus.",
                "new ControlToolbar().Add(new ControlToolbarItemDropdown() { Toggle = _ => TypeToggleDropdown.Toggle })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemDropdown()
                    {
                        Icon = _ => new IconHome(),
                        Toggle = _ => TypeToggleDropdown.Toggle
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "Add",
                "The `Add` method allows insertion of toolbar elements into the toolbar.",
                "new ControlToolbar().Add(new ControlToolbarItemButton() { Icon = _ => new IconHome() })",
                new ControlToolbar().Add
                (
                    new ControlToolbarItemButton() { Icon = _ => new IconHome() }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlToolbarItemButton),
                "AddMore",
                "The `AddMore` method enhances the toolbar by appending extra actions that are grouped behind a consolidated entry point \"…\".",
                "new ControlToolbar().AddMore(new ControlDropdownItemLink() { Label = _ => \"Calculator\", Icon = _ => new IconCalculator()})",
                new ControlToolbar().AddMore
                (
                    new ControlDropdownItemLink() { Text = "Calculator", Icon = new IconCalculator() }
                )
            );
        }

        /// <summary>
        /// Creates a collection of toolbar items with sequential labels and icons.
        /// </summary>
        /// <remarks>
        /// <returns>
        /// An enumerable collection of <see cref="IControlToolbarItem"/> objects, each representing a 
        /// toolbar item with a unique label and a icon.
        /// </returns>
        private IEnumerable<IControlToolbarItem> CreateItems(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                var alignment = i > count / 2 ? TypeToolbarItemAlignment.Right : TypeToolbarItemAlignment.Left;

                if (i % 3 == 0)
                {
                    yield return new ControlToolbarItemDivider() { Alignment = _ => alignment };
                }
                yield return new ControlToolbarItemButton($"item{i}")
                {
                    Text = _ => $"Item {i}",
                    Icon = i > count / 2 ? _ => new IconCat() : _ => new IconDog(),
                    Alignment = _ => alignment
                };
            }
        }
    }
}
