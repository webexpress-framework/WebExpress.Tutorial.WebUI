using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the chart control for the tutorial demonstration.
    /// </summary>
    [WebIcon<IconControlChart>]
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
            Stage.Description = @"A `ControlChart` visualizes data as a line, bar, pie, doughnut, radar, polar area, bubble or scatter chart. The chart is drawn by WebExpress itself as SVG - no third-party charting library is involved - and follows the light and dark theme with a color-blind-safe palette. Its marks enter with subtle, staggered animations that respect the reader's reduced-motion setting. The legend toggles the series, the pointer shows the values of the category or slice beneath it, and the arrow keys walk the values when the chart has the focus. A visually hidden table carries all values for assistive technology. Labels, datasets, titles and axis options are set through properties; the client-side `ChartCtrl` additionally offers a fluent JavaScript API.";

            Stage.Control =
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Sales Development",
                    TitleX = _ => "Month",
                    TitleY = _ => "Sales (k)",
                    Height = _ => 300,
                    TitleDisplay = _ => true,
                    YBeginAtZero = _ => true
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

            Stage.Code = @"
            new ControlChart()
            {
                Type = _ => TypeChart.Bar,
                Title = _ => ""Sales Development"",
                TitleX = _ => ""Month"",
                TitleY = _ => ""Sales (k)"",
                Height = _ => 300,
                TitleDisplay = _ => true,
                YBeginAtZero = _ => true
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

            Stage.AddProperty
            (
                "Type",
                "The chart type determines the visualization. Line and bar charts plot values over categories, pie, doughnut and polar area charts compare the parts of a whole, a radar chart compares several properties, and bubble and scatter charts plot points over two value axes.",
                "Type = _ => TypeChart.Bar",
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Bar",
                    TitleDisplay = _ => true,
                    Height = _ => 220,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("A", "B", "C", "D")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Values",
                        Data = new ControlChartDatasetPointCollection(5f, 9f, 2f, 7f)
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Line",
                    TitleDisplay = _ => true,
                    Height = _ => 220,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("A", "B", "C", "D")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Values",
                        Data = new ControlChartDatasetPointCollection(5f, 9f, 2f, 7f)
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Pie,
                    Title = _ => "Pie",
                    TitleDisplay = _ => true,
                    Height = _ => 220
                }
                    .AddLabel("Red", "Blue", "Yellow")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Votes",
                        Data = new ControlChartDatasetPointCollection(12f, 19f, 3f)
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Doughnut,
                    Title = _ => "Browser Usage",
                    TitleDisplay = _ => true,
                    Height = _ => 220
                }
                    .AddLabel("Chrome", "Firefox", "Edge")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Users",
                        Data = new ControlChartDatasetPointCollection(55f, 20f, 25f)
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Radar,
                    Title = _ => "Car Comparison",
                    TitleDisplay = _ => true,
                    Height = _ => 260
                }
                    .AddLabel("Speed", "Reliability", "Comfort", "Safety", "Economy")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Car A",
                        Data = new ControlChartDatasetPointCollection(7f, 9f, 8f, 6f, 5f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Car B",
                        Data = new ControlChartDatasetPointCollection(6f, 7f, 9f, 8f, 7f)
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.PolarArea,
                    Title = _ => "Wind Strength",
                    TitleDisplay = _ => true,
                    Height = _ => 220
                }
                    .AddLabel("North", "East", "South", "West")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Wind",
                        Data = new ControlChartDatasetPointCollection(11f, 16f, 7f, 13f)
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Bubble,
                    Title = _ => "Bubble Data",
                    TitleDisplay = _ => true,
                    Height = _ => 220
                }
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Bubbles",
                        Data = new ControlChartDatasetPointCollection
                        (
                            new ControlChartDatasetPointBubble { X = 1, Y = 1, Radius = 15 },
                            new ControlChartDatasetPointBubble { X = 0.5f, Y = 0.5f, Radius = 10 },
                            new ControlChartDatasetPointBubble { X = 0.8f, Y = 0.7f, Radius = 6 }
                        )
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Scatter,
                    Title = _ => "Scatter Data",
                    TitleDisplay = _ => true,
                    Height = _ => 220
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

            Stage.AddProperty
            (
                "Labels",
                "Labels name the categories of the x-axis, the slices of a pie or the spokes of a radar chart. They appear on the axis, in the tooltip and in the data table.",
                @"
                new ControlChart()
                    .AddLabel(""Q1"", ""Q2"", ""Q3"", ""Q4"")",
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Quarters",
                    TitleDisplay = _ => true,
                    Height = _ => 220,
                    YBeginAtZero = _ => true
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

            Stage.AddProperty
            (
                "Title, TitleX, TitleY",
                "The title names the chart - it is also the name assistive technology reads for it - and the axis titles name the quantities on the axes. The title is shown when TitleDisplay is set.",
                "Title = _ => \"Performance Overview\"; TitleDisplay = _ => true; TitleX = _ => \"Month\"; TitleY = _ => \"Points\";",
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Performance Overview",
                    TitleX = _ => "Month",
                    TitleY = _ => "Points",
                    TitleDisplay = _ => true,
                    Height = _ => 220
                }
                    .AddLabel("Jan", "Feb", "Mar", "Apr")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Team A",
                        Data = new ControlChartDatasetPointCollection(3f, 6f, 4f, 7f)
                    })
            );

            Stage.AddProperty
            (
                "LegendDisplay",
                "Without a setting the legend appears as soon as a chart has two or more datasets, and always for pie, doughnut and polar area charts; a single series is named by the title. LegendDisplay forces the legend on. Every legend entry is a toggle that hides or shows its series.",
                "LegendDisplay = _ => true;",
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Orders",
                    TitleDisplay = _ => true,
                    LegendDisplay = _ => true,
                    Height = _ => 220,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("S", "M", "L", "XL")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Orders",
                        Data = new ControlChartDatasetPointCollection(4f, 8f, 6f, 2f)
                    })
            );

            Stage.AddProperty
            (
                "YBeginAtZero, Minimum, Maximum",
                "The y-axis can be made to include zero or be fixed to a minimum and a maximum. The axis steps in round values; a fixed bound is kept exactly. Bar charts start at zero anyway, because a bar's length is its value.",
                "YBeginAtZero = _ => true; Minimum = _ => 0; Maximum = _ => 20;",
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Scaling",
                    TitleDisplay = _ => true,
                    Height = _ => 220,
                    YBeginAtZero = _ => true,
                    Minimum = _ => 0,
                    Maximum = _ => 20
                }
                    .AddLabel("P1", "P2", "P3", "P4")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Measurements",
                        Data = new ControlChartDatasetPointCollection(2f, 5f, 9f, 14f)
                    })
            );

            Stage.AddProperty
            (
                "Datasets (Type, YAxisId), TitleY1, Y1BeginAtZero, MinimumY1, MaximumY1",
                "Type draws a single dataset as bars or as a line within a line or bar chart, so a series stands apart by its meaning - here the revenue as a line over the bars of the units sold. Series of a different magnitude flatten each other on one axis: next to a revenue in the thousands, a count of a few dozen units runs along the bottom. YAxisId = \"y1\" measures a dataset on a second value axis at the right edge, with its own ticks and its own title, so both series use the full height. TitleY1, Y1BeginAtZero, MinimumY1 and MaximumY1 set the second axis like their counterparts set the first one. It draws no grid lines of its own, which would cross those of the first axis. Only vertical line and bar charts have a second axis.",
                @"
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    TitleY = _ => ""Units"",
                    TitleY1 = _ => ""Revenue (EUR)"",
                    Y1BeginAtZero = _ => true
                }
                    .AddDataset(new ControlChartDataset
                    {
                        Title = ""Units"",
                        Data = new ControlChartDatasetPointCollection(24f, 31f, 28f, 42f, 38f, 47f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = ""Revenue"",
                        Data = new ControlChartDatasetPointCollection(1150f, 1520f, 1390f, 2080f, 1870f, 2390f),
                        Type = TypeDatasetChart.Line,
                        YAxisId = ""y1""
                    })",
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Units and Revenue",
                    TitleDisplay = _ => true,
                    LegendDisplay = _ => true,
                    Height = _ => 260,
                    TitleY = _ => "Units",
                    TitleY1 = _ => "Revenue (EUR)",
                    Y1BeginAtZero = _ => true
                }
                    .AddLabel("Jan", "Feb", "Mar", "Apr", "May", "Jun")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Units",
                        Data = new ControlChartDatasetPointCollection(24f, 31f, 28f, 42f, 38f, 47f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Revenue",
                        Data = new ControlChartDatasetPointCollection(1150f, 1520f, 1390f, 2080f, 1870f, 2390f),
                        Type = TypeDatasetChart.Line,
                        Point = TypePointChart.Triangle,
                        YAxisId = "y1"
                    })
            );

            Stage.AddProperty
            (
                "Datasets (Title, Color, Border)",
                "Each dataset has a title and may define its own background color, border color and border width; without colors it takes the next color of the theme palette. Any CSS color works, including the theme variables.",
                @"
                new ControlChartDataset
                {
                    Title = ""Alpha"",
                    Data = new ControlChartDatasetPointCollection(3f, 7f, 5f),
                    BackgroundColor = ""gold"",
                    BorderColor = ""red"",
                    BorderWidth = 2
                }",
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Style",
                    TitleDisplay = _ => true,
                    Height = _ => 220,
                    YBeginAtZero = _ => true
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
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Highlight",
                        Data = new ControlChartDatasetPointCollection(6f, 2f, 3f),
                        BackgroundColor = new PropertyColorChart(TypeColorChart.Highlight).ToString()
                    })
            );

            Stage.AddProperty
            (
                "Datasets (Fill, Point)",
                "Fill turns a line into an area chart, filled down to the origin, the start or the end of the axis. Point sets the marker shape of a line, radar or scatter dataset, so series stay apart without relying on their color.",
                @"
                new ControlChartDataset
                {
                    Title = ""Visitors"",
                    Data = new ControlChartDatasetPointCollection(4f, 7f, 6f, 9f, 8f),
                    Fill = TypeFillChart.Origin,
                    Point = TypePointChart.Rect
                }",
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Traffic",
                    TitleDisplay = _ => true,
                    Height = _ => 240,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("Mon", "Tue", "Wed", "Thu", "Fri")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Visitors",
                        Data = new ControlChartDatasetPointCollection(4f, 7f, 6f, 9f, 8f),
                        Fill = TypeFillChart.Origin,
                        Point = TypePointChart.Rect
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Orders",
                        Data = new ControlChartDatasetPointCollection(2f, 3f, 5f, 4f, 6f),
                        Point = TypePointChart.Triangle
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Returns",
                        Data = new ControlChartDatasetPointCollection(1f, 1f, 2f, 1f, 2f),
                        Point = TypePointChart.Rhombus
                    })
            );

            Stage.AddProperty
            (
                "Datasets (Curve, Tension)",
                "Curve sets how a line dataset runs between its points. Straight segments keep the single values in front. A Bezier curve reads as a continuous course; Tension sets how far it swings out, from 0 (straight) to 1, with 0.4 as default. Between two points a Bezier curve may swing past their values - a monotone curve does not, so every peak in the drawing is a peak in the data, which suits measured values.",
                @"
                new ControlChartDataset
                {
                    Title = ""Monotone"",
                    Data = new ControlChartDatasetPointCollection(4f, 5f, 16f, 6f, 7f, 18f, 8f),
                    Curve = TypeCurveChart.Monotone
                }",
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Straight, Bezier and Monotone",
                    TitleDisplay = _ => true,
                    Height = _ => 260,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("1", "2", "3", "4", "5", "6", "7")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Straight",
                        Data = new ControlChartDatasetPointCollection(4f, 5f, 16f, 6f, 7f, 18f, 8f)
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Bezier",
                        Data = new ControlChartDatasetPointCollection(14f, 15f, 26f, 16f, 17f, 28f, 18f),
                        Curve = TypeCurveChart.Bezier
                    })
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Monotone",
                        Data = new ControlChartDatasetPointCollection(24f, 25f, 36f, 26f, 27f, 38f, 28f),
                        Curve = TypeCurveChart.Monotone
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Smooth Area",
                    TitleDisplay = _ => true,
                    Height = _ => 240,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Load",
                        Data = new ControlChartDatasetPointCollection(32f, 45f, 41f, 58f, 52f, 30f, 24f),
                        Curve = TypeCurveChart.Bezier,
                        Tension = 0.5f,
                        Fill = TypeFillChart.Origin
                    })
            );

            Stage.AddProperty
            (
                "Datasets (Trendline)",
                "A trendline shows the direction of a dataset besides its single values. A linear trendline is fitted by least squares and shows the overall direction; a moving average smooths out the noise over a window of TrendlinePeriod points (three by default) and keeps the course. The trendline is drawn dashed in a shade of its series, appears in the tooltip and in the data table and is hidden together with its series. It applies to line, bar, scatter and bubble charts; radial charts have no course to draw it along.",
                @"
                new ControlChartDataset
                {
                    Title = ""Revenue"",
                    Data = new ControlChartDatasetPointCollection(12f, 15f, 13f, 18f, 17f, 21f, 24f),
                    Trendline = TypeTrendlineChart.Linear
                }",
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Linear Trend",
                    TitleDisplay = _ => true,
                    Height = _ => 240
                }
                    .AddLabel("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Revenue",
                        Data = new ControlChartDatasetPointCollection(12f, 15f, 13f, 18f, 17f, 21f, 24f),
                        Trendline = TypeTrendlineChart.Linear
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Bar,
                    Title = _ => "Moving Average",
                    TitleDisplay = _ => true,
                    Height = _ => 240,
                    YBeginAtZero = _ => true
                }
                    .AddLabel("W1", "W2", "W3", "W4", "W5", "W6", "W7", "W8", "W9", "W10")
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Tickets",
                        Data = new ControlChartDatasetPointCollection(14f, 9f, 17f, 12f, 20f, 15f, 23f, 18f, 26f, 21f),
                        Trendline = TypeTrendlineChart.MovingAverage,
                        TrendlinePeriod = 3
                    }),
                new ControlChart()
                {
                    Type = _ => TypeChart.Scatter,
                    Title = _ => "Correlation",
                    TitleDisplay = _ => true,
                    TitleX = _ => "Ad spend (k)",
                    TitleY = _ => "Orders",
                    Height = _ => 240
                }
                    .AddDataset(new ControlChartDataset
                    {
                        Title = "Campaigns",
                        Data = new ControlChartDatasetPointCollection
                        (
                            new ControlChartDatasetPointScatter(1, 12),
                            new ControlChartDatasetPointScatter(2, 15),
                            new ControlChartDatasetPointScatter(2.5f, 21),
                            new ControlChartDatasetPointScatter(3, 19),
                            new ControlChartDatasetPointScatter(4, 26),
                            new ControlChartDatasetPointScatter(4.5f, 24),
                            new ControlChartDatasetPointScatter(5, 31),
                            new ControlChartDatasetPointScatter(6, 33)
                        ),
                        Trendline = TypeTrendlineChart.Linear
                    })
            );

            Stage.AddProperty
            (
                "Height, Width",
                "The height sets the vertical size of the drawing in pixels; without it the chart is 300 pixels high. The chart takes the width of its container and redraws itself when the container changes size; Width caps it at a fixed number of pixels.",
                "Height = _ => 200; Width = _ => 480;",
                new ControlChart()
                {
                    Type = _ => TypeChart.Line,
                    Title = _ => "Height Example",
                    TitleDisplay = _ => true,
                    Height = _ => 200,
                    Width = _ => 480,
                    YBeginAtZero = _ => true
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
