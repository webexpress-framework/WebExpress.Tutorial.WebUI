using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a REST API dashboard with Monkey Island themed content for every widget template.
    /// The columns are held in a thread-safe in-memory store so that renaming,
    /// reordering and deleting them persists across reloads.
    /// </summary>
    public sealed class MonkeyIslandDashboard : RestApiDashboard
    {
        private static readonly object _syncRoot = new();

        private static readonly List<RestApiDashboardColumn> _columns =
            [
                new RestApiDashboardColumn
                {
                    Id = "info",
                    Label = "Locations",
                    Size = "33%",
                    Widgets = new List<RestApiDashboardWidget>
                    {
                        new RestApiDashboardWidgetInfo
                        {
                            Color = "brown",
                            Movable = true,
                            Title = "Scumm Bar",
                            Description = "Infamous pirate tavern at Mêlée Island's docks. Best place to overhear sailing rumors."
                        },
                        new RestApiDashboardWidgetInfo
                        {
                            Color = "purple",
                            Movable = true,
                            Title = "Voodoo Shop",
                            Description = "Seek mystical advice from the Voodoo Lady. Ingredients for curses in stock!"
                        }
                    }
                },
                new RestApiDashboardColumn
                {
                    Id = "inventory",
                    Label = "Inventory",
                    Size = "33%",
                    Widgets =
                    [
                        new RestApiDashboardWidgetList
                        {
                            Color = "yellow",
                            Movable = true,
                            Items =
                            [
                                "Rubber Chicken with a Pulley in the Middle",
                                "Breath Mints",
                                "Mêlée Island Map"
                            ]
                        },
                        new RestApiDashboardWidgetProgress
                        {
                            Color = "cyan",
                            Movable = true,
                            Value = 75, // Prozentwert
                            ProgressColor = "success"
                        },
                        new RestApiDashboardWidgetBigNumber
                        {
                            Color = "gold",
                            Movable = true,
                            Value = "1,000,000",
                            Label = "Pieces of Eight Collected"
                        }
                    ]
                },
                new RestApiDashboardColumn
                {
                    Id = "crew",
                    Label = "Crew",
                    Size = "1fr",
                    Widgets =
                    [
                        new RestApiDashboardWidgetAvatar
                        {
                            Color = "green",
                            Movable = true,
                            Name = "Carla",
                            Caption = "Sword Master of Mêlée Island"
                        },
                        new RestApiDashboardWidgetAvatar
                        {
                            Color = "red",
                            Movable = true,
                            Name = "Meathook",
                            Caption = "Owner of Hook Isle. Afraid of parrots"
                        },
                        new RestApiDashboardWidgetStats
                        {
                            Color = "teal",
                            Movable = true,
                            Title = "Monkey Island Status",
                            Uptime = "Always open for adventure"
                        }
                    ]
                }
            ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandDashboard()
        {
        }

        /// <summary>
        /// Returns the current dashboard columns (with their widgets).
        /// </summary>
        /// <param name="request">The incoming request context.</param>
        /// <returns>A snapshot of the configured dashboard columns.</returns>
        protected override IEnumerable<RestApiDashboardColumn> RetrieveColumns(IRequest request)
        {
            lock (_syncRoot)
            {
                return [.. _columns];
            }
        }

        /// <summary>
        /// Applies a column-layout change (rename / reorder / delete) to the
        /// in-memory store. Widgets stay attached to their (surviving) columns.
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
                var reordered = new List<RestApiDashboardColumn>();

                foreach (var col in layout.Columns)
                {
                    if (string.IsNullOrWhiteSpace(col?.Id) || !byId.TryGetValue(col.Id, out var existing))
                    {
                        continue;
                    }

                    existing.Label = col.Title ?? existing.Label;
                    if (!string.IsNullOrWhiteSpace(col.Size))
                    {
                        existing.Size = col.Size;
                    }
                    reordered.Add(existing);
                }

                _columns.Clear();
                _columns.AddRange(reordered);
            }
        }
    }
}