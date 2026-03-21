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
                .Add(
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
                .AddColumns(
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
        }
    }
}