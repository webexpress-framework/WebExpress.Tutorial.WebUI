using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table.Templates
{
    /// <summary>
    /// Represents the disjunctive normal form template of a table control for the tutorial.
    /// </summary>
    [WebIcon<IconControlDnf>]
    [Title("Dnf-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Dnf : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Dnf()
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Dnf` template shows a filter column - a disjunctive normal form such as `(A AND B) OR (C)` - inside a table. In ReadOnly mode the expression is rendered as terms joined by the operator words, so both levels stay readable without the reader knowing the notation. In Edit mode the cell hands itself to Smart Edit, which shows exactly that read view until the reader asks to change it.

A cell is far narrower than the expression it may hold, so the read state clips to a single line by default and keeps the full expression in the tooltip. Letting it wrap instead would make the row heights of the table depend on the complexity of one cell.";

            Stage.Controls =
            [
                new ControlTable("myTable")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.DarkControls =
            [
                new ControlTableReorderable("myTableDark")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.Code = @"
                new ControlTable(""myTable"")
                    .AddColumns(...)
                    .AddRows(...)";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode. In ReadOnly mode the expression is a static, compact rendering; in Edit mode the cell becomes a Smart Edit whose editor is the full `Dnf` control, so a filter can be reworked without leaving the table.",
                "Editable = _ => true",
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the text shown in a conjunction that holds no term yet, guiding the user towards the expected input.",
                "Placeholder = _ => \"Pick a trait\"",
                new ControlTable().AddColumns(CreateColumns(true, "Pick a trait")).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "MaxGroups",
                "The `MaxGroups` property caps the number of conjunctions a cell may hold. Once the cap is reached the add button is disabled. Left unset the number is unlimited.",
                "MaxGroups = _ => 2",
                new ControlTable().AddColumns(CreateColumns(true, null, 2)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Compact",
                "The `Compact` property controls how the read state deals with an expression wider than its cell. Enabled - the default - the expression is clipped to a single line and stays reachable through the tooltip. Disabled it wraps, which shows the whole filter at the price of a taller row.",
                "Compact = _ => false",
                new ControlText() { Text = _ => "true", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = _ => "false", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(false, null, -1, false)).AddRows(CreateRows())
            );
        }

        /// <summary>
        /// Creates the columns of the demonstration table.
        /// </summary>
        /// <param name="editable">
        /// A value indicating whether the column can be edited in place.
        /// </param>
        /// <param name="placeholder">The placeholder of an empty conjunction.</param>
        /// <param name="maxGroups">
        /// The maximum number of conjunctions, or a value of zero or less for an
        /// unlimited number.
        /// </param>
        /// <param name="compact">
        /// A value indicating whether the read state clips the expression to one line.
        /// </param>
        /// <returns>The configured columns.</returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, string placeholder = null, int maxGroups = -1, bool compact = true)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateDnf()
            {
                Editable = _ => editable,
                Placeholder = _ => placeholder,
                MaxGroups = _ => maxGroups,
                Compact = _ => compact
            }
                .Add(new ControlFormItemInputSelectionItem("pirate") { Text = _ => "Pirate", Color = _ => TypeColorSelection.Primary })
                .Add(new ControlFormItemInputSelectionItem("governor") { Text = _ => "Governor", Color = _ => TypeColorSelection.Success })
                .Add(new ControlFormItemInputSelectionItem("ghost") { Text = _ => "Ghost", Color = _ => TypeColorSelection.Warning })
                .Add(new ControlFormItemInputSelectionItem("voodoo") { Text = _ => "Voodoo priestess", Color = _ => TypeColorSelection.Danger }))
            {
                Title = _ => "Applies to",
                Icon = _ => new IconFilter()
            };
        }

        /// <summary>
        /// Generates the rows of the demonstration table, each holding an expression
        /// of a different shape.
        /// </summary>
        /// <returns>The generated rows.</returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            // (Pirate AND Ghost) OR Governor
            yield return new ControlTableRow("myRow1")
                .Add(new ControlTableCell() { Text = _ => "pirate;ghost|governor" });

            // a single conjunction, which is the value a plain selection submits
            yield return new ControlTableRow("myRow2")
                .Add(new ControlTableCell() { Text = _ => "governor;voodoo" });

            // a single term
            yield return new ControlTableRow("myRow3")
                .Add(new ControlTableCell() { Text = _ => "voodoo" });
        }
    }
}
