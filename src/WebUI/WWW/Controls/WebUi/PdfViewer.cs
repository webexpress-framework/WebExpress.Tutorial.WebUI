using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the pdf viewer control for the tutorial.
    /// </summary>
    [WebIcon<IconControlPdfViewer>]
    [Title("PDF Viewer")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class PdfViewer : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page, for the address of the PDF endpoint.</param>
        /// <param name="sitemapManager">The sitemap manager that resolves the PDF endpoint.</param>
        public PdfViewer(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            // the samples show the files the content tutorial renders on the server, so the
            // viewer has a document of several pages to open without shipping one
            IUri Pdf(string format) => sitemapManager.GetUri<ContentPdf>(pageContext).Add(new UriQuery("format", format));

            Stage.Description = @"The `PdfViewer` shows a PDF file inside the page. It embeds the file with an `<object>` element and leaves the drawing to the viewer the browser brings along, so no script and no third-party renderer are loaded, and scrolling, searching, printing and downloading work as the reader knows them from the browser. A browser without an inline viewer - most mobile browsers among them - shows a short note and a link that opens the file on its own instead. The file is subject to the `object-src` directive of the content security policy, which by default only admits files of the own server.";

            Stage.Control = new ControlPdfViewer()
            {
                Uri = _ => Pdf("showcase"),
                Label = _ => "The Secret of Monkey Island"
            };

            // the browser's viewer brings its own colours, and a second copy of the file would
            // only load the same document twice
            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlPdfViewer()
            {
                Uri = _ => sitemapManager.GetUri<ContentPdf>(pageContext).Add(new UriQuery(""format"", ""showcase"")),
                Label = _ => ""The Secret of Monkey Island""
            };";

            Stage.AddProperty
            (
                "Uri",
                "The `Uri` property is the address of the PDF file. It becomes the source of the embedded object and the target of the link the fallback offers. The server should answer with the content type `application/pdf` and an `inline` content disposition, otherwise the browser offers the file for download instead of showing it.",
                "Uri = _ => sitemapManager.GetUri<ContentPdf>(pageContext).Add(new UriQuery(\"format\", \"markdown\"))",
                new ControlPdfViewer()
                {
                    Uri = _ => Pdf("markdown"),
                    Label = _ => "Content as markdown"
                }
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property names the embedded document for assistive technology. A screen reader announces the viewer as a region of its own, and without a name it would only be read out as an unnamed object. The text may be an internationalization key.",
                "Label = _ => \"Content as rich text\"",
                new ControlPdfViewer()
                {
                    Uri = _ => Pdf("richtext"),
                    Label = _ => "Content as rich text"
                }
            );

            Stage.AddProperty
            (
                "Height",
                "The `Height` property sets the height of the viewer in pixels. Without it the viewer takes the height the stylesheet gives it, which is enough to read a page; an object element without any height would collapse to 150 pixels. The width always follows the surrounding container.",
                "Height = _ => 300",
                new ControlPdfViewer()
                {
                    Uri = _ => Pdf("richtext"),
                    Label = _ => "Content as rich text",
                    Height = _ => 300
                }
            );

            Stage.AddProperty
            (
                "Page",
                "The `Page` property selects the page the viewer opens at, counting from 1. Like the other open parameters it is appended to the fragment of the address, which the browser hands to its viewer without sending it to the server - the file stays the same cached resource whichever page is opened.",
                "Page = _ => 3",
                new ControlPdfViewer()
                {
                    Uri = _ => Pdf("showcase"),
                    Label = _ => "The Secret of Monkey Island, page 3",
                    Page = _ => 3
                }
            );

            Stage.AddProperty
            (
                "Zoom",
                "The `Zoom` property sets the zoom factor the viewer opens with, in percent. The reader can change it at any time in the viewer itself.",
                "Zoom = _ => 50",
                new ControlPdfViewer()
                {
                    Uri = _ => Pdf("showcase"),
                    Label = _ => "The Secret of Monkey Island at half size",
                    Zoom = _ => 50
                }
            );

            Stage.AddProperty
            (
                "Toolbar",
                "The `Toolbar` property asks the viewer to hide its toolbar, so the document takes all of the space. It is a request rather than a guarantee: Chromium-based browsers follow it, Firefox keeps its toolbar.",
                "Toolbar = _ => false",
                new ControlPdfViewer()
                {
                    Uri = _ => Pdf("plugin"),
                    Label = _ => "Plugins as PDF",
                    Toolbar = _ => false
                }
            );
        }
    }
}
