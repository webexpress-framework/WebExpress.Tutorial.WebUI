using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the progress control for the tutorial.    
    /// </summary>    
    [Title("Progress")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Progress : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the progress control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Progress(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Progress` control is used to provide visual feedback on the status of a process or task. It can be customized with different colors, labels, and animations to clearly indicate how much of the task has been completed.";

            Stage.Control = new ControlProgress()
            {
                Value = _ => 50
            };

            Stage.Code = @"
                new ControlProgress()
                {
                    Value = _ => 50
                };";

            Stage.AddProperty
            (
                "Value",
                "Sets the current value of the progress bar. The value should be between 0 and 100.",
                "Value = _ => 75",
                new ControlProgress()
                {
                    Value = _ => 25
                },
                new ControlProgress()
                {
                    Value = _ => 50
                },
                new ControlProgress()
                {
                    Value = _ => 75
                },
                new ControlProgress()
                {
                    Value = _ => 100
                }
            );

            Stage.AddProperty
            (
                "Format",
                "Defines visual layout of the progress bar.",
                "Format = _ => TypeFormatProgress.Striped",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 25,
                    Text = _ => "Default",
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    Format = _ => TypeFormatProgress.Default,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Colored", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Colored",
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Secondary),
                    Format = _ => TypeFormatProgress.Colored,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Striped", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 75,
                    Text = _ => "Striped",
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Info),
                    Format = _ => TypeFormatProgress.Striped,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Animated", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 100,
                    Text = _ => "Animated",
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success),
                    Format = _ => TypeFormatProgress.Animated,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                }

            );

            Stage.AddProperty
            (
                "Color",
                "Sets the color of the progress bar.",
                "Color = _ => new PropertyColorProgress(TypeColorProgress.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Default)
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary)
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Secondary)
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Info)
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success)
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Warning)
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Danger)
                },
                new ControlText() { Text = _ => "Highlight", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Highlight)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress("gold")
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Sets the text color of the progress bar.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Default",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Default)
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Primary",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Primary)
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Secondary",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Secondary)
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Info",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Success",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Success)
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Warning",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Warning)
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Danger",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger)
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Light",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Light)
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Dark",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Dark)
                },
                new ControlText() { Text = _ => "White", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "White",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.White)
                },
                new ControlText() { Text = _ => "Muted", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Muted",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText(TypeColorText.Muted)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Custom",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = _ => new PropertyColorText("gold")
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Defines the background color of the component.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Default",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Default)
                },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Primary",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Secondary",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Info",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Success",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Warning",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Danger",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Light",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Dark",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = _ => "White", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "White",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.White)
                },
                new ControlText() { Text = _ => "Transparent", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Transparent",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = _ => "Custom", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 50,
                    Text = _ => "Custom",
                    Format = _ => TypeFormatProgress.Animated,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = _ => new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Specifies the vertical dimension of the progress bar.",
                "Size = _ => TypeSizeProgress.ExtraSmall",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 75,
                    Text = _ => "Default",
                    Size = _ => TypeSizeProgress.Default,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success),
                    Format = _ => TypeFormatProgress.Animated,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "ExtraSmall", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 75,
                    Text = _ => "ExtraSmall",
                    Size = _ => TypeSizeProgress.ExtraSmall,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success),
                    Format = _ => TypeFormatProgress.Animated,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Small", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 75,
                    Text = _ => "Small",
                    Size = _ => TypeSizeProgress.Small,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success),
                    Format = _ => TypeFormatProgress.Animated,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "Large", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 75,
                    Text = _ => "Large",
                    Size = _ => TypeSizeProgress.Large,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success),
                    Format = _ => TypeFormatProgress.Animated,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = _ => "ExtraLarge", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = _ => 75,
                    Text = _ => "ExtraLarge",
                    Size = _ => TypeSizeProgress.ExtraLarge,
                    Color = _ => new PropertyColorProgress(TypeColorProgress.Success),
                    Format = _ => TypeFormatProgress.Animated,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                }

            );
        }
    }
}
