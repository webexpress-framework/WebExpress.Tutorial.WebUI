using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a simple kanban test board for demonstration purposes.
    /// </summary>
    [Title("RestKanban")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestKanban : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestKanban(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<WebExpress.Tutorial.WebUI.WWW.Api._1_.MonkeyIslandKanban>(pageContext);
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `Kanban` control provides a column‑based layout for visual workflow management. Each column represents a process stage (e.g., To Do, In Progress, Done), while each card represents a movable work item. Cards can be rearranged or moved between columns, enabling intuitive drag‑and‑drop interaction and progress tracking. The control also supports swimlanes: horizontal lanes that group related work items across all columns. Swimlanes allow parallel workflows (e.g., Priority, Teams, Categories) to be displayed within the same board, providing an additional structural dimension for organizing and filtering tasks.";

            Stage.Control = new ControlRestKanban(RandomId.Create())
            {
                RestUri = uri
            };

            Stage.Code = @"
            new ControlRestKanban(RandomId.Create())
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandKanban>(pageContext)
            };";
        }
    }
}