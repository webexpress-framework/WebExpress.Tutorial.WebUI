using System.Net;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the country input control for the tutorial.
    /// </summary>
    [WebIcon<IconFlag>]
    [Title("Country")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Country : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the country control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public Country(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CHANGE_FILTER_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"A `Country` control lets users choose a country from a list that shows each country with its flag. The names are shown and sorted in the language of the visitor, and the list can be searched by typing. The value is the ISO 3166-1 alpha-2 code, such as `DE`, so it stays the same whatever language the form was filled in.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputCountry { Label = _ => "Country", Country = _ => "DE" }
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, x.Context.Request, $"Value: {WebUtility.HtmlEncode(x.Value.Text)}", durability: 5000)))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputCountry { Label = _ => ""Country"", Country = _ => ""DE"" }
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, x.Context.Request, $""Value: {WebUtility.HtmlEncode(x.Value.Text)}"", durability: 5000)))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Country",
                "The `Country` property preselects a country by its code as long as the form has no value of its own. With `MultiSelect`, several codes are separated by a semicolon.",
                "Country = _ => \"JP\"",
                new ControlForm(null, new ControlFormItemInputCountry(null)
                {
                    Country = _ => "JP"
                })
            );

            Stage.AddProperty
            (
                "Countries",
                "The `Countries` property limits the list to the given codes. Left unset, all countries of ISO 3166-1 are offered. The server refuses a submitted code that is not on the list.",
                "Countries = _ => [\"AT\", \"CH\", \"DE\", \"LI\", \"LU\"]",
                new ControlForm(null, new ControlFormItemInputCountry(null)
                {
                    Countries = _ => ["AT", "CH", "DE", "LI", "LU"]
                })
            );

            Stage.AddProperty
            (
                "MultiSelect",
                "The `MultiSelect` property allows several countries to be chosen. The chosen countries appear as chips with their flag, and the value holds their codes separated by a semicolon.",
                "MultiSelect = _ => true",
                new ControlForm(null, new ControlFormItemInputCountry(null)
                {
                    MultiSelect = _ => true,
                    Country = _ => "FR;IT;ES"
                })
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property sets the text shown while no country is chosen.",
                "Placeholder = _ => \"Select your country\"",
                new ControlForm(null, new ControlFormItemInputCountry(null)
                {
                    Placeholder = _ => "Select your country"
                })
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property makes the country field non-interactive, indicating that the country cannot be changed.",
                "Disabled = _ => true",
                new ControlForm(null, new ControlFormItemInputCountry(null)
                {
                    Country = _ => "SE",
                    Disabled = _ => true
                })
            );
        }
    }
}
