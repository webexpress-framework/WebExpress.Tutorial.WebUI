using System.Net.Http;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Comment
{
    /// <summary>
    /// Demo page for the read surface of the threaded comment widget. Hosts
    /// a <see cref="ControlDataComment"/> bound to the
    /// <see cref="MonkeyIslandComment"/> REST endpoint. Authoring of new
    /// top-level comments lives on the sibling
    /// <see cref="DataComposer"/> page and is wired up via the
    /// <c>COMMENT_ADDED_EVENT</c>.
    /// </summary>
    [Title("DataComment")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Index : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public Index(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlComment` renders the **read surface** of a threaded comment widget. It emits a host element that the client-side `webexpress.webapp.CommentCtrl` turns into a toolbar (category filter and sort) and a list of comments - with likes, pinning, reactions, threaded replies and inline edit / delete for the current user's own comments.";

            // the data service and its endpoint are authored in C# through the
            // fluent data surface; the endpoint resolves through the sitemap.
            Stage.Controls =
            [
                new ControlDataComment("tutorial-comment-guybrush")
                {
                    CurrentUser = _ => "guybrush"
                }
                    .Service("data", svc => svc
                        .Endpoint<MonkeyIslandComment>()
                        .Method(HttpMethod.Get)
                        .UpdateMethod(HttpMethod.Put))
            ];

            Stage.DarkControls = [];

            Stage.Code = @"
            new ControlDataComment(""tutorial-comment-guybrush"")
            {
                CurrentUser = _ => ""guybrush""
            }
                .Service(""data"", svc => svc
                    .Endpoint<MonkeyIslandComment>()
                    .Method(HttpMethod.Get)
                    .UpdateMethod(HttpMethod.Put));";
        }
    }
}
