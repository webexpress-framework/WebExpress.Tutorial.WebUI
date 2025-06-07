using System;
using System.Collections.Generic;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the search control for the tutorial.    
    /// </summary>    
    [Title("Search")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Search : PageControl
    {
        private readonly IEnumerable<ControlSearchItemSuggestion> _suggestions =
        [
            new ControlSearchItemSuggestion("1") { Label = "Home", Icon = new IconHome(), Favorited = true },
            new ControlSearchItemSuggestion("2") { Label = "Settings", Icon = new IconWrench() },
            new ControlSearchItemSuggestion("3") { Label = "User Profile", Icon = new IconUser() },
            new ControlSearchItemSuggestion("4") { Label = "Help & Support", Icon = new IconInfoCircle() },
            new ControlSearchItemSuggestion("5") { Label = "Messages", Icon = new IconPaperPlane() },
            new ControlSearchItemSuggestion("6") { Label = "Favorites", Icon = new IconStar() },
            new ControlSearchItemSuggestion("7") { Label = "Account Overview" },
            new ControlSearchItemSuggestion("8") { Label = "Privacy Policy", Icon = new IconKey(), Favorited = true},
            new ControlSearchItemSuggestion("9") { Label = "Notifications", Icon = new IconComment() },
            new ControlSearchItemSuggestion("10") { Label = "Log Out", Icon = new IconPowerOff() }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the search control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Search(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_FILTER_EVENT, Event.CHANGE_FAVORITE_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"The `Search` control is an input component where users can enter search commands to find specific information. It serves as an interface between the user and a search function, delivering relevant results based on the entered terms. With features like real-time suggestions, the search field enhances usability and allows for faster navigation.";

            Stage.Control = new ControlSearch(Guid.NewGuid().ToString(), [.. _suggestions])
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
                new ControlSearch(Guid.NewGuid().ToString(), [.. _suggestions])
                {
                    Placeholder = "Enter search term..."
                }
            );

            Stage.AddProperty
            (
                "EnableFavorited",
                "The `EnableFavorited` property allows for the prioritization of preferred search suggestions. When enabled, certain favorites can be highlighted and displayed more prominently within the search suggestions. This feature enhances the user experience by making frequently used or marked-as-relevant suggestions more accessible.",
                "EnableFavorited = true",
                new ControlSearch(Guid.NewGuid().ToString(), [.. _suggestions])
                {
                    EnableFavorited = true
                }
            );

            Stage.AddProperty
            (
                "Value",
                "The `Value` property defines the initial search term used when a search function is initialized. By setting a predefined value, the search field can be populated with a starting term, guiding users and improving search efficiency.\r\n\r\nThis feature is particularly useful when frequently used or preselected terms should be readily available, allowing users to refine their searches more quickly without manually entering the term.",
                @"Value = ""hello""",
                new ControlSearch(Guid.NewGuid().ToString(), [.. _suggestions])
                {
                    Value = "hello"
                }
            );

            Stage.AddItem
            (
                "Suggestion",
                "Suggestions in a `SearchControl` are automatically generated or predefined input aids that offer users relevant search terms or options based on past inputs or data sources. They enhance usability by speeding up searches and reducing typos.",
                "new ControlSearch(null, [new ControlSearchItemSuggestion(\"1\") { Icon = new IconHome(), Label = \"Home\", Favorited = true }])",
                new ControlSearch(Guid.NewGuid().ToString(), [.. _suggestions])
                {
                    Placeholder = "Enter search term..."
                }
            );
        }
    }
}
