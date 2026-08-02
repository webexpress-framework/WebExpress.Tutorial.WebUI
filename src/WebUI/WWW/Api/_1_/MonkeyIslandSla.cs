using System;
using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebStatusPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST endpoint backing the service level agreement demo. It keeps a single
    /// agreement in memory - the crew's promise to answer a summons from the
    /// governor within four hours, renewed every day - and exposes the three
    /// transitions the widget offers: GET returns the current state, POST
    /// applies a pause, a resume, a manual settlement or a restart and answers
    /// with the state that resulted.
    /// </summary>
    /// <remarks>
    /// The endpoint owns no logic of its own: it applies the transitions of
    /// <see cref="SlaDefinition"/> and reports what <see cref="SlaEvaluator"/>
    /// derives from the result, so the widget, the endpoint and the unit tests
    /// all arrive at the same status by the same route.
    /// </remarks>
    [Segment("sla")]
    [Title("Monkey Island SLA")]
    public sealed class MonkeyIslandSla : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static readonly object _syncRoot = new();

        /// <summary>
        /// The agreement the demo operates on. It starts three hours ago, so a
        /// visitor arrives at a widget that is already at risk and can watch it
        /// change rather than having to wait for it.
        /// </summary>
        private static SlaDefinition _definition = new()
        {
            Start = DateTime.Now.AddHours(-3),
            Target = TimeSpan.FromHours(4),
            WarningThreshold = 0.6d,
            Recurrence = TypeRecurrenceSla.Daily,
            Cycles = 5
        };

        /// <summary>
        /// The JSON payload the client posts to request a transition.
        /// </summary>
        private sealed class ActionPayload
        {
            /// <summary>
            /// Gets or sets the requested transition: pause, resume, fulfill or restart.
            /// </summary>
            public string Action { get; set; }
        }

        /// <summary>
        /// Returns the current state of the agreement.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the state.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            lock (_syncRoot)
            {
                return Json(_definition);
            }
        }

        /// <summary>
        /// Applies the transition named in the request body.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the resulting state.</returns>
        [Method(RequestMethod.POST)]
        public IResponse Update(Request request)
        {
            var payload = GetPayload(request);
            var action = (payload?.Action ?? string.Empty).Trim().ToLowerInvariant();
            var moment = DateTime.Now;

            lock (_syncRoot)
            {
                var transitioned = action switch
                {
                    "pause" => _definition.Pause(moment),
                    "resume" => _definition.Resume(moment),
                    "fulfill" => _definition.Fulfill(moment),
                    "restart" => _definition.Restart(moment),
                    _ => null
                };

                // the transitions are part of the contract, so an unknown one is
                // a caller error rather than something to guess at
                if (transitioned is null)
                {
                    return new ResponseBadRequest(new StatusMessage($"Unknown action '{action}'."));
                }

                _definition = transitioned;

                return Json(_definition);
            }
        }

        /// <summary>
        /// Serializes the state of an agreement in the shape the client widget
        /// adopts.
        /// </summary>
        /// <param name="definition">The definition to report.</param>
        /// <returns>The HTTP response.</returns>
        private static IResponse Json(SlaDefinition definition)
        {
            var evaluation = SlaEvaluator.Evaluate(definition, DateTime.Now);

            var json = JsonSerializer.Serialize(new
            {
                status = evaluation.Status.ToValue(),
                target = (long)evaluation.Budget.TotalSeconds,
                elapsed = (long)evaluation.Elapsed.TotalSeconds,
                remaining = (long)evaluation.Remaining.TotalSeconds,
                period = (long)evaluation.Period.TotalSeconds,
                cycle = evaluation.Cycle,
                cycles = evaluation.Cycles,
                paused = evaluation.IsPaused,
                settled = evaluation.IsSettled
            }, _jsonOptions);

            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(json)
            }
                .AddHeaderContentType("application/json");
        }

        /// <summary>
        /// Deserializes the JSON request body into the action payload.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The payload, or <see langword="null"/> when missing or invalid.</returns>
        private static ActionPayload GetPayload(Request request)
        {
            if (request?.Content is null || request.Content.Length == 0)
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<ActionPayload>(request.Content, _jsonOptions);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
