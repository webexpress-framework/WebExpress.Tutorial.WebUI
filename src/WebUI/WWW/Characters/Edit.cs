using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;

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
        /// Gets the form control used to manage character rest settings.
        /// </summary>
        public ControlFormCharacterEdit Form { get; } = new ControlFormCharacterEdit("characterform")
        {
        };

        /// <summary>
        /// Initializes a new instance of the class. The form's data service is
        /// declared by its endpoint type, so the client loads and submits the
        /// character through the emitted wx-service island.
        /// </summary>
        public Edit()
        {
            Form.DataService<MonkeyIslandCharacter>();
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
