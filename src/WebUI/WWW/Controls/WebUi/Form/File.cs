using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>    
    /// Represents the file control for the tutorial.    
    /// </summary>    
    [Title("File")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class File : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the text box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public File(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.ADD_EVENT, Event.REMOVE_EVENT);

            Stage.Description = @"The `File` upload control allows users to select and upload files as part of a form submission. It provides an intuitive interface for choosing one or multiple files and integrates seamlessly into form workflows.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputFile())
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputTag())
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";
        }
    }
}
