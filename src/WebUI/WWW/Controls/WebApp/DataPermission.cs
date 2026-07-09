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
    /// revoke) and fills its assign selects from the
    /// <see cref="IncidentPermissionGroups"/> and
    /// <see cref="IncidentPermissionPolicies"/> directories. The seed grants
    /// IT Support the edit policy, the Service Desk the view policy and the
    /// Incident Managers the admin policy.
    /// </summary>
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
            Stage.Description = @"`ControlDataPermission` manages the group-to-policy assignments of a protected resource, following the identity model (`Identity -> Group -> Policy -> Permission`). The control only emits the host element; the assign row, the searchable, paged assignment table and the revoke affordance are built by the client-side `webexpress.webapp.PermissionCtrl`.";

            Stage.Controls =
            [
                new ControlDataPermission("tutorial-permission-incident")
                {
                    PageSize = _ => 10
                }
                    .DataService<IncidentPermissions>()
                    .GroupsService<IncidentPermissionGroups>()
                    .PoliciesService<IncidentPermissionPolicies>()
            ];

            Stage.Code = @"
            new ControlDataPermission(""tutorial-permission-incident"")
            {
                PageSize = _ => 10
            }
                .DataService<IncidentPermissions>()
                .GroupsService<IncidentPermissionGroups>()
                .PoliciesService<IncidentPermissionPolicies>();";

            Stage.AddProperty
            (
                "Modal",
                @"The permission surface is typically embedded in a modal that is opened from the toolbar of the protected resource, mirroring the 'Manage permissions' flow of the application.",
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
                @"The readonly flag suppresses the assign row and the per-row revoke affordance, so users without administrative rights can review the effective assignments without changing them.",
                "Readonly = _ => true",
                new ControlDataPermission()
                {
                    Readonly = _ => true
                }
                    .DataService<IncidentPermissions>()
            );

            Stage.AddProperty
            (
                "PageSize",
                @"The page size determines how many assignments are shown per page; the pager appears as soon as more assignments exist.",
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
