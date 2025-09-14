using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the search control for the tutorial.    
    /// </summary>    
    [Title("SearchContent")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class SearchContent : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the search control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public SearchContent(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_FILTER_EVENT);

            Stage.Description = @"The `SearchContent` control provides a contextual search interface that allows users to filter or locate specific content within designated areas of a page. By linking to one or more target elements, it enables scoped searching and dynamic content interaction. With support for placeholder text and icon integration, the control enhances usability and guides user input effectively.";

            Stage.Control = new ControlSearchContent()
            {
                Placeholder = "Enter search term...",
                TargetIds = ["wx-content-main"]
            };

            Stage.Code = @"
            new ControlSearchContent()
            {
                Placeholder = ""Enter search term..."",
                TargetIds = [""wx-content-main""]
            };";

            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field – a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = \"Enter search term...\"",
                new ControlSearch()
                {
                    Placeholder = "Enter search term..."
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Sets the icon displayed in the search control. It provides a visual cue for the search functionality.",
                "Icon = new IconStar()",
                new ControlSearchContent()
                {
                    Icon = new IconStar()
                }
            );

            Stage.AddProperty
            (
                "TargetIds",
                "Specifies the IDs of the content elements that the search control should target. Multiple IDs can be defined.",
                "TargetIds = [\"wx-content-main\"]",
                new ControlSearchContent()
                {
                    TargetIds = ["wx-content-main"]
                }
            );

            Stage.AddProperty
            (
                "HighlightColor",
                "Defines the color used to highlight matching search terms in the target content. Accepts any valid CSS color value.",
                "HighlightColor = \"green\"",
                new ControlSearchContent()
                {
                    HighlightColor = "green",
                    TargetIds = ["wx-content-main"]
                }
            );
        }
    }
}
