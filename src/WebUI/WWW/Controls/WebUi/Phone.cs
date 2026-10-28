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
    /// Represents the phone control for the tutorial.
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
        /// <param name="pageContext">The context of the page where the phone control is used.</param>
        public Phone(IPageContext pageContext)
        {
            Stage.Description = @"The `Phone` control is a read-only component that shows a telephone number with the flag of its country, as a link that dials it. The number is kept in the international E.164 form (`+4930123456`) and shown with its calling code set apart.";

            Stage.Controls = [
                new ControlPhone()
                {
                    Phone = _ => "+49 30 123456"
                }
            ];

            Stage.Code = @"
            new ControlPhone()
            {
                Phone = _ => ""+49 30 123456""
            };";

            Stage.AddProperty
            (
                "Phone",
                "The `Phone` property sets the number. An international number names its own country - even where countries share a calling code: +1 416 is Canada, +1 242 the Bahamas, +1 212 the United States.",
                "Phone = _ => \"+1 416 555 0100\"",
                new ControlPhone() { Phone = _ => "+1 416 555 0100" },
                new ControlPhone() { Phone = _ => "+1 242 555 0100" },
                new ControlPhone() { Phone = _ => "+1 212 555 0100" }
            );

            Stage.AddProperty
            (
                "Country",
                "The `Country` property names the country a national number belongs to, so a page may keep numbers the way its users wrote them. The national prefix is dropped, as the international form leaves it out.",
                "Phone = _ => \"030 123456\", Country = _ => \"DE\"",
                new ControlPhone() { Phone = _ => "030 123456", Country = _ => "DE" }
            );
        }
    }
}
