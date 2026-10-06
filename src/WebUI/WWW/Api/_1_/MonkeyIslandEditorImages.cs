using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExpress.WebCore;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebParameter;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebStatusPage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The image library behind the image page WebApp adds to the editor's image dialog. It
    /// serves as both the upload and the images service of the demo: a POST stores an image and
    /// answers with its address, a GET lists the images, and a GET with an id delivers one.
    /// </summary>
    /// <remarks>
    /// The demo keeps uploads in memory, bounded in number and size, and accepts only raster
    /// formats - an uploaded SVG is a document that runs script when it is opened from this site.
    /// The pictures of the tutorial's own assets are listed beside them.
    /// </remarks>
    [Segment("editor-images")]
    [Title("Monkey Island Editor Images")]
    public sealed class MonkeyIslandEditorImages : IRestApi
    {
        private const int MaxImages = 20;
        private const int MaxBytes = 2 * 1024 * 1024;
        private static readonly string[] _assets = ["image1.png", "image2.png", "image3.png", "carousel1.png", "carousel2.png", "carousel3.png", "dex_zogbert.png", "rocket.png"];
        private static readonly HashSet<string> _contentTypes = ["image/png", "image/jpeg", "image/gif", "image/webp"];
        private static readonly JsonSerializerOptions _json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        private static readonly object _syncRoot = new();
        private static readonly List<StoredImage> _uploads = [];
        private static int _nextId;

        /// <summary>
        /// Lists the images matching the search, or delivers one uploaded image when an id is given.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The image list, or the image.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            var id = request.GetParameter("id")?.Value;
            if (!string.IsNullOrEmpty(id))
            {
                StoredImage image;
                lock (_syncRoot)
                {
                    image = _uploads.FirstOrDefault(x => x.Id == id);
                }

                return image is null
                    ? new ResponseNotFound()
                    : new ResponseOK { Content = image.Data }.AddHeaderContentType(image.ContentType);
            }

            var search = request.GetParameter("q")?.Value ?? string.Empty;
            var self = SelfUri(request);
            List<LibraryItem> items;
            lock (_syncRoot)
            {
                items = [.. _uploads
                    .AsEnumerable()
                    .Reverse()
                    .Select(x => Item(x.Id, x.Name, $"{self}?id={x.Id}"))];
            }
            items.AddRange(_assets.Select(x => Item(x, x, request.ApplicationContext.Route.Concat("assets/img/" + x).ToString())));

            var matches = items
                .Where(x => string.IsNullOrWhiteSpace(search) || x.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Json(new { Items = matches, Total = matches.Count });
        }

        /// <summary>
        /// Stores an uploaded image and answers with the address it can be inserted under.
        /// </summary>
        /// <param name="request">The request carrying the image in the multipart field "file".</param>
        /// <returns>The stored image.</returns>
        [Method(RequestMethod.POST)]
        public IResponse Create(Request request)
        {
            var file = request.Parameters.OfType<ParameterFile>().FirstOrDefault();
            if (file?.Data is null || file.Data.Length == 0)
            {
                return new ResponseBadRequest(new StatusMessage("No image was uploaded."));
            }
            if (!_contentTypes.Contains(file.ContentType?.ToLowerInvariant() ?? string.Empty))
            {
                return new ResponseBadRequest(new StatusMessage("Only PNG, JPEG, GIF and WebP images are accepted."));
            }
            if (file.Data.Length > MaxBytes)
            {
                return new ResponsePayloadTooLarge(new StatusMessage("The image is larger than 2 MB."));
            }

            var image = new StoredImage("u" + System.Threading.Interlocked.Increment(ref _nextId), System.IO.Path.GetFileName(file.Value ?? "image"), file.ContentType.ToLowerInvariant(), file.Data);
            lock (_syncRoot)
            {
                _uploads.Add(image);
                // the demo runs unattended, so the oldest uploads make room instead of growing without end
                while (_uploads.Count > MaxImages)
                {
                    _uploads.RemoveAt(0);
                }
            }

            return Json(Item(image.Id, image.Name, $"{SelfUri(request)}?id={image.Id}"));
        }

        /// <summary>
        /// Builds a list entry in the item shape of a file result.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The file name.</param>
        /// <param name="uri">The address the image is shown from.</param>
        /// <returns>The entry.</returns>
        private static LibraryItem Item(string id, string name, string uri)
        {
            return new LibraryItem(id, name, uri, uri);
        }

        /// <summary>
        /// Resolves the address of this endpoint, which the uploaded images are delivered from.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The address.</returns>
        private static string SelfUri(Request request)
        {
            return LocalPath(WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandEditorImages>(request.ApplicationContext)?.ToString());
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
        /// Creates a JSON response.
        /// </summary>
        /// <param name="data">The payload.</param>
        /// <returns>The response.</returns>
        private static IResponse Json(object data)
        {
            return new ResponseOK { Content = JsonSerializer.Serialize(data, _json) }.AddHeaderContentType("application/json");
        }

        /// <summary>
        /// An uploaded image held in memory.
        /// </summary>
        /// <param name="Id">The id the image is delivered under.</param>
        /// <param name="Name">The file name.</param>
        /// <param name="ContentType">The accepted content type.</param>
        /// <param name="Data">The bytes.</param>
        private sealed record StoredImage(string Id, string Name, string ContentType, byte[] Data);

        /// <summary>
        /// An entry of the image list, in the item shape of a file result.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <param name="Name">The file name.</param>
        /// <param name="Uri">The address the image is inserted under.</param>
        /// <param name="Image">The address of the preview.</param>
        private sealed record LibraryItem(string Id, string Name, string Uri, string Image);
    }
}
