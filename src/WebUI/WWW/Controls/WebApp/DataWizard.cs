using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the rest wizard control for the tutorial.    
    /// </summary>    
    [WebIcon<IconControlSteps>]
    [Title("DataWizard")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataWizard : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public DataWizard(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Wizard` control is used to collect user input step by step in a structured and validated manner, exchanging all data directly with the server through a REST API. Instead of performing a traditional POST submit as in classic web applications, each step communicates event‑driven with its corresponding endpoint and operates entirely without page reloads. The wizard combines various input elements (such as text fields, dropdowns, and buttons) to provide a guided and consistent user experience. All input is validated on the client side to ensure that only correct and complete data is processed. Transmission, validation, and all CRUD operations (creating, modifying, and updating records) are executed through a defined REST route. Data is sent as a JSON payload, and server responses are evaluated in real time to dynamically update the UI and advance the wizard flow.

A step carries a `Title` and a `Subtitle` for the indicator at the top of the dialog. Naming a `SummarySource` makes the indicator read back the answer of a step in place of its question, so the header states what was decided rather than what was asked; a step already passed can be clicked to return to it. A step that declares a `Uri` is rendered by the server: it is fetched with the answers collected so far, which lets it depend on them, and answering `204 No Content` skips it entirely. `FinishLabel` and `FinishIcon` name what the last button actually does.";

            var games = ViewModel.MonkeyIslandGames
                .Select(x => new ControlFormItemInputSelectionItem(x.Id.ToString())
                {
                    Text = _ => x.Name
                });

            Stage.Control = new ControlDataWizard("myform")
                {
                    // the wording of the button that leaves the wizard on its last step
                    FinishLabel = _ => "Create character",
                    FinishIcon = _ => new IconPlus()
                }
                .DataService<MonkeyIslandCharacter>()
                .Add
                (
                    new ControlDataWizardPage("page_basic")
                    {
                        Title = _ => "Character",
                        Subtitle = _ => "Who is it?",
                        // once the step is answered the indicator shows the name that was
                        // entered in place of the question
                        SummarySource = _ => "Name"
                    }
                        .Add
                        (
                            new ControlFormItemInputText("char_name")
                            {
                                Name = _ => "Name",
                                Placeholder = _ => "Enter character name",
                                Required = _ => true
                            },
                            new ControlFormItemInputText("char_desc")
                            {
                                Name = _ => "Description",
                                Format = _ => TypeEditTextFormat.Multiline,
                                Placeholder = _ => "Brief character description"
                            }
                        ),
                    new ControlDataWizardPage("page_appearsin")
                    {
                        Title = _ => "Appearances",
                        Subtitle = _ => "Which games?"
                    }
                        .Add(
                            new ControlFormItemInputSelection("appearsin")
                            {
                                Name = _ => "AppearsIn",
                                Placeholder = _ => "Select games",
                                MultiSelect = _ => true
                            }
                                .Add(games)
                        ),
                    new ControlDataWizardPage("page_icon")
                    {
                        Title = _ => "Portrait",
                        Subtitle = _ => "How does it look?"
                    }
                        .Add
                        (
                            new ControlFormItemInputAvatar("char_avatar")
                            {
                                Name = _ => "Icon"
                                // additional avatar config may be set here (Shape, Uri, etc.)
                            }
                        )
                );

            Stage.Code = @"
            new ControlDataWizard(""myform"")
            {
                FinishLabel = _ => ""Create character"",
                FinishIcon = _ => new IconPlus()
            }
                .DataService<MonkeyIslandCharacter>()
                .Add
                (
                    new ControlDataWizardPage(""page_basic"")
                    {
                        Title = _ => ""Character"",
                        Subtitle = _ => ""Who is it?"",
                        SummarySource = _ => ""Name""
                    }
                        .Add(/* ... */),

                    // a step with a Uri is fetched from the server with the answers
                    // collected so far, and skipped when the server replies 204
                    new ControlDataWizardPage(""page_details"")
                    {
                        Title = _ => ""Details"",
                        Uri = _ => new UriEndpoint(""/api/1/wizard/details"")
                    }
                );";
        }
    }
}
