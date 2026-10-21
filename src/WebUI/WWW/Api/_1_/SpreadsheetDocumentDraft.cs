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
    /// The draft endpoint behind the workbook dialog demo: the unpublished version of the
    /// workbook, written while the author works and never seen by a reader.
    /// </summary>
    /// <remarks>
    /// The payload is the same shape <see cref="SpreadsheetDocument"/> is published with, keyed by
    /// the field names the control was authored with. <c>GET</c> adds the two reserved keys the
    /// indicator opens on - whether a draft exists and when it was last written - and
    /// <c>DELETE</c> discards it. Nothing here publishes: ending a draft is the record endpoint's
    /// job, inside the transaction that applies the workbook.
    /// </remarks>
    [Segment("workbookdraft")]
    [Title("Spreadsheet Document Draft")]
    public sealed class SpreadsheetDocumentDraft : IRestApi
    {
        private static DocumentPayload _draft;
        private static DateTime? _updated;

        /// <summary>
        /// The unpublished draft, or <see langword="null"/> when there is none.
        /// </summary>
        internal static DocumentPayload Current
        {
            get
            {
                lock (SpreadsheetDocument.SyncRoot)
                {
                    return _draft;
                }
            }
        }

        /// <summary>
        /// Ends the draft. Called by the record endpoint as part of publishing.
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
            lock (SpreadsheetDocument.SyncRoot)
            {
                return State();
            }
        }

        /// <summary>
        /// Stores the supplied values as the unpublished draft.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the stored draft state, or 400 for a body that is no
        /// workbook.</returns>
        [Method(RequestMethod.PUT)]
        public IResponse Update(Request request)
        {
            var payload = SpreadsheetDocument.Read(request, out var error);

            if (payload is null)
            {
                return new ResponseBadRequest(new StatusMessage(error));
            }

            lock (SpreadsheetDocument.SyncRoot)
            {
                _draft = payload;
                _updated = DateTime.UtcNow;

                return State();
            }
        }

        /// <summary>
        /// Discards the draft, leaving the published workbook standing.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the emptied draft state.</returns>
        [Method(RequestMethod.DELETE)]
        public IResponse Remove(Request request)
        {
            lock (SpreadsheetDocument.SyncRoot)
            {
                Clear();

                return State();
            }
        }

        /// <summary>
        /// Builds the answer of the draft state; the caller holds the lock.
        /// </summary>
        /// <returns>The response.</returns>
        private static IResponse State()
        {
            return MonkeyIslandDocument.Json(new DraftPayload
            {
                Title = _draft?.Title,
                Body = _draft?.Body,
                Draft = _draft is not null,
                Updated = _updated?.ToString("o", CultureInfo.InvariantCulture)
            });
        }

        /// <summary>
        /// The workbook payload plus the two keys reserved for the save indicator.
        /// </summary>
        private sealed class DraftPayload
        {
            /// <summary>
            /// Gets or sets the drafted name.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the drafted workbook as JSON.
            /// </summary>
            public string Body { get; set; }

            /// <summary>
            /// Gets or sets whether an unpublished draft exists. The reserved keys are spelled on
            /// the wire exactly as the control reads them, while the document's own keys stay the
            /// field names the form was authored with.
            /// </summary>
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
