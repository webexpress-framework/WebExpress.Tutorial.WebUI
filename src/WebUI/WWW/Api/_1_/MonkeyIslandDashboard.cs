using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a REST API dashboard with Monkey Island themed content for every widget template.
    /// The columns are held in a thread-safe in-memory store so that renaming,
    /// reordering, deleting and adding columns and widgets persists across reloads.
    /// </summary>
    public sealed class MonkeyIslandDashboard : RestApiDashboard
    {
        private const string ScrumVelocityWidgetId = "widget_scrum_velocity";

        private static readonly object _syncRoot = new();

        // demo sprint history for the velocity widget, oldest sprint first; kept
        // as the json the widget seeds its wx-state island from
        private static readonly string _demoSprintsJson = JsonSerializer.Serialize(new[]
        {
            new { id = "s1", name = "Plank", committed = 30, completed = 24 },
            new { id = "s2", name = "Grog", committed = 32, completed = 30 },
            new { id = "s3", name = "Parrot", committed = 34, completed = 28 },
            new { id = "s4", name = "Cutlass", committed = 33, completed = 33 },
            new { id = "s5", name = "Doubloon", committed = 36, completed = 31 },
            new { id = "s6", name = "Kraken", committed = 35, completed = 37 }
        });

        private static readonly List<RestApiDashboardColumn> _columns =
            [
                new RestApiDashboardColumn
                {
                    Id = "info",
                    Label = "Locations",
                    Size = "33%",
                    Color = "#0d6efd",
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
                    Color = "#20c997",
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
                    Color = "#fd7e14",
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
                        },
                        new RestApiDashboardWidgetGeneric(ScrumVelocityWidgetId)
                        {
                            Color = "cyan",
                            Movable = true,
                            Title = "Crew Velocity",
                            Params = new Dictionary<string, string>
                            {
                                ["maxSprints"] = "6",
                                ["sprints"] = _demoSprintsJson
                            }
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

        // the widget types this board offers for adding; the server owns the set,
        // so only these can be placed on the dashboard
        private static readonly List<RestApiDashboardAvailableWidget> _availableWidgets =
            [
                new() { Id = ScrumVelocityWidgetId, Title = "Velocity", Icon = "fas fa-chart-column", Description = "Sprint velocity chart" },
                new() { Id = "widget_info", Title = "Location", Icon = "fas fa-map-location-dot", Description = "A place on the map" },
                new() { Id = "widget_list", Title = "Inventory", Icon = "fas fa-list", Description = "A bullet list of items" },
                new() { Id = "widget_progress", Title = "Progress", Icon = "fas fa-tasks", Description = "A progress bar" },
                new() { Id = "widget_bignumber", Title = "Treasure", Icon = "fas fa-hashtag", Description = "A big number KPI" },
                new() { Id = "widget_avatar", Title = "Crew member", Icon = "fas fa-user", Description = "An avatar card" }
            ];

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
        /// Returns the widget types the board may add.
        /// </summary>
        /// <param name="request">The incoming request context.</param>
        /// <returns>The available widget descriptors.</returns>
        protected override IEnumerable<RestApiDashboardAvailableWidget> RetrieveAvailableWidgets(IRequest request)
        {
            return _availableWidgets;
        }

        /// <summary>
        /// Applies a column-layout change (add / rename / reorder / delete) to the
        /// in-memory store. A column absent from the payload is dropped, an unknown
        /// id is created, and surviving columns keep their widgets.
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
                    if (string.IsNullOrWhiteSpace(col?.Id))
                    {
                        continue;
                    }

                    if (byId.TryGetValue(col.Id, out var existing))
                    {
                        existing.Label = col.Title ?? existing.Label;
                        if (!string.IsNullOrWhiteSpace(col.Size))
                        {
                            existing.Size = col.Size;
                        }
                        // color is nullable and clearing it back to none is valid
                        existing.Color = col.Color;
                        reordered.Add(existing);
                    }
                    else
                    {
                        reordered.Add(new RestApiDashboardColumn
                        {
                            Id = col.Id,
                            Label = col.Title ?? string.Empty,
                            Size = string.IsNullOrWhiteSpace(col.Size) ? "1fr" : col.Size,
                            Color = col.Color,
                            Widgets = new List<RestApiDashboardWidget>()
                        });
                    }
                }

                _columns.Clear();
                _columns.AddRange(reordered);
            }
        }

        /// <summary>
        /// Rebuilds the board from a full update, persisting widget additions,
        /// deletions and settings. Widgets are stored as generic widgets carrying
        /// the client type id and params; a velocity widget is backfilled with the
        /// demo sprint history when it arrives without one.
        /// </summary>
        /// <param name="board">The full board carried in the request.</param>
        /// <param name="request">The incoming request.</param>
        protected override void UpdateBoard(IEnumerable<RestApiDashboardBoardColumn> board, IRequest request)
        {
            if (board is null)
            {
                return;
            }

            lock (_syncRoot)
            {
                var rebuilt = new List<RestApiDashboardColumn>();

                foreach (var col in board)
                {
                    if (col is null || string.IsNullOrWhiteSpace(col.Id))
                    {
                        continue;
                    }

                    var widgets = new List<RestApiDashboardWidget>();

                    foreach (var widget in col.Widgets ?? Enumerable.Empty<RestApiDashboardBoardWidget>())
                    {
                        if (widget is null || string.IsNullOrWhiteSpace(widget.Id))
                        {
                            continue;
                        }

                        var generic = new RestApiDashboardWidgetGeneric(widget.Id)
                        {
                            Title = widget.Title,
                            Color = widget.Color,
                            Movable = true,
                            Params = widget.Params != null
                                ? new Dictionary<string, string>(widget.Params)
                                : new Dictionary<string, string>()
                        };

                        EnrichWidget(generic);
                        widgets.Add(generic);
                    }

                    rebuilt.Add(new RestApiDashboardColumn
                    {
                        Id = col.Id,
                        Label = col.Title ?? string.Empty,
                        Size = string.IsNullOrWhiteSpace(col.Size) ? "1fr" : col.Size,
                        Color = col.Color,
                        Widgets = widgets
                    });
                }

                _columns.Clear();
                _columns.AddRange(rebuilt);
            }
        }

        /// <summary>
        /// Backfills a freshly added velocity widget with the demo sprint history
        /// and a default sprint count, so a widget added through the board menu
        /// paints real data even though the client sends it without any.
        /// </summary>
        /// <param name="widget">The widget to enrich.</param>
        private static void EnrichWidget(RestApiDashboardWidgetGeneric widget)
        {
            if (widget.Id != ScrumVelocityWidgetId)
            {
                return;
            }

            widget.Params ??= new Dictionary<string, string>();

            if (!widget.Params.ContainsKey("maxSprints"))
            {
                widget.Params["maxSprints"] = "6";
            }

            if (!widget.Params.TryGetValue("sprints", out var sprints) || string.IsNullOrWhiteSpace(sprints))
            {
                widget.Params["sprints"] = _demoSprintsJson;
            }
        }
    }
}