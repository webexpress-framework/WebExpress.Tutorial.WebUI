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
    /// Represents the check control for the tutorial.    
    /// </summary>    
    [Title("Check")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Check : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page on which the check control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Check(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"A `Check` control is a graphical user interface element that allows users to choose between two states: checked (selected) or unchecked (not selected).";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputCheck { Label = "Label", Description = "Check box description" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputCheck { Label = ""Label"", Description = ""Check box description"" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the check box field serves as a short description and is displayed in the main area of the control. It ensures a clear and concise presentation of the check control.",
                "Label = \"Subscribe to newsletter\"",
                new ControlForm(null, new ControlFormItemInputCheck(null)
                {
                    Label = "Subscribe to newsletter"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the check box field.",
                "Help = \"You can unsubscribe anytime from your account settings.\"",
                new ControlForm(null, new ControlFormItemInputCheck(null)
                {
                    Help = "You can unsubscribe anytime from your account settings."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the check box field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconPaperPlane()",
                new ControlForm(null, new ControlFormItemInputCheck(null)
                {
                    Icon = new IconPaperPlane()
                })
            );

            Stage.AddProperty
            (
                "Description",
                "The `description` property provides a short, contextual explanation displayed directly to the right of the check box. It enhances clarity without increasing vertical space, making it ideal for clean, compact user interfaces.",
                @"Description = ""Subscribe to newsletter – Receive monthly updates via email""",
                new ControlForm()
                    .Add(new ControlFormItemInputCheck
                    {
                        Label = "Subscribe to newsletter",
                        Icon = new IconPaperPlane(),
                        Description = "Subscribe to newsletter – Receive monthly updates via email",
                        Help = "You can unsubscribe anytime from your account settings.",
                        Layout = TypeLayoutCheck.Default
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `disabled` property is used to make a check box non interactive and visually grayed out. It signals to users that the option is currently not available.",
                @"Disabled = true",
                new ControlForm()
                    .Add(new ControlFormItemInputCheck
                    {
                        Label = "Subscribe to newsletter",
                        Icon = new IconPaperPlane(),
                        Description = "Subscribe to newsletter – Receive monthly updates via email",
                        Help = "You can unsubscribe anytime from your account settings.",
                        Layout = TypeLayoutCheck.Default,
                        Disabled = true
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Layout",
                "The `layout` property defines how the check box is visually presented and how its content is arranged within the user interface. It does not affect the logic or functionality—only the appearance and positioning.",
                "Layout = TypeLayoutCheck.Switch",
                new ControlForm()
                    .Add(new ControlFormItemInputCheck
                    {
                        Label = "Default",
                        Description = "Checkbox description",
                        Layout = TypeLayoutCheck.Default
                    })
                    .Add(new ControlFormItemInputCheck
                    {
                        Label = "Switch",
                        Description = "Checkbox description",
                        Layout = TypeLayoutCheck.Switch
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Inline",
                "The `Inline` property arranges check box elements horizontally in a single row, rather than stacking them vertically. It's ideal for compact interfaces such as toolbars, input groups, or forms where side-by-side alignment improves clarity and flow.",
                "Layout = TypeLayoutCheck.Switch",
                new ControlForm()
                    .Add(new ControlFormItemInputCheck
                    {
                        Description = "Checkbox 1"
                    })
                    .Add(new ControlFormItemInputCheck
                    {
                        Description = "Checkbox 2"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
