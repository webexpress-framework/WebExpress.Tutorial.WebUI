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
    /// Represents the progress task control demo for the tutorial.
    /// </summary>
    [Title("ProgressTask")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class ProgressTask : PageControl
    {
        private const string TaskId = "sword-fighting-insult-task";
        private readonly ITaskManager _taskManager;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="taskManager">The task manager.</param>
        public ProgressTask(ITaskManager taskManager)
        {
            _taskManager = taskManager;

            Stage.AddEvent(Event.TASK_UPDATE_EVENT, Event.TASK_FINISH_EVENT, Event.SHOW_EVENT, Event.HIDE_EVENT);

            Stage.Description = @"`ControlProgressTask` visualizes the lifecycle of a server-side task (`WebTask`). Updates are no longer polled over a REST endpoint - the server pushes every state change (start, progress tick, message change, finish, cancel) live through the existing MessageQueue WebSocket (see `WebExpress.WebApp.WebMessageQueue.ProgressTaskDispatcher`). The same channel that already carries popup notifications and collaborative messages now also drives the progress overlay.

Because every relevant lifecycle event is broadcast as it happens, the UI reacts immediately without any HTTP roundtrip from the receiver. When the client (re)connects - for example after a page navigation or a transient network drop - the dispatcher replays the current snapshot of every active task on top of the new socket, so the progress bar always reflects reality even when the user joined after the task already started.

Manual scenarios:

- **Live progress** - press the demo button: the bar fills as the task runs.
- **Multiple windows** - open the same URL in two tabs and start a task: both update in lockstep.
- **Page navigation** - start a long task, navigate to another tutorial page and back; the snapshot is replayed so the bar reflects the live progress immediately.
- **Reconnect** - briefly disable the network in DevTools while a task is running; once the WebSocket reconnects the progress jumps to the latest server-side state.";

            Stage.Controls =
            [
                new ControlProgressTask("myTask")
                {
                    TaskId = _ => CreateTask()
                }
            ];

            Stage.DarkControls =
            [
                new ControlProgressTask("myDarkTask")
                {
                    TaskId = _ => CreateTask()
                }
            ];

            Stage.Code = @"
            new ControlProgressTask(""myTask"")
            {
                TaskId = _=> ""sword-fighting-insult-task""
            }";

            Stage.AddProperty
            (
                "TaskId",
                "The `TaskId` property specifies the unique identifier of the task to follow. The client side `ProgressTaskCtrl` filters incoming `webexpress.webapp.progresstask.update` messages by this id, so the same control instance can safely coexist with every other MessageQueue consumer on the page.",
                "TaskId = _=> \"abc123\"",
                new ControlProgressTask("taskid-demo")
                {
                    TaskId = _ => "abc123"
                }
            );

            Stage.AddProperty
            (
                "ShowOnStart",
                "The `ShowOnStart` property indicates whether the control should remain hidden until the first progress signal for the task arrives. Useful for deferred UI activation based on server-side activity.",
                "ShowOnStart = _ => true",
                new ControlProgressTask("showonstart")
                {
                    Display = _ => TypeDisplay.None,
                    TaskId = _ => CreateTask(),
                    ShowOnStart = _ => true
                }
            );

            Stage.AddProperty
            (
                "HideOnFinish",
                "The `HideOnFinish` property hides the associated element once the task finishes (or is canceled), keeping the UI uncluttered after a successful run.",
                "HideOnFinish = _ => true",
                new ControlProgressTask("hideonfinish")
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
