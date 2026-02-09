using WebExpress.WebApp.WebFragment;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents a modal fragment control for editing table forms within
    /// a sectioned and scoped context.
    /// </summary>
    [Section<SectionBodySecondary>]
    [Scope<IScopeControl>]
    [Cache]
    public sealed class ControlModalFragment : FragmentControlModalRemoteForm
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ControlModalFragment(IFragmentContext fragmentContext)
          : base(fragmentContext, "myTableFormEdit")
        {
            Header = "webexpress.tutorial.webui:character.edit.header";
        }
    }
}