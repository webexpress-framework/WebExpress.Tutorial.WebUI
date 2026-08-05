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
    /// Represents the link list control for the tutorial.
    /// </summary>
    [WebIcon<IconControlLinkList>]
    [Title("LinkList")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class LinkList : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the link list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public LinkList(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `LinkList` control groups related links under a shared heading and an optional icon. Unlike the `List` control it is not a bullet list but a labelled block of links, which suits footers, resource collections and any place where a handful of destinations belong together.";

            Stage.Control = new ControlLinkList()
            {
                Icon = _ => new IconLink(),
                Name = _ => "Resources",
                NameColor = _ => new PropertyColorText(TypeColorText.Primary)
            }
                .Add
                (
                    new ControlLink()
                    {
                        Text = _ => "Documentation",
                        Uri = _ => pageContext.Route.ToUri()
                    },
                    new ControlLink()
                    {
                        Text = _ => "Downloads",
                        Uri = _ => pageContext.Route.ToUri()
                    }
                );

            Stage.Code = @"
                new ControlLinkList()
                {
                    Icon = _ => new IconLink(),
                    Name = _ => ""Resources"",
                    NameColor = _ => new PropertyColorText(TypeColorText.Primary)
                }
                    .Add
                    (
                        new ControlLink()
                        {
                            Text = _ => ""Documentation"",
                            Uri = _ => pageContext.Route.ToUri()
                        },
                        new ControlLink()
                        {
                            Text = _ => ""Downloads"",
                            Uri = _ => pageContext.Route.ToUri()
                        }
                    );";

            Stage.AddProperty
            (
                "Name",
                "Sets the heading above the links. Without a name the control renders the links alone, which is useful when the surrounding layout already provides a caption.",
                "Name = _ => \"Resources\"",
                new ControlLinkList()
                {
                    Name = _ => "Resources"
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() }),
                new ControlLinkList()
                {
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() })
            );

            Stage.AddProperty
            (
                "NameColor",
                "Sets the color of the heading.",
                "NameColor = _ => new PropertyColorText(TypeColorText.Primary)",
                new ControlLinkList()
                {
                    Name = _ => "Primary",
                    NameColor = _ => new PropertyColorText(TypeColorText.Primary)
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() }),
                new ControlLinkList()
                {
                    Name = _ => "Muted",
                    NameColor = _ => new PropertyColorText(TypeColorText.Muted)
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() }),
                new ControlLinkList()
                {
                    Name = _ => "Custom",
                    NameColor = _ => new PropertyColorText("gold")
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() })
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon ahead of the heading, identifying the topic the links belong to.",
                "Icon = _ => new IconLink()",
                new ControlLinkList()
                {
                    Icon = _ => new IconLink(),
                    Name = _ => "Resources"
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() }),
                new ControlLinkList()
                {
                    Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)),
                    Name = _ => "Custom"
                }
                    .Add(new ControlLink() { Text = _ => "Documentation", Uri = _ => pageContext.Route.ToUri() })
            );

            Stage.AddItem
            (
                typeof(ControlLink),
                "ControlLink",
                "The entries of the list are ordinary links, so every option of the `Link` control - an icon, a tooltip, a target or an action instead of a uri - is available inside a link list as well.",
                @"new ControlLink()
                {
                    Text = _ => ""Documentation"",
                    Icon = _ => new IconBook(),
                    Uri = _ => pageContext.Route.ToUri()
                }",
                new ControlLinkList()
                {
                    Icon = _ => new IconLink(),
                    Name = _ => "Resources"
                }
                    .Add
                    (
                        new ControlLink()
                        {
                            Text = _ => "Documentation",
                            Icon = _ => new IconBook(),
                            Uri = _ => pageContext.Route.ToUri()
                        },
                        new ControlLink()
                        {
                            Text = _ => "Downloads",
                            Icon = _ => new IconDownload(),
                            Uri = _ => pageContext.Route.ToUri()
                        },
                        new ControlLink()
                        {
                            Text = _ => "Report an issue",
                            Icon = _ => new IconBug(),
                            Tooltip = _ => "Opens the issue tracker",
                            Uri = _ => pageContext.Route.ToUri()
                        }
                    )
            );
        }
    }
}
