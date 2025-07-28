using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the line control for the tutorial.    
    /// </summary>    
    [Title("Line")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Line : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the line control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Line(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `Line` serves as a simple yet effective element for creating visual separation within a user interface. Typically represented as a horizontal line, it helps organize content and enhance readability by clearly delineating sections or groups of information.";

            Stage.Control = new ControlLine()
            {
            };

            Stage.Code = @"
            new ControlLine()
            {
            };";

            Stage.AddProperty
            (
                "Color",
                "Sets the color.",
                "Color = new PropertyColorLine(TypeColorLine.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Default)
                },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Primary)
                },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Secondary)
                },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Info)
                },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Success)
                },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Warning)
                },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Danger)
                },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Dark)
                },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine(TypeColorLine.Light)
                },
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlLine()
                {
                    Color = new PropertyColorLine("gold")
                }
            );
        }
    }
}
