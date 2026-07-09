using System.Collections.Generic;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides the directory of assignable identity policies for the
    /// incident permission demo. Backs the "policies" service of the
    /// permission control, which fills the policy select of the assign row.
    /// </summary>
    [Segment("incident-permission-policies")]
    [Title("Incident Permission Policies")]
    public sealed class IncidentPermissionPolicies : RestApiPermissionPolicies
    {
        /// <summary>
        /// Returns the assignable identity policies of the demo directory.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The policies.</returns>
        protected override IEnumerable<RestApiPermissionPolicy> RetrievePolicies(IRequest request)
        {
            return IncidentPermissionDirectory.Policies;
        }
    }
}
