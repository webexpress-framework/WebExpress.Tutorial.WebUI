using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the text box control for the tutorial.    
    /// </summary>    
    [Title("TextBox")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class TextBox : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the text box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public TextBox(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"The `TextBox` control allows for an intuitive and dynamic input of text options. Users can easily type or edit text, creating a fluid and visually engaging interaction.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputTextBox() { Format = TypeEditTextFormat.Wysiwyg })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"  
               new ControlForm()
                .Add(new ControlFormItemInputTextBox() { Format = TypeEditTextFormat.Wysiwyg })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the text box input. It provides a clear label for the expected input and supports internationalization, allowing it to be used as an internationalization string.",
                "Placeholder = \"Enter text here\"",
                new ControlForm(items: new ControlFormItemInputTextBox()
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
                    .Add(new ControlFormItemInputTextBox()
                    {
                        MinLength = 5,
                    }.Initialize(x => x.Value = "01234"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "MaxLength",
                "The `MaxLength` property defines the maximum number of characters allowed in the text box. It ensures input validation and prevents excessive input.",
                "MaxLength = 100",
                new ControlForm()
                    .Add(new ControlFormItemInputTextBox()
                    {
                        MaxLength = 10,
                    }.Initialize(x => x.Value = "0123456789"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Pattern",
                "Defines a regular expression to validate input.",
                "Pattern = \"[A-Za-z]{4}\"",
                new ControlForm()
                    .Add(new ControlFormItemInputTextBox("pattern")
                    {
                        Pattern = "[A-Za-z]{4}"
                    }.Initialize(x => x.Value = "Hello"))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of a `TextBox` control item serves as a short form of the input text and is displayed in the main area of the control. It ensures a concise and clear representation of the input.",
                "Label = \"Label 1\"",
                new ControlForm(items: new ControlFormItemInputTextBox() { Label = "Label 1" })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a text box. It provides a visual representation and identification of the input field, enhancing user guidance and recognition.",
                "Icon = new IconHome()",
                new ControlForm(items: new ControlFormItemInputTextBox() { Icon = new IconHome() })
            );

            Stage.AddProperty
            (
               "Help",
               "The `Help` property provides additional guidance or information for the text box. It enhances user understanding by offering context or instructions.",
               "Help = \"This is a help text.\"",
               new ControlForm(items: new ControlFormItemInputTextBox() { Help = "This is a help text." })
            );

            Stage.AddProperty
            (
               "Format",
               "The `Format` property controls the behavior of the `TextBox`, allowing it to be converted into a multi-line input box. When this property is configured, the TextBox supports line breaks and expands dynamically to accommodate longer text entries.",
               "Format = TypeEditTextFormat.Wysiwyg",
               new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
               new ControlForm(items: new ControlFormItemInputTextBox() { Format = TypeEditTextFormat.Default }),
               new ControlText() { Text = "Multiline", TextColor = new PropertyColorText(TypeColorText.Info) },
               new ControlForm(items: new ControlFormItemInputTextBox() { Format = TypeEditTextFormat.Multiline }),
               new ControlText() { Text = "Wysiwyg", TextColor = new PropertyColorText(TypeColorText.Info) },
               new ControlForm(items: new ControlFormItemInputTextBox() { Format = TypeEditTextFormat.Wysiwyg })
            );
        }
    }
}
