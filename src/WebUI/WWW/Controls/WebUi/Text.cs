using System;
using System.IO;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the text control for the tutorial.  
    /// </summary>  
    [Title("Text")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Text : PageControl
    {
        private readonly string _text = "WebExpress is a lightweight web server written in C# and available for various platforms.";

        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        public Text()
        {
            Stage.Description = @"The `Text` control is a flexible component tailored for showcasing both static and dynamic text in web applications. It offers a range of styling, formatting, and customization features, enabling improved readability and an engaging user experience.";

            Stage.Controls = [
                new ControlText()
                {
                    Text = _text
                }
            ];

            Stage.Code = $"new ControlText() {{ Text = \"{_text}\"}}";

            Stage.AddProperty
            (
                "Format",
                "Defines the format of the text.",
                "Format = _ => TypesTextFormat.Paragraph",
                new ControlText() { Text = "Default", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Default
                },
                new ControlText() { Text = "H1", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "Heading Level 1",
                    Format = TypeFormatText.H1
                },
                new ControlText() { Text = "H2", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "Heading Level 2",
                    Format = TypeFormatText.H2
                },
                new ControlText() { Text = "H3", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "Heading Level 3",
                    Format = TypeFormatText.H3
                },
                new ControlText() { Text = "H4", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "Heading Level 4",
                    Format = TypeFormatText.H4
                },
                new ControlText() { Text = "H5", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "Heading Level 5",
                    Format = TypeFormatText.H5
                },
                new ControlText() { Text = "H6", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "Heading Level 6",
                    Format = TypeFormatText.H6
                },
                new ControlText() { Text = "Paragraph", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.One), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Paragraph
                },
                new ControlText() { Text = "Bold", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Bold
                },
                new ControlText() { Text = "Italic", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Italic
                },
                new ControlText() { Text = "Underline", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Underline
                },
                new ControlText() { Text = "StruckOut", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.StruckOut
                },
                new ControlText() { Text = "Cite", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Cite
                },
                new ControlText() { Text = "Small", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Small
                },
                new ControlText() { Text = "Strong", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Strong
                },
                new ControlText() { Text = "Code", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "10 PRINT \"HELLO WORLD!\"<br>20 GOTO 10",
                    Format = TypeFormatText.Code
                },
                new ControlText() { Text = "Output", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = "C:\\DOS\\",
                    Format = TypeFormatText.Output
                },
                new ControlText() { Text = "Time", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = DateTime.Now.ToString(),
                    Format = TypeFormatText.Time
                },
                new ControlText() { Text = "Markdown", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = new StreamReader(GetType().Assembly.GetManifestResourceStream("WebExpress.Tutorial.WebUI.Assets.md\\example.md")).ReadToEnd(),
                    Format = TypeFormatText.Markdown
                },
                new ControlText() { Text = "Mark", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Mark
                },
                new ControlText() { Text = "Highlight", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Highlight
                },
                new ControlText() { Text = "Definition", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Definition
                },
                new ControlText() { Text = "Abbreviation", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Abbreviation
                },
                new ControlText() { Text = "Blockquote", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Blockquote
                },
                new ControlText() { Text = "Figcaption", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Figcaption
                },
                new ControlText() { Text = "Preformatted", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Format = TypeFormatText.Preformatted
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Defines the text color.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Standard", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Default)
                },
                new ControlText() { Text = "Primary", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Primary)
                },
                new ControlText() { Text = "Info", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlText() { Text = "Success", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Success)
                },
                new ControlText() { Text = "Warning", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Warning)
                },
                new ControlText() { Text = "Danger", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Danger)
                },
                new ControlText() { Text = "Dark", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Dark)
                },
                new ControlText() { Text = "Light", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Light)
                },
                new ControlText() { Text = "White", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.White)
                },
                new ControlText() { Text = "Highlight", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText(TypeColorText.Highlight)
                },
                new ControlText() { Text = "Custom", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    TextColor = new PropertyColorText("red")
                }
             );

            Stage.AddProperty
            (
                "Size",
                "Defines the text size.",
                "Size = new PropertySizeText(TypeSizeText.Small)",
                new ControlText() { Text = "ExtraSmall", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Size = new PropertySizeText(TypeSizeText.ExtraSmall)
                },
                new ControlText() { Text = "Small", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Size = new PropertySizeText(TypeSizeText.Small)
                },
                new ControlText() { Text = "Standard", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Size = new PropertySizeText(TypeSizeText.Default)
                },
                new ControlText() { Text = "Large", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Size = new PropertySizeText(TypeSizeText.Large)
                },
                new ControlText() { Text = "ExtraLarge", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Size = new PropertySizeText(TypeSizeText.ExtraLarge)
                },
                new ControlText() { Text = "Custom", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Size = new PropertySizeText(3.1f)
                }
            );

            Stage.AddProperty
            (
                "Title",
                "Defines a tooltip.",
                "Title = \"Hello World!\"",
                new ControlText() { Text = "Title", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _text,
                    Title = "Hello World!"
                }
             );
        }
    }
}
