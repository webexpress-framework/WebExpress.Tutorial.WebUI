using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the code control for the tutorial.  
    /// </summary>  
    [Title("Code")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Code : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        public Code()
        {
            Stage.Description = @"The `Code` control provides a clean and structured way to display source code within a defined box, complete with syntax highlighting. It’s particularly useful in development environments, documentation platforms, or educational tools where readable and well-organized code presentation is essential. With features such as automatic line wrapping and a copy button, this control enhances usability and improves the overall interaction with code snippets.";

            Stage.Controls = [
                new ControlCode()
                    {
                        Code = _ => "cls\nprint \"hello world!\"",
                        Language = _ => TypeLanguage.Basic,
                        LineNumbers = _ => true
                    }
            ];

            Stage.Code = @"
            new ControlCode()
            {
                Code = _ => ""cls\nprint \""hello world!\"""",
                Language = _ => TypeLanguage.Basic,
                LineNumbers = _ => true
            }";

            Stage.AddProperty
            (
                "Language",
                "The `Language` property specifies the programming language of the code being displayed. It plays a key role in enabling accurate syntax highlighting and ensures that code is presented in a visually consistent and readable manner.",
                "Language = _ => TypeLanguage.Bash",
                // Default
                new ControlText() { Text = "Default", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Default, Code = _ => "hello world!" },

                // Bash
                new ControlText() { Text = "Bash", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Bash, Code = _ => "#!/bin/bash\necho \"Hello, world!\"" },

                // Basic
                new ControlText() { Text = "Basic", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Basic, Code = _ => "PRINT \"Hello, world!\"" },

                // Cmd
                new ControlText() { Text = "Cmd", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Cmd, Code = _ => "@echo Hello, world!" },

                // Cobol
                new ControlText() { Text = "Cobol", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Cobol, Code = _ => "DISPLAY \"Hello, world!\"" },

                // C++
                new ControlText() { Text = "C++", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Cpp, Code = _ => "#include <iostream>\nint main() {\n    std::cout << \"Hello, world!\";\n    return 0;\n}" },

                // C#
                new ControlText() { Text = "C#", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.CSharp, Code = _ => "Console.WriteLine(\"Hello, world!\");" },

                // Groovy
                new ControlText() { Text = "Groovy", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Groovy, Code = _ => "println 'Hello, world!'" },

                // Java
                new ControlText() { Text = "Java", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Java, Code = _ => "public class HelloWorld {\n    public static void main(String[] args) {\n        System.out.println(\"Hello, world!\");\n    }\n}" },

                // JavaScript
                new ControlText() { Text = "JavaScript", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.JavaScript, Code = _ => "console.log(\"Hello, world!\");" },

                // Markdown
                new ControlText() { Text = "Markdown", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Markdown, Code = _ => "# Hello, world!" },

                // PHP
                new ControlText() { Text = "PHP", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Php, Code = _ => "<?php\necho \"Hello, world!\";\n?>" },

                // PowerShell
                new ControlText() { Text = "PowerShell", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.PowerShell, Code = _ => "Write-Host \"Hello, world!\"" },

                // Property
                new ControlText() { Text = "Property", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Property, Code = _ => "greeting=Hello, world!" },

                // Python
                new ControlText() { Text = "Python", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Python, Code = _ => "print(\"Hello, world!\")" },

                // VisualBasic
                new ControlText() { Text = "Visual Basic", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.VisualBasic, Code = _ => "Console.WriteLine(\"Hello, world!\")" },

                // XML
                new ControlText() { Text = "XML", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Xml, Code = _ => "<message>Hello, world!</message>" }
            );

            Stage.AddProperty
            (
                "LineNumbers",
                "The `LineNumbers` property controls whether line numbers are displayed alongside the code within a code-display control.",
                "LineNumbers = true",
                // Default
                new ControlText() { Text = "False", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Bash, Code = _ => "#!/bin/bash\necho \"Hello, world!\"", LineNumbers = _ => false },

                // Bash
                new ControlText() { Text = "True", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Bash, Code = _ => "#!/bin/bash\necho \"Hello, world!\"", LineNumbers = _ => true }
            );
        }
    }
}
