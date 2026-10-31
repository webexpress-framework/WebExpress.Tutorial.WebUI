using System.Text;
using System.Text.Json;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST endpoint the <c>ControlDataForm</c> demo loads its greeting from and saves it to. A
    /// data form bypasses the classic form processing, so a save is only ever seen here, and this
    /// is where it is confirmed to the visitor.
    /// </summary>
    /// <remarks>
    /// The greeting is kept in memory: the tutorial has nothing to persist to, and the point of
    /// the demo is the round trip, not the storage.
    /// </remarks>
    [Segment("greeting")]
    [Title("Greeting of the data form demo")]
    public sealed class DataFormGreeting : IRestApi
    {
        private const string DefaultGreeting = "Hello World!";

        /// <summary>
        /// The form posts lowercase json and the deserializer matches property names
        /// case-sensitively, so without this every greeting reads as empty.
        /// </summary>
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// The stored greeting. Static because the endpoint is instantiated per request.
        /// </summary>
        private static volatile string _greeting = DefaultGreeting;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DataFormGreeting()
        {
        }

        /// <summary>
        /// Handles <c>GET {base}</c>: answers the stored greeting, which the form loads when it
        /// starts, so a reload shows what was saved last.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The greeting as JSON.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            return Json(new { data = new { regards = _greeting } });
        }

        /// <summary>
        /// Handles <c>POST {base}</c>: stores the greeting and confirms the save with a
        /// notification. The form validates on the client already, but the endpoint is reachable
        /// without it, so an empty greeting is refused here as well.
        /// </summary>
        /// <param name="request">The request carrying <c>{ "regards": "…" }</c>.</param>
        /// <returns>The stored greeting, or the field error as JSON.</returns>
        [Method(RequestMethod.POST)]
        public IResponse Store(Request request)
        {
            var regards = ReadRegards(request)?.Trim();

            if (string.IsNullOrEmpty(regards))
            {
                return Json(new { errors = new { regards = "Please enter a greeting." } }, new ResponseBadRequest());
            }

            _greeting = regards;

            SaveNotification.Notify(request, regards);

            return Json(new { data = new { regards } });
        }

        /// <summary>
        /// Reads the greeting out of the posted body.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The greeting, or null when the body carries none.</returns>
        private static string ReadRegards(Request request)
        {
            var content = request?.Content;

            if (content is null || content.Length == 0)
            {
                return null;
            }

            try
            {
                var payload = JsonSerializer.Deserialize<GreetingPayload>(Encoding.UTF8.GetString(content), _jsonOptions);

                return payload?.Regards;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Serializes the value into the response as its JSON content.
        /// </summary>
        /// <param name="value">The value to answer.</param>
        /// <param name="response">The response to fill; an OK response when omitted.</param>
        /// <returns>The response.</returns>
        private static IResponse Json(object value, Response response = null)
        {
            response ??= new ResponseOK();
            response.Content = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));

            return response.AddHeaderContentType("application/json");
        }

        /// <summary>
        /// The body of a save.
        /// </summary>
        private sealed class GreetingPayload
        {
            /// <summary>
            /// Gets or sets the greeting.
            /// </summary>
            public string Regards { get; set; }
        }
    }
}
