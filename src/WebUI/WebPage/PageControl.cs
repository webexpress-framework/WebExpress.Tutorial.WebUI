using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebPage
{
    /// <summary>
    /// Represents the base class for page controls in the web application.
    /// </summary>
    public abstract class PageControl : IPage<VisualTreeWebApp>, IScopeControl, IScopeGeneral
    {
        /// <summary>
        /// Returns the stage where the acts (Main Act and Supporting Acts) come to life.
        /// </summary>
        protected Stage Stage { get; } = new Stage();

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.Content.MainPanel.AddPrimary(new ControlLine()
            {
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = TrimIndentation(Stage.Description),
                Format = TypeFormatText.Markdown
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "Example",
                Format = TypeFormatText.H3,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "To demonstrate the functionality and potential use cases of this control, here’s an example showcasing its key features in action.",
                Format = TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "Light Mode",
                Format = TypeFormatText.H5,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = @"Designed for bright and well-lit environments, light mode offers a clear and vibrant presentation of the control, making it ideal for applications that prioritize brightness and clarity.",
                Format = TypeFormatText.Markdown,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. Stage.Controls])
            {
                BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light),
                Styles = ["max-width: 80em;"],
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "Dark Mode",
                Format = TypeFormatText.H5,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = @"Optimized for dim settings, dark mode delivers a high-contrast theme that enhances readability and reduces eye strain, while maintaining the control’s core functionalities.",
                Format = TypeFormatText.Markdown,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. Stage.DarkControls.Any() ? Stage.DarkControls : Stage.Controls])
            {
                BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark),
                Styles = ["max-width: 80em;"],
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None,
                PropertySpacing.Space.None, PropertySpacing.Space.Two),
                Theme = TypeTheme.Dark
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "Code",
                Format = TypeFormatText.H3,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "Below is the corresponding code snippet, designed to provide a clear understanding of the control's implementation. It demonstrates how the control is instantiated and customized to achieve specific functionality and appearance.",
                Format = TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(null, new ControlCode()
            {
                Code = TrimIndentation(Stage.Code),
                LineNumbers = true,
                Styles = ["max-width: 91em;"],
                Language = TypeLanguage.CSharp,

                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = "The following HTML structure is generated based on the example control and serves as the foundation for its visual and functional representation. It includes the necessary elements to create an interactive user interface, allowing users to engage intuitively and efficiently.",
                Format = TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlCode()
            {
                Code = string.Join("<br>", Stage.Controls.Select(x => x.Render(new RenderControlContext(renderContext), visualTree)?.ToString().Trim())),
                LineNumbers = true,
                Styles = ["max-width: 91em;"],
                Language = TypeLanguage.Xml,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });

            if (Stage.PropertyActs.Any())
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "Properties",
                    Format = TypeFormatText.H3,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "Every control is equipped with a set of properties that define its behavior, appearance, and functionality. These properties are designed to provide flexibility and customization, enabling developers to tailor the controls to fit their unique requirements seamlessly. Below is a detailed exploration of the key properties available for this control.",
                    Format = TypeFormatText.Paragraph
                });
            }

            foreach (var supportedAct in Stage.PropertyActs)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = supportedAct.Name,
                    Format = TypeFormatText.H4,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = supportedAct.Description,
                    Format = TypeFormatText.Markdown
                });

                if (!string.IsNullOrWhiteSpace(supportedAct.Callout))
                {
                    visualTree.Content.MainPanel.AddPrimary(new ControlPanelCallout(null, new ControlText()
                    {
                        Text = supportedAct.Callout
                    })
                    {
                        Color = new PropertyColorCallout(TypeColorCallout.Info),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    });
                }

                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. supportedAct.Controls])
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light),
                    Styles = ["max-width: 80em;"],
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlCode()
                {
                    Code = TrimIndentation(supportedAct.Code),
                    LineNumbers = true,
                    Styles = ["max-width: 91em;"],
                    Language = TypeLanguage.CSharp,

                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
            }

            if (Stage.ItemActs.Any())
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "Item types",
                    Format = TypeFormatText.H3,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "Item types enhance enumerations with a range of functionalities, providing increased flexibility and adaptability for various applications. Through the assignment of distinct attributes and behaviors, they empower developers to customize lists to address specific needs effectively.",
                    Format = TypeFormatText.Paragraph
                });
            }

            foreach (var supportedAct in Stage.ItemActs)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = supportedAct.Name,
                    Format = TypeFormatText.H4,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = supportedAct.Description,
                    Format = TypeFormatText.Markdown
                });

                if (!string.IsNullOrWhiteSpace(supportedAct.Callout))
                {
                    visualTree.Content.MainPanel.AddPrimary(new ControlPanelCallout(null, new ControlText()
                    {
                        Text = supportedAct.Callout
                    })
                    {
                        Color = new PropertyColorCallout(TypeColorCallout.Info),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    });
                }

                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. supportedAct.Controls])
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light),
                    Styles = ["max-width: 80em;"],
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlCode()
                {
                    Code = TrimIndentation(supportedAct.Code),
                    LineNumbers = true,
                    Styles = ["max-width: 91em;"],
                    Language = TypeLanguage.CSharp,

                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
            }

            if (Stage.Events.Any())
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "Events",
                    Format = TypeFormatText.H3
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "Several events are registered with the Control, enabling precise monitoring and management of processes. They respond to specific occurrences and trigger appropriate actions:",
                    Format = TypeFormatText.Paragraph
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlList(null,
                [..
                    Stage.Events.Select(x => new ControlListItem(null, new ControlText()
                    {
                        Text = $"`{x.GetEventName()}` - {x.GetDescription()}",
                        Format = TypeFormatText.Markdown
                    }))
                ])
                {
                    Layout = TypeLayoutList.Default
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = "In the next section, these events will be monitored in real time as they are triggered during example usage. This live tracking provides a detailed analysis of event behavior and system interactions, offering valuable insights into their functionality:",
                    Format = TypeFormatText.Paragraph
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, new ControlEventLogger
                (
                    null,
                    string.Join(" ", Stage.Events.Select(x => x.GetEventName()))
                )
                {
                    Styles = ["max-width: 80em;"],
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                })
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
                });
            }
        }

        /// <summary>
        /// Trims the leading indentation from each line of the input string.
        /// </summary>
        /// <param name="input">The input string with potential leading indentation.</param>
        /// <returns>A string with the leading indentation removed from each line.</returns>
        private static string TrimIndentation(string input)
        {
            var lines = input?.Replace("\r", "").Split('\n', System.StringSplitOptions.RemoveEmptyEntries);
            var indentation = lines?.FirstOrDefault(line => !string.IsNullOrWhiteSpace(line))?.TakeWhile(char.IsWhiteSpace).Count() ?? 0;

            for (int i = 0; i < lines?.Length; i++)
            {
                if (lines[i].Length >= indentation)
                {
                    lines[i] = lines[i].Substring(indentation);
                }
            }

            return string.Join("\n", lines ?? []);
        }
    }
}
