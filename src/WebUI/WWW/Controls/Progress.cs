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
                Value = 50
            };

            Stage.Code = @"
                new ControlProgress()
                {
                    Value = 50
                };";

            Stage.AddProperty
            (
                "Value",
                "Sets the current value of the progress bar. The value should be between 0 and 100.",
                "Value = 75",
                new ControlProgress()
                {
                    Value = 25
                },
                new ControlProgress()
                {
                    Value = 50
                },
                new ControlProgress()
                {
                    Value = 75
                },
                new ControlProgress()
                {
                    Value = 100
                }
            );

            Stage.AddProperty
            (
                "Format",
                "Defines visual layout of the progress bar.",
                "Format = TypeFormatProgress.Striped",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 25,
                    Text = "Default",
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    Format = TypeFormatProgress.Default,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "Colored", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Colored",
                    Color = new PropertyColorProgress(TypeColorProgress.Secondary),
                    Format = TypeFormatProgress.Colored,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "Striped", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 75,
                    Text = "Striped",
                    Color = new PropertyColorProgress(TypeColorProgress.Info),
                    Format = TypeFormatProgress.Striped,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "Animated", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 100,
                    Text = "Animated",
                    Color = new PropertyColorProgress(TypeColorProgress.Success),
                    Format = TypeFormatProgress.Animated,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                }

            );

            Stage.AddProperty
            (
                "Color",
                "Sets the color of the progress bar.",
                "Color = new PropertyColorProgress(TypeColorProgress.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Default)
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Danger)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress("gold")
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Sets the text color of the progress bar.",
                "TextColor = new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Default",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Default)
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Primary",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Secondary",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Info",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Success",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Warning",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Danger",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Danger)
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Light",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Light)
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Dark",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Dark)
                },
                new ControlText() { Text = "White", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "White",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.White)
                },
                new ControlText() { Text = "Muted", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Muted",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText(TypeColorText.Muted)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Custom",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    TextColor = new PropertyColorText("gold")
                }
            );

            Stage.AddProperty
            (
                "BackgroundColor",
                "Defines the background color of the component.",
                "TextColor = new PropertyColorText(TypeColorText.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Default",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Default)
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Primary",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Secondary",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Info",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Success",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Warning",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Danger",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger)
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Light",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Dark",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark)
                },
                new ControlText() { Text = "White", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "White",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.White)
                },
                new ControlText() { Text = "Transparent", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Transparent",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Transparent)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 50,
                    Text = "Custom",
                    Format = TypeFormatProgress.Animated,
                    Color = new PropertyColorProgress(TypeColorProgress.Primary),
                    BackgroundColor = new PropertyColorBackground("gold")
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Specifies the vertical dimension of the progress bar.",
                "Size = TypeSizeProgress.ExtraSmall",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 75,
                    Text = "Default",
                    Size = TypeSizeProgress.Default,
                    Color = new PropertyColorProgress(TypeColorProgress.Success),
                    Format = TypeFormatProgress.Animated,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "ExtraSmall", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 75,
                    Text = "ExtraSmall",
                    Size = TypeSizeProgress.ExtraSmall,
                    Color = new PropertyColorProgress(TypeColorProgress.Success),
                    Format = TypeFormatProgress.Animated,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "Small", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 75,
                    Text = "Small",
                    Size = TypeSizeProgress.Small,
                    Color = new PropertyColorProgress(TypeColorProgress.Success),
                    Format = TypeFormatProgress.Animated,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "Large", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 75,
                    Text = "Large",
                    Size = TypeSizeProgress.Large,
                    Color = new PropertyColorProgress(TypeColorProgress.Success),
                    Format = TypeFormatProgress.Animated,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                },
                new ControlText() { Text = "ExtraLarge", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlProgress()
                {
                    Value = 75,
                    Text = "ExtraLarge",
                    Size = TypeSizeProgress.ExtraLarge,
                    Color = new PropertyColorProgress(TypeColorProgress.Success),
                    Format = TypeFormatProgress.Animated,
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Three)
                }

            );
        }
    }
}
