using System.Net.Http;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the REST traffic light demo page for the tutorial. Hosts a
    /// <see cref="ControlDataTrafficLight"/> connected to the
    /// <see cref="MonkeyIslandStatus"/> REST endpoint, which serves the current
    /// status (GET) and persists a change (PUT). The crew's readiness starts
    /// green; clicking a lamp persists the new status through the service layer.
    /// </summary>
    [Title("DataTrafficLight")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataTrafficLight : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataTrafficLight(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlDataTrafficLight` renders a traffic light whose status is loaded from a REST endpoint (GET) and persisted when the user clicks a lamp (PUT). The control only emits the host element and its `wx-service` data island; the lamps, the interaction and the persistence are built by the client-side `webexpress.webapp.TrafficLightCtrl`, which composes the read-only or the interactive WebUI representation and routes every request through the service layer. Set `Readonly` to render the dedicated read-only representation that loads but never persists. The control is also scope-capable: bind it to a resource of a `ControlViewState` scope (see the *Scope binding* section below).";

            Stage.Controls =
            [
                new ControlDataTrafficLight("tutorial-status-crew")
                    .DataService<MonkeyIslandStatus>()
            ];

            Stage.Code = @"
            new ControlDataTrafficLight(""tutorial-status-crew"")
                .DataService<MonkeyIslandStatus>();";

            Stage.AddProperty
            (
                "Readonly",
                "When `Readonly` is set, the lamps are rendered for reading only: the current status is loaded from the endpoint, but clicking a lamp neither changes nor persists it.",
                "new ControlDataTrafficLight(\"a\") { Readonly = _ => true }.DataService<MonkeyIslandStatus>()",
                new ControlDataTrafficLight("tutorial-status-crew-ro")
                {
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandStatus>()
            );

            Stage.AddProperty
            (
                "Orientation",
                "The `Orientation` property arranges the lamps either vertically, like a physical signal, or horizontally.",
                "new ControlDataTrafficLight(\"a\") { Orientation = _ => TypeOrientationTrafficLight.Horizontal }.DataService<MonkeyIslandStatus>()",
                new ControlDataTrafficLight("tutorial-status-crew-h")
                {
                    Orientation = _ => TypeOrientationTrafficLight.Horizontal
                }
                    .DataService<MonkeyIslandStatus>()
            );

            Stage.AddProperty
            (
                "Scope binding (ViewState)",
                "`ControlDataTrafficLight` is scope-capable. Bound to a resource of an enclosing `ControlViewState` scope with `Resource<TResource>()`, the status becomes a slice of the scope's shared state: the scope loads it centrally and every bound control subscribes. Here two lights share one `StatusResource` - changing the editable one persists and re-queries the resource, so the read-only one updates in lock step, neither owning its own service.",
                @"var statusEdit = new ControlDataTrafficLight(""statusEdit"").Resource<StatusResource>();
var statusView = new ControlDataTrafficLight(""statusView"")
{
    Readonly = _ => true,
    Orientation = _ => TypeOrientationTrafficLight.Horizontal
}.Resource<StatusResource>();

new ControlViewState<DataQueryState>(""statusScope"")
    .State(s => { })
    .Service<MonkeyIslandStatus>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
    .Resource<StatusResource>(r => r.Service<MonkeyIslandStatus>());",
                new ControlViewState<DataQueryState>("statusScope")
                    .State(s => { })
                    .Service<MonkeyIslandStatus>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Resource<StatusResource>(r => r.Service<MonkeyIslandStatus>()),
                new ControlDataTrafficLight("statusEdit")
                    .Resource<StatusResource>(),
                new ControlDataTrafficLight("statusView")
                {
                    Readonly = _ => true,
                    Orientation = _ => TypeOrientationTrafficLight.Horizontal
                }
                    .Resource<StatusResource>()
            );
        }
    }
}
