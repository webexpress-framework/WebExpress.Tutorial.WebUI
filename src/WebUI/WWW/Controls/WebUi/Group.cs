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
    /// Represents the group control demo page for the tutorial.
    /// </summary>
    [WebIcon<IconControlStat>]
    [Title("Group")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Group : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Group(IPageContext pageContext)
        {
            Stage.Description = @"The `Group` control lays items out as fields of one surface, divided by hairlines.

Things placed side by side are read as one statement about one subject, and the reader compares them - left as separate boxes they read as separate claims. The content is not the group's business: any control can be a field.

The dividers are why this is a control rather than a stylesheet. A rule on every field but the first is correct only until the row wraps; which field starts a row is a question about the laid-out geometry, so the control answers it after layout and again whenever the width changes.";

            Stage.Controls =
            [
                new ControlGroup
                (
                    null,
                    new ControlStat()
                    {
                        Icon = _ => new IconListCheck(),
                        Label = _ => "Issues",
                        Value = _ => "112",
                        Delta = _ => "+8 this week",
                        Trend = _ => TypeStatTrend.Up
                    },
                    new ControlStat()
                    {
                        Icon = _ => new IconUsers(),
                        Label = _ => "People",
                        Value = _ => "38"
                    },
                    new ControlStat()
                    {
                        Icon = _ => new IconUserGroup(),
                        Label = _ => "Teams",
                        Value = _ => "4"
                    },
                    new ControlStat()
                    {
                        Icon = _ => new IconBolt(),
                        Label = _ => "Activity today",
                        Value = _ => "6"
                    }
                )
            ];

            Stage.Code = @"
            new ControlGroup
            (
                null,
                new ControlStat()
                {
                    Icon = _ => new IconListCheck(),
                    Label = _ => ""Issues"",
                    Value = _ => ""112""
                },
                new ControlStat()
                {
                    Icon = _ => new IconUsers(),
                    Label = _ => ""People"",
                    Value = _ => ""38""
                }
            );";

            Stage.AddProperty
            (
                "Columns",
                "Fixes how many fields a row holds. The default lets the fields divide the available width between them, whatever their number.",
                "Columns = _ => 2",
                new ControlGroup
                (
                    null,
                    new ControlStat() { Icon = _ => new IconCoins(), Label = _ => "Revenue", Value = _ => "12.4k" },
                    new ControlStat() { Icon = _ => new IconChartLine(), Label = _ => "Sessions", Value = _ => "3,204" },
                    new ControlStat() { Icon = _ => new IconEye(), Label = _ => "Open rate", Value = _ => "57%" },
                    new ControlStat() { Icon = _ => new IconClock(), Label = _ => "Avg. time", Value = _ => "2m 40s" }
                )
                {
                    Columns = _ => 2
                }
            );

            Stage.AddProperty
            (
                "Spacing",
                "The room a field gives its content. A field holding a control needs none of its own - the control brings its padding - while bare text needs what a card would give it.",
                "Spacing = _ => TypeSpacingGroup.Wide",
                new ControlGroup
                (
                    null,
                    BuildProse("Organigramm", "Wer gehört zu welchem Team, wer entscheidet, wer vertritt."),
                    BuildProse("Richtlinien", "Verbindliche Regeln für Vorgänge, Fristen und Eskalation."),
                    BuildProse("Dokumente", "Vorlagen, Formulare und Checklisten der Organisation.")
                )
                {
                    Columns = _ => 3,
                    Spacing = _ => TypeSpacingGroup.Wide
                }
            );

            Stage.AddProperty
            (
                "Framed",
                "Draws the group as a bounded surface. A group placed inside something that already frames it - a card, a section with a guide line - turns this off so the two frames do not double up.",
                "Framed = _ => false",
                new ControlGroup
                (
                    null,
                    new ControlStat() { Icon = _ => new IconListCheck(), Label = _ => "Open", Value = _ => "24" },
                    new ControlStat() { Icon = _ => new IconCircleCheck(), Label = _ => "Closed", Value = _ => "88" },
                    new ControlStat() { Icon = _ => new IconClock(), Label = _ => "Overdue", Value = _ => "3" }
                )
                {
                    Framed = _ => false
                }
            );
        }

        /// <summary>
        /// Builds a field of prose - a heading over a sentence - to show that the group takes
        /// whatever it is given rather than only metrics.
        /// </summary>
        /// <param name="title">The heading.</param>
        /// <param name="text">The sentence beneath it.</param>
        /// <returns>The panel.</returns>
        private static IControl BuildProse(string title, string text)
        {
            var panel = new ControlPanel();

            panel.Add(new ControlText()
            {
                Text = _ => title,
                Format = _ => TypeFormatText.Bold
            });

            panel.Add(new ControlText()
            {
                Text = _ => text,
                TextColor = _ => new PropertyColorText(TypeColorText.Secondary),
                Format = _ => TypeFormatText.Paragraph
            });

            return panel;
        }
    }
}
