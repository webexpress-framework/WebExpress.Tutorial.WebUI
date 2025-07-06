using System.IO;
using WebExpress.Toutorial.WebUI.WWW.Controls;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Toutorial.WebUI.WebFragment.ControlPage
{
    /// <summary>
    /// Represents a control panel fragment that displays an overview using Markdown content and the controls.
    /// </summary>
    [Section<SectionContentPreferences>]
    [Scope<Index>]
    [Cache]
    public sealed class ControlOverviewFragment : FragmentControlPanel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ControlOverviewFragment(IFragmentContext fragmentContext)
          : base(fragmentContext)
        {
            using var stream = GetType().Assembly.GetManifestResourceStream("WebExpress.Tutorial.WebUI.Assets.md\\control.md");
            using var reader = new StreamReader(stream);

            Add(new ControlText()
            {
                Format = TypeFormatText.Markdown,
                Text = reader.ReadToEnd()
            });
        }
    }
}