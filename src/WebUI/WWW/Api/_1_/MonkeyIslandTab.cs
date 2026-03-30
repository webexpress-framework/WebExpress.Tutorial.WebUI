using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    public sealed class MonkeyIslandTab : RestApiTab<Game>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandTab()
        {
        }

        /// <summary>
        /// Retrieves the collection of tab views associated with the specified request.
        /// </summary>
        /// <param name="context">
        /// The context in which the query is executed. Provides additional information or constraints 
        /// for the retrieval operation. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request for which to retrieve tab views. Must not be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of tab views for the specified request. Returns 
        /// an empty collection if no states are available.
        /// </returns>
        protected override IEnumerable<RestApiTabView> RetrieveViews(IQueryContext context, IRequest request)
        {
            return
            [
                new RestApiTabView
                {
                    Id = "tab_island",
                    Title = "Islands",
                    Name = "All known islands",
                    Icon = "fas fa-umbrella-beach",
                    TemplateId = "monkeyTemplate",
                    Uri = "/api/tabcontent/islands"
                },
                new RestApiTabView
                {
                    Id = "tab_pirates",
                    Title = "Pirates",
                    Name = "Pirate leaders and crews",
                    Icon = "fas fa-skull-crossbones",
                    TemplateId = "monkeyTemplate",
                    Uri = "/api/tabcontent/pirates"
                },
                new RestApiTabView
                {
                    Id = "tab_inventory",
                    Title = "Inventory",
                    Name = "Guybrush's Inventory",
                    Icon = "fas fa-box",
                    TemplateId = "monkeyTemplate",
                    Uri = "/api/tabcontent/inventory"
                },
                new RestApiTabView
                {
                    Id = "tab_secrets",
                    Title = "Secrets",
                    Name = "Rumors & hidden places",
                    Icon = "fas fa-map-marked-alt",
                    TemplateId = "monkeyTemplate",
                    Uri = "/api/tabcontent/secrets"
                }
            ];
        }

        /// <summary>
        /// Creates a new instance of a REST API tab view based on the specified
        /// query context and request.
        /// </summary>
        /// <param name="context">
        /// The query context that provides information about the current state 
        /// and parameters of the query.
        /// </param>
        /// <param name="request">
        /// The request object containing details of the REST API call to be 
        /// represented in the view.
        /// </param>
        /// <returns>
        /// An object that implements the IRestApiTabView interface, representing 
        /// the created view for the specified request and context.
        /// </returns>
        protected override IRestApiTabView CreateView(IQueryContext context, IRequest request)
        {
            return new RestApiTabView
            {
                Id = "tab_dynamic_" + DateTime.Now.Ticks,
                Title = "New Tab",
                Name = "A dynamically created Monkey Island tab",
                Icon = "fas fa-star",
                TemplateId = "monkeyTemplate"
            };
        }
    }
}