using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the tab control for the tutorial.    
    /// </summary>    
    [Title("Tab")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Tab : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Tab(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.SELECTED_TAB_EVENT);

            Stage.Description = @"The `Tab` control serves as a container for multiple tab views. Each tab is defined through a tab view with metadata such as title, an icon and an optional badge (for example an entry count) with an optional badge color.";

            Stage.Control = new ControlTab(RandomId.Create())
            {
            }
                .Add(new ControlTabView()
                {
                    Title = _ => "Tab View 1",
                    Icon = _ => new IconTable()
                }
                    .Add(new ControlText() { Text = _ => "content of the tab view 1" }))
                .Add(new ControlTabView()
                {
                    Title = _ => "Tab View 2",
                    Icon = _ => new IconList(),
                    Badge = _ => "12"
                }
                    .Add(new ControlText() { Text = _ => "content of the tab view 2" }))
                .Add(new ControlTabView()
                {
                    Title = _ => "Tab View 3",
                    Icon = _ => new IconDiagramProject(),
                    Badge = _ => "3",
                    BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                }
                    .Add(new ControlText() { Text = _ => "content of the tab view 3" }));

            Stage.Code = @"
            new ControlTab(RandomId.Create())
            {
            }
                .Add(new ControlTabView()
                {
                    Title = _ => ""Tab View 1"",
                    Icon = _ => new IconTable()
                }
                    .Add(new ControlText() { Text = _ => ""content of the tab view 1"" }))
                .Add(new ControlTabView()
                {
                    Title = _ => ""Tab View 2"",
                    Icon = _ => new IconList(),
                    Badge = _ => ""12""
                }
                    .Add(new ControlText() { Text = _ => ""content of the tab view 2"" }))
                .Add(new ControlTabView()
                {
                    Title = _ => ""Tab View 3"",
                    Icon = _ => new IconDiagramProject(),
                    Badge = _ => ""3"",
                    BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                }
                    .Add(new ControlText() { Text = _ => ""content of the tab view 3"" }));";

            Stage.AddProperty
            (
                "Layout",
                "Determines the layout of the tab navigation.",
                "Layout = _ => TypeLayoutTab.Underline",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTab(RandomId.Create())
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = _ => "Tab View 1", Icon = _ => new IconTable() }.Add(new ControlText() { Text = _ => "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 2", Icon = _ => new IconList() }.Add(new ControlText() { Text = _ => "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 3", Icon = _ => new IconDiagramProject() }.Add(new ControlText() { Text = _ => "content of the tab view 3" })),
                new ControlText() { Text = _ => "Pill", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTab(RandomId.Create())
                {
                    Layout = _ => TypeLayoutTab.Pill
                }
                    .Add(new ControlTabView() { Title = _ => "Tab View 1", Icon = _ => new IconTable() }.Add(new ControlText() { Text = _ => "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 2", Icon = _ => new IconList() }.Add(new ControlText() { Text = _ => "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 3", Icon = _ => new IconDiagramProject() }.Add(new ControlText() { Text = _ => "content of the tab view 3" })),
                new ControlText() { Text = _ => "Underline", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTab(RandomId.Create())
                {
                    Layout = _ => TypeLayoutTab.Underline
                }
                    .Add(new ControlTabView() { Title = _ => "Tab View 1", Icon = _ => new IconTable() }.Add(new ControlText() { Text = _ => "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 2", Icon = _ => new IconList() }.Add(new ControlText() { Text = _ => "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 3", Icon = _ => new IconDiagramProject() }.Add(new ControlText() { Text = _ => "content of the tab view 3" }))
            );

            Stage.AddProperty
            (
                "Badge",
                "Shows a badge at the trailing edge of the tab header, typically a count. A system color is applied through BadgeColor; a user-defined color is emitted as an inline style.",
                "Badge = _ => \"12\", BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)",
                new ControlTab(RandomId.Create())
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = _ => "Neutral", Icon = _ => new IconTable(), Badge = _ => "12" }.Add(new ControlText() { Text = _ => "a badge without a color keeps the neutral default" }))
                    .Add(new ControlTabView() { Title = _ => "System color", Icon = _ => new IconList(), Badge = _ => "3", BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger) }.Add(new ControlText() { Text = _ => "a system color is applied as a css class" }))
                    .Add(new ControlTabView() { Title = _ => "User color", Icon = _ => new IconDiagramProject(), Badge = _ => "7", BadgeColor = _ => new PropertyColorBackgroundBadge("#7c3aed") }.Add(new ControlText() { Text = _ => "a user-defined color is applied as an inline style" }))
            );

            Stage.AddItem
            (
                typeof(ControlTabView),
                "ControlTabView",
                "A tab container composed of multiple tab views, each providing its own title, icon, and content area. Every tab is defined as a ControlTabView and can host arbitrary controls. This example demonstrates a three-tab layout using the default tab configuration, where each tab displays a simple text element as its content.",
                "new ControlTabView(...);",
                new ControlTab(RandomId.Create())
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = _ => "Tab View 1", Icon = _ => new IconTable() }.Add(new ControlText() { Text = _ => "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 2", Icon = _ => new IconList() }.Add(new ControlText() { Text = _ => "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 3", Icon = _ => new IconDiagramProject() }.Add(new ControlText() { Text = _ => "content of the tab view 3" }))
            );

            Stage.AddItem
            (
                typeof(ControlTab),
                "ControlTab with Toolbar",
                "This example shows a tab control with integrated toolbar items that are displayed on the right side of the navigation bar. The toolbar can contain buttons, dropdowns, and other toolbar items.",
                "new ControlTab(...).Add(new ControlToolbarItemButton() { ... });",
                new ControlTab(RandomId.Create())
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = _ => "Tab View 1", Icon = _ => new IconTable() }.Add(new ControlText() { Text = _ => "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = _ => "Tab View 2", Icon = _ => new IconList() }.Add(new ControlText() { Text = _ => "content of the tab view 2" }))
                    .Add(new ControlToolbarItemButton() { Icon = _ => new IconGear(), Tooltip = _ => "Settings" })
                    .Add(new ControlToolbarItemButton() { Icon = _ => new IconRotate(), Tooltip = _ => "Reload" })
            );
        }
    }
}

