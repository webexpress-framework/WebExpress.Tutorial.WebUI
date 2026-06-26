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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed Scrum team workload board, showing the
    /// crew of the active sprint and the story points assigned to each of them.
    /// </summary>
    [Title("DataScrumTeam")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataScrumTeam : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataScrumTeam(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.DATA_REQUESTED_EVENT, Event.DATA_ARRIVED_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The `ScrumTeam` control shows the people working in the current sprint as a row of avatars badged with their story points. Only the first few people are shown inline; the rest collapse into a `+N` chip that – like the trailing total chip – opens a modal listing every person together with their story points as a table.";

            Stage.Controls =
            [
                new ControlDataScrumTeam("monkeyIslandTeam")
                {
                    MaxVisible = _ => 4
                }
                    .DataService<MonkeyIslandScrumTeam>()
            ];

            Stage.Code = @"
            new ControlDataScrumTeam(""monkeyIslandTeam"")
            {
                MaxVisible = _ => 4
            }
                .DataService<MonkeyIslandScrumTeam>()";
        }
    }
}
