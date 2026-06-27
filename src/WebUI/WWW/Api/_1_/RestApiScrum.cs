using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a Monkey Island themed Scrum REST API for backlog and sprint data.
    /// </summary>
    [Segment("scrum")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Scrum")]
    public sealed class RestApiScrum : RestApiScrumBacklog<Sprint, ScrumItem>
    {
        private static readonly object SyncRoot = new();

        /// <summary>
        /// Retrieves a collection of sprints based on the specified query and context.
        /// </summary>
        /// <param name="query">
        /// The query that defines the criteria for selecting sprints.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed, providing access to relevant 
        /// data and services.
        /// </param>
        /// <param name="request">
        /// The request information associated with the operation, which may include 
        /// user or session details.
        /// </param>
        /// <returns>
        /// An enumerable collection of sprints that match the specified query criteria.
        /// </returns>
        protected override IEnumerable<Sprint> RetrieveSprints(IQuery<Sprint> query, IQueryContext context, IRequest request)
        {
            lock (SyncRoot)
            {
                return ViewModel.MonkeyIslandSprints
                    .Select(x => new Sprint
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Goal = x.Goal,
                        Status = x.Status,
                        Start = x.Start,
                        End = x.End,
                        Capacity = x.Capacity
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Retrieves a collection of REST API Scrum items based on the specified 
        /// query and context.
        /// </summary>
        /// <param name="query">
        /// The query used to filter or select the relevant Curse items.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed, providing additional 
        /// information or services required for retrieval.
        /// </param>
        /// <param name="request">
        /// The request information associated with the current operation, which 
        /// may influence item retrieval.
        /// </param>
        /// <returns>
        /// An enumerable collection of RestApiScrumItem objects representing the 
        /// scrum items that match the query criteria.
        /// </returns>
        protected override IEnumerable<ScrumItem> RetrieveItems(IQuery<ScrumItem> query, IQueryContext context, IRequest request)
        {
            lock (SyncRoot)
            {
                return ViewModel.MonkeyIslandScrumItems
                    .Select(x => new ScrumItem
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Icon = x.Icon,
                        Key = x.Key,
                        Title = x.Title,
                        Priority = x.Priority,
                        Points = x.Points,
                        SprintId = x.SprintId,
                        Status = x.Status,
                        Rank = x.Rank,
                        AssigneeId = x.AssigneeId
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Creates a new sprint using the specified payload and request context.
        /// </summary>
        /// <param name="payload">
        /// The payload containing the properties and configuration for the new 
        /// sprint. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request context associated with the sprint creation operation. Provides 
        /// additional metadata or authentication information as needed.
        /// </param>
        /// <param name="newSprint">
        /// When this method returns, contains the newly created sprint instance.
        /// </param>
        /// <returns>
        /// A result object containing information about the created sprint, including 
        /// a clone of the new sprint data.
        /// </returns>
        protected override IRestApiCrudResultCreate CreateSprint(RestApiSprintPayload payload, IRequest request, out Sprint newSprint)
        {
            lock (SyncRoot)
            {
                newSprint = new Sprint
                {
                    Id = Guid.TryParse(payload.Id, out var id) ? id : Guid.NewGuid(),
                    Name = payload.Name ?? string.Empty,
                    Goal = payload.Goal ?? string.Empty,
                    Status = string.IsNullOrWhiteSpace(payload.Status) ? "planned" : payload.Status,
                    Start = payload.Start,
                    End = payload.End,
                    Capacity = payload.Capacity ?? 0
                };

                ViewModel.MonkeyIslandSprints.Add(newSprint);

                if (string.Equals(newSprint.Status, "active", StringComparison.OrdinalIgnoreCase))
                {
                    var restSprints = ViewModel.MonkeyIslandSprints.Select(ToRestSprint).ToList();
                    CloseOtherActiveSprints(restSprints, newSprint.Id);
                    foreach (var restSprint in restSprints)
                    {
                        if (!Guid.TryParse(restSprint.Id, out var restSprintId))
                        {
                            continue;
                        }

                        var sprint = ViewModel.MonkeyIslandSprints.FirstOrDefault(x => x.Id == restSprintId);
                        if (sprint is not null)
                        {
                            sprint.Status = restSprint.Status;
                        }
                    }
                }

                return new RestApiCrudResultCreate
                {
                    Data = ToRestSprint(newSprint)
                };
            }
        }

        /// <summary>
        /// Updates the properties of an existing sprint based on the provided payload.
        /// </summary>
        /// <param name="existingSprint">
        /// The sprint whose properties are to be updated. Must be a valid sprint 
        /// object with an existing ID.
        /// </param>
        /// <param name="payload">
        /// The payload containing the new values for the sprint. Values not provided 
        /// remain unchanged.
        /// </param>
        /// <param name="request">
        /// The current API request object containing contextual information about 
        /// the operation.
        /// </param>
        /// <returns>
        /// A result object indicating the outcome of the sprint update.
        /// </returns>
        protected override IRestApiCrudResultUpdate UpdateSprint(Sprint existingSprint, RestApiSprintPayload payload, IRequest request)
        {
            lock (SyncRoot)
            {
                var sprint = ViewModel.MonkeyIslandSprints.First(x => x.Id == existingSprint.Id);

                sprint.Name = payload.Name ?? sprint.Name;
                sprint.Goal = payload.Goal ?? sprint.Goal;
                sprint.Status = string.IsNullOrWhiteSpace(payload.Status) ? sprint.Status : payload.Status;
                sprint.Start = payload.Start ?? sprint.Start;
                sprint.End = payload.End ?? sprint.End;
                sprint.Capacity = payload.Capacity ?? sprint.Capacity;

                if (string.Equals(sprint.Status, "active", StringComparison.OrdinalIgnoreCase))
                {
                    var restSprints = ViewModel.MonkeyIslandSprints.Select(ToRestSprint).ToList();
                    CloseOtherActiveSprints(restSprints, sprint.Id);
                    foreach (var restSprint in restSprints)
                    {
                        if (!Guid.TryParse(restSprint.Id, out var restSprintId))
                        {
                            continue;
                        }

                        var existing = ViewModel.MonkeyIslandSprints.FirstOrDefault(x => x.Id == restSprintId);
                        if (existing is not null)
                        {
                            existing.Status = restSprint.Status;
                        }
                    }
                }

                return new RestApiCrudResultUpdate();
            }
        }

        /// <summary>
        /// Moves an existing Scrum item to another sprint or back to the backlog 
        /// and updates its status and rank accordingly.
        /// </summary>
        /// <remarks>
        /// <param name="existingItem">
        /// The Scrum item to be moved. Must be a valid item that already exists.
        /// </param>
        /// <param name="payload">
        /// The payload containing information about the target sprint and additional 
        /// move options.
        /// The target sprint may be null to move the item back to the backlog.
        /// </param>
        /// <param name="request">
        /// The current API request object containing contextual information about 
        /// the operation.
        /// </param>
        /// <returns>
        /// A result object confirming the completion of the Scrum item update.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the specified target sprint cannot be found.
        /// </exception>
        protected override IRestApiCrudResultUpdate MoveItem(ScrumItem existingItem, RestApiScrumMovePayload payload, IRequest request)
        {
            lock (SyncRoot)
            {
                var item = ViewModel.MonkeyIslandScrumItems.First(x => x.Id == existingItem.Id);
                var previousSprintId = item.SprintId;
                var targetSprintId = NormalizeSprintId(payload.SprintId);

                if (targetSprintId is not null && !ViewModel.MonkeyIslandSprints.Any(x => x.Id == targetSprintId))
                {
                    throw new InvalidOperationException("Target sprint not found.");
                }

                item.SprintId = targetSprintId;
                item.Status = targetSprintId is null
                    ? "backlog"
                    : string.Equals(item.Status, "backlog", StringComparison.OrdinalIgnoreCase) ? "todo" : item.Status;

                var restItems = ViewModel.MonkeyIslandScrumItems.Select(ToRestItem).ToList();
                item.Rank = NextRank(restItems, targetSprintId);
                NormalizeRanks(restItems, previousSprintId);
                NormalizeRanks(restItems, targetSprintId);

                foreach (var restItem in restItems)
                {
                    if (!Guid.TryParse(restItem.Id, out var restItemId))
                    {
                        continue;
                    }

                    var existing = ViewModel.MonkeyIslandScrumItems.FirstOrDefault(x => x.Id == restItemId);
                    if (existing is not null)
                    {
                        existing.Rank = restItem.Rank;
                        existing.SprintId = NormalizeSprintId(restItem.SprintId);
                        existing.Status = restItem.Status;
                    }
                }

                return new RestApiCrudResultUpdate();
            }
        }

        /// <summary>
        /// Reorders the specified Scrum item within its sprint or moves it to a 
        /// different sprint, updating its rank according to the provided payload.
        /// </summary>
        /// <param name="existingItem">
        /// The Scrum item to be ranked or moved. Must not be null and must exist in 
        /// the current collection.
        /// </param>
        /// <param name="payload">
        /// The payload containing the target sprint identifier and the desired rank 
        /// for the item. The sprint identifier may be null to retain the current 
        /// sprint.
        /// </param>
        /// <param name="request">
        /// The request context for the operation. Provides additional information 
        /// about the API request.
        /// </param>
        /// <returns>
        /// An object representing the result of the update operation. Indicates 
        /// whether the ranking or move was successful.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the target sprint specified in the payload does not exist.
        /// </exception>
        protected override IRestApiCrudResultUpdate RankItem(ScrumItem existingItem, RestApiScrumRankPayload payload, IRequest request)
        {
            lock (SyncRoot)
            {
                var item = ViewModel.MonkeyIslandScrumItems.First(x => x.Id == existingItem.Id);
                var sprintId = NormalizeSprintId(payload.SprintId) ?? item.SprintId;

                if (sprintId is not null && !ViewModel.MonkeyIslandSprints.Any(x => x.Id == sprintId))
                {
                    throw new InvalidOperationException("Target sprint not found.");
                }

                var previousSprintId = item.SprintId;
                item.SprintId = sprintId;

                var restItems = ViewModel.MonkeyIslandScrumItems.Select(ToRestItem).ToList();
                var restItem = restItems.First(x => Guid.TryParse(x.Id, out var restItemId) && restItemId == item.Id);
                ReorderItem(restItems, restItem, sprintId, payload.Rank ?? 1);

                if (previousSprintId != sprintId)
                {
                    NormalizeRanks(restItems, previousSprintId);
                }

                foreach (var reorderedItem in restItems)
                {
                    if (!Guid.TryParse(reorderedItem.Id, out var reorderedItemId))
                    {
                        continue;
                    }

                    var existing = ViewModel.MonkeyIslandScrumItems.FirstOrDefault(x => x.Id == reorderedItemId);
                    if (existing is not null)
                    {
                        existing.Rank = reorderedItem.Rank;
                        existing.SprintId = NormalizeSprintId(reorderedItem.SprintId);
                    }
                }

                return new RestApiCrudResultUpdate();
            }
        }

        /// <summary>
        /// Deletes the specified sprint and updates associated scrum items to 
        /// reflect the removal.
        /// </summary>
        /// <param name="existingSprint">
        /// The sprint to be deleted. Must not be null and must exist in the current
        /// collection.
        /// </param>
        /// <param name="request">
        /// The request context for the delete operation. Provides additional 
        /// information about the operation.
        /// </param>
        /// <returns>
        /// A result object indicating the outcome of the delete operation.
        /// </returns>
        protected override IRestApiCrudResultDelete DeleteSprint(Sprint existingSprint, IRequest request)
        {
            lock (SyncRoot)
            {
                var sprint = ViewModel.MonkeyIslandSprints.First(x => x.Id == existingSprint.Id);

                ViewModel.MonkeyIslandSprints.Remove(sprint);

                foreach (var item in ViewModel.MonkeyIslandScrumItems.Where(x => x.SprintId == sprint.Id))
                {
                    item.SprintId = null;
                    item.Status = "backlog";
                }

                var restItems = ViewModel.MonkeyIslandScrumItems.Select(ToRestItem).ToList();
                NormalizeRanks(restItems, sprint.Id);
                NormalizeRanks(restItems, null);

                foreach (var restItem in restItems)
                {
                    if (!Guid.TryParse(restItem.Id, out var restItemId))
                    {
                        continue;
                    }

                    var existing = ViewModel.MonkeyIslandScrumItems.FirstOrDefault(x => x.Id == restItemId);
                    if (existing is not null)
                    {
                        existing.Rank = restItem.Rank;
                        existing.SprintId = NormalizeSprintId(restItem.SprintId);
                        existing.Status = restItem.Status;
                    }
                }

                return new RestApiCrudResultDelete();
            }
        }

        /// <summary>
        /// Converts a sprint domain object to its REST API representation.
        /// </summary>
        /// <param name="sprint">
        /// The sprint instance to convert. Cannot be null.
        /// </param>
        /// <returns>
        /// A RestApiScrumSprint object containing the mapped properties from 
        /// the specified sprint.
        /// </returns>
        protected override RestApiScrumSprintItem ToRestSprint(Sprint sprint)
        {
            return new RestApiScrumSprintItem
            {
                Id = sprint.Id.ToString(),
                Name = sprint.Name,
                Goal = sprint.Goal,
                Status = sprint.Status,
                Start = sprint.Start,
                End = sprint.End,
                Capacity = sprint.Capacity
            };
        }

        /// <summary>
        /// Converts the specified Scrum item into a representation compatible with 
        /// the REST API.
        /// </summary>
        /// <param name="item">
        /// The Scrum item to convert. Must not be null.
        /// </param>
        /// <returns>
        /// A new RestApiScrumItem object containing the properties of the specified 
        /// Scrum item.
        /// </returns>
        protected override RestApiScrumItem ToRestItem(ScrumItem item)
        {
            var rest = new RestApiScrumItem
            {
                Id = item.Id.ToString(),
                Type = item.Type,
                Icon = item.Icon,
                Key = item.Key,
                Title = item.Title,
                Priority = item.Priority,
                Points = item.Points,
                SprintId = item.SprintId?.ToString(),
                Status = item.Status,
                Rank = item.Rank,
                AssigneeId = item.AssigneeId
            };

            // resolve the assignee from the shared Monkey Island directory so the
            // backlog can render an avatar without a second round trip
            if (!string.IsNullOrWhiteSpace(item.AssigneeId))
            {
                var user = MonkeyIslandWatcherDirectory.FindById(item.AssigneeId);
                if (user is not null)
                {
                    rest.AssigneeName = user.Name;
                    rest.AssigneeInitials = user.Initials;
                    rest.AssigneeColor = user.Color;
                }
            }

            return rest;
        }

        /// <summary>
        /// Applies a new assignee and/or story-point estimate to an existing
        /// Scrum item.
        /// </summary>
        /// <param name="existingItem">The item to update.</param>
        /// <param name="payload">The payload carrying the new assignee and estimate.</param>
        /// <param name="request">The current API request.</param>
        /// <returns>A result object confirming the update.</returns>
        protected override IRestApiCrudResultUpdate UpdateItem(ScrumItem existingItem, RestApiScrumItemPayload payload, IRequest request)
        {
            lock (SyncRoot)
            {
                var item = ViewModel.MonkeyIslandScrumItems.First(x => x.Id == existingItem.Id);

                item.AssigneeId = string.IsNullOrWhiteSpace(payload.AssigneeId) ? null : payload.AssigneeId;

                if (payload.Points.HasValue)
                {
                    item.Points = Math.Max(0, payload.Points.Value);
                }

                return new RestApiCrudResultUpdate();
            }
        }
    }
}
