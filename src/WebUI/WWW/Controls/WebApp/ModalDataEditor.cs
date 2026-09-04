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
    /// Represents the document editor dialog demo for the tutorial.
    /// </summary>
    /// <remarks>
    /// The demo is driven by two endpoints of the tutorial API, because the control's whole point
    /// is that they are two: <see cref="MonkeyIslandDocument"/> holds the published document and
    /// publishes on <c>PUT</c>, while <see cref="MonkeyIslandDocumentDraft"/> holds the
    /// unpublished text the editor writes into while it is being typed. Every sample on the page
    /// shares them, so publishing in one and reopening another shows the same document.
    /// </remarks>
    [WebIcon<IconFileLines>]
    [Title("ModalDataEditor")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class ModalDataEditor : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the control is used.</param>
        public ModalDataEditor(IPageContext pageContext)
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"The `ModalDataEditor` is a fullscreen dialog for writing one document — a title and a rich-text body — that separates the two things a single save button normally has to pretend are one: *do not lose what I have written* and *let the readers see this*.

Every change is written into an unpublished draft within a second of the typing stopping, and the submit button publishes. A form that only saves on submit loses an afternoon to a closed tab; a form that saves continuously publishes every unfinished sentence to whoever is reading the page. Neither is acceptable for a document, and both are fine for an issue — which is why this is a control of its own and not a mode of `DataFormEdit`.

That takes two endpoints. The **record** service loads what the editor opens on and its `PUT` *is* the publication, which ends the draft inside its own transaction; the **draft** service stores, answers and drops the unpublished text. The control never deletes a draft as part of publishing: a delete racing a publish that failed would destroy the only copy.

This sample is shared: open the page in a second browser session, press the button there too, and the two see each other — presence on the footer bar, the other pointer over the text, their caret in the field they are writing in, and every stored draft picked up by the other side.

The control is the dialog rather than a form somebody else opens as one, because a writing surface is only right at that size: the title is an editable field on the dialog's own title bar, the body fills its content with no scrollbar of its own, and the footer bar reads *state · presence · ⋯ · publish · close*. It renders closed and is opened by a trigger addressing its id.

Type into the body and watch the footer; then close the dialog without publishing and open it again — the draft is resumed, while the record's published text is unchanged until publish is pressed.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = _ => "Write the document",
                    Icon = _ => new IconPenToSquare(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("editor")
                },
                Create("editor", control =>
                {
                    // the page's own sample is shared, so opening it in two browsers is all it
                    // takes to see the presence, the pointers, the carets and the text arrive
                    control.Collaborative = _ => true;
                    control.CollaborationId = _ => "tutorial-document";
                })
            ];

            Stage.Code = @"
            new ControlButton()
            {
                Text = _ => ""Write the document"",
                Icon = _ => new IconPenToSquare(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                PrimaryAction = _ => new ActionModal(""editor"")
            },
            new ModalDataEditor(""editor"")
            {
                Title = { Name = _ => ""Title"", Placeholder = _ => ""Name of the document"" },
                Body = { Name = _ => ""Body"", Placeholder = _ => ""Write..."" }
            }
                .DataService<MonkeyIslandDocument>()
                .DraftService<MonkeyIslandDocumentDraft>();";

            Stage.AddProperty
            (
                "DraftService",
                "Declares the endpoint the unpublished text is written to. It is what turns the submit from a save into a publication: the footer gains the save indicator and the overflow menu, and every change goes to this endpoint while the author types. The payload is the same shape the publish sends, so the endpoint reads one contract and not two.",
                "DraftService<MonkeyIslandDocumentDraft>()",
                [.. Sample("editor-draft", "With a draft", control => control.Debounce = _ => 400)]
            );

            Stage.AddProperty
            (
                "Draft",
                "Decides whether the surface drafts at all. Turned off it saves once, on submit, and the button reads save beside the dialog's close — the honest reading for a document nobody may hold an unpublished version of. It is a resolver rather than a fixed value because whether a draft may exist is often a question about the request, and it is kept apart from the endpoint declaration so that turning drafting off does not mean withdrawing the endpoint.",
                "Draft = _ => false",
                [.. Sample("editor-nodraft", "Without a draft", control => control.Draft = _ => false)]
            );

            Stage.AddProperty
            (
                "Collaborative",
                "Shares the writing surface, so two authors in the same document see each other's presence, pointers, carets and text. The presence chips are docked onto the footer bar rather than left floating over the first line of what is being written. The collaboration id is the routing channel: only clients rendering the same id see each other, so open this page in two browser sessions to try it.",
                "Collaborative = _ => true, CollaborationId = _ => \"tutorial-document\"",
                [.. Sample("editor-collaborative", "Shared with others", control =>
                {
                    control.Collaborative = _ => true;
                    control.CollaborationId = _ => "tutorial-document";
                })]
            );

            Stage.AddProperty
            (
                "MoreItems",
                "Adds entries to the overflow menu beside the discard the control owns — a view of what publishing would change, for example. Both sit in a menu rather than on the bar because both are rare next to publishing and one of them is destructive: an author reaching for the publish button must not be able to discard their afternoon by being slightly off. The menu shows nothing while no draft exists, because there is then nothing to act on.",
                "MoreItems.Add(new ControlDropdownItemLink(\"changes\") { Text = _ => \"Show changes\" })",
                [.. Sample("editor-more", "With a host entry", control => control.MoreItems.Add
                (
                    new ControlDropdownItemLink("editor-more-changes")
                    {
                        Text = _ => "Show changes",
                        Icon = _ => new IconCodeCompare()
                    }
                ))]
            );

            Stage.AddProperty
            (
                "Show",
                "Opens the dialog with the page instead of waiting for a trigger. A page that is itself the editor has no reading view to be opened from; everywhere else the dialog stays closed until something addresses its id, which is why the samples above come with an activator button.",
                "Show = _ => true",
                new ControlText()
                {
                    Text = _ => "Not shown here: a dialog that opens with the page would cover this one.",
                    Format = _ => TypeFormatText.Italic
                }
            );
        }

        /// <summary>
        /// Builds one sample: the activator and the dialog it opens.
        /// </summary>
        /// <remarks>
        /// The dialog renders closed, so a sample is only reachable through a trigger addressing
        /// its id - which is also the shortest demonstration of how the control is authored.
        /// </remarks>
        /// <param name="id">The dialog id, which is what the activator addresses.</param>
        /// <param name="label">The activator's label.</param>
        /// <param name="configure">The adjustment the sample demonstrates.</param>
        /// <returns>The activator and the dialog.</returns>
        private static IEnumerable<IControl> Sample(string id, string label, System.Action<WebExpress.WebApp.WebControl.ModalDataEditor> configure)
        {
            yield return new ControlButton()
            {
                Text = _ => label,
                Icon = _ => new IconPenToSquare(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                PrimaryAction = _ => new ActionModal(id)
            };

            yield return Create(id, configure);
        }

        /// <summary>
        /// Builds a document editor bound to the two endpoints of the tutorial API.
        /// </summary>
        /// <param name="id">The dialog id.</param>
        /// <param name="configure">An optional adjustment.</param>
        /// <returns>The configured control.</returns>
        private static WebExpress.WebApp.WebControl.ModalDataEditor Create(string id, System.Action<WebExpress.WebApp.WebControl.ModalDataEditor> configure = null)
        {
            var control = new WebExpress.WebApp.WebControl.ModalDataEditor(id)
            {
                Title = { Name = _ => "Title", Placeholder = _ => "Name of the document" },
                Body = { Name = _ => "Body", Placeholder = _ => "Write..." }
            }
                .DataService<MonkeyIslandDocument>()
                .DraftService<MonkeyIslandDocumentDraft>();

            configure?.Invoke(control);

            return control;
        }
    }
}
