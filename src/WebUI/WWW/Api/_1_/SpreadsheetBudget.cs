using System.Text;
using System.Text.Json;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebStatusPage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebUI.WebSpreadsheet;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The endpoint behind the loading and saving step of the spreadsheet tutorial: a
    /// <c>GET</c> answers the stored workbook, a <c>PUT</c> or <c>POST</c> stores the workbook
    /// the spreadsheet sends.
    /// </summary>
    /// <remarks>
    /// The workbook is kept in memory for every visitor at once, which is enough to show the
    /// round trip; an application stores it with the record it belongs to. A posted workbook is
    /// read through <see cref="SpreadsheetWorkbook.Parse"/>, so only a validated workbook is ever
    /// stored and answered again.
    /// </remarks>
    [Title("Spreadsheet budget")]
    public sealed class SpreadsheetBudget : IRestApi
    {
        private static readonly object _sync = new();
        private static string _workbook;

        /// <summary>
        /// Returns the stored workbook, or the initial example when nothing was saved yet.
        /// </summary>
        /// <param name="request">The current request.</param>
        /// <returns>The workbook as JSON.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(IRequest request)
        {
            lock (_sync)
            {
                _workbook ??= SpreadsheetSamples.Budget().ToJson();

                return Json(_workbook);
            }
        }

        /// <summary>
        /// Stores the workbook the spreadsheet sends.
        /// </summary>
        /// <param name="request">The current request carrying the workbook as JSON.</param>
        /// <returns>The stored workbook, or 400 for a body that is no workbook.</returns>
        [Method(RequestMethod.PUT)]
        [Method(RequestMethod.POST)]
        public IResponse Update(IRequest request)
        {
            if (request is not Request data || data.Content is null || data.Content.Length == 0)
            {
                return new ResponseBadRequest(new StatusMessage("Missing workbook."));
            }

            try
            {
                var workbook = SpreadsheetWorkbook.Parse(Encoding.UTF8.GetString(data.Content));

                lock (_sync)
                {
                    _workbook = workbook.ToJson();

                    return Json(_workbook);
                }
            }
            catch (JsonException ex)
            {
                return new ResponseBadRequest(new StatusMessage("No workbook: " + ex.Message));
            }
        }

        /// <summary>
        /// Wraps JSON text into a response.
        /// </summary>
        /// <param name="json">The JSON text.</param>
        /// <returns>The response.</returns>
        private static IResponse Json(string json)
        {
            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(json)
            }
                .AddHeaderContentType("application/json");
        }
    }
}
