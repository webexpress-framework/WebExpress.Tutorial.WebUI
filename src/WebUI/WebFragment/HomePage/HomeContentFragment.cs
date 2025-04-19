using System.IO;
using WebApp.WWW;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebUI.WebFragment.HomePage
{
    [Section<SectionContentPrimary>]
    [Scope<Index>]
    [Cache]
    public sealed class HomeContentFragment : FragmentControlPanel
    {
        public HomeContentFragment(IFragmentContext fragmentContext)
          : base(fragmentContext)
        {
            using var stream = GetType().Assembly.GetManifestResourceStream("WebUI.Assets.md.home.md");
            using var reader = new StreamReader(stream);

            Add(new ControlText()
            {
                Format = TypeFormatText.Markdown,
                Text = reader.ReadToEnd()
            });
        }
    }
}