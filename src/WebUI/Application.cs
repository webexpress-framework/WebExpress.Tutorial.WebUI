using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.Toutorial.WebUI
{
    /// <summary>
    /// Represents the application of the tutorial.
    /// </summary>
    [Name("webexpress.toutorial.webui:app.name")]
    [Description("webexpress.toutorial.webui:app.description")]
    [Icon("/assets/img/webui.svg")]
    [ContextPath("/webui")]
    public sealed class Application : IApplication
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Application()
        {
        }

        /// <summary>
        /// Called when the application starts working. The call is concurrent. 
        /// </summary>
        public void Run()
        {
        }
    }
}