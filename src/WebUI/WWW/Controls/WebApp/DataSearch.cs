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
    /// Represents the tutorial page that demonstrates a search box whose suggestions are
    /// served by a REST endpoint. Hosts a <see cref="ControlDataSearch"/> connected to the
    /// <see cref="MonkeyIslandSearchSuggestions"/> endpoint, which answers with the crew
    /// members matching the typed term - each one linking to its own page.
    /// </summary>
    [Title("DataSearch")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataSearch : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the search control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataSearch(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register relevant ui events
            Stage.AddEvent(Event.DATA_REQUESTED_EVENT, Event.DATA_ARRIVED_EVENT, Event.CHANGE_FILTER_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            // describe the control in the tutorial
            Stage.Description = @"`ControlDataSearch` is the data bound counterpart of `ControlSearch`: the box, the icon and the dropdown are inherited, but the suggestions come from a REST endpoint instead of from static markup. The menu opens on focus - with an empty term the endpoint decides what to offer, here a ""Crew"" caption above the whole cast - and every keystroke queries it again, debounced, so a typed word costs one request rather than one per letter. Each suggestion is a link to its target, so a click opens that page directly; the arrow keys walk the menu and enter opens the highlighted entry. With nothing highlighted, enter submits the term to the page declared through `SubmitUri`. A slow answer that arrives after a later keystroke is dropped rather than painted over the newer term, and a failing endpoint leaves the empty text rather than stale hits. The client side is `webexpress.webapp.SearchSuggestionCtrl`, and the endpoint speaks the dropdown contract (`RestApiDropdown<T>`): the term in `q`, the entry cap in `l`, an items envelope back.";

            // default (light) sample
            Stage.Controls =
            [
                new ControlDataSearch("crewSearch")
                {
                    Placeholder = _ => "Search the crew...",
                    EmptyText = _ => "No crew member found."
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            ];

            // dark sample
            Stage.DarkControls =
            [
                new ControlDataSearch("darkCrewSearch")
                {
                    Placeholder = _ => "Search the crew...",
                    EmptyText = _ => "No crew member found."
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            ];

            // code sample
            Stage.Code = @"
            new ControlDataSearch(""crewSearch"")
            {
                Placeholder = _ => ""Search the crew..."",
                EmptyText = _ => ""No crew member found.""
            }
                .DataService<MonkeyIslandSearchSuggestions>()";

            // properties: DataService
            Stage.AddProperty
            (
                "DataService",
                "The data service whose endpoint delivers the suggestions. It receives the term in the query parameter `q` and the entry cap in `l`, and answers with an items envelope - the contract `RestApiDropdown<T>` already produces.",
                ".DataService<MonkeyIslandSearchSuggestions>()",
                new ControlDataSearch("p_service")
                {
                    Placeholder = _ => "Search the crew..."
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );

            // properties: MaxItems
            Stage.AddProperty
            (
                "MaxItems",
                "The largest number of selectable suggestions to render (default 10). Headers and dividers are structural and do not count against it, so a capped menu keeps its captions.",
                "MaxItems = _ => 3",
                new ControlDataSearch("p_maxitems")
                {
                    Placeholder = _ => "Search the crew...",
                    MaxItems = _ => 3
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );

            // properties: EmptyText
            Stage.AddProperty
            (
                "EmptyText",
                "The text shown in place of the suggestions when the term matches nothing. Type a name no pirate carries to see it.",
                "EmptyText = _ => \"No crew member found.\"",
                new ControlDataSearch("p_emptytext")
                {
                    Placeholder = _ => "Search the crew...",
                    EmptyText = _ => "No crew member found."
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );

            // properties: QueryParameter
            Stage.AddProperty
            (
                "QueryParameter",
                "The name of the query parameter the term is sent in (default `q`). A different name travels in addition to `q`, so an endpoint that reads only the convention still receives the term.",
                "QueryParameter = _ => \"term\"",
                new ControlDataSearch("p_queryparam")
                {
                    Placeholder = _ => "Search the crew...",
                    QueryParameter = _ => "term"
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );

            // properties: SubmitUri
            Stage.AddProperty
            (
                "SubmitUri",
                "The page the term is submitted to when enter is pressed with no suggestion highlighted. Without it, enter only opens a highlighted suggestion.",
                "SubmitUri = _ => sitemapManager.GetUri<Index>(pageContext.ApplicationContext)",
                new ControlDataSearch("p_submituri")
                {
                    Placeholder = _ => "Type and press enter...",
                    SubmitUri = _ => sitemapManager.GetUri<Index>(pageContext.ApplicationContext)
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );

            // properties: Placeholder
            Stage.AddProperty
            (
                "Placeholder",
                "The hint shown in the empty box. Inherited from `ControlSearch`.",
                "Placeholder = _ => \"Search the crew...\"",
                new ControlDataSearch("p_placeholder")
                {
                    Placeholder = _ => "Search the crew..."
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );

            // properties: Footer
            Stage.AddProperty
            (
                "Footer",
                "A control rendered below the suggestions. It is inherited from `ControlSearch` and stays visible even when the endpoint returned nothing, which makes it the place for a way out of the menu.",
                "Footer = new ControlText() { Text = _ => \"Press enter for the full search\" }",
                new ControlDataSearch("p_footer")
                {
                    Placeholder = _ => "Search the crew...",
                    Footer = new ControlText()
                    {
                        Text = _ => "Press enter for the full search",
                        TextColor = _ => new PropertyColorText(TypeColorText.Secondary)
                    }
                }
                    .DataService<MonkeyIslandSearchSuggestions>()
            );
        }
    }
}
