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

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the tutorial page that demonstrates a REST-backed dropdown control with search and grouping.
    /// </summary>
    [Title("RestSelection")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestSelection : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the table control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestSelection(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register relevant ui events
            Stage.AddEvent(Event.DATA_ARRIVED_EVENT, Event.DATA_REQUESTED_EVENT, Event.CHANGE_VALUE_EVENT, Event.CHANGE_FILTER_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            // describe the control in the tutorial
            Stage.Description = @"A `Selection` control with a REST backend dynamically loads its options from a configurable API endpoint and supports search and paging parameters. When the dropdown opens, it fetches data based on the current search term; a loading indicator is displayed while the request is in progress. After a successful fetch, the options are available for multi-select.";

            // default (light) sample
            Stage.Control = new ControlForm()
                .Add
                (
                    new ControlRestFormItemInputSelection("lightSelection")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(pageContext.ApplicationContext)
                    }
                );

            // dark sample
            Stage.DarkControls =
            [
                new ControlForm(null)
                .Add
                (
                    new ControlRestFormItemInputSelection("darkSelection")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(pageContext.ApplicationContext)
                    }
                )
            ];

            Stage.Code = @"
            new ControlForm()
                .Add
                (
                    new ControlRestFormItemInputSelection(""lightSelection"")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInventory>(pageContext.ApplicationContext)
                    }
                );";

            Stage.AddProperty
            (
                "Multiselect",
                "The multiselect property is used in a Selection Control to allow users to choose multiple options from a list. By enabling this property, the control is configured to support flexible multi-selection rather than limiting users to a single choice.",
                "MultiSelect = true",
                new ControlForm(null, new ControlRestFormItemInputSelection()
                {
                    MultiSelect = true,
                    RestUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(pageContext.ApplicationContext)
                })
            );

            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field, a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = \"Placeholder\"",
                new ControlForm(null, new ControlRestFormItemInputSelection()
                {
                    Placeholder = "Placeholder",
                    RestUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(pageContext.ApplicationContext)
                })
            );

            Stage.AddProperty
            (
                "MaxItems",
                "Maximum number of entries to display.",
                "MaxItems = 10",
                 new ControlForm(null, new ControlRestFormItemInputSelection()
                 {
                     MaxItems = 10,
                     RestUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(pageContext.ApplicationContext)
                 })
            );
        }
    }
}