using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Form
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
        /// <param name="pageContext">The context of the page where the text box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Tag(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.ADD_EVENT, Event.REMOVE_EVENT);

            Stage.Description = @"The `Tag` control is an interactive user interface component that allows users to display, manage, and select multiple keyword-like items known as ""tags."" It’s ideal for organizing data, filtering content, or entering custom labels.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputTag()
                    .Initialize(x => x.Value.Add("Tag-1;Tag-2;Tag-3")))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputTag()
                    .Initialize(x => x.Value.Add(""Tag-1;Tag-2;Tag-3""))))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the tag box input. It provides a clear label for the expected input and supports internationalization, allowing it to be used as an internationalization string.",
                "Placeholder = \"Enter tag here\"",
                new ControlForm(items: new ControlFormItemInputTag()
                {
                    Placeholder = "Enter tag here",
                })
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the visual color applied to all selected tags within the `Tag` control component. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "Color = new PropertyColorTag(TypeColorTag.Warning)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Default) }.Initialize(x => x.Value.Add("Default"))),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Primary) }.Initialize(x => x.Value.Add("Primary"))),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Secondary) }.Initialize(x => x.Value.Add("Secondary"))),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Info) }.Initialize(x => x.Value.Add("Info"))),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Success) }.Initialize(x => x.Value.Add("Success"))),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Warning) }.Initialize(x => x.Value.Add("Warning"))),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Danger) }.Initialize(x => x.Value.Add("Danger"))),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Light) }.Initialize(x => x.Value.Add("Light"))),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag(TypeColorTag.Dark) }.Initialize(x => x.Value.Add("Dark"))),
                new ControlText() { Text = "User defind", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTag() { Color = new PropertyColorTag("gold") }.Initialize(x => x.Value.Add("User defind")))
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of a tag control item serves as a short form of the input text and is displayed in the main area of the control. It ensures a concise and clear representation of the input.",
                "Label = \"Label 1\"",
                new ControlForm(items: new ControlFormItemInputTag() { Label = "Label 1" })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a tag box. It provides a visual representation and identification of the input field, enhancing user guidance and recognition.",
                "Icon = new IconHome()",
                new ControlForm(items: new ControlFormItemInputTag() { Icon = new IconHome() })
            );

            Stage.AddProperty
            (
               "Help",
               "The `Help` property provides additional guidance or information for the tag box. It enhances user understanding by offering context or instructions.",
               "Help = \"This is a help text.\"",
               new ControlForm(items: new ControlFormItemInputTag() { Help = "This is a help text." })
            );
        }
    }
}
