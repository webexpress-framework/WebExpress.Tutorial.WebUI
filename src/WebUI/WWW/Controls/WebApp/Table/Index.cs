using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Table
{
    /// <summary>    
    /// Represents the table control for the tutorial.    
    /// </summary>    
    [Title("RestTable")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Index : PageControl
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
        public Index(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.TABLE_SORT_EVENT, Event.COLUMN_REORDER_EVENT);

            Stage.Description = @"A `RestTable` control is a user interface component that retrieves data from a REST API and operates based on the CRUD principle, which encompasses creating, reading, updating, and processing data. The control automatically fetches data from the API and displays it in a tabular format. Users can add, modify, or delete entries in the table, with each action being synchronized directly with the API. Additionally, the control provides sorting and filtering functionalities to enhance data presentation and accessibility.";

            Stage.Controls =
            [
                new ControlRestTable("myTable")
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandCharacterTable>(pageContext.ApplicationContext),
                    PageSize = 5
                },
                new ControlModalExample("modal")
                {
                }
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlRestTable(""myTable"")
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandCharacterTable>(pageContext.ApplicationContext),
                PageSize = 5
            }";
        }
    }
}
