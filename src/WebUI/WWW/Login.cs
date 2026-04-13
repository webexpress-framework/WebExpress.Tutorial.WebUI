using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebPolicies;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW
{
    /// <summary>
    /// Represents the page for tests the login in the web application, providing logic for rendering and processing user
    /// authentication input.
    /// </summary>
    [WebIcon<IconPowerOff>]
    [Title("webexpress.tutorial.webui:loginpage.label")]
    [Scope<IScopeGeneral>]
    [Policy<AuthenticatedAccessPolicy>]
    public sealed class Login : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Login()
        {
        }

        /// <summary>
        /// Processing of the page.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree control to be processed.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var card = new ControlPanelCard()
            {
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
            };

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext, "webexpress.Tutorial.webui:app.name"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext, "webexpress.Tutorial.webui:app.description"),
                Format = TypeFormatText.Paragraph
            });

            visualTree.Content.MainPanel.AddPrimary(card);
        }
    }
}
