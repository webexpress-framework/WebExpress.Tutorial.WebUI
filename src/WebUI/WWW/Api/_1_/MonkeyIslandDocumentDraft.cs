using System;
using System.Globalization;
using System.Text.Json.Serialization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebStatusPage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The draft endpoint behind the document form demo: the unpublished version of the document,
    /// written while the author types and never seen by a reader.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The payload is the same shape <see cref="MonkeyIslandDocument"/> is published with, keyed
    /// by the field names the control was authored with, so this endpoint reads one contract and
    /// not two. <c>GET</c> adds the two reserved keys the indicator opens on - whether a draft
    /// exists and when it was last written - and <c>DELETE</c> discards it.
    /// </para>
    /// <para>
    /// Note what is <i>not</i> here: nothing publishes. Ending a draft is the record endpoint's
    /// job, inside the transaction that applies the text.
    /// </para>
    /// </remarks>
    [Segment("documentdraft")]
    [Title("Monkey Island Document Draft")]
    public sealed class MonkeyIslandDocumentDraft : IRestApi
    {
        private static DocumentPayload _draft;
        private static DateTime? _updated;

        /// <summary>
        /// The unpublished draft, or <see langword="null"/> when there is none. Read by the record
        /// endpoint, which answers the draft's text where one exists.
        /// </summary>
        internal static DocumentPayload Current
        {
            get
            {
                lock (MonkeyIslandDocument.SyncRoot)
                {
                    return _draft;
                }
            }
        }

        /// <summary>
        /// Ends the draft. Called by the record endpoint as part of publishing, which is the only
        /// place a draft may be dropped other than an explicit discard.
        /// </summary>
        internal static void Clear()
        {
            _draft = null;
            _updated = null;
        }

        /// <summary>
        /// Answers the draft's values plus whether there is one and when it was last written.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the draft state.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            lock (MonkeyIslandDocument.SyncRoot)
            {
                return MonkeyIslandDocument.Json(new DraftPayload
                {
                    Title = _draft?.Title,
                    Body = _draft?.Body,
                    Draft = _draft is not null,
                    Updated = _updated?.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture)
                });
            }
        }

        /// <summary>
        /// Stores the supplied values as the unpublished draft.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the stored draft state.</returns>
        [Method(RequestMethod.PUT)]
        public IResponse Update(Request request)
        {
            try
            {
                var payload = MonkeyIslandDocument.GetPayload(request);

                if (payload is null)
                {
                    return new ResponseBadRequest(new StatusMessage("A document payload is required."));
                }

                lock (MonkeyIslandDocument.SyncRoot)
                {
                    _draft = payload;
                    _updated = DateTime.UtcNow;

                    return MonkeyIslandDocument.Json(new DraftPayload
                    {
                        Title = _draft.Title,
                        Body = _draft.Body,
                        Draft = true,
                        Updated = _updated?.ToString("o", CultureInfo.InvariantCulture)
                    });
                }
            }
            catch (Exception ex)
            {
                return new ResponseBadRequest(new StatusMessage($"Error processing request.{ex}"));
            }
        }

        /// <summary>
        /// Discards the draft, leaving the published text standing.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the emptied draft state.</returns>
        [Method(RequestMethod.DELETE)]
        public IResponse Remove(Request request)
        {
            lock (MonkeyIslandDocument.SyncRoot)
            {
                Clear();

                return MonkeyIslandDocument.Json(new DraftPayload { Draft = false, Updated = null });
            }
        }

        /// <summary>
        /// The document payload plus the two keys reserved for the save indicator.
        /// </summary>
        private sealed class DraftPayload
        {
            /// <summary>
            /// Gets or sets the drafted name.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the drafted body.
            /// </summary>
            public string Body { get; set; }

            /// <summary>
            /// Gets or sets whether an unpublished draft exists.
            /// </summary>
            /// <remarks>
            /// The two reserved keys are spelled on the wire exactly as the control reads them,
            /// while the document's own keys stay the field names the form was authored with. A
            /// blanket naming policy would rename both, and the form would then find no field to
            /// fill.
            /// </remarks>
            [JsonPropertyName("draft")]
            public bool Draft { get; set; }

            /// <summary>
            /// Gets or sets when the draft was last written, as an ISO timestamp.
            /// </summary>
            [JsonPropertyName("updated")]
            public string Updated { get; set; }
        }
    }
}
