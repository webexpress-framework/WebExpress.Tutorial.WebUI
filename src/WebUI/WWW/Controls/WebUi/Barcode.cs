using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the barcode control for the tutorial.
    /// </summary>
    [WebIcon<IconBarcode>]
    [Title("Barcode")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Barcode : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the barcode control is used.</param>
        public Barcode(IPageContext pageContext)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.DATA_ERROR_EVENT);

            Stage.Description = @"The `Barcode` control encodes a value as a scannable graphic - either as a linear symbology (`Code 128`, `Code 39`, `EAN-13`, `EAN-8`) or as a two-dimensional `QR` code.

The encoders are part of the control rather than a dependency, because a barcode has to be drawn offline and inside a strict content policy: no CDN, no external image service. Everything is rendered as inline SVG, which stays crisp at any size and prints without artefacts.

A value the chosen symbology cannot express is refused rather than drawn - a symbol that renders but does not scan fails only at the scanner, which is later and worse. The control says so instead, and reports it as an event.";

            Stage.Control = new ControlBarcode("myBarcode")
            {
                Value = _ => "4006381333931",
                Type = _ => TypeBarcode.Ean13
            };

            Stage.Code = @"
                new ControlBarcode(""myBarcode"")
                {
                    Value = _ => ""4006381333931"",
                    Type = _ => TypeBarcode.Ean13
                };";

            Stage.AddProperty
            (
                "Type",
                @"The `Type` property selects the symbology. `Code128` is the dense general purpose choice and the default; `Code39` is less dense but is what many older scanners and label printers expect; `Ean13` and `Ean8` are the article numbers of retail trade, whose check digit is computed when it is missing and verified when it is given; `QR` holds far more than a linear symbology and survives partial damage, which makes it the choice for urls and for anything scanned by a phone camera.",
                "Type = _ => TypeBarcode.QR",
                new ControlText() { Text = _ => "Code 128", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "WX-2026-4711", Type = _ => TypeBarcode.Code128 },
                new ControlText() { Text = _ => "Code 39", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "WX-2026-4711", Type = _ => TypeBarcode.Code39 },
                new ControlText() { Text = _ => "EAN-13", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "4006381333931", Type = _ => TypeBarcode.Ean13 },
                new ControlText() { Text = _ => "EAN-8", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "96385074", Type = _ => TypeBarcode.Ean8 },
                new ControlText() { Text = _ => "QR", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "https://webexpress-framework.github.io/", Type = _ => TypeBarcode.QR }
            );

            Stage.AddProperty
            (
                "Value",
                "The `Value` property is what the symbol encodes. A value the symbology cannot express - here an EAN-13 whose check digit does not match its digits - is refused rather than drawn, and reported through the error event.",
                "Value = _ => \"4006381333932\"",
                new ControlText() { Text = _ => "A valid article number", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "4006381333931", Type = _ => TypeBarcode.Ean13 },
                new ControlText() { Text = _ => "One digit off: the check digit no longer matches", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "4006381333932", Type = _ => TypeBarcode.Ean13 }
            );

            Stage.AddProperty
            (
                "ErrorCorrection",
                "The `ErrorCorrection` property sets how much of a QR code can be lost and still be read: about 7% at `Low`, 15% at `Medium`, 25% at `Quartile` and 30% at `High`. The redundancy comes out of the capacity, so the same value needs a larger symbol at a higher level - which is what makes the four codes below grow while carrying the same url. It has no meaning for the linear symbologies and is ignored there.",
                "ErrorCorrection = _ => TypeErrorCorrectionBarcode.High",
                new ControlText() { Text = _ => "Low", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "https://webexpress-framework.github.io/", Type = _ => TypeBarcode.QR, ErrorCorrection = _ => TypeErrorCorrectionBarcode.Low },
                new ControlText() { Text = _ => "Medium", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "https://webexpress-framework.github.io/", Type = _ => TypeBarcode.QR, ErrorCorrection = _ => TypeErrorCorrectionBarcode.Medium },
                new ControlText() { Text = _ => "Quartile", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "https://webexpress-framework.github.io/", Type = _ => TypeBarcode.QR, ErrorCorrection = _ => TypeErrorCorrectionBarcode.Quartile },
                new ControlText() { Text = _ => "High", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "https://webexpress-framework.github.io/", Type = _ => TypeBarcode.QR, ErrorCorrection = _ => TypeErrorCorrectionBarcode.High }
            );

            Stage.AddProperty
            (
                "Color",
                @"The `Color` property colors the modules - the bars of a linear symbology or the squares of a QR code - and `BackgroundColor` the quiet zone around them. Both accept a palette color as well as a custom one.

A scanner reads contrast rather than color, and expects a dark symbol on a light ground: a light color therefore needs a dark ground, and two colors close to each other do not scan at all however good they look on screen. Red on white is the classic failure, because many laser scanners use a red light source and see red as white.",
                "Color = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "A palette color", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode()
                {
                    Value = _ => "https://webexpress-framework.github.io/",
                    Type = _ => TypeBarcode.QR,
                    Color = _ => new PropertyColorText(TypeColorText.Primary)
                },
                new ControlText() { Text = _ => "A custom color", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode()
                {
                    Value = _ => "WX-2026-4711",
                    Color = _ => new PropertyColorText("#0d3b66"),
                    BackgroundColor = _ => new PropertyColorBackground("#fff8e1")
                },
                new ControlText() { Text = _ => "Inverted: a light symbol needs a dark ground", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode()
                {
                    Value = _ => "https://webexpress-framework.github.io/",
                    Type = _ => TypeBarcode.QR,
                    Color = _ => new PropertyColorText("#f5f5f5"),
                    BackgroundColor = _ => new PropertyColorBackground("#111111")
                }
            );

            Stage.AddProperty
            (
                "ModuleWidth",
                "The `ModuleWidth` property is the width of a single module in pixels and is what scales the symbol. It is the setting to raise when a printed code is not read - unlike a css size, which enlarges the graphic without giving the scanner more to resolve.",
                "ModuleWidth = _ => 4",
                new ControlText() { Text = _ => "1 pixel per module", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "WX-2026", ModuleWidth = _ => 1 },
                new ControlText() { Text = _ => "3 pixels per module", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlBarcode() { Value = _ => "WX-2026", ModuleWidth = _ => 3 }
            );

            Stage.AddProperty
            (
                "BarHeight",
                "The `BarHeight` property sets how tall the bars of a linear symbology are. A QR code is square and takes its extent from the module width instead.",
                "BarHeight = _ => 100",
                new ControlBarcode() { Value = _ => "WX-2026", BarHeight = _ => 30 },
                new ControlBarcode() { Value = _ => "WX-2026", BarHeight = _ => 100 }
            );

            Stage.AddProperty
            (
                "ShowText",
                "The `ShowText` property prints the encoded value below a linear symbol, so it stays readable when the symbol does not scan. Turn it off where the value is shown elsewhere anyway.",
                "ShowText = _ => false",
                new ControlBarcode() { Value = _ => "4006381333931", Type = _ => TypeBarcode.Ean13, ShowText = _ => false }
            );

            Stage.AddProperty
            (
                "Inline edit",
                @"A barcode is not human readable, so a bare text field gives no feedback on whether a value can be encoded at all. `ControlFormItemInputBarcode` therefore pairs the field with a live preview, which answers that while the value is typed and marks the field invalid as soon as it stops encoding - try removing a digit from the article number below.

The same input becomes an inline edit inside a table through `ControlTableTemplateBarcode`: the cell shows the symbol and swaps to the field on a double click.",
                "new ControlFormItemInputBarcode() { Type = _ => TypeBarcode.Ean13 }",
                new ControlForm()
                {
                }
                    .Add
                    (
                        new ControlFormItemInputBarcode("article")
                        {
                            Name = _ => "article",
                            Label = _ => "Article number (EAN-13)",
                            Type = _ => TypeBarcode.Ean13,
                            Value = _ => "4006381333931"
                        },
                        new ControlFormItemInputBarcode("link")
                        {
                            Name = _ => "link",
                            Label = _ => "Link (QR)",
                            Type = _ => TypeBarcode.QR,
                            ErrorCorrection = _ => TypeErrorCorrectionBarcode.Quartile,
                            Value = _ => "https://webexpress-framework.github.io/",
                            // the preview is shown in the colors the value will
                            // be displayed in, so nothing shifts when the editor closes
                            Color = _ => new PropertyColorText("#0d3b66")
                        }
                    )
            );
        }
    }
}
