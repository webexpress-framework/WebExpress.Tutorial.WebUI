using System.Linq;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebApp.WWW
{
    /// <summary>
    /// Represents the info page for the tutorial.
    /// </summary>
    [Title("webui:infopage.label")]
    [Scope<IScopeGeneral>]
    public sealed class Info : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class with the specified page context.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Info(IPageContext pageContext)
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var webexpress = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.PluginId.ToString() == "webexpress.webapp").FirstOrDefault();
            var webapp = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.Assembly == GetType().Assembly).FirstOrDefault();

            visualTree.Content.MainPanel.AddPrimary(new ControlImage()
            {
                Uri = renderContext.PageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(),
                Width = 200,
                Height = 200,
                HorizontalAlignment = TypeHorizontalAlignment.Right
            });

            var card = new ControlPanelCard()
            {
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
            };

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webui:app.name"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webui:app.description"),
                Format = TypeFormatText.Paragraph
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webui:app.about"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = string.Format
                (
                    I18N.Translate(renderContext.Request?.Culture, "webui:app.version.label"),
                    I18N.Translate(renderContext.Request?.Culture, webapp?.PluginName),
                    webapp?.Version,
                    webexpress?.PluginName,
                    webexpress?.Version
                ),
                TextColor = new PropertyColorText(TypeColorText.Primary)
            });

            visualTree.Content.MainPanel.AddPrimary(card);
        }
    }
}
