using System;
using System.IO;
using System.Linq;
using System.Reflection;
using WebExpress.Tutorial.WebUI.WWW.Controls.WebUi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebUI.WebEditor;
using WebExpress.WebUI.WebPdf;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The endpoint behind the PDF demo of the content control: it renders the values the
    /// tutorial page shows into a PDF file on the server and answers with the file, so the
    /// output can be checked in the browser's own viewer.
    /// </summary>
    /// <remarks>
    /// <c>format=richtext</c> renders the stored editor value, <c>format=markdown</c> the same
    /// document brought into markdown, and <c>format=showcase</c> a document that exercises
    /// every block the renderer knows - long enough to break across pages, so the repeated
    /// table header, the running footer and the bookmarks can be seen.
    /// </remarks>
    [Segment("content-pdf")]
    [Title("Content PDF")]
    public sealed class ContentPdf : IRestApi
    {
        /// <summary>
        /// Renders the requested sample and returns it as a PDF file.
        /// </summary>
        /// <param name="request">The request context.</param>
        /// <returns>A response carrying the file.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(Request request)
        {
            var format = request?.GetParameter("format")?.Value?.ToLowerInvariant() ?? "richtext";
            var document = format switch
            {
                "markdown" => PdfRendererMarkdown.ConvertMarkdownToPdf(Content.CreateMarkdown()),
                "showcase" => EditorContent.ConvertToPdf(CreateShowcase(request.ApplicationContext.Route.Concat("assets/img/image1.png").ToString())),
                _ => EditorContent.ConvertToPdf(Content.CreateEditorValue())
            };

            document.Title = $"WebExpress content ({format})";
            document.Author = "WebExpress tutorial";
            document.Language = "en";
            document.Footer = "Page {page} of {pages}";
            document.ImageResolver = LoadAsset;

            var response = new ResponseOK
            {
                Content = document.ToArray()
            }
                .AddHeaderContentType("application/pdf");

            // inline lets the browser show the file in its viewer instead of downloading it
            response.Header.ContentDisposition = $"inline; filename=\"content-{format}.pdf\"";

            return response;
        }

        /// <summary>
        /// Loads a picture of the tutorial's own assets. The renderer asks for every address
        /// a text names; only the pictures embedded in this plugin are answered, so a text
        /// cannot make the server fetch anything else.
        /// </summary>
        /// <param name="source">The address as written in the text.</param>
        /// <returns>The picture, or null.</returns>
        private static byte[] LoadAsset(string source)
        {
            var path = source?.Replace('\\', '/');

            // only a path on this site is answered; an address with a host stays unfetched
            if (path is null || path.Contains("://") || path.StartsWith("//") || path.Contains(".."))
            {
                return null;
            }

            var index = path.IndexOf("assets/img/", StringComparison.OrdinalIgnoreCase);

            if (index < 0)
            {
                return null;
            }

            // the resource name keeps the folder separator of the build machine
            var assembly = Assembly.GetExecutingAssembly();
            var suffix = ".Assets." + path[(index + "assets/".Length)..].Replace('/', '.');
            var name = assembly.GetManifestResourceNames()
                .FirstOrDefault(n => n.Replace('\\', '.').Replace('/', '.').EndsWith(suffix, StringComparison.OrdinalIgnoreCase));

            if (name is null)
            {
                return null;
            }

            using var stream = assembly.GetManifestResourceStream(name);
            using var memory = new MemoryStream();
            stream.CopyTo(memory);

            return memory.ToArray();
        }

        /// <summary>
        /// Builds an editor value that uses every block and inline format the PDF renderer
        /// understands.
        /// </summary>
        /// <param name="picture">The address of the picture, as the page links it.</param>
        /// <returns>The raw editor value.</returns>
        internal static string CreateShowcase(string picture)
        {
            var rows = string.Concat(Enumerable.Range(1, 40).Select(i =>
                $"<tr><td>{i}</td><td>Insult number {i}</td><td style=\"text-align: right\">{i * 7 % 100} %</td></tr>"));

            return "<h1>The Secret of Monkey Island</h1>"
                + "<p style=\"text-align: justify\">Guybrush Threepwood arrives on M&#234;l&#233;e Island with one ambition: to become a mighty pirate. "
                + "Text can be <b>bold</b>, <i>italic</i>, <u>underlined</u>, <s>struck through</s>, <mark>marked</mark>, "
                + "<span style=\"color: #d63384\">colored</span>, <span style=\"background-color: #cfe2ff\">highlighted</span>, "
                + "x<sup>2</sup>, H<sub>2</sub>O, <code>inline code</code> or a <a href=\"https://github.com/webexpress-framework\">link</a>. "
                + "Umlauts and typography survive: Gr&#252;&#223;e, 10 &#8364;, &#8222;quoted&#8220; &#8211; and a dash.</p>"
                + "<p style=\"margin-left: 40px\">An indented paragraph, the way the editor indents a block.</p>"
                + "<p style=\"text-align: center\"><span style=\"font-size: 24px\">A larger, centered line</span></p>"
                + "<h2>Blocks</h2>"
                + "<div class=\"alert alert-warning\"><strong>Warning:</strong> Never pet a three-headed monkey.</div>"
                + "<div class=\"wx-callout wx-callout-success\"><div class=\"wx-callout-body\">The voodoo lady approves.</div></div>"
                + "<blockquote><p>You fight like a dairy farmer.</p><p>How appropriate. You fight like a cow.</p></blockquote>"
                + "<pre><code class=\"language-csharp\">var document = EditorContent.ConvertToPdf(value);\n"
                + "document.Footer = \"Page {page} of {pages}\";\nreturn document.ToArray();</code></pre>"
                + "<h3>Lists</h3>"
                + "<ul><li>Sword fighting<ul><li>Insults<ul><li>Comebacks</li></ul></li></ul></li><li>Thievery</li>"
                + "<li><input type=\"checkbox\" checked> Find the treasure</li><li><input type=\"checkbox\"> Rescue the governor</li></ul>"
                + "<ol type=\"I\"><li>Part one</li><li>Part two</li><li>Part three</li></ol>"
                + "<h3>Regions</h3>"
                + "<div class=\"wx-editor-row\"><div class=\"wx-editor-region\" data-weight=\"1\"><p><b>Left region</b> - one third of the row.</p></div>"
                + "<div class=\"wx-editor-region\" data-weight=\"2\"><p><b>Right region</b> - two thirds of the row, as the author weighted it in the editor.</p></div></div>"
                + "<h3>Picture</h3>"
                + $"<img src=\"{picture}\" alt=\"Monkey Island\" style=\"display: block; width: 320px; margin-left: auto; margin-right: auto\">"
                + "<p style=\"text-align: center\"><i>A picture resolved from the assets of the tutorial.</i></p>"
                + "<img src=\"https://example.com/not-fetched.png\" alt=\"A picture the server refuses to fetch\" style=\"display: block\">"
                + "<h2>Table across pages</h2>"
                + "<table class=\"table table-striped table-bordered\"><colgroup><col style=\"width: 60px\"><col><col style=\"width: 100px\"></colgroup>"
                + "<thead><tr><th>#</th><th>Insult</th><th>Effect</th></tr></thead><tbody>" + rows + "</tbody></table>"
                + "<hr><p>That's the second biggest PDF I've ever seen!</p>";
        }
    }
}
