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
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandWorkflow()
        {
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
            return
            [
                new RestApiWorkflowState
                {
                    Id = "todo",
                    Label = "Quest Board",
                    X = 100,
                    Y = 120,
                    BackgroundColor = "#eef6fb",
                    ForegroundColor = "#0077be",
                    Icon = "fas fa-map",
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
                    Icon = "fas fa-hat-cowboy",
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
                    Icon = "fas fa-skull-crossbones",
                    Shape = "circle",
                    Layout = "label-below"
                },
                new RestApiWorkflowState
                {
                    Id = "done",
                    Label = "Legendary Status",
                    X = 850,
                    Y = 200,
                    BackgroundColor = "#e8eaf6",
                    ForegroundColor = "#512da8",
                    Icon = "fas fa-trophy",
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