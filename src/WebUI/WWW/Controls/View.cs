using System;
using WebExpress.Tutorial.WebUI.Model;
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

            Stage.Description = @"The `View` control class serves as a central container for multiple views, each defined through a view element with metadata such as name, description, and an icon. Views can optionally declare themselves as detail views. When such a view becomes active, a split layout is automatically created, placing the master view in the left pane and a `Frame` control in the right pane. Without an active detail view, the master view occupies the full available space.";

            Stage.Control = new ControlView(Guid.NewGuid().ToString())
            {
            }
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
                    Description = "This is the second view",
                    DetailFrame = true
                }
                    .Add(new ControlText() { Text = "content of the view 2" }))
                .Add(new ControlViewItem()
                {
                    Title = "View 3",
                    Icon = new IconDiagramProject(),
                    Description = "This is the third view"
                }
                    .Add(new ControlText() { Text = "content of the view 3" }));

            Stage.Code = @"
            new ControlView()";
        }
    }
}
