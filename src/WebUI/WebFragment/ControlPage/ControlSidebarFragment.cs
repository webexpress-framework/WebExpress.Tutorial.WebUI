using System.Linq;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebUI.WWW.Controls;

namespace WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents the sidebar fragment for the control page.
    /// This fragment is used to display the primary sidebar section in the control page.
    /// </summary>
    [Section<SectionSidebarPrimary>]
    [Scope<IScopeControl>]
    [Cache]
    public sealed class ControlSidebarFragment : FragmentControlNavigation
    {
        private readonly IComponentHub _componentHub;
        private readonly IFragmentContext _fragmentContext;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <param name="fragmentContext">The context of the fragment, providing access to the current state and dependencies.</param>
        public ControlSidebarFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            _componentHub = componentHub;
            _fragmentContext = fragmentContext;

            Layout = TypeLayoutTab.Pill;
            Orientation = TypeOrientationTab.Vertical;
            GridColumn = new PropertyGrid(TypeDevice.Medium, 2);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var indexContext = _componentHub.PageManager.GetPages(typeof(Index), _fragmentContext.ApplicationContext).FirstOrDefault();
            var items = _componentHub.PageManager.Pages
                .Where(x => x.ApplicationContext == _fragmentContext.ApplicationContext)
                .Where(x => x.Scopes.Contains(typeof(IScopeControl)))
                .Where(x => x.EndpointId != indexContext?.EndpointId)
                .OrderBy(x => x.PageTitle)
                .Select(x => new ControlNavigationItemLink()
                {
                    Text = I18N.Translate(renderContext, x.PageTitle),
                    Uri = x.Route.ToUri(),
                    Active = renderContext.PageContext.EndpointId == x.EndpointId
                        ? TypeActive.Active
                        : TypeActive.None
                });

            return base.Render(renderContext, visualTree, items);
        }
    }
}
