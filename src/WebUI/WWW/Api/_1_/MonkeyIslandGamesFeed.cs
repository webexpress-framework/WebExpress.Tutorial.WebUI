using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API feed of the Monkey Island games: one page of entries, newest first,
    /// that the feed control appends to what it is already showing.
    /// </summary>
    [Title("Monkey Island Games")]
    public sealed class MonkeyIslandGamesFeed : RestApiFeed<Game>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandGamesFeed()
        {
        }

        /// <summary>
        /// Retrieves the entries of the requested page.
        /// </summary>
        /// <param name="query">The query criteria, already narrowed to the requested page.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The entries of the page.</returns>
        protected override IEnumerable<RestApiFeedItem> RetrieveItems(IQuery<Game> query, IQueryContext context, IRequest request)
        {
            // the page is materialized before it is projected: the projection below builds
            // collections, which an expression tree cannot carry
            return query.Apply(ViewModel.MonkeyIslandGames.AsQueryable())
                .ToList()
                .Select(x => new RestApiFeedItem
                {
                    Id = x.Id.ToString(),
                    Title = x.Name,
                    Meta = x.ReleaseYear.ToString(),
                    Text = x.Description,
                    Images = Plates(x),
                    Tags = x.IsRemake ? ["Remake"] : ["Original"],
                    Metrics =
                    [
                        new RestApiFeedMetric { Icon = "wx-icon-light wx-icon-light-thumbs-up", Value = (x.ReleaseYear % 40).ToString(), Label = "Likes" },
                        new RestApiFeedMetric { Icon = "wx-icon-light wx-icon-light-comment", Value = (x.Name?.Length ?? 0).ToString(), Label = "Comments" }
                    ]
                })
                .ToList();
        }

        /// <summary>
        /// Draws the pictures of one game.
        /// </summary>
        /// <remarks>
        /// The tutorial has no artwork to ship, so the plates are drawn here - three per game, in
        /// colours derived from its title. It is enough for the catalogue page to show what the
        /// control does with more than one picture, which is the whole point of looking at it.
        /// </remarks>
        /// <param name="game">The game.</param>
        /// <returns>The pictures, as inline data uris.</returns>
        private static IEnumerable<string> Plates(Game game)
        {
            string[] palette = ["#1f6f4a", "#8a3b12", "#243a6b"];

            return palette.Select((colour, index) =>
            {
                var svg = $"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 300 200\">" +
                    $"<rect width=\"300\" height=\"200\" fill=\"{colour}\"/>" +
                    $"<text x=\"150\" y=\"118\" text-anchor=\"middle\" font-family=\"sans-serif\" font-size=\"64\" fill=\"#ffffff\">" +
                    $"{game.ReleaseYear % 100:D2}.{index + 1}</text></svg>";

                return "data:image/svg+xml;base64," + Convert.ToBase64String(Encoding.UTF8.GetBytes(svg));
            });
        }

        /// <summary>
        /// Returns how many games there are in total, so the control's button disappears on the
        /// last page rather than one page later.
        /// </summary>
        /// <param name="query">The filtered query, without paging applied.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The number of games.</returns>
        protected override int RetrieveTotal(IQuery<Game> query, IQueryContext context, IRequest request)
        {
            return ViewModel.MonkeyIslandGames.Count();
        }
    }
}
