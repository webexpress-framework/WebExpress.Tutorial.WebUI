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
                        Title = _ => "System Status",
                        Icon = _ => new IconDiagramProject(),
                        Color = _ => "blue",
                        Column = _ => 0,
                        Widget = _ => "system"
                    },
                    new ControlDashboardWidget("widget2")
                    {
                        Title = _ => "User",
                        Icon = _ => new IconUser(),
                        Color = _ => "green",
                        Column = _ => 1,
                        Widget = _ => "users"
                    },
                    new ControlDashboardWidget("widget3")
                    {
                        Title = _ => "Analytics",
                        Icon = _ => new IconChartDiagram(),
                        Color = _ => "orange",
                        Column = _ => 2,
                        Widget = _ => "analytics"
                    }
                );

            var content1 = new ControlDashboardWidgetContent()
                .Add(new ControlText() { Text = _ => "System Status: OK" });

            var content2 = new ControlDashboardWidgetContent()
                .Add(new ControlText() { Text = _ => "Active users: 42" });

            var content3 = new ControlDashboardWidgetContent()
                .Add(new ControlText() { Text = _ => "Analytics data is loading" });

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
                        Title = _ => ""System Status"",
                        Icon = _ => new IconDiagramProject(),
                        Color = _ => ""blue"",
                        Column = _ => 0,
                        Widget = _ => ""system""
                    },
                    new ControlDashboardWidget(""widget2"")
                    {
                        Title = _ => ""User"",
                        Icon = _ => new IconUser(),
                        Color = _ => ""green"",
                        Column = _ => 1,
                        Widget = _ => ""users""
                    },
                    new ControlDashboardWidget(""widget3"")
                    {
                        Title = _ => ""Analytics"",
                        Icon = _ => new IconChart(),
                        Color = _ => ""orange"",
                        Column = _ => 2,
                        Widget = _ => ""analytics""
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
                "Title = _ => \"Title\"",
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (
                    new ControlDashboardWidget("widget1")
                    {
                        Title = _ => "Title",
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Icon",
                "The `Icon` property specifies the visual symbol displayed alongside the widget’s title. It provides an immediate visual cue that helps users recognize the widget’s purpose or category at a glance. Icons improve scannability, support intuitive navigation within dashboards, and contribute to a consistent and expressive visual language across the interface.",
                "Title = _ => \"Title\"",
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (
                    new ControlDashboardWidget("widget1")
                    {
                        Icon = _ => new IconHome(),
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Movable",
                "The `Movable` property determines whether a widget can be repositioned within the dashboard layout. When enabled, users can drag the widget to a different column or position, allowing flexible customization of the dashboard’s structure. When disabled, the widget remains fixed in place, ensuring a stable layout for essential or system‑defined components.",
                "Movable = _ => false",
                new ControlText() { Text = _ => "default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                ),
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Movable = _ => false,
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                ),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Movable = _ => true,
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Closeable",
                "The `Closeable` property determines whether a widget can be removed from the dashboard by the user. When enabled, the widget displays a close control that allows users to hide or dismiss it, providing flexibility for personalizing the dashboard layout. When disabled, the widget remains permanently visible, ensuring that essential or system‑defined components cannot be accidentally removed.",
                "Closeable = _ => false",
                new ControlText() { Text = _ => "default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                ),
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Closeable = _ => false,
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                ),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Closeable = _ => true,
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                )
            );

            Stage.AddItemProperty
            (
                typeof(ControlDashboardWidget),
                "Color",
                "The `Color` property defines the accent color used to visually distinguish the widget. It can be applied to elements such as the header, border, or icon, helping users quickly identify categories, priorities, or thematic groupings within the dashboard. By customizing the widget’s color, interfaces can achieve clearer visual hierarchy, improved scannability, and a more expressive overall design.",
                "Color = _ => \"#ff0000\"",
                new ControlDashboard(RandomId.Create())
                .Add
                (
                    new ControlDashboardColumn("column", "Column", "auto")
                )
                .Add
                (

                    new ControlDashboardWidget("widget1")
                    {
                        Color = _ => "#ff0000",
                        Column = _ => 0,
                        Widget = _ => "system"
                    }
                )
            );
        }
    }
}