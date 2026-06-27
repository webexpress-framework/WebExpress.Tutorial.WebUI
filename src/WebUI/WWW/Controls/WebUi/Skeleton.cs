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
    /// Represents the skeleton control demo page for the tutorial.
    /// </summary>
    [Title("Skeleton")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Skeleton : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Skeleton(IPageContext pageContext)
        {
            Stage.Description = @"The `Skeleton` control is a shimmering placeholder shown in place of content that has not loaded yet. It comes as one or more text lines, a circle (for an avatar) or a rectangle (for an image or a card).";

            Stage.Controls =
            [
                new ControlSkeleton()
            ];

            Stage.Code = @"
            new ControlSkeleton();";

            Stage.AddProperty
            (
                "Type",
                "Selects the placeholder shape: text lines, a circle or a rectangle.",
                "Type = _ => TypeSkeleton.Circle",
                new ControlSkeleton() { Type = _ => TypeSkeleton.Circle },
                new ControlSkeleton()
                {
                    Type = _ => TypeSkeleton.Rectangle,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );

            Stage.AddProperty
            (
                "Lines",
                "Sets the number of lines rendered for the text shape.",
                "Lines = _ => 4",
                new ControlSkeleton() { Lines = _ => 4 }
            );

            Stage.AddProperty
            (
                "Animated",
                "Turns the shimmer animation on or off.",
                "Animated = _ => false",
                new ControlSkeleton() { Animated = _ => false }
            );
        }
    }
}
