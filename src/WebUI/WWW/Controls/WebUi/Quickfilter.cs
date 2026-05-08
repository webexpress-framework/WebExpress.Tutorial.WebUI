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
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("category")
                    {
                        Text = _ => "Category",
                        Icon = _ => new IconTag(),
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("team")
                    {
                        Text = _ => "Team",
                        Icon = _ => new IconUsers(),
                        PrimaryAction = _ => new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("date")
                    {
                        Text = _ => "Date",
                        Icon = _ => new IconCalendar(),
                        PrimaryAction = _ => new ActionFilter()
                    }
                )
            ];

            Stage.Code = @"
            new ControlQuickfilter();";
        }
    }
}