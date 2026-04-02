using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the pagination control for the tutorial.    
    /// </summary>    
    [Title("Pagination")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Pagination : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Pagination(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_PAGE_EVENT, Event.CLICK_EVENT);

            Stage.Description = @"The `Pagination` control provides a structured and intuitive way to navigate through large data sets by dividing content into discrete pages. It offers clear navigation elements that help users move forward, backward, or jump to specific pages, making it ideal for list views, search results, or any scenario involving paged data.";

            Stage.Control = new ControlPagination(RandomId.Create())
            {
            };

            Stage.Code = @"
            new ControlPagination(RandomId.Create())";

            Stage.AddProperty
            (
                "Page",
                "The `Page` property defines the number of items to skip before the first page is displayed. It is typically used to control the starting position within a paged data set, enabling precise navigation and flexible pagination behavior\r\n",
                "PageOffset = 2",
                new ControlPagination()
                {
                    Page = 2
                }
            );

            Stage.AddProperty
            (
                "Total",
                "The `Total` property defines the total number of pages available within the pagination component. It determines how many discrete page steps the user can navigate through when browsing a paged data set.\r\n",
                @"PageCount = 5",
                new ControlPagination()
                {
                    Total = 5,
                }
            );

            Stage.AddProperty
            (
                "Size",
                "The `Size` property defines the visual scale of the pagination component. It adjusts the overall dimensions of the pagination controls, allowing the component to appear in a default, small, or large variant depending on the layout and design requirements.\r\n",
                @"Size = TypeSizePagination.Small",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPagination()
                {
                    Size = TypeSizePagination.Default,
                },
                new ControlText() { Text = "Small", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPagination()
                {
                    Size = TypeSizePagination.Small,
                },
                new ControlText() { Text = "Large", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPagination()
                {
                    Size = TypeSizePagination.Large,
                }
            );
        }
    }
}
