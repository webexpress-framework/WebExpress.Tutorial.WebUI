using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the image control for the tutorial.
    /// </summary>
    [Title("Image")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Image : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        public Image(IApplicationContext applicationContext)
        {
            Stage.Description = @"An `Image` is a visual component used to display a single picture or graphic. It is ideal for showcasing product photos, profile pictures, illustrations, or any content that benefits from a clear, visually engaging presentation.";

            Stage.Control = new ControlImage()
            {
                Height = _ => 300,
                Uri = _ => applicationContext.Route.Concat("assets/img/image1.png").ToUri()
            };

            Stage.Code = @"
                Stage.Control = new ControlImage()
                {
                    Height = _ => 300,
                    Uri = _ => applicationContext.Route.Concat(""assets/img/image1.png"").ToUri()
                };";

            Stage.DarkControls =
                [
                    new ControlImage()
                        {
                            Height = _ => 300,
                            Uri = _ => applicationContext.Route.Concat("assets/img/image1.png").ToUri()
                        }
                ];

            Stage.AddProperty
                (
                    "Uri",
                    "The `Uri` property is a fundamental attribute of image-based UI components—like an `Image` control—that determines where the image is loaded from. This can be a resource embedded in the application or a remote web URL.",
                    "Uri = _ => applicationContext.Route.Concat(\"assets/img/image2.png\").ToUri()",
                    new ControlImage()
                    {
                        Height = _ => 300,
                        Uri = _ => applicationContext.Route.Concat("assets/img/image2.png").ToUri()
                    }
                );

            Stage.AddProperty
                (
                    "Width",
                    "The `Width` property defines the horizontal size of a UI element, measured in pixels. It's one of the core layout attributes used to control how elements are rendered in an interface.",
                    "Width = _ => 150",
                    new ControlImage()
                    {
                        Width = _ => 150,
                        Uri = _ => applicationContext.Route.Concat("assets/img/image3.png").ToUri()
                    }
                );

            Stage.AddProperty
                (
                    "Height",
                    "The `Height` property defines the vertical size of a UI element, measured in pixels. It's one of the core layout attributes used to control how elements are rendered in an interface.",
                    "Width = _ => 150",
                    new ControlImage()
                    {
                        Height = _ => 150,
                        Uri = _ => applicationContext.Route.Concat("assets/img/image3.png").ToUri()
                    }
                );

            Stage.AddProperty
                (
                    "Tooltip",
                    "A Tooltip is a small, informative popup that appears when a user hovers over (or long-presses) a UI element, such as a button, image, or control. The Tooltip property allows developers to assign a short text description that provides helpful context or guidance without cluttering the interface.",
                    "Tooltip = _ => \"Two aliens riding together on a dragon through a glowing orange sky.\"",
                    new ControlImage()
                    {
                        Height = _ => 300,
                        Tooltip = _ => "Two aliens riding together on a dragon through a glowing orange sky.",
                        Uri = _ => applicationContext.Route.Concat("assets/img/image3.png").ToUri()
                    }
                );
        }
    }
}
