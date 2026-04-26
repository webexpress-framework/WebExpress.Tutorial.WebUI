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

            Stage.Description = @"The REST-backed `FormEditor` wires the visual form editor to the WebExpress.WebApp REST endpoints (`/api/1/FormEditor`, `/api/1/FormFieldCatalog`). Every mutation in the editor (add / remove / rename / drag-and-drop) is persisted via a debounced PUT against the structure endpoint; the field catalog is loaded from the server on startup. The same control runs in offline-mock mode when no `RestUrl` is configured (see the [FormEditor](../WebUi/FormEditor) page for offline examples).";

            Stage.Control = new ControlRestFormEditor(RandomId.Create())
            {
                FormId = "00000000-0000-0000-0000-000000000001",
                RestUri = sitemapManager.GetUri<FormEditor>(pageContext),
                FieldCatalogUri = sitemapManager.GetUri<FormFieldCatalog>(pageContext),
                Preview = true,
                Indent = 18
            };

            Stage.Code = @"
            new ControlFormEditor(""my-form-editor"")
            {
                FormId = ""00000000-0000-0000-0000-000000000001"",
                RestUri = sitemapManager.GetUri<FormEditor>(pageContext),
                FieldCatalogUri = sitemapManager.GetUri<FormFieldCatalog>(pageContext),
                Preview = true,
                Indent = 18
            };";

            Stage.AddProperty
            (
                "FormId",
                "Identifier of the form to load on startup. The editor issues `GET {RestUrl}/item/{FormId}` to fetch the structure and `PUT {RestUrl}/item/{FormId}` to persist mutations.",
                @"FormId = ""00000000-0000-0000-0000-000000000001""",
                new ControlRestFormEditor(RandomId.Create())
                {
                    FormId = "00000000-0000-0000-0000-000000000001",
                    RestUri = sitemapManager.GetUri<FormEditor>(pageContext),
                    FieldCatalogUri = sitemapManager.GetUri<FormFieldCatalog>(pageContext),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Readonly",
                "Suppresses every mutation control and skips REST writes. The editor still issues the initial GET to load the structure, but the user cannot add / delete / drag / rename anything.",
                "Readonly = true",
                new ControlRestFormEditor(RandomId.Create())
                {
                    FormId = "00000000-0000-0000-0000-000000000001",
                    RestUri = sitemapManager.GetUri<FormEditor>(pageContext),
                    FieldCatalogUri = sitemapManager.GetUri<FormFieldCatalog>(pageContext),
                    Readonly = true,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
            );
        }
    }
}
