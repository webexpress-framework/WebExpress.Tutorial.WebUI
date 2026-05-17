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
        /// Gets the stage where the acts (Main Act and Supporting Acts) come to life.
        /// </summary>
        protected Stage Stage { get; } = new Stage();

        /// <summary>
        /// Processing of the resource. Virtual so a derived tutorial page can
        /// hook in before the default rendering, e.g. to switch the active
        /// theme via <c>visualTree.UseTheme&lt;TTheme&gt;()</c>.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public virtual void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.Content.MainPanel.AddPrimary(new ControlLine()
            {
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => TrimIndentation(Stage.Description),
                Format = _ => TypeFormatText.Markdown
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "Example",
                Format = _ => TypeFormatText.H3,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "To demonstrate the functionality and potential use cases of this control, here’s an example showcasing its key features in action.",
                Format = _ => TypeFormatText.Paragraph
            });
            if (Stage.DarkControls is not null)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Light Mode",
                    Format = _ => TypeFormatText.H5,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => @"Designed for bright and well-lit environments, light mode offers a clear and vibrant presentation of the control, making it ideal for applications that prioritize brightness and clarity.",
                    Format = _ => TypeFormatText.Markdown,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
            }
            visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. Stage.Controls])
            {
                Classes = ["wx-resizable"],
                Styles = ["max-width: 80em;"],
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });

            if (Stage.DarkControls is not null)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Dark Mode",
                    Format = _ => TypeFormatText.H5,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => @"Optimized for dim settings, dark mode delivers a high-contrast theme that enhances readability and reduces eye strain, while maintaining the control’s core functionalities.",
                    Format = _ => TypeFormatText.Markdown,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. Stage.DarkControls.Any() ? Stage.DarkControls : Stage.Controls])
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark),
                    Styles = ["max-width: 80em;"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None,
                    PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Theme = _ => TypeTheme.Dark
                });
            }
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "Code",
                Format = _ => TypeFormatText.H3,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "Below is the corresponding code snippet, designed to provide a clear understanding of the control's implementation. It demonstrates how the control is instantiated and customized to achieve specific functionality and appearance.",
                Format = _ => TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(null, new ControlCode()
            {
                Code = _ => TrimIndentation(Stage.Code),
                LineNumbers = _ => true,
                Styles = ["max-width: 91em;"],
                Language = _ => TypeLanguage.CSharp,

                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "The following HTML structure is generated based on the example control and serves as the foundation for its visual and functional representation. It includes the necessary elements to create an interactive user interface, allowing users to engage intuitively and efficiently.",
                Format = _ => TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlCode()
            {
                Code = _ => string.Join("<br>", Stage.Controls.Select(x => x.Render(new RenderControlContext(renderContext), visualTree)?.ToString().Trim())),
                LineNumbers = _ => true,
                Styles = ["max_ => -width: 91em;"],
                Language = _ => TypeLanguage.Xml,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });

            if (Stage.PropertyActs.Any())
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Properties",
                    Format = _ => TypeFormatText.H3,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Every control is equipped with a set of properties that define its behavior, appearance, and functionality. These properties are designed to provide flexibility and customization, enabling developers to tailor the controls to fit their unique requirements seamlessly. Below is a detailed exploration of the key properties available for this control.",
                    Format = _ => TypeFormatText.Paragraph
                });
            }

            foreach (var supportedAct in Stage.PropertyActs)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => supportedAct.Name,
                    Format = _ => TypeFormatText.H4,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => supportedAct.Description,
                    Format = _ => TypeFormatText.Markdown
                });

                if (!string.IsNullOrWhiteSpace(supportedAct.Callout))
                {
                    visualTree.Content.MainPanel.AddPrimary(new ControlPanelCallout(null, new ControlText()
                    {
                        Text = _ => supportedAct.Callout
                    })
                    {
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Info),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    });
                }

                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. supportedAct.Controls])
                {
                    Styles = ["max-width: 80em;"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlCode()
                {
                    Code = _ => TrimIndentation(supportedAct.Code),
                    LineNumbers = _ => true,
                    Styles = ["max-width: 91em;"],
                    Language = _ => TypeLanguage.CSharp,

                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });
            }

            if (Stage.ItemActs.Any())
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Item types",
                    Format = _ => TypeFormatText.H3,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Item types enhance enumerations with a range of functionalities, providing increased flexibility and adaptability for various applications. Through the assignment of distinct attributes and behaviors, they empower developers to customize lists to address specific needs effectively.",
                    Format = _ => TypeFormatText.Paragraph
                });
            }

            foreach (var supportedAct in Stage.ItemActs)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => supportedAct.Name,
                    Format = _ => TypeFormatText.H4,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => supportedAct.Description,
                    Format = _ => TypeFormatText.Markdown
                });

                if (!string.IsNullOrWhiteSpace(supportedAct.Callout))
                {
                    visualTree.Content.MainPanel.AddPrimary(new ControlPanelCallout(null, new ControlText()
                    {
                        Text = _ => supportedAct.Callout
                    })
                    {
                        Color = _ => new PropertyColorCallout(TypeColorCallout.Info),
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    });
                }

                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. supportedAct.Controls])
                {
                    Styles = ["max-width: 80em;"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlCode()
                {
                    Code = _ => TrimIndentation(supportedAct.Code),
                    LineNumbers = _ => true,
                    Styles = ["max-width: 91em;"],
                    Language = _ => TypeLanguage.CSharp,

                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                foreach (var subAct in Stage.ItemPropertyActs.Where(x => x.Type == supportedAct.Type))
                {
                    visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null)
                    {
                        Styles = ["max-width: 80em;"],
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    }
                        .Add
                        (
                            new ControlText()
                            {
                                Text = _ => subAct.Name,
                                Format = _ => TypeFormatText.H5,
                                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                            },
                            new ControlText()
                            {
                                Text = _ => subAct.Description,
                                Format = _ => TypeFormatText.Markdown
                            },
                            !string.IsNullOrWhiteSpace(subAct.Callout)
                                ? new ControlPanelCallout(null, new ControlText()
                                {
                                    Text = _ => subAct.Callout
                                })
                                {
                                    Color = _ => new PropertyColorCallout(TypeColorCallout.Info),
                                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                                }
                                : null,
                            new ControlPanelCard(null, [.. subAct.Controls])
                            {
                                Styles = ["max-width: 80em;"],
                                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                            },
                            new ControlCode()
                            {
                                Code = _ => TrimIndentation(subAct.Code),
                                LineNumbers = _ => true,
                                Styles = ["max-width: 91em;"],
                                Language = _ => TypeLanguage.CSharp,

                                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                            }
                        )
                    );
                }
            }

            if (Stage.Events.Any())
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Events",
                    Format = _ => TypeFormatText.H3
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "Several events are registered with the Control, enabling precise monitoring and management of processes. They respond to specific occurrences and trigger appropriate actions:",
                    Format = _ => TypeFormatText.Paragraph
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlList(null,
                [..
                    Stage.Events.Select(x => (ControlListItem)new ControlListItem(null).Add(new ControlText()
                    {
                        Text = _ =>$"`{x.GetEventName()}` - {x.GetDescription()}",
                        Format = _ => TypeFormatText.Markdown
                    }))
                ])
                {
                    Layout = _ => TypeLayoutList.Default
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = _ => "In the next section, these events will be monitored in real time as they are triggered during example usage. This live tracking provides a detailed analysis of event behavior and system interactions, offering valuable insights into their functionality:",
                    Format = _ => TypeFormatText.Paragraph
                });
                visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, new ControlEventLogger
                (
                    null,
                    string.Join(" ", Stage.Events.Select(x => x.GetEventName()))
                )
                {
                    Styles = ["max-width: 80em;"],
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                })
                {
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
