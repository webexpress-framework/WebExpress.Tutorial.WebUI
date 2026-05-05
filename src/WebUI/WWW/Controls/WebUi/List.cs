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
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" })
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
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" }),
                new ControlText() { Text = "Simple", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Simple
                }
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" }),
                new ControlText() { Text = "Group", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Group
                }
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" }),
                new ControlText() { Text = "Flush", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Flush
                }
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" }),
                new ControlText() { Text = "Horizontal", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlList()
                {
                    Layout = TypeLayoutList.Horizontal
                }
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" })
            );

            Stage.AddProperty
            (
                "Selectable",
                "Enables item selection within the list. When `Selectable` is set to true, each list item becomes interactive and can be highlighted or chosen by the user. This mode is typically used when the list represents actionable entries, supports navigation, or triggers detail views based on the selected element.",
                "Selectable = true",
                new ControlList()
                {
                    Selectable = _ => true
                }
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" })
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
                        Text = _ => "Default Background"
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Primary Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Primary)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Secondary Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Light)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Info Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Secondary)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Success Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Info)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Warning Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Success)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Error Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Warning)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Dark Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Danger)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Light Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Dark)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "White Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.White)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Transparent Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList(TypeColorBackgroundList.Transparent)
                    })
                    .Add(new ControlListItem(null)
                    {
                        Text = _ => "Custom Background",
                        BackgroundColor = _ => new PropertyColorBackgroundList("gold"),
                        Color = _ => new PropertyColorText("red")
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
                    .Add(new ControlListItem(null) { Text = _ => "First Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Second Element" })
                    .Add(new ControlListItem(null) { Text = _ => "Third Element" })
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
                    new ControlListItemLink() { Text = _ => "First Element", Uri = _ => pageContext.Route.ToUri(), Icon = _ => new IconAt() },
                    new ControlListItemLink() { Text = _ => "Second Element", Uri = _ => pageContext.Route.ToUri(), Tooltip = _ => "Tooltip" },
                    new ControlListItemLink() { Text = _ => "Third Element", Uri = _ => pageContext.Route.ToUri(), Title = _ => "Title" }
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
                    new ControlListItemButton(null) { Text = _ => "First Element" },
                    new ControlListItemButton(null) { Text = _ => "Second Element" },
                    new ControlListItemButton(null) { Text = _ => "Third Element" }
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
                        Text = _ => "First Element",
                        PrimaryAction = _ => new ActionModal("modal"),
                        Icon = _ => new IconAt()
                    },
                    new ControlListItemButton(null)
                    {
                        Text = _ => "Second Element",
                        PrimaryAction = _ => new ActionModal("modal")
                    },
                    new ControlListItemButton()
                    {
                        Text = _ => "Third Element",
                        PrimaryAction = _ => new ActionModal("modal")
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
                        Text = _ => "First Element",
                        SecondaryAction = _ => new ActionModal("modal"),
                        Icon = _ => new IconAt()
                    },
                    new ControlListItemButton(null)
                    {
                        Text = _ => "Second Element",
                        SecondaryAction = _ => new ActionModal("modal")
                    },
                    new ControlListItemButton()
                    {
                        Text = _ => "Third Element",
                        SecondaryAction = _ => new ActionModal("modal")
                    }
                ),
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
