﻿using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WWW.Controls;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents a navigation item link for the control page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to create a navigation link to the Control page with an icon and label.
    /// </remarks>
    [Section<SectionAppNavigationPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Cache]
    public sealed class ControlLinkFragment : FragmentControlNavigationItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public ControlLinkFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "webexpress.tutorial.webui:controlpage.label";
            Uri = componentHub.SitemapManager.GetUri<Index>(fragmentContext.ApplicationContext);
            Icon = new IconClone();
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            Active = renderContext.Endpoint is PageControl || renderContext.Endpoint is Index ? TypeActive.Active : TypeActive.None;

            return base.Render(renderContext, visualTree);
        }
    }
}