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
    /// Represents the CheckBox control for the tutorial.    
    /// </summary>    
    [Title("CheckBox")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class CheckBox : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page on which the CheckBox control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public CheckBox(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"A `CheckBox` control is a graphical user interface element that allows users to choose between two states: checked (selected) or unchecked (not selected).";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputCheckBox { Label = "Label", Description = "Checkbox description" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputCheckBox { Label = ""Label"", Description = ""Checkbox description"" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the checkbox field serves as a short description and is displayed in the main area of the control. It ensures a clear and concise presentation of the selection.",
                "Label = \"Subscribe to newsletter\"",
                new ControlForm(null, new ControlFormItemInputCheckBox(null)
                {
                    Label = "Subscribe to newsletter"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the checkbox field.",
                "Help = \"You can unsubscribe anytime from your account settings.\"",
                new ControlForm(null, new ControlFormItemInputCheckBox(null)
                {
                    Help = "You can unsubscribe anytime from your account settings."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the checkbox field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconPaperPlane()",
                new ControlForm(null, new ControlFormItemInputCheckBox(null)
                {
                    Icon = new IconPaperPlane()
                })
            );

            Stage.AddProperty
               (
                   "Description",
                   "The `description` property provides a short, contextual explanation displayed directly to the right of the `CheckBox`. It enhances clarity without increasing vertical space, making it ideal for clean, compact user interfaces.",
                   @"Description = ""Subscribe to newsletter – Receive monthly updates via email""",
                   new ControlForm()
                       .Add(new ControlFormItemInputCheckBox
                       {
                           Label = "Subscribe to newsletter",
                           Icon = new IconPaperPlane(),
                           Description = "Subscribe to newsletter – Receive monthly updates via email",
                           Help = "You can unsubscribe anytime from your account settings.",
                           Layout = TypeLayoutCheckbox.Default
                       })
                       .AddPrimaryButton(new ControlFormItemButtonSubmit())
               );

            Stage.AddProperty
               (
                   "Disabled",
                   "The `disabled` property is used to make a `CheckBox` non interactive and visually grayed out. It signals to users that the option is currently not available.",
                   @"Disabled = true",
                   new ControlForm()
                       .Add(new ControlFormItemInputCheckBox
                       {
                           Label = "Subscribe to newsletter",
                           Icon = new IconPaperPlane(),
                           Description = "Subscribe to newsletter – Receive monthly updates via email",
                           Help = "You can unsubscribe anytime from your account settings.",
                           Layout = TypeLayoutCheckbox.Default,
                           Disabled = true
                       })
                       .AddPrimaryButton(new ControlFormItemButtonSubmit())
               );

            Stage.AddProperty
                (
                    "Layout",
                    "The `layout` property defines how the `ComboBox` is visually presented and how its content is arranged within the user interface. It does not affect the logic or functionality—only the appearance and positioning.",
                    "Layout = TypeLayoutCheckbox.Switch",
                    new ControlForm()
                        .Add(new ControlFormItemInputCheckBox
                        {
                            Label = "Default",
                            Description = "Checkbox description",
                            Layout = TypeLayoutCheckbox.Default
                        })
                        .Add(new ControlFormItemInputCheckBox
                        {
                            Label = "Switch",
                            Description = "Checkbox description",
                            Layout = TypeLayoutCheckbox.Switch
                        })
                        .AddPrimaryButton(new ControlFormItemButtonSubmit())
                );
        }
    }
}
