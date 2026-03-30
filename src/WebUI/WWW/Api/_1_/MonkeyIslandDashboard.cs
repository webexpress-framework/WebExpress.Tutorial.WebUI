using System.Collections.Generic;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a REST API dashboard with Monkey Island themed content for every widget template.
    /// </summary>
    public sealed class MonkeyIslandDashboard : RestApiDashboard
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandDashboard()
        {
        }

        /// <summary>
        /// This method defines the columns and widgets for the dashboard. Each widget is 
        /// themed around Monkey Island locations, inventory items, and crew members.
        /// </summary>
        /// <param name="request">The incoming request context.</param>
        /// <returns>A sequence of configured dashboard columns.</returns>
        protected override IEnumerable<RestApiDashboardColumn> RetrieveColumns(IRequest request)
        {
            return
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
        }
    }
}