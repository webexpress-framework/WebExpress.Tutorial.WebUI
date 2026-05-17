using System.Collections.Concurrent;
using System.Net;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// In-memory per-client theme store demonstrating how user code can
    /// persist a <see cref="WebApp.WebRestApi.RestApiTheme"/> selection
    /// without involving the framework. Keyed by the remote endpoint so
    /// different browsers see independent selections during the tutorial;
    /// production applications would key by identity, session id, or user
    /// profile instead.
    /// </summary>
    public static class ThemeStore
    {
        private static readonly ConcurrentDictionary<string, string> _selections = new();

        /// <summary>
        /// Returns the stored theme id for the request, or <see langword="null"/>
        /// when nothing has been picked yet.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The stored theme id or <see langword="null"/>.</returns>
        public static string Get(IRequest request)
        {
            var key = GetKey(request);
            return key is not null && _selections.TryGetValue(key, out var value) ? value : null;
        }

        /// <summary>
        /// Stores <paramref name="themeId"/> for the request, or removes
        /// the entry when <paramref name="themeId"/> is <see langword="null"/>
        /// or empty.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <param name="themeId">The theme id to store, or null/empty to clear.</param>
        public static void Set(IRequest request, string themeId)
        {
            var key = GetKey(request);
            if (key is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(themeId))
            {
                _selections.TryRemove(key, out _);
            }
            else
            {
                _selections[key] = themeId;
            }
        }

        /// <summary>
        /// Derives a per-client storage key. The remote IP is good enough for
        /// the single-machine tutorial scenario; production code would use a
        /// signed session id or the authenticated identity id instead.
        /// </summary>
        /// <param name="request">The current HTTP request.</param>
        /// <returns>The storage key or <see langword="null"/>.</returns>
        private static string GetKey(IRequest request)
        {
            return (request?.RemoteEndPoint as IPEndPoint)?.Address?.ToString()
                ?? request?.RemoteEndPoint?.ToString();
        }
    }
}
