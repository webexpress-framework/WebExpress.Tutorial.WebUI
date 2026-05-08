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
                Layout = _ => TypeLayoutTab.Pill
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
                Layout = _ => TypeLayoutTab.Pill
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
                "Active = _ => TypeActive.Active",
                new ControlText()
                {
                    Text = _ => "None",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(CreateLink("None", TypeActive.None)),
                new ControlText()
                {
                    Text = _ => "Active",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(CreateLink("Active", TypeActive.Active)),
                new ControlText()
                {
                    Text = _ => "Disabled",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add(CreateLink("Disabled", TypeActive.Disabled))
            );

            Stage.AddProperty
            (
                "Layout",
                "Specifies the visual arrangement style of the navigation control. Determines whether navigation items are displayed as a standard bar, menu, tabbed interface, or pill-shaped buttons.",
                "Layout = _ => TypeLayoutTab.Tab",

                new ControlText()
                {
                    Text = _ => "Default",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Menu",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Menu
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Tab",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Tab
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Pill",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill
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
                "HorizontalAlignment = _ => TypeHorizontalAlignmentTab.Default",

                new ControlText()
                {
                    Text = _ => "Default",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    HorizontalAlignment = _ => TypeHorizontalAlignmentTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Left",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    HorizontalAlignment = _ => TypeHorizontalAlignmentTab.Left
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Center",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    HorizontalAlignment = _ => TypeHorizontalAlignmentTab.Center
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Right",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    HorizontalAlignment = _ => TypeHorizontalAlignmentTab.Right
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
                "Orientation = _ => TypeOrientationTab.Vertical",

                new ControlText()
                {
                    Text = _ => "Default",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    Orientation = _ => TypeOrientationTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Horizontal",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    Orientation = _ => TypeOrientationTab.Horizontal
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Vertical",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    Orientation = _ => TypeOrientationTab.Vertical
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
                "Justified = _ => TypeJustifiedTab.Justified",

                new ControlText()
                {
                    Text = _ => "Default",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    Justified = _ => TypeJustifiedTab.Default
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Justified",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    Justified = _ => TypeJustifiedTab.Justified
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
                "ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary)",

                new ControlText()
                {
                    Text = _ => "Default",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Default)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Primary",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Primary)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Secondary",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Secondary)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Info",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Info)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Success",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Success)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Warning",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Danger",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Danger)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Dark",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Dark)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Light",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Light)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "White",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.White)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Transparent",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground(TypeColorBackground.Transparent)
                }
                    .Add
                    (
                        CreateLink("One"),
                        CreateLink("Two", TypeActive.Active),
                        CreateLink("Three")
                    ),

                new ControlText()
                {
                    Text = _ => "Custom",
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlNavigation()
                {
                    Layout = _ => TypeLayoutTab.Pill,
                    ActiveColor = _ => new PropertyColorBackground("gold")
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
        private ControlNavigationItemLink CreateLink(string text, TypeActive active = TypeActive.None)
        {
            var link = new ControlNavigationItemLink()
            {
                Text = _ => text,
                Uri = _ => _pageContext.Route.ToUri(),
                Active = _ => active,
                Params = _ => new System.Collections.Generic.List<Parameter>() { new Parameter("link", text.ToLower(), ParameterScope.Parameter) }
            };

            return link;
        }
    }
}
