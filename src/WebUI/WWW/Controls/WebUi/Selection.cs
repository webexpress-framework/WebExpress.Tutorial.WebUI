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
                    Value = _ => "1;2"
                }
                    .Add
                    (
                        new ControlFormItemInputSelectionItem("1")
                        {
                            Text = _ => "Hallo"
                        },
                        new ControlFormItemInputSelectionItem("2")
                        {
                            Text = _ => "WebExpress"
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
                    Value = _ => "Default"
                }
                    .Add(new ControlFormItemInputSelectionItem("Default")
                    {
                        Text = _ => "Default"
                    })
            );

            Stage.AddItemProperty
            (
                typeof(ControlFormItemInputSelectionItem),
                "LabelColor",
                "The `LabelColor` property defines the visual color applied to the item within the control. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "LabelColor = TypeColorSelection.Secondary",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Default" }.Add(new ControlFormItemInputSelectionItem("Default") { Text = _ => "Default" }),
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Primary" }.Add(new ControlFormItemInputSelectionItem("Primary") { Text = _ => "Primary", Color = _ => TypeColorSelection.Primary }),
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Secondary" }.Add(new ControlFormItemInputSelectionItem("Secondary") { Text = _ => "Secondary", Color = _ => TypeColorSelection.Secondary }),
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Info" }.Add(new ControlFormItemInputSelectionItem("Info") { Text = _ => "Info", Color = _ => TypeColorSelection.Info }),
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Success" }.Add(new ControlFormItemInputSelectionItem("Success") { Text = _ => "Success", Color = _ => TypeColorSelection.Success }),
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Warning" }.Add(new ControlFormItemInputSelectionItem("Warning") { Text = _ => "Warning", Color = _ => TypeColorSelection.Warning }),
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Danger" }.Add(new ControlFormItemInputSelectionItem("Danger") { Text = _ => "Danger", Color = _ => TypeColorSelection.Danger }),
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Light" }.Add(new ControlFormItemInputSelectionItem("Light") { Text = _ => "Light", Color = _ => TypeColorSelection.Light }),
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlSelection() { Value = _ => "Dark" }.Add(new ControlFormItemInputSelectionItem("Dark") { Text = _ => "Dark", Color = _ => TypeColorSelection.Dark })
            );
        }
    }
}
