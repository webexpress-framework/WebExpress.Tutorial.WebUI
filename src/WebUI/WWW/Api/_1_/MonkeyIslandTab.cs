using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides the REST tab endpoint for the Monkey Island tab demo. The tabs
    /// are held in a thread-safe in-memory store so that creating, removing and
    /// reordering them (drag and drop with the ⠿ grip) persists across reloads.
    /// </summary>
    public sealed class MonkeyIslandTab : RestApiTab<Game>
    {
        private static readonly object _syncRoot = new();

        private static readonly List<RestApiTabView> _views =
        [
            new RestApiTabView
            {
                Id = "tab_island",
                Title = "Islands",
                Name = "All known islands",
                Icon = "fas fa-umbrella-beach",
                // the badge previews how many locations the view contains
                Badge = ViewModel.MonkeyIslandLocations.Count.ToString(),
                TemplateId = "monkeyTemplate",
                Uri = "/api/tabcontent/islands"
            },
            new RestApiTabView
            {
                Id = "tab_pirates",
                Title = "Pirates",
                Name = "Pirate leaders and crews",
                Icon = "fas fa-skull-crossbones",
                Badge = ViewModel.MonkeyIslandCharacters.Count.ToString(),
                TemplateId = "monkeyTemplate",
                Uri = "/api/tabcontent/pirates"
            },
            new RestApiTabView
            {
                Id = "tab_inventory",
                Title = "Inventory",
                Name = "Guybrush's Inventory",
                Icon = "fas fa-box",
                Badge = ViewModel.MonkeyIslandInventories.Count.ToString(),
                TemplateId = "monkeyTemplate",
                Uri = "/api/tabcontent/inventory"
            },
            new RestApiTabView
            {
                Id = "tab_secrets",
                Title = "Secrets",
                Name = "Rumors & hidden places",
                Icon = "fas fa-map-marked-alt",
                // the colored badge marks the fresh rumors as an eye-catcher
                Badge = "3",
                BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger),
                TemplateId = "monkeyTemplate",
                Uri = "/api/tabcontent/secrets"
            }
        ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandTab()
        {
        }

        /// <summary>
        /// Retrieves the collection of tab views in their current order.
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
            lock (_syncRoot)
            {
                return [.. _views];
            }
        }

        /// <summary>
        /// Creates a new tab view and appends it to the in-memory store.
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
            var view = new RestApiTabView
            {
                Id = "tab_dynamic_" + DateTime.Now.Ticks,
                Title = "New Tab",
                Name = "A dynamically created Monkey Island tab",
                Icon = "fas fa-star",
                TemplateId = "monkeyTemplate"
            };

            lock (_syncRoot)
            {
                _views.Add(view);
            }

            return view;
        }

        /// <summary>
        /// Removes the tab view with the specified id from the in-memory store.
        /// </summary>
        /// <param name="viewId">The id of the view to remove.</param>
        /// <returns>
        /// <see langword="true"/> when the view existed and was removed; otherwise <see langword="false"/>.
        /// </returns>
        protected override bool RemoveView(string viewId)
        {
            lock (_syncRoot)
            {
                var existing = _views.FirstOrDefault(v => string.Equals(v.Id, viewId, StringComparison.OrdinalIgnoreCase));
                if (existing is null)
                {
                    return false;
                }

                _views.Remove(existing);
                return true;
            }
        }

        /// <summary>
        /// Applies a new tab order to the in-memory store. Views not mentioned
        /// in the order keep their relative order and are appended at the end.
        /// </summary>
        /// <param name="order">The ordered list of tab ids in their new sequence.</param>
        /// <param name="context">The query context.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns><see langword="true"/> when the order was applied.</returns>
        protected override bool ReorderViews(IReadOnlyList<string> order, IQueryContext context, IRequest request)
        {
            lock (_syncRoot)
            {
                var byId = _views.ToDictionary(v => v.Id, v => v);
                var reordered = new List<RestApiTabView>();

                foreach (var id in order)
                {
                    if (byId.TryGetValue(id, out var view))
                    {
                        reordered.Add(view);
                        byId.Remove(id);
                    }
                }

                // keep any views that were not part of the order payload
                reordered.AddRange(_views.Where(v => byId.ContainsKey(v.Id)));

                _views.Clear();
                _views.AddRange(reordered);

                return true;
            }
        }
    }
}
