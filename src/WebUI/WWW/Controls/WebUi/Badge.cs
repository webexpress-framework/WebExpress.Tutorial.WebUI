using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the badge control for the tutorial.  
    /// </summary>  
    [Title("Badge")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Badge : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the badge is used.</param>
        public Badge(IPageContext pageContext)
        {
            Stage.Description = @"The `Badge` control is an intuitive and versatile tool designed for displaying labels, counters, or status indicators in web applications. It ensures user interactions are visually enhanced, using dynamic styling and functionality to improve user experience. Built for flexibility, the control can be customized to suit various use cases.";

            Stage.Controls = [
                new ControlBadge()
                {
                    Value = _ => "1"
                },
                new ControlBadge()
                {
                    Value = _ => "2",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                },
                new ControlBadge()
                {
                    Value = _ => "3",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary)
                },
                new ControlBadge()
                {
                    Value = _ => "4",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Info)
                },
                new ControlBadge()
                {
                    Value = _ => "5",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success)
                },
                new ControlBadge()
                {
                    Value = _ => "60",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning)
                },
                new ControlBadge()
                {
                    Value = _ => "70",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                },
                new ControlBadge()
                {
                    Value = _ => "80",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark)
                },
                new ControlBadge()
                {
                    Value = _ => "90",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Light)
                },
                new ControlBadge()
                {
                    Value = _ => "100",
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Highlight)
                },
                new ControlBadge()
                {
                    Value = _ => "200",
                    TextColor = _ => new PropertyColorText("red"),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge("gold")
                }
            ];

            Stage.Code = @"
            new ControlBadge() 
            { 
                Value = _ => ""New"", 
                BackgroundColor = _ => new PropertyColorBackground(TypesBackgroundColor.Success) 
            };";

            Stage.AddProperty
            (
                "Pill",
                "Changes the design and adds more rounded corners.",
                "Pill = _ => TypePillBadge.Pill",
                new ControlBadge()
                {
                    Value = _ => "Default",
                    Pill = _ => TypePillBadge.Pill
                },
                new ControlBadge()
                {
                    Value = _ => "Primary",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                },
                new ControlBadge()
                {
                    Value = _ => "Secondary",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary)
                },
                new ControlBadge()
                {
                    Value = _ => "Info",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Info)
                },
                new ControlBadge()
                {
                    Value = _ => "Success",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success)
                },
                new ControlBadge()
                {
                    Value = _ => "Warning",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning)
                },
                new ControlBadge()
                {
                    Value = _ => "Danger",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                },
                new ControlBadge()
                {
                    Value = _ => "Dark",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark)
                },
                new ControlBadge()
                {
                    Value = _ => "Light",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Light)
                },
                new ControlBadge()
                {
                    Value = _ => "Highlight",
                    Pill = _ => TypePillBadge.Pill,
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Highlight)
                },
                new ControlBadge()
                {
                    Value = _ => "User defined",
                    Pill = _ => TypePillBadge.Pill,
                    TextColor = _ => new PropertyColorText("red"),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge("gold")
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Adds a URI so that the badge functions like a link.",
                "Uri = _ => pageContext.Route.ToUri()",
                new ControlBadge()
                {
                    Value = _ => "Default",
                    Uri = _ => pageContext.Route.ToUri()
                },
                new ControlBadge()
                {
                    Value = _ => "Primary",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                },
                new ControlBadge()
                {
                    Value = _ => "Secondary",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary)
                },
                new ControlBadge()
                {
                    Value = _ => "Info",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Info)
                },
                new ControlBadge()
                {
                    Value = _ => "Success",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success)
                },
                new ControlBadge()
                {
                    Value = _ => "Warning",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning)
                },
                new ControlBadge()
                {
                    Value = _ => "Danger",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                },
                new ControlBadge()
                {
                    Value = _ => "Dark",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark)
                },
                new ControlBadge()
                {
                    Value = _ => "Light",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Light)
                },
                new ControlBadge()
                {
                    Value = _ => "Highlight",
                    Uri = _ => pageContext.Route.ToUri(),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Highlight)
                },
                new ControlBadge()
                {
                    Value = _ => "Custom",
                    Uri = _ => pageContext.Route.ToUri(),
                    TextColor = _ => new PropertyColorText("red"),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge("gold")
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Sets the size",
                "",
                "Size = _ => new PropertySizeText(TypeSizeText.Small)",
                new ControlBadge()
                {
                    Value = _ => "ExtraSmall",
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraSmall),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = _ => "Small",
                    Size = _ => new PropertySizeText(TypeSizeText.Small),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = _ => "Default",
                    Size = _ => new PropertySizeText(TypeSizeText.Default),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = _ => "Large",
                    Size = _ => new PropertySizeText(TypeSizeText.Large),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = _ => "ExtraLarge",
                    Size = _ => new PropertySizeText(TypeSizeText.ExtraLarge),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = _ => "3.1f",
                    Size = _ => new PropertySizeText(3.1f),
                    BackgroundColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );
        }
    }
}
