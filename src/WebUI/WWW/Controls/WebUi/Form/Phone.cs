using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the phone input control for the tutorial.
    /// </summary>
    [WebIcon<IconPhone>]
    [Title("Phone")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Phone : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the phone control is used.</param>
        public Phone(IPageContext pageContext)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"A `Phone` control takes a telephone number: a button with the flag and calling code of the country, beside a field for the national number. The country menu can be searched by name or calling code, and a number typed or pasted with `+` or `00` selects its country itself. The page receives the number in the international E.164 form, checked against the numbering plan of its country.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputPhone { Label = _ => "Phone" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputPhone { Label = _ => ""Phone"" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Phone",
                "The `Phone` property preselects a number as long as the form has no value of its own. An international number selects its country.",
                "Phone = _ => \"+44 20 7946 0000\"",
                new ControlForm(null, new ControlFormItemInputPhone(null) { Phone = _ => "+44 20 7946 0000" })
            );

            Stage.AddProperty
            (
                "Country",
                "The `Country` property sets the country an empty field starts in. Left unset, the field starts in the country of the visitor's language, such as Austria for de-AT.",
                "Country = _ => \"CH\"",
                new ControlForm(null, new ControlFormItemInputPhone(null) { Country = _ => "CH" })
            );

            Stage.AddProperty
            (
                "Countries",
                "The `Countries` property limits the countries offered; the server refuses a number of another country.",
                "Countries = _ => [\"AT\", \"CH\", \"DE\", \"LI\"]",
                new ControlForm(null, new ControlFormItemInputPhone(null) { Countries = _ => ["AT", "CH", "DE", "LI"] })
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property sets the text of the empty number field.",
                "Placeholder = _ => \"30 123456\"",
                new ControlForm(null, new ControlFormItemInputPhone(null) { Placeholder = _ => "30 123456" })
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property locks both the country button and the number field.",
                "Disabled = _ => true",
                new ControlForm(null, new ControlFormItemInputPhone(null) { Phone = _ => "+4930123456", Disabled = _ => true })
            );
        }
    }
}
