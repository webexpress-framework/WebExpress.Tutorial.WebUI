using System;
using System.Net;
using WebExpress.Tutorial.WebUI.WWW;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebEndpoint;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Rebuilds the public project website with WebExpress controls instead of embedding its HTML document.
    /// </summary>
    public sealed class LandingExampleContent
    {
        private readonly IUri _pageUri;
        private readonly IUri _homeUri;
        private readonly IUri _privacyUri;
        private readonly IUri _logoUri;

        /// <summary>
        /// Resolves local destinations once so the example also works below a different application route.
        /// </summary>
        /// <param name="componentHub">The component hub providing sitemap access.</param>
        /// <param name="fragmentContext">The application owning the landing fragments.</param>
        public LandingExampleContent(IComponentHub componentHub, IFragmentContext fragmentContext)
        {
            _pageUri = componentHub.SitemapManager.GetUri<Landing>(fragmentContext.ApplicationContext);
            _homeUri = componentHub.SitemapManager.GetUri<WWW.Index>(fragmentContext.ApplicationContext);
            _privacyUri = componentHub.SitemapManager.GetUri<Privacy>(fragmentContext.ApplicationContext);
            _logoUri = new UriEndpoint(RouteEndpoint.Combine(fragmentContext.ApplicationContext.Route,
                "assets/img/landing-logo.svg"));
        }

        /// <summary>
        /// Recreates the reference website's hero content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed hero controls.</returns>
        public IControl CreateHero()
        {
            return Panel("wx-landing-container wx-landing-hero-inner", null,
                Text("landing.reference.hero.text.1", TypeFormatText.Paragraph, "wx-landing-eyebrow", null),
                Text("landing.reference.hero.text.2", TypeFormatText.H1, "wx-landing-hero-title", "hero-title"),
                Text("landing.reference.hero.text.3", TypeFormatText.Paragraph, "wx-landing-hero-lead", null),
                Panel("wx-landing-hero-actions", null,
                    Link("landing.reference.hero.link.1", "#get-started", "wx-landing-btn wx-landing-btn-primary"),
                    Link("landing.reference.hero.link.2", "https://github.com/webexpress-framework/WebExpress", "wx-landing-btn wx-landing-btn-ghost")),
                Panel("wx-landing-hero-highlights", null,
                    Text("landing.reference.hero.highlight.1"),
                    Text("landing.reference.hero.highlight.2"),
                    Text("landing.reference.hero.highlight.3")));
        }

        /// <summary>
        /// Recreates the reference website's introduction content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed introduction controls.</returns>
        public IControl CreateIntroduction()
        {
            return Panel("wx-landing-section", "get-started",
                Panel("wx-landing-container", null,
                    Panel("wx-landing-section-header", null,
                        Text("landing.reference.introduction.text.1", TypeFormatText.Paragraph, "wx-landing-eyebrow", null),
                        Text("landing.reference.introduction.text.2", TypeFormatText.H2, "", "get-started-title"),
                        Text("landing.reference.introduction.text.3", TypeFormatText.Paragraph, "wx-landing-section-lead", null)),
                    Panel("wx-landing-cards", null,
                        Panel("wx-landing-card", null,
                            Text("landing.reference.introduction.text.4", TypeFormatText.H3, "wx-landing-card-title", null),
                            Text("landing.reference.introduction.text.5", TypeFormatText.Paragraph, "", null),
                            Panel("wx-landing-link-list", null, Text("landing.reference.introduction.list.1", TypeFormatText.Markdown))),
                        Panel("wx-landing-card", null,
                            Text("landing.reference.introduction.text.6", TypeFormatText.H3, "wx-landing-card-title", null),
                            Panel("", null, Text("landing.reference.introduction.text.7", TypeFormatText.Markdown)),
                            Panel("wx-landing-link-list", null, Text("landing.reference.introduction.list.2", TypeFormatText.Markdown))),
                        Panel("wx-landing-card", null,
                            Text("landing.reference.introduction.text.8", TypeFormatText.H3, "wx-landing-card-title", null),
                            Text("landing.reference.introduction.text.9", TypeFormatText.Paragraph, "", null),
                            Panel("wx-landing-link-list", null, Text("landing.reference.introduction.list.3", TypeFormatText.Markdown)))),
                    Panel("wx-landing-snippet", null,
                        Panel("wx-landing-snippet-caption", null, Text("landing.reference.introduction.text.10", TypeFormatText.Markdown)),
                        new ControlCode { Code = _ => "{\n  \"WebExpress\": {\n    \"Endpoints\": [\n      { \"Uri\": \"http://localhost:8080/\" }\n    ],\n    \"ExternalUri\": \"http://localhost:8080/\",\n    \"Culture\": \"en-US\",\n    \"PackagePath\": \"./packages\",\n    \"AssetPath\": \"./assets\",\n    \"DataPath\": \"./data\"\n  }\n}", Language = _ => TypeLanguage.Default }),
                    Panel("", null, Text("landing.reference.introduction.text.11", TypeFormatText.Paragraph)),
                    Panel("", null, Text("landing.reference.introduction.text.12", TypeFormatText.Markdown)),
                    Panel("", null, Text("landing.reference.introduction.text.13", TypeFormatText.Markdown)),
                    Panel("wx-landing-section-footnote", null, Text("landing.reference.introduction.text.14", TypeFormatText.Markdown))));
        }

        /// <summary>
        /// Recreates the reference website's contribute content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed contribute controls.</returns>
        public IControl CreateContribute()
        {
            return Panel("wx-landing-section wx-landing-section-alt", "contribute",
                Panel("wx-landing-container", null,
                    Panel("wx-landing-section-header", null,
                        Text("landing.reference.contribute.text.1", TypeFormatText.Paragraph, "wx-landing-eyebrow", null),
                        Text("landing.reference.contribute.text.2", TypeFormatText.H2, "", "contribute-title"),
                        Text("landing.reference.contribute.text.3", TypeFormatText.Paragraph, "wx-landing-section-lead", null)),
                    Panel("wx-landing-cards wx-landing-cards-two", null,
                        Panel("wx-landing-card", null,
                            Text("landing.reference.contribute.text.4", TypeFormatText.H3, "wx-landing-card-title", null),
                            Panel("wx-landing-bullet-list", null, Text("landing.reference.contribute.list.1", TypeFormatText.Markdown)),
                            Panel("wx-landing-link-list", null, Text("landing.reference.contribute.list.2", TypeFormatText.Markdown))),
                        Panel("wx-landing-card", null,
                            Text("landing.reference.contribute.text.5", TypeFormatText.H3, "wx-landing-card-title", null),
                            Panel("wx-landing-bullet-list", null, Text("landing.reference.contribute.list.3", TypeFormatText.Markdown)),
                            Panel("wx-landing-link-list", null, Text("landing.reference.contribute.list.4", TypeFormatText.Markdown))))));
        }

        /// <summary>
        /// Recreates the reference website's contact content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed contact controls.</returns>
        public IControl CreateContact()
        {
            return Panel("wx-landing-section", "contact",
                Panel("wx-landing-container", null,
                    Panel("wx-landing-section-header", null,
                        Text("landing.reference.contact.text.1", TypeFormatText.Paragraph, "wx-landing-eyebrow", null),
                        Text("landing.reference.contact.text.2", TypeFormatText.H2, "", "contact-title"),
                        Text("landing.reference.contact.text.3", TypeFormatText.Paragraph, "wx-landing-section-lead", null)),
                    Panel("wx-landing-cards wx-landing-cards-two", null,
                        Panel("wx-landing-card", null,
                            Text("landing.reference.contact.text.4", TypeFormatText.H3, "wx-landing-card-title", null),
                            Text("landing.reference.contact.text.5", TypeFormatText.Paragraph, "", null),
                            Panel("wx-landing-link-list", null, Text("landing.reference.contact.list.1", TypeFormatText.Markdown)),
                            Panel("wx-landing-muted wx-landing-small", null, Text("landing.reference.contact.text.6", TypeFormatText.Markdown))),
                        Panel("wx-landing-card", null,
                            Text("landing.reference.contact.text.7", TypeFormatText.H3, "wx-landing-card-title", null),
                            Text("landing.reference.contact.text.8", TypeFormatText.Paragraph, "", null),
                            Panel("wx-landing-contact-mail", null, Text("landing.reference.contact.text.9", TypeFormatText.Markdown)),
                            Text("landing.reference.contact.text.10", TypeFormatText.Paragraph, "wx-landing-muted wx-landing-small", null)))));
        }

        /// <summary>
        /// Recreates the reference website's legal content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed legal controls.</returns>
        public IControl CreateLegal()
        {
            return Panel("wx-landing-section wx-landing-section-alt", "legal",
                Panel("wx-landing-container", null,
                    Panel("wx-landing-section-header", null,
                        Text("landing.reference.legal.text.1", TypeFormatText.Paragraph, "wx-landing-eyebrow", null),
                        Text("landing.reference.legal.text.2", TypeFormatText.H2, "", "legal-title"),
                        Text("landing.reference.legal.text.3", TypeFormatText.Paragraph, "wx-landing-section-lead", null)),
                    Panel("wx-landing-legal-grid", null,
                        Panel("wx-landing-legal-box", null,
                            Text("landing.reference.legal.text.4", TypeFormatText.H3, "", null),
                            Text("landing.reference.legal.text.5", TypeFormatText.Paragraph, "", null)),
                        Panel("wx-landing-legal-box", null,
                            Text("landing.reference.legal.text.6", TypeFormatText.H3, "", null),
                            Text("landing.reference.legal.text.7", TypeFormatText.Paragraph, "", null)),
                        Panel("wx-landing-legal-box", null,
                            Text("landing.reference.legal.text.8", TypeFormatText.H3, "", null),
                            Panel("", null, Text("landing.reference.legal.text.9", TypeFormatText.Markdown))))));
        }

        /// <summary>
        /// Recreates the reference website's header content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed header controls.</returns>
        public IControl CreateHeader()
        {
            return Panel("", null,
                Link("landing.reference.skip", "#wx-landing-main", "wx-landing-skip-link"),
                Panel("wx-landing-container wx-landing-site-header-inner", null,
                Brand("WebExpress-Framework", "wx-landing-brand"),
                Panel("wx-landing-site-nav wx-landing-nav", null,
                    Panel("wx-landing-site-nav-list", "primary-menu",
                        Panel("", null,
                            Link("landing.reference.header.link.1", "#get-started", "")),
                        Panel("", null,
                            Link("landing.reference.header.link.2", "#contribute", "")),
                        Panel("", null,
                            Link("landing.reference.header.link.3", "#contact", "")),
                        Panel("", null,
                            Link("landing.reference.header.link.4", "https://github.com/webexpress-framework/WebExpress", ""))))));
        }

        /// <summary>
        /// Recreates the reference website's footer content with native WebExpress controls.
        /// </summary>
        /// <returns>The composed footer controls.</returns>
        public IControl CreateFooter()
        {
            return Panel("", null,
                Panel("wx-landing-container wx-landing-site-footer-inner", null,
                    Panel("wx-landing-site-footer-col", null,
                        Brand("WebExpress", "wx-landing-brand wx-landing-brand-footer"),
                        Text("landing.reference.footer.text.1", TypeFormatText.Paragraph, "wx-landing-muted wx-landing-small", null)),
                    Panel("wx-landing-site-footer-col wx-landing-nav", null,
                        Text("landing.reference.footer.text.2", TypeFormatText.H4, "", null),
                        Panel("", null, Text("landing.reference.footer.list.1", TypeFormatText.Markdown))),
                    Panel("wx-landing-site-footer-col wx-landing-nav", null,
                        Text("landing.reference.footer.text.3", TypeFormatText.H4, "", null),
                        Panel("", null, Text("landing.reference.footer.list.2", TypeFormatText.Markdown))),
                    Panel("wx-landing-site-footer-col wx-landing-nav", null,
                        Text("landing.reference.footer.text.4", TypeFormatText.H4, "", null),
                        Panel("", null, Text("landing.reference.footer.list.3", TypeFormatText.Markdown)))),
                Panel("wx-landing-container wx-landing-site-footer-meta", null,
                    Text("landing.reference.footer.text.5", TypeFormatText.Paragraph, "", null)));
        }

        /// <summary>
        /// Builds layout groups without introducing HTML strings into the page composition.
        /// </summary>
        /// <param name="classes">The landing stylesheet classes applied to the group.</param>
        /// <param name="id">The optional anchor used by section navigation.</param>
        /// <param name="controls">The controls composed inside the group.</param>
        /// <returns>The configured layout panel.</returns>
        private static ControlPanel Panel(string classes, string id, params IControl[] controls)
        {
            return new ControlPanel(id, controls)
            {
                Role = _ => classes.Contains("wx-landing-nav") ? "navigation" : null,
                Classes = classes.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            };
        }

        /// <summary>
        /// Supplies localized text and native Markdown for inline code, lists, and documentation links.
        /// </summary>
        /// <param name="key">The resource key containing the source website's English copy.</param>
        /// <param name="format">The semantic text format required by the section.</param>
        /// <param name="classes">The typography classes applied by the landing stylesheet.</param>
        /// <param name="id">The optional heading anchor.</param>
        /// <returns>The configured text control.</returns>
        private ControlText Text(string key, TypeFormatText format = TypeFormatText.Default, string classes = "", string id = null)
        {
            return new ControlText(id)
            {
                Text = context =>
                {
                    var text = I18N.Translate(context, "webexpress.tutorial.webui:" + key)
                        .Replace("\\n", "\n")
                        .Replace("(privacy)", "(" + _privacyUri + ")");
                    return format == TypeFormatText.Markdown ? text : WebUtility.HtmlEncode(text);
                },
                Format = _ => format,
                Classes = classes.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            };
        }

        /// <summary>
        /// Keeps section links on the landing route even when the document has an application base URI.
        /// </summary>
        /// <param name="key">The localized navigation label.</param>
        /// <param name="destination">An in-page anchor or external documentation destination.</param>
        /// <param name="classes">The link or call-to-action styling.</param>
        /// <returns>The configured native link control.</returns>
        private ControlLink Link(string key, string destination, string classes)
        {
            var uri = destination.StartsWith('#')
                ? new UriEndpoint(_pageUri).SetFragment(destination[1..])
                : new UriEndpoint(destination);
            return new ControlLink
            {
                Text = _ => "webexpress.tutorial.webui:" + key,
                Uri = _ => uri,
                Classes = classes.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            };
        }

        /// <summary>
        /// Uses the original project logo as an embedded local asset without remote image requests.
        /// </summary>
        /// <returns>The decorative logo accompanying the visible brand name.</returns>
        private ControlImage Logo()
        {
            return new ControlImage
            {
                Uri = _ => _logoUri,
                Width = _ => 32,
                Height = _ => 32,
                Alt = _ => "",
                Classes = ["wx-landing-brand-logo"]
            };
        }

        /// <summary>
        /// Composes the linked brand with a local image and visible project name.
        /// </summary>
        /// <param name="name">The project name shown beside the logo.</param>
        /// <param name="classes">The header or footer brand styles.</param>
        /// <returns>The linked brand control.</returns>
        private ControlLink Brand(string name, string classes)
        {
            return new ControlLink(null, Logo())
            {
                Text = _ => name,
                Uri = _ => _homeUri,
                Classes = classes.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            };
        }
    }
}
