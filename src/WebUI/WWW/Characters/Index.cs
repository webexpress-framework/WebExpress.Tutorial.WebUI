using WebExpress.Tutorial.WebUI.WebParamter;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;

namespace WebExpress.Tutorial.WebUI.WWW.Characters
{
    /// <summary>
    /// Represents the index page of a character.
    /// </summary>
    [SegmentGuid<CharacterIdParameter>()]
    public sealed class Index : IPage<VisualTreeWebApp>
    {
        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
        }
    }
}
