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
    /// Provides a Monkey Island themed Scrum REST API for active sprint overview data.
    /// </summary>
    [Segment("scrum-sprint")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Scrum Sprint")]
    public sealed class RestApiScrumSprint : RestApiScrumSprint<Sprint, ScrumItem>
    {
        private static readonly object SyncRoot = new();

        /// <summary>
        /// Retrieves a collection of sprints.
        /// </summary>
        /// <param name="query">The query that defines the criteria for selecting sprints.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request information associated with the operation.</param>
        /// <returns>An enumerable collection of sprints.</returns>
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
        /// Retrieves a collection of scrum items.
        /// </summary>
        /// <param name="query">The query used to filter or select items.</param>
        /// <param name="context">The context in which the query is executed.</param>
        /// <param name="request">The request information associated with the current operation.</param>
        /// <returns>An enumerable collection of scrum items.</returns>
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
                        Rank = x.Rank
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Converts a sprint model instance into the REST sprint DTO.
        /// </summary>
        /// <param name="sprint">The sprint model.</param>
        /// <returns>The REST sprint DTO.</returns>
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
        /// Converts an item model instance into the REST item DTO.
        /// </summary>
        /// <param name="item">The item model.</param>
        /// <returns>The REST item DTO.</returns>
        protected override RestApiScrumItem ToRestItem(ScrumItem item)
        {
            return new RestApiScrumItem
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
                Rank = item.Rank
            };
        }
    }
}
