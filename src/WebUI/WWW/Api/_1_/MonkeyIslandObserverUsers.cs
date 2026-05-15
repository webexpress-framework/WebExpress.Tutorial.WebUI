using System;
using System.Collections.Generic;
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
    /// Provides the directory of candidate users for the Monkey Island
    /// observer demo. Backs the <c>data-users-uri</c> of the observer
    /// control, which queries <c>GET {uri}?q=…</c> as the user types into
    /// the "+" dropdown.
    /// </summary>
    [Segment("observer-users")]
    [Title("Monkey Island Observer Users")]
    public sealed class MonkeyIslandObserverUsers : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        /// <summary>
        /// Handles <c>GET {base}?q=…</c>: returns the candidate users
        /// matching the provided substring (case-insensitive, against name
        /// and team).
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The HTTP response.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(IRequest request)
        {
            var q = request?.GetParameter("q")?.Value ?? string.Empty;

            var users = MonkeyIslandObserverDirectory.All
                .Where(u => string.IsNullOrWhiteSpace(q)
                    || (u.Name ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase)
                    || (u.Team ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var json = JsonSerializer.Serialize(users, _jsonOptions);

            return new ResponseOK
            {
                Content = Encoding.UTF8.GetBytes(json)
            }
                .AddHeaderContentType("application/json");
        }
    }

    /// <summary>
    /// Shared in-memory directory of Monkey Island characters that may
    /// observe an entity in the demo. Used both by the observer endpoint
    /// (to resolve the user id when an observer is added) and the user
    /// search endpoint (to list candidates in the "+" dropdown).
    /// </summary>
    internal static class MonkeyIslandObserverDirectory
    {
        /// <summary>
        /// Gets the full directory of Monkey Island themed users.
        /// </summary>
        public static IReadOnlyList<RestApiObserverItem> All { get; } =
        [
            new() { Id = "guybrush",   Name = "Guybrush Threepwood",   Team = "Mighty Pirates",   Initials = "GT", Color = "#1d4ed8" },
            new() { Id = "elaine",     Name = "Elaine Marley",         Team = "Governor's Office", Initials = "EM", Color = "#7c3aed" },
            new() { Id = "stan",       Name = "Stan S. Stanman",       Team = "Used Coffins, Etc.", Initials = "SS", Color = "#b45309" },
            new() { Id = "voodoolady", Name = "The Voodoo Lady",        Team = "International House of Mojo", Initials = "VL", Color = "#047857" },
            new() { Id = "lechuck",    Name = "Captain LeChuck",        Team = "Ghost Pirates",     Initials = "LC", Color = "#991b1b" },
            new() { Id = "wally",      Name = "Wally B. Feed",          Team = "Cartographers' Guild", Initials = "WB", Color = "#0e7490" },
            new() { Id = "herman",     Name = "Herman Toothrot",        Team = "Marooned",          Initials = "HT", Color = "#6d28d9" },
            new() { Id = "murray",     Name = "Murray, the Demonic Skull", Team = "Existential Crisis Dept.", Initials = "MS", Color = "#374151" }
        ];

        /// <summary>
        /// Resolves a user record by id, or <see langword="null"/> when
        /// none matches.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <returns>The user record, or <see langword="null"/>.</returns>
        public static RestApiObserverItem FindById(string id) =>
            All.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
    }
}
