using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebCondition;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Renders the login dialog that <see cref="LoginLinkFragment"/> (avatar dropdown
    /// "Login") opens via its <c>ActionModal</c>, so signing in happens on top of the
    /// page the user is on.
    /// </summary>
    /// <remarks>
    /// The dialog is a <see cref="ControlDataModalLogin"/>: the login dialog of WebUI
    /// framing the REST login, which submits the credentials to the <see cref="Session"/>
    /// endpoint - the same endpoint the full-page login of the application uses - and
    /// reloads the page once the session cookie is set. The dialog is rendered with the
    /// page rather than fetched on the click, so it opens without a round trip.
    /// </remarks>
    [Section<SectionBodySecondary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Condition<ConditionLogout>]
    [Cache]
    public sealed class LoginModalFragment : ControlDataModalLogin, IFragmentControl<ControlDataModalLogin>
    {
        /// <summary>
        /// Gets the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; }

        /// <summary>
        /// Initializes a new instance of the class with the well-known
        /// <c>modal-login</c> id, so the avatar Login link can target it.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LoginModalFragment(IFragmentContext fragmentContext)
            : base("modal-login")
        {
            FragmentContext = fragmentContext;
            Header = _ => "webexpress.webapp:login.label";

            this.DataService<Session>();
        }

        /// <summary>
        /// Convert the fragment to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the fragment is rendered.</param>
        /// <param name="visualTree">The visual tree used for rendering the fragment.</param>
        /// <returns>An HTML node representing the rendered fragment, or null when conditions are not met.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            if (!FragmentContext.Conditions.Check(renderContext?.Request))
            {
                return null;
            }

            return base.Render(renderContext, visualTree);
        }
    }
}
