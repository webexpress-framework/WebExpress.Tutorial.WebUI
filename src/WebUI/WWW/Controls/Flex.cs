using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the flex control for the tutorial.    
    /// </summary>    
    [Title("Flex")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Flex : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Flex(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Flex` is a versatile UI control designed to arrange content dynamically using the CSS Flexbox model. It enables declarative, configurable layout composition in either horizontal or vertical direction. Ideal for responsive interfaces, modular dashboards, or runtime-generated views.
";

            Stage.Control = new ControlPanelFlex()
            {
            }
                .Add(CreateWrapControls(3));

            Stage.Code = @"
            Stage.Control = new ControlPanelFlex()
            {
            }
                .Add(new ControlText()
                {
                    Text = ""First Entry"",
                    Format = TypeFormatText.Default,
                    Border = new PropertyBorder(true),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)
                })
                .Add(new ControlText()
                {
                    Text = ""Second Entry"",
                    Format = TypeFormatText.Default,
                    Border = new PropertyBorder(true),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)
                })
                .Add(new ControlText()
                {
                    Text = ""Third Entry"",
                    Format = TypeFormatText.Default,
                    Border = new PropertyBorder(true),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)
                });";

            Stage.AddProperty
            (
                "Layout",
                "Defines how child elements are arranged within the panel using Flexbox layout modes.",
                "Layout = TypeLayoutFlex.None",

                new ControlText()
                {
                    Text = "None",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.None
                }
                    .Add(CreateWrapControls(3)),

                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default
                }
                    .Add(CreateWrapControls(3)),

                new ControlText()
                {
                    Text = "Inline",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Inline
                }
                 .Add(CreateWrapControls(3))
            );

            Stage.AddProperty
            (
                "Justify",
                "Defines the horizontal alignment of items within a Flexbox panel.",
                "Justify = TypeJustifiedFlex.Start",
                new ControlText()
                {
                    Text = "None",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Justify = TypeJustifiedFlex.None
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Start",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Justify = TypeJustifiedFlex.Start
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "End",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Justify = TypeJustifiedFlex.End
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Center",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Justify = TypeJustifiedFlex.Center
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Between",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Justify = TypeJustifiedFlex.Between
                }
                    .Add(CreateWrapControls(3)),

                // Justify: Around
                new ControlText()
                {
                    Text = "Around",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Justify = TypeJustifiedFlex.Around
                }
                    .Add(CreateWrapControls(3))
            );

            Stage.AddProperty
            (
                "Align",
                "Defines the vertical alignment of items within a Flexbox panel.",
                "Align = TypeAlignFlex.Start",
                new ControlText()
                {
                    Text = "None",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.None,
                    Styles = ["height: 100px"],
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Start",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Start,
                    Styles = ["height: 100px"],
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "End",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.End,
                    Styles = ["height: 100px"],
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Center",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Center,
                    Styles = ["height: 100px"],
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Baseline",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Baseline,
                    Styles = ["height: 100px"],
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(3)),
                new ControlText()
                {
                    Text = "Stretch",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Align = TypeAlignFlex.Stretch,
                    Styles = ["height: 100px"],
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(3))
            );

            Stage.AddProperty
            (
                "Wrap",
                "Defines how items behave when they overflow the available space.",
                "Wrap = TypeWrap.None",

                new ControlText()
                {
                    Text = "None",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Wrap = TypeWrap.None,
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(15)),

                new ControlText()
                {
                    Text = "Nowrap",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Wrap = TypeWrap.Nowrap,
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(15)),
                new ControlText()
                {
                    Text = "Wrap",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Wrap = TypeWrap.Wrap,
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(15)),
                new ControlText()
                {
                    Text = "Wrap-Reverse",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelFlex()
                {
                    Layout = TypeLayoutFlex.Default,
                    Wrap = TypeWrap.Reverse,
                    Border = new PropertyBorder(true)
                }
                    .Add(CreateWrapControls(15))
            );
        }

        /// <summary>
        /// Creates an array of controls with predefined labels and formatting.
        /// </summary>
        /// <param name="count">
        /// The number of controls to create. Must be a non-negative value. If the value 
        /// exceeds the number of predefined labels, only the available labels will be used.
        /// </param>
        /// <returns>
        /// An array of <see cref="IControl"/> objects, each initialized with a predefined 
        /// label, default text formatting, a visible border, and padding.  The array will 
        /// contain up to <paramref name="count"/> controls, or fewer if <paramref name="count"/> 
        /// exceeds the number of predefined labels.
        /// </returns>
        private static IControl[] CreateWrapControls(int count)
        {
            string[] labels =
            [
                "First Entry", "Second Entry", "Third Entry", "Fourth Entry", "Fifth Entry",
                "Sixth Entry", "Seventh Entry", "Eighth Entry", "Ninth Entry", "Tenth Entry",
                "Eleventh Entry", "Twelfth Entry", "Thirteenth Entry", "Fourteenth Entry", "Fifteenth Entry"
            ];

            return [.. labels.Take(count).Select(text => new ControlText()
            {
                Text = text,
                Format = TypeFormatText.Default,
                Border = new PropertyBorder(true),
                Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)
            })];
        }
    }
}
