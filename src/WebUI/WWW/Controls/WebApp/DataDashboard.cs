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
    /// Represents the dashboard control for the tutorial.
    /// </summary>
    [WebIcon<IconControlDashboard>]
    [Title("DataDashboard")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataDashboard : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataDashboard(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"The `Dashboard` control organizes widgets into columns. Each widget provides metadata (title, icon, color, column) and can optionally contain content controls. With `EditableColumn`/`MovableColumn`/`DeletableColumn` enabled, the columns can be renamed inline from their `…` menu, reordered via the ⠿ grip and deleted. `EditableColumn` also puts a divider between every two columns: dragging it moves width from one of the two to the other, so the columns always share the row and never run past its edge. The arrow keys move a focused divider, a double click splits the pair evenly, and the column menu evens out all widths. The board `…` menu (`AddableColumn`/`AddableWidget`) adds a new column or a dashboard item — the offered items are the ones the REST endpoint returns from `RetrieveAvailableWidgets`. Each item carries its own `…` menu with settings (`ConfigurableWidget` — always name and color plus type-specific fields) and delete. Every change is persisted to the REST endpoint.";

            // the dashboard is created separately and bound to the layout
            // resource by type; the ViewState declares the service and the resource
            // by type.
            var dashboard = new ControlDataDashboard(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true,
                AddableColumn = _ => true,
                AddableWidget = _ => true,
                ConfigurableWidget = _ => true
            }.Resource<LayoutResource>();

            Stage.Controls =
            [
                new ControlViewState<EmptyState>(RandomId.Create())
                    .Service<MonkeyIslandDashboard>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Resource<LayoutResource>(r => r.Service<MonkeyIslandDashboard>()),
                dashboard
            ];

            Stage.Code = @"
            var dashboard = new ControlDataDashboard(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true,
                AddableColumn = _ => true,
                AddableWidget = _ => true,
                ConfigurableWidget = _ => true
            }.Resource<LayoutResource>();

            new ControlViewState<EmptyState>(RandomId.Create())
                .Service<MonkeyIslandDashboard>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                .Resource<LayoutResource>(r => r.Service<MonkeyIslandDashboard>()),
            dashboard";
        }
    }
}
