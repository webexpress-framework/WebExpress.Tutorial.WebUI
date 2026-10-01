using System;
using System.Collections.Generic;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebPdf;
using WebExpress.WebUI.WebPdf.Element;

namespace WebExpress.Tutorial.WebUI.WebPdf
{
    /// <summary>
    /// Shows how a plugin outside of the framework decides what a markdown plugin looks like
    /// in a PDF file. A text names a ticket of an issue tracker with <c>{{ticket id="WX-42"}}</c>
    /// inline, or with <c>{{% ticket id="WX-42" status="open" %}}…{{% /ticket %}}</c> as a box
    /// around a note about it. The framework only carries the name and the parameters; being
    /// public, sealed and named, the class is registered by the PDF plugin manager when the
    /// tutorial plugin is loaded.
    /// </summary>
    [Name("ticket")]
    public sealed class TicketPdfPlugin : IPdfPlugin
    {
        private static readonly PdfColor TicketBackground = new(231, 241, 255);
        private static readonly PdfColor OpenBackground = new(255, 243, 205);
        private static readonly PdfColor ClosedBackground = new(209, 231, 221);

        /// <summary>
        /// Sets the ticket number as a code-like token within the line, in the style of the
        /// text around it, so it stays bold within bold text.
        /// </summary>
        /// <param name="element">The element, with its parameters and the surrounding style.</param>
        /// <returns>The inline elements that take the element's place.</returns>
        public IEnumerable<PdfInlineElement> ConvertInline(PdfInlineElementPlugin element)
        {
            var id = element.Parameters.GetValueOrDefault("id");

            if (string.IsNullOrWhiteSpace(id))
            {
                return [];
            }

            return [new PdfInlineElementText(id, element.Style with
            {
                FontFamily = PdfFontFamily.Courier,
                Scale = element.Style.Scale * 0.9f,
                Background = TicketBackground
            })];
        }

        /// <summary>
        /// Frames the enclosed note in a box whose head names the ticket and is tinted by its
        /// status. A table is used because it already breaks across pages and keeps its head.
        /// </summary>
        /// <param name="element">The element, with its parameters and content.</param>
        /// <returns>The blocks that take the element's place.</returns>
        public IEnumerable<PdfBlockElement> ConvertBlock(PdfBlockElementPlugin element)
        {
            var id = element.Parameters.GetValueOrDefault("id") ?? "Ticket";
            var status = element.Parameters.GetValueOrDefault("status");
            var head = string.IsNullOrWhiteSpace(status) ? id : $"{id} - {status}";

            return [new PdfBlockElementTable()
                .Add(new PdfBlockElementTableRow([new PdfBlockElementTableCell(head)])
                {
                    Header = true,
                    Background = string.Equals(status, "closed", StringComparison.OrdinalIgnoreCase)
                        ? ClosedBackground
                        : OpenBackground
                })
                .Add(new PdfBlockElementTableRow([new PdfBlockElementTableCell(element.Content)]))];
        }
    }
}
