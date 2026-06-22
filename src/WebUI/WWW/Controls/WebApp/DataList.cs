using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the list control for the tutorial (REST-backed flat list).
    /// </summary>
    [Title("DataList")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataList : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataList(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register demo events that the list control can emit
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `DataList` control is a user interface component that retrieves data from a REST API and exposes interactions in a flat list representation. The control automatically fetches data from the API and renders the items as a list. Users can add, modify, delete, and reorder entries, with every action synchronized with the API. In addition, the control provides filtering and pagination for improved accessibility.";

            Stage.Controls =
            [
                new ControlDataList("myList")
                    .State(s => s
                        .Page(0)
                        .PageSize(25))
                    .DataService<MonkeyIslandGamesList>(),
                new ControlModalExample("modal")
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlDataList(""myList"")
                .State(s => s
                    .Page(0)
                    .PageSize(25))
                .DataService<MonkeyIslandGamesList>(),
            new ControlModalExample(""modal"")";
        }
    }
}
