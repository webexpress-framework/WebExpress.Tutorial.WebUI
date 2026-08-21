using System.Collections.Generic;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a workflow for a kanban board themed around Monkey Island, 
    /// defining custom columns for use in REST API
    /// scenarios.
    /// </summary>
    public sealed class MonkeyIslandWorkflow : RestApiWorkflow
    {
        // the only workflow this tutorial knows; any other id is a miss, which is
        // what makes the 404 path observable
        private const string WorkflowId = "monkeyisland";

        // the tutorial has no database behind it, so the edited definition lives
        // in a process wide store. Without one the editor would report a
        // successful save and still show the seed data after every reload, which
        // reads as "saving is broken".
        private static readonly object _sync = new();
        private static RestApiWorkflowResult _header;
        private static List<RestApiWorkflowState> _states;
        private static List<RestApiWorkflowTransition> _transitions;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandWorkflow()
        {
        }

        /// <summary>
        /// Retrieves the workflow header so the editor's meta panel shows a named,
        /// versioned workflow instead of an anonymous one.
        /// </summary>
        /// <param name="workflowId">
        /// The unique identifier of the workflow to retrieve.
        /// </param>
        /// <param name="context">
        /// The query context providing access to the underlying data store. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The current API request. Cannot be null.
        /// </param>
        /// <returns>
        /// A <see cref="RestApiWorkflowResult"/> carrying the workflow header.
        /// </returns>
        protected override RestApiWorkflowResult Retrieve(string workflowId, IQueryContext context, IRequest request)
        {
            lock (_sync)
            {
                return EnsureSeeded(workflowId) ? _header : null;
            }
        }

        /// <summary>
        /// Persists the definition the editor's autosave delivers, so a reload shows
        /// the edited workflow rather than the seed data. The version is advanced on
        /// every write, which is what lets a second open editor notice that it holds
        /// a stale revision.
        /// </summary>
        /// <param name="workflowId">
        /// The unique identifier of the workflow to update.
        /// </param>
        /// <param name="workflow">
        /// The workflow definition to persist.
        /// </param>
        /// <param name="context">
        /// The query context providing access to the underlying data store. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The current API request. Cannot be null.
        /// </param>
        protected override void Update(string workflowId, RestApiWorkflowResult workflow, IQueryContext context, IRequest request)
        {
            lock (_sync)
            {
                if (!EnsureSeeded(workflowId))
                {
                    return;
                }

                _states = [.. workflow?.States ?? []];
                _transitions = [.. workflow?.Transitions ?? []];

                if (!string.IsNullOrWhiteSpace(workflow?.Name))
                {
                    _header.Name = workflow.Name;
                }
                if (workflow?.Description != null)
                {
                    _header.Description = workflow.Description;
                }

                _header.Version = int.TryParse(_header.Version, out var revision)
                    ? (revision + 1).ToString()
                    : "1";
            }
        }

        /// <summary>
        /// Fills the store with the seed definition on first access.
        /// </summary>
        /// <param name="workflowId">The identifier of the workflow to seed.</param>
        /// <returns>True when the requested workflow exists.</returns>
        private static bool EnsureSeeded(string workflowId)
        {
            if (!string.Equals(workflowId, WorkflowId, System.StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (_header != null)
            {
                return true;
            }

            _header = new RestApiWorkflowResult
            {
                Id = WorkflowId,
                Name = "Monkey Island Quest",
                Version = "1",
                Description = "A pirate's journey from the quest board to legendary status."
            };
            _states = [.. SeedStates()];
            _transitions = [.. SeedTransitions()];
            return true;
        }

        /// <summary>
        /// Retrieves the collection of workflow states associated with the specified request.
        /// </summary>
        /// <param name="workflowId">
        /// The unique identifier of the workflow whose states are to be retrieved.
        /// </param>
        /// <param name="context">
        /// The query context providing access to the underlying data store. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request for which to retrieve workflow states. Must not be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of workflow states for the specified request. Returns 
        /// an empty collection if no states are available.
        /// </returns>
        protected override IEnumerable<RestApiWorkflowState> RetrieveStates(string workflowId, IQueryContext context, IRequest request)
        {
            lock (_sync)
            {
                return EnsureSeeded(workflowId) ? _states : [];
            }
        }

        /// <summary>
        /// Builds the states the tutorial starts from.
        /// </summary>
        /// <returns>The seed states.</returns>
        private static IEnumerable<RestApiWorkflowState> SeedStates()
        {
            return
            [
                new RestApiWorkflowState
                {
                    Id = "todo",
                    Label = "Quest Board",
                    IsStart = true,
                    X = 100,
                    Y = 120,
                    BackgroundColor = "#eef6fb",
                    ForegroundColor = "#0077be",
                    Icon = "wx-icon-light wx-icon-light-map",
                    Shape = "rect",
                    Layout = "label-inside"
                },
                new RestApiWorkflowState
                {
                    Id = "adventure",
                    Label = "Adventuring",
                    X = 350,
                    Y = 160,
                    BackgroundColor = "#e8f5e9",
                    ForegroundColor = "#146c43",
                    Icon = "wx-icon-light wx-icon-light-hat-cowboy",
                    Shape = "rect",
                    Layout = "label-inside"
                },
                new RestApiWorkflowState
                {
                    Id = "danger",
                    Label = "Danger Zone",
                    X = 600,
                    Y = 110,
                    BackgroundColor = "#fff4e5",
                    ForegroundColor = "#b26a00",
                    Icon = "wx-icon-light wx-icon-light-skull-crossbones",
                    Shape = "circle",
                    Layout = "label-below"
                },
                new RestApiWorkflowState
                {
                    Id = "done",
                    Label = "Legendary Status",
                    IsEnd = true,
                    X = 850,
                    Y = 200,
                    BackgroundColor = "#e8eaf6",
                    ForegroundColor = "#512da8",
                    Icon = "wx-icon-light wx-icon-light-trophy",
                    Shape = "rect",
                    Layout = "label-inside"
                }
            ];
        }

        /// <summary>
        /// Retrieves the collection of workflow transitions available for the specified request.
        /// </summary>
        /// <param name="workflowId">
        /// The unique identifier of the workflow whose states are to be retrieved.
        /// </param>
        /// <param name="context">
        /// The query context providing access to the underlying data store. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request for which to retrieve workflow transitions. Cannot be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of workflow transitions associated with the request. Returns 
        /// an empty collection if no transitions are available.
        /// </returns>
        protected override IEnumerable<RestApiWorkflowTransition> RetrieveTransitions(string workflowId, IQueryContext context, IRequest request)
        {
            lock (_sync)
            {
                return EnsureSeeded(workflowId) ? _transitions : [];
            }
        }

        /// <summary>
        /// Builds the transitions the tutorial starts from.
        /// </summary>
        /// <returns>The seed transitions.</returns>
        private static IEnumerable<RestApiWorkflowTransition> SeedTransitions()
        {
            return
            [
                new RestApiWorkflowTransition
                {
                    Id = "t1",
                    From = "todo",
                    To = "adventure",
                    Color = "#007bff",
                    DashArray = "5 2",
                    Waypoints = new List<RestApiWorkflowWaypoint> { new RestApiWorkflowWaypoint { X = 225, Y = 140 } },
                    Label = "Begin Quest",
                    Description = "Start a new pirate quest.",
                    Form = "",
                    Guards =
                    [
                        new RestApiWorkflowGuard
                        {
                            Id = "g1",
                            Type = "condition",
                            Label = "You must be a pirate.",
                            Children = new List<RestApiWorkflowGuard>()
                        }
                    ],
                    Validators =
                    [
                        new RestApiWorkflowValidator
                        {
                            Id = "v1",
                            Type = "condition",
                            Label = "Quest description is not empty",
                            Children = new List<RestApiWorkflowValidator>()
                        }
                    ],
                    PostFunctions =
                    [
                        new RestApiWorkflowPostFunction
                        {
                            Id = "pf1",
                            Type = "action",
                            Label = "Unlock 'Scumm Bar' access"
                        }
                    ]
                },
                new RestApiWorkflowTransition
                {
                    Id = "t2",
                    From = "adventure",
                    To = "danger",
                    Color = "#dc3545",
                    DashArray = "4 2",
                    Waypoints = [new RestApiWorkflowWaypoint { X = 450, Y = 130 }],
                    Label = "Face Danger",
                    Description = "You encounter LeChuck or one of his minions.",
                    Form = "",
                    Guards = [],
                    Validators = [],
                    PostFunctions =
                    [
                        new RestApiWorkflowPostFunction
                        {
                            Id = "pf2",
                            Type = "action",
                            Label = "Set status to 'In Danger'"
                        }
                    ]
                },
                new RestApiWorkflowTransition
                {
                    Id = "t3",
                    From = "danger",
                    To = "done",
                    Color = "#28a745",
                    DashArray = "",
                    Waypoints = [new RestApiWorkflowWaypoint { X = 700, Y = 180 }],
                    Label = "Achieve Victory",
                    Description = "You have completed your legendary quest!",
                    Form = "",
                    Guards = [],
                    Validators = [],
                    PostFunctions =
                    [
                        new RestApiWorkflowPostFunction
                        {
                            Id = "pf3",
                            Type = "action",
                            Label = "Award trophy and pirate title"
                        }
                    ]
                }
            ];
        }
    }
}