using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the color control for the tutorial.  
    /// </summary>  
    [Title("Color")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Color : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        public Color()
        {
            Stage.Description = @"The `Code` control provides a clean and structured way to display source code within a defined box, complete with syntax highlighting. It’s particularly useful in development environments, documentation platforms, or educational tools where readable and well-organized code presentation is essential. With features such as automatic line wrapping and a copy button, this control enhances usability and improves the overall interaction with code snippets.";

            Stage.Controls = [
                new ControlColor()
                    {
                        Color = "orange"
                    }
            ];

            Stage.Code = @"
            new ControlColor()
            {
                Color = ""orange""
            }";

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the visual color value applied to the control. It updates the swatch and ensures that the selected color is represented consistently in the UI.",
                "Color = \"green\"",
                new ControlColor() { Color = "green" }
            );

            Stage.AddProperty
            (
                "Tooltip",
                "The `Tooltip` property specifies the text shown when hovering over the color swatch. It helps users understand the meaning or purpose of the selected color.",
                "Tooltip = \"green\"",
                new ControlColor() { Color = "green", Tooltip = "green" }
            );
        }
    }
}
