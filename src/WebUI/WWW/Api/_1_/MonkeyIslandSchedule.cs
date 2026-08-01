using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Provides a Monkey Island themed schedule endpoint: the appointments of
    /// Guybrush's quest through the Caribbean. Backs the data service of the
    /// <c>ControlDataSchedule</c> control, which queries the period it shows and
    /// persists the moves the visitor makes.
    /// </summary>
    /// <remarks>
    /// The tutorial has no database behind it, so the edited appointments live
    /// in a process wide store. Without one a move would report success and the
    /// entry would jump back on the next navigation, which reads as "saving is
    /// broken".
    /// </remarks>
    [Segment("schedule")]
    [Title("Monkey Island Schedule")]
    public sealed class MonkeyIslandSchedule : RestApiSchedule
    {
        private static readonly object _syncRoot = new();
        private static readonly List<RestApiScheduleItem> _items = [.. Seed()];
        private static int _nextId = 100;

        /// <summary>
        /// Retrieves the appointments overlapping the requested period. The
        /// overlap rather than the start decides, so a voyage that began in the
        /// previous month still shows on the days it covers in this one.
        /// </summary>
        /// <param name="from">The first day of the period, or null.</param>
        /// <param name="to">The day after the period, or null.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The appointments.</returns>
        protected override IEnumerable<RestApiScheduleItem> RetrieveItems(DateTime? from, DateTime? to, IRequest request)
        {
            lock (_syncRoot)
            {
                return
                [
                    .. _items
                        .Where(x => Overlaps(x, from, to))
                        .Select(Clone)
                ];
            }
        }

        /// <summary>
        /// Creates an appointment and assigns it an identifier.
        /// </summary>
        /// <param name="item">The appointment to create.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The created appointment.</returns>
        protected override RestApiScheduleItem Create(RestApiScheduleItem item, IRequest request)
        {
            lock (_syncRoot)
            {
                item.Id = $"i{_nextId++}";
                _items.Add(Clone(item));

                return item;
            }
        }

        /// <summary>
        /// Updates an appointment, which is the path a move takes.
        /// </summary>
        /// <param name="item">The appointment to update.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>The updated appointment, or null when the id is unknown.</returns>
        protected override RestApiScheduleItem Update(RestApiScheduleItem item, IRequest request)
        {
            lock (_syncRoot)
            {
                var index = _items.FindIndex(x => x.Id == item.Id);
                if (index < 0)
                {
                    return null;
                }

                // only the period travels with a move; the presentation stays
                // with the stored appointment so a drag cannot strip its colour
                var stored = _items[index];
                stored.Start = item.Start;
                stored.End = item.End;
                stored.AllDay = item.AllDay;

                if (!string.IsNullOrEmpty(item.Title))
                {
                    stored.Title = item.Title;
                }

                return Clone(stored);
            }
        }

        /// <summary>
        /// Deletes an appointment.
        /// </summary>
        /// <param name="id">The identifier of the appointment.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>True when the appointment was deleted.</returns>
        protected override bool Delete(string id, IRequest request)
        {
            lock (_syncRoot)
            {
                return _items.RemoveAll(x => x.Id == id) > 0;
            }
        }

        /// <summary>
        /// Determines whether an appointment overlaps a period.
        /// </summary>
        /// <param name="item">The appointment.</param>
        /// <param name="from">The first day of the period, or null.</param>
        /// <param name="to">The day after the period, or null.</param>
        /// <returns>True when the appointment is visible in the period.</returns>
        private static bool Overlaps(RestApiScheduleItem item, DateTime? from, DateTime? to)
        {
            if (from is null && to is null)
            {
                return true;
            }

            var start = DateTime.TryParse(item.Start, out var parsedStart) ? parsedStart : DateTime.MinValue;
            var end = DateTime.TryParse(item.End, out var parsedEnd) ? parsedEnd : start;

            return (to is null || start < to.Value) && (from is null || end >= from.Value);
        }

        /// <summary>
        /// Copies an appointment, so the store cannot be mutated through a
        /// reference that leaked into a response.
        /// </summary>
        /// <param name="item">The appointment.</param>
        /// <returns>The copy.</returns>
        private static RestApiScheduleItem Clone(RestApiScheduleItem item)
        {
            return new RestApiScheduleItem
            {
                Id = item.Id,
                Title = item.Title,
                Start = item.Start,
                End = item.End,
                AllDay = item.AllDay,
                Category = item.Category,
                ColorCss = item.ColorCss,
                Icon = item.Icon,
                Meta = item.Meta
            };
        }

        /// <summary>
        /// Builds the appointments the tutorial starts from.
        /// </summary>
        /// <returns>The seed appointments.</returns>
        private static IEnumerable<RestApiScheduleItem> Seed()
        {
            return
            [
                new RestApiScheduleItem
                {
                    Id = "standup",
                    Title = "Crew meeting",
                    Start = Format(new DateTime(2026, 8, 12, 9, 0, 0)),
                    End = Format(new DateTime(2026, 8, 12, 9, 30, 0)),
                    Category = "crew",
                    Icon = "fas fa-compass"
                },
                new RestApiScheduleItem
                {
                    Id = "insult",
                    Title = "Insult sword fighting",
                    Start = Format(new DateTime(2026, 8, 12, 10, 0, 0)),
                    End = Format(new DateTime(2026, 8, 12, 12, 0, 0)),
                    Category = "training",
                    ColorCss = "bg-warning",
                    Icon = "fas fa-hat-cowboy"
                },
                new RestApiScheduleItem
                {
                    Id = "grog",
                    Title = "Grog at the Scumm Bar",
                    Start = Format(new DateTime(2026, 8, 12, 11, 0, 0)),
                    End = Format(new DateTime(2026, 8, 12, 13, 0, 0)),
                    Category = "crew",
                    Icon = "fas fa-beer-mug-empty"
                },
                new RestApiScheduleItem
                {
                    Id = "voyage",
                    Title = "Voyage to Monkey Island",
                    Start = Format(new DateTime(2026, 8, 5)),
                    End = Format(new DateTime(2026, 8, 9)),
                    AllDay = true,
                    Category = "voyage",
                    ColorCss = "bg-success",
                    Icon = "fas fa-sailboat",
                    Meta = new Dictionary<string, string> { ["ship"] = "Sea Monkey" }
                },
                new RestApiScheduleItem
                {
                    Id = "showdown",
                    Title = "Showdown with LeChuck",
                    Start = Format(new DateTime(2026, 8, 20)),
                    End = Format(new DateTime(2026, 8, 22)),
                    AllDay = true,
                    Category = "quest",
                    ColorCss = "bg-danger",
                    Icon = "fas fa-skull-crossbones"
                },
                new RestApiScheduleItem
                {
                    Id = "wedding",
                    Title = "Wedding with Elaine",
                    Start = Format(new DateTime(2026, 9, 3, 14, 0, 0)),
                    End = Format(new DateTime(2026, 9, 3, 18, 0, 0)),
                    Category = "quest",
                    Icon = "fas fa-trophy"
                }
            ];
        }
    }
}
