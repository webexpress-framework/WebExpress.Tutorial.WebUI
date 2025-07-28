using System.IO;
using WebExpress.Tutorial.WebUI.WWW;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment.HomePage
{
    /// <summary>
    /// Represents a control panel fragment that displays an overview of control-related information.
    /// </summary>
    /// <remarks>This fragment is initialized with content loaded from an embedded Markdown resource file. It
    /// is designed to be used within the context of a fragment-based UI framework.</remarks>
    [Section<SectionContentPrimary>]
    [Scope<Index>]
    [Cache]
    public sealed class ControlOverviewFragment : FragmentControlPanel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlOverviewFragment"/> class,  which displays an overview
        /// of controls using content loaded from an embedded Markdown resource.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is created.</param>
        public ControlOverviewFragment(IFragmentContext fragmentContext)
          : base(fragmentContext)
        {
            using var stream = GetType().Assembly.GetManifestResourceStream("WebExpress.Tutorial.WebUI.Assets.md\\home.md");
            using var reader = new StreamReader(stream);

            Add(new ControlText()
            {
                Format = TypeFormatText.Markdown,
                Text = reader.ReadToEnd()
            });
        }
    }
}