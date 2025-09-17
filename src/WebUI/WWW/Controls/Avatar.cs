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
    /// Represents the avatar control for the tutorial.
    /// </summary>    
    [Title("Avatar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Avatar : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="applicationContext">The application context.</param>
        /// <param name="pageContext">The context of the page where the line control is used.</param>
        public Avatar(IApplicationContext applicationContext, IPageContext pageContext)
        {
            Stage.Description = @"The `Avatar` control displays a visual representation of a person or entity, typically using an image or initials.";

            Stage.Control = new ControlAvatar()
            {
                User = "Dex Zogbert"
            };

            Stage.Code = @"
            new ControlAvatar()
            {
                User = ""Dex Zogbert""
            };";

            Stage.AddProperty
            (
                "User",
                "Returns or sets the key of the attribute, representing the name or identifier in the key-value pair.",
                @"
                new ControlAvatar()
                {
                    User = ""Dex Zogbert""
                };",
                new ControlAvatar()
                {
                    User = "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Reteuns or sets the text color of the user name.",
                "TextColor = new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Default),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Primary),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Secondary),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Info),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Success),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Warning),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Danger),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Dark),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText(TypeColorText.Light),
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = new PropertyColorText("gold"),
                    User = "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Returns or sets the background color of the avatar control.",
                @"
                new ControlAvatar()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                };",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert"
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = "Transparent", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    BackgroundColor = new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Image",
                "Returns or sets the image associated with the control, typically used to visually represent a person, object, or entity.\r\n",
                @"
                new ControlAvatar()
                {
                    Image = applicationContext.Route.Concat(""assets/img/dex_zogbert.png"").ToUri()
                }",
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    Image = applicationContext.Route.Concat("assets/img/dex_zogbert.png").ToUri()
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Returns or sets the URI associated with the avatar.",
                @"
                new ControlAvatar()
                {
                    Uri = pageContext.Route.ToUri()
                }",
                new ControlText() { Text = "With URI", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlText() { Text = "Without URI", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the avatar control.",
                @"
                new ControlAvatar()
                {
                    Size = TypeSizeAvatar.Small
                };",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    Size = TypeSizeAvatar.Default
                },
                new ControlText() { Text = "Small", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    Size = TypeSizeAvatar.Small
                },
                new ControlText() { Text = "Large", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    User = "Dex Zogbert",
                    Size = TypeSizeAvatar.Large
                }
            );
        }
    }
}
