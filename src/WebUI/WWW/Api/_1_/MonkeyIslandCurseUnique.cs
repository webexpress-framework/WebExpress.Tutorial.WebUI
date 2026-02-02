using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island curses.
    /// </summary>
    [Title("Monkey Island Curses")]
    public sealed class MonkeyIslandCurseUnique : RestApiUnique
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandCurseUnique()
        {
        }

        /// <summary>
        /// Determines whether the specified value is available based on the provided request context.
        /// </summary>
        /// <param name="value">
        /// The value to check for availability.
        /// </param>
        /// <param name="request">
        /// The request context containing additional information for the availability check. 
        /// </param>
        /// <returns>True if the specified value is available; otherwise, false.</returns>
        protected override bool CheckAvailable(string value, Request request)
        {
            var data = ViewModel.MonkeyIslandCurses;
            var unique = data.Select(x => x.Name.ToLower()).Any(x => x.StartsWith(value));

            return !unique;
        }
    }
}