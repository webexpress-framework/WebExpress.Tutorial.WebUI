using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Tutorial-side REST endpoint backing the icon set selector of the Designs page. The
    /// framework has already checked the id against the offered sets, so the hooks only move
    /// it in and out of <see cref="ThemeStore"/>.
    /// </summary>
    [Title("Icon Set Selector")]
    public sealed class IconSetApi : RestApiIconSet
    {
        /// <summary>
        /// Returns the stored icon set id; without one the selector shows the first offered set.
        /// </summary>
        /// <param name="context">The query context (unused by the in-memory store).</param>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The stored icon set id, or null.</returns>
        protected override string GetActiveIconSetId(IQueryContext context, IRequest request)
        {
            return ThemeStore.GetIconSet(request);
        }

        /// <summary>
        /// Stores the validated icon set id in the tutorial's appearance store.
        /// </summary>
        /// <param name="iconSetId">The validated icon set id, or null to clear.</param>
        /// <param name="context">The query context (unused).</param>
        /// <param name="request">The current HTTP request.</param>
        protected override void PersistSelection(string iconSetId, IQueryContext context, IRequest request)
        {
            ThemeStore.SetIconSet(request, iconSetId);
        }
    }
}
