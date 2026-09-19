using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>
    /// Wraps a sample so every named landmark it renders is named after the section the sample
    /// sits in. A tutorial page shows the same control many times over - light and dark, once per
    /// property - and a reader who jumps between landmarks needs to tell those copies apart,
    /// which a name repeated thirty times cannot do.
    /// </summary>
    public class ControlSampleLandmarks : Control
    {
        private readonly IControl _sample;
        private readonly string _section;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sample">The sample control to render.</param>
        /// <param name="section">The name of the section the sample is shown in.</param>
        public ControlSampleLandmarks(IControl sample, string section)
            : base(null)
        {
            _sample = sample;
            _section = section;
        }

        /// <summary>
        /// Renders the sample and qualifies the names of the landmarks it produced.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered sample.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var node = _sample.Render(renderContext, visualTree);
            Qualify(node);

            return node;
        }

        /// <summary>
        /// Walks the rendered tree and appends the section name to the label of every landmark.
        /// </summary>
        /// <param name="node">The node to start at.</param>
        private void Qualify(IHtmlNode node)
        {
            if (node is HtmlElement element)
            {
                if (IsLandmark(element))
                {
                    var label = element.GetUserAttribute("aria-label");

                    if (!string.IsNullOrWhiteSpace(label))
                    {
                        element.AddUserAttribute("aria-label", label + " (" + _section + ")");
                    }
                }

                foreach (var child in element.Elements)
                {
                    Qualify(child);
                }
            }
            else if (node is HtmlList list)
            {
                foreach (var child in list.Elements)
                {
                    Qualify(child);
                }
            }
        }

        /// <summary>
        /// Tells whether an element is a landmark, by its tag or by its role.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>True for a landmark.</returns>
        private static bool IsLandmark(HtmlElement element)
        {
            return element is HtmlElementSectionNav or HtmlElementSectionMain or HtmlElementSectionAside
                || element.Role is "navigation" or "region" or "toolbar" or "search" or "complementary" or "banner" or "contentinfo" or "form" or "main";
        }
    }
}
