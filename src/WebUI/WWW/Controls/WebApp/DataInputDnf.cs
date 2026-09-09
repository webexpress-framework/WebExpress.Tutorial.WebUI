using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the tutorial page that demonstrates a REST-backed disjunctive
    /// normal form control.
    /// </summary>
    [WebIcon<IconControlDnf>]
    [Title("DataInputDnf")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataInputDnf : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DataInputDnf()
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.ADD_EVENT, Event.REMOVE_EVENT, Event.DATA_ARRIVED_EVENT, Event.DATA_REQUESTED_EVENT);

            Stage.Description = @"A `DataInputDnf` control builds a filter as a **disjunctive normal form** - `(A AND B) OR (C)` - whose selectable terms come from a REST endpoint instead of the page.

The structure is the one of the static `Dnf` control; what the REST variant replaces is where the terms come from. Every conjunction is a REST backed `Selection` of its own, so each one loads lazily when its picker is opened and searches server side with a debounced request. Keeping one picker per conjunction is what lets two conjunctions be searched independently - filtering the first row must not rewrite the list of the second.

A conjunction added later starts from the terms already received rather than empty, so its list is on screen before its own request returns.";

            Stage.Control = new ControlForm()
                .Add
                (
                    new ControlDataFormItemInputDnf("lightDnf")
                    {
                        Label = _ => "Show characters seen at"
                    }
                        .DataService<MonkeyIslandLocationsSelection>()
                );

            Stage.DarkControls =
            [
                new ControlForm(null)
                .Add
                (
                    new ControlDataFormItemInputDnf("darkDnf")
                    {
                        Label = _ => "Show characters seen at"
                    }
                        .DataService<MonkeyIslandLocationsSelection>()
                )
            ];

            Stage.Code = @"
            new ControlForm()
                .Add
                (
                    new ControlDataFormItemInputDnf(""lightDnf"")
                    {
                        Label = _ => ""Show characters seen at""
                    }
                        .DataService<MonkeyIslandLocationsSelection>()
                );";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property sets the text shown in a conjunction that holds no term yet. It informs the user about the expected input and disappears as soon as a term is picked.",
                "Placeholder = _ => \"Pick a location\"",
                new ControlForm(null, new ControlDataFormItemInputDnf()
                {
                    Placeholder = _ => "Pick a location"
                }
                    .DataService<MonkeyIslandLocationsSelection>())
            );

            Stage.AddProperty
            (
                "MaxGroups",
                "The `MaxGroups` property caps the number of conjunctions the user may add. Once the cap is reached the add button is disabled. Left unset the number is unlimited.",
                "MaxGroups = _ => 2",
                new ControlForm(null, new ControlDataFormItemInputDnf()
                {
                    MaxGroups = _ => 2
                }
                    .DataService<MonkeyIslandLocationsSelection>())
            );

            Stage.AddProperty
            (
                "MaxItems",
                "The `MaxItems` property caps how many terms a single picker shows at once. It bounds the work of rendering a large term set without limiting what the endpoint may return for a search.",
                "MaxItems = _ => 10",
                new ControlForm(null, new ControlDataFormItemInputDnf()
                {
                    MaxItems = _ => 10
                }
                    .DataService<MonkeyIslandLocationsSelection>())
            );
        }
    }
}
