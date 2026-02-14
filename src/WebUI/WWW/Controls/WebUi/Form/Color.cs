using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
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
        /// <param name="pageContext">The context of the page on which the check control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Color(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description =
            @"A `Color` control allows users to select a color value. It displays a visual color swatch and provides an intuitive way to choose or modify color information.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputColor { Color = "#a1b2c3" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputColor { Color = ""#a1b2c3"" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the color value displayed and selected by the user. It updates the visual swatch and ensures consistent representation of the chosen color. Only 6‑digit hexadecimal values (`#RRGGBB`) are supported.",
                "Color = \"#a1b2c3\"",
                new ControlForm(null, new ControlFormItemInputColor(null)
                {
                    Color = "#a1b2c3"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides additional guidance or context for the color field, helping users understand its purpose or usage.",
                "Help = \"Choose your preferred highlight color.\"",
                new ControlForm(null, new ControlFormItemInputColor(null)
                {
                    Help = "Choose your preferred highlight color."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines an icon displayed next to the color field, offering visual support and improving recognizability.",
                "Icon = new IconPalette()",
                new ControlForm(null, new ControlFormItemInputColor(null)
                {
                    Icon = new IconPalette()
                })
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property makes the color field non-interactive and visually muted, indicating that the color cannot be changed.",
                @"Disabled = true",
                new ControlForm()
                    .Add(new ControlFormItemInputColor
                    {
                        Label = "Theme color",
                        Icon = new IconPalette(),
                        Help = "This setting is currently locked.",
                        Disabled = true
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
