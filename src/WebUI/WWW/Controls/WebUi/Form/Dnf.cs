using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>
    /// Represents the disjunctive normal form control for the tutorial.
    /// </summary>
    [WebIcon<IconControlDnf>]
    [Title("Dnf")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Dnf : PageControl
    {
        private readonly IEnumerable<ControlFormItemInputSelectionItem> _options =
        [
            new ControlFormItemInputSelectionItem("pirate") { Text = _ => "Pirate", Icon = _ => new IconSkull(), Color = _ => TypeColorSelection.Primary },
            new ControlFormItemInputSelectionItem("governor") { Text = _ => "Governor", Icon = _ => new IconCrown(), Color = _ => TypeColorSelection.Success },
            new ControlFormItemInputSelectionItem("shopkeeper") { Text = _ => "Shopkeeper", Icon = _ => new IconShop(), Color = _ => TypeColorSelection.Info },
            new ControlFormItemInputSelectionItem("ghost") { Text = _ => "Ghost", Icon = _ => new IconGhost(), Color = _ => TypeColorSelection.Warning },
            new ControlFormItemInputSelectionItem("voodoo") { Text = _ => "Voodoo priestess", Icon = _ => new IconHatWizard(), Color = _ => TypeColorSelection.Danger },
            new ControlFormItemInputSelectionItem("swordmaster") { Text = _ => "Sword master", Icon = _ => new IconHandFist() }
        ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Dnf()
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.ADD_EVENT, Event.REMOVE_EVENT);

            Stage.Description = @"A `Dnf` control lets a user build a filter as a **disjunctive normal form** - a disjunction of conjunctions. Everything picked inside one row is combined with `AND`, and the rows are combined with `OR`, so `[[A,B],[C]]` reads as `(A AND B) OR (C)`.

Every boolean filter can be brought into this form, so the control covers the whole space of boolean conditions while asking the user to understand only two operators and never a nesting deeper than two levels. Each row is an ordinary multi-select `Selection` field, so filtering, icons and colors behave exactly as they do elsewhere.

The first row is the expression itself and therefore permanent: its close icon empties it instead of deleting it. Every further row's close icon removes the whole conjunction.

The value is submitted as a single string in which `;` separates the terms of a conjunction and `|` separates the conjunctions - `pirate;ghost|governor`. A one-row expression is therefore byte for byte the value a plain `Selection` submits.";

            Stage.Control = new ControlForm(null, new ControlFormItemInputDnf(null, [.. _options])
            {
                Label = _ => "Show characters that are"
            });

            Stage.Code = @"
            new ControlForm(null, new ControlFormItemInputDnf(null, new ControlFormItemInputSelectionItem(""pirate"") { Text = _ => ""Pirate"" })
            {
                Label = _ => ""Show characters that are""
            });";

            Stage.DarkControls =
            [
                new ControlForm(null, new ControlFormItemInputDnf(null, [.. _options])
                {
                    Label = _ => "Show characters that are"
                })
            ];

            Stage.AddProperty
            (
                "Value",
                "The value of the control is the expression itself. It is written as a single string in which `;` joins the terms of a conjunction and `|` separates the conjunctions, so `pirate;ghost|governor` reads as `(Pirate AND Ghost) OR Governor`. Terms repeated inside one conjunction, blank terms and empty conjunctions carry no meaning and are dropped when the value is read.",
                "Initialize(x => x.Value.Add(\"pirate\", \"ghost\").Add(\"governor\"))",
                new ControlForm(null, new ControlFormItemInputDnf(null, [.. _options])
                    .Initialize(x => x.Value.Add("pirate", "ghost").Add("governor")) as IControlFormItem)
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property sets the text shown in a conjunction that holds no term yet. It informs the user about the expected input and disappears as soon as a term is picked.",
                "Placeholder = _ => \"Pick a trait\"",
                new ControlForm(null, new ControlFormItemInputDnf(null, [.. _options])
                {
                    Placeholder = _ => "Pick a trait"
                })
            );

            Stage.AddProperty
            (
                "MaxGroups",
                "The `MaxGroups` property caps the number of conjunctions the user may add. Once the cap is reached the add button is disabled. Left unset the number is unlimited, which is the default: how many alternatives a filter needs is a property of the data, not of the control.",
                "MaxGroups = _ => 2",
                new ControlForm(null, new ControlFormItemInputDnf(null, [.. _options])
                {
                    MaxGroups = _ => 2
                })
            );

            Stage.AddProperty
            (
                "Disabled",
                "The `Disabled` property renders the expression without any way to change it. The add button is hidden and the rows stop reacting to input, while the expression itself stays readable.",
                "Disabled = _ => true",
                new ControlForm(null, new ControlFormItemInputDnf(null, [.. _options])
                {
                    Disabled = _ => true
                }
                    .Initialize(x => x.Value.Add("pirate", "ghost").Add("governor")) as IControlFormItem)
            );

            Stage.AddItem
            (
                typeof(ControlFormItemInputSelectionItem),
                "ControlFormItemInputSelectionItem",
                "The selectable terms are declared with the same items a `Selection` uses, because a term is a property of the filtered subject rather than of the position it takes in the expression. The same set is therefore offered in every conjunction.",
                "new ControlFormItemInputSelectionItem(\"pirate\") { Text = _ => \"Pirate\", Icon = _ => new IconSkull(), Color = _ => TypeColorSelection.Primary }",
                new ControlForm(null, new ControlFormItemInputDnf
                (
                    null,
                    new ControlFormItemInputSelectionItem("pirate") { Text = _ => "Pirate", Icon = _ => new IconSkull(), Color = _ => TypeColorSelection.Primary },
                    new ControlFormItemInputSelectionItem("ghost") { Text = _ => "Ghost", Icon = _ => new IconGhost(), Color = _ => TypeColorSelection.Warning }
                ))
            );
        }
    }
}
