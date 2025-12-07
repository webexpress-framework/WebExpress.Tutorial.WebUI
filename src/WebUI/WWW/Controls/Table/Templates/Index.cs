using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Table.Templates
{
    /// <summary>
    /// Represents the overview page of built-in templates 
    /// available as cell renderers. Custom renderers can also be defined.
    /// </summary>
    [Title("Templates")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : IPage<VisualTreeWebApp>
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        public Index()
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = @"This page provides an overview of the built-in templates that are available as cell renderers within the `TableControl`. In addition to the predefined options, developers can also implement and integrate their own custom renderers.",
                Format = TypeFormatText.Markdown
            });
        }
    }
}
