using System.Net.Http;
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
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a simple kanban test board for demonstration purposes.
    /// </summary>
    [WebIcon<IconControlKanban>]
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

            Stage.Description = @"A `Kanban` control provides a column‑based layout for visual workflow management. Each column represents a process stage (e.g., To Do, In Progress, Done), while each card represents a movable work item. Cards can be rearranged or moved between columns, enabling intuitive drag‑and‑drop interaction and progress tracking. The control also supports swimlanes: horizontal lanes that group related work items across all columns. With `EditableColumn`/`MovableColumn`/`DeletableColumn` enabled, each column carries a `…` menu to rename, resize, recolor and delete it, and columns can be reordered via the ⠿ grip. The board `…` menu (`ConfigurableBoard`/`AddableColumn`/`AddableSwimlane`) opens the settings dialog with the WQL filter and adds a new column or swimlane. With `EditableSwimlane`/`DeletableSwimlane`/`ConfigurableSwimlane` enabled, each swimlane carries a `…` menu to rename, filter (WQL settings) and delete it. Each column can carry a badge (e.g. the card count). Every change is persisted to the REST endpoint.";

            // the board is created separately and bound to the board resource by
            // type; the ViewState declares the service and the resource by type.
            var board = new ControlDataKanban(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true,
                AddableColumn = _ => true,
                AddableSwimlane = _ => true,
                EditableSwimlane = _ => true,
                DeletableSwimlane = _ => true,
                MovableSwimlane = _ => true,
                ConfigurableBoard = _ => true,
                ConfigurableSwimlane = _ => true
            }.Resource<BoardResource>();

            Stage.Controls =
            [
                new ControlViewState<EmptyState>(RandomId.Create())
                    .Service<MonkeyIslandKanban>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Resource<BoardResource>(r => r.Service<MonkeyIslandKanban>()),
                board
            ];

            Stage.Code = @"
            var board = new ControlDataKanban(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true,
                AddableColumn = _ => true,
                AddableSwimlane = _ => true,
                EditableSwimlane = _ => true,
                DeletableSwimlane = _ => true,
                MovableSwimlane = _ => true,
                ConfigurableBoard = _ => true,
                ConfigurableSwimlane = _ => true
            }.Resource<BoardResource>();

            new ControlViewState<EmptyState>(RandomId.Create())
                .Service<MonkeyIslandKanban>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                .Resource<BoardResource>(r => r.Service<MonkeyIslandKanban>()),
            board";
        }
    }
}
