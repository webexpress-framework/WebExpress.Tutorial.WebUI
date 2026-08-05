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
    /// Represents the card counter control for the tutorial.
    /// </summary>
    [Title("CardCounter")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class CardCounter : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the card counter control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public CardCounter(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `CardCounter` control condenses a single key figure into a compact card: an icon, the value itself, a describing caption and an optional progress bar. It is meant for dashboards and overview pages where several figures are shown side by side and the reader should grasp each one at a glance.";

            Stage.Control = new ControlCardCounter()
            {
                Icon = _ => new IconUsers(),
                Value = _ => 42,
                Text = _ => "Active users",
                Progress = _ => 65
            };

            Stage.Code = @"
                new ControlCardCounter()
                {
                    Icon = _ => new IconUsers(),
                    Value = _ => 42,
                    Text = _ => ""Active users"",
                    Progress = _ => 65
                };";

            Stage.AddProperty
            (
                "Value",
                "Sets the key figure shown as the headline of the card. Without a value the card shows its caption alone, which is useful while the figure is still being determined.",
                "Value = _ => 42",
                new ControlCardCounter()
                {
                    Icon = _ => new IconUsers(),
                    Value = _ => 42,
                    Text = _ => "Active users"
                },
                new ControlCardCounter()
                {
                    Icon = _ => new IconUsers(),
                    Text = _ => "Unknown"
                }
            );

            Stage.AddProperty
            (
                "Text",
                "Sets the caption below the value. It names what the figure counts and is rendered muted, so the value stays dominant.",
                "Text = _ => \"Active users\"",
                new ControlCardCounter()
                {
                    Icon = _ => new IconEnvelope(),
                    Value = _ => 128,
                    Text = _ => "Unread messages"
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon identifying the counted subject.",
                "Icon = _ => new IconUsers()",
                new ControlCardCounter()
                {
                    Icon = _ => new IconUsers(),
                    Value = _ => 42,
                    Text = _ => "Users"
                },
                new ControlCardCounter()
                {
                    Icon = _ => new IconBug(),
                    Value = _ => 7,
                    Text = _ => "Open bugs"
                },
                new ControlCardCounter()
                {
                    Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(2, TypeSizeUnit.Em)),
                    Value = _ => 3,
                    Text = _ => "Custom"
                }
            );

            Stage.AddProperty
            (
                "Progress",
                "Adds a progress bar below the caption, relating the value to a target. Without a progress value no bar is rendered, so a figure without a target stays unchanged.",
                "Progress = _ => 65",
                new ControlCardCounter()
                {
                    Icon = _ => new IconCheck(),
                    Value = _ => 13,
                    Text = _ => "Completed tasks",
                    Progress = _ => 25
                },
                new ControlCardCounter()
                {
                    Icon = _ => new IconCheck(),
                    Value = _ => 34,
                    Text = _ => "Completed tasks",
                    Progress = _ => 65
                },
                new ControlCardCounter()
                {
                    Icon = _ => new IconCheck(),
                    Value = _ => 52,
                    Text = _ => "Completed tasks",
                    Progress = _ => 100
                }
            );

            Stage.AddProperty
            (
                "TextColor",
                "Sets the color of the icon and the value, which lets a card signal the state of the figure it shows.",
                "TextColor = _ => new PropertyColorText(TypeColorText.Success)",
                new ControlCardCounter()
                {
                    Icon = _ => new IconCheck(),
                    Value = _ => 52,
                    Text = _ => "Success",
                    TextColor = _ => new PropertyColorText(TypeColorText.Success)
                },
                new ControlCardCounter()
                {
                    Icon = _ => new IconBug(),
                    Value = _ => 7,
                    Text = _ => "Danger",
                    TextColor = _ => new PropertyColorText(TypeColorText.Danger)
                },
                new ControlCardCounter()
                {
                    Icon = _ => new IconFlag(),
                    Value = _ => 21,
                    Text = _ => "Custom",
                    TextColor = _ => new PropertyColorText("gold")
                }
            );
        }
    }
}
