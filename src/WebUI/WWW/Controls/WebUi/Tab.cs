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

            Stage.Description = @"The `Tab` control serves as a container for multiple tab views. Each tab is defined through a tab view with metadata such as title and an icon.";

            Stage.Control = new ControlTab(RandomId.Create())
            {
            }
                .Add(new ControlTabView()
                {
                    Title = "Tab View 1",
                    Icon = new IconTable()
                }
                    .Add(new ControlText() { Text = "content of the tab view 1" }))
                .Add(new ControlTabView()
                {
                    Title = "Tab View 2",
                    Icon = new IconList()
                }
                    .Add(new ControlText() { Text = "content of the tab view 2" }))
                .Add(new ControlTabView()
                {
                    Title = "Tab View 3",
                    Icon = new IconDiagramProject(),
                }
                    .Add(new ControlText() { Text = "content of the tab view 3" }));

            Stage.Code = @"
            new ControlTab(RandomId.Create())
            {
            }
                .Add(new ControlTabView()
                {
                    Title = ""Tab View 1"",
                    Icon = new IconTable()
                }
                    .Add(new ControlText() { Text = ""content of the tab view 1"" }))
                .Add(new ControlTabView()
                {
                    Title = ""Tab View 2"",
                    Icon = new IconList()
                }
                    .Add(new ControlText() { Text = ""content of the tab view 2"" }))
                .Add(new ControlTabView()
                {
                    Title = ""Tab View 3"",
                    Icon = new IconDiagramProject(),
                }
                    .Add(new ControlText() { Text = ""content of the tab view 3"" }));";

            Stage.AddProperty
            (
                "Layout",
                "Determines the layout of the tab navigation.",
                "Layout = TypeLayoutTab.Underline",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTab(RandomId.Create())
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = "Tab View 1", Icon = new IconTable() }.Add(new ControlText() { Text = "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = "Tab View 2", Icon = new IconList() }.Add(new ControlText() { Text = "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = "Tab View 3", Icon = new IconDiagramProject() }.Add(new ControlText() { Text = "content of the tab view 3" })),
                new ControlText() { Text = "Pill", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTab(RandomId.Create())
                {
                    Layout = TypeLayoutTab.Pill
                }
                    .Add(new ControlTabView() { Title = "Tab View 1", Icon = new IconTable() }.Add(new ControlText() { Text = "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = "Tab View 2", Icon = new IconList() }.Add(new ControlText() { Text = "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = "Tab View 3", Icon = new IconDiagramProject() }.Add(new ControlText() { Text = "content of the tab view 3" })),
                new ControlText() { Text = "Underline", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTab(RandomId.Create())
                {
                    Layout = TypeLayoutTab.Underline
                }
                    .Add(new ControlTabView() { Title = "Tab View 1", Icon = new IconTable() }.Add(new ControlText() { Text = "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = "Tab View 2", Icon = new IconList() }.Add(new ControlText() { Text = "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = "Tab View 3", Icon = new IconDiagramProject() }.Add(new ControlText() { Text = "content of the tab view 3" }))
            );

            Stage.AddItem
            (
                typeof(ControlTabView),
                "ControlTabView",
                "A tab container composed of multiple tab views, each providing its own title, icon, and content area. Every tab is defined as a ControlTabView and can host arbitrary controls. This example demonstrates a three-tab layout using the default tab configuration, where each tab displays a simple text element as its content.",
                "new ControlTabView(...);",
                new ControlTab(RandomId.Create())
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = "Tab View 1", Icon = new IconTable() }.Add(new ControlText() { Text = "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = "Tab View 2", Icon = new IconList() }.Add(new ControlText() { Text = "content of the tab view 2" }))
                    .Add(new ControlTabView() { Title = "Tab View 3", Icon = new IconDiagramProject() }.Add(new ControlText() { Text = "content of the tab view 3" }))
            );

            Stage.AddItem
            (
                typeof(ControlTab),
                "ControlTab with Toolbar",
                "This example shows a tab control with integrated toolbar items that are displayed on the right side of the navigation bar. The toolbar can contain buttons, dropdowns, and other toolbar items.",
                "new ControlTab(...).Add(new ControlToolbarItemButton() { ... });",
                new ControlTab(RandomId.Create())
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add(new ControlTabView() { Title = "Tab View 1", Icon = new IconTable() }.Add(new ControlText() { Text = "content of the tab view 1" }))
                    .Add(new ControlTabView() { Title = "Tab View 2", Icon = new IconList() }.Add(new ControlText() { Text = "content of the tab view 2" }))
                    .Add(new ControlToolbarItemButton() { Icon = new IconGear(), Tooltip = "Settings" })
                    .Add(new ControlToolbarItemButton() { Icon = new IconRotate(), Tooltip = "Reload" })
            );
        }
    }
}

