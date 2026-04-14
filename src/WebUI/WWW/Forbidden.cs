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
    /// Represents a web page that displays a forbidden access message to users who do not 
    /// have the required permissions.
    /// </summary>
    [WebIcon<IconLock>]
    [Title("webexpress.tutorial.webui:forbiddenpage.label")]
    [Scope<IScopeGeneral>]
    [Policy<SystemAccessPolicy>]
    public sealed class Forbidden : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Forbidden()
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
                Text = I18N.Translate(renderContext, "webexpress.tutorial.webui:app.name"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext, "webexpress.tutorial.webui:app.description"),
                Format = TypeFormatText.Paragraph
            });

            card.Add(new ControlText()
            {
                Text = "You must never see this content.",
                Format = TypeFormatText.Paragraph,
                TextColor = new PropertyColorText(TypeColorText.Danger)
            });

            visualTree.Content.MainPanel.AddPrimary(card);
        }
    }
}
