using System;
using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebStatusPage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST endpoint backing the traffic light demo. It keeps a single
    /// Monkey-Island-themed status token (the readiness of the crew to set
    /// sail) in memory: GET returns the current token, PUT replaces it with the
    /// token supplied in the JSON body. The tokens match the client lamps:
    /// "red", "yellow", "green" or an empty string for off.
    /// </summary>
    [Segment("status")]
    [Title("Monkey Island Status")]
    public sealed class MonkeyIslandStatus : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static readonly object _syncRoot = new();
        private static string _state = "green";

        /// <summary>
        /// The JSON payload exchanged with the client traffic light control.
        /// </summary>
        private sealed class StatusPayload
        {
            /// <summary>
            /// Gets or sets the lit lamp token.
            /// </summary>
            public string Value { get; set; }
        }

        /// <summary>
        /// Returns the current status token.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the current token.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            lock (_syncRoot)
            {
                return Json(new StatusPayload { Value = _state });
            }
        }

        /// <summary>
        /// Replaces the status with the token supplied in the request body.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the resulting token.</returns>
        [Method(RequestMethod.PUT)]
        public IResponse Update(Request request)
        {
            try
            {
                var payload = GetPayload(request);
                var value = (payload?.Value ?? string.Empty).Trim().ToLowerInvariant();

                // guard against arbitrary input; an unknown token resets to off
                if (value is not ("red" or "yellow" or "green"))
                {
                    value = string.Empty;
                }

                lock (_syncRoot)
                {
                    _state = value;
                    return Json(new StatusPayload { Value = _state });
                }
            }
            catch (Exception ex)
            {
                return new ResponseBadRequest(new StatusMessage($"Error processing request.{ex}"));
            }
        }

        /// <summary>
        /// Deserializes the JSON request body into the status payload.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The payload, or <see langword="null"/> when missing or invalid.</returns>
        private static StatusPayload GetPayload(Request request)
        {
            if (request?.Content is null || request.Content.Length == 0)
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<StatusPayload>(request.Content, _jsonOptions);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Builds an <c>application/json</c> 200 response from the payload.
        /// </summary>
        /// <param name="payload">The payload to serialize.</param>
        /// <returns>The HTTP response.</returns>
        private static IResponse Json(object payload)
        {
            var json = JsonSerializer.Serialize(payload, _jsonOptions);
            var content = Encoding.UTF8.GetBytes(json);

            return new ResponseOK
            {
                Content = content
            }
                .AddHeaderContentType("application/json");
        }
    }
}
