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
    /// Represents the status template of the REST table control for the tutorial.
    /// </summary>
    [Title("Status-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Status : PageControl
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
        public Status(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Status` template condenses a cell value into a colored status dot within a REST table column, the table analog of the status task dot (red error, green done, yellow warning, blue running, gray pending). The endpoint declares the template on the column, including whether the translated status name is shown beside the dot. The template is read-only.";

            Stage.Controls =
            [
                new ControlDataTable("myTable")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableStatus>(),
            ];

            Stage.DarkControls =
            [
                new ControlDataTable("myTableDark")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableStatus>()
            ];

            Stage.Code = @"
                new ControlDataTable(""myTable"")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableStatus>()";
        }
    }
}
