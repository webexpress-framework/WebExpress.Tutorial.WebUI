using System.Net;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the tutorial page that demonstrates a REST-backed dropdown control with search and grouping.
    /// </summary>
    [WebIcon<IconControlSelection>]
    [Title("DataInputSelection")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataInputSelection : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the table control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public DataInputSelection(IPageContext pageContext, IComponentHub componentHub)
        {
            // register relevant ui events
            Stage.AddEvent(Event.DATA_ARRIVED_EVENT, Event.DATA_REQUESTED_EVENT, Event.CHANGE_VALUE_EVENT, Event.CHANGE_FILTER_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            // describe the control in the tutorial
            Stage.Description = @"A `Selection` control with a REST backend dynamically loads its options from a configurable API endpoint and supports search and paging parameters. When the dropdown opens, it fetches data based on the current search term; a loading indicator is displayed while the request is in progress. After a successful fetch, the options are available for multi-select.";

            // default (light) sample
            Stage.Control = new ControlForm("myform")
                .Add
                (
                    new ControlDataFormItemInputSelection("lightSelection")
                    {
                        Name = _ => "mySelectionCtrl"
                    }
                        .DataService<MonkeyIslandLocationsSelection>()
                        .Process(x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, x.Context.Request, $"Value: {WebUtility.HtmlEncode(x.Value.Text)}", durability: 5000))
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            // shares the form and the field name with the light copy, which already announces
            // the submission - only the ids differ, so the two data islands stay apart
            Stage.DarkControls =
            [
                new ControlForm("myform")
                .Add
                (
                    new ControlDataFormItemInputSelection("darkSelection")
                    {
                        Name = _ => "mySelectionCtrl"
                    }
                        .DataService<MonkeyIslandLocationsSelection>()
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit())
            ];

            Stage.Code = @"
            new ControlForm(""myform"")
                .Add
                (
                    new ControlDataFormItemInputSelection(""lightSelection"")
                    {
                        Name = _ => ""mySelectionCtrl""
                    }
                        .DataService<MonkeyIslandLocationsSelection>()
                        .Process(x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, x.Context.Request, $""Value: {WebUtility.HtmlEncode(x.Value.Text)}"", durability: 5000))
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Multiselect",
                "The multiselect property is used in a Selection Control to allow users to choose multiple options from a list. By enabling this property, the control is configured to support flexible multi-selection rather than limiting users to a single choice.",
                "MultiSelect = _=> true",
                new ControlForm(null, new ControlDataFormItemInputSelection()
                {
                    MultiSelect = _ => true
                }
                    .DataService<MonkeyIslandLocationsSelection>())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field, a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = _=> \"Placeholder\"",
                new ControlForm(null, new ControlDataFormItemInputSelection()
                {
                    Placeholder = _ => "Placeholder"
                }
                    .DataService<MonkeyIslandLocationsSelection>())
            );

            Stage.AddProperty
            (
                "MaxItems",
                "Maximum number of entries to display.",
                "MaxItems = _=> 10",
                 new ControlForm(null, new ControlDataFormItemInputSelection()
                 {
                     MaxItems = _ => 10
                 }
                     .DataService<MonkeyIslandLocationsSelection>())
            );
        }
    }
}