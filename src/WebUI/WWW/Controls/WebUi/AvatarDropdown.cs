using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the avatar dropdown control for the tutorial.
    /// </summary>    
    [Title("AvatarDropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class AvatarDropdown : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="applicationContext">The application context.</param>
        /// <param name="pageContext">The context of the page where the line control is used.</param>
        public AvatarDropdown(IApplicationContext applicationContext, IPageContext pageContext)
        {
            Stage.Description = @"The `AvatarDropdown` control combines a visual avatar representation with an interactive dropdown menu. When the user selects the avatar, a menu appears containing common user actions such as viewing the profile, accessing settings, or logging out.";

            Stage.Control = new ControlAvatarDropdown()
            {
                Image = applicationContext.Route.Concat("assets/img/dex_zogbert.png").ToUri()
            };

            Stage.Code = @"
            new ControlAvatarDropdown()
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
                new ControlAvatarDropdown()
                {
                    User = "Dex Zogbert"
                }
            );

            Stage.AddProperty
            (
                "Image",
                "Returns or sets the image associated with the control, typically used to visually represent a person, object, or entity.\r\n",
                @"
                new ControlAvatarDropdown()
                {
                    Image = applicationContext.Route.Concat(""assets/img/dex_zogbert.png"").ToUri()
                }",
                new ControlAvatarDropdown()
                {
                    Image = applicationContext.Route.Concat("assets/img/dex_zogbert.png").ToUri()
                }
            );

            Stage.AddProperty
            (
                "MenuAlignment",
                "Determines how the menu should be aligned relative to the button.",
                "AlignmentMenu = TypeAlignmentDropdownMenu.Right",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatarDropdown(null)
                {
                    User = "Dex Zogbert",
                    AlignmentMenu = TypeAlignmentDropdownMenu.Default,
                    Color = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                },
                new ControlText() { Text = "Right", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlAvatarDropdown(null)
                {
                    User = "Dex Zogbert",
                    AlignmentMenu = TypeAlignmentDropdownMenu.Right,
                    Color = new PropertyColorButton(TypeColorButton.Primary),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                }
            );

            Stage.AddItem
            (
                typeof(ControlDropdownItemLink),
                "ControlDropdownItemLink",
                "This item is displayed inside the avatar dropdown menu and represents a selectable link that triggers a navigation or action.",
                "new ControlDropdownItemLink()",
                new ControlAvatarDropdown(null)
                {
                    User = "Dex Zogbert"
                }
                    .Add(new ControlDropdownItemLink() { Text = "Log out", Icon = new IconPowerOff() })
            );

            Stage.AddItem
            (
                typeof(ControlDropdownItemHeader),
                "ControlDropdownItemHeader",
                "This item is displayed inside the avatar dropdown menu and serves as a non-interactive header used to group related actions.",
                "new ControlDropdownItemHeader()",
                 new ControlAvatarDropdown(null)
                 {
                     User = "Dex Zogbert"
                 }
                    .Add(new ControlDropdownItemHeader() { Text = "Header" })
            );

            Stage.AddItem
            (
                typeof(ControlDropdownItemDivider),
                "ControlDropdownItemDivider",
                "This item is displayed inside the dropdown menu and is used as a visual divider to separate groups of related actions.",
                "new ControlDropdownItemDivider()",
                new ControlAvatarDropdown(null)
                {
                    User = "Dex Zogbert"
                }
                    .Add(new ControlDropdownItemDivider() { })
            );
        }
    }
}
