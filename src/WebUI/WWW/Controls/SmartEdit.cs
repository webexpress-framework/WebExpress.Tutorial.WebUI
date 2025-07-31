using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the smart edit control for the tutorial.  
    /// </summary>  
    [Title("SmartEdit")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class SmartEdit : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        public SmartEdit()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `SmartEdit` is a versatile control for inline editing of values directly within HTML elements. It extends the functionality of conventional display elements with the ability to edit these values comfortably and without changing the editing context. When hovering over a target element with the mouse, a pencil icon appears to the right of the content, serving as an edit button. Clicking the pencil opens an editor form at that exact position, allowing the values to be edited. The input can either be accepted and saved or canceled. The choice of editor is flexible and can be customized, allowing for the use of simple text fields or specialized components like a code editor.";

            Stage.Controls = [
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText().Initialize(x => x.Value = "Hello WebExpress!"))
            ];

            Stage.Code = @"
            new ControlSmartEdit()
            {
            }
                .Add(new ControlFormItemInputText().Initialize(x => x.Value = ""Hello WebExpress!""))";
        }
    }
}
