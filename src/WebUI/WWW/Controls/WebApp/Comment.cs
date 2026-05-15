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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the threaded comment demo page for the tutorial. Each
    /// card hosts a <see cref="ControlComment"/> connected to the
    /// <see cref="MonkeyIslandComment"/> REST endpoint seeded with a
    /// Monkey Island themed thread between Guybrush Threepwood, Elaine
    /// Marley, Stan and the Voodoo Lady. Opening the page in two browsers
    /// (with different <c>data-current-user</c> values) lets you exercise
    /// the full lifecycle: post, edit, delete, like, pin, react and reply.
    /// </summary>
    [Title("Comment")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Comment : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public Comment(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<MonkeyIslandComment>(pageContext);

            Stage.Description = @"`ControlComment` renders a threaded comment surface backed by a REST endpoint. The control only emits the host element; the actual toolbar (category filter and sort), comment list (with likes, pinning, reactions and inline edit) and composer (powered by `webexpress.webui.EditorCtrl`) are built by the client-side `webexpress.webapp.CommentCtrl`. The endpoint exposes the standard sub-paths:

- `GET    {uri}` — list comments
- `POST   {uri}` — create a comment
- `PUT    {uri}/{id}` — update a comment
- `DELETE {uri}/{id}` — delete a comment
- `POST   {uri}/{id}/likes` — toggle like
- `POST   {uri}/{id}/pin` — toggle pinned
- `POST   {uri}/{id}/reactions` — toggle a reaction emoji
- `POST   {uri}/{id}/replies` — append a reply

The tutorial wires the control to `MonkeyIslandComment`, a Monkey Island themed in-memory implementation. The seed thread features Guybrush Threepwood asking for help against the Sword Master, Elaine Marley posting a hint, Stan trying to sell a ship and the Voodoo Lady revealing the secret of root beer.

Manual scenarios:

- **Compose** — pick a category, type into the composer and submit; the new comment appears immediately.
- **React & like** — click the heart or `+` button on any comment; counts and the highlight for *your* reactions update in place.
- **Pin** — pin a comment; it floats to the top of the list regardless of sort order.
- **Reply** — open a thread, post a reply and watch it nest under its parent.
- **Edit & delete** — only your own comments expose edit / delete actions; the inline editor uses the same WYSIWYG component as the composer.
- **Two users** — open the page in two browsers, change `data-current-user` to e.g. `elaine` in one of them and observe how authoring rights, like state and reaction highlights diverge.";

            Stage.Controls =
            [
                new ControlPanelCard
                (
                    null,
                    new ControlText
                    {
                        Text = _ => "Comments — Guybrush's quest log",
                        Format = _ => TypeFormatText.H5,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    },
                    new ControlComment("tutorial-comment-guybrush")
                    {
                        RestUri = _ => uri,
                        CurrentUser = _ => "guybrush"
                    }
                )
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
