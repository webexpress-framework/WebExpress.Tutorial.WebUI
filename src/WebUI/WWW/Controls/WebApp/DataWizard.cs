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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the rest wizard control for the tutorial.    
    /// </summary>    
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
            Stage.Description = @"The `Wizard` control is used to collect user input step by step in a structured and validated manner, exchanging all data directly with the server through a REST API. Instead of performing a traditional POST submit as in classic web applications, each step communicates event‑driven with its corresponding endpoint and operates entirely without page reloads. The wizard combines various input elements (such as text fields, dropdowns, and buttons) to provide a guided and consistent user experience. All input is validated on the client side to ensure that only correct and complete data is processed. Transmission, validation, and all CRUD operations (creating, modifying, and updating records) are executed through a defined REST route. Data is sent as a JSON payload, and server responses are evaluated in real time to dynamically update the UI and advance the wizard flow.";

            var games = ViewModel.MonkeyIslandGames
                .Select(x => new ControlFormItemInputSelectionItem(x.Id.ToString())
                {
                    Text = _ => x.Name
                });

            Stage.Control = new ControlDataWizard("myform")
                .DataService<MonkeyIslandCharacter>()
                .Add
                (
                    new ControlDataWizardPage("page_basic")
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
                .DataService<MonkeyIslandCharacter>()";
        }
    }
}
