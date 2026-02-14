using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebParameter;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the navigation control for the tutorial.    
    /// </summary>    
    [Title("Navigation")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Navigation : PageControl
    {
        private readonly IPageContext _pageContext;

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Navigation(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            _pageContext = pageContext;

            Stage.Description = @"The `Navigation` control is a versatile interface element for creating clear, well‑structured navigation bars in applications. It helps users move quickly between different sections, modules, or pages, whether displayed horizontally as a classic menu bar or vertically as a sidebar.";

            Stage.Control = new ControlNavigation()
            {
                Layout = TypeLayoutTab.Pill
            }
                .Add
                (
                    CreateLink("One"),
                    CreateLink("Two", TypeActive.Active),
                    CreateLink("Three")
                );

            Stage.Code = @"
            Stage.Control =  new ControlNavigation()
            {
                Layout = TypeLayoutTab.Pill
            }
                .Add
                (
                    CreateLink(""One""),
                    CreateLink(""Two"", TypeActive.Active),
                    CreateLink(""Three"")
                );";

            Stage.AddProperty
            (
                "Active",
                "Defines the visual and functional state of a navigation link. Determines whether a link is inactive, highlighted as the current selection, or disabled to prevent interaction.",
                "Active = TypeActive.Active",
                new ControlText()
                {
                    Text = "None",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add(CreateLink("None", TypeActive.None)),
                new ControlText()
                {
                    Text = "Active",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add(CreateLink("Active", TypeActive.Active)),
                new ControlText()
                {
                    Text = "Disabled",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add(CreateLink("Disabled", TypeActive.Disabled))
            );

            Stage.AddProperty
            (
                "Layout",
                "Specifies the visual arrangement style of the navigation control. Determines whether navigation items are displayed as a standard bar, menu, tabbed interface, or pill-shaped buttons.",
                "Layout = TypeLayoutTab.Tab",

                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Menu",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Menu
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Tab",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Tab
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Pill",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    )
            );

            Stage.AddProperty
            (
                "HorizontalAlignment",
                "Specifies how navigation items are positioned horizontally within the navigation control. Choose between default, left-aligned, centered, or right-aligned layouts.",
                "HorizontalAlignment = TypeHorizontalAlignmentTab.Default",

                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    HorizontalAlignment = TypeHorizontalAlignmentTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Left",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    HorizontalAlignment = TypeHorizontalAlignmentTab.Left
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Center",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    HorizontalAlignment = TypeHorizontalAlignmentTab.Center
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Right",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    HorizontalAlignment = TypeHorizontalAlignmentTab.Right
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    )
            );

            Stage.AddProperty
            (
                "Orientation",
                "Specifies the direction in which navigation items are arranged within the navigation control. Choose between default, horizontal, or vertical orientation.",
                "Orientation = TypeOrientationTab.Vertical",

                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    Orientation = TypeOrientationTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Horizontal",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    Orientation = TypeOrientationTab.Horizontal
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Vertical",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    Orientation = TypeOrientationTab.Vertical
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    )
            );

            Stage.AddProperty
            (
                "Justified",
                "Determines whether all navigation links should have equal width. When enabled, each link expands to occupy the same horizontal space, creating a balanced and uniform appearance.",
                "Justified = TypeJustifiedTab.Justified",

                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    Justified = TypeJustifiedTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Justified",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    Justified = TypeJustifiedTab.Justified
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    )
            );

            Stage.AddProperty
            (
                "ActiveColor",
                "Specifies the background color applied to the active navigation item. Choose from predefined theme colors or provide a custom value. Only the active item is affected.",
                "ActiveColor = new PropertyColorBackground(TypeColorBackground.Secondary)",

                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Default)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Primary",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Primary)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Secondary",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Info",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Info)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Success",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Warning",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Warning)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Danger",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Danger)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Dark",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Dark)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Light",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Light)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "White",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.White)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Transparent",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground(TypeColorBackground.Transparent)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = "Custom",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = TypeLayoutTab.Pill,
                    ActiveColor = new PropertyColorBackground("gold")
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    )
            );
        }

        /// <summary>
        /// Creates a new ControlNavigationItemLink with the specified text, identifier, 
        /// and active state.
        /// </summary>
        /// <param name="text">The display text for the link.</param>
        /// <param name="active">The active state of the link. The default value is None.</param>
        /// <returns>A <see cref="ControlNavigationItemLink"/> instance initialized with the specified parameters.</returns>
        private ControlNavigationItemLink CreateLink
        (
            string text,
            TypeActive active = TypeActive.None
        )
        {
            var link = new ControlNavigationItemLink()
            {
                Text = text,
                Uri = _pageContext.Route.ToUri(),
                Active = active
            };
            link.Params.Add(new Parameter("link", text.ToLower(), ParameterScope.Parameter));

            return link;
        }
    }
}
