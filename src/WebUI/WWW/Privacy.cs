using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW
{
    /// <summary>
    /// Provides application-owned sample privacy information for the cookie examples.
    /// </summary>
    [WebIcon<IconCookie>]
    [Title("webexpress.tutorial.webui:privacy.title")]
    [Scope<IScopeGeneral>]
    public sealed class Privacy : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Renders example information through the standard C# text controls.
        /// </summary>
        /// <param name="renderContext">The context used for localized page rendering.</param>
        /// <param name="visualTree">The application tree receiving the privacy information.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.Content.MainPanel.AddPrimary(new ControlText
            {
                Text = _ => "webexpress.tutorial.webui:privacy.example",
                Format = _ => TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText
            {
                Text = _ => "webexpress.tutorial.webui:privacy.storage",
                Format = _ => TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText
            {
                Text = _ => "webexpress.tutorial.webui:privacy.server",
                Format = _ => TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText
            {
                Text = _ => "webexpress.tutorial.webui:privacy.choice",
                Format = _ => TypeFormatText.Paragraph
            });
        }
    }
}
