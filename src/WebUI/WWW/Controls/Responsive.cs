using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the responsive control for the tutorial.  
    /// </summary>  
    [Title("Responsive")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Responsive : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        public Responsive(IPageContext pageContext)
        {
            Stage.Description = @"The `Responsive` control is a UI controller that dynamically shows or hides panels depending on the width of its container. It enables modular, responsive layouts by selecting the most appropriate panel for the current viewport size. Only one panel is visible at a time, based on the active breakpoint.";

            Stage.Controls = [
                new ControlResponsive()
                    .Add(new ControlPanel().Add(new ControlText() { Text = "Fallback" }), -1)
                    .Add(new ControlPanel().Add(new ControlText() { Text = "Panel for >= 100px" }), 100)
                    .Add(new ControlPanel().Add(new ControlText() { Text = "Panel for >= 200px" }), 200)
                    .Add(new ControlPanel().Add(new ControlText() { Text = "Panel for >= 300px" }), 300)
                    .Add(new ControlPanel().Add(new ControlText() { Text = "Panel for >= 400px" }), 400)
                    .Add(new ControlPanel().Add(new ControlText() { Text = "Panel for >= 500px" }), 500)
            ];

            Stage.Code = @"
            new ControlResponsive()
                .Add(new ControlPanel().Add(new ControlText() { Text = ""Fallback"" }), -1) 
                .Add(new ControlPanel().Add(new ControlText() { Text = ""Panel for >= 100px"" }), 100)
                .Add(new ControlPanel().Add(new ControlText() { Text = ""Panel for >= 200px"" }), 200)
                .Add(new ControlPanel().Add(new ControlText() { Text = ""Panel for >= 300px"" }), 300)
                .Add(new ControlPanel().Add(new ControlText() { Text = ""Panel for >= 400px"" }), 400)
                .Add(new ControlPanel().Add(new ControlText() { Text = ""Panel for >= 500px"" }), 500);";

        }
    }
}
