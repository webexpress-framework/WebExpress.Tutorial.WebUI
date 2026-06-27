using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the spinner control demo page for the tutorial.
    /// </summary>
    [Title("Spinner")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Spinner : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Spinner(IPageContext pageContext)
        {
            Stage.Description = @"The `Spinner` control shows a lightweight loading indicator while an operation is in progress. It comes in a rotating border and a growing variant, supports a small size, and takes its color from the inherited `TextColor`, exactly like a Bootstrap spinner.";

            Stage.Controls =
            [
                new ControlSpinner(),
                new ControlSpinner()
                {
                    Type = _ => TypeSpinner.Grow,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            ];

            Stage.Code = @"
            new ControlSpinner();";

            Stage.AddProperty
            (
                "Type",
                "Switches between the rotating border and the growing variant.",
                "Type = _ => TypeSpinner.Grow",
                new ControlSpinner() { Type = _ => TypeSpinner.Border },
                new ControlSpinner() { Type = _ => TypeSpinner.Grow }
            );

            Stage.AddProperty
            (
                "Small",
                "Renders the compact, small-size spinner.",
                "Small = _ => true",
                new ControlSpinner() { Small = _ => true },
                new ControlSpinner() { Type = _ => TypeSpinner.Grow, Small = _ => true }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Colors the spinner using the inherited text color.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlSpinner() { TextColor = _ => new PropertyColorText(TypeColorText.Primary) },
                new ControlSpinner() { TextColor = _ => new PropertyColorText(TypeColorText.Success) },
                new ControlSpinner() { TextColor = _ => new PropertyColorText(TypeColorText.Danger) }
            );
        }
    }
}
