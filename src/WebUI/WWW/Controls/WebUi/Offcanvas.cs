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
    /// Represents the offcanvas control demo page for the tutorial.
    /// </summary>
    [Title("Offcanvas")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Offcanvas : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Offcanvas(IPageContext pageContext)
        {
            Stage.Description = @"The `Offcanvas` control is a drawer panel that slides in from an edge of the viewport. The panel only emits its own markup; it is opened by any element carrying `data-bs-toggle=""offcanvas""` and `data-bs-target=""#{id}""`, wired by the Bootstrap data API, and closed by its built-in close button.";

            Stage.Controls =
            [
                new ControlHtml()
                {
                    Html = _ => @"<button class=""btn btn-primary"" type=""button"" data-bs-toggle=""offcanvas"" data-bs-target=""#tutorialOffcanvas"">Open offcanvas</button>"
                },
                new ControlOffcanvas("tutorialOffcanvas", new ControlText() { Text = _ => "The offcanvas body holds any controls you like." })
                {
                    Title = _ => "Offcanvas"
                }
            ];

            Stage.Code = @"
            new ControlHtml()
            {
                Html = _ => @""<button class=""""btn btn-primary"""" type=""""button"""" data-bs-toggle=""""offcanvas"""" data-bs-target=""""#tutorialOffcanvas"""">Open offcanvas</button>""
            },
            new ControlOffcanvas(""tutorialOffcanvas"", new ControlText() { Text = _ => ""..."" })
            {
                Title = _ => ""Offcanvas""
            };";

            Stage.AddProperty
            (
                "Placement",
                "Sets the edge the panel slides in from (start, end, top or bottom).",
                "Placement = _ => TypeOffcanvasPlacement.End",
                new ControlHtml()
                {
                    Html = _ => @"<button class=""btn btn-primary"" type=""button"" data-bs-toggle=""offcanvas"" data-bs-target=""#tutorialOffcanvasEnd"">Open from the end</button>"
                },
                new ControlOffcanvas("tutorialOffcanvasEnd", new ControlText() { Text = _ => "This panel slides in from the end." })
                {
                    Title = _ => "End",
                    Placement = _ => TypeOffcanvasPlacement.End
                }
            );
        }
    }
}
