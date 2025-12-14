using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WWW.Api._1;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Characters
{
    /// <summary>
    /// Represents the page for editing character rest settings within the 
    /// web application.
    /// </summary>
    [Title("Edit Character")]
    public sealed class Edit : IPage<VisualTreeWebApp>
    {
        /// <summary>
        /// Returns the form control used to manage character rest settings.
        /// </summary>
        public ControlFormCharacter Form { get; } = new ControlFormCharacter("characterform")
        {
        };

        /// <summary>
        /// Initializes a new instance of the class with the specified sitemap manager.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to manage and update sitemap data. Cannot be null.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public Edit(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            Form.Mode = TypeRestFormMode.Edit;
            Form.Uri = sitemapManager.GetUri<MonkeyIslandCharacter>(applicationContext);
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.Content.MainPanel.AddPrimary(Form);
        }
    }
}
