using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the breadcrumb control for the tutorial.    
    /// </summary>    
    [Title("Breadcrumb")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Breadcrumb : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="applicationContext">The application context.</param>
        /// <param name="pageContext">The context of the page where the line control is used.</param>
        public Breadcrumb(IApplicationContext applicationContext, IPageContext pageContext)
        {
            Stage.Description = @"The `Breadcrumb` control displays the user's navigation path within a hierarchical structure, allowing quick access to previous levels and improving orientation within the application.";

            Stage.Control = new ControlBreadcrumb()
            {
                Uri = pageContext.Route.ToUri(),
            };

            Stage.Code = @"
            new ControlBreadcrumb()
            {
                Uri = pageContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "TextColor",
                "Reteuns or sets the text color of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Primary)
                }",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Primary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Secondary),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Info),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Success),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Warning),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Danger),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Dark),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText(TypeColorText.Light),
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = new PropertyColorText("gold"),
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Returns or sets the background color of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                };",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = "Transparent", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Returns or sets the URI associated with the breadcrumb.",
                @"
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri()
                }",
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Prefix",
                "Returns or sets the prefix displayed before the main content of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    Prefix = ""You are here:""
                }",
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    Prefix = "You are here:"
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    Size = TypeSizeButton.Small
                };",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    Size = TypeSizeText.Default
                },
                new ControlText() { Text = "ExtraSmall", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    Size = TypeSizeText.ExtraSmall
                },
                new ControlText() { Text = "Small", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    Size = TypeSizeText.Small
                },
                new ControlText() { Text = "Large", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    Size = TypeSizeText.Large
                },
                new ControlText() { Text = "ExtraLarge", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = pageContext.Route.ToUri(),
                    Size = TypeSizeText.ExtraLarge
                }
            );
        }
    }
}
