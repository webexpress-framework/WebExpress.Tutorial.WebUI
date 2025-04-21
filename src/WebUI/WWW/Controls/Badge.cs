using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the badge control for the tutorial.  
    /// </summary>  
    [Title("Badge")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
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
                    Value = "1"
                },
                new ControlBadge()
                {
                    Value = "2",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                },
                new ControlBadge()
                {
                    Value = "3",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary)
                },
                new ControlBadge()
                {
                    Value = "4",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Info)
                },
                new ControlBadge()
                {
                    Value = "5",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success)
                },
                new ControlBadge()
                {
                    Value = "60",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning)
                },
                new ControlBadge()
                {
                    Value = "70",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                },
                new ControlBadge()
                {
                    Value = "80",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark)
                },
                new ControlBadge()
                {
                    Value = "90",
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Light)
                },
                new ControlBadge()
                {
                    Value = "200",
                    TextColor = new PropertyColorText("red"),
                    BackgroundColor = new PropertyColorBackgroundBadge("gold")
                }
            ];

            Stage.Code = @"new ControlBadge() 
            { 
                Value = ""New"", 
                BackgroundColor = new PropertyColorBackground(TypesBackgroundColor.Success) 
            };";

            Stage.AddProperty
            (
                "Pill",
                "Changes the design and adds more rounded corners.",
                "Pill = TypePillBadge.Pill",
                new ControlBadge()
                {
                    Value = "Default",
                    Pill = TypePillBadge.Pill
                },
                new ControlBadge()
                {
                    Value = "Primary",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                },
                new ControlBadge()
                {
                    Value = "Secondary",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary)
                },
                new ControlBadge()
                {
                    Value = "Info",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Info)
                },
                new ControlBadge()
                {
                    Value = "Success",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success)
                },
                new ControlBadge()
                {
                    Value = "Warning",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning)
                },
                new ControlBadge()
                {
                    Value = "Danger",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                },
                new ControlBadge()
                {
                    Value = "Dark",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark)
                },
                new ControlBadge()
                {
                    Value = "Light",
                    Pill = TypePillBadge.Pill,
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Light)
                },
                new ControlBadge()
                {
                    Value = "User defined",
                    Pill = TypePillBadge.Pill,
                    TextColor = new PropertyColorText("red"),
                    BackgroundColor = new PropertyColorBackgroundBadge("gold")
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "Adds a URI so that the badge functions like a link.",
                "Uri = pageContext.Route.ToUri()",
                new ControlBadge()
                {
                    Value = "Default",
                    Uri = pageContext.Route.ToUri()
                },
                new ControlBadge()
                {
                    Value = "Primary",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
                },
                new ControlBadge()
                {
                    Value = "Secondary",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary)
                },
                new ControlBadge()
                {
                    Value = "Info",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Info)
                },
                new ControlBadge()
                {
                    Value = "Success",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success)
                },
                new ControlBadge()
                {
                    Value = "Warning",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning)
                },
                new ControlBadge()
                {
                    Value = "Danger",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                },
                new ControlBadge()
                {
                    Value = "Dark",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark)
                },
                new ControlBadge()
                {
                    Value = "Light",
                    Uri = pageContext.Route.ToUri(),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Light)
                },
                new ControlBadge()
                {
                    Value = "Custom",
                    Uri = pageContext.Route.ToUri(),
                    TextColor = new PropertyColorText("red"),
                    BackgroundColor = new PropertyColorBackgroundBadge("gold")
                }
            );

            Stage.AddProperty
            (
                "Size",
                "Sets the size",
                "",
                "Size = new PropertySizeText(TypeSizeText.Small)",
                new ControlBadge()
                {
                    Value = "ExtraSmall",
                    Size = new PropertySizeText(TypeSizeText.ExtraSmall),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = "Small",
                    Size = new PropertySizeText(TypeSizeText.Small),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = "Default",
                    Size = new PropertySizeText(TypeSizeText.Default),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = "Large",
                    Size = new PropertySizeText(TypeSizeText.Large),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = "ExtraLarge",
                    Size = new PropertySizeText(TypeSizeText.ExtraLarge),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                },
                new ControlBadge()
                {
                    Value = "3.1f",
                    Size = new PropertySizeText(3.1f),
                    BackgroundColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
            );
        }
    }
}
