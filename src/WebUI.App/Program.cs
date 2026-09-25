using System.Reflection;

namespace WebUI.App
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>The exit </returns>
        static int Main(string[] args)
        {
            var app = new WebExpress.WebCore.WebEx()
            {
                Name = Assembly.GetExecutingAssembly().GetName().Name
            };

            return app.Execution(args);
        }
    }
}