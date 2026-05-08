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
                Username = _ => "Dex Zogbert"
            };

            Stage.Code = @"
            new ControlAvatar()
            {
                Username = _ => ""Dex Zogbert""
            };";

            Stage.AddProperty
            (
                "Username",
                "Returns or sets the key of the attribute, representing the name or identifier in the key-value pair.",
                @"
                new ControlAvatar()
                {
                    Username = _ => ""Dex Zogbert""
                };",
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Reteuns or sets the text color of the user name.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Default),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Secondary),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Info),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Success),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Warning),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText(TypeColorText.Light),
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    TextColor = _ => new PropertyColorText("gold"),
                    Username = _ => "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Returns or sets the background color of the avatar control.",
                @"
                new ControlAvatar()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                };",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert"
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = _ => "Transparent", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    BackgroundColor = _ => new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Image",
                "Returns or sets the image associated with the control, typically used to visually represent a person, object, or entity.\r\n",
                @"
                new ControlAvatar()
                {
                    Image = _ => applicationContext.Route.Concat(""assets/img/dex_zogbert.png"").ToUri()
                }",
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    Image = _ => applicationContext.Route.Concat("assets/img/dex_zogbert.png").ToUri()
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Returns or sets the URI associated with the avatar.",
                @"
                new ControlAvatar()
                {
                    Uri = _ => pageContext.Route.ToUri()
                }",
                new ControlText() { Text = _ => "With URI", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlText() { Text = _ => "Without URI", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the avatar control.",
                @"
                new ControlAvatar()
                {
                    Size = _ => TypeSizeAvatar.Small
                };",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    Size = _ => TypeSizeAvatar.Default
                },
                new ControlText() { Text = _ => "Small", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    Size = _ => TypeSizeAvatar.Small
                },
                new ControlText() { Text = _ => "Large", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlAvatar()
                {
                    Username = _ => "Dex Zogbert",
                    Size = _ => TypeSizeAvatar.Large
                }
            );
        }
    }
}
