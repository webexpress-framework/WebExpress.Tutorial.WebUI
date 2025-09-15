using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WebTask;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebTask;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the progress task control for the tutorial.    
    /// </summary>    
    [Title("RestProgressTask")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestProgressTask : PageControl
    {
        private const string TaskId = "sword-fighting-insult-task";
        private readonly ITaskManager _taskManager;

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="taskManager">The task manager.</param>
        public RestProgressTask(ITaskManager taskManager)
        {
            _taskManager = taskManager;

            Stage.AddEvent(Event.TASK_UPDATE_EVENT, Event.TASK_FINISH_EVENT, Event.SHOW_EVENT, Event.HIDE_EVENT);

            Stage.Description = @"A `ProgressTask` control is a user interface component that visualizes the execution state of a server-side task retrieved via a REST API. The control monitors the task's lifecycle, including creation, execution, completion, and cancellation. It periodically queries the API to update the task's progress and displays contextual messages that reflect the current state of the task. The control is designed to provide real-time feedback, improve user engagement, and enhance transparency during asynchronous operations.";

            Stage.Controls =
            [
                new ControlRestProgressTask("myTask")
                {
                    TaskId = CreateTask(),
                    Interval = 1000
                }
            ];

            Stage.DarkControls =
            [
                new ControlRestProgressTask("myDarkTask")
                {
                    TaskId = CreateTask(),
                    Interval = 1000
                }
            ];

            Stage.Code = @"
            new ControlRestProgressTask(""myTask"")
            {
                TaskId = ""sword-fighting-insult-task"",
                Interval = 1000
            }";

            Stage.AddProperty
            (
                "TaskId",
                "The `TaskId` property specifies the unique identifier for the task. It is used to associate the progress control with a specific backend operation and enables targeted updates via REST.",
                "TaskId = \"abc123\"",
                new ControlRestProgressTask("myDarkTask")
                {
                    TaskId = "abc123"
                }
            );

            Stage.AddProperty
            (
                "Interval",
                "The `Interval` property defines the polling interval in milliseconds. It determines how frequently the control queries the backend for task updates.",
                "Interval = 5000",
                new ControlRestProgressTask("interval")
                {
                    TaskId = CreateTask(),
                    Interval = 5000
                }
            );

            Stage.AddProperty
            (
                "ShowOnStart",
                "The `ShowOnStart` property indicates whether the control should become visible when the task begins. This is useful for deferred UI activation based on progress.",
                "ShowOnStart = true",
                new ControlRestProgressTask("showonstart")
                {
                    Display = TypeDisplay.None,
                    TaskId = CreateTask(),
                    ShowOnStart = true
                }
            );

            Stage.AddProperty
            (
                "HideOnFinish",
                "The `HideOnFinish` property controls whether the associated element should be hidden once the task is complete. It helps declutter the UI after successful execution.",
                "HideOnFinish = true",
                new ControlRestProgressTask("hideonfinish")
                {
                    TaskId = CreateTask(),
                    HideOnFinish = true
                }
            );
        }

        /// <summary>
        /// Creates and runs a new MonkeyIslandInsultTask task/>.
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
