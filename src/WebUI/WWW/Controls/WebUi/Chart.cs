using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the chart control for the tutorial demonstration.
    /// </summary>
    [Title("Chart")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Chart : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Chart()
        {
            // provide a concise explanation for the chart control demo
            Stage.Description = @"A `ControlChart` visualizes data as a chart (e.g., bar, line, pie). The control renders a container for the client-side ChartCtrl and passes configuration via data attributes. Datasets, labels, titles, and axis options (e.g., begin at zero, min/max) can be configured via properties and additionally through a fluent API.";

            // basic example chart shown at the top of the page
            Stage.Control =
                new ControlChart()
                {
                    Type = TypeChart.Bar,
                    Title = "Sales Development",
                    TitleX = "Month",
                    TitleY = "Sales (k)",
                    Height = 300,
                    Responsive = true,
                    MaintainAspectRatio = false,
                    LegendDisplay = true,
                    TitleDisplay = true,
                    YBeginAtZero = true
                }
                    .AddLabel("Jan", "Feb", "Mar", "Apr", "May", "Jun")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "2024",
                        Data = new ControlChartDatasetPointCollection(12f, 19f, 3f, 5f, 2f, 3f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "2025",
                        Data = new ControlChartDatasetPointCollection(8f, 11f, 5f, 8f, 13f, 7f)
                    });

            // show code snippet for the basic example
            Stage.Code = @"
            new ControlChart()
            {
                Type = TypeChart.Bar,
                Labels = new List<string> { ""Jan"", ""Feb"", ""Mar"", ""Apr"", ""May"", ""Jun"" },
                Title = ""Sales Development"",
                TitleX = ""Month"",
                TitleY = ""Sales (k)"",
                Height = 300,
                Responsive = true,
                MaintainAspectRatio = false,
                LegendDisplay = true,
                TitleDisplay = true,
                YBeginAtZero = true
            }
                .AddLabel(""Jan"", ""Feb"", ""Mar"", ""Apr"", ""May"", ""Jun"")
                .AddDataset(new ControlChartDataset
                {
                    Title = ""2024"",
                    Data = new ControlChartDatasetPointCollection(12f, 19f, 3f, 5f, 2f, 3f)
                })
                .AddDataset(new ControlChartDataset
                {
                    Title = ""2025"",
                    Data = new ControlChartDatasetPointCollection(8f, 11f, 5f, 8f, 13f, 7f)
                });";

            // property: Type
            Stage.AddProperty
            (
                "Type",
                "The chart type determines the visualization (e.g., bar or line chart).",
                "Type = TypeChart.Bar or Type = TypeChart.Line",
                new ControlChart()
                {
                    Type = TypeChart.Bar,
                    Title = "Bar",
                    TitleDisplay = true,
                    Height = 220,
                    YBeginAtZero = true
                }
                    .AddLabel("A", "B", "C", "D")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Values",
                        Data = new ControlChartDatasetPointCollection(5f, 9f, 2f, 7f)
                    }),
                new ControlChart()
                {
                    Type = TypeChart.Line,
                    Title = "Line",
                    TitleDisplay = true,
                    Height = 220,
                    YBeginAtZero = true
                }
                    .AddLabel("A", "B", "C", "D")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Values",
                        Data = new ControlChartDatasetPointCollection(5f, 9f, 2f, 7f)
                    }),
                new ControlChart()
                {
                    Type = TypeChart.Pie,
                    Title = "Pie",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddLabel("Red", "Blue", "Yellow")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Votes",
                        Data = new ControlChartDatasetPointCollection(12f, 19f, 3f)
                    }),
                new ControlChart()
                {
                    Type = TypeChart.Doughnut,

                    Title = "Browser Usage",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddLabel("Chrome", "Firefox", "Edge")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Users",
                        Data = new ControlChartDatasetPointCollection(55f, 20f, 25f)
                    }),
                new ControlChart()
                {
                    Type = TypeChart.Radar,
                    Title = "Car Comparison",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddLabel("Speed", "Reliability", "Comfort")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Car A",
                        Data = new ControlChartDatasetPointCollection(7f, 9f, 8f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Car B",
                        Data = new ControlChartDatasetPointCollection(6f, 7f, 9f)
                    }),
                new ControlChart()
                {
                    Type = TypeChart.PolarArea,
                    Title = "Wind Strength",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddLabel("North", "East", "South")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Wind",
                        Data = new ControlChartDatasetPointCollection(11f, 16f, 7f)
                    }),
                new ControlChart()
                {
                    Type = TypeChart.Bubble,
                    Title = "Bubble Data",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Bubbles",
                        Data = new ControlChartDatasetPointCollection
                        (
                            new ControlChartDatasetPointBubble { X = 1, Y = 1, Radius = 15 },
                            new ControlChartDatasetPointBubble { X = 0.5f, Y = 0.5f, Radius = 10 }
                        )
                    }),
                new ControlChart()
                {
                    Type = TypeChart.Scatter,
                    Title = "Scatter Data",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Points",
                        Data = new ControlChartDatasetPointCollection
                        (
                            new ControlChartDatasetPointScatter { X = 3, Y = 7 },
                            new ControlChartDatasetPointScatter { X = 7, Y = 2 },
                            new ControlChartDatasetPointScatter { X = 5, Y = 9 }
                        )
                    })
            );

            // property: Labels
            Stage.AddProperty
            (
                "Labels",
                "Labels describe the data categories of the x-axis or the segments in other chart types.",
                "Labels = new List<string> { \"Q1\", \"Q2\", \"Q3\", \"Q4\" }",
                new ControlChart()
                {
                    Type = TypeChart.Bar,
                    Title = "Quarters",
                    TitleDisplay = true,
                    Height = 220,
                    YBeginAtZero = true
                }
                    .AddLabel("Q1", "Q2", "Q3", "Q4")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Plan",
                        Data = new ControlChartDatasetPointCollection(10f, 15f, 12f, 18f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Actual",
                        Data = new ControlChartDatasetPointCollection(9f, 14f, 13f, 17f)
                    })
            );

            // property: Title, TitleX, TitleY
            Stage.AddProperty
            (
                "Title, TitleX, TitleY",
                "Titles and axis titles improve readability and context of the chart.",
                "Title = \"Performance Overview\"; TitleX = \"Month\"; TitleY = \"Points\";",
                new ControlChart()
                {
                    Type = TypeChart.Line,
                    Title = "Performance Overview",
                    TitleX = "Month",
                    TitleY = "Points",
                    TitleDisplay = true,
                    Height = 220
                }
                    .AddLabel("Jan", "Feb", "Mar", "Apr")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Team A",
                        Data = new ControlChartDatasetPointCollection(3f, 6f, 4f, 7f)
                    })
            );

            // property: Responsive, MaintainAspectRatio, LegendDisplay, TitleDisplay
            Stage.AddProperty
            (
                "Responsive & Legend/Title",
                "Responsive behavior and display of legend or title can be controlled independently.",
                "Responsive = true; MaintainAspectRatio = false; LegendDisplay = true; TitleDisplay = true;",
                new ControlChart()
                {
                    Type = TypeChart.Bar,
                    Title = "Sizes",
                    TitleDisplay = true,
                    Responsive = true,
                    MaintainAspectRatio = false,
                    LegendDisplay = true,
                    Height = 220,
                    YBeginAtZero = true
                }
                    .AddLabel("S", "M", "L", "XL")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Orders",
                        Data = new ControlChartDatasetPointCollection(4f, 8f, 6f, 2f)
                    })
            );

            // property: Axis settings (BeginAtZero, Min/Max)
            Stage.AddProperty
            (
                "Axes (BeginAtZero, Min/Max)",
                "The y-axis can start at zero or be limited by min/max.",
                "YBeginAtZero = true; Minimum = 0; Maximum = 20;",
                new ControlChart()
                {
                    Type = TypeChart.Bar,
                    Title = "Scaling",
                    TitleDisplay = true,
                    Height = 220,
                    YBeginAtZero = true,
                    Minimum = 0,
                    Maximum = 20
                }
                    .AddLabel("P1", "P2", "P3", "P4")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Measurements",
                        Data = new ControlChartDatasetPointCollection(2f, 5f, 9f, 14f)
                    })
            );

            // property: Dataset styling
            Stage.AddProperty
            (
                "Datasets (Label, Color, Border)",
                "Each dataset can define a label, background/border color, and border width.",
                @"
                new ControlChartDataset
                {
                    Title = ""Alpha"",
                    Data = [3f, 7f, 5f],
                    BackgroundColor = ""gold"",
                    BorderColor = ""red"",
                    BorderWidth = 2
                }",
                new ControlChart()
                {
                    Type = TypeChart.Bar,
                    Title = "Style",
                    TitleDisplay = true,
                    Height = 220,
                    YBeginAtZero = true
                }
                    .AddLabel("K1", "K2", "K3")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Alpha",
                        Data = new ControlChartDatasetPointCollection(3f, 7f, 5f),
                        BackgroundColor = "gold",
                        BorderColor = "red",
                        BorderWidth = 2
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Beta",
                        Data = new ControlChartDatasetPointCollection(4f, 4f, 8f)
                    })
            );

            // property: Height
            Stage.AddProperty
            (
                "Height",
                "The height controls the vertical size of the chart in pixels and affects the display area.",
                "Height = 360",
                new ControlChart()
                {
                    Type = TypeChart.Line,
                    Title = "Height Example",
                    TitleDisplay = true,
                    Height = 360,
                    YBeginAtZero = true
                }
                    .AddLabel("T1", "T2", "T3", "T4", "T5")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Progression",
                        Data = new ControlChartDatasetPointCollection(1f, 3f, 2f, 5f, 4f)
                    })
            );
        }
    }
}