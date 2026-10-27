using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Tutorial-side REST endpoint that keeps the light or dark choice. It backs the picker on
    /// the Designs page and the dark mode switch of the user menu; the framework has already
    /// reduced the value to light, dark or none, so the hooks only move it in and out of
    /// <see cref="ThemeStore"/>.
    /// </summary>
    [Title("Color Scheme Selector")]
    public sealed class ColorSchemeApi : RestApiColorScheme
    {
        /// <summary>
        /// Returns the stored scheme; without one the theme decides.
        /// </summary>
        /// <param name="context">The query context (unused by the in-memory store).</param>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>"light", "dark" or null.</returns>
        protected override string GetActiveColorScheme(IQueryContext context, IRequest request)
        {
            return ThemeStore.GetColorScheme(request);
        }

        /// <summary>
        /// Stores the validated scheme in the tutorial's appearance store.
        /// </summary>
        /// <param name="colorScheme">"light", "dark" or null.</param>
        /// <param name="context">The query context (unused).</param>
        /// <param name="request">The current HTTP request.</param>
        protected override void PersistSelection(string colorScheme, IQueryContext context, IRequest request)
        {
            ThemeStore.SetColorScheme(request, colorScheme);
        }
    }
}
