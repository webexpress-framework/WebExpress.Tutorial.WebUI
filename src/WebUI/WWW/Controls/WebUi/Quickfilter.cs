using WebExpress.Tutorial.WebUI.Model;
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
    /// Represents a simple quickfilter test board for demonstration purposes.
    /// </summary>
    [Title("Quickfilter")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Quickfilter : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Quickfilter(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_FILTER_EVENT);

            Stage.Description = "A `Quickfilter` control provides a compact way to display and manage active filters within a page. It can host multiple filter components and visually represent the currently applied filter set. Quickfilters are typically used to refine lists, tables, or dashboards without requiring full-page reloads.";

            Stage.Controls =
            [
                new ControlText() { Text = _ => "ControlButton", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlButton("onbutton")
                {
                    Text = (c) => "On",
                    Icon = _ => new IconPowerOff(),
                    PrimaryAction = _ => new ActionFilter()
                    {
                        Group = "powerbutton",
                        Exclusive = true
                    }
                },
                new ControlButton("offbutton")
                {
                    Text = (c) => "Off",
                    Icon = _ => new IconPowerOff(),
                    PrimaryAction = _ => new ActionFilter()
                    {
                        Group = "powerbutton",
                        Exclusive = true
                    }
                },
                new ControlText() { Text = _ => "ControlDropdown", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDropdown("dropdown")
                {
                    Text =_ =>  "Dropdown",
                    Icon = _ => new IconToggleOn(),

                }
                    .Add(new ControlDropdownItemLink("ondropdown")
                    {
                        Text = _ => "On",
                        Icon = _ => new IconPowerOff(),
                        PrimaryAction = _ => new ActionFilter()
                        {
                            Group = "powerdropdown",
                        Exclusive = true
                        }
                    })
                    .Add(new ControlDropdownItemLink("offdropdown")
                    {
                        Text =_ =>  "Off",
                        Icon = _ => new IconPowerOff(),
                        PrimaryAction = _ => new ActionFilter()
                        {
                            Group = "powerdropdown",
                        Exclusive = true
                        }
                    }),
                new ControlText() { Text = _ => "ControlQuickfilter", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlQuickfilter()
                .Add
                (
                    new ControlQuickfilterItemButton("status")
                    {
                        Text = _ => "Status",
                        Icon = _ => new IconHome(),
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("priority")
                    {
                        Text = _ => "Priority",
                        Icon = _ => new IconFlag(),
                        Badge = _ => "3",
                        BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger),
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("category")
                    {
                        Text = _ => "Category",
                        Icon = _ => new IconTag(),
                        BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("team")
                    {
                        Text = _ => "Team",
                        Icon = _ => new IconUsers(),
                        Badge = _ => "12",
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("date")
                    {
                        Text = _ => "Date",
                        Icon = _ => new IconCalendar(),
                        BackgroundColor = _ => new PropertyColorButton("#7c3aed"),
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemDropdown("sprint")
                    {
                        Text = _ => "Sprint",
                        Icon = _ => new IconCalendar()
                    }
                        .Add(new ControlQuickfilterItemDropdownItem("sprint-current")
                        {
                            Text = _ => "Current",
                            Icon = _ => new IconPlay(),
                            PrimaryAction = _ => new ActionFilter() { Group = "sprint", Exclusive = true }
                        })
                        .Add(new ControlQuickfilterItemDropdownItem("sprint-next")
                        {
                            Text = _ => "Next",
                            Icon = _ => new IconForward(),
                            PrimaryAction = _ => new ActionFilter() { Group = "sprint", Exclusive = true }
                        }),
                    new ControlQuickfilterItemAvatar("assignee-guybrush")
                    {
                        Text = _ => "Guybrush Threepwood",
                        Initials = _ => "GT",
                        Color = _ => "#1d4ed8",
                        PrimaryAction = _ => new ActionFilter() { Group = "assignee" }
                    },
                    new ControlQuickfilterItemAvatar("assignee-elaine")
                    {
                        Text = _ => "Elaine Marley",
                        Initials = _ => "EM",
                        Color = _ => "#7c3aed",
                        PrimaryAction = _ => new ActionFilter() { Group = "assignee" }
                    },
                    new ControlQuickfilterItemAvatar("assignee-automation")
                    {
                        Text = _ => "Automation",
                        Icon = _ => new IconRobot(),
                        Color = _ => "#0e7490",
                        PrimaryAction = _ => new ActionFilter() { Group = "assignee" }
                    },
                    new ControlQuickfilterItemMultiSelect("tags")
                    {
                        Text = _ => "Tags",
                        Icon = _ => new IconTag()
                    }
                        .Add(new ControlQuickfilterItemDropdownItem("tag-bug")
                        {
                            Text = _ => "Bug",
                            Icon = _ => new IconBug(),
                            Badge = _ => "8",
                            BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger),
                            PrimaryAction = _ => new ActionFilter() { Group = "tags" }
                        })
                        .Add(new ControlQuickfilterItemDropdownItem("tag-feature")
                        {
                            Text = _ => "Feature",
                            Icon = _ => new IconBookmark(),
                            Badge = _ => "5",
                            PrimaryAction = _ => new ActionFilter() { Group = "tags" }
                        })
                        .Add(new ControlQuickfilterItemDropdownItem("tag-docs")
                        {
                            Text = _ => "Docs",
                            Icon = _ => new IconBook(),
                            Badge = _ => "2",
                            PrimaryAction = _ => new ActionFilter() { Group = "tags" }
                        })
                )
            ];

            Stage.Code = @"
            new ControlQuickfilter();";
        }
    }
}