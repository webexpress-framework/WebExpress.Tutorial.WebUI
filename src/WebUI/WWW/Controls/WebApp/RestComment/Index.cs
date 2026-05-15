using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Comment
{
    /// <summary>
    /// Demo page for the read surface of the threaded comment widget. Hosts
    /// a <see cref="ControlRestComment"/> bound to the
    /// <see cref="MonkeyIslandComment"/> REST endpoint. Authoring of new
    /// top-level comments lives on the sibling
    /// <see cref="RestComposer"/> page and is wired up via the
    /// <c>COMMENT_ADDED_EVENT</c>.
    /// </summary>
    [Title("RestComment")]
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
            var uri = sitemapManager.GetUri<MonkeyIslandComment>(pageContext);

            Stage.Description = @"`ControlComment` renders the **read surface** of a threaded comment widget. It emits a host element that the client-side `webexpress.webapp.CommentCtrl` turns into a toolbar (category filter and sort) and a list of comments - with likes, pinning, reactions, threaded replies and inline edit / delete for the current user's own comments.";

            Stage.Controls =
            [
                new ControlRestComment("tutorial-comment-guybrush")
                {
                    RestUri = _ => uri,
                    CurrentUser = _ => "guybrush"
                }
            ];

            Stage.Code = @"
            new ControlComment(""tutorial-comment-guybrush"")
            {
                RestUri = _ => sitemapManager.GetUri<MonkeyIslandComment>(pageContext),
                CurrentUser = _ => ""guybrush""
            };";
        }
    }
}
