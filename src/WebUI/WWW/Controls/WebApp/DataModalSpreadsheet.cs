using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the workbook dialog demo for the tutorial.
    /// </summary>
    /// <remarks>
    /// The demo is driven by two endpoints of the tutorial API, because the control's whole point
    /// is that they are two: <see cref="SpreadsheetDocument"/> holds the published workbook and
    /// publishes on <c>PUT</c>, while <see cref="SpreadsheetDocumentDraft"/> holds the unpublished
    /// workbook the dialog writes into while it is being worked on. Every sample on the page
    /// shares them, so publishing in one and reopening another shows the same workbook.
    /// </remarks>
    [WebIcon<IconTableCells>]
    [Title("DataModalSpreadsheet")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataModalSpreadsheet : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the control is used.</param>
        public DataModalSpreadsheet(IPageContext pageContext)
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT, Event.SPREADSHEET_CELL_CHANGED_EVENT);

            Stage.Description = @"The `ControlDataModalSpreadsheet` is a fullscreen dialog for working on one workbook — a name and a spreadsheet filling the dialog — that separates the two things a single save button normally has to pretend are one: *do not lose what I have entered* and *let the readers see this*.

It is the workbook kind of the document dialog that `ControlDataModalEditor` is the text kind of: drafting, publishing, discarding, sharing and the footer bar are the same, only the body is a spreadsheet. A budget half updated is worse for its readers than last month's, so every change goes into an unpublished draft within a second of the work stopping, and the submit button publishes.

That takes two endpoints. The **record** service loads the workbook the dialog opens on and its `PUT` *is* the publication, which ends the draft inside its own transaction; the **draft** service stores, answers and drops the unpublished workbook. The workbook travels as its JSON under the field name of the body, so both endpoints read it with `SpreadsheetWorkbook.Parse` — formula cells carry their last result, so a server reads figures without a formula engine.

This sample is shared: open the page in a second browser session, press the button there too, and the two see each other — presence on the footer bar, the other selection in the grid, and every change arriving on the other side.

Change a few cells and watch the footer; then close the dialog without publishing and open it again — the draft is resumed, while the published workbook is unchanged until publish is pressed. The switch at the left end of the bar shows the workbook the way the readers will get it: the same grid, read-only and without toolbar and formula bar.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = _ => "Edit the budget",
                    Icon = _ => new IconTableCells(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("workbook")
                },
                Create("workbook", control =>
                {
                    // the page's own sample is shared, so opening it in two browsers is all it
                    // takes to see the presence, the selections and the changes arrive
                    control.Collaborative = _ => true;
                    control.CollaborationId = _ => "tutorial-workbook";
                })
            ];

            Stage.Code = @"
            new ControlButton()
            {
                Text = _ => ""Edit the budget"",
                Icon = _ => new IconTableCells(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                PrimaryAction = _ => new ActionModal(""workbook"")
            },
            new ControlDataModalSpreadsheet(""workbook"")
            {
                Title = { Name = _ => ""Title"", Placeholder = _ => ""Name of the workbook"" },
                Body = { Name = _ => ""Body"" }
            }
                .DataService<SpreadsheetDocument>()
                .DraftService<SpreadsheetDocumentDraft>();";

            Stage.AddProperty
            (
                "DraftService",
                "Declares the endpoint the unpublished workbook is written to. It is what turns the submit from a save into a publication: the footer gains the save indicator and the overflow menu, and every change goes to this endpoint while the author works. The payload is the same shape the publish sends, so the endpoint reads one contract and not two.",
                "DraftService<SpreadsheetDocumentDraft>()",
                [.. Sample("workbook-draft", "With a draft", control => control.Debounce = _ => 400)]
            );

            Stage.AddProperty
            (
                "Draft",
                "Decides whether the surface drafts at all. Turned off it saves once, on submit, and the button reads save beside the dialog's close — the honest reading for a workbook nobody may hold an unpublished version of.",
                "Draft = _ => false",
                [.. Sample("workbook-nodraft", "Without a draft", control => control.Draft = _ => false)]
            );

            Stage.AddProperty
            (
                "Preview",
                "Offers the reading view on the footer bar: the switch at its left end puts the workbook the way a read-only page shows it — the same grid without toolbar, formula bar and editing — in the place of the surface, and takes it away again. It follows the workbook while it is showing. Turned off, the bar carries no switch.",
                "Preview = _ => false",
                [.. Sample("workbook-nopreview", "Without a preview", control => control.Preview = _ => false)]
            );

            Stage.AddProperty
            (
                "Body",
                "The spreadsheet input the workbook is entered in. Toolbar, formula bar, sheet tabs, size and language are its own settings, so a dialog for a narrow task can take the editing chrome away while the drafting stays.",
                "Body = { Name = _ => \"Body\", Toolbar = _ => false, Locale = _ => \"de\" }",
                [.. Sample("workbook-plain", "Without a toolbar, in German", control =>
                {
                    control.Body.Toolbar = _ => false;
                    control.Body.Locale = _ => "de";
                })]
            );

            Stage.AddProperty
            (
                "Collaborative",
                "Shares the workbook, so two authors see each other's presence, selections and changes. The presence chips are docked onto the footer bar. The collaboration id is the routing channel: only clients rendering the same id see each other, so open this page in two browser sessions to try it.",
                "Collaborative = _ => true, CollaborationId = _ => \"tutorial-workbook\"",
                [.. Sample("workbook-collaborative", "Shared with others", control =>
                {
                    control.Collaborative = _ => true;
                    control.CollaborationId = _ => "tutorial-workbook";
                })]
            );

            Stage.AddProperty
            (
                "MoreItems",
                "Adds entries to the overflow menu beside the discard the control owns. Both sit in a menu rather than on the bar because both are rare next to publishing and one of them is destructive. The menu shows nothing while no draft exists, because there is then nothing to act on.",
                "MoreItems.Add(new ControlDropdownItemLink(\"export\") { Text = _ => \"Export as CSV\" })",
                [.. Sample("workbook-more", "With a host entry", control => control.MoreItems.Add
                (
                    new ControlDropdownItemLink("workbook-more-export")
                    {
                        Text = _ => "Export as CSV",
                        Icon = _ => new IconFileCsv()
                    }
                ))]
            );
        }

        /// <summary>
        /// Builds one sample: the activator and the dialog it opens.
        /// </summary>
        /// <param name="id">The dialog id, which is what the activator addresses.</param>
        /// <param name="label">The activator's label.</param>
        /// <param name="configure">The adjustment the sample demonstrates.</param>
        /// <returns>The activator and the dialog.</returns>
        private static IEnumerable<IControl> Sample(string id, string label, System.Action<ControlDataModalSpreadsheet> configure)
        {
            yield return new ControlButton()
            {
                Text = _ => label,
                Icon = _ => new IconTableCells(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                PrimaryAction = _ => new ActionModal(id)
            };

            yield return Create(id, configure);
        }

        /// <summary>
        /// Builds a workbook dialog bound to the two endpoints of the tutorial API.
        /// </summary>
        /// <param name="id">The dialog id.</param>
        /// <param name="configure">An optional adjustment.</param>
        /// <returns>The configured control.</returns>
        private static ControlDataModalSpreadsheet Create(string id, System.Action<ControlDataModalSpreadsheet> configure = null)
        {
            var control = new ControlDataModalSpreadsheet(id)
            {
                Title = { Name = _ => "Title", Placeholder = _ => "Name of the workbook" },
                Body = { Name = _ => "Body" }
            }
                .DataService<SpreadsheetDocument>()
                .DraftService<SpreadsheetDocumentDraft>();

            configure?.Invoke(control);

            return control;
        }
    }
}
