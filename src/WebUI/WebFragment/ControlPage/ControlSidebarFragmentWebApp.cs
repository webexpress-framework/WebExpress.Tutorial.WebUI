using System.Collections.Generic;
using System.Linq;
using WebExpress.Toutorial.WebUI.WebScope;
using WebExpress.Toutorial.WebUI.WWW.Controls;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Toutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents the sidebar fragment for the control page.
    /// This fragment is used to display the primary sidebar section in the control page.
    /// </summary>
    [Section<SectionSidebarSecondary>]
    [Scope<IScopeControl>]
    [Cache]
    public sealed class ControlSidebarFragmentWebApp : FragmentControlTree
    {
        private readonly IComponentHub _componentHub;
        private readonly IFragmentContext _fragmentContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlSidebarFragmentWebUI"/> class.
        /// </summary>
        /// <param name="componentHub">The component hub providing access to various managers and services.</param>
        /// <param name="fragmentContext">The context of the fragment, providing access to the current state and dependencies.</param>
        public ControlSidebarFragmentWebApp(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            _componentHub = componentHub;
            _fragmentContext = fragmentContext;

            Layout = TypeLayoutTree.Default;
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var indexContext = _componentHub.PageManager.GetPages(typeof(Index), _fragmentContext.ApplicationContext).FirstOrDefault();
            var items = _componentHub.PageManager.Pages
                .Where(x => x.ApplicationContext == _fragmentContext.ApplicationContext)
                .Where(x => x.Scopes.Contains(typeof(IScopeControlWebApp)))
                .Where(x => x.EndpointId != indexContext?.EndpointId)
                .OrderBy(x => x.PageTitle)
                .Select(x => new ControlTreeItem
                {
                    Label = I18N.Translate(renderContext, x.PageTitle),
                    Uri = x.Route.ToUri(),
                    Active = x.Route == renderContext.PageContext.Route,
                    Expand = true
                }).ToList();

            var tree = BuildTree(items, indexContext.Route.ToUri());

            return new HtmlElementTextContentP("WebExpress.WebApp").Add(base.Render(renderContext, visualTree, tree));
        }

        /// <summary>
        /// Builds a hierarchical tree structure from a flat list of items.
        /// </summary>
        /// <param name="items">The flat list of tree items.</param>
        /// <param name="root">The root URI to determine the hierarchy.</param>
        /// <returns>A collection of <see cref="ControlTreeItemLink"/> representing the hierarchical tree structure.</returns>
        private static IEnumerable<ControlTreeItem> BuildTree(IEnumerable<ControlTreeItem> items, IUri root)
        {
            var nodes = new List<ControlTreeItem>();

            foreach (var item in items.Where
            (
                x => x.Uri.ToString().StartsWith(root.ToString()) &&
                x.Uri.PathSegments.Count() == root.PathSegments.Count() + 1)
            )
            {
                var node = new ControlTreeItem(item.Id, BuildTree(items, item.Uri).ToArray())
                {
                    Label = item.Label,
                    Uri = item.Uri,
                    Active = item.Active,
                    Expand = true
                };
                nodes.Add(node);
            }

            return nodes;
        }
    }
}
