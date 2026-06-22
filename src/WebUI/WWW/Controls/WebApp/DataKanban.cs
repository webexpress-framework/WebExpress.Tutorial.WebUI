using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
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
    [Title("DataKanban")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataKanban : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DataKanban(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `Kanban` control provides a column‑based layout for visual workflow management. Each column represents a process stage (e.g., To Do, In Progress, Done), while each card represents a movable work item. Cards can be rearranged or moved between columns, enabling intuitive drag‑and‑drop interaction and progress tracking. The control also supports swimlanes: horizontal lanes that group related work items across all columns. With `EditableColumn`/`MovableColumn`/`DeletableColumn` enabled, the column headers can be renamed inline (pencil / double-click), reordered via the ⠿ grip and deleted — the new column layout is persisted to the REST endpoint.";

            // the data service and its endpoint are authored in C# through the
            // fluent data surface; the endpoint resolves through the sitemap.
            Stage.Control = new ControlDataKanban(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true
            }
                .DataService<MonkeyIslandKanban>();

            Stage.Code = @"
            new ControlDataKanban(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true
            }
                .DataService<MonkeyIslandKanban>();";
        }
    }
}
