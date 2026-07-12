using System;
using System.Text;
using System.Text.Json;
using WebExpress.Tutorial.WebUI.WebTask;
using WebExpress.WebCore;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST endpoint that starts a <see cref="MonkeyIslandInsultTask"/> and
    /// answers with its id. It is the "starter" service the
    /// <c>ControlStatusTask</c> demo posts to: the dot posts here on a click (or
    /// on load), adopts the returned task id and then follows the task live over
    /// the MessageQueue. A fresh id per start lets the dot repeat the task without
    /// the client ever knowing the id up front.
    /// </summary>
    [Segment("insult-task")]
    [Title("Start Monkey Island insult task")]
    public sealed class InsultTaskStarter : IRestApi
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public InsultTaskStarter()
        {
        }

        /// <summary>
        /// Starts a new insult task and returns its id so the caller can follow it.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response carrying the started task id as JSON.</returns>
        [Method(RequestMethod.POST)]
        public IResponse Start(Request request)
        {
            // a fresh id per start so a repeating dot follows a genuinely new task
            // each cycle rather than colliding with a still-known id
            var task = WebEx.ComponentHub.TaskManager.CreateTask<MonkeyIslandInsultTask>(Guid.NewGuid().ToString("N"), null);
            task.Run();

            var json = JsonSerializer.Serialize(new { taskId = task.Id });

            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(json)
            }
                .AddHeaderContentType("application/json");
        }
    }
}
