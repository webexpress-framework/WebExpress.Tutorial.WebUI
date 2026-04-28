using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST-backed form editor control demo for the tutorial.
    /// </summary>
    [Title("RestFormEditor")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestFormEditor : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the form editor control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestFormEditor(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.ADD_EVENT, Event.REMOVE_EVENT, Event.MOVE_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The REST‑backed FormEditor connects the visual form editor to the WebExpress.WebApp REST endpoints. The GET endpoint returns the complete form structure, including all tabs, all form fields and the full field catalog of the class in which the form is embedded. Every change made in the editor, such as adding, removing, renaming or reordering elements, is persisted through a debounced PUT request to the structure endpoint.";

            Stage.Control = new ControlRestFormEditor(RandomId.Create())
            {
                RestUri = sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery("id", "00000000-0000-0000-0000-000000000001")),
                Preview = true,
                Indent = 18
            };

            Stage.Code = @"
            new ControlFormEditor(""my-form-editor"")
            {
                RestUri = sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery(""id"", ""00000000-0000-0000-0000-000000000001"")),
                Preview = true,
                Indent = 18
            };";

            Stage.AddProperty
            (
                "Readonly",
                "Suppresses every mutation control and skips REST writes. The editor still issues the initial GET to load the structure, but the user cannot add / delete / drag / rename anything.",
                "Readonly = true",
                new ControlRestFormEditor(RandomId.Create())
                {
                    RestUri = sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery("id", "00000000-0000-0000-0000-000000000001")),
                    Readonly = true,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
            );
        }
    }
}
