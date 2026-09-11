using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the permission demo page for the tutorial.
    /// Hosts a <see cref="ControlDataPermission"/> that manages the
    /// group-to-policy assignments of the class 'Incident' (see the identity
    /// model: Identity -> Group -> Policy -> Permission). The control talks
    /// to the <see cref="IncidentPermissions"/> REST endpoint (list / assign /
    /// revoke) and fills the pickers of its assign dialog from the
    /// <see cref="IncidentPermissionGroups"/> and
    /// <see cref="IncidentPermissionPolicies"/> directories. The seed grants
    /// IT Support the edit policy, the Service Desk the view policy and the
    /// Incident Managers the admin policy.
    /// </summary>
    [WebIcon<IconShieldHalved>]
    [Title("DataPermission")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataPermission : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataPermission(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlDataPermission` manages the group-to-policy assignments of a protected resource, following the identity model (`Identity -> Group -> Policy -> Permission`). The surface is a single table: the first column names the group, the second carries its policies as chips that are edited inline with the move control and the options menu of a row revokes it. Further groups are assigned through the dialog the toolbar above the table opens, which assigns the picked policy set to every picked group, so the table shows stored assignments only. The toolbar starts with the optional title and the tools fragments contribute - here the search box the tutorial adds to every permission surface - and ends with the assign affordance. The control emits the host element and the pagination control it binds through `BindPaging`; the table itself is built by the client-side `webexpress.webapp.PermissionCtrl`.";

            Stage.Controls =
            [
                new ControlDataPermission("tutorial-permission-incident")
                {
                    Title = _ => "webexpress.tutorial.webui:permission.title",
                    PageSize = _ => 10
                }
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>()
            ];

            Stage.Code = @"
            new ControlDataPermission(""tutorial-permission-incident"")
            {
                Title = _ => ""webexpress.tutorial.webui:permission.title"",
                PageSize = _ => 10
            }
                .DataService<IncidentPermissions>()
                .GroupsService<IncidentPermissionGroups>()
                .PoliciesService<IncidentPermissionPolicies>();";

            Stage.AddProperty
            (
                "Title",
                @"The title captions the toolbar above the table. It names what the assignments protect when the surrounding page does not; hosted in a modal, the dialog header usually does, which is why the title is optional and left empty there. The value is translated, so an i18n key may be passed.",
                @"Title = _ => ""webexpress.tutorial.webui:permission.title""",
                new ControlDataPermission()
                {
                    Title = _ => "webexpress.tutorial.webui:permission.title"
                }
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>()
            );

            Stage.AddProperty
            (
                "Tools",
                @"The tools between the title and the assign affordance are contributed by fragments in the sections `SectionPermissionToolbarPreferences`, `SectionPermissionToolbarPrimary` and `SectionPermissionToolbarSecondary`. The sections resolve against the runtime type of the control, so a fragment scoped to `ControlDataPermission` joins every permission surface of the application - the search box on this page is such a fragment. A search box among the tools is bound to the surface by the control itself: typing narrows the table to the groups whose name matches, without a bind declared on the page.",
                @"[Section<SectionPermissionToolbarPrimary>]
                [Scope<ControlDataPermission>]
                public sealed class SectionPermissionToolbarPrimaryFragment : FragmentControlSearch
                {
                    public SectionPermissionToolbarPrimaryFragment(IFragmentContext fragmentContext)
                        : base(fragmentContext)
                    {
                        Placeholder = _ => ""webexpress.tutorial.webui:permission.search.placeholder"";
                    }
                }",
                new ControlDataPermission()
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>()
            );

            Stage.AddProperty
            (
                "Modal",
                @"The permission surface is typically embedded in a modal that is opened from the toolbar of the protected resource, mirroring the 'Manage permissions' flow of the application. The assign dialog of the surface then opens on top of it.",
                @"new ControlModal(""incidentPermissionsModal"", new ControlDataPermission()
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>())
                {
                    Header = _ => ""webexpress.tutorial.webui:permission.manage.header""
                }",
                new ControlButton()
                {
                    Text = _ => "Manage Permissions",
                    Icon = _ => new IconUserShield(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("incidentPermissionsModal")
                },
                new ControlModal("incidentPermissionsModal", new ControlDataPermission()
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>())
                {
                    Header = _ => "webexpress.tutorial.webui:permission.manage.header",
                    Size = _ => TypeModalSize.Large
                }
            );

            Stage.AddProperty
            (
                "Readonly",
                @"The readonly flag suppresses the assign affordance, the options menu and the inline editing of the chips, so users without administrative rights can review the effective assignments without changing them. The title and the contributed tools stay, because reading the assignments is what they help with as well. The policies service stays declared, because the chips resolve their labels through it.",
                @"Readonly = _ => true",
                new ControlDataPermission()
                {
                    Readonly = _ => true
                }
                    .DataService<IncidentPermissions>()
                    .PoliciesService<IncidentPermissionPolicies>()
            );

            Stage.AddProperty
            (
                "PageSize",
                @"The page size determines how many groups are shown per page; the pagination control below the table navigates them.",
                "PageSize = _ => 2",
                new ControlDataPermission()
                {
                    PageSize = _ => 2
                }
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>()
            );
        }
    }
}
