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
    /// Represents the dashboard control for the tutorial.
    /// </summary>
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

            Stage.Description = @"The `Dashboard` control organizes widgets into columns. Each widget provides metadata (title, icon, color, column) and can optionally contain content controls. With `EditableColumn`/`MovableColumn`/`DeletableColumn` enabled, the column headers can be renamed inline (pencil / double-click), reordered via the ⠿ grip and deleted — the new column layout is persisted to the REST endpoint.";

            // the data service and its endpoint are authored in C# through the
            // fluent data surface; the endpoint resolves through the sitemap.
            var dashboard = new ControlDataDashboard(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true
            }
                .DataService<MonkeyIslandDashboard>();

            Stage.Control = dashboard;

            Stage.Code = @"
            new ControlDataDashboard(RandomId.Create())
            {
                EditableColumn = _ => true,
                MovableColumn = _ => true,
                DeletableColumn = _ => true
            }
                .DataService<MonkeyIslandDashboard>();";
        }
    }
}
