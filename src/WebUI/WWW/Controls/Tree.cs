using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the tree control for the tutorial.    
    /// </summary>    
    [Title("Tree")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Tree : PageControl
    {
        private readonly IEnumerable<ControlTreeItem> _nodes =
        [
            new ControlTreeItem("1",
                [
                    new ControlTreeItem("1.1")
                    {
                        Text = "Node 1.1",
                        Uri = new UriEndpoint("http://example.com")
                    },
                    new ControlTreeItem("1.2")
                    {
                        Text = "Node 1.2"
                    }
                ])
            {
                Text = "Node 1",
                IconOpen = new IconFolderOpen(),
                IconClose = new IconFolder(),
                Expand = true
            },
            new ControlTreeItem("2",
                [
                    new ControlTreeItem("2.1")
                    {
                        Text = "Node 2.1"
                    },
                    new ControlTreeItem("2.2")
                    {
                        Text = "Node 2.2"
                    }
                ])
            {
                Text = "Node 2",
                IconOpen = new IconFolderOpen(),
                IconClose = new IconFolder(),
                Icon = new IconCog(),
                Expand = false
            }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Tree(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_VISIBILITY_EVENT, Event.CLICK_EVENT, Event.MOVE_EVENT);

            Stage.Description = @"The `Tree` control provides a hierarchical tree structure that represents the organization and relationships of various UI controls. Its structured layout facilitates navigation and management of the contained elements. Each component within the tree can have parent or child elements, creating a logical arrangement that supports interactions and dependencies between controls.";

            Stage.Control = new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
            {
            };

            Stage.Code = @"
            new ControlTree()
            {
                null,
                new ControlTreeItem(""1"", ...
            };";

            Stage.AddProperty
            (
                "DisableIndicator",
                "The `DisableIndicator` property controls the visibility of indicators within the tree structure. When disabled, the visual cues that typically show whether a node is expanded, collapsed, or a leaf node without a substructure are removed. By hiding these indicators, the tree takes on a cleaner, more minimalistic appearance. This can be useful when a simplified visual design is desired or when the hierarchical structure does not need to be explicitly displayed.",
                "DisableIndicator = true",
                new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                {
                    DisableIndicator = true
                }
            );

            Stage.AddProperty
            (
                "Movable",
                "The `Movable` property enables the drag-and-drop movement of nodes within the tree structure. When activated, users can click or tap on a node and drag it to a new position, allowing for intuitive and dynamic reorganization. This feature enhances interactivity and usability, making it easy to adjust the structure visually without manual configuration. It is ideal for applications requiring flexible, user-controlled arrangement of nodes.",
                "Movable = true",
                new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                {
                    Movable = true
                }
            );

            Stage.AddProperty
            (
                "Layout",
                "The `Layout` property controls the visual representation of the tree, determining how its structure and elements are arranged. By selecting different layout options, the appearance can be optimized for better readability, clarity, and usability.",
                "Layout = TypeLayoutTree.Simple",
                [
                    new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                    {
                        Layout = TypeLayoutTree.Default
                    },
                    new ControlText() { Text = "Group", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                    {
                        Layout = TypeLayoutTree.Group
                    },
                    new ControlText() { Text = "Flat", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                    {
                        Layout = TypeLayoutTree.Flat
                    },
                    new ControlText() { Text = "Flush", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                    {
                        Layout = TypeLayoutTree.Flush
                    },
                    new ControlText() { Text = "Horizontal", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTree(Guid.NewGuid().ToString(), [.. _nodes])
                    {
                        Layout = TypeLayoutTree.Horizontal
                    }
                ]
            );

            Stage.AddItem
            (
                "Expand",
                "The `Expand` property controls the visibility of a tree node's substructure. It determines whether the child elements are displayed by default or remain collapsed.\r\n\r\nBy managing visibility dynamically, `Expand` allows for a flexible tree structure. Users can reveal relevant sections as needed, improving navigation and ensuring a clearer, more organized view.",
                @"
                new ControlTree(Guid.NewGuid().ToString())
                {
                }
                    .Add(new ControlTreeItem(""1"", new ControlTreeItem(""1.1""))
                    {
                        Expand = true
                    })",
                new ControlTree(Guid.NewGuid().ToString())
                {
                }
                    .Add(new ControlTreeItem("1", new ControlTreeItem("1.1"))
                    {
                        Expand = true
                    })
            );

            Stage.AddItem
            (
                "DisableIndicator",
                "Determines whether the expand/collapse indicator is displayed for tree nodes. When set to true, the indicator is hidden even if the node has children, allowing for cleaner layouts or custom expansion logic.",
                @"
                new ControlTree() 
                { 
                    DisableIndicator = true 
                }
                    .Add(...)",
                new ControlTree(Guid.NewGuid().ToString())
                {
                    DisableIndicator = true
                }
                    .Add(_nodes)
            );

            Stage.AddItem
            (
                "Uri",
                "The `Uri` property enables the association of a node with a specific link address. These links can point to external websites or internal resources, allowing users to navigate directly to relevant content.",
                "new ControlTreeItemLink(\"1\") { Uri = new UriEndpoint(\"http://example.com\") }",
                new ControlTree(Guid.NewGuid().ToString(), new ControlTreeItem("1") { Uri = new UriEndpoint("http://example.com") })
                {
                }
            );

            Stage.AddItem
            (
                "Target",
                "The `Target` property controls how a link opens when clicked. It determines whether the destination page appears in the same tab, a new tab, or a specific window.",
                "new ControlTreeItemLink(\"1\") { Uri = new UriEndpoint(\"http://example.com\"), Target = TypeTarget.Blank }",
                new ControlTree(Guid.NewGuid().ToString(), new ControlTreeItem("1") { Uri = new UriEndpoint("http://example.com"), Target = TypeTarget.Blank })
                {
                }
            );

            Stage.AddItem
            (
                "Tooltip",
                "The `Tooltip` property provides additional information when hovering over a node. It displays a small pop-up text box, helping users understand the purpose or details of the node without clicking on it.",
                "new ControlTreeItemLink(\"1\") { Tooltip = \"abc\" }",
                new ControlTree(Guid.NewGuid().ToString(), new ControlTreeItem("1") { Tooltip = "abc" })
                {
                }
            );

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a node. It provides a visual representation and identification of nodes within the tree structure, enhancing user guidance and recognition.\r\n\r\nIcons can be either system icons or custom icons, allowing flexibility in design and functionality. System icons offer a standardized visual language, ensuring consistency across applications, while custom icons enable tailored representations to meet specific user needs.",
                "new ControlTreeItem(\"1\") { Icon = new IconHome() }",
                new ControlTree(Guid.NewGuid().ToString(), new ControlTreeItem("1") { Icon = new IconHome() })
                {
                }
            );

            Stage.AddItem
            (
                "IconOpen and IconClose",
                @"The `IconOpen` and `IconClose` property defines the symbols assigned to a node, representing its state within the tree structure. Each node can have two distinct icons: `IconOpen` – Displays when the node is expanded, indicating that its substructure is visible. `IconClose` – Appears when the node is collapsed, signaling that its substructure is hidden. Using separate icons for open and closed states enhances clarity and usability, allowing users to intuitively understand and interact with the tree structure.",
                "new ControlTreeItem(\"1\", new ControlTreeItem(\"1.1\")) { Expand = true, IconOpen=new IconFolderOpen(), IconClose=new IconFolder() }",
                new ControlTree(Guid.NewGuid().ToString(), new ControlTreeItem("1", new ControlTreeItem("1.1")) { Expand = true, IconOpen = new IconFolderOpen(), IconClose = new IconFolder() })
                {
                }
            );
        }
    }
}
