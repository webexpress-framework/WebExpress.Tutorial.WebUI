using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides the directory of assignable identity groups for the incident
    /// permission demo. Backs the "groups" service of the permission control,
    /// which fills the group select of the assign row.
    /// </summary>
    [Segment("incident-permission-groups")]
    [Title("Incident Permission Groups")]
    public sealed class IncidentPermissionGroups : RestApiPermissionGroups
    {
        /// <summary>
        /// Returns the assignable identity groups of the demo directory.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The groups.</returns>
        protected override IEnumerable<RestApiPermissionGroup> RetrieveGroups(IRequest request)
        {
            return IncidentPermissionDirectory.Groups;
        }
    }

    /// <summary>
    /// Shared in-memory directory of the identity groups and policies of the
    /// incident permission demo. Used by the assignment endpoint (to resolve
    /// ids when a group is assigned) and by the groups and policies endpoints
    /// (to fill the assign selects). In a real application both would come
    /// from the identity manager.
    /// </summary>
    internal static class IncidentPermissionDirectory
    {
        /// <summary>
        /// Gets the assignable identity groups.
        /// </summary>
        public static IReadOnlyList<RestApiPermissionGroup> Groups { get; } =
        [
            new() { Id = "it-support",        Name = "IT Support" },
            new() { Id = "service-desk",      Name = "Service Desk" },
            new() { Id = "incident-managers", Name = "Incident Managers" },
            new() { Id = "end-user",          Name = "End-User Support" },
            new() { Id = "security",          Name = "Security Team" }
        ];

        /// <summary>
        /// Gets the assignable identity policies.
        /// </summary>
        public static IReadOnlyList<RestApiPermissionPolicy> Policies { get; } =
        [
            new() { Id = "class_view_policy",  Name = "class_view_policy",  Description = "Grants read access to the class." },
            new() { Id = "class_edit_policy",  Name = "class_edit_policy",  Description = "Grants read and write access to the class." },
            new() { Id = "class_admin_policy", Name = "class_admin_policy", Description = "Grants full administrative control over the class." }
        ];

        /// <summary>
        /// Resolves a group record by id, or <see langword="null"/> when
        /// none matches.
        /// </summary>
        /// <param name="id">The group id.</param>
        /// <returns>The group record, or <see langword="null"/>.</returns>
        public static RestApiPermissionGroup FindGroupById(string id) =>
            Groups.FirstOrDefault(x => string.Equals(x.Id, id, System.StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Resolves a policy record by id, or <see langword="null"/> when
        /// none matches.
        /// </summary>
        /// <param name="id">The policy id.</param>
        /// <returns>The policy record, or <see langword="null"/>.</returns>
        public static RestApiPermissionPolicy FindPolicyById(string id) =>
            Policies.FirstOrDefault(x => string.Equals(x.Id, id, System.StringComparison.OrdinalIgnoreCase));
    }
}
