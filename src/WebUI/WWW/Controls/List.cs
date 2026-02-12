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

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the list control for the tutorial.  
    /// </summary>  
    [Title("List")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class List : PageControl
    {
        private readonly IControlDropdownItem _item1 = new ControlDropdownItemHeader() { Text = "Header" };
        private readonly IControlDropdownItem _item2 = new ControlDropdownItemLink() { Text = "First Entry", Icon = new IconWrench() };
        private readonly IControlDropdownItem _item3 = new ControlDropdownItemLink() { Text = "Second Entry" };
        private readonly IControlDropdownItem _item4 = new ControlDropdownItemDivider();
        private readonly IControlDropdownItem _item5 = new ControlDropdownItemLink() { Text = "Third Entry" };

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the list control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public List(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `List` control is a powerful component used to present a collection of items in a structured and organized way. It supports various display styles, such as ordered and unordered lists, and offers extensive customization options for layout and design. The List control can also handle dynamic content, providing developers with the flexibility to adapt to changing data.";

            Stage.Controls = [
                new ControlList
                (
                    "myList",
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
            ];

            Stage.Code = @"
            new ControlList
            (
                ""myList"",
                new ControlListItem(null, new ControlText() { Text = ""First Element"" }),
                new ControlListItem(null, new ControlText() { Text = ""Second Element"" }),
                new ControlListItem(null, new ControlText() { Text = ""Third Element"" })
            );";

            Stage.AddProperty
            (
                "Layout",
                "Determines the layout",
                "Layout = TypeLayoutList.Group",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Default
                },
                new ControlText() { Text = "Simple", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Simple
                },
                new ControlText() { Text = "Group", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Group
                },
                new ControlText() { Text = "Flush", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Flush
                },
                new ControlText() { Text = "Horizontal", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Horizontal
                }
            );

            Stage.AddProperty
            (
                "Active",
                "Determines the active status of a list item. Note: Only applied for Group, Flush, and Horizontal.",
                "Active = TypeActive.Active",
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "None" }) { Active = TypeActive.None },
                    new ControlListItem(null, new ControlText() { Text = "Activated" }) { Active = TypeActive.Active },
                    new ControlListItem(null, new ControlText() { Text = "Disabled" }) { Active = TypeActive.Disabled }
                )
                {
                    Layout = TypeLayoutList.Group
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Determines the background color of a list item.",
                "BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Primary)",
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "Default Background" }),
                    new ControlListItem(null, new ControlText() { Text = "Primary Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Primary) },
                    new ControlListItem(null, new ControlText() { Text = "Secondary Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Light) },
                    new ControlListItem(null, new ControlText() { Text = "Info Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Secondary) },
                    new ControlListItem(null, new ControlText() { Text = "Success Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Info) },
                    new ControlListItem(null, new ControlText() { Text = "Warning Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Success) },
                    new ControlListItem(null, new ControlText() { Text = "Error Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Warning) },
                    new ControlListItem(null, new ControlText() { Text = "Dark Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Danger) },
                    new ControlListItem(null, new ControlText() { Text = "Light Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Dark) },
                    new ControlListItem(null, new ControlText() { Text = "White Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.White) },
                    new ControlListItem(null, new ControlText() { Text = "Transparent Background" }) { BackgroundColor = new PropertyColorBackgroundList(TypeColorBackground.Transparent) },
                    new ControlListItem(null, new ControlText() { Text = "Custom Background" }) { BackgroundColor = new PropertyColorBackgroundList("gold"), TextColor = new PropertyColorText("red") }
                )
                {
                    Layout = TypeLayoutList.Group
                }
            );

            Stage.AddItem
            (
                "ControlListItem",
                "A simple list item.",
                "new ControlListItem(...);",
                new ControlList
                (
                    null,
                    new ControlListItem(null, new ControlText() { Text = "First Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItem(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Group
                }
            );

            Stage.AddItem
            (
                "ControlListItemLink",
                "A link as a list entry.",
                "new ControlListItemLink(...);",
                new ControlList
                (
                    null,
                    new ControlListItemLink() { Text = "First Element", Uri = pageContext.Route.ToUri(), Icon = new IconAt() },
                    new ControlListItemLink() { Text = "Second Element", Uri = pageContext.Route.ToUri(), Tooltip = "Tooltip" },
                    new ControlListItemLink() { Text = "Third Element", Uri = pageContext.Route.ToUri(), Title = "Title" }
                )
                {
                    Layout = TypeLayoutList.Group
                }
            );

            Stage.AddItem
            (
                "ControlListItemButton",
                "A button as a list entry.",
                "new ControlListItemButton(...);",
                new ControlList
                (
                    null,
                    new ControlListItemButton(null, new ControlText() { Text = "First Element" }),
                    new ControlListItemButton(null, new ControlText() { Text = "Second Element" }),
                    new ControlListItemButton(null, new ControlText() { Text = "Third Element" })
                )
                {
                    Layout = TypeLayoutList.Group
                }
            );

            Stage.AddItem
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = new ActionModal(\"modal\")",
                new ControlList
                (
                    null,
                    new ControlListItemLink() { Text = "First Element", PrimaryAction = new ActionModal("modal"), Icon = new IconAt() },
                    new ControlListItemButton(null, new ControlText() { Text = "Second Element" }) { PrimaryAction = new ActionModal("modal") },
                    new ControlListItemLink() { Text = "Third Element", PrimaryAction = new ActionModal("modal"), Title = "Title" }
                ),
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddItem
            (
                "SecondaryAction",
                "Defines the secondary user action, often triggered by a double‑click to open a dialog or perform an alternative operation.",
                "SecondaryAction = new ActionModal(\"modal\")",
                new ControlList
                (
                    null,
                    new ControlListItemLink() { Text = "First Element", SecondaryAction = new ActionModal("modal"), Icon = new IconAt() },
                    new ControlListItemButton(null, new ControlText() { Text = "Second Element" }) { SecondaryAction = new ActionModal("modal") },
                    new ControlListItemLink() { Text = "Third Element", SecondaryAction = new ActionModal("modal"), Title = "Title" }
                ),
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
