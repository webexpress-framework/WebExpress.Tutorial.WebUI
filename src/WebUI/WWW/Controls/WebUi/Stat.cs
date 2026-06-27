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
    /// Represents the stat (metric) control demo page for the tutorial.
    /// </summary>
    [Title("Stat")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Stat : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Stat(IPageContext pageContext)
        {
            Stage.Description = @"The `Stat` control is a compact metric (KPI) tile: a label, a prominent value, an optional change indicator colored by its trend, and an optional leading icon.";

            Stage.Controls =
            [
                new ControlStat()
                {
                    Icon = _ => new IconCoins(),
                    Label = _ => "Revenue",
                    Value = _ => "12.4k",
                    Delta = _ => "+8.1%",
                    Trend = _ => TypeStatTrend.Up
                }
            ];

            Stage.Code = @"
            new ControlStat()
            {
                Icon = _ => new IconCoins(),
                Label = _ => ""Revenue"",
                Value = _ => ""12.4k"",
                Delta = _ => ""+8.1%"",
                Trend = _ => TypeStatTrend.Up
            };";

            Stage.AddProperty
            (
                "Trend",
                "Colors the delta by the direction of the change (up, down or neutral).",
                "Trend = _ => TypeStatTrend.Down",
                new ControlStat()
                {
                    Icon = _ => new IconChartLine(),
                    Label = _ => "Sessions",
                    Value = _ => "3,204",
                    Delta = _ => "+12%",
                    Trend = _ => TypeStatTrend.Up
                },
                new ControlStat()
                {
                    Icon = _ => new IconUsers(),
                    Label = _ => "Bounce rate",
                    Value = _ => "38%",
                    Delta = _ => "-4%",
                    Trend = _ => TypeStatTrend.Down
                },
                new ControlStat()
                {
                    Icon = _ => new IconEye(),
                    Label = _ => "Open rate",
                    Value = _ => "57%",
                    Delta = _ => "0%",
                    Trend = _ => TypeStatTrend.Neutral
                }
            );
        }
    }
}
