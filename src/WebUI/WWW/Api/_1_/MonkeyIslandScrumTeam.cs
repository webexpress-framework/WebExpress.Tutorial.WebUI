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
    /// Provides the Monkey Island themed team workload for the active Scrum
    /// sprint. Backs the data service of the <c>ControlDataScrumTeam</c>
    /// control, which queries <c>GET {uri}</c> once and renders the people
    /// together with the story points assigned to each of them.
    /// </summary>
    [Segment("scrum-team")]
    [Title("Monkey Island Scrum Team")]
    public sealed class MonkeyIslandScrumTeam : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // the crew that has pulled items into "Sprint Mêlée 1"; the points sum to
        // the sprint's committed load and the completed share shows the progress
        // each member has made, with a couple of lighter members so the "+N"
        // overflow chip and the modal table are demonstrated
        private static readonly IReadOnlyList<RestApiScrumTeamMember> _crew =
        [
            new() { Id = "guybrush", Name = "Guybrush Threepwood", Team = "Crew of the Sea Monkey", Initials = "GT", Color = "#1d4ed8", Points = 13, Completed = 5 },
            new() { Id = "elaine",   Name = "Elaine Marley",       Team = "Governor's Office",      Initials = "EM", Color = "#7c3aed", Points = 8,  Completed = 8 },
            new() { Id = "carla",    Name = "Carla",               Team = "Sword Masters",          Initials = "CA", Color = "#be185d", Points = 5,  Completed = 2 },
            new() { Id = "otis",     Name = "Otis",                Team = "Mêlée Jail",             Initials = "OT", Color = "#047857", Points = 5,  Completed = 5 },
            new() { Id = "stan",     Name = "Stan S. Stanman",     Team = "Used Coffins, Etc.",     Initials = "SS", Color = "#b45309", Points = 3,  Completed = 0 },
            new() { Id = "wally",    Name = "Wally B. Feed",       Team = "Cartographers' Guild",   Initials = "WB", Color = "#0e7490", Points = 2,  Completed = 1 },
            new() { Id = "herman",   Name = "Herman Toothrot",     Team = "Marooned",               Initials = "HT", Color = "#6d28d9", Points = 0,  Completed = 0 }
        ];

        /// <summary>
        /// Handles <c>GET {base}</c>: returns the people working in the active
        /// sprint together with their story points.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The HTTP response.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(IRequest request)
        {
            var json = JsonSerializer.Serialize(_crew, _jsonOptions);

            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(json)
            }
                .AddHeaderContentType("application/json");
        }
    }
}
