using WebExpress.WebApp.WebCondition;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebFragment
{
    /// <summary>
    /// Renders the shared <c>modal-form</c> container that <see cref="LoginLinkFragment"/>
    /// (avatar dropdown "Login") targets via its <c>ActionModal</c>.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="ControlModalRemotePage"/> (JS class
    /// <c>wx-webui-modal-page</c>) rather than the form variant: the login
    /// page returns a JS-bootstrapped <c>&lt;div class="wx-webapp-login"&gt;</c>
    /// rather than a <c>&lt;form&gt;</c>, so the form-finding logic of
    /// <c>wx-webui-modal-form</c> would emit <c>modal.form.notfound</c>. The
    /// page controller instead copies the body content 1:1 into the modal,
    /// and the <c>MutationObserver</c> picks up the login div to bootstrap
    /// the actual form on the client.
    /// </remarks>
    [Section<SectionBodySecondary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Scope<IScopeStatusPage>]
    [Condition<ConditionLogout>]
    [Cache]
    public sealed class LoginModalFragment : ControlModalRemotePage, IFragmentControl<ControlModalRemotePage>
    {
        /// <summary>
        /// Gets the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; }

        /// <summary>
        /// Initializes a new instance of the class with the well-known
        /// <c>modal-form</c> id, so the avatar Login link can target it.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LoginModalFragment(IFragmentContext fragmentContext)
            : base("modal-form")
        {
            FragmentContext = fragmentContext;
            Header = _ => "webexpress.webapp:login.label";
            Selector = _ => "#login";
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
