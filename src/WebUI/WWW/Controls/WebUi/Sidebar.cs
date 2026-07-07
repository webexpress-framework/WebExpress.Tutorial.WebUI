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
    /// Represents the sidebar control for the tutorial.  
    /// </summary>  
    [Title("Sidebar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Sidebar : PageControl
    {
        private readonly IPageContext _pageContext;

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Sidebar(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            _pageContext = pageContext;
            var uri = _pageContext.Route.ToUri();

            Stage.Description = @"The `Sidebar` control is a responsive, modular UI component designed to organize and display navigation or functional items within an application. It serves as a central docking interface for interactive sidebar items and adapts seamlessly to various screen sizes and contexts.";

            Stage.Controls =
            [
                new ControlSidebar("mySidebar")
                {
                    Breakpoint = _ => 768
                }
                    .Add(CreateItems(15))
            ];

            Stage.DarkControls =
            [
                new ControlSidebar("myDarkSidebar")
                    .Add(CreateItems(15))
            ];

            Stage.Code = @"
            new ControlSidebar(""mySidebar"")
            {
                Breakpoint = 768
            }
                .Add(CreateItems(25));";

            Stage.AddProperty
            (
                "Breakpoint",
                @"The `Breakpoint` property defines the minimum viewport width, in pixels, at which the sidebar transitions from its default layout to a reduced, space-saving version. When the viewport is equal to or wider than the specified breakpoint, the sidebar remains fully visible in its standard form. If the viewport falls below this threshold, the sidebar automatically collapses into a compact layout, such as an overlay, drawer, or icon-only mode, optimized for smaller screens and mobile devices. This responsive behavior ensures consistent usability across different device sizes. By default, the breakpoint is set to 100 pixels.",
                @"
                new ControlSidebar()
                {
                    Breakpoint = _ => 768
                };",
                new ControlSidebar()
                {
                    Breakpoint = _ => 768
                }
                    .Add(CreateItems(15))
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemHeader),
                "ControlSidebarItemHeader",
                @"The `ControlSidebarItemHeader` component represents a static, non-interactive header element within the sidebar. It is typically used to visually separate groups of controls or to label sections for better orientation and readability. The header displays a simple text label and does not respond to user interaction. When the sidebar is in its default layout, usually on larger screens. The header is fully visible and helps structure the sidebar content. However, when the viewport width falls below the defined breakpoint, triggering the reduced layout mode, the header is automatically hidden.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemHeader() { Text = _ => ""Header"" });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemHeader() { Text = _ => "Header" })
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemDivider),
                "ControlSidebarItemDivider",
                @"Inserts a visual divider between sidebar items to improve structure and readability. The divider is purely decorative and does not respond to interaction. By setting `Mode = TypeSidebarMode.Hide`, the divider is automatically hidden when the sidebar enters reduced mode.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemDivider())
                    .Add(new ControlSidebarItemDivider() { Mode = _ => TypeSidebarMode.Hide });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemDivider())
                    .Add(new ControlSidebarItemDivider() { Mode = _ => TypeSidebarMode.Hide })
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemLink),
                "ControlSidebarItemLink",
                @"Adds clickable link items to the sidebar, typically used for navigation or external references. Each link includes an icon and label. Links can be conditionally hidden in reduced mode using `Mode = TypeSidebarMode.Hide`, or made dismissible by setting `Dismissibility = TypeDismissibilitySidebar.Dismissible`.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink() 
                    { 
                        Icon = _ => new IconStaffSnake(), 
                        Text = _ => ""Link 1"", 
                        Uri = _ => uri
                    })
                    .Add(new ControlSidebarItemLink() 
                    { 
                        Icon = _ => new IconStaffSnake(), 
                        Text = _ => ""Link 2"", 
                        Uri = _ => uri, 
                        Mode = _ => TypeSidebarMode.Hide 
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconStaffSnake(),
                        Text = _ => ""Link 3"",
                        Uri = _ => uri,
                        Dismissibility = _ => TypeDismissibilitySidebar.Dismissible
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconComputerMouse(),
                        Text = _ => "Link 1",
                        Uri = _ => uri
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconKeyboard(),
                        Text = _ => "Link 2",
                        Uri = _ => uri,
                        Mode = _ => TypeSidebarMode.Hide
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconComputer(),
                        Text = _ => "Link 3",
                        Uri = _ => uri,
                        Dismissibility = _ => TypeDismissibilitySidebar.Dismissible
                    })
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemLink),
                "ControlSidebarItemLink (Badge & Hierarchy)",
                @"A `ControlSidebarItemLink` can carry a `Badge`, for example an unread or item count, colored through `BadgeColor`. Nesting child links with `.Add(...)` turns the link into a collapsible group whose subtree the user can expand and collapse; `Expanded = _ => true` renders the group open. Badges and hierarchy compose, so a parent may show an aggregate count while its children carry their own.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconComputerMouse(),
                        Text = _ => ""Inbox"",
                        Badge = _ => ""12"",
                        BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => ""Projects"",
                        Expanded = _ => true
                    }
                        .Add(new ControlSidebarItemLink() { Text = _ => ""Alpha"", Badge = _ => ""3"" })
                        .Add(new ControlSidebarItemLink() { Text = _ => ""Beta"" }));",
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconComputerMouse(),
                        Text = _ => "Inbox",
                        Uri = _ => uri,
                        Badge = _ => "12",
                        BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => "Projects",
                        Expanded = _ => true
                    }
                        .Add(new ControlSidebarItemLink()
                        {
                            Icon = _ => new IconKeyboard(),
                            Text = _ => "Alpha",
                            Uri = _ => uri,
                            Badge = _ => "3",
                            BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                        })
                        .Add(new ControlSidebarItemLink()
                        {
                            Icon = _ => new IconComputer(),
                            Text = _ => "Beta",
                            Uri = _ => uri
                        }))
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemLink),
                "ControlSidebarItemLink (Options & Colors)",
                @"A `ControlSidebarItemLink` can expose a trailing ""..."" options menu through `AddOption(...)`. Like the table row menu, it is revealed only on hover and appears exclusively when options are present, so quiet rows stay uncluttered. The menu works for flat links and nested tree items alike. The row itself can be tinted with `Color` (text) and `BackgroundColor` (background); each accepts a predefined framework color, emitted as a css class, or a custom value, emitted as an inline style, so a row can be highlighted without writing any css.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconComputerMouse(),
                        Text = _ => ""With options""
                    }
                        .AddOption(new ControlDropdownItemLink() { Icon = _ => new IconPenToSquare(), Text = _ => ""Edit"" })
                        .AddOption(new ControlDropdownItemLink() { Icon = _ => new IconCopy(), Text = _ => ""Duplicate"" })
                        .AddOption(new ControlDropdownItemDivider())
                        .AddOption(new ControlDropdownItemLink() { Icon = _ => new IconTrash(), Text = _ => ""Delete"" }))
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => ""Danger text"",
                        Color = _ => new PropertyColorText(TypeColorText.Danger)
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => ""Custom"",
                        Color = _ => new PropertyColorText(""#ffffff""),
                        BackgroundColor = _ => new PropertyColorBackground(""#6f42c1"")
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconComputerMouse(),
                        Text = _ => "With options",
                        Uri = _ => uri
                    }
                        .AddOption(new ControlDropdownItemLink() { Icon = _ => new IconPenToSquare(), Text = _ => "Edit", Uri = _ => uri })
                        .AddOption(new ControlDropdownItemLink() { Icon = _ => new IconCopy(), Text = _ => "Duplicate", Uri = _ => uri })
                        .AddOption(new ControlDropdownItemDivider())
                        .AddOption(new ControlDropdownItemLink() { Icon = _ => new IconTrash(), Text = _ => "Delete", Uri = _ => uri }))
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => "Danger text",
                        Uri = _ => uri,
                        Color = _ => new PropertyColorText(TypeColorText.Danger)
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => "Highlighted",
                        Uri = _ => uri,
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Highlight)
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = _ => new IconHome(),
                        Text = _ => "Custom",
                        Uri = _ => uri,
                        Color = _ => new PropertyColorText("#ffffff"),
                        BackgroundColor = _ => new PropertyColorBackground("#6f42c1")
                    })
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemControl),
                "ControlSidebarItemControl",
                @"Embeds a custom content block into the sidebar. This item can host arbitrary controls such as text, buttons, sliders, or other UI elements, making it highly flexible for contextual content. An optional icon may be displayed alongside the content to provide visual cues or reinforce meaning. The Mode property controls how the item behaves in responsive layouts:
                  - `Mode = _ => TypeSidebarModeExtended.Hide`: will hide the item when the sidebar enters reduced mode.
                  - `Mode = _ => TypeSidebarModeExtended.Overlay`: displays it as overlay in reduced mode.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = _ => new IconMountainSun(),
                        Content = _ => new ControlText() { Text = ""Overlay"" },
                        Mode = _ => TypeSidebarModeExtended.Overlay
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = _ => new IconMountain(),
                        Content = new ControlText() { Text = _ => "Default" }
                    })
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = _ => new IconMountainSun(),
                        Content = new ControlText() { Text = _ => "Hide" },
                        Mode = _ => TypeSidebarModeExtended.Hide
                    })
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = _ => new IconMountainSun(),
                        Content = new ControlText() { Text = _ => "Overlay" },
                        Mode = _ => TypeSidebarModeExtended.Overlay
                    })
            );

            Stage.AddItem
            (
                typeof(ControlSidebarItemControl),
                "ControlSidebarItemIcon",
                @"Adds a freely placeable icon element to the sidebar, optionally combined with an edit button on hover and an optional modal. In compact mode the icon is displayed small, otherwise large. Optionally, a text label can be shown below the icon. The properties `IconClass`, `IconImage`, `IconText`, `IconEdit`, and `IconEditModal` control appearance and behavior.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemIcon()
                    {
                        Icon = _ => new IconHome(),
                        IconEdit = _ => true,
                        PrimaryAction = _ => new ActionModal(""modalId""),
                        Text = _ => ""My Icon"",
                        // Mode = _ => TypeSidebarMode.Default  // if needed
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemIcon()
                    {
                        Icon = _ => new IconHome(),
                        IconEdit = _ => true,
                        PrimaryAction = _ => new ActionModal("modalId"),
                        Text = _ => "My Icon"
                    })
            );
        }

        /// <summary>
        /// Creates a collection of sidebar items with sequential labels and icons.
        /// </summary>
        /// <remarks>
        /// <returns>
        /// An enumerable collection of <see cref="IControlSidebarItem"/> objects, each representing a 
        /// sidebar item with a unique label and a icon.
        /// </returns>
        private IEnumerable<IControlSidebarItem> CreateItems(int count)
        {
            for (int i = 0; i <= count; i++)
            {
                if (i % 10 == 0)
                {
                    yield return new ControlSidebarItemHeader()
                    {
                        Text = _ => $"Header {i}",
                    };

                    continue;
                }
                else if (i % 5 == 0)
                {
                    yield return new ControlSidebarItemDivider();

                    continue;
                }

                yield return new ControlSidebarItemLink($"item{i}")
                {
                    Text = _ => $"Item {i}",
                    Icon = _ => i % 2 == 0 ? new IconDog() : new IconCat(),
                    Mode = _ => i % 2 == 0 ? TypeSidebarMode.Hide : TypeSidebarMode.Default,
                    Dismissibility = _ => i % 2 == 0 ? TypeDismissibilitySidebar.Dismissible : TypeDismissibilitySidebar.None,
                    Uri = _ => _pageContext.Route.ToUri(),
                };
            }

            yield return new ControlSidebarItemControl()
            {
                Icon = _ => new IconGift(),
                Content = new ControlButton()
                {
                    Text = (c) => "button",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                },
                Mode = _ => TypeSidebarModeExtended.Overlay
            };
        }
    }
}
