using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the dark-mode button control for the tutorial.
    /// </summary>
    [Title("ButtonDarkmode")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ButtonDarkmode : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ButtonDarkmode()
        {
            Stage.Description = @"The `ControlButtonDarkmode` control renders a button that toggles the dark mode of the page. It sets the `data-bs-theme` attribute on the root HTML element to `dark` or `light` and persists the current mode in a cookie so that the state survives a reload. The button is auto-initialized by the `webexpress.webui.darkmode` JavaScript module via the `wx-webui-darkmode` marker class.";

            Stage.Controls = [
                new ControlButtonDarkmode()
                {
                    Title = "Toggle dark mode"
                }
            ];

            Stage.Code = @"
            new ControlButtonDarkmode()
            {
                Title = ""Toggle dark mode""
            };";

            Stage.AddProperty
            (
                "IconLight",
                "Specifies the icon shown while the light mode is active.",
                "IconLight = new IconMoon()",
                new ControlButtonDarkmode()
                {
                    IconLight = new IconMoon()
                }
            );

            Stage.AddProperty
            (
                "IconDark",
                "Specifies the icon shown while the dark mode is active.",
                "IconDark = new IconSun()",
                new ControlButtonDarkmode()
                {
                    IconDark = new IconSun()
                }
            );

            Stage.AddProperty
            (
                "Title",
                "Sets the tooltip shown on hover.",
                "Title = \"Toggle dark mode\"",
                new ControlButtonDarkmode()
                {
                    Title = "Toggle dark mode"
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = TypeSizeButton.Small",
                new ControlButtonDarkmode()
                {
                    Size = TypeSizeButton.Small,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlButtonDarkmode()
                {
                    Size = TypeSizeButton.Default,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlButtonDarkmode()
                {
                    Size = TypeSizeButton.Large,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );
        }
    }
}
