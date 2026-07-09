using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Manages the group-to-policy assignments of the class 'Incident' using
    /// a thread-safe in-memory store. The base class handles filtering and
    /// paging; this endpoint only resolves the ids against the demo
    /// directory and mutates the store.
    /// </summary>
    [Segment("incident-permissions")]
    [IncludeSubPaths(true)]
    [Title("Incident Permissions")]
    public sealed class IncidentPermissions : RestApiPermission
    {
        private static readonly object _syncRoot = new();
        private static readonly List<RestApiPermissionItem> _store =
        [
            new() { GroupId = "it-support",        GroupName = "IT Support",        PolicyId = "class_edit_policy",  PolicyName = "class_edit_policy" },
            new() { GroupId = "it-support",        GroupName = "IT Support",        PolicyId = "class_view_policy",  PolicyName = "class_view_policy" },
            new() { GroupId = "service-desk",      GroupName = "Service Desk",      PolicyId = "class_view_policy",  PolicyName = "class_view_policy" },
            new() { GroupId = "incident-managers", GroupName = "Incident Managers", PolicyId = "class_admin_policy", PolicyName = "class_admin_policy" }
        ];

        /// <summary>
        /// Retrieves all assignments from memory in a thread-safe manner.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>A snapshot of the assignment list.</returns>
        protected override IEnumerable<RestApiPermissionItem> RetrieveAssignments(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _store.Select(Clone)];
            }
        }

        /// <summary>
        /// Resolves the group and the policy against the demo directory and
        /// stores the assignment pair; an already existing pair is returned
        /// unchanged.
        /// </summary>
        /// <param name="groupId">The id of the group to be assigned.</param>
        /// <param name="policyId">The id of the policy the group is assigned to.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The persisted assignment, or <see langword="null"/> when the group or the policy is unknown.</returns>
        protected override RestApiPermissionItem AddAssignment(string groupId, string policyId, IRequest request)
        {
            var group = IncidentPermissionDirectory.FindGroupById(groupId);
            var policy = IncidentPermissionDirectory.FindPolicyById(policyId);
            if (group is null || policy is null)
            {
                return null;
            }

            lock (_syncRoot)
            {
                var existing = _store.FirstOrDefault(x => x.GroupId == group.Id && x.PolicyId == policy.Id);
                if (existing is not null)
                {
                    return Clone(existing);
                }

                var assignment = new RestApiPermissionItem
                {
                    GroupId = group.Id,
                    GroupName = group.Name,
                    PolicyId = policy.Id,
                    PolicyName = policy.Name
                };

                _store.Add(assignment);
                return Clone(assignment);
            }
        }

        /// <summary>
        /// Removes the assignment pair from the store.
        /// </summary>
        /// <param name="groupId">The id of the assigned group.</param>
        /// <param name="policyId">The id of the assigned policy.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>
        /// <see langword="true"/> when the assignment existed and was
        /// removed; otherwise <see langword="false"/>.
        /// </returns>
        protected override bool RemoveAssignment(string groupId, string policyId, IRequest request)
        {
            lock (_syncRoot)
            {
                var existing = _store.FirstOrDefault(x => x.GroupId == groupId && x.PolicyId == policyId);
                if (existing is null)
                {
                    return false;
                }

                _store.Remove(existing);
                return true;
            }
        }

        /// <summary>
        /// Returns a shallow copy of the supplied assignment so mutations on
        /// the response cannot leak back into the in-memory store.
        /// </summary>
        /// <param name="source">The source assignment.</param>
        /// <returns>A copy.</returns>
        private static RestApiPermissionItem Clone(RestApiPermissionItem source) => new()
        {
            GroupId = source.GroupId,
            GroupName = source.GroupName,
            PolicyId = source.PolicyId,
            PolicyName = source.PolicyName
        };
    }
}
