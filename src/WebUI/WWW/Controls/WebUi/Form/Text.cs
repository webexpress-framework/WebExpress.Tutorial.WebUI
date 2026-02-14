using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>    
    /// Represents the text control for the tutorial.    
    /// </summary>    
    [Title("Text")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Text : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the text box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Text(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"The `Text` control allows for an intuitive and dynamic input of text options. Users can easily type or edit text, creating a fluid and visually engaging interaction.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputText() { Format = TypeEditTextFormat.Wysiwyg })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"  
               new ControlForm()
                .Add(new ControlFormItemInputText() { Format = TypeEditTextFormat.Wysiwyg })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the text box input. It provides a clear label for the expected input and supports internationalization, allowing it to be used as an internationalization string.",
                "Placeholder = \"Enter text here\"",
                new ControlForm(items: new ControlFormItemInputText()
                {
                    Placeholder = "Enter text here",
                })
            );

            Stage.AddProperty
            (
                "MinLength",
                "The `MinLength` property defines the minimum number of characters required in the text box. It ensures input validation and enforces a minimum input length.",
                "MinLength = 5",
                new ControlForm()
                    .Add(new ControlFormItemInputText()
                    {
                        MinLength = 5,
                    }.Initialize(x => x.Value.Text = "01234"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "MaxLength",
                "The `MaxLength` property defines the maximum number of characters allowed in the text box. It ensures input validation and prevents excessive input.",
                "MaxLength = 100",
                new ControlForm()
                    .Add(new ControlFormItemInputText()
                    {
                        MaxLength = 10,
                    }.Initialize(x => x.Value.Text = "0123456789"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Pattern",
                "Defines a regular expression to validate input.",
                "Pattern = \"[A-Za-z]{4}\"",
                new ControlForm()
                    .Add(new ControlFormItemInputText("pattern")
                    {
                        Pattern = "[A-Za-z]{4}"
                    }.Initialize(x => x.Value.Text = "Hello"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of a text box control item serves as a short form of the input text and is displayed in the main area of the control. It ensures a concise and clear representation of the input.",
                "Label = \"Label 1\"",
                new ControlForm(items: new ControlFormItemInputText() { Label = "Label 1" })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a text box. It provides a visual representation and identification of the input field, enhancing user guidance and recognition.",
                "Icon = new IconHome()",
                new ControlForm(items: new ControlFormItemInputText() { Icon = new IconHome() })
            );

            Stage.AddProperty
            (
               "Help",
               "The `Help` property provides additional guidance or information for the text box. It enhances user understanding by offering context or instructions.",
               "Help = \"This is a help text.\"",
               new ControlForm(items: new ControlFormItemInputText() { Help = "This is a help text." })
            );

            Stage.AddProperty
            (
               "Format",
               "The `Format` property controls the behavior of the text box, allowing it to be converted into a multi-line input box. When this property is configured, the TextBox supports line breaks and expands dynamically to accommodate longer text entries.",
               "Format = TypeEditTextFormat.Wysiwyg",
               new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
               new ControlForm(items: new ControlFormItemInputText() { Format = TypeEditTextFormat.Default }),
               new ControlText() { Text = "Multiline", TextColor = new PropertyColorText(TypeColorText.Info) },
               new ControlForm(items: new ControlFormItemInputText() { Format = TypeEditTextFormat.Multiline }),
               new ControlText() { Text = "Wysiwyg", TextColor = new PropertyColorText(TypeColorText.Info) },
               new ControlForm(items: new ControlFormItemInputText() { Format = TypeEditTextFormat.Wysiwyg })
            );
        }
    }
}
