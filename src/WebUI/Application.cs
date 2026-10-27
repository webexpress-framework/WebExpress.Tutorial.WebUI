using WebExpress.Tutorial.WebUI.WebTheme;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebTheme;
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
    [Theme<StandardTheme>]
    public sealed class Application : IApplication
    {
        /// <summary>
        /// Gets the current application context, which provides access to 
        /// application-wide services and configurations.
        /// </summary>
        public static IApplicationContext ApplicationContext { get; private set; }

        /// <summary>
        /// Gets the pirate drawings, offered as icon set on the Designs page.
        /// </summary>
        public static IconSet MonkeyIsland { get; } = new
        (
            "monkeyisland",
            "webexpress.tutorial.webui:iconset.monkeyisland.label",
            "webexpress.tutorial.webui:iconset.monkeyisland.tooltip",
            "assets/css/monkeyisland.icons.css"
        );

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="applicationContext">The context that supplies application services to the tutorial.</param>
        public Application(IApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            ThemePreferences.Register(applicationContext, ThemeStore.Resolve,
                () => new ControlDataSelectionTheme("tutorialThemeSelector").DataService<ThemeApi>());
            ThemePreferences.RegisterIconSets(applicationContext, [IconSet.Default, MonkeyIsland], ThemeStore.ResolveIconSet,
                () => new ControlDataSelectionIconSet("tutorialIconSetSelector").DataService<IconSetApi>());
            ThemePreferences.RegisterColorScheme<ColorSchemeApi>(applicationContext, ThemeStore.ResolveColorScheme);
        }

        /// <summary>
        /// Called when the application starts working. The call is concurrent. 
        /// </summary>
        public void Run()
        {
        }

        /// <summary>
        /// Disposes of the resources used by the application. This method is called when 
        /// the application is no longer needed and should release any unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            ThemePreferences.Remove(ApplicationContext);
        }
    }
}
