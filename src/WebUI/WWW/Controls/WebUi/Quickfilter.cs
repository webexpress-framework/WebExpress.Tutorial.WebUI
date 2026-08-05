using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
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

            Stage.Description = "A `Quickfilter` control provides a compact way to display and manage active filters within a page. It can host multiple filter components and visually represent the currently applied filter set. Quickfilters are typically used to refine lists, tables, or dashboards without requiring full-page reloads.\n\nAll items are backed by the same client-side filter registry and the same `ActionFilter`, so a bar may freely mix one-click chips, avatars and dropdowns. Every other control carrying an `ActionFilter` - an ordinary button or dropdown item, for instance - takes part in the same filter set, which is why the examples below stay in sync with each other.";

            Stage.Controls =
            [
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
                        }),
                    new ControlQuickfilterItemAdd("newfilter")
                    {
                        Tooltip = _ => "Create a new filter",
                        PrimaryAction = _ => new ActionModal("filtermodal")
                    }
                ),
                new ControlModalExample("filtermodal")
                {
                }
            ];

            Stage.Code = @"
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemButton(""status"")
                        {
                            Text = _ => ""Status"",
                            Icon = _ => new IconHome(),
                            PrimaryAction = _ => new ActionFilter()
                        },
                        new ControlQuickfilterItemDropdown(""sprint"")
                        {
                            Text = _ => ""Sprint"",
                            Icon = _ => new IconCalendar()
                        }
                            .Add(new ControlQuickfilterItemDropdownItem(""sprint-current"")
                            {
                                Text = _ => ""Current"",
                                PrimaryAction = _ => new ActionFilter() { Group = ""sprint"", Exclusive = true }
                            }),
                        new ControlQuickfilterItemAdd(""newfilter"")
                        {
                            Tooltip = _ => ""Create a new filter"",
                            PrimaryAction = _ => new ActionModal(""filtermodal"")
                        }
                    );";

            Stage.AddProperty
            (
                "ActionFilter",
                "Every item triggers its filter through an `ActionFilter`. A `Group` ties related filters together and `Exclusive` turns the group into a single-choice selection, so activating one member deactivates the others. Because the registry is global, ordinary controls participate in the same filter set - the buttons below toggle the very same filters as the chips above.",
                "PrimaryAction = _ => new ActionFilter() { Group = \"powerbutton\", Exclusive = true }",
                new ControlButton("onbutton")
                {
                    Text = _ => "On",
                    Icon = _ => new IconPowerOff(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    PrimaryAction = _ => new ActionFilter()
                    {
                        Group = "powerbutton",
                        Exclusive = true
                    }
                },
                new ControlButton("offbutton")
                {
                    Text = _ => "Off",
                    Icon = _ => new IconPowerOff(),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two),
                    PrimaryAction = _ => new ActionFilter()
                    {
                        Group = "powerbutton",
                        Exclusive = true
                    }
                },
                new ControlDropdown("dropdown")
                {
                    Text = _ => "Dropdown",
                    Icon = _ => new IconToggleOn()
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
                        Text = _ => "Off",
                        Icon = _ => new IconPowerOff(),
                        PrimaryAction = _ => new ActionFilter()
                        {
                            Group = "powerdropdown",
                            Exclusive = true
                        }
                    })
            );

            Stage.AddItem
            (
                typeof(ControlQuickfilterItemButton),
                "ControlQuickfilterItemButton",
                "A one-click chip toggling a single filter. It is the plainest item of the bar and the visual all other items match.",
                @"new ControlQuickfilterItemButton(""state-open"")
                {
                    Text = _ => ""Open"",
                    Icon = _ => new IconFolderOpen(),
                    PrimaryAction = _ => new ActionFilter() { Group = ""state"", Exclusive = true }
                }",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemButton("state-open")
                        {
                            Text = _ => "Open",
                            Icon = _ => new IconFolderOpen(),
                            PrimaryAction = _ => new ActionFilter() { Group = "state", Exclusive = true }
                        },
                        new ControlQuickfilterItemButton("state-closed")
                        {
                            Text = _ => "Closed",
                            Icon = _ => new IconCheck(),
                            PrimaryAction = _ => new ActionFilter() { Group = "state", Exclusive = true }
                        }
                    )
            );

            Stage.AddItemProperty
            (
                typeof(ControlQuickfilterItemButton),
                "Badge",
                "Adds a short fact at the trailing edge of the chip, typically the number of matching entries. `BadgeColor` accepts a system color as well as a user-defined one; without a badge text the chip stays unchanged.",
                @"new ControlQuickfilterItemButton(""badge-danger"")
                {
                    Badge = _ => ""12"",
                    BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                }",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemButton("badge-plain")
                        {
                            Text = _ => "Default",
                            Badge = _ => "12",
                            PrimaryAction = _ => new ActionFilter()
                        },
                        new ControlQuickfilterItemButton("badge-danger")
                        {
                            Text = _ => "Danger",
                            Badge = _ => "3",
                            BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger),
                            PrimaryAction = _ => new ActionFilter()
                        },
                        new ControlQuickfilterItemButton("badge-custom")
                        {
                            Text = _ => "Custom",
                            Badge = _ => "7",
                            BadgeColor = _ => new PropertyColorBackgroundBadge("#7c3aed"),
                            PrimaryAction = _ => new ActionFilter()
                        }
                    )
            );

            Stage.AddItemProperty
            (
                typeof(ControlQuickfilterItemButton),
                "BackgroundColor",
                "Colors the chip. A system color is emitted as its button css class, a user-defined color as a raw css value; either way the chip keeps its outline-to-filled behavior in that hue.",
                @"new ControlQuickfilterItemButton(""color-success"")
                {
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success)
                }",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemButton("color-default")
                        {
                            Text = _ => "Default",
                            PrimaryAction = _ => new ActionFilter()
                        },
                        new ControlQuickfilterItemButton("color-success")
                        {
                            Text = _ => "Success",
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Success),
                            PrimaryAction = _ => new ActionFilter()
                        },
                        new ControlQuickfilterItemButton("color-danger")
                        {
                            Text = _ => "Danger",
                            BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Danger),
                            PrimaryAction = _ => new ActionFilter()
                        },
                        new ControlQuickfilterItemButton("color-custom")
                        {
                            Text = _ => "Custom",
                            BackgroundColor = _ => new PropertyColorButton("#7c3aed"),
                            PrimaryAction = _ => new ActionFilter()
                        }
                    )
            );

            Stage.AddItem
            (
                typeof(ControlQuickfilterItemAvatar),
                "ControlQuickfilterItemAvatar",
                "An avatar chip used to filter by a person. The client draws the image when one is supplied, otherwise the icon, otherwise the initials on the person's color - matching the avatars shown elsewhere in the app.",
                @"new ControlQuickfilterItemAvatar(""owner-guybrush"")
                {
                    Text = _ => ""Guybrush Threepwood"",
                    Initials = _ => ""GT"",
                    Color = _ => ""#1d4ed8"",
                    PrimaryAction = _ => new ActionFilter() { Group = ""owner"" }
                }",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemAvatar("owner-guybrush")
                        {
                            Text = _ => "Guybrush Threepwood",
                            Initials = _ => "GT",
                            Color = _ => "#1d4ed8",
                            PrimaryAction = _ => new ActionFilter() { Group = "owner" }
                        },
                        new ControlQuickfilterItemAvatar("owner-elaine")
                        {
                            Text = _ => "Elaine Marley",
                            Initials = _ => "EM",
                            Color = _ => "#7c3aed",
                            PrimaryAction = _ => new ActionFilter() { Group = "owner" }
                        },
                        new ControlQuickfilterItemAvatar("owner-automation")
                        {
                            Text = _ => "Automation",
                            Icon = _ => new IconRobot(),
                            Color = _ => "#0e7490",
                            PrimaryAction = _ => new ActionFilter() { Group = "owner" }
                        }
                    )
            );

            Stage.AddItem
            (
                typeof(ControlQuickfilterItemDropdown),
                "ControlQuickfilterItemDropdown",
                "A single-choice dropdown of related options, which keeps a long list of filters compact. Group the options exclusively and the toggle shows the active option's label and closes on select.",
                @"new ControlQuickfilterItemDropdown(""release"")
                {
                    Text = _ => ""Release""
                }
                    .Add(new ControlQuickfilterItemDropdownItem(""release-current"")
                    {
                        Text = _ => ""Current"",
                        PrimaryAction = _ => new ActionFilter() { Group = ""release"", Exclusive = true }
                    })",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemDropdown("release")
                        {
                            Text = _ => "Release",
                            Icon = _ => new IconCalendar()
                        }
                            .Add(new ControlQuickfilterItemDropdownItem("release-current")
                            {
                                Text = _ => "Current",
                                Icon = _ => new IconPlay(),
                                Badge = _ => "14",
                                PrimaryAction = _ => new ActionFilter() { Group = "release", Exclusive = true }
                            })
                            .Add(new ControlQuickfilterItemDropdownItem("release-next")
                            {
                                Text = _ => "Next",
                                Icon = _ => new IconForward(),
                                PrimaryAction = _ => new ActionFilter() { Group = "release", Exclusive = true }
                            })
                    )
            );

            Stage.AddItem
            (
                typeof(ControlQuickfilterItemMultiSelect),
                "ControlQuickfilterItemMultiSelect",
                "A multi-select dropdown built from the same options as the single-choice one. Several options may be active at once, the menu stays open while values are picked, and the toggle shows the count of active options as a badge.",
                @"new ControlQuickfilterItemMultiSelect(""labels"")
                {
                    Text = _ => ""Labels""
                }
                    .Add(new ControlQuickfilterItemDropdownItem(""label-bug"")
                    {
                        Text = _ => ""Bug"",
                        PrimaryAction = _ => new ActionFilter() { Group = ""labels"" }
                    })",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemMultiSelect("labels")
                        {
                            Text = _ => "Labels",
                            Icon = _ => new IconTag()
                        }
                            .Add(new ControlQuickfilterItemDropdownItem("label-bug")
                            {
                                Text = _ => "Bug",
                                Icon = _ => new IconBug(),
                                Badge = _ => "8",
                                BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger),
                                PrimaryAction = _ => new ActionFilter() { Group = "labels" }
                            })
                            .Add(new ControlQuickfilterItemDropdownItem("label-feature")
                            {
                                Text = _ => "Feature",
                                Icon = _ => new IconBookmark(),
                                Badge = _ => "5",
                                PrimaryAction = _ => new ActionFilter() { Group = "labels" }
                            })
                            .Add(new ControlQuickfilterItemDropdownItem("label-docs")
                            {
                                Text = _ => "Docs",
                                Icon = _ => new IconBook(),
                                Badge = _ => "2",
                                PrimaryAction = _ => new ActionFilter() { Group = "labels" }
                            })
                    )
            );

            Stage.AddItem
            (
                typeof(ControlQuickfilterItemAdd),
                "ControlQuickfilterItemAdd",
                "A chip that creates a new filter instead of applying one. It carries no filter id, never shows active and always trails the bar, so the affordance keeps its position while filters come and go. Its `PrimaryAction` - typically an `ActionModal` opening the dialog in which the criteria are picked - is what defines the new filter.",
                @"new ControlQuickfilterItemAdd(""addfilter"")
                {
                    Tooltip = _ => ""Create a new filter"",
                    PrimaryAction = _ => new ActionModal(""addfiltermodal"")
                }",
                new ControlQuickfilter()
                    .Add
                    (
                        new ControlQuickfilterItemButton("area-frontend")
                        {
                            Text = _ => "Frontend",
                            PrimaryAction = _ => new ActionFilter() { Group = "area" }
                        },
                        new ControlQuickfilterItemAdd("addfilter")
                        {
                            Tooltip = _ => "Create a new filter",
                            PrimaryAction = _ => new ActionModal("addfiltermodal")
                        }
                    ),
                new ControlModalExample("addfiltermodal")
                {
                }
            );

            Stage.AddItemProperty
            (
                typeof(ControlQuickfilterItemAdd),
                "Text",
                "Labels the chip. Without a text the chip stays icon-only and announces itself through its `Tooltip`, which keeps a crowded bar compact.",
                @"new ControlQuickfilterItemAdd(""addfilter-labeled"")
                {
                    Text = _ => ""New filter""
                }",
                new ControlQuickfilter()
                    .Add(new ControlQuickfilterItemAdd("addfilter-labeled")
                    {
                        Text = _ => "New filter",
                        Tooltip = _ => "Create a new filter"
                    })
            );

            Stage.AddItemProperty
            (
                typeof(ControlQuickfilterItemAdd),
                "Icon",
                "Replaces the plus sign the chip is drawn with by default.",
                @"new ControlQuickfilterItemAdd(""addfilter-icon"")
                {
                    Icon = _ => new IconWandMagic()
                }",
                new ControlQuickfilter()
                    .Add(new ControlQuickfilterItemAdd("addfilter-icon")
                    {
                        Text = _ => "Smart filter",
                        Icon = _ => new IconWandMagic()
                    })
            );
        }
    }
}
