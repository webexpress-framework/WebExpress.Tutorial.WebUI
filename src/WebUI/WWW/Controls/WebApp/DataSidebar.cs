using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the tutorial page that demonstrates a REST-backed sidebar with
    /// a hierarchical navigation tree and badges.
    /// </summary>
    [Title("DataSidebar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataSidebar : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the sidebar control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataSidebar(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register relevant ui events
            Stage.AddEvent(Event.DATA_ARRIVED_EVENT);

            // describe the control in the tutorial
            Stage.Description = @"A REST-backed sidebar that loads its navigation tree from an API. The endpoint returns headers, links and dividers, decorates entries with badges (for example an unread or item count) and nests links into collapsible groups. The sidebar renders placeholder rows while loading, collapses into a reduced layout below its breakpoint, and re-queries itself when the server announces a data change. The example endpoint returns a Monkey Island themed tree whose badge counts reflect the live view model.";

            // default (light) sample
            Stage.Controls =
            [
                new ControlDataSidebar("navSidebar")
                {
                    Breakpoint = _ => 200
                }
                    .DataService<MonkeyIslandSidebar>()
            ];

            // dark sample
            Stage.DarkControls =
            [
                new ControlDataSidebar("darkNavSidebar")
                {
                    Breakpoint = _ => 200
                }
                    .DataService<MonkeyIslandSidebar>()
            ];

            // code sample
            Stage.Code = @"
            new ControlDataSidebar(""navSidebar"")
            {
                Breakpoint = _ => 200
            }
                .DataService<MonkeyIslandSidebar>()";

            // properties: DataService
            Stage.AddProperty
            (
                "DataService",
                "The data service whose endpoint delivers the navigation tree. The endpoint derives from RestApiSidebar and returns items, headers, dividers, badges and nested children.",
                ".DataService<MonkeyIslandSidebar>()",
                new ControlDataSidebar("p_service")
                {
                    Breakpoint = _ => 200
                }
                    .DataService<MonkeyIslandSidebar>()
            );

            // properties: Breakpoint
            Stage.AddProperty
            (
                "Breakpoint",
                "The minimum viewport width, in pixels, at which the sidebar stays in its full layout. Below the breakpoint it collapses into the reduced, space-saving form.",
                "Breakpoint = _ => 200",
                new ControlDataSidebar("p_breakpoint")
                {
                    Breakpoint = _ => 200
                }
                    .DataService<MonkeyIslandSidebar>()
            );
        }
    }
}
