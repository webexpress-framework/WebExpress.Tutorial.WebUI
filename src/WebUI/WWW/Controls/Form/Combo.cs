using System.Collections.Generic;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls.Form
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
            new ControlFormItemInputComboItem { Value = "1", Text = "Option 1" },
            new ControlFormItemInputComboItem { Value = "2", Text = "Option 2" },
            new ControlFormItemInputComboItem { Value = "3", Text = "Option 3" },
            new ControlFormItemInputComboItem { Value = "4", Text = "Option 4" },
            new ControlFormItemInputComboItem { Value = "5", Text = "Option 5" },
            new ControlFormItemInputComboItem { Value = "6", Text = "Option 6" },
            new ControlFormItemInputComboItem { Value = "7", Text = "Option 7" },
            new ControlFormItemInputComboItem { Value = "8", Text = "Option 8" },
            new ControlFormItemInputComboItem { Value = "9", Text = "Option 9" },
            new ControlFormItemInputComboItem { Value = "10", Text = "Option 10" }
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
                new ControlForm(items: new ControlFormItemInputCombo(items: [.. _options])
                {
                    Placeholder = "Select an option",
                })
            );
        }
    }
}
