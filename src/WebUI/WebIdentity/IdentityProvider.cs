using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebCore;
using WebExpress.WebCore.WebIdentity;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebPolicies;

namespace WebExpress.Tutorial.WebUI.WebIdentity
{
    /// <summary>
    /// Supplies the tutorial's explicit development administrator and its example identity directory.
    /// The published demo credentials must never be used by a production application.
    /// </summary>
    public class IdentityProvider : WebApp.WebIdentity.IdentityProvider
    {
        private static readonly IIdentity _administrator = new Identity
        (
            new Guid("0a229b58-c679-4c5c-a8d2-1c7259e2a077"),
            "admin",
            roles: ["Administrators"],
            policyNames: [typeof(SystemAccessPolicy).FullName]
        );

        /// <summary>
        /// Keeps the demonstration administrator visible without granting its policies to editable example characters.
        /// </summary>
        /// <returns>The development administrator followed by the example character identities.</returns>
        public override IEnumerable<IIdentity> GetIdentities()
        {
            return ViewModel.MonkeyIslandCharacters.Cast<IIdentity>().Prepend(_administrator);
        }

        /// <summary>
        /// Preserves the tutorial's example groups independently of the administrator's explicit policy claims.
        /// </summary>
        /// <returns>The example groups used by identity and permission controls.</returns>
        public override IEnumerable<IIdentityGroup> GetGroups()
        {
            return ViewModel.MonkeyIslandGroups;
        }

        /// <summary>
        /// Verifies the documented development credentials before issuing an identity with system access.
        /// </summary>
        /// <param name="username">The submitted name of the tutorial's development account.</param>
        /// <param name="password">The submitted demonstration password, which must match exactly.</param>
        /// <returns>The administrator for the documented credentials, or null for every other combination.</returns>
        public override IIdentity Authenticate(string username, string password)
        {
            return string.Equals(username, "admin", StringComparison.OrdinalIgnoreCase) && password == "password"
                ? _administrator
                : null;
        }

        /// <summary>
        /// Displays a login dialog using the specified request and identity information.
        /// </summary>
        /// <param name="request">
        /// The request containing parameters and context for the login operation. Cannot be null.
        /// </param>
        /// <param name="initiator">
        /// The endpoint that triggered the authentication process. Used to determine the origin and
        /// context of the authentication requirement.
        /// </param>
        /// <param name="identity">
        /// The identity information to be used for authentication. Cannot be null.
        /// </param>
        /// <returns>
        /// An object that represents the response to the login dialog, including authentication results and any
        /// relevant status information.
        /// </returns>
        public override IResponse CreateAuthenticationPrompt(IRequest request, IPageContext initiator, IIdentity identity)
        {
            var sessionUri = WebEx.ComponentHub.SitemapManager.GetUri<Session>(initiator);

            return base.CreateAuthenticationPrompt(request, initiator, identity, sessionUri);
        }
    }
}
