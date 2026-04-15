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
    /// Represents the password control for the tutorial.    
    /// </summary>    
    [Title("Password")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Password : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the password control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Password(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"The `Password` control provides a secure text input field for entering passwords. It masks the input by default and includes a show/hide toggle, allowing users to verify their input when needed.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputPassword()
                {
                    Label = "Password",
                    Icon = new IconLock(),
                    Help = "Enter your password."
                })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
                new ControlForm()
                    .Add(new ControlFormItemInputPassword()
                    {
                        Label = ""Password"",
                        Icon = new IconLock(),
                        Help = ""Enter your password.""
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the password input. It provides a clear label for the expected input and supports internationalization, allowing it to be used as an internationalization string.",
                "Placeholder = \"Enter your password\"",
                new ControlForm(null, new ControlFormItemInputPassword()
                {
                    Placeholder = "Enter your password",
                })
            );

            Stage.AddProperty
            (
                "MinLength",
                "The `MinLength` property defines the minimum number of characters required in the password field. It ensures input validation and enforces a minimum input length.",
                "MinLength = 8",
                new ControlForm()
                    .Add(new ControlFormItemInputPassword()
                    {
                        Label = "Password",
                        MinLength = 8,
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "MaxLength",
                "The `MaxLength` property defines the maximum number of characters allowed in the password field. It ensures input validation and prevents excessive input.",
                "MaxLength = 64",
                new ControlForm()
                    .Add(new ControlFormItemInputPassword()
                    {
                        Label = "Password",
                        MaxLength = 64,
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Pattern",
                "Defines a regular expression to validate the password input.",
                "Pattern = \"(?=.*[A-Z])(?=.*[0-9]).{8,}\"",
                new ControlForm()
                    .Add(new ControlFormItemInputPassword("pattern")
                    {
                        Label = "Password",
                        Pattern = "(?=.*[A-Z])(?=.*[0-9]).{8,}"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of a password control item serves as a short form of the input and is displayed in the main area of the control. It ensures a concise and clear representation of the input.",
                "Label = \"Password\"",
                new ControlForm(null, new ControlFormItemInputPassword() { Label = "Password" })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a password field. It provides a visual representation and identification of the input field, enhancing user guidance and recognition.",
                "Icon = new IconLock()",
                new ControlForm(null, new ControlFormItemInputPassword() { Icon = new IconLock() })
            );

            Stage.AddProperty
            (
               "Help",
               "The `Help` property provides additional guidance or information for the password field. It enhances user understanding by offering context or instructions.",
               "Help = \"Your password must be at least 8 characters long.\"",
               new ControlForm(null, new ControlFormItemInputPassword() { Help = "Your password must be at least 8 characters long." })
            );

            Stage.AddProperty
            (
               "Disabled",
               "The `Disabled` property is used to make a password field non-interactive and visually grayed out. It signals to users that the option is currently not available.",
               @"Disabled = true",
               new ControlForm()
                   .Add(new ControlFormItemInputPassword()
                   {
                       Label = "Password",
                       Icon = new IconLock(),
                       Help = "This field is currently locked.",
                       Disabled = true
                   })
                   .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
