using System.Collections.Generic;
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
    /// Provides the Monkey Island themed sprint history for the velocity chart.
    /// Backs the data service of the <c>ControlDataScrumVelocity</c> control,
    /// which queries <c>GET {uri}</c> once and renders the completed story points
    /// per sprint. The sprints are returned in chronological order (oldest
    /// first); the control keeps the trailing window it was configured to show.
    /// </summary>
    [Segment("scrum-velocity")]
    [Title("Monkey Island Scrum Velocity")]
    public sealed class MonkeyIslandScrumVelocity : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // the closed sprints of the campaign, oldest first; the completed points
        // are the velocity and the committed points the original commitment, so
        // the chart can contrast delivery against plan
        private static readonly IReadOnlyList<RestApiScrumVelocitySprint> _history =
        [
            new() { Id = "s1", Name = "Sprint Mêlée 1",     Committed = 30, Completed = 24 },
            new() { Id = "s2", Name = "Sprint Scumm 2",     Committed = 28, Completed = 27 },
            new() { Id = "s3", Name = "Sprint Voodoo 3",    Committed = 26, Completed = 18 },
            new() { Id = "s4", Name = "Sprint Carnival 4",  Committed = 32, Completed = 31 },
            new() { Id = "s5", Name = "Sprint Big Whoop 5", Committed = 30, Completed = 28 },
            new() { Id = "s6", Name = "Sprint Catacomb 6",  Committed = 34, Completed = 22 },
            new() { Id = "s7", Name = "Sprint LeChuck 7",   Committed = 28, Completed = 29 }
        ];

        /// <summary>
        /// Handles <c>GET {base}</c>: returns the recent sprints together with
        /// their committed and completed story points.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The HTTP response.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(IRequest request)
        {
            var json = JsonSerializer.Serialize(_history, _jsonOptions);

            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(json)
            }
                .AddHeaderContentType("application/json");
        }
    }
}
