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
    /// Represents the steps control demo page for the tutorial.
    /// </summary>
    [Title("Steps")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Steps : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Steps(IPageContext pageContext)
        {
            Stage.Description = @"The `Steps` control shows the progress through a sequence of steps as a numbered, connected indicator. Each step is pending, active or completed; a completed step shows a check instead of its number. It pairs naturally with a multi-page form or wizard.";

            Stage.Controls =
            [
                new ControlSteps
                (
                    null,
                    new ControlStepsItem() { Label = _ => "Account", State = _ => TypeStepState.Completed },
                    new ControlStepsItem() { Label = _ => "Profile", State = _ => TypeStepState.Active },
                    new ControlStepsItem() { Label = _ => "Confirm", State = _ => TypeStepState.Pending }
                )
            ];

            Stage.Code = @"
            new ControlSteps
            (
                null,
                new ControlStepsItem() { Label = _ => ""Account"", State = _ => TypeStepState.Completed },
                new ControlStepsItem() { Label = _ => ""Profile"", State = _ => TypeStepState.Active },
                new ControlStepsItem() { Label = _ => ""Confirm"", State = _ => TypeStepState.Pending }
            );";

            Stage.AddProperty
            (
                "Description",
                "Adds a secondary text below the label of a step.",
                "Description = _ => \"Enter your details\"",
                new ControlSteps
                (
                    null,
                    new ControlStepsItem() { Label = _ => "Account", Description = _ => "Done", State = _ => TypeStepState.Completed },
                    new ControlStepsItem() { Label = _ => "Profile", Description = _ => "In progress", State = _ => TypeStepState.Active },
                    new ControlStepsItem() { Label = _ => "Confirm", Description = _ => "Pending", State = _ => TypeStepState.Pending }
                )
            );

            Stage.AddProperty
            (
                "Vertical",
                "Stacks the steps vertically instead of in a row.",
                "Vertical = _ => true",
                new ControlSteps
                (
                    null,
                    new ControlStepsItem() { Label = _ => "Account", State = _ => TypeStepState.Completed },
                    new ControlStepsItem() { Label = _ => "Profile", State = _ => TypeStepState.Active },
                    new ControlStepsItem() { Label = _ => "Confirm", State = _ => TypeStepState.Pending }
                )
                {
                    Vertical = _ => true
                }
            );
        }
    }
}
