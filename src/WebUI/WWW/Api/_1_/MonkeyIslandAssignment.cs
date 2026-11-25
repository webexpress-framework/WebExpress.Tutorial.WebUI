using System;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebDomain;
using WebExpress.WebCore.WebEndpoint;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Holds the assignee of the Monkey Island quest log in a thread-safe in-memory store.
    /// The tutorial has no sign-in, so the caller always plays Guybrush Threepwood and may
    /// change the assignment. Captain LeChuck refuses every assignment, which shows how a
    /// refusal reaches the user.
    /// </summary>
    [Segment("assignment")]
    [Title("Monkey Island Assignee")]
    public sealed class MonkeyIslandAssignment : RestApiAssignment<MonkeyIslandQuest>, IPublicEndpoint
    {
        private const string SelfId = "guybrush";
        private const string RefusingId = "lechuck";

        private static readonly object _syncRoot = new();
        private static readonly MonkeyIslandQuest _quest = new() { Title = "Find the Secret of Monkey Island" };
        private static string _assigneeId = "elaine";

        /// <summary>
        /// Gets the current assignee, so the demo page renders the row on the server.
        /// </summary>
        public static RestApiAssignmentItem CurrentAssignee
        {
            get
            {
                lock (_syncRoot)
                {
                    return Find(_assigneeId);
                }
            }
        }

        /// <summary>
        /// Gets the person the caller plays.
        /// </summary>
        public static RestApiAssignmentItem CurrentSelf => Find(SelfId);

        /// <summary>
        /// Returns the quest log, the only object of the demo.
        /// </summary>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns>The quest.</returns>
        protected override MonkeyIslandQuest RetrieveItem(IQueryContext context, IRequest request) => _quest;

        /// <summary>
        /// Returns the assignee of the quest.
        /// </summary>
        /// <param name="item">The quest.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns>The assignee, or <see langword="null"/>.</returns>
        protected override RestApiAssignmentItem RetrieveAssignee(MonkeyIslandQuest item, IQueryContext context, IRequest request) => CurrentAssignee;

        /// <summary>
        /// Returns the person the caller plays.
        /// </summary>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns>Guybrush Threepwood.</returns>
        protected override RestApiAssignmentItem RetrieveSelf(IQueryContext context, IRequest request) => CurrentSelf;

        /// <summary>
        /// Lets every caller change the assignment, since the demo has no sign-in.
        /// </summary>
        /// <param name="item">The quest.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns><see langword="true"/>.</returns>
        protected override bool MayChange(MonkeyIslandQuest item, IQueryContext context, IRequest request) => true;

        /// <summary>
        /// Assigns the quest to a crew member of the directory.
        /// </summary>
        /// <param name="item">The quest.</param>
        /// <param name="userId">The id of the new assignee.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        /// <returns><see langword="false"/> when nobody of the directory carries the id.</returns>
        protected override bool Assign(MonkeyIslandQuest item, string userId, IQueryContext context, IRequest request)
        {
            if (string.Equals(userId, RefusingId, StringComparison.OrdinalIgnoreCase))
            {
                throw new RestApiRefusal(I18N.Translate(request, "webexpress.tutorial.webui:assignment.refused.lechuck"));
            }

            var user = Find(userId);
            if (user is null)
            {
                return false;
            }

            lock (_syncRoot)
            {
                _assigneeId = user.Id;
            }

            return true;
        }

        /// <summary>
        /// Removes the assignee of the quest.
        /// </summary>
        /// <param name="item">The quest.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The request.</param>
        protected override void Unassign(MonkeyIslandQuest item, IQueryContext context, IRequest request)
        {
            lock (_syncRoot)
            {
                _assigneeId = null;
            }
        }

        /// <summary>
        /// Resolves a crew member of the shared Monkey Island directory.
        /// </summary>
        /// <param name="id">The id, or <see langword="null"/>.</param>
        /// <returns>The person, or <see langword="null"/>.</returns>
        private static RestApiAssignmentItem Find(string id)
        {
            var user = id is null ? null : MonkeyIslandWatcherDirectory.FindById(id);

            return user is null ? null : new RestApiAssignmentItem
            {
                Id = user.Id,
                Name = user.Name,
                Image = user.Image,
                Initials = user.Initials
            };
        }
    }

    /// <summary>
    /// The quest log of the assignment demo. It belongs to a domain, so a change of its
    /// assignee is announced and every row bound to the quest loads the new assignee.
    /// </summary>
    public sealed class MonkeyIslandQuest : IIndexItem, IDomain
    {
        /// <summary>
        /// Gets or sets the unique identifier of the quest.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the title of the quest.
        /// </summary>
        public string Title { get; set; }
    }
}
