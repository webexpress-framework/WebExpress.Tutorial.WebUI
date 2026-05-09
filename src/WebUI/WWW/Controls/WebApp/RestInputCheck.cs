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
                        RestUri = _=> sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Description = _ => "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            ];

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlRestFormItemInputCheck(""lightCheck"")
                {
                    RestUri = _=> sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                    Description = _ => ""Enable insult sword fighting""
                })
                .AddPrimaryButton(new ControlFormItemButtonSubmit())";

            Stage.AddProperty
            (
                "RestUri",
                "Defines the REST API endpoint that reads and persists the checked state.",
                "RestUri = _ => sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext)",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_rest_uri")
                    {
                        RestUri = _ => sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Description = _ => "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "InitialChecked",
                "Pre-selects the checkbox without issuing a GET request. The value takes precedence over the REST endpoint.",
                "InitialChecked = _ => true",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_initial_true")
                    {
                        RestUri = _ => sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        InitialChecked = _ => true,
                        Description = _ => "Pre-checked without GET"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Description",
                "Sets the label text shown next to the checkbox.",
                @"Description = _ => ""Enable insult sword fighting""",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_description")
                    {
                        RestUri = _ => sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Description = _ => "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Layout",
                "Switches between the default checkbox and the toggle switch appearance.",
                "Layout = _ => TypeLayoutCheck.Switch",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_layout")
                    {
                        RestUri = _ => sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Layout = _ => TypeLayoutCheck.Switch,
                        Description = _ => "Enable insult sword fighting"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Inline",
                "Renders the checkbox inline with adjacent controls rather than on a new line.",
                "Inline = _ => true",
                new ControlForm()
                    .Add(new ControlRestFormItemInputCheck("p_inline")
                    {
                        RestUri = _ => sitemapManager.GetUri<MonkeyIslandInsultModeCheck>(pageContext.ApplicationContext),
                        Inline = _ => true,
                        Description = _ => "Inline"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
