using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a Monkey Island themed gantt REST endpoint: the project plan
    /// for Guybrush's quest to become a mighty pirate and rescue Elaine. The
    /// tasks and links are held in a thread-safe in-memory store so that
    /// rescheduling, linking, adding and deleting persist across reloads.
    /// Routing of the sub-paths (<c>/tasks</c>, <c>/tasks/{id}</c>,
    /// <c>/links</c>, <c>/links/{id}</c>) is handled by the
    /// <see cref="RestApiGantt"/> base class.
    /// </summary>
    [Segment("gantt")]
    [IncludeSubPaths(true)]
    [Title("Monkey Island Gantt")]
    public sealed class MonkeyIslandGantt : RestApiGantt
    {
        private static readonly object _syncRoot = new();
        private static readonly List<RestApiGanttTask> _tasks = SeedTasks();
        private static readonly List<RestApiGanttLink> _links = SeedLinks();
        private static int _nextId = 100;

        /// <summary>
        /// Retrieves all tasks from the store in a thread-safe manner.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The project's tasks.</returns>
        protected override IEnumerable<RestApiGanttTask> RetrieveTasks(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _tasks.Select(Clone)];
            }
        }

        /// <summary>
        /// Retrieves all dependency links from the store in a thread-safe manner.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The project's links.</returns>
        protected override IEnumerable<RestApiGanttLink> RetrieveLinks(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _links.Select(Clone)];
            }
        }

        /// <summary>
        /// Stores a newly created task, assigning a server id so the client
        /// adopts the canonical resource.
        /// </summary>
        /// <param name="task">The task to create.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The stored task.</returns>
        protected override RestApiGanttTask CreateTask(RestApiGanttTask task, IRequest request)
        {
            lock (_syncRoot)
            {
                task.Id = NextId("t");
                task.Resources ??= [];
                _tasks.Add(task);

                return Clone(task);
            }
        }

        /// <summary>
        /// Applies a task change to the stored task.
        /// </summary>
        /// <param name="id">The task id from the sub-path.</param>
        /// <param name="task">The task payload.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The updated task, or null when unknown.</returns>
        protected override RestApiGanttTask UpdateTask(string id, RestApiGanttTask task, IRequest request)
        {
            lock (_syncRoot)
            {
                var existing = _tasks.FirstOrDefault(x => x.Id == id);
                if (existing is null)
                {
                    return null;
                }

                existing.Label = task.Label;
                existing.Start = task.Start;
                existing.End = task.End;
                existing.Duration = task.Duration;
                existing.Progress = task.Progress;
                existing.Resources = task.Resources ?? [];
                existing.ParentId = task.ParentId;
                existing.Icon = task.Icon;

                return Clone(existing);
            }
        }

        /// <summary>
        /// Removes a task including its container subtree and every link that
        /// touches a removed task, mirroring the cascade of the client.
        /// </summary>
        /// <param name="id">The task id from the sub-path.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>True when the task existed and was removed.</returns>
        protected override bool DeleteTask(string id, IRequest request)
        {
            lock (_syncRoot)
            {
                if (!_tasks.Any(x => x.Id == id))
                {
                    return false;
                }

                // collect the subtree so a container drops together with its children
                var removed = new HashSet<string> { id };
                var grown = true;
                while (grown)
                {
                    grown = false;
                    foreach (var candidate in _tasks)
                    {
                        if (candidate.ParentId is not null && removed.Contains(candidate.ParentId) && removed.Add(candidate.Id))
                        {
                            grown = true;
                        }
                    }
                }

                _tasks.RemoveAll(x => removed.Contains(x.Id));
                _links.RemoveAll(x => removed.Contains(x.From) || removed.Contains(x.To));

                return true;
            }
        }

        /// <summary>
        /// Stores a newly created dependency link, assigning a server id.
        /// </summary>
        /// <param name="link">The link to create.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The stored link.</returns>
        protected override RestApiGanttLink CreateLink(RestApiGanttLink link, IRequest request)
        {
            lock (_syncRoot)
            {
                link.Id = NextId("l");
                link.Type = string.IsNullOrWhiteSpace(link.Type) ? "FS" : link.Type;
                _links.Add(link);

                return Clone(link);
            }
        }

        /// <summary>
        /// Removes a dependency link from the store.
        /// </summary>
        /// <param name="id">The link id from the sub-path.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>True when the link existed and was removed.</returns>
        protected override bool DeleteLink(string id, IRequest request)
        {
            lock (_syncRoot)
            {
                return _links.RemoveAll(x => x.Id == id) > 0;
            }
        }

        /// <summary>
        /// Generates the next server side id with a prefix.
        /// </summary>
        /// <param name="prefix">The id prefix.</param>
        /// <returns>The id.</returns>
        private static string NextId(string prefix)
        {
            return prefix + (_nextId++).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Seeds the plan of Guybrush's quest: two container phases with their
        /// tasks, a "set sail" milestone and the final confrontation.
        /// </summary>
        /// <returns>The seeded tasks.</returns>
        private static List<RestApiGanttTask> SeedTasks()
        {
            return
            [
                new RestApiGanttTask { Id = "p1", Label = "Become a mighty pirate", ParentId = null, Icon = "fas fa-hat-wizard" },
                new RestApiGanttTask { Id = "t1", Label = "Master the sword", ParentId = "p1", Start = "2026-07-06", Duration = 4, Progress = 100, Resources = ["Guybrush", "Carla"], Icon = "fas fa-khanda" },
                new RestApiGanttTask { Id = "t2", Label = "Master thievery", ParentId = "p1", Start = "2026-07-08", Duration = 3, Progress = 60, Resources = ["Guybrush"], Icon = "fas fa-mask" },
                new RestApiGanttTask { Id = "t3", Label = "Master treasure hunting", ParentId = "p1", Start = "2026-07-11", Duration = 3, Progress = 20, Resources = ["Guybrush", "Otis"], Icon = "fas fa-gem" },

                new RestApiGanttTask { Id = "p2", Label = "Voyage to Monkey Island", ParentId = null, Icon = "fas fa-map" },
                new RestApiGanttTask { Id = "t4", Label = "Assemble a crew", ParentId = "p2", Start = "2026-07-14", Duration = 2, Progress = 0, Resources = ["Meathook", "Carla", "Otis"], Icon = "fas fa-users" },
                new RestApiGanttTask { Id = "t5", Label = "Acquire a ship", ParentId = "p2", Start = "2026-07-16", Duration = 3, Progress = 0, Resources = ["Stan"], Icon = "fas fa-ship" },
                new RestApiGanttTask { Id = "m1", Label = "Set sail", ParentId = "p2", Start = "2026-07-20", Duration = 0, Progress = 0, Icon = "fas fa-flag" },

                new RestApiGanttTask { Id = "t6", Label = "Defeat LeChuck", ParentId = null, Start = "2026-07-21", Duration = 4, Progress = 0, Resources = ["Guybrush"], Color = "#b02a37", Icon = "fas fa-skull-crossbones" },
                new RestApiGanttTask { Id = "m2", Label = "Rescue Elaine", ParentId = null, Start = "2026-07-27", Duration = 0, Progress = 0, Icon = "fas fa-heart" }
            ];
        }

        /// <summary>
        /// Seeds the dependencies between the plan's tasks.
        /// </summary>
        /// <returns>The seeded links.</returns>
        private static List<RestApiGanttLink> SeedLinks()
        {
            return
            [
                new RestApiGanttLink { Id = "l1", From = "t1", To = "t4", Type = "FS" },
                new RestApiGanttLink { Id = "l2", From = "t3", To = "t4", Type = "FS" },
                new RestApiGanttLink { Id = "l3", From = "t4", To = "t5", Type = "FS" },
                new RestApiGanttLink { Id = "l4", From = "t5", To = "m1", Type = "FS" },
                new RestApiGanttLink { Id = "l5", From = "m1", To = "t6", Type = "FS" },
                new RestApiGanttLink { Id = "l6", From = "t6", To = "m2", Type = "FS" }
            ];
        }

        /// <summary>
        /// Returns a defensive copy of a task, so the stored instance is never
        /// handed out and later mutated through the response object.
        /// </summary>
        /// <param name="task">The task to copy.</param>
        /// <returns>The copy.</returns>
        private static RestApiGanttTask Clone(RestApiGanttTask task)
        {
            return new RestApiGanttTask
            {
                Id = task.Id,
                Label = task.Label,
                Start = task.Start,
                End = task.End,
                Duration = task.Duration,
                Progress = task.Progress,
                Resources = task.Resources is null ? null : [.. task.Resources],
                ParentId = task.ParentId,
                Color = task.Color,
                Icon = task.Icon
            };
        }

        /// <summary>
        /// Returns a defensive copy of a link.
        /// </summary>
        /// <param name="link">The link to copy.</param>
        /// <returns>The copy.</returns>
        private static RestApiGanttLink Clone(RestApiGanttLink link)
        {
            return new RestApiGanttLink
            {
                Id = link.Id,
                From = link.From,
                To = link.To,
                Type = link.Type
            };
        }
    }
}
