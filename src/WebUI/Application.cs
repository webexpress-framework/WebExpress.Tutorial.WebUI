using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.Tutorial.WebUI
{
    /// <summary>
    /// Represents the application of the tutorial.
    /// </summary>
    [Name("webexpress.Tutorial.webui:app.name")]
    [Description("webexpress.Tutorial.webui:app.description")]
    [Icon("/assets/img/webui.svg")]
    [ContextPath("/webui")]
    public sealed class Application : IApplication
    {
        /// <summary>
        /// Returns the current application context, which provides access to application-wide services and configurations.
        /// </summary>
        public static IApplicationContext ApplicationContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Application(IApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        /// <summary>
        /// Called when the application starts working. The call is concurrent. 
        /// </summary>
        public void Run()
        {
        }
    }
}