using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a REST API kanban with Monkey Island themed content for every widget template.
    /// </summary>
    public sealed class MonkeyIslandKanban : RestApiKanban<Curse>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandKanban()
        {
        }

        /// <summary>
        /// This method defines the columns for the kanban. Each card is 
        /// themed around Monkey Island.
        /// </summary>
        /// <param name="request">The incoming request context.</param>
        /// <returns>A sequence of configured kanban columns.</returns>
        public override IEnumerable<RestApiKanbanColumn> RetrieveColumns(IRequest request)
        {
            return
            [
                new RestApiKanbanColumn { Id = "todo",     Label = "Trials",        ColorCss = "bg-light text-dark" },
                new RestApiKanbanColumn { Id = "progress", Label = "Adventure",     ColorCss = "bg-primary text-white" },
                new RestApiKanbanColumn { Id = "danger",   Label = "Danger Zone",   ColorCss = "bg-danger text-white" },
                new RestApiKanbanColumn { Id = "done",     Label = "Legendary Feats", ColorCss = "bg-success text-white" }
            ];
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
        public override IEnumerable<RestApiKanbanSwimlane> RetrieveSwimlanes(IRequest request)
        {
            return
            [
                new RestApiKanbanSwimlane { Id = "melee",      Label = "Mêlée Island",       ColorCss = "bg-secondary text-white", Expanded = true },
                new RestApiKanbanSwimlane { Id = "monkey",     Label = "Monkey Island",      ColorCss = "bg-warning text-dark",    Expanded = true },
                new RestApiKanbanSwimlane { Id = "lechuck",    Label = "LeChuck's Fortress", ColorCss = "bg-dark text-white",      Expanded = false }
            ];
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
        public override IEnumerable<RestApiKanbanCard> RetrieveCards(IQuery<Curse> query, IQueryContext context, IRequest request)
        {
            return
            [
                new RestApiKanbanCard
                {
                    Id = "k1",
                    Label = "Swordfighting Training",
                    Html = "Face Carla and become the Sword Master.",
                    ColumnId = "progress",
                    SwimlaneId = "melee",
                    ColorCss = "border-primary"
                },
                new RestApiKanbanCard
                {
                    Id = "k2",
                    Label = "Steal the Idol",
                    Html = "Infiltrate the Governor's mansion and snatch the voodoo idol.",
                    ColumnId = "danger",
                    SwimlaneId = "melee",
                    ColorCss = "border-danger"
                },
                new RestApiKanbanCard
                {
                    Id = "k3",
                    Label = "Assemble Crew",
                    Html = "Recruit Carla, Otis and Meathook to sail to Monkey Island.",
                    ColumnId = "todo",
                    SwimlaneId = "melee"
                },
                new RestApiKanbanCard
                {
                    Id = "k4",
                    Label = "Find Secret of Monkey Island",
                    Html = "Explore and find the fabled secret.",
                    ColumnId = "todo",
                    SwimlaneId = "monkey"
                },
                new RestApiKanbanCard
                {
                    Id = "k5",
                    Label = "Defeat LeChuck",
                    Html = "Confront LeChuck and save Elaine.",
                    ColumnId = "done",
                    SwimlaneId = "lechuck",
                    ColorCss = "border-success"
                }
            ];
        }
    }
}