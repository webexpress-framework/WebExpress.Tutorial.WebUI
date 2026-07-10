using WebExpress.Tutorial.WebUI.Model;
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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Table.Templates
{
    /// <summary>
    /// Represents the markdown template of the REST table control for the tutorial.
    /// </summary>
    [Title("Markdown-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Markdown : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">
        /// The context of the page where the table control is used.
        /// </param>
        /// <param name="sitemapManager">
        /// The sitemap manager for managing site navigation.
        /// </param>
        public Markdown(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Markdown` template renders the cell value of a REST table column as a markdown subset (headings, emphasis, code, links and lists). The raw value is escaped on the client before the markup is rewritten, so markdown data cannot inject HTML. The template is read-only.";

            Stage.Controls =
            [
                new ControlDataTable("myTable")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableMarkdown>(),
            ];

            Stage.DarkControls =
            [
                new ControlDataTable("myTableDark")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableMarkdown>()
            ];

            Stage.Code = @"
                new ControlDataTable(""myTable"")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableMarkdown>()";
        }
    }
}
