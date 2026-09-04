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
    /// The record endpoint behind the document form demo: one Monkey-Island-themed document
    /// held in memory, with a title and a rich-text body.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the endpoint that decides what the editor opens on. <c>GET</c> answers the
    /// unpublished draft where there is one and the published text otherwise, which is what
    /// makes "editing resumes the draft" true without any scripting on the client - the control
    /// never merges the two, it only asks.
    /// </para>
    /// <para>
    /// <c>PUT</c> <b>is</b> the publication: it applies the text and ends the draft in the same
    /// step. Ending it here rather than letting the client delete it is what keeps a publish that
    /// failed from destroying the only copy of the text.
    /// </para>
    /// </remarks>
    [Segment("document")]
    [Title("Monkey Island Document")]
    public sealed class MonkeyIslandDocument : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// The published title.
        /// </summary>
        public static string PublishedTitle { get; private set; } = "The Secret of Monkey Island";

        /// <summary>
        /// The published body.
        /// </summary>
        public static string PublishedBody { get; private set; } =
            "<p>Guybrush Threepwood arrives on M&#234;l&#233;e Island with one ambition: to become a mighty pirate.</p>";

        /// <summary>
        /// The lock both endpoints of the demo take, so a publish and an autosave landing at the
        /// same moment cannot interleave into a document that is half of each.
        /// </summary>
        internal static object SyncRoot { get; } = new();

        /// <summary>
        /// The values the editor opens on, which are the draft's when one exists.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the values.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            lock (SyncRoot)
            {
                var draft = MonkeyIslandDocumentDraft.Current;

                return Json(new DocumentPayload
                {
                    Title = draft?.Title ?? PublishedTitle,
                    Body = draft?.Body ?? PublishedBody
                });
            }
        }

        /// <summary>
        /// Publishes the supplied text and ends the draft in the same step.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the published values.</returns>
        [Method(RequestMethod.PUT)]
        public IResponse Update(Request request)
        {
            try
            {
                var payload = GetPayload(request);

                if (payload is null)
                {
                    return new ResponseBadRequest(new StatusMessage("A document payload is required."));
                }

                lock (SyncRoot)
                {
                    PublishedTitle = payload.Title ?? string.Empty;
                    PublishedBody = payload.Body ?? string.Empty;

                    // the draft ends with the publication, inside the same transaction, so there
                    // is never a moment in which neither the record nor the draft carries the text
                    MonkeyIslandDocumentDraft.Clear();

                    return Json(new DocumentPayload { Title = PublishedTitle, Body = PublishedBody });
                }
            }
            catch (Exception ex)
            {
                return new ResponseBadRequest(new StatusMessage($"Error processing request.{ex}"));
            }
        }

        /// <summary>
        /// Deserializes the JSON request body into the document payload.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The payload, or <see langword="null"/> when missing or invalid.</returns>
        internal static DocumentPayload GetPayload(Request request)
        {
            if (request?.Content is null || request.Content.Length == 0)
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<DocumentPayload>(request.Content, _jsonOptions);
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
        internal static IResponse Json(object payload)
        {
            var content = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload, _jsonOptions));

            return new ResponseOK
            {
                Content = content
            }
                .AddHeaderContentType("application/json");
        }
    }

    /// <summary>
    /// The wire shape both endpoints speak. The keys are the field names the control was
    /// authored with, so the draft and the publication carry one contract rather than two.
    /// </summary>
    public sealed class DocumentPayload
    {
        /// <summary>
        /// Gets or sets the document's name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the document's rich-text body.
        /// </summary>
        public string Body { get; set; }
    }
}
