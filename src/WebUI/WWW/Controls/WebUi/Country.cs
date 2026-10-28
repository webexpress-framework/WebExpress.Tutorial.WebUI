using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the country control for the tutorial.
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
        /// <param name="pageContext">The context of the page where the country control is used.</param>
        public Country(IPageContext pageContext)
        {
            Stage.Description = @"The `Country` control is a read-only component that shows a country as its flag followed by its name. The country is given as its ISO 3166-1 alpha-2 code, such as `DE` or `JP`, and the name is shown in the language of the visitor.";

            Stage.Controls = [
                new ControlCountry()
                {
                    Country = _ => "DE"
                }
            ];

            Stage.Code = @"
            new ControlCountry()
            {
                Country = _ => ""DE""
            };";

            Stage.AddProperty
            (
                "Country",
                "The `Country` property sets the country by its ISO 3166-1 alpha-2 code. The letter case does not matter, and a code the framework does not know leaves the display empty instead of showing a name without a flag.",
                "Country = _ => \"jp\"",
                new ControlCountry() { Country = _ => "jp" },
                new ControlCountry() { Country = _ => "BR" },
                new ControlCountry() { Country = _ => "ZA" },
                new ControlCountry() { Country = _ => "CA" }
            );

            Stage.AddProperty
            (
                "ShowName",
                "The `ShowName` property decides whether the name is shown beside the flag. Without the name, the flag alone stands for the country - screen readers still announce the name, and pointing at the flag shows it as a tooltip.",
                "ShowName = _ => false",
                new ControlCountry() { Country = _ => "FR", ShowName = _ => false },
                new ControlCountry() { Country = _ => "IT", ShowName = _ => false },
                new ControlCountry() { Country = _ => "ES", ShowName = _ => false },
                new ControlCountry() { Country = _ => "SE", ShowName = _ => false }
            );
        }
    }
}
