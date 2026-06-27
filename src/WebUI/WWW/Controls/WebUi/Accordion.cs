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
    /// Represents the accordion control demo page for the tutorial.
    /// </summary>
    [Title("Accordion")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Accordion : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Accordion(IPageContext pageContext)
        {
            Stage.Description = @"The `Accordion` control stacks a set of collapsible sections. By default only one section is open at a time; opening another closes the previous one. The whole behavior is driven by the Bootstrap collapse data API.";

            Stage.Controls =
            [
                new ControlAccordion
                (
                    "tutorialAccordion",
                    new ControlAccordionItem("tutorialAccordion-1", new ControlText() { Text = _ => "The first section is open on load." })
                    {
                        Header = _ => "First section",
                        Expanded = _ => true
                    },
                    new ControlAccordionItem("tutorialAccordion-2", new ControlText() { Text = _ => "Opening this section collapses the first one." })
                    {
                        Header = _ => "Second section"
                    },
                    new ControlAccordionItem("tutorialAccordion-3", new ControlText() { Text = _ => "Only one section stays open at a time." })
                    {
                        Header = _ => "Third section"
                    }
                )
            ];

            Stage.Code = @"
            new ControlAccordion
            (
                ""tutorialAccordion"",
                new ControlAccordionItem(""tutorialAccordion-1"", new ControlText() { Text = _ => ""..."" })
                {
                    Header = _ => ""First section"",
                    Expanded = _ => true
                },
                new ControlAccordionItem(""tutorialAccordion-2"", new ControlText() { Text = _ => ""..."" })
                {
                    Header = _ => ""Second section""
                }
            );";

            Stage.AddProperty
            (
                "Flush",
                "Removes the outer borders and rounded corners so the accordion blends into its parent.",
                "Flush = _ => true",
                new ControlAccordion
                (
                    "tutorialAccordionFlush",
                    new ControlAccordionItem("tutorialAccordionFlush-1", new ControlText() { Text = _ => "A flush section." })
                    {
                        Header = _ => "First section"
                    },
                    new ControlAccordionItem("tutorialAccordionFlush-2", new ControlText() { Text = _ => "Another flush section." })
                    {
                        Header = _ => "Second section"
                    }
                )
                {
                    Flush = _ => true
                }
            );

            Stage.AddProperty
            (
                "AlwaysOpen",
                "Lets more than one section stay open at the same time.",
                "AlwaysOpen = _ => true",
                new ControlAccordion
                (
                    "tutorialAccordionOpen",
                    new ControlAccordionItem("tutorialAccordionOpen-1", new ControlText() { Text = _ => "This section stays open ..." })
                    {
                        Header = _ => "First section",
                        Expanded = _ => true
                    },
                    new ControlAccordionItem("tutorialAccordionOpen-2", new ControlText() { Text = _ => "... while this one is open too." })
                    {
                        Header = _ => "Second section",
                        Expanded = _ => true
                    }
                )
                {
                    AlwaysOpen = _ => true
                }
            );
        }
    }
}
