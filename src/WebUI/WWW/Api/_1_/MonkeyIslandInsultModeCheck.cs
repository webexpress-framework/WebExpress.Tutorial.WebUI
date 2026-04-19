using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API endpoint demonstrating the <see cref="RestApiCheck"/>
    /// pattern. Toggles a global Monkey-Island-themed boolean state — whether
    /// insult sword fighting is enabled — through GET/POST requests.
    /// </summary>
    [Title("Monkey Island Insult Sword Fighting")]
    public sealed class MonkeyIslandInsultModeCheck : RestApiCheck
    {
        private static bool _state = true;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandInsultModeCheck()
        {
        }

        /// <summary>
        /// Returns the current state of the insult sword fighting flag.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>The current state.</returns>
        protected override bool GetChecked(Request request)
        {
            return _state;
        }

        /// <summary>
        /// Persists the new state of the insult sword fighting flag.
        /// </summary>
        /// <param name="checked">The new state.</param>
        /// <param name="request">The request context.</param>
        protected override void SetChecked(bool @checked, Request request)
        {
            _state = @checked;
        }
    }
}
