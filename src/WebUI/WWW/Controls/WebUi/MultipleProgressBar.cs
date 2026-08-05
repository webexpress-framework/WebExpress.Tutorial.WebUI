using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the multiple progress bar control for the tutorial.
    /// </summary>
    [WebIcon<IconControlMultipleProgressBar>]
    [Title("MultipleProgressBar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class MultipleProgressBar : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the multiple progress bar control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public MultipleProgressBar(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `MultipleProgressBar` control splits a single bar into several segments, each with its own value, color and label. Where the `Progress` control shows how far one task has come, this control shows how a whole is distributed - the states of a work package, the used shares of a quota - without needing a chart. The segments are passed to the constructor.";

            Stage.Control = new ControlMultipleProgressBar
            (
                null,
                new ControlMultipleProgressBarItem()
                {
                    Value = _ => 45,
                    Text = _ => "Done",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlMultipleProgressBarItem()
                {
                    Value = _ => 30,
                    Text = _ => "In progress",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlMultipleProgressBarItem()
                {
                    Value = _ => 15,
                    Text = _ => "Blocked",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                }
            )
            {
                Format = _ => TypeFormatProgress.Colored
            };

            Stage.Code = @"
                new ControlMultipleProgressBar
                (
                    null,
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 45,
                        Text = _ => ""Done"",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 30,
                        Text = _ => ""In progress"",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 15,
                        Text = _ => ""Blocked"",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                    }
                )
                {
                    Format = _ => TypeFormatProgress.Colored
                };";

            Stage.AddProperty
            (
                "Format",
                "Defines the visual layout of the bar. The default format falls back to the native progress element and therefore shows the sum of all segments as a single bar; every other format renders the segments individually.",
                "Format = _ => TypeFormatProgress.Striped",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                CreateExample(TypeFormatProgress.Default),
                new ControlText() { Text = _ => "Colored", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                CreateExample(TypeFormatProgress.Colored),
                new ControlText() { Text = _ => "Striped", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                CreateExample(TypeFormatProgress.Striped),
                new ControlText() { Text = _ => "Animated", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                CreateExample(TypeFormatProgress.Animated)
            );

            Stage.AddItem
            (
                typeof(ControlMultipleProgressBarItem),
                "ControlMultipleProgressBarItem",
                "A single segment of the bar. Its `Value` is the share it occupies, so the values of all segments together should not exceed 100.",
                @"new ControlMultipleProgressBarItem()
                {
                    Value = _ => 45,
                    Text = _ => ""Done""
                }",
                CreateExample(TypeFormatProgress.Colored)
            );

            Stage.AddItemProperty
            (
                typeof(ControlMultipleProgressBarItem),
                "Value",
                "Sets the share of the segment, given as a percentage of the whole bar.",
                @"new ControlMultipleProgressBarItem()
                {
                    Value = _ => 45
                }",
                new ControlMultipleProgressBar
                (
                    null,
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 20,
                        Text = _ => "20",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 60,
                        Text = _ => "60",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                    }
                )
                {
                    Format = _ => TypeFormatProgress.Colored
                }
            );

            Stage.AddItemProperty
            (
                typeof(ControlMultipleProgressBarItem),
                "BackgroundColor",
                "Sets the color of the segment, which is what tells the segments apart.",
                @"new ControlMultipleProgressBarItem()
                {
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }",
                new ControlMultipleProgressBar
                (
                    null,
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 25,
                        Text = _ => "Success",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 25,
                        Text = _ => "Info",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 25,
                        Text = _ => "Danger",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 25,
                        Text = _ => "Custom",
                        BackgroundColor = _ => new PropertyColorBackground("gold")
                    }
                )
                {
                    Format = _ => TypeFormatProgress.Colored
                }
            );

            Stage.AddItemProperty
            (
                typeof(ControlMultipleProgressBarItem),
                "Color",
                "Sets the color of the label drawn inside the segment, so it stays readable on a light as well as on a dark segment.",
                @"new ControlMultipleProgressBarItem()
                {
                    Color = _ => new PropertyColorText(TypeColorText.Dark)
                }",
                new ControlMultipleProgressBar
                (
                    null,
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 50,
                        Text = _ => "White on dark",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark),
                        Color = _ => new PropertyColorText(TypeColorText.White)
                    },
                    new ControlMultipleProgressBarItem()
                    {
                        Value = _ => 50,
                        Text = _ => "Dark on light",
                        BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light),
                        Color = _ => new PropertyColorText(TypeColorText.Dark)
                    }
                )
                {
                    Format = _ => TypeFormatProgress.Colored
                }
            );
        }

        /// <summary>
        /// Builds a bar of three segments in the given format, so the format act can
        /// compare the layouts on identical data.
        /// </summary>
        /// <param name="format">The format of the bar.</param>
        /// <returns>The example bar.</returns>
        private static ControlMultipleProgressBar CreateExample(TypeFormatProgress format)
        {
            return new ControlMultipleProgressBar
            (
                null,
                new ControlMultipleProgressBarItem()
                {
                    Value = _ => 45,
                    Text = _ => "Done",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlMultipleProgressBarItem()
                {
                    Value = _ => 30,
                    Text = _ => "In progress",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlMultipleProgressBarItem()
                {
                    Value = _ => 15,
                    Text = _ => "Blocked",
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                }
            )
            {
                Format = _ => format,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
            };
        }
    }
}
