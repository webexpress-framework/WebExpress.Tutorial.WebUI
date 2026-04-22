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
                new ControlList()
                {
                    Title = "List Control Example",
                    Sortable = true
                }
                    .Add(new ControlListItem(null) { Text = "First Element" ,
                    BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Primary) })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" })
            ];

            Stage.Code = @"
            new ControlList()
            {
                Title = ""List Control Example"",
                Sortable = true
            }
                .Add(new ControlListItem(null) { Text = ""First Element"" })
                .Add(new ControlListItem(null) { Text = ""Second Element"" })
                .Add(new ControlListItem(null) { Text = ""Third Element"" })";

            Stage.AddProperty
            (
                "Layout",
                "Determines the layout",
                "Layout = TypeLayoutList.Group",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Default
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" }),
                new ControlText() { Text = "Simple", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Simple
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" }),
                new ControlText() { Text = "Group", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Group
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" }),
                new ControlText() { Text = "Flush", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Flush
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" }),
                new ControlText() { Text = "Horizontal", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Horizontal
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" })
            );

            Stage.AddProperty
            (
                "Active",
                "Determines the active status of a list item. Note: Only applied for Group, Flush, and Horizontal.",
                "Active = TypeActive.Active",
                new ControlList()
                {
                    Layout = TypeLayoutList.Group
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" })
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Determines the background color of a list item.",
                "BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Primary)",
                new ControlList()
                {
                    Layout = TypeLayoutList.Group
                }
                    .Add(new ControlListItem(null)
                    {
                        Text = "Default Background"
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Primary Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Primary)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Secondary Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Light)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Info Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Secondary)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Success Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Info)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Warning Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Success)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Error Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Warning)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Dark Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Danger)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Light Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Dark)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "White Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.White)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Transparent Background",
                        BackgroundColor = new PropertyColorBackgroundList(TypeColorBackgroundList.Transparent)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = "Custom Background",
                        BackgroundColor = new PropertyColorBackgroundList("gold"),
                        Color = new PropertyColorText("red")
                    })
            );

            Stage.AddItem
            (
                typeof(ControlListItem),
                "ControlListItem",
                "A simple list item.",
                "new ControlListItem(...);",
                new ControlList()
                {
                    Layout = TypeLayoutList.Group
                }
                    .Add(new ControlListItem(null) { Text = "First Element" })
                    .Add(new ControlListItem(null) { Text = "Second Element" })
                    .Add(new ControlListItem(null) { Text = "Third Element" })
            );

            Stage.AddItem
            (
                typeof(ControlListItemLink),
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
                typeof(ControlListItemButton),
                "ControlListItemButton",
                "A button as a list entry.",
                "new ControlListItemButton(...);",
                new ControlList
                (
                    null,
                    new ControlListItemButton(null) { Text = "First Element" },
                    new ControlListItemButton(null) { Text = "Second Element" },
                    new ControlListItemButton(null) { Text = "Third Element" }
                )
                {
                    Layout = TypeLayoutList.Group
                }
            );

            Stage.AddItemProperty
            (
                typeof(ControlListItemButton),
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = new ActionModal(\"modal\")",
                new ControlList
                (
                    null,
                    new ControlListItemButton()
                    {
                        Text = "First Element",
                        PrimaryAction = new ActionModal("modal"),
                        Icon = new IconAt()
                    },
                    new ControlListItemButton(null)
                    {
                        Text = "Second Element",
                        PrimaryAction = new ActionModal("modal")
                    },
                    new ControlListItemButton()
                    {
                        Text = "Third Element",
                        PrimaryAction = new ActionModal("modal")
                    }
                ),
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddItemProperty
            (
                typeof(ControlListItemButton),
                "SecondaryAction",
                "Defines the secondary user action, often triggered by a double‑click to open a dialog or perform an alternative operation.",
                "SecondaryAction = new ActionModal(\"modal\")",
                new ControlList
                (
                    null,
                    new ControlListItemButton()
                    {
                        Text = "First Element",
                        SecondaryAction = new ActionModal("modal"),
                        Icon = new IconAt()
                    },
                    new ControlListItemButton(null)
                    {
                        Text = "Second Element",
                        SecondaryAction = new ActionModal("modal")
                    },
                    new ControlListItemButton()
                    {
                        Text = "Third Element",
                        SecondaryAction = new ActionModal("modal")
                    }
                ),
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
