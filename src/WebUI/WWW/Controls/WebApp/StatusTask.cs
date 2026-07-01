using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WebTask;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTask;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the status task (dot) control demo for the tutorial.
    /// </summary>
    [Title("StatusTask")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class StatusTask : PageControl
    {
        private const string TaskId = "sword-fighting-insult-status-task";
        private readonly ITaskManager _taskManager;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="taskManager">The task manager.</param>
        public StatusTask(ITaskManager taskManager)
        {
            _taskManager = taskManager;

            Stage.AddEvent(Event.TASK_UPDATE_EVENT, Event.TASK_FINISH_EVENT, Event.SHOW_EVENT, Event.HIDE_EVENT);

            Stage.Description = @"`ControlStatusTask` condenses the same live task lifecycle that `ControlProgressTask` shows as a bar into a single colored dot: **red** for an error, **green** for done, **yellow** for a warning, **blue** for a running task and **gray** for a pending one. Updates arrive over the MessageQueue WebSocket (see `WebExpress.WebApp.WebMessageQueue.ProgressTaskDispatcher`) - the same channel and the same `webexpress.webapp.progresstask.update` message the progress bar consumes - so the dot reflects the server state without any HTTP polling and survives page navigation, transient disconnects and multiple windows.

A dot and a `ControlProgressTask` bound to the same `TaskId` update in lockstep. Left without a `TaskId` the control renders the static `Status`, which is the way to show a plain status point in a dense surface (a table row, a list item, a header) that is not backed by a running task.";

            Stage.Controls =
            [
                new ControlStatusTask("myStatus")
                {
                    TaskId = _ => CreateTask()
                }
            ];

            Stage.Code = @"
            new ControlStatusTask(""myStatus"")
            {
                TaskId = _ => ""sword-fighting-insult-status-task""
            }";

            Stage.AddProperty
            (
                "Status",
                "The `Status` property paints a static dot when the control is not driven by a task. It carries the full palette - `Pending` (gray), `Running` (blue), `Warning` (yellow), `Error` (red) and `Done` (green) - so a status point can be shown inline without a running task.",
                "new ControlStatusTask(\"a\") { Status = _ => TypeStatusTask.Warning }",
                new ControlStatusTask("status-pending")
                {
                    Status = _ => TypeStatusTask.Pending,
                    Label = _ => "Pending"
                },
                new ControlStatusTask("status-running")
                {
                    Status = _ => TypeStatusTask.Running,
                    Label = _ => "Running"
                },
                new ControlStatusTask("status-warning")
                {
                    Status = _ => TypeStatusTask.Warning,
                    Label = _ => "Warning"
                },
                new ControlStatusTask("status-error")
                {
                    Status = _ => TypeStatusTask.Error,
                    Label = _ => "Error"
                },
                new ControlStatusTask("status-done")
                {
                    Status = _ => TypeStatusTask.Done,
                    Label = _ => "Done"
                }
            );

            Stage.AddProperty
            (
                "TaskId",
                "The `TaskId` property specifies the unique identifier of the task to follow. The client side `StatusTaskCtrl` filters incoming `webexpress.webapp.progresstask.update` messages by this id and maps the task state to the dot color, so the dot coexists with every other MessageQueue consumer and with a `ControlProgressTask` bound to the same task.",
                "TaskId = _ => \"abc123\"",
                new ControlStatusTask("statusid-demo")
                {
                    TaskId = _ => "abc123"
                }
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property renders a caption next to the dot and doubles as its tooltip. Without a label a task driven dot uses the server message and otherwise the translated status name.",
                "Label = _ => \"Deployment\"",
                new ControlStatusTask("status-label")
                {
                    Status = _ => TypeStatusTask.Done,
                    Label = _ => "Deployment"
                }
            );

            Stage.AddProperty
            (
                "ShowOnStart",
                "The `ShowOnStart` property keeps the dot hidden until the first update for the task arrives.",
                "ShowOnStart = _ => true",
                new ControlStatusTask("status-showonstart")
                {
                    Display = _ => TypeDisplay.None,
                    TaskId = _ => CreateTask(),
                    ShowOnStart = _ => true
                }
            );

            Stage.AddProperty
            (
                "HideOnFinish",
                "The `HideOnFinish` property hides the dot once the task finishes or is canceled.",
                "HideOnFinish = _ => true",
                new ControlStatusTask("status-hideonfinish")
                {
                    TaskId = _ => CreateTask(),
                    HideOnFinish = _ => true
                }
            );
        }

        /// <summary>
        /// Creates and runs a new <see cref="MonkeyIslandInsultTask"/>.
        /// </summary>
        /// <remarks>The created task is immediately started.</remarks>
        /// <returns>The unique identifier of the created task.</returns>
        private string CreateTask()
        {
            var task = _taskManager.CreateTask<MonkeyIslandInsultTask>(TaskId, null);
            task.Run();

            return task.Id;
        }
    }
}
