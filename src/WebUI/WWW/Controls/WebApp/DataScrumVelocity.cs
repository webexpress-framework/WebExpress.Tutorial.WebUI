using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents a Monkey Island themed Scrum velocity chart, showing the
    /// completed story points of the recent sprints with the committed points as
    /// a backdrop and the rolling average.
    /// </summary>
    [Title("DataScrumVelocity")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataScrumVelocity : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="sitemapManager">The sitemap manager for URI generation.</param>
        public DataScrumVelocity(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.DATA_REQUESTED_EVENT, Event.DATA_ARRIVED_EVENT, Event.UPDATED_EVENT);

            Stage.Description = @"The `ScrumVelocity` control shows the velocity – the completed story points – of the last few sprints as a column chart. Each column contrasts the completed points (solid bar) with the committed points (backdrop bar), and a line marks the average velocity across the shown sprints. The bar colors are user-definable like a control button: a system color (for example `TypeColorBackground.Success`) renders as a CSS class, a user-defined color (for example `#2563eb`) as an inline style.";

            Stage.Controls =
            [
                new ControlDataScrumVelocity("monkeyIslandVelocity")
                {
                    MaxSprints = _ => 6,
                    ColorCompleted = _ => new PropertyColorBackground("#2563eb"),
                    ColorAverage = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                }
                    .DataService<MonkeyIslandScrumVelocity>()
            ];

            Stage.Code = @"
            new ControlDataScrumVelocity(""monkeyIslandVelocity"")
            {
                MaxSprints = _ => 6,
                ColorCompleted = _ => new PropertyColorBackground(""#2563eb""),
                ColorAverage = _ => new PropertyColorBackground(TypeColorBackground.Danger)
            }
                .DataService<MonkeyIslandScrumVelocity>()";
        }
    }
}
