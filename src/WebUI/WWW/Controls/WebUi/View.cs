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
    /// Represents the view control for the tutorial.
    /// </summary>
    [Title("View")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class View : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the tree control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public View(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_VISIBILITY_EVENT);

            Stage.Description = @"The `View` control class serves as a central container for multiple views, each defined through a view element with metadata such as name, description, and an icon. The persistent header, search bar, main content area and footer remain visible across view changes; only the navigation between views differs by `Layout`.";

            Stage.Control = new ControlView(RandomId.Create())
            {
            }
                .Add(new ControlViewHeader()
                {
                }
                    .Add(new ControlSearch()))
                .Add(new ControlViewItem()
                {
                    Title = "View 1",
                    Icon = new IconTable(),
                    Description = "This is the first view"
                }
                    .Add(new ControlText() { Text = "content of the view 1" }))
                .Add(new ControlViewItem()
                {
                    Title = "View 2",
                    Icon = new IconList(),
                    Description = "This is the second view"
                }
                    .Add(new ControlText() { Text = "content of the view 2" }))
                .Add(new ControlViewItem()
                {
                    Title = "View 3",
                    Icon = new IconDiagramProject(),
                    Description = "This is the third view"
                }
                    .Add(new ControlText() { Text = "content of the view 3" }))
                .Add(new ControlViewFooter()
                {
                }
                    .Add(new ControlText() { Text = "Footer" }));

            Stage.Code = @"
            new ControlView(RandomId.Create())
            {
            }
                .Add(new ControlViewHeader()
                {
                }
                    .Add(new ControlSearch()))
                .Add(new ControlViewItem()
                {
                    Title = ""View 1"",
                    Icon = new IconTable(),
                    Description = ""This is the first view""
                }
                    .Add(new ControlText() { Text = ""content of the view 1"" }))
                .Add(new ControlViewItem()
                {
                    Title = ""View 2"",
                    Icon = new IconList(),
                    Description = ""This is the second view""
                }
                    .Add(new ControlText() { Text = ""content of the view 2"" }))
                .Add(new ControlViewItem()
                {
                    Title = ""View 3"",
                    Icon = new IconDiagramProject(),
                    Description = ""This is the third view""
                }
                    .Add(new ControlText() { Text = ""content of the view 3"" }))
                .Add(new ControlViewFooter()
                {
                }
                    .Add(new ControlText() { Text = ""Footer"" }))";

            Stage.AddProperty
            (
                "Layout",
                "Controls how view switching is rendered. The Default layout shows the title and description of the active view together with a dropdown for switching. The ToggleGroup layout omits title and description and exposes all views directly through a compact toggle bar.",
                "Layout = TypeLayoutView.ToggleGroup",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlView(RandomId.Create())
                {
                    Layout = TypeLayoutView.Default
                }
                    .Add(new ControlViewHeader().Add(new ControlSearch()))
                    .Add(new ControlViewItem() { Title = "View 1", Icon = new IconTable(), Description = "This is the first view" }.Add(new ControlText() { Text = "content of the view 1" }))
                    .Add(new ControlViewItem() { Title = "View 2", Icon = new IconList(), Description = "This is the second view" }.Add(new ControlText() { Text = "content of the view 2" }))
                    .Add(new ControlViewItem() { Title = "View 3", Icon = new IconDiagramProject(), Description = "This is the third view" }.Add(new ControlText() { Text = "content of the view 3" }))
                    .Add(new ControlViewFooter().Add(new ControlText() { Text = "Footer" })),
                new ControlText() { Text = "ToggleGroup", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlView(RandomId.Create())
                {
                    Layout = TypeLayoutView.ToggleGroup
                }
                    .Add(new ControlViewHeader().Add(new ControlSearch()))
                    .Add(new ControlViewItem() { Title = "View 1", Icon = new IconTable() }.Add(new ControlText() { Text = "content of the view 1" }))
                    .Add(new ControlViewItem() { Title = "View 2", Icon = new IconList() }.Add(new ControlText() { Text = "content of the view 2" }))
                    .Add(new ControlViewItem() { Title = "View 3", Icon = new IconDiagramProject() }.Add(new ControlText() { Text = "content of the view 3" }))
                    .Add(new ControlViewFooter().Add(new ControlText() { Text = "Footer" }))
            );

            Stage.AddItem
            (
                typeof(ControlViewItem),
                "ControlViewItem",
                "A single view inside a `ControlView`. Each item provides its own title, description, icon and content area and may host arbitrary controls.",
                "new ControlViewItem(...);",
                new ControlView(RandomId.Create())
                {
                    Layout = TypeLayoutView.Default
                }
                    .Add(new ControlViewItem() { Title = "View 1", Icon = new IconTable(), Description = "This is the first view" }.Add(new ControlText() { Text = "content of the view 1" }))
                    .Add(new ControlViewItem() { Title = "View 2", Icon = new IconList(), Description = "This is the second view" }.Add(new ControlText() { Text = "content of the view 2" }))
                    .Add(new ControlViewItem() { Title = "View 3", Icon = new IconDiagramProject(), Description = "This is the third view" }.Add(new ControlText() { Text = "content of the view 3" }))
            );
        }
    }
}
