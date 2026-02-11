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

namespace WebExpress.Tutorial.WebUI.WWW.Controls
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
                    Breakpoint = 768
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
                    Breakpoint = 768
                };",
                new ControlSidebar()
                {
                    Breakpoint = 768
                }
                    .Add(CreateItems(15))
            );

            Stage.AddItem
            (
                "ControlSidebarItemHeader",
                @"The `ControlSidebarItemHeader` component represents a static, non-interactive header element within the sidebar. It is typically used to visually separate groups of controls or to label sections for better orientation and readability. The header displays a simple text label and does not respond to user interaction. When the sidebar is in its default layout, usually on larger screens. The header is fully visible and helps structure the sidebar content. However, when the viewport width falls below the defined breakpoint, triggering the reduced layout mode, the header is automatically hidden.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemHeader() { Text = ""Header"" });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemHeader() { Text = "Header" })
            );

            Stage.AddItem
            (
                "ControlSidebarItemDivider",
                @"Inserts a visual divider between sidebar items to improve structure and readability. The divider is purely decorative and does not respond to interaction. By setting `Mode = TypeSidebarMode.Hide`, the divider is automatically hidden when the sidebar enters reduced mode.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemDivider())
                    .Add(new ControlSidebarItemDivider() { Mode = TypeSidebarMode.Hide });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemDivider())
                    .Add(new ControlSidebarItemDivider() { Mode = TypeSidebarMode.Hide })
            );

            Stage.AddItem
            (
                "ControlSidebarItemLink",
                @"Adds clickable link items to the sidebar, typically used for navigation or external references. Each link includes an icon and label. Links can be conditionally hidden in reduced mode using `Mode = TypeSidebarMode.Hide`, or made dismissible by setting `Dismissibility = TypeDismissibilitySidebar.Dismissible`.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink() 
                    { 
                        Icon = new IconStaffSnake(), 
                        Text = ""Link 1"", 
                        Uri = uri
                    })
                    .Add(new ControlSidebarItemLink() 
                    { 
                        Icon = new IconStaffSnake(), 
                        Text = ""Link 2"", 
                        Uri = uri, 
                        Mode = TypeSidebarMode.Hide 
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = new IconStaffSnake(),
                        Text = ""Link 3"",
                        Uri = uri,
                        Dismissibility = TypeDismissibilitySidebar.Dismissible
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = new IconComputerMouse(),
                        Text = "Link 1",
                        Uri = uri
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = new IconKeyboard(),
                        Text = "Link 2",
                        Uri = uri,
                        Mode = TypeSidebarMode.Hide
                    })
                    .Add(new ControlSidebarItemLink()
                    {
                        Icon = new IconComputer(),
                        Text = "Link 3",
                        Uri = uri,
                        Dismissibility = TypeDismissibilitySidebar.Dismissible
                    })
            );

            Stage.AddItem
            (
                "ControlSidebarItemControl",
                @"Embeds a custom content block into the sidebar. This item can host arbitrary controls such as text, buttons, sliders, or other UI elements, making it highly flexible for contextual content. An optional icon may be displayed alongside the content to provide visual cues or reinforce meaning. The Mode property controls how the item behaves in responsive layouts:
                  - `Mode = TypeSidebarModeExtended.Hide`: will hide the item when the sidebar enters reduced mode.
                  - `Mode = TypeSidebarModeExtended.Overlay`: displays it as overlay in reduced mode.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = new IconMountainSun(),
                        Content = new ControlText() { Text = ""Overlay"" },
                        Mode = TypeSidebarModeExtended.Overlay
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = new IconMountain(),
                        Content = new ControlText() { Text = "Default" }
                    })
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = new IconMountainSun(),
                        Content = new ControlText() { Text = "Hide" },
                        Mode = TypeSidebarModeExtended.Hide
                    })
                    .Add(new ControlSidebarItemControl()
                    {
                        Icon = new IconMountainSun(),
                        Content = new ControlText() { Text = "Overlay" },
                        Mode = TypeSidebarModeExtended.Overlay
                    })
            );

            Stage.AddItem
            (
                "ControlSidebarItemIcon",
                @"Adds a freely placeable icon element to the sidebar, optionally combined with an edit button on hover and an optional modal. In compact mode the icon is displayed small, otherwise large. Optionally, a text label can be shown below the icon. The properties `IconClass`, `IconImage`, `IconText`, `IconEdit`, and `IconEditModal` control appearance and behavior.",
                @"
                new ControlSidebar()
                    .Add(new ControlSidebarItemIcon()
                    {
                        Icon = new IconHome(),
                        IconEdit = true,
                        PrimaryAction = new ActionModal(""modalId""),
                        Text = ""My Icon"",
                        // Mode = TypeSidebarMode.Default  // if needed
                    });",
                new ControlSidebar()
                    .Add(new ControlSidebarItemIcon()
                    {
                        Icon = new IconHome(),
                        IconEdit = true,
                        PrimaryAction = new ActionModal("modalId"),
                        Text = "My Icon"
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
                        Text = $"Header {i}",
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
                    Text = $"Item {i}",
                    Icon = i % 2 == 0 ? new IconDog() : new IconCat(),
                    Mode = i % 2 == 0 ? TypeSidebarMode.Hide : TypeSidebarMode.Default,
                    Dismissibility = i % 2 == 0 ? TypeDismissibilitySidebar.Dismissible : TypeDismissibilitySidebar.None,
                    Uri = _pageContext.Route.ToUri(),
                };
            }

            yield return new ControlSidebarItemControl()
            {
                Icon = new IconGift(),
                Content = new ControlButton()
                {
                    Text = "button",
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
                },
                Mode = TypeSidebarModeExtended.Overlay
            };
        }
    }
}
