using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the system metric gauge demo for the tutorial.
    /// </summary>
    [Title("SystemMetric")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class SystemMetric : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public SystemMetric()
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT);

            Stage.Description = @"`ControlSystemMetric` renders a live gauge for **one** system metric of the server: the CPU load of the server process or the physical memory usage of the host. The readings arrive over the MessageQueue WebSocket (see `WebExpress.WebApp.WebMessageQueue.SystemMetricsDispatcher`): the client subscribes the metric's channel on mount and the server pushes a fresh sample every two seconds, so the gauge is live without any HTTP polling and survives page navigation, transient disconnects and multiple windows. A connection without a subscribed gauge receives no metric traffic at all.

Each control instance shows exactly one metric. A surface that presents CPU and memory side by side simply places two instances, which keeps every gauge a small, composable unit. The gauge comes in two layouts - a compact **bar** and a live **chart** (sparkline of the recent history) - and is color coded: green below 60 %, yellow from 60 % and red from 85 %; the memory gauge additionally carries the absolute usage (used / total) as its tooltip.";

            Stage.Controls =
            [
                new ControlSystemMetric("myCpu")
                {
                    Metric = _ => TypeSystemMetric.Cpu
                },
                new ControlSystemMetric("myRam")
                {
                    Metric = _ => TypeSystemMetric.Ram
                }
            ];

            Stage.Code = @"
            new ControlSystemMetric(""myCpu"")
            {
                Metric = _ => TypeSystemMetric.Cpu
            },
            new ControlSystemMetric(""myRam"")
            {
                Metric = _ => TypeSystemMetric.Ram
            }";

            Stage.AddProperty
            (
                "Metric",
                "The `Metric` property selects the reading the gauge renders: `Cpu` for the processor load of the server process (normalized over all cores) or `Ram` for the physical memory usage of the host. A control instance always shows exactly one metric; the default is `Cpu`.",
                "Metric = _ => TypeSystemMetric.Ram",
                new ControlSystemMetric("metric-cpu")
                {
                    Metric = _ => TypeSystemMetric.Cpu
                },
                new ControlSystemMetric("metric-ram")
                {
                    Metric = _ => TypeSystemMetric.Ram
                }
            );

            Stage.AddProperty
            (
                "Layout",
                "The `Layout` property selects the visual form of the gauge: `Bar` (a compact bar that fills to the current percentage, the default) or `Chart` (a live sparkline that scrolls right-to-left like a task manager CPU chart, with the newest reading at the right edge, so a trend is visible at a glance). Both layouts share the metric, the color thresholds and the tooltip.",
                "Layout = _ => TypeSystemMetricLayout.Chart",
                new ControlSystemMetric("layout-bar")
                {
                    Metric = _ => TypeSystemMetric.Cpu,
                    Layout = _ => TypeSystemMetricLayout.Bar,
                    Label = _ => "CPU (bar)"
                },
                new ControlSystemMetric("layout-chart")
                {
                    Metric = _ => TypeSystemMetric.Cpu,
                    Layout = _ => TypeSystemMetricLayout.Chart,
                    Label = _ => "CPU (chart)"
                }
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property replaces the caption above the gauge. Without a label the client falls back to the translated metric name (`CPU` or `Memory`).",
                "Label = _ => \"Server load\"",
                new ControlSystemMetric("metric-label")
                {
                    Metric = _ => TypeSystemMetric.Cpu,
                    Label = _ => "Server load"
                }
            );
        }
    }
}
