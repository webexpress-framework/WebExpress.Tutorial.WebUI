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
    [Title("ComboBox")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ComboBox : PageControl
    {
        private readonly IEnumerable<ControlFormItemInputComboBoxItem> _options =
        [
            new ControlFormItemInputComboBoxItem { Value = "1", Text = "Option 1" },
            new ControlFormItemInputComboBoxItem { Value = "2", Text = "Option 2" },
            new ControlFormItemInputComboBoxItem { Value = "3", Text = "Option 3" },
            new ControlFormItemInputComboBoxItem { Value = "4", Text = "Option 4" },
            new ControlFormItemInputComboBoxItem { Value = "5", Text = "Option 5" },
            new ControlFormItemInputComboBoxItem { Value = "6", Text = "Option 6" },
            new ControlFormItemInputComboBoxItem { Value = "7", Text = "Option 7" },
            new ControlFormItemInputComboBoxItem { Value = "8", Text = "Option 8" },
            new ControlFormItemInputComboBoxItem { Value = "9", Text = "Option 9" },
            new ControlFormItemInputComboBoxItem { Value = "10", Text = "Option 10" }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the combo box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public ComboBox(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"The `ComboBox` control allows for an intuitive and dynamic selection of options. Users can easily choose from a dropdown list, creating a fluid and visually engaging interaction.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputComboBox().Add([.. _options]))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()  
                .Add(new ControlFormItemInputComboBox().Add(new ControlFormItemInputComboBoxItem { Value = ""1"", Text = ""Option 1"" }))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the combo box input. It provides a clear label for the expected input and supports internationalization, allowing it to be used as an internationalization string.",
                "Placeholder = \"Select an option\"",
                new ControlForm(items: new ControlFormItemInputComboBox(items: [.. _options])
                {
                    Placeholder = "Select an option",
                })
            );
        }
    }
}
