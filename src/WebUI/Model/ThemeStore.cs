using System;
using System.Linq;
using System.Net;
using WebExpress.WebApp.WebTheme;
using WebExpress.WebCore;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebTheme;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Reads and writes the visitor's color theme and icon set for the tutorial's endpoints
    /// and pages, without involving the framework in where the choice is kept.
    /// </summary>
    /// <remarks>
    /// The records live in <see cref="Store"/>; the tutorial keeps them in memory, a real
    /// application assigns its database implementation of <see cref="IAppearanceStore"/> at
    /// startup. A signed-in visitor owns the choice through the identity, so it follows them
    /// across browsers; an anonymous visitor is told apart by the client address, which is
    /// good enough on a single machine.
    /// </remarks>
    public static class ThemeStore
    {
        /// <summary>
        /// Gets or sets the store that keeps the appearance records.
        /// </summary>
        public static IAppearanceStore Store { get; set; } = new MemoryAppearanceStore();

        /// <summary>
        /// Returns the stored theme id for the request, or <see langword="null"/>
        /// when nothing has been picked yet.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The stored theme id or <see langword="null"/>.</returns>
        public static string Get(IRequest request)
        {
            return Store.Get(GetOwner(request))?.ThemeId;
        }

        /// <summary>
        /// Stores <paramref name="themeId"/> for the request, or removes the choice when
        /// <paramref name="themeId"/> is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <param name="themeId">The theme id to store, or null/empty to clear.</param>
        public static void Set(IRequest request, string themeId)
        {
            Update(request, x => x with { ThemeId = Normalize(themeId) });
        }

        /// <summary>
        /// Returns the stored icon set id for the request, or <see langword="null"/>
        /// when the framework drawings apply.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The stored icon set id or <see langword="null"/>.</returns>
        public static string GetIconSet(IRequest request)
        {
            return Store.Get(GetOwner(request))?.IconSetId;
        }

        /// <summary>
        /// Stores <paramref name="iconSetId"/> for the request; the framework drawings are
        /// the absence of a choice, so picking them clears it.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <param name="iconSetId">The icon set id to store, or null/empty to clear.</param>
        public static void SetIconSet(IRequest request, string iconSetId)
        {
            var value = Normalize(iconSetId);
            Update(request, x => x with { IconSetId = value == IconSet.Default.Id ? null : value });
        }

        /// <summary>
        /// Returns the stored light or dark choice for the request, or <see langword="null"/>
        /// when the theme decides.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>"light", "dark" or <see langword="null"/>.</returns>
        public static string GetColorScheme(IRequest request)
        {
            return Store.Get(GetOwner(request))?.ColorScheme;
        }

        /// <summary>
        /// Stores the light or dark choice; <see langword="null"/> hands the decision back to the theme.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <param name="colorScheme">"light", "dark" or null.</param>
        public static void SetColorScheme(IRequest request, string colorScheme)
        {
            Update(request, x => x with { ColorScheme = ColorScheme.Normalize(colorScheme) });
        }

        /// <summary>
        /// Resolves the saved light or dark choice for <see cref="ThemePreferences.RegisterColorScheme{TEndpoint}"/>.
        /// </summary>
        /// <param name="renderContext">The request being rendered.</param>
        /// <returns>"light", "dark" or null.</returns>
        public static string ResolveColorScheme(IRenderContext renderContext)
        {
            return GetColorScheme(renderContext?.Request);
        }

        /// <summary>
        /// Applies only a theme registered for the current application before rendering. The
        /// icon set needs no call here: the web application's visual tree links it on render.
        /// </summary>
        /// <param name="renderContext">The request and application being rendered.</param>
        /// <param name="visualTree">The visual tree that receives the selected stylesheet.</param>
        public static void Apply(IRenderContext renderContext, VisualTreeControl visualTree)
        {
            visualTree.UseTheme(Resolve(renderContext));
        }

        /// <summary>
        /// Resolves the saved preference for both tutorial and shared settings pages.
        /// </summary>
        /// <param name="renderContext">The request and application being rendered.</param>
        /// <returns>The selected registered theme, or null when no preference is stored.</returns>
        public static IThemeContext Resolve(IRenderContext renderContext)
        {
            var selected = Get(renderContext.Request);
            return WebEx.ComponentHub.ThemeManager.Themes.FirstOrDefault(x =>
                x.ApplicationContext == renderContext.PageContext.ApplicationContext
                && string.Equals(x.ThemeId.ToString(), selected, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Resolves the saved icon set id for <see cref="ThemePreferences.RegisterIconSets"/>.
        /// </summary>
        /// <param name="renderContext">The request being rendered.</param>
        /// <returns>The stored icon set id, or null.</returns>
        public static string ResolveIconSet(IRenderContext renderContext)
        {
            return GetIconSet(renderContext?.Request);
        }

        /// <summary>
        /// Changes one choice and keeps the other, because the store writes whole records.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <param name="change">The change applied to the current record.</param>
        private static void Update(IRequest request, Func<AppearancePreference, AppearancePreference> change)
        {
            var owner = GetOwner(request);
            if (owner is null)
            {
                return;
            }

            Store.Save(owner, change(Store.Get(owner) ?? new AppearancePreference(null, null)));
        }

        /// <summary>
        /// Treats an empty choice as no choice.
        /// </summary>
        /// <param name="id">The submitted id.</param>
        /// <returns>The id, or null.</returns>
        private static string Normalize(string id)
        {
            return string.IsNullOrWhiteSpace(id) ? null : id.Trim();
        }

        /// <summary>
        /// Derives the owner of the record: the signed-in identity, so the choice follows
        /// the person, otherwise the client address.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The owner key or <see langword="null"/>.</returns>
        private static string GetOwner(IRequest request)
        {
            if (request is null)
            {
                return null;
            }

            var identity = WebEx.ComponentHub?.IdentityManager?.GetCurrentIdentity(request);
            if (identity is not null)
            {
                return "identity:" + identity.Id.ToString("N");
            }

            var address = (request.RemoteEndPoint as IPEndPoint)?.Address?.ToString()
                ?? request.RemoteEndPoint?.ToString();
            return address is not null ? "address:" + address : null;
        }
    }
}
