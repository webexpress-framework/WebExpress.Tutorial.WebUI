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
                    ShowSprintFilter = _ => true,
                    ColorCompleted = _ => new PropertyColorBackground("#2563eb"),
                    ColorAverage = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                }
                    .DataService<MonkeyIslandScrumVelocity>()
            ];

            Stage.Code = @"
            new ControlDataScrumVelocity(""monkeyIslandVelocity"")
            {
                MaxSprints = _ => 6,
                ShowSprintFilter = _ => true,
                ColorCompleted = _ => new PropertyColorBackground(""#2563eb""),
                ColorAverage = _ => new PropertyColorBackground(TypeColorBackground.Danger)
            }
                .DataService<MonkeyIslandScrumVelocity>()";

            Stage.AddProperty
            (
                "ShowSprintFilter",
                @"`MaxSprints` decides how much history the chart shows; `ShowSprintFilter` hands that decision to the visitor. It adds a `wx-webui-input-slider` below the legend whose scale is the loaded history and whose two handles narrow the plot to a window of it - drag them together to compare two sprints, apart to read the whole campaign. The average line and the rolling average in the header follow the window, because an average over sprints that are not on screen answers a question nobody asked.

The slider starts on exactly the window `MaxSprints` describes, so switching the filter on changes what the visitor *can* do, never what they first see. It is opt-in for the same reason: the chart is otherwise a read-only tile, and a wall display should not invite an interaction nobody is standing in front of.",
                @"
                new ControlDataScrumVelocity(""velocityFiltered"")
                {
                    MaxSprints = _ => 3,
                    ShowSprintFilter = _ => true
                }
                    .DataService<MonkeyIslandScrumVelocity>()",
                new ControlDataScrumVelocity("velocityFiltered")
                {
                    MaxSprints = _ => 3,
                    ShowSprintFilter = _ => true
                }
                    .DataService<MonkeyIslandScrumVelocity>()
            );
        }
    }
}
