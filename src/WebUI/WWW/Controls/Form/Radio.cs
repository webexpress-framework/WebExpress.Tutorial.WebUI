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
    /// Represents the RadioButton control for the tutorial.    
    /// </summary>    
    [Title("Radio")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Radio : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page on which the RadioButton control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Radio(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"A `Radio` control is a graphical user interface element that allows users to select one of several options. Unlike a checkbox, only one option within a group can be selected at a time.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputRadio { Label = "Label", Description = "Radio description" })
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
                    new ControlForm()
                        .Add(new ControlFormItemInputRadio { Label = ""Label"", Description = ""RadioButton description"" })
                        .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the radio button field serves as a short description and is displayed in the main area of the control. It ensures a clear and concise presentation of the selection.",
                "Label = \"Option 1\"",
                new ControlForm(null, new ControlFormItemInputRadio(null)
                {
                    Label = "Option 1"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the radio button field.",
                "Help = \"Select one of the available options.\"",
                new ControlForm(null, new ControlFormItemInputRadio(null)
                {
                    Help = "Select one of the available options."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the radio button field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconPaperPlane()",
                new ControlForm(null, new ControlFormItemInputRadio(null)
                {
                    Icon = new IconPaperPlane()
                })
            );

            Stage.AddProperty
               (
                   "Description",
                   "The `Description` property provides a short, contextual explanation that is displayed directly to the right of the radio button. It increases clarity without increasing the vertical space required.",
                   @"Description = ""Option 1 – Select this option""",
                   new ControlForm()
                       .Add(new ControlFormItemInputRadio
                       {
                           Label = "Option 1",
                           Icon = new IconPaperPlane(),
                           Description = "Option 1 – Select this option",
                           Help = "For more information about the selection, see the help.",
                       })
                       .AddPrimaryButton(new ControlFormItemButtonSubmit())
               );

            Stage.AddProperty
               (
                   "Disabled",
                   "The `Disabled` property is used to make a radio button non-interactive and visually grayed out. It signals to the user that the option is currently unavailable.",
                   @"Disabled = true",
                   new ControlForm()
                       .Add(new ControlFormItemInputRadio
                       {
                           Label = "Option 1",
                           Icon = new IconPaperPlane(),
                           Description = "Option 1 – Select this option",
                           Help = "For more information about the selection, see the help.",
                           Disabled = true
                       })
                       .AddPrimaryButton(new ControlFormItemButtonSubmit())
               );

            Stage.AddProperty
               (
                   "Inline",
                   "The `Inline` property arranges radio button elements horizontally in a single row, rather than stacking them vertically. It's ideal for compact interfaces such as toolbars, input groups, or forms where side-by-side alignment improves clarity and flow.",
                   "Inline = true",
                   new ControlForm()
                       .Add(new ControlFormItemInputRadio
                       {
                           Name = "InlineRadioOptions",
                           Description = "Radio 1",
                           Inline = true
                       }, new ControlFormItemInputRadio
                       {
                           Name = "InlineRadioOptions",
                           Description = "Radio 2",
                           Inline = true
                       })
                       .AddPrimaryButton(new ControlFormItemButtonSubmit())
               );
        }
    }
}
