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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a REST-backed input control that validates user input by querying an API to determine whether the
    /// entered value is unique or already in use.
    /// </summary>
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestInputUnique : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the table control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestInputUnique(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // register relevant ui events
            Stage.AddEvent(Event.DATA_ARRIVED_EVENT, Event.DATA_REQUESTED_EVENT, Event.CLICK_EVENT, Event.CHANGE_VISIBILITY_EVENT);

            // describe the control in the tutorial
            Stage.Description = @"A REST-backed input validator that queries an API to check whether the entered value is already in use or available. The control displays a text field and triggers validation on input or blur events. The API response should indicate availability status, which is then reflected in the UI through visual feedback (e.g., success or error state). Optionally, debounce timing and server-side filtering can be configured.";

            // default (light) sample
            Stage.Controls =
            [
                new ControlForm()
                    .Add(new ControlRestFormItemInputUnique("lightUnique")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandCurseUnique>(pageContext.ApplicationContext),
                        Help = @"Enter a curse name to check its availability (e.g., ""Elaine's Statue Curse"")"
                    }
                        .Initialize(x => x.Value.Text = "LeChuck's Ghost Curse"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            ];

            // dark sample
            Stage.DarkControls =
            [
                new ControlForm()
                    .Add(new ControlRestFormItemInputUnique("darkUnique")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandCurseUnique>(pageContext.ApplicationContext),
                        Help = @"Enter a curse name to check its availability (e.g., ""Elaine's Statue Curse"")"
                    }
                        .Initialize(x => x.Value.Text = "LeChuck's Ghost Curse"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            ];

            // code sample
            Stage.Code = @"
            new ControlForm()
                .Add(new ControlRestFormItemInputUnique(""lightUnique"")
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandCurse>(pageContext.ApplicationContext),
                    Help = @""Enter a curse name to check its availability (e.g., """"Elaine's Statue Curse"""")""
                }
                    .Initialize(x => x.Value.Text = ""LeChuck's Ghost Curse""))
                .AddPrimaryButton(new ControlFormItemButtonSubmit())";

            // properties: Api
            Stage.AddProperty
            (
                "RestUri",
                "Defines the REST API endpoint that checks the uniqueness of a specified input value.",
                "RestUri = sitemapManager.GetUri<MonkeyIslandCurse>(pageContext.ApplicationContext)",
                new ControlForm()
                    .Add(new ControlRestFormItemInputUnique("p_api")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandCurseUnique>(pageContext.ApplicationContext)
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}