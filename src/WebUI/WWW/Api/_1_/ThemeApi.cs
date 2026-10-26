using System.Linq;
using System;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Tutorial-side REST endpoint backing the theme selector on the
    /// Theme demo page. Derives from <see cref="RestApiTheme"/> and
    /// plugs the persistence hooks into <see cref="ThemeStore"/>, an
    /// in-memory store keyed per client. Production code would route
    /// these calls into a real user profile / session / database instead.
    /// </summary>
    [Title("Theme Selector")]
    public sealed class ThemeApi : RestApiTheme
    {
        /// <summary>
        /// Keeps the selector aligned with the stored preference or application default.
        /// </summary>
        /// <param name="context">The query context (unused by the in-memory store).</param>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The selected theme id, falling back to the application default.</returns>
        protected override string GetActiveThemeId(IQueryContext context, IRequest request)
        {
            return ThemeStore.Get(request) ?? request.ApplicationContext.DefaultTheme?.ThemeId.ToString();
        }

        /// <summary>
        /// Persists the user's theme pick in the tutorial's in-memory store.
        /// </summary>
        /// <param name="themeId">The chosen theme id, or null to clear.</param>
        /// <param name="context">The query context (unused).</param>
        /// <param name="request">The current HTTP request.</param>
        protected override void PersistSelection(string themeId, IQueryContext context, IRequest request)
        {
            if (!string.IsNullOrEmpty(themeId) && !WebEx.ComponentHub.ThemeManager.Themes.Any(x =>
                x.ApplicationContext == request.ApplicationContext
                && string.Equals(x.ThemeId.ToString(), themeId, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("The selected theme is not registered for this application.", nameof(themeId));
            }

            ThemeStore.Set(request, themeId);
        }
    }
}
