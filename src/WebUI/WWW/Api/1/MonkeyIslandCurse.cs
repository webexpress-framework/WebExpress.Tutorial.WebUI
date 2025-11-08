using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1
{
    /// <summary>
    /// Represents a REST API table for managing and retrieving data about Monkey Island curses.
    /// </summary>
    [Title("Monkey Island Curses")]
    [Method(CrudMethod.GET)]
    public sealed class MonkeyIslandCurse : RestApiCrudUnique<Curse>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandCurse()
        {
            Data = ViewModel.MonkeyIslandCurses;
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
            var unique = Data.Select(x => x.Name.ToLower()).Any(x => x.StartsWith(value));

            return !unique;
        }
    }
}