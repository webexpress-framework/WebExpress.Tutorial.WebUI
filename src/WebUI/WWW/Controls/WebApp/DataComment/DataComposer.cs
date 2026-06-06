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
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Comment
{
    /// <summary>
    /// Demo page for the minimalist new-comment composer. Hosts a
    /// <see cref="ControlDataCommentComposer"/> bound to the
    /// <see cref="MonkeyIslandComment"/> REST endpoint. The composer is
    /// rendered next to a <see cref="ControlDataComment"/> read surface so the
    /// dispatched <c>COMMENT_ADDED_EVENT</c> can be observed in place - the
    /// list above updates immediately on submit without an extra
    /// roundtrip.
    /// </summary>
    [Title("DataCommentComposer")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataComposer : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataComposer(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<MonkeyIslandComment>(pageContext);

            Stage.Description = @"`ControlCommentComposer` renders the **authoring surface** of the threaded comment widget. It emits a host element that the client-side `webexpress.webapp.CommentComposerCtrl` turns into a *minimalist single-line trigger* (looks like an empty input). On focus or click the trigger collapses out of the way and the full form takes over - category select, WYSIWYG editor (powered by `webexpress.webui.EditorCtrl`), labels input and send / cancel buttons.";

            Stage.Controls =
            [
                new ControlDataCommentComposer("tutorial-comment-composer-guybrush")
                {
                    RestUri = _ => uri,
                    CurrentUser = _ => "guybrush",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None)
                }
            ];

            Stage.Code = @"
            new ControlCommentComposer(""tutorial-comment-composer-guybrush"")
            {
                RestUri = _ => sitemapManager.GetUri<MonkeyIslandComment>(pageContext),
                CurrentUser = _ => ""guybrush""
            };";
        }
    }
}
