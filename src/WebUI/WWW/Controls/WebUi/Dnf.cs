using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the read only disjunctive normal form control for the tutorial.
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
            new ControlFormItemInputSelectionItem("voodoo") { Text = _ => "Voodoo priestess", Icon = _ => new IconHatWizard(), Color = _ => TypeColorSelection.Danger }
        ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Dnf()
        {
            Stage.Description = @"The `Dnf` control is the read-only counterpart of the `Dnf` form field. It renders a **disjunctive normal form** - the terms of one conjunction joined by `and`, the conjunctions separated by `or` - so both levels stay readable without the reader knowing the notation.

The operator words are real text rather than decoration, so a copy of the rendered expression carries them and a screen reader announces them.

It takes the same items the form field takes, because a term id only becomes a label through them. An expression whose options are missing therefore still renders its term ids: a filter that renders as nothing would claim the rows are unfiltered, which is the one thing it must never say falsely.";

            Stage.Controls =
            [
                new ControlDnf()
                {
                    Value = _ => new ControlFormInputValueDnf("pirate;ghost|governor")
                }
                    .Add(_options)
            ];

            Stage.Code = @"
            new ControlDnf()
            {
                Value = _ => new ControlFormInputValueDnf(""pirate;ghost|governor"")
            }
                .Add(new ControlFormItemInputSelectionItem(""pirate"") { Text = _ => ""Pirate"" });";

            Stage.DarkControls =
            [
                new ControlDnf()
                {
                    Value = _ => new ControlFormInputValueDnf("pirate;ghost|governor")
                }
                    .Add(_options)
            ];

            Stage.AddProperty
            (
                "Value",
                "The `Value` property carries the expression. It is written as a single string in which `;` joins the terms of a conjunction and `|` separates the conjunctions, so `pirate;ghost|governor` reads as `(Pirate AND Ghost) OR Governor`. A one-conjunction expression is byte for byte the value a plain `Selection` carries.",
                "Value = _ => new ControlFormInputValueDnf(\"pirate;voodoo|ghost|governor\")",
                new ControlDnf()
                {
                    Value = _ => new ControlFormInputValueDnf("pirate;voodoo|ghost|governor")
                }
                    .Add(_options)
            );

            Stage.AddProperty
            (
                "Compact",
                "The `Compact` property clips the expression to a single line and keeps the full text in the tooltip. This is what a table cell uses: letting a long expression wrap would make the height of a row depend on the complexity of one filter.",
                "Compact = _ => true",
                new ControlDnf()
                {
                    Value = _ => new ControlFormInputValueDnf("pirate;ghost;voodoo|governor;shopkeeper|swordmaster"),
                    Compact = _ => true,
                    Width = _ => TypeWidth.TwentyFive
                }
                    .Add(_options)
            );

            Stage.AddProperty
            (
                "EmptyText",
                "The `EmptyText` property names what an empty expression means in its context. Without it an unset filter renders as nothing at all, which reads as a missing value rather than as an absent restriction.",
                "EmptyText = _ => \"No restriction\"",
                new ControlDnf()
                {
                    EmptyText = _ => "No restriction"
                }
                    .Add(_options)
            );

            Stage.AddItem
            (
                typeof(ControlFormItemInputSelectionItem),
                "ControlFormItemInputSelectionItem",
                "The terms are declared with the same items a `Selection` uses, so text, icon and color of a term are identical wherever it appears. A term the options do not cover falls back to its id rather than disappearing from the expression.",
                "new ControlFormItemInputSelectionItem(\"pirate\") { Text = _ => \"Pirate\", Icon = _ => new IconSkull(), Color = _ => TypeColorSelection.Primary }",
                new ControlDnf()
                {
                    Value = _ => new ControlFormInputValueDnf("pirate;ghost")
                }
                    .Add
                    (
                        new ControlFormItemInputSelectionItem("pirate") { Text = _ => "Pirate", Icon = _ => new IconSkull(), Color = _ => TypeColorSelection.Primary },
                        new ControlFormItemInputSelectionItem("ghost") { Text = _ => "Ghost", Icon = _ => new IconGhost(), Color = _ => TypeColorSelection.Warning }
                    )
            );
        }
    }
}
