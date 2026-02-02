using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the tutorial page that demonstrates a REST-backed dropdown 
    /// control with search and grouping.
    /// </summary>
    [Title("RestDropdown")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestDropDown : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the table control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestDropDown(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register relevant ui events
            Stage.AddEvent(Event.DATA_ARRIVED_EVENT, Event.DATA_REQUESTED_EVENT, Event.CLICK_EVENT, Event.CHANGE_VISIBILITY_EVENT);

            // describe the control in the tutorial
            Stage.Description = @"A REST-backed dropdown that retrieves entries from an API, displays a search field initially, shows up to 25 entries, and divides the results into the groups ""preferences"", ""primary"", and ""secondary"". Grouping is based on the ""category"" field in the API response. Optionally, filtering can be performed locally or server-side.";

            // default (light) sample
            Stage.Controls =
            [
                new ControlRestDropdown("inventoryDropdown")
                {
                    Text = "Inventory",
                    RestUri = sitemapManager.GetUri<MonkeyIslandInventoriesDropdown>(pageContext.ApplicationContext)
                }
                    .Add(new ControlDropdownItemLink()
                    {
                        Text = "Add Item",
                        Icon = new IconPlus()
                    })
            ];

            // dark sample
            Stage.DarkControls =
            [
                new ControlRestDropdown("darkInventoryDropdown")
                {
                    Text = "Inventory",
                    RestUri = sitemapManager.GetUri<MonkeyIslandInventoriesDropdown>(pageContext.ApplicationContext)
                }
            ];

            // code sample
            Stage.Code = @"
            new ControlRestDropdown(""inventoryDropdown"")
            {
                Text = ""Inventory"",
                RestUri = sitemapManager.GetUri<MonkeyIslandInventory>(pageContext.ApplicationContext)
            }
                .Add(new ControlDropdownItemLink()
                {
                    Text = ""Add Item"",
                    Icon = new IconPlus()
                });";

            // properties: Api
            Stage.AddProperty
            (
                "RestUri",
                "The REST endpoint from which the entries are loaded.",
                "RestUri = sitemapManager.GetUri<MonkeyIslandInventory>(pageContext.ApplicationContext)",
                new ControlRestDropdown("p_api")
                {
                    Text = "Inventory",
                    RestUri = sitemapManager.GetUri<MonkeyIslandInventoriesDropdown>(pageContext.ApplicationContext)
                }
            );

            // properties: MaxItems
            Stage.AddProperty
            (
                "MaxItems",
                "Maximum number of entries to display (excluding search bar and separators).",
                "MaxItems = 10",
                new ControlRestDropdown("p_maxitems")
                {
                    Text = "Inventory",
                    RestUri = sitemapManager.GetUri<MonkeyIslandInventoriesDropdown>(pageContext.ApplicationContext),
                    MaxItems = 10
                }
            );

            // properties: SearchPlaceholder
            Stage.AddProperty
            (
                "SearchPlaceholder",
                "Placeholder text in the search field.",
                "SearchPlaceholder = \"Search entries...\"",
                new ControlRestDropdown("p_placeholder")
                {
                    Text = "Inventory",
                    RestUri = sitemapManager.GetUri<MonkeyIslandInventoriesDropdown>(pageContext.ApplicationContext),
                    SearchPlaceholder = "Search entries..."
                }
            );
        }
    }
}