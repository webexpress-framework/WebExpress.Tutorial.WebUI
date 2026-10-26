using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.CookieBanner
{
    /// <summary>
    /// Demonstrates an informational acknowledgement without optional permissions.
    /// </summary>
    [WebIcon<IconCookie>]
    [Title("webexpress.tutorial.webui:cookiebanner.notice.title")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Notice : PageControl
    {
        /// <summary>
        /// Configures the informational variant independently of the consent example.
        /// </summary>
        /// <param name="componentHub">The component hub resolving the privacy page.</param>
        /// <param name="pageContext">The application context of the example page.</param>
        public Notice(IComponentHub componentHub, IPageContext pageContext)
        {
            Stage.DarkControls = null;
            Stage.Description = "The notice mode records that information has been acknowledged. It never grants optional permissions. The permanent privacy information button reopens the notice.";
            Stage.Controls =
            [
                new ControlCookieBanner("tutorial-notice")
                {
                    Mode = _ => TypeCookieBannerMode.Notice,
                    PrivacyUri = _ => componentHub.SitemapManager.GetUri<Privacy>(pageContext.ApplicationContext),
                    PrivacyLabel = _ => "webexpress.tutorial.webui:privacy.title",
                    StorageKey = _ => "tutorial:cookie-notice"
                }
            ];
            Stage.Code = """
                new ControlCookieBanner("privacy")
                {
                    Mode = _ => TypeCookieBannerMode.Notice,
                    StorageKey = _ => "my-application:notice",
                    PrivacyUri = _ => componentHub.SitemapManager.GetUri<Privacy>(pageContext.ApplicationContext),
                    PrivacyLabel = _ => "webexpress.tutorial.webui:privacy.title"
                }
                """;
        }
    }
}
