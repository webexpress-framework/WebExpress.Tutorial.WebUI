using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the feed control for the tutorial: the Monkey Island games read one page at a
    /// time, newest first, with a button that appends the next.
    /// </summary>
    [WebIcon<IconControlTimeline>]
    [Title("DataFeed")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataFeed : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataFeed(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"A `DataFeed` control shows entries from a REST API stacked one under the other, newest first, with a button under them that fetches the next page and appends it. It is the counterpart of the `DataList` for content that is read rather than scanned: a list pages, replacing its rows so the reader walks pages, which suits a working set somebody looks something up in; a feed grows, keeping what has been read on the page and adding under it, which suits a stream somebody reads down — posts, announcements, activity. Each entry carries a heading, a quiet line of context under it, the text itself (rich text is rendered as such) and optionally an icon, a picture, tags and the address it leads to. The button hides itself once the last page has arrived: exactly, when the endpoint counts its result, and otherwise after the first page that comes back shorter than the size that was asked for.";

            Stage.Controls =
            [
                new ControlDataFeed("monkeyIslandFeed")
                {
                    PageSize = _ => 3,
                    MoreLabel = _ => "Show more games",
                    EmptyText = _ => "No games yet.",
                    OpenLabel = _ => "Read on"
                }
                    .DataService<MonkeyIslandGamesFeed>()
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlDataFeed(""monkeyIslandFeed"")
            {
                PageSize = _ => 3,
                MoreLabel = _ => ""Show more games"",
                EmptyText = _ => ""No games yet."",
                OpenLabel = _ => ""Read on""
            }
                .DataService<MonkeyIslandGamesFeed>()";
        }
    }
}
