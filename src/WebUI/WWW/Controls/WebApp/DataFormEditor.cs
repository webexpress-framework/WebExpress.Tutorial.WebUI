using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST-backed form editor control demo for the tutorial.
    /// </summary>
    [WebIcon<IconPenToSquare>]
    [Title("DataFormEditor")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataFormEditor : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the form editor control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataFormEditor(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.ADD_EVENT, Event.REMOVE_EVENT, Event.MOVE_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The REST‑backed FormEditor connects the visual form editor to the WebExpress.WebApp REST endpoints. The GET endpoint returns the complete form structure, including all tabs, all form fields and the full field catalog of the class in which the form is embedded. Every change made in the editor, such as adding, removing, renaming or reordering elements, is persisted through a debounced PUT request to the structure endpoint.";

            Stage.Control = new ControlDataFormEditor(RandomId.Create())
            {
                Preview = _ => true,
                Indent = _ => 18
            }
                .Service("data", svc => svc
                    .Uri(_ => sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery("id", "00000000-0000-0000-0000-000000000001"))));

            Stage.Code = @"
            new ControlDataFormEditor(""my-form-editor"")
            {
                Preview = _=> true,
                Indent = _=> 18
            }
                .Service(""data"", svc => svc
                    .Uri(_ => sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery(""id"", ""00000000-0000-0000-0000-000000000001""))));";

            Stage.AddProperty
            (
                "Readonly",
                "Suppresses every mutation control and skips REST writes. The editor still issues the initial GET to load the structure, but the user cannot add / delete / drag / rename anything.",
                "Readonly = true",
                new ControlDataFormEditor(RandomId.Create())
                {
                    Readonly = _ => true,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Service("data", svc => svc
                        .Uri(_ => sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery("id", "00000000-0000-0000-0000-000000000001"))))
            );

            Stage.AddProperty
            (
                "DraftService",
                "Declares the endpoint the unpublished structure is written to, which separates the two meanings of save: every change goes to the draft, nothing the forms in use see, and the data service is reached only through the publish button, whose `PUT` applies the structure and ends the draft in the same step. The header gains the publish button, the footer the draft state and the discard link. The draft endpoint derives from `RestApiFormEditorDraft<TIndexItem>`, which keeps a revision of the draft and refuses a save edited on top of another one: open this page in a second browser session, change the form in both, and the second save reports the conflict instead of overwriting the first. The sample edits a form of its own, so the samples above do not write over its draft.",
                @"
            new ControlDataFormEditor(""my-form-editor"")
            {
                DraftServiceFactory = _ => DataServiceDescriptor.DraftData(sitemapManager.GetUri<FormEditorDraft>(pageContext).Add(new UriQuery(""id"", formId)).ToString())
            }
                .Service(""data"", svc => svc
                    .Uri(_ => sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery(""id"", formId))));",
                new ControlDataFormEditor(RandomId.Create())
                {
                    DraftServiceFactory = _ => DataServiceDescriptor.DraftData(sitemapManager.GetUri<FormEditorDraft>(pageContext).Add(new UriQuery("id", FormEditor.DraftFormId)).ToString()),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Service("data", svc => svc
                        .Uri(_ => sitemapManager.GetUri<FormEditor>(pageContext).Add(new UriQuery("id", FormEditor.DraftFormId))))
            );
        }
    }
}
