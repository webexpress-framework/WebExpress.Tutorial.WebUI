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
                    Text = _ => _text
                }
            ];

            Stage.Code = $"new ControlText() {{ Text = _ => \"{_text}\"}}";

            Stage.AddProperty
            (
                "Format",
                "Defines the format of the text.",
                "Format = _ => TypesTextFormat.Paragraph",
                new ControlText() { Text = _ => "Default", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Default
                },
                new ControlText() { Text = _ => "H1", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "Heading Level 1",
                    Format = _ => TypeFormatText.H1
                },
                new ControlText() { Text = _ => "H2", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "Heading Level 2",
                    Format = _ => TypeFormatText.H2
                },
                new ControlText() { Text = _ => "H3", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "Heading Level 3",
                    Format = _ => TypeFormatText.H3
                },
                new ControlText() { Text = _ => "H4", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "Heading Level 4",
                    Format = _ => TypeFormatText.H4
                },
                new ControlText() { Text = _ => "H5", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "Heading Level 5",
                    Format = _ => TypeFormatText.H5
                },
                new ControlText() { Text = _ => "H6", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "Heading Level 6",
                    Format = _ => TypeFormatText.H6
                },
                new ControlText() { Text = _ => "Paragraph", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.One), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Paragraph
                },
                new ControlText() { Text = _ => "Bold", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Bold
                },
                new ControlText() { Text = _ => "Italic", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Italic
                },
                new ControlText() { Text = _ => "Underline", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Underline
                },
                new ControlText() { Text = _ => "StruckOut", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.StruckOut
                },
                new ControlText() { Text = _ => "Cite", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Cite
                },
                new ControlText() { Text = _ => "Small", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Small
                },
                new ControlText() { Text = _ => "Strong", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Strong
                },
                new ControlText() { Text = _ => "Code", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "10 PRINT \"HELLO WORLD!\"<br>20 GOTO 10",
                    Format = _ => TypeFormatText.Code
                },
                new ControlText() { Text = _ => "Output", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => "C:\\DOS\\",
                    Format = _ => TypeFormatText.Output
                },
                new ControlText() { Text = _ => "Time", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => DateTime.Now.ToString(),
                    Format = _ => TypeFormatText.Time
                },
                new ControlText() { Text = _ => "Markdown", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => new StreamReader(GetType().Assembly.GetManifestResourceStream("WebExpress.Tutorial.WebUI.Assets.md\\example.md")).ReadToEnd(),
                    Format = _ => TypeFormatText.Markdown
                },
                new ControlText() { Text = _ => "Mark", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Mark
                },
                new ControlText() { Text = _ => "Highlight", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Highlight
                },
                new ControlText() { Text = _ => "Definition", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Definition
                },
                new ControlText() { Text = _ => "Abbreviation", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Abbreviation
                },
                new ControlText() { Text = _ => "Blockquote", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Blockquote
                },
                new ControlText() { Text = _ => "Figcaption", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Figcaption
                },
                new ControlText() { Text = _ => "Preformatted", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Format = _ => TypeFormatText.Preformatted
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Defines the text color.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Standard", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Default)
                },
                new ControlText() { Text = _ => "Primary", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary)
                },
                new ControlText() { Text = _ => "Info", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlText() { Text = _ => "Success", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Success)
                },
                new ControlText() { Text = _ => "Warning", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Warning)
                },
                new ControlText() { Text = _ => "Danger", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger)
                },
                new ControlText() { Text = _ => "Dark", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark)
                },
                new ControlText() { Text = _ => "Light", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Light)
                },
                new ControlText() { Text = _ => "White", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.White)
                },
                new ControlText() { Text = _ => "Highlight", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText(TypeColorText.Highlight)
                },
                new ControlText() { Text = _ => "Custom", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    TextColor = _ => new PropertyColorText("red")
                }
             );

            Stage.AddProperty
            (
                "Size",
                "Defines the text size.",
                "Size = new PropertySizeText(TypeSizeText.Small)",
                new ControlText() { Text = _ => "ExtraSmall", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraSmall)
                },
                new ControlText() { Text = _ => "Small", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Size = _ => new PropertySizeText(TypeSizeText.Small)
                },
                new ControlText() { Text = _ => "Standard", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Size = _ => new PropertySizeText(TypeSizeText.Default)
                },
                new ControlText() { Text = _ => "Large", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Size = _ => new PropertySizeText(TypeSizeText.Large)
                },
                new ControlText() { Text = _ => "ExtraLarge", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraLarge)
                },
                new ControlText() { Text = _ => "Custom", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Size = _ => new PropertySizeText(3.1f)
                }
            );

            Stage.AddProperty
            (
                "Title",
                "Defines a tooltip.",
                "Title = _ => \"Hello World!\"",
                new ControlText() { Text = _ => "Title", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlText()
                {
                    Text = _ => _text,
                    Title = _ => "Hello World!"
                }
             );
        }
    }
}
