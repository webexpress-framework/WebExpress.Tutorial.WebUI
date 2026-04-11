using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the dashboard control for the tutorial.
    /// </summary>
    [Title("Dashboard")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Dashboard : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Dashboard(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description =
                @"The `Dashboard` control organizes widgets into columns. Each widget provides metadata (title, icon, color, column) and can optionally contain content controls.";

            var dashboard = new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("state", "System Status", "25%"),
                    new ControlDashboardColumn("users", "Users", "50%"),
                    new ControlDashboardColumn("analytics", "Analytics", "*")
                )
                .Add(
                    new ControlDashboardWidget("widget1")
                    {
                        Title = "System Status",
                        Icon = new IconDiagramProject(),
                        Color = "blue",
                        Column = 0,
                        Widget = "system"
                    },
                    new ControlDashboardWidget("widget2")
                    {
                        Title = "User",
                        Icon = new IconUser(),
                        Color = "green",
                        Column = 1,
                        Widget = "users"
                    },
                    new ControlDashboardWidget("widget3")
                    {
                        Title = "Analytics",
                        Icon = new IconChartDiagram(),
                        Color = "orange",
                        Column = 2,
                        Widget = "analytics"
                    }
                );

            var content1 = new ControlDashboardWidgetContent()
                .Add(new ControlText() { Text = "System Status: OK" });

            var content2 = new ControlDashboardWidgetContent()
                .Add(new ControlText() { Text = "Active users: 42" });

            var content3 = new ControlDashboardWidgetContent()
                .Add(new ControlText() { Text = "Analytics data is loading" });

            dashboard.Add(content1, content2, content3);

            Stage.Control = dashboard;

            Stage.Code = @"
            new ControlDashboard(RandomId.Create())
                .AddColumns
                (
                    new ControlDashboardColumn(""state"", ""System Status"", ""25%""),
                    new ControlDashboardColumn(""users"", ""Users"", ""50%""),
                    new ControlDashboardColumn(""analytics"", ""Analytics"", ""*"")
                )
                .Add(
                    new ControlDashboardWidget(""widget1"")
                    {
                        Title = ""System Status"",
                        Icon = new IconDiagramProject(),
                        Color = ""blue"",
                        Column = 0,
                        Widget = ""system""
                    },
                    new ControlDashboardWidget(""widget2"")
                    {
                        Title = ""User"",
                        Icon = new IconUser(),
                        Color = ""green"",
                        Column = 1,
                        Widget = ""users""
                    },
                    new ControlDashboardWidget(""widget3"")
                    {
                        Title = ""Analytics"",
                        Icon = new IconChart(),
                        Color = ""orange"",
                        Column = 2,
                        Widget = ""analytics""
                    }
                );";

            Stage.AddItem
            (
                typeof(ControlDashboardWidget),
                "ControlDashboardWidget",
                "A `ControlDashboardWidget` represents a self‑contained visual unit within a dashboard layout. Each widget encapsulates a specific piece of information, a metric, or an interactive element, allowing dashboards to be composed from modular, reusable building blocks. Widgets are placed into dashboard columns, can display charts, numbers, lists, or system‑defined components, and provide a consistent structure for presenting data in a clear and scannable way. By separating content into individual widgets, dashboards remain flexible, maintainable, and easy to extend with additional insights or functionality.",
                "new ControlDashboard(RandomId.Create())",
                new ControlDashboard(RandomId.Create())
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Title",
                "The `Title` property defines the human‑readable heading displayed at the top of the widget. It serves as the primary label that identifies the widget’s purpose and helps users quickly understand the type of information or functionality it provides. A well‑chosen title improves scannability, supports intuitive navigation within dashboards, and ensures that widgets remain meaningful even when displayed in compact or multi‑column layouts.",
                "Title = \"Title\"",
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (
                    new ControlDashboardWidget("widget1")
                    {
                        Title = "Title",
                        Column = 0,
                        Widget = "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Icon",
                "The `Icon` property specifies the visual symbol displayed alongside the widget’s title. It provides an immediate visual cue that helps users recognize the widget’s purpose or category at a glance. Icons improve scannability, support intuitive navigation within dashboards, and contribute to a consistent and expressive visual language across the interface.",
                "Title = \"Title\"",
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (
                    new ControlDashboardWidget("widget1")
                    {
                        Icon = new IconHome(),
                        Column = 0,
                        Widget = "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Movable",
                "The `Movable` property determines whether a widget can be repositioned within the dashboard layout. When enabled, users can drag the widget to a different column or position, allowing flexible customization of the dashboard’s structure. When disabled, the widget remains fixed in place, ensuring a stable layout for essential or system‑defined components.",
                "Movable = false",
                new ControlText() { Text = "default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Column = 0,
                        Widget = "system"
                    }
                ),
                new ControlText() { Text = "false", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Movable = false,
                        Column = 0,
                        Widget = "system"
                    }
                ),
                new ControlText() { Text = "true", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Movable = true,
                        Column = 0,
                        Widget = "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Closeable",
                "The `Closeable` property determines whether a widget can be removed from the dashboard by the user. When enabled, the widget displays a close control that allows users to hide or dismiss it, providing flexibility for personalizing the dashboard layout. When disabled, the widget remains permanently visible, ensuring that essential or system‑defined components cannot be accidentally removed.",
                "Closeable = false",
                new ControlText() { Text = "default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Column = 0,
                        Widget = "system"
                    }
                ),
                new ControlText() { Text = "false", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Closeable = false,
                        Column = 0,
                        Widget = "system"
                    }
                ),
                new ControlText() { Text = "true", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Closeable = true,
                        Column = 0,
                        Widget = "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Color",
                "The `Color` property defines the accent color used to visually distinguish the widget. It can be applied to elements such as the header, border, or icon, helping users quickly identify categories, priorities, or thematic groupings within the dashboard. By customizing the widget’s color, interfaces can achieve clearer visual hierarchy, improved scannability, and a more expressive overall design.",
                "Color = \"#ff0000\"",
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Color = "#ff0000",
                        Column = 0,
                        Widget = "system"
                    }
                )
            );
        }
    }
}