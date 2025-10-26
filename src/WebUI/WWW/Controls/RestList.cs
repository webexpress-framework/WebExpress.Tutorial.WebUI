using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the list control for the tutorial (REST-backed flat list).
    /// </summary>
    [Title("RestList")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestList : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestList(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register demo events that the list control can emit
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `RestList` control is a user interface component that retrieves data from a REST API and exposes CRUD-oriented interactions in a flat list representation. The control automatically fetches data from the API and renders the items as a list. Users can add, modify, delete, and reorder entries, with every action synchronized with the API. In addition, the control provides filtering and pagination for improved accessibility.";

            Stage.Controls =
            [
                new ControlRestList("myList")
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandGames>(pageContext.ApplicationContext)
                }
                    .Add(new ControlRestFormGame("myListForm")
                    {
                        Uri = sitemapManager.GetUri<MonkeyIslandGames>(pageContext.ApplicationContext)
                    })
            ];

            Stage.DarkControls =
            [
                new ControlText()
                //new ControlRestList("myListDark")
                //{
                //    RestUri = sitemapManager.GetUri<MonkeyIslandCharacters>(pageContext.ApplicationContext)
                //}
                //    .Add(new ControlRestFormCharacter("myListDarkForm")
                //    {
                //        Uri = sitemapManager.GetUri<MonkeyIslandCharacters>(pageContext.ApplicationContext)
                //    })
            ];

            Stage.Code = @"
            new ControlRestList(""myList"")
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandGames>(pageContext.ApplicationContext)
            }
                .Add(new ControlRestFormGame(""myListForm"")
                {
                    Uri = sitemapManager.GetUri<MonkeyIslandGames>(pageContext.ApplicationContext)
                })";
        }
    }
}