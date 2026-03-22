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
                new ControlText() { Text = "ControlButton", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlButton("onbutton")
                {
                    Text = "On",
                    Icon = new IconPowerOff(),
                    PrimaryAction = new ActionFilter()
                    {
                        Group = "powerbutton",
                        Exclusive = true
                    }
                },
                new ControlButton("offbutton")
                {
                    Text = "Off",
                    Icon = new IconPowerOff(),
                    PrimaryAction = new ActionFilter()
                    {
                        Group = "powerbutton",
                        Exclusive = true
                    }
                },
                new ControlText() { Text = "ControlDropdown", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDropdown("dropdown")
                {
                    Text = "Dropdown",
                    Icon = new IconToggleOn(),

                }
                    .Add(new ControlDropdownItemLink("ondropdown")
                    {
                        Text = "On",
                        Icon = new IconPowerOff(),
                        PrimaryAction = new ActionFilter()
                        {
                            Group = "powerdropdown",
                        Exclusive = true
                        }
                    })
                    .Add(new ControlDropdownItemLink("offdropdown")
                    {
                        Text = "Off",
                        Icon = new IconPowerOff(),
                        PrimaryAction = new ActionFilter()
                        {
                            Group = "powerdropdown",
                        Exclusive = true
                        }
                    }),
                new ControlText() { Text = "ControlQuickfilter", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlQuickfilter()
                .Add
                (
                    new ControlQuickfilterItemButton("status")
                    {
                        Text = "Status",
                        Icon = new IconHome(),
                        PrimaryAction = new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("priority")
                    {
                        Text = "Priority",
                        Icon = new IconFlag(),
                        PrimaryAction = new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("category")
                    {
                        Text = "Category",
                        Icon = new IconTag(),
                        PrimaryAction = new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("team")
                    {
                        Text = "Team",
                        Icon = new IconUsers(),
                        PrimaryAction = new ActionFilter()
                    },
                    new ControlQuickfilterItemButton("date")
                    {
                        Text = "Date",
                        Icon = new IconCalendar(),
                        PrimaryAction = new ActionFilter()
                    }
                )
            ];

            Stage.Code = @"
            new ControlQuickfilter();";
        }
    }
}