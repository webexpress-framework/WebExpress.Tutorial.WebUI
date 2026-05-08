using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
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
                    Value = _ => "Hallo;WebExpress"
                }
            ];

            Stage.Code = @"
            new ControlTag()  
            {  
                Value = _ => ""Hallo;WebExpress""
            };";

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the visual color applied to all tags within the `Tag` control. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "Color = _ => new PropertyColorTag(TypeColorTag.Warning)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Default", Color = _ => new PropertyColorTag(TypeColorTag.Default) },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Primary", Color = _ => new PropertyColorTag(TypeColorTag.Primary) },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Secondary", Color = _ => new PropertyColorTag(TypeColorTag.Secondary) },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Info", Color = _ => new PropertyColorTag(TypeColorTag.Info) },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Success", Color = _ => new PropertyColorTag(TypeColorTag.Success) },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Warning", Color = _ => new PropertyColorTag(TypeColorTag.Warning) },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Danger", Color = _ => new PropertyColorTag(TypeColorTag.Danger) },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Light", Color = _ => new PropertyColorTag(TypeColorTag.Light) },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Dark", Color = _ => new PropertyColorTag(TypeColorTag.Dark) },
                new ControlText() { Text = _ => "Highlight", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "Highlight", Color = _ => new PropertyColorTag(TypeColorTag.Highlight) },
                new ControlText() { Text = _ => "User defind", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTag() { Value = _ => "gold", Color = _ => new PropertyColorTag("gold") }
            );
        }
    }
}
