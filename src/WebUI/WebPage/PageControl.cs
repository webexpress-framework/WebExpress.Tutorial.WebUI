using System.Linq;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;

namespace WebUI.WebPage
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
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = Stage.Description,
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
                Text = @"Designed for bright and well-lit environments, Light Mode offers a clear and vibrant presentation of the control, making it ideal for applications that prioritize brightness and clarity.",
                Format = TypeFormatText.Markdown,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. Stage.Controls])
            {
                BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light),
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
                Text = @"Optimized for dim settings, Dark Mode delivers a high-contrast theme that enhances readability and reduces eye strain, while maintaining the control’s core functionalities.",
                Format = TypeFormatText.Markdown,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, [.. Stage.Controls])
            {
                BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two),
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
            visualTree.Content.MainPanel.AddPrimary(new ControlPanelCard(null, new ControlText()
            {
                Text = Stage.Code,
                Format = TypeFormatText.Code,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            })
            {
                BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
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
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = supportedAct.Code,
                    Format = TypeFormatText.Code
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
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                });

                visualTree.Content.MainPanel.AddPrimary(new ControlText()
                {
                    Text = supportedAct.Code,
                    Format = TypeFormatText.Code
                });
            }
        }
    }
}
