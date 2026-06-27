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
    /// Represents the tooltip control demo page for the tutorial.
    /// </summary>
    [Title("Tooltip")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Tooltip : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Tooltip(IPageContext pageContext)
        {
            Stage.Description = @"The `Tooltip` control shows a short text next to its trigger on hover or focus. The trigger is styled here like a button via the inherited `Classes`. The tooltip is wired by the client-side `webexpress.webui.TooltipCtrl`, because Bootstrap does not auto-initialize tooltips.";

            Stage.Controls =
            [
                new ControlTooltip()
                {
                    Text = _ => "Hover me",
                    Title = _ => "This is a tooltip",
                    Classes = ["btn", "btn-secondary"]
                }
            ];

            Stage.Code = @"
            new ControlTooltip()
            {
                Text = _ => ""Hover me"",
                Title = _ => ""This is a tooltip"",
                Classes = [""btn"", ""btn-secondary""]
            };";

            Stage.AddProperty
            (
                "Placement",
                "Sets the side the tooltip is shown on (top, right, bottom or left).",
                "Placement = _ => TypeTooltipPlacement.Right",
                new ControlTooltip()
                {
                    Text = _ => "Top",
                    Title = _ => "Shown above",
                    Placement = _ => TypeTooltipPlacement.Top,
                    Classes = ["btn", "btn-secondary"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlTooltip()
                {
                    Text = _ => "Right",
                    Title = _ => "Shown to the right",
                    Placement = _ => TypeTooltipPlacement.Right,
                    Classes = ["btn", "btn-secondary"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlTooltip()
                {
                    Text = _ => "Bottom",
                    Title = _ => "Shown below",
                    Placement = _ => TypeTooltipPlacement.Bottom,
                    Classes = ["btn", "btn-secondary"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );
        }
    }
}
