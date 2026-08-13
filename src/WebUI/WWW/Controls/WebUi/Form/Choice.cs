using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the segmented choice control for the tutorial.
    /// </summary>
    [Title("Choice")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Choice : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page on which the choice control is used.</param>
        /// <param name="componentHub">The component hub for managing components.</param>
        public Choice(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"A `Choice` control offers a small, fixed set of mutually exclusive options as a row of buttons instead of folding them into a drop-down. It suits a field whose options are few and worth reading at a glance — a priority, a severity, a size — where a drop-down would hide exactly the information the user is comparing. The selected value is stored in a hidden input, so the control submits like any other form field. Clicking the selected option again clears the selection.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputChoice()
                {
                    Name = _ => "Size",
                    Label = _ => "Size"
                }
                    .Add
                    (
                        new ControlFormItemInputChoiceItem() { Text = _ => "S", Value = _ => "small" },
                        new ControlFormItemInputChoiceItem() { Text = _ => "M", Value = _ => "medium" },
                        new ControlFormItemInputChoiceItem() { Text = _ => "L", Value = _ => "large" }
                    ))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
                    new ControlForm()
                        .Add(new ControlFormItemInputChoice()
                        {
                            Name = _ => ""Size"",
                            Label = _ => ""Size""
                        }
                            .Add
                            (
                                new ControlFormItemInputChoiceItem() { Text = _ => ""S"", Value = _ => ""small"" },
                                new ControlFormItemInputChoiceItem() { Text = _ => ""M"", Value = _ => ""medium"" },
                                new ControlFormItemInputChoiceItem() { Text = _ => ""L"", Value = _ => ""large"" }
                            ))
                        .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the choice field serves as a short description and is displayed above the options.",
                "Label = _ => \"Priority\"",
                new ControlForm(null, new ControlFormItemInputChoice(null)
                {
                    Label = _ => "Priority"
                }
                    .Add
                    (
                        new ControlFormItemInputChoiceItem() { Text = _ => "P1", Value = _ => "P1" },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P2", Value = _ => "P2" }
                    ) as ControlFormItemInputChoice)
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the choice field.",
                "Help = _ => \"Pick the severity the ticket is handled with.\"",
                new ControlForm(null, new ControlFormItemInputChoice(null)
                {
                    Label = _ => "Priority",
                    Help = _ => "Pick the severity the ticket is handled with."
                }
                    .Add
                    (
                        new ControlFormItemInputChoiceItem() { Text = _ => "P1", Value = _ => "P1" },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P2", Value = _ => "P2" }
                    ) as ControlFormItemInputChoice)
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property of an option renders an accent dot in front of its label. On an ordered scale this makes the ranking readable without reading the labels — from the most severe entry to the least.",
                "Color = _ => new PropertyColorTile(\"#dc3545\")",
                new ControlForm(null, new ControlFormItemInputChoice(null)
                {
                    Label = _ => "Priority"
                }
                    .Add
                    (
                        new ControlFormItemInputChoiceItem() { Text = _ => "P1", Value = _ => "P1", Color = _ => new PropertyColorTile("#dc3545") },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P2", Value = _ => "P2", Color = _ => new PropertyColorTile("#fd7e14") },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P3", Value = _ => "P3", Color = _ => new PropertyColorTile("#0d6efd") },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P4", Value = _ => "P4", Color = _ => new PropertyColorTile("#6c757d") }
                    ) as ControlFormItemInputChoice)
            );

            Stage.AddProperty
            (
                "Description",
                "The `Description` property of an option is shown as its tooltip. It carries the longer wording that does not fit on a compact button.",
                "Description = _ => \"Critical system outage\"",
                new ControlForm(null, new ControlFormItemInputChoice(null)
                {
                    Label = _ => "Priority"
                }
                    .Add
                    (
                        new ControlFormItemInputChoiceItem() { Text = _ => "P1", Value = _ => "P1", Description = _ => "Critical system outage" },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P2", Value = _ => "P2", Description = _ => "Severe degradation" }
                    ) as ControlFormItemInputChoice)
            );

            Stage.AddProperty
            (
                "Required",
                "The `Required` property enforces a selection. A control that stores its value in a hidden input is barred from native constraint validation, so it declares the requirement to the form controller instead — the form is not submitted while nothing is selected.",
                "Required = _ => true",
                new ControlForm()
                    .Add(new ControlFormItemInputChoice()
                    {
                        Name = _ => "Priority",
                        Label = _ => "Priority",
                        Required = _ => true
                    }
                        .Add
                        (
                            new ControlFormItemInputChoiceItem() { Text = _ => "P1", Value = _ => "P1" },
                            new ControlFormItemInputChoiceItem() { Text = _ => "P2", Value = _ => "P2" }
                        ) as ControlFormItemInputChoice)
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property renders every option non-interactive and visually grayed out. It signals that the field is currently unavailable.",
                "Disabled = _ => true",
                new ControlForm(null, new ControlFormItemInputChoice(null)
                {
                    Label = _ => "Priority",
                    Disabled = _ => true
                }
                    .Add
                    (
                        new ControlFormItemInputChoiceItem() { Text = _ => "P1", Value = _ => "P1" },
                        new ControlFormItemInputChoiceItem() { Text = _ => "P2", Value = _ => "P2" }
                    ) as ControlFormItemInputChoice)
            );

            Stage.AddProperty
            (
                "FilterSource",
                "The `FilterSource` property narrows the visible options to the value of another input. One control can therefore carry the options of every context — the sizes of every product, the priorities of every class — and show only those of the context chosen elsewhere in the form. An option without a `FilterValue` is always offered, and a selection the new filter no longer offers is dropped rather than submitted unseen. In the example the options follow the product selected above them.",
                "FilterSource = _ => \"Product\"",
                new ControlForm()
                    .Add(new ControlFormItemInputCombo()
                    {
                        Name = _ => "Product",
                        Label = _ => "Product",
                        Placeholder = _ => "Select a product"
                    }
                        .Add(new ControlFormItemInputComboItem() { Text = _ => "Shirt", Value = _ => "shirt" })
                        .Add(new ControlFormItemInputComboItem() { Text = _ => "Shoe", Value = _ => "shoe" }) as ControlFormItemInputCombo)
                    .Add(new ControlFormItemInputChoice()
                    {
                        Name = _ => "Size",
                        Label = _ => "Size",
                        FilterSource = _ => "Product"
                    }
                        .Add
                        (
                            new ControlFormItemInputChoiceItem() { Text = _ => "S", Value = _ => "s", FilterValue = _ => "shirt" },
                            new ControlFormItemInputChoiceItem() { Text = _ => "M", Value = _ => "m", FilterValue = _ => "shirt" },
                            new ControlFormItemInputChoiceItem() { Text = _ => "L", Value = _ => "l", FilterValue = _ => "shirt" },
                            new ControlFormItemInputChoiceItem() { Text = _ => "41", Value = _ => "41", FilterValue = _ => "shoe" },
                            new ControlFormItemInputChoiceItem() { Text = _ => "42", Value = _ => "42", FilterValue = _ => "shoe" },
                            new ControlFormItemInputChoiceItem() { Text = _ => "43", Value = _ => "43", FilterValue = _ => "shoe" }
                        ) as ControlFormItemInputChoice)
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
