using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the tag control for the tutorial.  
    /// </summary>  
    [Title("Tag")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Tag : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        public Tag(IPageContext pageContext)
        {
            Stage.Description = @"The `TagControl` is a read-only component used to visually represent values as tags. This makes it ideal for highlighting categories, statuses, or labels in a consistent way.";

            Stage.Controls = [
                new ControlTag()
                {
                    Value = "Hallo;WebExpress"
                }
            ];

            Stage.Code = @"
            new ControlTag()  
            {  
                Value = ""Hallo;WebExpress""
            };";

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the visual color applied to all tags within the `Tag` control. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "Color = new PropertyColorTag(TypeColorTag.Warning)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Default", Color = new PropertyColorTag(TypeColorTag.Default) },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Primary", Color = new PropertyColorTag(TypeColorTag.Primary) },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Secondary", Color = new PropertyColorTag(TypeColorTag.Secondary) },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Info", Color = new PropertyColorTag(TypeColorTag.Info) },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Success", Color = new PropertyColorTag(TypeColorTag.Success) },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Warning", Color = new PropertyColorTag(TypeColorTag.Warning) },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Danger", Color = new PropertyColorTag(TypeColorTag.Danger) },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Light", Color = new PropertyColorTag(TypeColorTag.Light) },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "Dark", Color = new PropertyColorTag(TypeColorTag.Dark) },
                new ControlText() { Text = "User defind", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = "gold", Color = new PropertyColorTag("gold") }
            );
        }
    }
}
