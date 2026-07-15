using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API quickfilter offering the platforms the Monkey Island
    /// games run on. It backs a single-choice REST dropdown, so its options form an
    /// exclusive set on the client.
    /// </summary>
    public sealed class MonkeyIslandPlatformQuickfilter : RestApiQuickfilter<QuickfilterGame>
    {
        private static readonly (string Id, string Name, IIcon Icon)[] _platforms =
        [
            ("platform-pc", "PC", new IconDesktop()),
            ("platform-console", "Console", new IconGamepad()),
            ("platform-mobile", "Mobile", new IconMobileScreenButton()),
            ("platform-retro", "Retro", new IconFloppyDisk())
        ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandPlatformQuickfilter()
        {
        }

        /// <summary>
        /// Retrieves the platform options, narrowed on the server by the search
        /// query so the single-choice dropdown stays consistent with the others.
        /// </summary>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The matching platform options.</returns>
        protected override IEnumerable<RestApiQuickfilterItem> RetrieveItems(IQueryContext context, IRequest request)
        {
            var q = request?.GetParameter("q")?.Value ?? string.Empty;

            return _platforms
                .Where(x => string.IsNullOrWhiteSpace(q)
                    || x.Name.Contains(q, StringComparison.OrdinalIgnoreCase))
                .Select(x => new RestApiQuickfilterItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Icon = x.Icon
                });
        }
    }
}
