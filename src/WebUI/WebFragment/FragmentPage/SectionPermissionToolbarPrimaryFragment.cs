using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment.FragmentPage
{
    /// <summary>
    /// Contributes a search box to the toolbar of the permission surface.
    /// </summary>
    /// <remarks>
    /// The toolbar sections resolve against the <b>runtime type</b> of the permission control, so
    /// scoping the fragment to <see cref="ControlDataPermission"/> puts the box on every permission
    /// surface of the tutorial. The control binds a search box among its tools to itself, which is
    /// why no bind is declared here or on the pages hosting the surface: typing narrows the table to
    /// the groups whose name matches.
    /// </remarks>
    [Section<SectionPermissionToolbarPrimary>]
    [Scope<ControlDataPermission>]
    [Cache]
    public sealed class SectionPermissionToolbarPrimaryFragment : FragmentControlSearch
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionPermissionToolbarPrimaryFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Placeholder = _ => "webexpress.tutorial.webui:permission.search.placeholder";
        }
    }
}
