using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebStatusPage;
using WebExpress.WebUI.WebSpreadsheet;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The record endpoint behind the workbook dialog demo: one budget workbook held in memory,
    /// with a name and the workbook as JSON.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the endpoint that decides what the dialog opens on. <c>GET</c> answers the
    /// unpublished draft where there is one and the published workbook otherwise, so "editing
    /// resumes the draft" needs no scripting on the client.
    /// </para>
    /// <para>
    /// <c>PUT</c> <b>is</b> the publication: it applies the workbook and ends the draft in the
    /// same step. The workbook is read through <see cref="SpreadsheetWorkbook.Parse"/>, so only a
    /// validated workbook is ever published or answered again.
    /// </para>
    /// </remarks>
    [Segment("workbook")]
    [Title("Spreadsheet Document")]
    public sealed class SpreadsheetDocument : IRestApi
    {
        /// <summary>
        /// The published name.
        /// </summary>
        public static string PublishedTitle { get; private set; } = "Household budget";

        /// <summary>
        /// The published workbook as JSON.
        /// </summary>
        public static string PublishedBody { get; private set; } = SpreadsheetSamples.Budget().ToJson();

        /// <summary>
        /// The lock both endpoints of the demo take, so a publish and an autosave landing at the
        /// same moment cannot interleave into a workbook that is half of each.
        /// </summary>
        internal static object SyncRoot { get; } = new();

        /// <summary>
        /// The values the dialog opens on, which are the draft's when one exists.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the values.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            lock (SyncRoot)
            {
                var draft = SpreadsheetDocumentDraft.Current;

                return MonkeyIslandDocument.Json(new DocumentPayload
                {
                    Title = draft?.Title ?? PublishedTitle,
                    Body = draft?.Body ?? PublishedBody
                });
            }
        }

        /// <summary>
        /// Publishes the supplied workbook and ends the draft in the same step.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the published values, or 400 for a body that is no
        /// workbook.</returns>
        [Method(RequestMethod.PUT)]
        public IResponse Update(Request request)
        {
            var payload = Read(request, out var error);

            if (payload is null)
            {
                return new ResponseBadRequest(new StatusMessage(error));
            }

            lock (SyncRoot)
            {
                PublishedTitle = payload.Title;
                PublishedBody = payload.Body;

                // the draft ends with the publication, inside the same transaction, so there is
                // never a moment in which neither the record nor the draft carries the workbook
                SpreadsheetDocumentDraft.Clear();

                return MonkeyIslandDocument.Json(payload);
            }
        }

        /// <summary>
        /// Reads the payload of a request and validates its workbook. The answer carries the
        /// workbook in its validated form, so what is stored is what the server understood.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <param name="error">Why the request was refused.</param>
        /// <returns>The validated payload, or <see langword="null"/>.</returns>
        internal static DocumentPayload Read(Request request, out string error)
        {
            var payload = MonkeyIslandDocument.GetPayload(request);

            if (payload is null)
            {
                error = "A workbook payload is required.";
                return null;
            }

            if (!SpreadsheetWorkbook.TryParse(payload.Body, out var workbook))
            {
                error = "The body is no workbook.";
                return null;
            }

            error = null;

            return new DocumentPayload
            {
                Title = payload.Title ?? string.Empty,
                Body = workbook.ToJson()
            };
        }
    }
}
