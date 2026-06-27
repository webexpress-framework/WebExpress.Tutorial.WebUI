using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the empty-state control demo page for the tutorial.
    /// </summary>
    [Title("EmptyState")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class EmptyState : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public EmptyState(IPageContext pageContext)
        {
            Stage.Description = @"The `EmptyState` control is a centered placeholder shown when there is nothing to display: an icon, a title and a message, with optional call-to-action controls below.";

            Stage.Controls =
            [
                new ControlEmptyState
                (
                    null,
                    new ControlButton()
                    {
                        Text = _ => "Add the first item",
                        Icon = _ => new IconPlus(),
                        BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                    }
                )
                {
                    Icon = _ => new IconInbox(),
                    Title = _ => "Nothing here yet",
                    Message = _ => "Your inventory is empty. Add an item to get started."
                }
            ];

            Stage.Code = @"
            new ControlEmptyState
            (
                null,
                new ControlButton()
                {
                    Text = _ => ""Add the first item"",
                    Icon = _ => new IconPlus(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                }
            )
            {
                Icon = _ => new IconInbox(),
                Title = _ => ""Nothing here yet"",
                Message = _ => ""Your inventory is empty. Add an item to get started.""
            };";

            Stage.AddProperty
            (
                "Without an action",
                "The icon, title and message work on their own; the call-to-action is optional.",
                "new ControlEmptyState() { Icon = _ => new IconMagnifyingGlass(), Title = _ => \"No results\" }",
                new ControlEmptyState()
                {
                    Icon = _ => new IconMagnifyingGlass(),
                    Title = _ => "No results",
                    Message = _ => "No characters match your search."
                }
            );
        }
    }
}
