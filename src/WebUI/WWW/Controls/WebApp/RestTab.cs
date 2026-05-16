using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the tab control for the tutorial.    
    /// </summary>    
    [Title("RestTab")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestTab : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public RestTab(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.SELECTED_TAB_EVENT, Event.TAB_ADDED_EVENT, Event.TAB_CLOSED_EVENT);

            Stage.Description = @"The `RestTab` control serves as a container for REST-driven tab views. This example provides three selectable templates (`dashboard`, `backlog`, and `table`) so new tabs can be created with different layouts.";

            Stage.Control = new ControlRestTab(RandomId.Create())
            {
                RestUri = _ => sitemapManager.GetUri<MonkeyIslandTab>(pageContext.ApplicationContext),
            }
                .Add
                (
                    new ControlRestTabTemplate("monkeyTemplate")
                    {
                        Icon = _ => new IconDiagramProject(),
                        Name = _ => "Dashboard",
                        Description = _ => "Dashboard template",
                        Multiplicity = _ => 5,
                        Bind = _ => new Binding().Add(new BindTemplate()
                            .Add("title", TypeBindMode.Text, ".wx-resttab-dashboard-title")
                            .Add("uri", TypeBindMode.Attr, ".wx-webui-dashboard", "data-uri")
                            .Add("isActive", TypeBindMode.Toggle, ".wx-webui-dashboard", "active"))
                    }
                        .Add(new ControlText("dashboard-title")
                        {
                            Text = _ => "Dashboard template",
                            Classes = ["wx-resttab-dashboard-title"]
                        })
                        .Add
                        (
                            new ControlDashboard("dashboard-template")
                                .Add
                                (
                                    new ControlDashboardColumn("dash-col-1", "Overview", "50%"),
                                    new ControlDashboardColumn("dash-col-2", "Status", "*")
                                )
                                .Add
                                (
                                    new ControlDashboardWidget("dash-widget-1")
                                    {
                                        Title = _ => "Progress",
                                        Icon = _ => new IconChartDiagram(),
                                        Column = _ => 0,
                                        Widget = _ => "progress"
                                    },
                                    new ControlDashboardWidget("dash-widget-2")
                                    {
                                        Title = _ => "Crew",
                                        Icon = _ => new IconUser(),
                                        Column = _ => 1,
                                        Widget = _ => "crew"
                                    }
                                )
                        ),
                    new ControlRestTabTemplate("backlogTemplate")
                    {
                        Icon = _ => new IconListCheck(),
                        Name = _ => "Backlog",
                        Description = _ => "Scrum backlog template",
                        Bind = _ => new Binding().Add(new BindTemplate()
                            .Add("name", TypeBindMode.Text, ".wx-resttab-backlog-title")
                            .Add("uri", TypeBindMode.Attr, ".wx-webapp-scrum-backlog", "data-uri"))
                    }
                        .Add(new ControlText("backlog-title")
                        {
                            Text = _ => "Backlog template",
                            Classes = ["wx-resttab-backlog-title"]
                        })
                        .Add
                        (
                            new ControlRestScrumBacklog("template-backlog")
                            {
                                RestUri = _ => sitemapManager.GetUri<RestApiScrum>(pageContext.ApplicationContext),
                                Title = _ => "Monkey Island Product Backlog",
                                Selectable = _ => true,
                                IconActive = _ => "fas fa-skull-crossbones",
                                IconPlanned = _ => "fas fa-hourglass-half",
                                IconBacklog = _ => "fas fa-map"
                            }
                        ),
                    new ControlRestTabTemplate("tableTemplate")
                    {
                        Icon = _ => new IconTable(),
                        Name = _ => "Table",
                        Description = _ => "Table template",
                        Bind = _ => new Binding().Add(new BindTemplate()
                            .Add("title", TypeBindMode.Text, ".wx-resttab-table-title"))
                    }
                        .Add(new ControlText("table-title")
                        {
                            Text = _ => "Table template",
                            Classes = ["wx-resttab-table-title"]
                        })
                        .Add
                        (
                            new ControlTable("template-table")
                                .AddColumns
                                (
                                    new ControlTableColumn("col-key") { Title = _ => "Key" },
                                    new ControlTableColumn("col-value") { Title = _ => "Value" }
                                )
                                .AddRows
                                (
                                    new ControlTableRow("row-1")
                                        .Add
                                        (
                                            new ControlTableCell() { Text = _ => "Ship" },
                                            new ControlTableCell() { Text = _ => "Sea Monkey" }
                                        ),
                                    new ControlTableRow("row-2")
                                        .Add
                                        (
                                            new ControlTableCell() { Text = _ => "Captain" },
                                            new ControlTableCell() { Text = _ => "Guybrush" }
                                        )
                                )
                        )
                );

            Stage.Code = @"
            new ControlRestTab(RandomId.Create())
            {
                RestUri = _ => sitemapManager.GetUri<MonkeyIslandTab>(pageContext.ApplicationContext),
            }
                .Add
                (
                    new ControlRestTabTemplate(""monkeyTemplate"")
                    {
                        Icon = _ => new IconDiagramProject(),
                        Name = _ => ""Dashboard"",
                        Description = _ => ""Dashboard template"",
                        Multiplicity = _ => 5,
                        Bind = _ => new BindTemplate()
                            .Add(""title"", TypeBindMode.Text, "".wx-resttab-dashboard-title"")
                            .Add(""uri"", TypeBindMode.Attr, "".wx-webui-dashboard"", ""data-uri"")
                            .Add(""isActive"", TypeBindMode.Toggle, "".wx-webui-dashboard"", ""active"")
                    }
                        .Add(new ControlText(""dashboard-title"")
                        {
                            Text = _ => ""Dashboard template"",
                            Classes = [""wx-resttab-dashboard-title""]
                        })
                        .Add
                        (
                            new ControlDashboard(""dashboard-template"")
                                .Add
                                (
                                    new ControlDashboardColumn(""dash-col-1"", ""Overview"", ""50%""),
                                    new ControlDashboardColumn(""dash-col-2"", ""Status"", ""*"")
                                )
                                .Add
                                (
                                    new ControlDashboardWidget(""dash-widget-1"")
                                    {
                                        Title = _ => ""Progress"",
                                        Icon = _ => new IconChartDiagram(),
                                        Column = _ => 0,
                                        Widget = _ => ""progress""
                                    },
                                    new ControlDashboardWidget(""dash-widget-2"")
                                    {
                                        Title = _ => ""Crew"",
                                        Icon = _ => new IconUser(),
                                        Column = _ => 1,
                                        Widget = _ => ""crew""
                                    }
                                )
                        ),
                    new ControlRestTabTemplate(""backlogTemplate"")
                    {
                        Icon = _ => new IconListCheck(),
                        Name = _ => ""Backlog"",
                        Description = _ => ""Scrum backlog template"",
                        Bind = _ => new BindTemplate()
                            .Add(""name"", TypeBindMode.Text, "".wx-resttab-backlog-title"")
                            .Add(""uri"", TypeBindMode.Attr, "".wx-webapp-scrum-backlog"", ""data-uri"")
                    }
                        .Add(new ControlText(""backlog-title"")
                        {
                            Text = _ => ""Backlog template"",
                            Classes = [""wx-resttab-backlog-title""]
                        })
                        .Add
                        (
                            new ControlRestScrumBacklog(""template-backlog"")
                            {
                                RestUri = _ => sitemapManager.GetUri<RestApiScrum>(pageContext.ApplicationContext),
                                Title = _ => ""Monkey Island Product Backlog"",
                                Selectable = _ => true,
                                IconActive = _ => ""fas fa-skull-crossbones"",
                                IconPlanned = _ => ""fas fa-hourglass-half"",
                                IconBacklog = _ => ""fas fa-map""
                            }
                        ),
                    new ControlRestTabTemplate(""tableTemplate"")
                    {
                        Icon = _ => new IconTable(),
                        Name = _ => ""Table"",
                        Description = _ => ""Table template"",
                        Bind = _ => new BindTemplate()
                            .Add(""title"", TypeBindMode.Text, "".wx-resttab-table-title"")
                    }
                        .Add(new ControlText(""table-title"")
                        {
                            Text = _ => ""Table template"",
                            Classes = [""wx-resttab-table-title""]
                        })
                        .Add
                        (
                            new ControlTable(""template-table"")
                                .AddColumns
                                (
                                    new ControlTableColumn(""col-key"") { Title = _ => ""Key"" },
                                    new ControlTableColumn(""col-value"") { Title = _ => ""Value"" }
                                )
                                .AddRows
                                (
                                    new ControlTableRow(""row-1"")
                                        .Add
                                        (
                                            new ControlTableCell() { Text = _ => ""Ship"" },
                                            new ControlTableCell() { Text = _ => ""Sea Monkey"" }
                                        ),
                                    new ControlTableRow(""row-2"")
                                        .Add
                                        (
                                            new ControlTableCell() { Text = _ => ""Captain"" },
                                            new ControlTableCell() { Text = _ => ""Guybrush"" }
                                        )
                                )
                        )
                );";
        }
    }
}
