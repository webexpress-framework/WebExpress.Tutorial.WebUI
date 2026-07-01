using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the read-only heat map control for the tutorial.
    /// </summary>
    [Title("Heat Map")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class HeatMap : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public HeatMap()
        {
            Stage.Description = @"The `HeatMap` control is a read-only data visualization. It renders a grid of numeric values and colours each cell on a gradient from a low to a high colour, making patterns and outliers - busy days, hot spots, gaps - easy to spot at a glance.";

            Stage.Control = new ControlHeatMap()
            {
                Values = _ =>
                [
                    [1.0, 3.0, 2.0, 5.0, 8.0, 9.0, 4.0],
                    [2.0, 1.0, 4.0, 6.0, 7.0, 3.0, 1.0],
                    [0.0, 2.0, 3.0, 8.0, 9.0, 6.0, 2.0]
                ],
                RowLabels = _ => ["Week 1", "Week 2", "Week 3"],
                ColumnLabels = _ => ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"]
            };

            Stage.Code = @"
                new ControlHeatMap()
                {
                    Values = _ =>
                    [
                        [1.0, 3.0, 2.0, 5.0, 8.0, 9.0, 4.0],
                        [2.0, 1.0, 4.0, 6.0, 7.0, 3.0, 1.0],
                        [0.0, 2.0, 3.0, 8.0, 9.0, 6.0, 2.0]
                    ],
                    RowLabels = _ => [""Week 1"", ""Week 2"", ""Week 3""],
                    ColumnLabels = _ => [""Mon"", ""Tue"", ""Wed"", ""Thu"", ""Fri"", ""Sat"", ""Sun""]
                };";

            Stage.AddProperty
            (
                "Values",
                "The `Values` property holds the grid as a sequence of rows, each a sequence of cell values. Rows may differ in length; a missing cell renders as a dashed placeholder rather than a low value.",
                "Values = _ => [[1, 2, 3], [4, 5, 6]]",
                new ControlHeatMap()
                {
                    Values = _ =>
                    [
                        [1.0, 2.0, 3.0, 4.0],
                        [5.0, 6.0, 7.0, 8.0],
                        [9.0, 10.0, 11.0, 12.0]
                    ]
                }
            );

            Stage.AddProperty
            (
                "Min / Max",
                "The `Min` and `Max` properties fix the value range mapped to the gradient. When left unset, the range spans the data so the full gradient is always used; fixing them makes several heat maps directly comparable.",
                "Min = _ => 0, Max = _ => 10",
                new ControlText() { Text = _ => "Auto range (spans the data)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlHeatMap()
                {
                    Values = _ => [[1.0, 2.0, 3.0], [4.0, 5.0, 6.0]]
                },
                new ControlText() { Text = _ => "Fixed range 0..20", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlHeatMap()
                {
                    Values = _ => [[1.0, 2.0, 3.0], [4.0, 5.0, 6.0]],
                    Min = _ => 0,
                    Max = _ => 20
                }
            );

            Stage.AddProperty
            (
                "Color",
                "The `LowColor` and `HighColor` properties define the gradient endpoints as any hex colour. The cells are interpolated linearly between them.",
                "LowColor = _ => \"#fee8c8\", HighColor = _ => \"#b30000\"",
                new ControlText() { Text = _ => "Blue (default)", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlHeatMap()
                {
                    Values = _ => [[1.0, 4.0, 9.0], [2.0, 6.0, 8.0]]
                },
                new ControlText() { Text = _ => "Orange / red", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlHeatMap()
                {
                    Values = _ => [[1.0, 4.0, 9.0], [2.0, 6.0, 8.0]],
                    LowColor = _ => "#fee8c8",
                    HighColor = _ => "#b30000"
                },
                new ControlText() { Text = _ => "Green", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlHeatMap()
                {
                    Values = _ => [[1.0, 4.0, 9.0], [2.0, 6.0, 8.0]],
                    LowColor = _ => "#e5f5e0",
                    HighColor = _ => "#00441b"
                }
            );

            Stage.AddProperty
            (
                "RowLabels / ColumnLabels",
                "The `RowLabels` and `ColumnLabels` properties annotate the vertical and horizontal axes. They are optional; without them the grid renders as bare cells.",
                "RowLabels = _ => [\"A\", \"B\"], ColumnLabels = _ => [\"x\", \"y\", \"z\"]",
                new ControlHeatMap()
                {
                    Values = _ => [[3.0, 7.0, 2.0], [5.0, 1.0, 8.0]],
                    RowLabels = _ => ["A", "B"],
                    ColumnLabels = _ => ["x", "y", "z"]
                }
            );
        }
    }
}
