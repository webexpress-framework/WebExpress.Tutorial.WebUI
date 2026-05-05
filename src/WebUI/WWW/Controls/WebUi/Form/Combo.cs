using System.Collections.Generic;
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
    /// Represents the combo box control for the tutorial.    
    /// </summary>    
    [Title("Combo")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Combo : PageControl
    {
        private readonly IEnumerable<ControlFormItemInputComboItem> _options =
        [
            new ControlFormItemInputComboItem { Value = _ => "1", Text = _ => "Option 1" },
            new ControlFormItemInputComboItem { Value = _ => "2", Text = _ => "Option 2" },
            new ControlFormItemInputComboItem { Value = _ => "3", Text = _ => "Option 3" },
            new ControlFormItemInputComboItem { Value = _ => "4", Text = _ => "Option 4" },
            new ControlFormItemInputComboItem { Value = _ => "5", Text = _ => "Option 5" },
            new ControlFormItemInputComboItem { Value = _ => "6", Text = _ => "Option 6" },
            new ControlFormItemInputComboItem { Value = _ => "7", Text = _ => "Option 7" },
            new ControlFormItemInputComboItem { Value = _ => "8", Text = _ => "Option 8" },
            new ControlFormItemInputComboItem { Value = _ => "9", Text = _ => "Option 9" },
            new ControlFormItemInputComboItem { Value = _ => "10", Text = _ => "Option 10" }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the combo box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Combo(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"The `Combo` control allows for an intuitive and dynamic selection of options. Users can easily choose from a dropdown list, creating a fluid and visually engaging interaction.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputCombo().Add([.. _options]))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()  
                .Add(new ControlFormItemInputCombo().Add(new ControlFormItemInputComboItem { Value = ""1"", Text = ""Option 1"" }))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the combo box input. It provides a clear label for the expected input and supports internationalization, allowing it to be used as an internationalization string.",
                "Placeholder = \"Select an option\"",
                new ControlForm(null, new ControlFormItemInputCombo(null, [.. _options])
                {
                    Placeholder = _ => "Select an option",
                })
            );
        }
    }
}
