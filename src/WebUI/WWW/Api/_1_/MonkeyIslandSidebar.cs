using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API that supplies a Monkey Island themed navigation tree
    /// for the data sidebar: headers, links, badges and a two-level hierarchy of
    /// locations. The badge counts are read from the in-memory view model, so the
    /// tutorial shows the sidebar reflecting live server data.
    /// </summary>
    [Title("Monkey Island Navigation")]
    public sealed class MonkeyIslandSidebar : RestApiSidebar
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandSidebar()
        {
        }

        /// <summary>
        /// Builds the navigation tree with a primary section, a nested world
        /// section (locations grouped by island, crew members) and a system
        /// section, decorating several entries with badges.
        /// </summary>
        /// <param name="request">The incoming request context.</param>
        /// <returns>The top level navigation items.</returns>
        protected override IEnumerable<RestApiSidebarItem> RetrieveItems(IRequest request)
        {
            yield return new RestApiSidebarItemHeader("Navigation");

            yield return new RestApiSidebarItem
            {
                Label = "Dashboard",
                Icon = "wx-icon-light wx-icon-light-compass",
                Active = true
            };

            yield return new RestApiSidebarItem
            {
                Label = "Games",
                Icon = "wx-icon-light wx-icon-light-gamepad",
                Badge = ViewModel.MonkeyIslandGames.Count.ToString(),
                BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Primary)
            };

            yield return new RestApiSidebarItem
            {
                Label = "Inventory",
                Icon = "wx-icon-light wx-icon-light-suitcase",
                Badge = ViewModel.MonkeyIslandInventories.Count.ToString()
            };

            yield return new RestApiSidebarItemHeader("World");

            // locations grouped by island demonstrate a two-level hierarchy: each
            // island is a collapsible group whose children are its locations
            yield return new RestApiSidebarItem
            {
                Label = "Locations",
                Icon = "wx-icon-light wx-icon-light-map",
                Expanded = true,
                Items = ViewModel.MonkeyIslandLocations
                    .GroupBy(location => string.IsNullOrWhiteSpace(location.Island) ? "Uncharted Waters" : location.Island)
                    .Select(group => new RestApiSidebarItem
                    {
                        Label = group.Key,
                        Icon = "wx-icon-light wx-icon-light-anchor",
                        Badge = group.Count().ToString(),
                        Items = group
                            .Select(location => new RestApiSidebarItem
                            {
                                Label = location.Text,
                                Icon = "wx-icon-light wx-icon-light-location-dot"
                            })
                            .ToList()
                    })
                    .ToList()
            };

            yield return new RestApiSidebarItem
            {
                Label = "Crew",
                Icon = "wx-icon-light wx-icon-light-users",
                Badge = ViewModel.MonkeyIslandCharacters.Count.ToString(),
                Items = ViewModel.MonkeyIslandCharacters
                    .Select(character => new RestApiSidebarItem
                    {
                        Label = character.Name,
                        Icon = "wx-icon-light wx-icon-light-user"
                    })
                    .ToList()
            };

            yield return new RestApiSidebarItemDivider();

            yield return new RestApiSidebarItemHeader("System");

            yield return new RestApiSidebarItem
            {
                Label = "Messages",
                Icon = "wx-icon-light wx-icon-light-envelope",
                Badge = "3",
                BadgeColor = new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
            };

            yield return new RestApiSidebarItem
            {
                Label = "Settings",
                Icon = "wx-icon-light wx-icon-light-cog"
            };
        }
    }
}
