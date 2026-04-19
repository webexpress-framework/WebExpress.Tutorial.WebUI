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
    /// Represents a REST-backed checkbox control that reads and persists its
    /// state via a REST API instead of a local cookie.
    /// </summary>
    [Title("RestInputCheck")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestInputCheck : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for building REST endpoint URIs.</param>
        public RestInputCheck(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `ControlRestFormItemInputCheck` control extends `ControlFormItemInputCheck` and communicates with a REST API instead of persisting its state through cookies. On render, the client issues a GET request against the configured `RestUri` to retrieve the current checked state. If an `InitialChecked` value is provided, it takes precedence and the GET is skipped. Subsequent state changes are forwarded to the same endpoint via POST.";

            Stage.Controls =
            [
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("lightCheck")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Description = "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            ];

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlRestFormItemInputCheck(""lightCheck"")
                {
                    RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                    Description = ""Enable insult sword fighting""
                })
                .AddPrimaryButton(new ControlFormItemButtonSubmit())";

            Stage.AddProperty
            (
                "RestUri",
                "Defines the REST API endpoint that reads and persists the checked state.",
                "RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext)",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_rest_uri")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Description = "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "InitialChecked",
                "Pre-selects the checkbox without issuing a GET request. The value takes precedence over the REST endpoint.",
                "InitialChecked = true",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_initial_true")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        InitialChecked = true,
                        Description = "Pre-checked without GET"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Description",
                "Sets the label text shown next to the checkbox.",
                @"Description = ""Enable insult sword fighting""",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_description")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Description = "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Layout",
                "Switches between the default checkbox and the toggle switch appearance.",
                "Layout = TypeLayoutCheck.Switch",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_layout")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Layout = TypeLayoutCheck.Switch,
                        Description = "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Inline",
                "Renders the checkbox inline with adjacent controls rather than on a new line.",
                "Inline = true",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_inline")
                    {
                        RestUri = sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Inline = true,
                        Description = "Inline"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
