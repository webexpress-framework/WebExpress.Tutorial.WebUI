using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the read only selection control for the tutorial.  
    /// </summary>  
    [Title("Selection")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Selection : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        public Selection(IPageContext pageContext)
        {
            Stage.Description = @"The `Selection` is a read-only component used to visually represent values chosen from a predefined set. It is ideal for highlighting categories, statuses, or labels in a consistent and structured way.
";

            Stage.Controls = [
                new ControlSelection()
                {
                    Value = "1;2"
                }
                    .Add
                    (
                        new ControlFormItemInputSelectionItem("1")
                        {
                            Text = "Hallo"
                        },
                        new ControlFormItemInputSelectionItem("2")
                        {
                            Text = "WebExpress"
                        }
                    )
            ];

            Stage.Code = @"
            new ControlSelection()
                {
                    Value = ""1;2""
                }
                    .Add
                    (
                        new ControlFormItemInputSelectionItem(""1"")
                        {
                            Text = ""Hallo""
                        },
                        new ControlFormItemInputSelectionItem(""2"")
                        {    
                            Text = ""WebExpress"" 
                        }
                    );";

            Stage.AddItem
            (
                typeof(ControlFormItemInputSelectionItem),
                "ControlFormItemInputSelectionItem",
                "A `ControlFormItemInputSelectionItem` represents a single option within a selection input control. Each item defines the label, value, and visual presentation of a selectable choice, allowing users to pick from a predefined set of options. Selection items can highlight the currently chosen value, support custom styling, and carry additional metadata when needed. By encapsulating each option as an independent item, `ControlFormItemInputSelectionItem` ensures clear structure, consistent rendering, and intuitive interaction within selection-based form components.",
                "new ControlFormItemInputSelectionItem(\"Default\") { Text = \"Default\" }",
                new ControlSelection()
                {
                    Value = "Default"
                }
                    .Add(new ControlFormItemInputSelectionItem("Default")
                    {
                        Text = "Default"
                    })
            );

            Stage.AddItemProperty
            (
                typeof(ControlFormItemInputSelectionItem),
                "LabelColor",
                "The `LabelColor` property defines the visual color applied to the item within the control. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "LabelColor = TypeColorSelection.Secondary",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Default" }.Add(new ControlFormItemInputSelectionItem("Default") { Text = "Default" }),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Primary" }.Add(new ControlFormItemInputSelectionItem("Primary") { Text = "Primary", Color = TypeColorSelection.Primary }),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Secondary" }.Add(new ControlFormItemInputSelectionItem("Secondary") { Text = "Secondary", Color = TypeColorSelection.Secondary }),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Info" }.Add(new ControlFormItemInputSelectionItem("Info") { Text = "Info", Color = TypeColorSelection.Info }),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Success" }.Add(new ControlFormItemInputSelectionItem("Success") { Text = "Success", Color = TypeColorSelection.Success }),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Warning" }.Add(new ControlFormItemInputSelectionItem("Warning") { Text = "Warning", Color = TypeColorSelection.Warning }),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Danger" }.Add(new ControlFormItemInputSelectionItem("Danger") { Text = "Danger", Color = TypeColorSelection.Danger }),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Light" }.Add(new ControlFormItemInputSelectionItem("Light") { Text = "Light", Color = TypeColorSelection.Light }),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = "Dark" }.Add(new ControlFormItemInputSelectionItem("Dark") { Text = "Dark", Color = TypeColorSelection.Dark })
            );
        }
    }
}
