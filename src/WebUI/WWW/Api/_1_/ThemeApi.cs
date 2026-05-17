using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Tutorial-side REST endpoint backing the theme selector on the
    /// IconTheme demo page. Derives from <see cref="RestApiTheme"/> and
    /// plugs the persistence hooks into <see cref="ThemeStore"/>, an
    /// in-memory store keyed per client. Production code would route
    /// these calls into a real user profile / session / database instead.
    /// </summary>
    [Title("Theme Selector")]
    public sealed class ThemeApi : RestApiTheme
    {
        /// <summary>
        /// Returns the stored theme id for the current request, or
        /// <see langword="null"/> when nothing has been picked yet.
        /// </summary>
        /// <param name="context">The query context (unused by the in-memory store).</param>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The stored theme id or <see langword="null"/>.</returns>
        protected override string GetActiveThemeId(IQueryContext context, IRequest request)
        {
            return ThemeStore.Get(request);
        }

        /// <summary>
        /// Persists the user's theme pick in the tutorial's in-memory store.
        /// </summary>
        /// <param name="themeId">The chosen theme id, or null to clear.</param>
        /// <param name="context">The query context (unused).</param>
        /// <param name="request">The current HTTP request.</param>
        protected override void PersistSelection(string themeId, IQueryContext context, IRequest request)
        {
            ThemeStore.Set(request, themeId);
        }
    }
}
