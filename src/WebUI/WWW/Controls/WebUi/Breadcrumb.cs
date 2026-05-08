using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
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
                Uri = _ => pageContext.Route.ToUri(),
            };

            Stage.Code = @"
            new ControlBreadcrumb()
            {
                Uri = _ => pageContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "TextColor",
                "Reteuns or sets the text color of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary)
                }",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Secondary),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Info),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Success),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Warning),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Light),
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    TextColor = _ => new PropertyColorText("gold"),
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Returns or sets the background color of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                };",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = _ => "Transparent", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Returns or sets the URI associated with the breadcrumb.",
                @"
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri()
                }",
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Prefix",
                "Returns or sets the prefix displayed before the main content of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    Prefix = _ => ""You are here:""
                }",
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Prefix = _ => "You are here:"
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the breadcrumb control.",
                @"
                new ControlBreadcrumb()
                {
                    Size = _ => TypeSizeButton.Small
                };",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => TypeSizeText.Default
                },
                new ControlText() { Text = _ => "ExtraSmall", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => TypeSizeText.ExtraSmall
                },
                new ControlText() { Text = _ => "Small", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => TypeSizeText.Small
                },
                new ControlText() { Text = _ => "Large", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => TypeSizeText.Large
                },
                new ControlText() { Text = _ => "ExtraLarge", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBreadcrumb()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Size = _ => TypeSizeText.ExtraLarge
                }
            );
        }
    }
}
