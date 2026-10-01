using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a REST API kanban with Monkey Island themed content for every widget template.
    /// The columns are held in a thread-safe in-memory store so that renaming,
    /// reordering and deleting them persists across reloads.
    /// </summary>
    public sealed class MonkeyIslandKanban : RestApiKanban<Curse>
    {
        private static readonly object _syncRoot = new();
        private static readonly Dictionary<string, RestApiKanbanMove> _moves = new();

        private static readonly List<RestApiKanbanColumn> _columns =
        [
            new RestApiKanbanColumn { Id = "todo", StatusIds = ["open"],     Label = "Trials",          ColorCss = "bg-light text-dark",    Badge = "2", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary) },
            new RestApiKanbanColumn { Id = "progress", StatusIds = ["active", "review"], Label = "Adventure",       ColorCss = "bg-primary text-white", Badge = "1", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary) },
            new RestApiKanbanColumn { Id = "danger", StatusIds = ["blocked"],   Label = "Danger Zone",     ColorCss = "bg-danger text-white",  Badge = "1", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger) },
            new RestApiKanbanColumn { Id = "done", StatusIds = ["done"],     Label = "Legendary Feats", ColorCss = "bg-success text-white", Badge = "1", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success) }
        ];

        private static readonly List<RestApiKanbanSwimlane> _swimlanes =
        [
            new RestApiKanbanSwimlane { Id = "melee",   Label = "Mêlée Island",       ColorCss = "bg-secondary text-white", Expanded = true,  Badge = "3", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary) },
            new RestApiKanbanSwimlane { Id = "monkey",  Label = "Monkey Island",      ColorCss = "bg-warning text-dark",    Expanded = true,  Badge = "1", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning) },
            new RestApiKanbanSwimlane { Id = "lechuck", Label = "LeChuck's Fortress", ColorCss = "bg-dark text-white",      Expanded = false, Badge = "1", BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Dark) }
        ];

        // the wql filter of the board settings; persisted so it survives full page
        // reloads that carry no wql request parameter
        private static string _filter;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandKanban()
        {
        }

        /// <summary>
        /// Offers workflow statuses that demonstrate multiple destinations within one column
        /// and colored status chips in both system and user-defined colors.
        /// </summary>
        /// <param name="request">The request used to retrieve the demonstration board.</param>
        /// <returns>The status catalog shared by all demonstration cards.</returns>
        protected override IEnumerable<RestApiKanbanStatus> RetrieveStatuses(IRequest request)
        {
            return
            [
                new() { Id = "open", Label = "Open", Color = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Secondary) },
                new() { Id = "active", Label = "In progress", Color = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary) },
                new() { Id = "review", Label = "In review", Color = new PropertyColorBackgroundBadge("#7c3aed") },
                new() { Id = "blocked", Label = "Blocked", Color = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger) },
                new() { Id = "done", Label = "Done", Color = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Success) }
            ];
        }

        /// <summary>
        /// Keeps a validated destination available on subsequent demonstration requests.
        /// </summary>
        /// <param name="move">The validated destination.</param>
        /// <param name="request">The request that initiated the move.</param>
        protected override void MoveCard(RestApiKanbanMove move, IRequest request)
        {
            lock (_syncRoot)
            {
                _moves[move.CardId] = move;
            }
        }

        /// <summary>
        /// This method defines the columns for the kanban. Each card is
        /// themed around Monkey Island.
        /// </summary>
        /// <param name="request">The incoming request context.</param>
        /// <returns>A sequence of configured kanban columns.</returns>
        protected override IEnumerable<RestApiKanbanColumn> RetrieveColumns(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _columns.Select(c => new RestApiKanbanColumn { Id = c.Id, StatusIds = c.StatusIds?.ToArray(), Label = c.Label, Size = c.Size, Color = c.Color, ColorCss = c.ColorCss, Badge = c.Badge, BadgeColor = c.BadgeColor })];
            }
        }

        /// <summary>
        /// Applies a column-layout change (rename / resize / recolor / reorder /
        /// delete) to the in-memory store.
        /// </summary>
        /// <param name="layout">The layout payload carrying the new column list.</param>
        /// <param name="request">The incoming request.</param>
        protected override void UpdtaeColumns(RestApiDashboardLayout layout, IRequest request)
        {
            if (layout?.Columns is null)
            {
                return;
            }

            lock (_syncRoot)
            {
                var byId = _columns.ToDictionary(c => c.Id, c => c);
                var reordered = new List<RestApiKanbanColumn>();

                foreach (var col in layout.Columns)
                {
                    if (string.IsNullOrWhiteSpace(col?.Id))
                    {
                        continue;
                    }

                    if (byId.TryGetValue(col.Id, out var existing))
                    {
                        existing.Label = col.Title ?? existing.Label;
                        existing.Size = col.Size;
                        existing.Color = col.Color;
                        existing.StatusIds = col.StatusIds?.ToArray();
                        reordered.Add(existing);
                    }
                    else
                    {
                        reordered.Add(new RestApiKanbanColumn { Id = col.Id, StatusIds = col.StatusIds?.ToArray(), Label = col.Title, Size = col.Size, Color = col.Color });
                    }
                }

                _columns.Clear();
                _columns.AddRange(reordered);
            }
        }

        /// <summary>
        /// Retrieves the collection of swimlanes associated with the specified request.
        /// </summary>
        /// <param name="request">
        /// The request context used to determine which swimlanes to retrieve.
        /// </param>
        /// <returns>
        /// An enumerable collection of swimlanes relevant to the request. The
        /// collection is empty if no swimlanes are available.
        /// </returns>
        protected override IEnumerable<RestApiKanbanSwimlane> RetrieveSwimlanes(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _swimlanes.Select(s => new RestApiKanbanSwimlane { Id = s.Id, Label = s.Label, ColorCss = s.ColorCss, Expanded = s.Expanded, Filter = s.Filter, Badge = s.Badge, BadgeColor = s.BadgeColor })];
            }
        }

        /// <summary>
        /// Applies a swimlane-layout change (add / rename / reorder / delete) to
        /// the in-memory store.
        /// </summary>
        /// <param name="layout">The layout payload carrying the new swimlane list.</param>
        /// <param name="request">The incoming request.</param>
        protected override void UpdateSwimlanes(RestApiDashboardLayout layout, IRequest request)
        {
            if (layout?.Swimlanes is null)
            {
                return;
            }

            lock (_syncRoot)
            {
                var byId = _swimlanes.ToDictionary(s => s.Id, s => s);
                var reordered = new List<RestApiKanbanSwimlane>();

                foreach (var lane in layout.Swimlanes)
                {
                    if (string.IsNullOrWhiteSpace(lane?.Id))
                    {
                        continue;
                    }

                    if (byId.TryGetValue(lane.Id, out var existing))
                    {
                        existing.Label = lane.Title ?? existing.Label;
                        existing.Filter = lane.Filter;
                        reordered.Add(existing);
                    }
                    else
                    {
                        reordered.Add(new RestApiKanbanSwimlane { Id = lane.Id, Label = lane.Title, Expanded = true, Filter = lane.Filter });
                    }
                }

                _swimlanes.Clear();
                _swimlanes.AddRange(reordered);
            }
        }

        /// <summary>
        /// Persists the board settings (the wql filter) to the in-memory store.
        /// </summary>
        /// <param name="layout">The layout payload carrying the wql filter.</param>
        /// <param name="request">The incoming request.</param>
        protected override void UpdateSettings(RestApiDashboardLayout layout, IRequest request)
        {
            lock (_syncRoot)
            {
                _filter = string.IsNullOrWhiteSpace(layout?.Filter) ? null : layout.Filter;
            }
        }

        /// <summary>
        /// Seeds the persisted wql filter when the request carries none, so the
        /// settings dialog reflects the stored value after a full page reload.
        /// </summary>
        /// <param name="wql">The wql filter carried on the request, or null.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The active wql filter, or null when the board has none.</returns>
        protected override string RetrieveFilter(string wql, IRequest request)
        {
            lock (_syncRoot)
            {
                return string.IsNullOrWhiteSpace(wql) ? _filter : wql;
            }
        }

        /// <summary>
        /// Retrieves a collection of Kanban cards based on the specified request parameters.
        /// </summary>
        /// <param name="query">
        /// An object containing the query parameters used to filter and select index items. Cannot 
        /// be null.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional information or constraints 
        /// for the retrieval operation. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request context used to determine which cards to retrieve.
        /// </param>
        /// <returns>
        /// An enumerable collection of cards relevant to the request. The 
        /// collection is empty if no cards are available.
        /// </returns>
        protected override IEnumerable<RestApiKanbanCard> RetrieveCards(IQuery<Curse> query, IQueryContext context, IRequest request)
        {
            RestApiKanbanCard[] cards =
            [
                new RestApiKanbanCard
                {
                    Id = "k1",
                    StatusId = "active",
                    Label = "Swordfighting Training",
                    Html = "Face Carla and become the Sword Master.",
                    ColumnId = "progress",
                    SwimlaneId = "melee",
                    ColorCss = "border-primary",
                    AssigneeId = "guybrush",
                    AssigneeName = "Guybrush Threepwood",
                    AssigneeInitials = "GT",
                    AssigneeColor = "#1d4ed8",
                    Badge = "#42",
                    BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary),
                    Footer =
                    [
                        new RestApiKanbanCardChip { Label = "P2", Color = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Warning), Title = "Priority" },
                        new RestApiKanbanCardChip { Label = "5", Icon = new IconStar(), Title = "Story points" }
                    ]
                },
                new RestApiKanbanCard
                {
                    Id = "k2",
                    StatusId = "blocked",
                    AllowedStatusIds = ["open", "active"],
                    Label = "Steal the Idol",
                    Html = "Infiltrate the Governor's mansion and snatch the voodoo idol.",
                    ColumnId = "danger",
                    SwimlaneId = "melee",
                    ColorCss = "border-danger",
                    AssigneeId = "elaine",
                    AssigneeName = "Elaine Marley",
                    AssigneeInitials = "EM",
                    AssigneeColor = "#7c3aed",
                    Badge = "#43",
                    BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger),
                    Footer =
                    [
                        new RestApiKanbanCardChip { Label = "P1", Color = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger), Title = "Priority" },
                        new RestApiKanbanCardChip { Label = "8", Icon = new IconStar(), Title = "Story points" }
                    ]
                },
                new RestApiKanbanCard
                {
                    Id = "k3",
                    StatusId = "open",
                    Label = "Assemble Crew",
                    Html = "Recruit Carla, Otis and Meathook to sail to Monkey Island.",
                    ColumnId = "todo",
                    SwimlaneId = "melee"
                },
                new RestApiKanbanCard
                {
                    Id = "k4",
                    StatusId = "open",
                    AllowedStatusIds = ["active", "review", "done"],
                    Label = "Find Secret of Monkey Island",
                    Html = "Explore and find the fabled secret.",
                    ColumnId = "todo",
                    SwimlaneId = "monkey"
                },
                new RestApiKanbanCard
                {
                    Id = "k5",
                    StatusId = "done",
                    AllowedStatusIds = [],
                    Label = "Defeat LeChuck",
                    Html = "Confront LeChuck and save Elaine.",
                    ColumnId = "done",
                    SwimlaneId = "lechuck",
                    ColorCss = "border-success",
                    AssigneeId = "lechuck",
                    AssigneeName = "Captain LeChuck",
                    AssigneeInitials = "LC",
                    AssigneeColor = "#991b1b"
                }
            ];

            lock (_syncRoot)
            {
                foreach (var card in cards)
                {
                    if (_moves.TryGetValue(card.Id, out var move))
                    {
                        card.ColumnId = move.ColumnId;
                        card.SwimlaneId = move.SwimlaneId;
                        card.StatusId = move.StatusId;
                    }
                }
            }

            return cards;
        }
    }
}