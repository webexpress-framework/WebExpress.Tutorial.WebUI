using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// The draft endpoint behind the drafting form editor demo: the unpublished
    /// structure of a form, written after every change and never seen by the forms
    /// in use.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The revision check comes from <see cref="RestApiFormEditorDraft{TIndexItem}"/>:
    /// a save edited on top of another revision is answered with 409, so two
    /// editors drafting the same form - two browser sessions on this page - cannot
    /// overwrite each other's drafts. The check is repeated in
    /// <see cref="StoreDraft"/> under the lock the form endpoint shares, because two
    /// saves may pass the check of the base class at the same moment.
    /// </para>
    /// <para>
    /// Note what is <i>not</i> here: nothing publishes. Ending a draft is the job of
    /// <see cref="FormEditor"/>, inside the transaction that applies the structure.
    /// </para>
    /// </remarks>
    [Title("Form structure draft")]
    public sealed class FormEditorDraft : RestApiFormEditorDraft<Game>
    {
        private static readonly Dictionary<string, RestApiFormEditorDraftItem> _drafts = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FormEditorDraft()
        {
        }

        /// <summary>
        /// Returns the unpublished draft of a form, or <see langword="null"/> when
        /// there is none. Read by the form endpoint, which answers the draft's
        /// structure where one exists.
        /// </summary>
        /// <param name="formId">The id of the form.</param>
        /// <returns>The draft or <see langword="null"/>.</returns>
        internal static RestApiFormEditorDraftItem Current(string formId)
        {
            lock (FormEditor.SyncRoot)
            {
                return _drafts.TryGetValue(formId, out var draft) ? draft : null;
            }
        }

        /// <summary>
        /// Ends the draft of a form. Called by the form endpoint as part of
        /// publishing, which is the only place a draft may be dropped other than an
        /// explicit discard.
        /// </summary>
        /// <param name="formId">The id of the form.</param>
        internal static void Clear(string formId)
        {
            lock (FormEditor.SyncRoot)
            {
                _drafts.Remove(formId);
            }
        }

        /// <summary>
        /// Retrieves the unpublished draft of the form.
        /// </summary>
        /// <param name="formId">The id of the form.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The current request.</param>
        /// <returns>The draft, or <see langword="null"/> when the form has none.</returns>
        protected override RestApiFormEditorDraftItem RetrieveDraft(string formId, IQueryContext context, IRequest request)
        {
            return Current(formId);
        }

        /// <summary>
        /// Stores the structure as the unpublished draft and moves the revision on,
        /// unless another save landed since the check of the base class.
        /// </summary>
        /// <param name="formId">The id of the form.</param>
        /// <param name="item">The drafted structure, carrying the revision it was edited on top of.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The current request.</param>
        /// <returns>The stored draft, or <see langword="null"/> to refuse a stale save.</returns>
        protected override RestApiFormEditorDraftItem StoreDraft(string formId, RestApiFormEditorItem item, IQueryContext context, IRequest request)
        {
            lock (FormEditor.SyncRoot)
            {
                var revision = _drafts.TryGetValue(formId, out var stored) ? stored.Revision : 0;

                if (item.DraftRevision != revision)
                {
                    return null;
                }

                // the revision is the draft's, not part of the structure the form
                // endpoint answers from it
                item.DraftRevision = 0;

                var draft = new RestApiFormEditorDraftItem
                {
                    Structure = item,
                    Updated = DateTime.UtcNow,
                    Revision = revision + 1
                };

                _drafts[formId] = draft;

                return draft;
            }
        }

        /// <summary>
        /// Discards the draft, leaving the published structure standing.
        /// </summary>
        /// <param name="formId">The id of the form.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The current request.</param>
        protected override void DeleteDraft(string formId, IQueryContext context, IRequest request)
        {
            Clear(formId);
        }
    }
}
