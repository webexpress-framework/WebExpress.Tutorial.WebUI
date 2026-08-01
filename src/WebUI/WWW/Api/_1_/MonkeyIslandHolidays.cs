using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebStatusPage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides the holidays of the Caribbean for a year and a region. Backs the
    /// holiday service of the <c>ControlDataSchedule</c> control, which asks for
    /// one year at a time because holidays change once a year while the
    /// appointments change constantly.
    /// </summary>
    [Segment("holidays")]
    [Title("Monkey Island Holidays")]
    public sealed class MonkeyIslandHolidays : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // the recurring days of the pirate calendar, as month and day; the year
        // arrives with the request and is filled in per response
        private static readonly (int Month, int Day, string Name, string Region, string Type)[] _recurring =
        [
            (1, 1, "New Year", "DE", "public"),
            (8, 8, "Talk Like a Pirate Day", "Caribbean", "observance"),
            (8, 15, "Assumption Day", "BY", "public"),
            (9, 19, "International Grog Day", "Caribbean", "optional"),
            (12, 25, "Christmas", "DE", "public")
        ];

        /// <summary>
        /// Handles <c>GET {base}?year=&amp;region=</c>: returns the holidays of
        /// the requested year, narrowed to the region when one is given.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The HTTP response.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(IRequest request)
        {
            var raw = request?.GetParameter("year")?.Value;
            if (!int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var year))
            {
                return new ResponseBadRequest(new StatusMessage("Missing or malformed year."));
            }

            var region = request?.GetParameter("region")?.Value;

            var holidays = _recurring
                .Where(x => string.IsNullOrEmpty(region) || string.Equals(x.Region, region, StringComparison.OrdinalIgnoreCase))
                .Select(x => new RestApiScheduleHoliday
                {
                    Date = new DateTime(year, x.Month, x.Day).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Name = x.Name,
                    Region = x.Region,
                    Type = x.Type
                })
                .ToList();

            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(holidays, _jsonOptions))
            }
                .AddHeaderContentType("application/json");
        }
    }
}
