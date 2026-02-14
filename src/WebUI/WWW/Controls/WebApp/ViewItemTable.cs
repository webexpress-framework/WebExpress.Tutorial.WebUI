using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the table view for the tutorial.    
    /// </summary>    
    [Title("ViewItemTable")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class ViewItemTable : PageControl
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
        public ViewItemTable(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"A `ControlViewItemTable` control is a user interface component that retrieves data from a REST API and operates based on the CRUD principle, which encompasses creating, reading, updating, and processing data. The control automatically fetches data from the API and displays it in a tabular format. Users can add, modify, or delete entries in the table, with each action being synchronized directly with the API. Additionally, the control provides sorting and filtering functionalities to enhance data presentation and accessibility.";

            Stage.Controls =
            [
                new ControlView("myView")
                {

                }
                    .Add(new ControlViewItemTable()
                    {
                        Title = "Characters",
                        Description = "A table that displays characters from Monkey Island.",
                        DataUri = sitemapManager.GetUri<Api._1_.MonkeyIslandCharacterTable>(pageContext.ApplicationContext),
                        WqlUri = sitemapManager.GetUri<Api._1_.MonkeyIslandBoatWql>(pageContext.ApplicationContext),
                        Infinite = true,
                        Icon = new IconSkull()
                    })
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlView(""myTable"")
            {
            }
                .Add(new ControlViewItemTable()
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandCharacterTable>(pageContext.ApplicationContext)
                })";
        }
    }
}
