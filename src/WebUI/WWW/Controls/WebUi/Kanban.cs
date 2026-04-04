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
    /// Represents a simple kanban test board for demonstration purposes.
    /// </summary>
    [Title("Kanban")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class RestKanban : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestKanban(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MOVE_EVENT);

            Stage.Description = @"A `Kanban` control provides a column‑based layout for visual workflow management. Each column represents a process stage (e.g., To Do, In Progress, Done), while each card represents a movable work item. Cards can be rearranged or moved between columns, enabling intuitive drag‑and‑drop interaction and progress tracking. The control also supports swimlanes: horizontal lanes that group related work items across all columns. Swimlanes allow parallel workflows (e.g., Priority, Teams, Categories) to be displayed within the same board, providing an additional structural dimension for organizing and filtering tasks.";

            var kanban = new ControlKanban(RandomId.Create())
                .Add
                (
                    new ControlKanbanColumn("todo", "To Do", "33%"),
                    new ControlKanbanColumn("progress", "In Progress", "33%"),
                    new ControlKanbanColumn("done", "Done", "*")
                )
                .Add
                (
                    new ControlKanbanSwimlane("height", "Height"),
                    new ControlKanbanSwimlane("priority", "Priority"),
                    new ControlKanbanSwimlane("team", "Team")
                );

            kanban.Add
            (
                new ControlKanbanCard("task1")
                {
                    Title = "Write Documentation",
                    Icon = new IconFileCode(),
                    Color = "blue",
                    ColumnId = "progress",
                    SwimlaneId = "height"
                },

                new ControlKanbanCard("task2")
                {
                    Title = "Implement Feature X",
                    Icon = new IconGears(),
                    Color = "orange",
                    ColumnId = "todo",
                    SwimlaneId = "priority"
                },

                new ControlKanbanCard("task3")
                {
                    Title = "Fix Bug #42",
                    Icon = new IconBug(),
                    Color = "green",
                    ColumnId = "done",
                    SwimlaneId = "team"
                },

                new ControlKanbanCard("task4")
                {
                    Title = "Refactor Data Layer",
                    Icon = new IconDatabase(),
                    Color = "purple",
                    ColumnId = "progress",
                    SwimlaneId = "team"
                },

                new ControlKanbanCard("task5")
                {
                    Title = "Design UI Mockups",
                    Icon = new IconPalette(),
                    Color = "pink",
                    ColumnId = "todo",
                    SwimlaneId = "height"
                },

                new ControlKanbanCard("task6")
                {
                    Title = "Prepare Release Notes",
                    Icon = new IconFilePdf(),
                    Color = "cyan",
                    ColumnId = "done",
                    SwimlaneId = "priority"
                }
            );

            Stage.Control = kanban;

            Stage.Code = @"
            var kanban = new ControlKanban(RandomId.Create())
                .Add
                (
                    new ControlKanbanColumn(""todo"", ""To Do"", ""33%""),
                    new ControlKanbanColumn(""progress"", ""In Progress"", ""33%""),
                    new ControlKanbanColumn(""done"", ""Done"", ""*"")
                )
                .Add
                (
                    new ControlKanbanSwimlane(""height"", ""Height""),
                    new ControlKanbanSwimlane(""priority"", ""Priority""),
                    new ControlKanbanSwimlane(""team"", ""Team"")
                );

            kanban.Add
            (
                new ControlKanbanCard(""task1"")
                {
                    Title = ""Write Documentation"",
                    Icon = new IconFileCode(),
                    Color = ""blue"",
                    ColumnId = ""progress"",
                    SwimlaneId = ""height""
                },

                new ControlKanbanCard(""task2"")
                {
                    Title = ""Implement Feature X"",
                    Icon = new IconGears(),
                    Color = ""orange"",
                    ColumnId = ""todo"",
                    SwimlaneId = ""priority""
                },

                new ControlKanbanCard(""task3"")
                {
                    Title = ""Fix Bug #42"",
                    Icon = new IconBug(),
                    Color = ""green"",
                    ColumnId = ""done"",
                    SwimlaneId = ""team""
                },

                new ControlKanbanCard(""task4"")
                {
                    Title = ""Refactor Data Layer"",
                    Icon = new IconDatabase(),
                    Color = ""purple"",
                    ColumnId = ""progress"",
                    SwimlaneId = ""team""
                },

                new ControlKanbanCard(""task5"")
                {
                    Title = ""Design UI Mockups"",
                    Icon = new IconPalette(),
                    Color = ""pink"",
                    ColumnId = ""todo"",
                    SwimlaneId = ""height""
                },

                new ControlKanbanCard(""task6"")
                {
                    Title = ""Prepare Release Notes"",
                    Icon = new IconFilePdf(),
                    Color = ""cyan"",
                    ColumnId = ""done"",
                    SwimlaneId = ""priority""
                }
            );";

            Stage.AddItem
            (
                "Expanded",
                "Determines whether the swimlane is currently expanded or collapsed. When set to true, the swimlane displays all contained items and controls. When set to false, the swimlane is collapsed and only its header remains visible. This property is typically used to manage visual density, reduce clutter, and allow users to focus on selected sections within a Kanban board.",
                "new ControlKanbanSwimlane(\"height\", \"Height\", true)",
                new ControlText()
                {
                    Text = "None",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlKanban(RandomId.Create())
                .Add
                (
                    new ControlKanbanColumn("todo", "To Do", "33%"),
                    new ControlKanbanColumn("progress", "In Progress", "33%"),
                    new ControlKanbanColumn("done", "Done", "*")
                )
                .Add
                (
                    new ControlKanbanSwimlane("height", "Height"),
                    new ControlKanbanSwimlane("priority", "Priority"),
                    new ControlKanbanSwimlane("team", "Team")
                ),
                new ControlText()
                {
                    Text = "true",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlKanban(RandomId.Create())
                .Add
                (
                    new ControlKanbanColumn("todo", "To Do", "33%"),
                    new ControlKanbanColumn("progress", "In Progress", "33%"),
                    new ControlKanbanColumn("done", "Done", "*")
                )
                .Add
                (
                    new ControlKanbanSwimlane("height", "Height", true),
                    new ControlKanbanSwimlane("priority", "Priority", true),
                    new ControlKanbanSwimlane("team", "Team", true)
                ),
                new ControlText()
                {
                    Text = "false",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlKanban(RandomId.Create())
                .Add
                (
                    new ControlKanbanColumn("todo", "To Do", "33%"),
                    new ControlKanbanColumn("progress", "In Progress", "33%"),
                    new ControlKanbanColumn("done", "Done", "*")
                )
                .Add
                (
                    new ControlKanbanSwimlane("height", "Height", false),
                    new ControlKanbanSwimlane("priority", "Priority", false),
                    new ControlKanbanSwimlane("team", "Team", false)
                )
            );
        }
    }
}