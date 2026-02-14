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
                        Code = "cls\nprint \"hello world!\"",
                        Language = TypeLanguage.Basic,
                        LineNumbers = true
                    }
            ];

            Stage.Code = @"
            new ControlCode()
            {
                Code = ""cls\nprint \""hello world!\"""",
                Language = TypeLanguage.Basic,
                LineNumbers = true
            }";

            Stage.AddProperty
            (
                "Language",
                "The `Language` property specifies the programming language of the code being displayed. It plays a key role in enabling accurate syntax highlighting and ensures that code is presented in a visually consistent and readable manner.",
                "Language = TypeLanguage.Bash",
                // Default
                new ControlText() { Text = "Default", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Default, Code = "hello world!" },

                // Bash
                new ControlText() { Text = "Bash", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Bash, Code = "#!/bin/bash\necho \"Hello, world!\"" },

                // Basic
                new ControlText() { Text = "Basic", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Basic, Code = "PRINT \"Hello, world!\"" },

                // Cmd
                new ControlText() { Text = "Cmd", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Cmd, Code = "@echo Hello, world!" },

                // Cobol
                new ControlText() { Text = "Cobol", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Cobol, Code = "DISPLAY \"Hello, world!\"" },

                // C++
                new ControlText() { Text = "C++", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Cpp, Code = "#include <iostream>\nint main() {\n    std::cout << \"Hello, world!\";\n    return 0;\n}" },

                // C#
                new ControlText() { Text = "C#", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.CSharp, Code = "Console.WriteLine(\"Hello, world!\");" },

                // Groovy
                new ControlText() { Text = "Groovy", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Groovy, Code = "println 'Hello, world!'" },

                // Java
                new ControlText() { Text = "Java", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Java, Code = "public class HelloWorld {\n    public static void main(String[] args) {\n        System.out.println(\"Hello, world!\");\n    }\n}" },

                // JavaScript
                new ControlText() { Text = "JavaScript", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.JavaScript, Code = "console.log(\"Hello, world!\");" },

                // Markdown
                new ControlText() { Text = "Markdown", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Markdown, Code = "# Hello, world!" },

                // PHP
                new ControlText() { Text = "PHP", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Php, Code = "<?php\necho \"Hello, world!\";\n?>" },

                // PowerShell
                new ControlText() { Text = "PowerShell", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.PowerShell, Code = "Write-Host \"Hello, world!\"" },

                // Property
                new ControlText() { Text = "Property", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Property, Code = "greeting=Hello, world!" },

                // Python
                new ControlText() { Text = "Python", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Python, Code = "print(\"Hello, world!\")" },

                // VisualBasic
                new ControlText() { Text = "Visual Basic", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.VisualBasic, Code = "Console.WriteLine(\"Hello, world!\")" },

                // XML
                new ControlText() { Text = "XML", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Xml, Code = "<message>Hello, world!</message>" }
            );

            Stage.AddProperty
            (
                "LineNumbers",
                "The `LineNumbers` property controls whether line numbers are displayed alongside the code within a code-display control.",
                "LineNumbers = true",
                // Default
                new ControlText() { Text = "False", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Bash, Code = "#!/bin/bash\necho \"Hello, world!\"", LineNumbers = false },

                // Bash
                new ControlText() { Text = "True", Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = TypeLanguage.Bash, Code = "#!/bin/bash\necho \"Hello, world!\"", LineNumbers = true }
            );
        }
    }
}
