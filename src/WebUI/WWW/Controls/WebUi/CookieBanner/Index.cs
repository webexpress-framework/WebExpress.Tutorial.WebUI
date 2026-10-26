using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;
using WebExpress.WebApp.WebPage;
using System.Linq;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.CookieBanner
{
    /// <summary>
    /// Demonstrates application-owned purposes through declarative C# controls.
    /// </summary>
    [WebIcon<IconCookie>]
    [Title("webexpress.tutorial.webui:cookiebanner.title")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : PageControl
    {
        /// <summary>
        /// Configures a provider-independent consent example.
        /// </summary>
        /// <param name="componentHub">The component hub resolving the privacy page.</param>
        /// <param name="pageContext">The application context of the example page.</param>
        public Index(IComponentHub componentHub, IPageContext pageContext)
        {
            Stage.DarkControls = null;
            Stage.Description = "The consent mode exposes application-defined purposes configured entirely in C#. Accept all purposes, retain only necessary purposes or save an individual selection. The standard event log below displays the resulting decision and its category permissions. No external provider is contacted. The Notice child page demonstrates acknowledgement without permissions.";
            Stage.AddEvent(Event.COOKIE_CHANGE_EVENT);
            Stage.Controls =
            [
                new ControlCookieBanner("tutorial-consent")
                {
                    Mode = _ => TypeCookieBannerMode.Consent,
                    PrivacyUri = _ => componentHub.SitemapManager.GetUri<Privacy>(pageContext.ApplicationContext),
                    PrivacyLabel = _ => "webexpress.tutorial.webui:privacy.title",
                    StorageKey = _ => "tutorial:cookie-consent",
                    Categories = _ =>
                    [
                        new CookieBannerCategory { Id = "necessary", Label = "webexpress.tutorial.webui:cookiebanner.necessary.label", Description = "webexpress.tutorial.webui:cookiebanner.necessary.description", Necessary = true },
                        new CookieBannerCategory { Id = "statistics", Label = "webexpress.tutorial.webui:cookiebanner.statistics.label", Description = "webexpress.tutorial.webui:cookiebanner.statistics.description" },
                        new CookieBannerCategory { Id = "media", Label = "webexpress.tutorial.webui:cookiebanner.media.label", Description = "webexpress.tutorial.webui:cookiebanner.media.description" }
                    ]
                }
            ];
            Stage.Code = """
                new ControlCookieBanner("privacy")
                {
                    Mode = _ => TypeCookieBannerMode.Consent,
                    StorageKey = _ => "my-application:privacy",
                    PrivacyUri = _ => componentHub.SitemapManager.GetUri<Privacy>(pageContext.ApplicationContext),
                    PrivacyLabel = _ => "webexpress.tutorial.webui:privacy.title",
                    Version = _ => "1",
                    Categories = _ =>
                    [
                        new CookieBannerCategory { Id = "necessary", Label = "webexpress.tutorial.webui:cookiebanner.necessary.label", Description = "webexpress.tutorial.webui:cookiebanner.necessary.description", Necessary = true },
                        new CookieBannerCategory { Id = "statistics", Label = "webexpress.tutorial.webui:cookiebanner.statistics.label", Description = "webexpress.tutorial.webui:cookiebanner.statistics.description" },
                        new CookieBannerCategory { Id = "media", Label = "webexpress.tutorial.webui:cookiebanner.media.label", Description = "webexpress.tutorial.webui:cookiebanner.media.description" }
                    ]
                }
                """;
            Stage.AddProperty("Mode", "Notice stores an acknowledgement. Consent stores individual category choices.",
                "Mode = _ => TypeCookieBannerMode.Consent");
            Stage.AddProperty("StorageKey", "Use one unique key per application and policy. Share it across that application's pages.",
                "StorageKey = _ => \"my-application:privacy\"");
            Stage.AddProperty("PrivacyUri", "Resolve the application's privacy information page through the sitemap.",
                "PrivacyUri = _ => componentHub.SitemapManager.GetUri<Privacy>(pageContext.ApplicationContext)");
            Stage.AddProperty("PrivacyLabel", "Configure the privacy link text or a translation key for the banner and settings dialog.",
                "PrivacyLabel = _ => \"webexpress.tutorial.webui:privacy.title\"");
            Stage.AddProperty("Version", "Change the version when purposes or policy text change to request a new decision.",
                "Version = _ => \"2\"");
        }
        /// <summary>
        /// Demonstrates reading the browser preference on the server without tutorial JavaScript.
        /// </summary>
        /// <param name="renderContext">The incoming request carrying the preference cookie.</param>
        /// <param name="visualTree">The page receiving the server-side decision summary.</param>
        public override void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var banner = (ControlCookieBanner)Stage.Controls.First();
            var decision = banner.GetDecision(new RenderControlContext(renderContext));
            visualTree.Content.MainPanel.AddPrimary(new ControlText
            {
                Text = _ => decision is null ? "webexpress.tutorial.webui:cookiebanner.server.pending"
                    : decision.IsAllowed("statistics") ? "webexpress.tutorial.webui:cookiebanner.server.allowed"
                    : "webexpress.tutorial.webui:cookiebanner.server.denied",
                Format = _ => TypeFormatText.Paragraph
            });
            base.Process(renderContext, visualTree);
        }
    }
}
