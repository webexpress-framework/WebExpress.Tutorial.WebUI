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
    /// Represents a fragment that displays a list of controls.
    /// </summary>
    [Section<SectionContentPrimary>]
    [Scope<Index>]
    [Cache]
    public sealed class ControlListFragment : FragmentControlList
    {
        private readonly IComponentHub _componentHub;
        private readonly IFragmentContext _fragmentContext;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context of the fragment.</param>
        public ControlListFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
          : base(fragmentContext)
        {
            _componentHub = componentHub;
            _fragmentContext = fragmentContext;

            Layout = TypeLayoutList.Simple;
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            // Retrieve the context of the index page.
            var indexContext = _componentHub.PageManager.GetPages(typeof(Index), _fragmentContext.ApplicationContext).FirstOrDefault();

            // Retrieve and filter the list of pages to be displayed.
            var items = _componentHub.PageManager.Pages
                .Where(x => x.ApplicationContext == _fragmentContext.ApplicationContext)
                .Where(x => x.Scopes.Contains(typeof(IScopeControl)))
                .Where(x => x.EndpointId != indexContext?.EndpointId)
                .OrderBy(x => x.PageTitle)
                .Select(x => new ControlListItemLink()
                {
                    Text = I18N.Translate(renderContext, x.PageTitle),
                    Uri = x.Route.ToUri(),
                    Active = renderContext.PageContext.EndpointId == x.EndpointId
                        ? TypeActive.Active
                        : TypeActive.None
                });

            // Render the control list with the filtered items.
            return base.Render(renderContext, visualTree, items);
        }
    }
}