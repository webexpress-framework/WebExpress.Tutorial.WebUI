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
    /// Represents the popover control demo page for the tutorial.
    /// </summary>
    [Title("Popover")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Popover : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Popover(IPageContext pageContext)
        {
            Stage.Description = @"The `Popover` control reveals a small overlay with a title and a message next to its trigger. The trigger is styled here like a button via the inherited `Classes`. The overlay is wired by the client-side `webexpress.webui.PopoverCtrl`, because Bootstrap does not auto-initialize popovers.";

            Stage.Controls =
            [
                new ControlPopover()
                {
                    Text = _ => "Click me",
                    Title = _ => "Popover title",
                    Message = _ => "And here is some helpful popover content.",
                    Classes = ["btn", "btn-primary"]
                }
            ];

            Stage.Code = @"
            new ControlPopover()
            {
                Text = _ => ""Click me"",
                Title = _ => ""Popover title"",
                Message = _ => ""And here is some helpful popover content."",
                Classes = [""btn"", ""btn-primary""]
            };";

            Stage.AddProperty
            (
                "Placement",
                "Sets the side the popover is shown on (top, right, bottom or left).",
                "Placement = _ => TypePopoverPlacement.Right",
                new ControlPopover()
                {
                    Text = _ => "Top",
                    Message = _ => "Shown above the trigger.",
                    Placement = _ => TypePopoverPlacement.Top,
                    Classes = ["btn", "btn-secondary"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlPopover()
                {
                    Text = _ => "Right",
                    Message = _ => "Shown to the right of the trigger.",
                    Placement = _ => TypePopoverPlacement.Right,
                    Classes = ["btn", "btn-secondary"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlPopover()
                {
                    Text = _ => "Bottom",
                    Message = _ => "Shown below the trigger.",
                    Placement = _ => TypePopoverPlacement.Bottom,
                    Classes = ["btn", "btn-secondary"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Trigger",
                "Sets the interaction that reveals the popover (click, hover or focus).",
                "Trigger = _ => TypePopoverTrigger.Hover",
                new ControlPopover()
                {
                    Text = _ => "Hover me",
                    Title = _ => "On hover",
                    Message = _ => "Revealed while hovering or focusing.",
                    Trigger = _ => TypePopoverTrigger.Hover,
                    Classes = ["btn", "btn-secondary"]
                }
            );
        }
    }
}
