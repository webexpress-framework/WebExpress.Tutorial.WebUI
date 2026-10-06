using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExpress.WebCore;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebEndpoint;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The link targets behind the link page WebApp adds to the editor's link dialog: pages of
    /// this tutorial, resolved through the sitemap so they follow the application's context path,
    /// and a few addresses outside of it.
    /// </summary>
    [Segment("editor-links")]
    [Title("Monkey Island Editor Links")]
    public sealed class MonkeyIslandEditorLinks : IRestApi
    {
        private static readonly JsonSerializerOptions _json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        /// <summary>
        /// Lists the link targets matching the search in their title or description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The link targets.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            var search = request.GetParameter("q")?.Value ?? string.Empty;
            var application = request.ApplicationContext;
            var items = new List<LinkItem>
            {
                Page<Index>(application, "Home", "The start page of the tutorial."),
                Page<Controls.WebUi.Content>(application, "Content", "Rendering editor content, as HTML and as PDF."),
                Page<Controls.WebUi.Form.Text>(application, "Text input", "The text field, including the rich-text editor."),
                Page<Controls.WebApp.Comment.Index>(application, "Comments", "The threaded comment widget."),
                Page<Controls.WebApp.Comment.DataComposer>(application, "Comment composer", "Writing a new comment."),
                new("https://en.wikipedia.org/wiki/Monkey_Island", "Monkey Island", "The game series on Wikipedia."),
                new("https://monkeyisland.fandom.com/wiki/Guybrush_Threepwood", "Guybrush Threepwood", "A mighty pirate.")
            };

            var matches = items
                .Where(x => x.Uri is not null)
                .Where(x => string.IsNullOrWhiteSpace(search)
                    || x.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || x.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ResponseOK { Content = JsonSerializer.Serialize(new { Items = matches, Total = matches.Count }, _json) }
                .AddHeaderContentType("application/json");
        }

        /// <summary>
        /// Builds a link target for a page of this tutorial.
        /// </summary>
        /// <typeparam name="TPage">The page type.</typeparam>
        /// <param name="application">The application the address is resolved in.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <returns>The link target; its address is null for a page the sitemap does not know.</returns>
        private static LinkItem Page<TPage>(IApplicationContext application, string title, string description)
            where TPage : IEndpoint
        {
            return new LinkItem(LocalPath(WebEx.ComponentHub.SitemapManager.GetUri<TPage>(application)?.ToString()), title, description);
        }

        /// <summary>
        /// Reduces an address of this site to its path, so a stored link keeps working when the
        /// site is reached under another host name and is recognized as internal by the editor.
        /// </summary>
        /// <param name="uri">The address the sitemap resolved.</param>
        /// <returns>The path with its query, or null.</returns>
        private static string LocalPath(string uri)
        {
            return System.Uri.TryCreate(uri, UriKind.Absolute, out var absolute) ? absolute.PathAndQuery : uri;
        }

        /// <summary>
        /// A link target.
        /// </summary>
        /// <param name="Uri">The address.</param>
        /// <param name="Title">The title the link reads when nothing was selected.</param>
        /// <param name="Description">The description shown in the list.</param>
        private sealed record LinkItem(string Uri, string Title, string Description);
    }
}
