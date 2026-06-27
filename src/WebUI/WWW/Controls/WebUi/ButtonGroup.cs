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
    /// Represents the button group control demo page for the tutorial.
    /// </summary>
    [Title("ButtonGroup")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ButtonGroup : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public ButtonGroup(IPageContext pageContext)
        {
            Stage.Description = @"The `ButtonGroup` control bundles a set of buttons into a single, segmented control. The buttons sit flush against each other and can be laid out horizontally or stacked vertically.";

            Stage.Controls =
            [
                new ControlButtonGroup
                (
                    null,
                    new ControlButton() { Text = _ => "Left" },
                    new ControlButton() { Text = _ => "Middle" },
                    new ControlButton() { Text = _ => "Right" }
                )
            ];

            Stage.Code = @"
            new ControlButtonGroup
            (
                null,
                new ControlButton() { Text = _ => ""Left"" },
                new ControlButton() { Text = _ => ""Middle"" },
                new ControlButton() { Text = _ => ""Right"" }
            );";

            Stage.AddProperty
            (
                "Vertical",
                "Stacks the buttons vertically instead of in a row.",
                "Vertical = _ => true",
                new ControlButtonGroup
                (
                    null,
                    new ControlButton() { Text = _ => "Top" },
                    new ControlButton() { Text = _ => "Middle" },
                    new ControlButton() { Text = _ => "Bottom" }
                )
                {
                    Vertical = _ => true
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Sets the size of the group.",
                "Size = _ => TypeSizeButton.Small",
                new ControlButtonGroup
                (
                    null,
                    new ControlButton() { Text = _ => "Small" },
                    new ControlButton() { Text = _ => "Group" }
                )
                {
                    Size = _ => TypeSizeButton.Small
                },
                new ControlButtonGroup
                (
                    null,
                    new ControlButton() { Text = _ => "Large" },
                    new ControlButton() { Text = _ => "Group" }
                )
                {
                    Size = _ => TypeSizeButton.Large
                }
            );
        }
    }
}
