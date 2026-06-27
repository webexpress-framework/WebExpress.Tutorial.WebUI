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
    /// Represents the description list control demo page for the tutorial.
    /// </summary>
    [Title("DescriptionList")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class DescriptionList : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public DescriptionList(IPageContext pageContext)
        {
            Stage.Description = @"The `DescriptionList` control presents a set of term/description pairs as a definition list, for an object's properties or a key/value summary. The terms sit above their descriptions, or beside them in the horizontal layout.";

            Stage.Controls =
            [
                new ControlDescriptionList
                (
                    null,
                    new ControlDescriptionListItem() { Term = _ => "Name", Description = _ => "Guybrush Threepwood" },
                    new ControlDescriptionListItem() { Term = _ => "Role", Description = _ => "Mighty Pirate" },
                    new ControlDescriptionListItem() { Term = _ => "Status", Description = _ => "Looking for the secret of Monkey Island" }
                )
            ];

            Stage.Code = @"
            new ControlDescriptionList
            (
                null,
                new ControlDescriptionListItem() { Term = _ => ""Name"", Description = _ => ""Guybrush Threepwood"" },
                new ControlDescriptionListItem() { Term = _ => ""Role"", Description = _ => ""Mighty Pirate"" }
            );";

            Stage.AddProperty
            (
                "Horizontal",
                "Places the terms beside their descriptions instead of above them.",
                "Horizontal = _ => true",
                new ControlDescriptionList
                (
                    null,
                    new ControlDescriptionListItem() { Term = _ => "Name", Description = _ => "Guybrush Threepwood" },
                    new ControlDescriptionListItem() { Term = _ => "Role", Description = _ => "Mighty Pirate" },
                    new ControlDescriptionListItem() { Term = _ => "Status", Description = _ => "Looking for the secret of Monkey Island" }
                )
                {
                    Horizontal = _ => true
                }
            );
        }
    }
}
