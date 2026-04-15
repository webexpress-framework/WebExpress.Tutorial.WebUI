using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebIdentity;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a concrete implementation of the RestApiLogin for testing purposes.
    /// Validates against hardcoded credentials and generates dummy session tokens.
    /// </summary>
    [Cache]
    public sealed class Session : RestApiSession
    {
        /// <summary>
        /// Validates the provided credentials against a hardcoded test account.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>The authenticated identity if valid; otherwise, null.</returns>
        protected override IIdentity ValidateCredentials(string username, string password)
        {
            // check against hardcoded test credentials
            //if (username == "admin" && password == "password")
            {
                // return a dummy identity for the authenticated user
                return ViewModel.MonkeyIslandCharacters.FirstOrDefault();
            }

            // return null to indicate failed authentication
            //return null;
        }

        /// <summary>
        /// Generates a dummy authentication token for the test session.
        /// </summary>
        /// <param name="identity">The authenticated identity.</param>
        /// <param name="request">The original request.</param>
        /// <returns>A randomly generated token string.</returns>
        protected override string GenerateSession(IIdentity identity, IRequest request)
        {
            return WebEx.ComponentHub.IdentityManager.Login(identity, request)?
                .Id.ToString();
        }

        /// <summary>
        /// Invalidates the authentication token or session for the given request.
        /// </summary>
        /// <param name="request">The original request.</param>
        protected override void InvalidateSession(IRequest request)
        {
            WebEx.ComponentHub.IdentityManager.Logout(request);
        }
    }
}