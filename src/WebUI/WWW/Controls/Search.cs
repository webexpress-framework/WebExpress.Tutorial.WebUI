using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the search control for the tutorial.    
    /// </summary>    
    [Title("Search")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    public sealed class Search : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the search control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Search(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent("webexpress.webui.change.filter", "Event triggered when a filter changes, typically in search or filter controls.");
            Stage.AddEvent("webexpress.webui.change.favorite", " Event triggered when a favorite changes.");

            Stage.Description = @"The `Search` control is an input component where users can enter search commands to find specific information. It serves as an interface between the user and a search function, delivering relevant results based on the entered terms. With features like real-time suggestions, the search field enhances usability and allows for faster navigation.";

            Stage.Control = new ControlSearch(null, [
                    new ControlSearchItemSuggestion("1") { Label = "Home", Icon = new IconHome() },
                    new ControlSearchItemSuggestion("2") { Label = "Settings" },
                    new ControlSearchItemSuggestion("3") { Label = "User Profile" },
                    new ControlSearchItemSuggestion("4") { Label = "Help & Support" },
                    new ControlSearchItemSuggestion("5") { Label = "Messages" },
                    new ControlSearchItemSuggestion("6") { Label = "Favorites" },
                    new ControlSearchItemSuggestion("7") { Label = "Account Overview" },
                    new ControlSearchItemSuggestion("8") { Label = "Privacy Policy" },
                    new ControlSearchItemSuggestion("9") { Label = "Notifications" },
                    new ControlSearchItemSuggestion("10") { Label = "Log Out" }
                ])
            {
                Placeholder = "Enter search term...",

            };

            Stage.Code = @"
            new ControlSearch()  
            {  
                Placeholder = ""Enter search term...""
            };";

            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field – a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = \"Enter search term...\"",
                new ControlSearch()
                {
                    Placeholder = "Enter search term...",
                }
            );

            Stage.AddItem
            (
                "Suggestion",
                "Suggestions in a `SearchControl` are automatically generated or predefined input aids that offer users relevant search terms or options based on past inputs or data sources. They enhance usability by speeding up searches and reducing typos.",
                "new ControlSearch(null, [new ControlSearchItemSuggestion(\"1\") { Icon = new IconHome(), Label = \"Home\", Favorited = true }])",
                new ControlSearch(null, [
                    new ControlSearchItemSuggestion("1") { Label = "Home", Icon = new IconHome(), Favorited = true },
                    new ControlSearchItemSuggestion("2") { Label = "Settings" },
                    new ControlSearchItemSuggestion("3") { Label = "User Profile" },
                    new ControlSearchItemSuggestion("4") { Label = "Help & Support" },
                    new ControlSearchItemSuggestion("5") { Label = "Messages" },
                    new ControlSearchItemSuggestion("6") { Label = "Favorites" },
                    new ControlSearchItemSuggestion("7") { Label = "Account Overview" },
                    new ControlSearchItemSuggestion("8") { Label = "Privacy Policy" },
                    new ControlSearchItemSuggestion("9") { Label = "Notifications" },
                    new ControlSearchItemSuggestion("10") { Label = "Log Out" }
                ])
                {
                    Placeholder = "Enter search term..."
                }

            );
        }
    }
}
