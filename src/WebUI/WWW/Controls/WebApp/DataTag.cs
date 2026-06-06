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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST tag demo page for the tutorial. Hosts a
    /// <see cref="ControlDataTag"/> connected to the
    /// <see cref="MonkeyIslandTag"/> REST endpoint, which serves the
    /// load / suggest / add / remove operations from a single URL. The quest
    /// log starts tagged with "pirate" and "grog"; typing offers
    /// autocomplete suggestions from the Monkey Island vocabulary.
    /// </summary>
    [Title("DataTag")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataTag : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataTag(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            var uri = sitemapManager.GetUri<MonkeyIslandTag>(pageContext);

            Stage.Description = @"`ControlDataTag` renders a read-only row of tag (label) chips followed by a ""+"" button. Clicking ""+"" opens a modal in which tags are added (with autocomplete) and deleted; on close the chips reflect the edits. The control only emits the host element; the read-only surface, the ""+"" button, the modal and the editable surface inside it are built by the client-side `webexpress.webapp.TagCtrl` (read-only) and `webexpress.webapp.TagEditorCtrl` (editable), which extend the WebUI `webexpress.webui.TagCtrl` and `InputTagCtrl`. The same endpoint loads the attached tags, adds new ones, deletes removed ones and — via the `q` query parameter — serves the autocomplete suggestions.";

            Stage.Controls =
            [
                new ControlDataTag("tutorial-tag-quest")
                {
                    RestUri = _ => uri,
                    Placeholder = _ => "add tag…"
                }
            ];

            Stage.Code = @"
            new ControlDataTag(""tutorial-tag-quest"")
            {
                RestUri = _ => sitemapManager.GetUri<MonkeyIslandTag>(pageContext),
                Placeholder = _ => ""add tag…""
            };";
        }
    }
}
