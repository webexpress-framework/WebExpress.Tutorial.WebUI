using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents the sidebar fragment for the control page.
    /// This fragment is used to display the primary sidebar section in the control page.
    /// </summary>
    [Section<SectionSidebarSecondary>]
    [Scope<IScopeControl>]
    [Cache]
    [Order(4)]
    public sealed class ControlSidebarFragmentWebAppTree : FragmentControlSidebarItemDynamic
    {
        private readonly struct SidebarTreeItem
        {
            public string Id { get; init; }
            public string Text { get; init; }
            public IUri Uri { get; init; }
            public bool Active { get; init; }
        }

        private readonly IComponentHub _componentHub;
        private readonly IFragmentContext _fragmentContext;

        /// <summary>
        /// Gets the control tree used to manage and organize UI controls.
        /// </summary>
        public ControlTree Tree { get; } = new ControlTree("webapp-control-tree")
        {
            Layout = _ => TypeLayoutTree.Default
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">
        /// The component hub providing access to various managers and services.
        /// </param>
        /// <param name="fragmentContext">
        /// The context of the fragment, providing access to the current state and dependencies.
        /// </param>
        public ControlSidebarFragmentWebAppTree(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            _componentHub = componentHub;
            _fragmentContext = fragmentContext;
            Icon = _ => new IconSitemap();
            Mode = _ => TypeSidebarModeExtended.Overlay;

            RenderControl += (renderContext, visualTree) =>
            {
                var indexContext = _componentHub?.PageManager
                    .GetPages(typeof(WWW.Controls.WebApp.Index), _fragmentContext.ApplicationContext)
                    .FirstOrDefault();

                var items = _componentHub?.PageManager.Pages
                    .Where(x => x.ApplicationContext == _fragmentContext.ApplicationContext)
                    .Where(x => x.Scopes.Contains(typeof(IScopeControlWebApp)))
                    .Where(x => x.EndpointId != indexContext?.EndpointId)
                    .OrderBy(x => x.PageTitle)
                    .Select(x => new SidebarTreeItem
                    {
                        Id = x.EndpointId?.ToString(),
                        Text = I18N.Translate(renderContext, x.PageTitle),
                        Uri = (IUri)new UriEndpoint(x.Route.PathSegments.ToArray()),
                        Active = x.Route == renderContext.PageContext.Route
                    })
                    .ToList();

                var tree = indexContext?.Route is null
                    ? []
                    : BuildTree(items, (IUri)new UriEndpoint(indexContext.Route.PathSegments.ToArray()));

                return Tree.Render(renderContext, visualTree, tree);
            };
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return base.Render(renderContext, visualTree);
        }

        /// <summary>
        /// Builds a hierarchical tree structure from a flat list of items.
        /// </summary>
        /// <param name="items">The flat list of tree items.</param>
        /// <param name="root">The root URI to determine the hierarchy.</param>
        /// <returns>A collection of <see cref="ControlTreeItem"/> representing the hierarchical tree structure.</returns>
        private static IEnumerable<ControlTreeItem> BuildTree(IReadOnlyList<SidebarTreeItem> items, IUri root)
        {
            var rootSegments = root.PathSegments as IReadOnlyList<IUriPathSegment> ?? root.PathSegments.ToList();
            return BuildTree(items, rootSegments);
        }

        /// <summary>
        /// Builds a hierarchical <see cref="ControlTreeItem"/> structure from a flat list
        /// of <see cref="SidebarTreeItem"/> entries. The hierarchy is derived from the
        /// URI path segments of each item, where a direct child must extend the parent's
        /// segment prefix by exactly one level.
        /// </summary>
        /// <param name="items">
        /// The complete list of sidebar items from which the tree is constructed.
        /// </param>
        /// <param name="parentSegments">
        /// The URI path segments identifying the current parent node. Only items whose
        /// segments form a direct one-level extension of this prefix are considered.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="ControlTreeItem"/> instances representing the direct
        /// children of the specified parent, each populated with recursively built
        /// descendant nodes.
        /// </returns>
        private static IEnumerable<ControlTreeItem> BuildTree(IReadOnlyList<SidebarTreeItem> items, IReadOnlyList<IUriPathSegment> parentSegments)
        {
            var nodes = new List<ControlTreeItem>();
            var childDepth = parentSegments.Count + 1;

            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var itemSegments = item.Uri.PathSegments as IReadOnlyList<IUriPathSegment> ?? item.Uri.PathSegments.ToList();

                if (!IsDirectChild(parentSegments, itemSegments, childDepth))
                {
                    continue;
                }

                var node = new ControlTreeItem(item.Id, [.. BuildTree(items, itemSegments)])
                {
                    Text = _ => item.Text,
                    Uri = _ => item.Uri,
                    Active = _ => item.Active,
                    Expand = _ => true
                };

                nodes.Add(node);
            }

            return nodes;
        }

        /// <summary>
        /// Determines whether a candidate URI segment list represents a direct child of
        /// a specified parent segment list. A direct child must extend the parent's
        /// segment prefix by exactly one additional segment and match all existing
        /// segments using case-insensitive comparison.
        /// </summary>
        /// <param name="parentSegments">
        /// The URI path segments identifying the parent node.
        /// </param>
        /// <param name="candidateSegments">
        /// The URI path segments of the item being tested.
        /// </param>
        /// <param name="childDepth">
        /// The required depth for a direct child, typically
        /// <c>parentSegments.Count + 1</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the candidate extends the parent's prefix by exactly one
        /// segment; otherwise <c>false</c>.
        /// </returns>
        private static bool IsDirectChild(IReadOnlyList<IUriPathSegment> parentSegments, IReadOnlyList<IUriPathSegment> candidateSegments, int childDepth)
        {
            if (candidateSegments.Count != childDepth)
            {
                return false;
            }

            for (var i = 0; i < parentSegments.Count; i++)
            {
                if (!string.Equals(parentSegments[i].Value, candidateSegments[i].Value, System.StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
