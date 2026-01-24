using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the tile control for the tutorial.    
    /// </summary>    
    [Title("Tile")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Tile : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Tile(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_VISIBILITY_EVENT, Event.MOVE_EVENT, Event.TILE_SEARCH_EVENT, Event.TILE_SORT_EVENT);

            Stage.Description = @"The `Tile` control class is perfectly suited for visualizing files and folders in a sleek, tile-based interface. It provides an intuitive and visually engaging way to present content, making it ideal for applications such as file managers, explorer views, or media libraries.";

            Stage.Control = new ControlTile(Guid.NewGuid().ToString())
            {
            }
                .Add(GetCards());

            Stage.Code = @"
            new ControlTile()
            {
                null
            }    
                .Add(ControlTileCard().Add(new ControlText(""game-1962-spacewar"") { Text = ""1962 • Spacewar! – Early real-time vector space duel"" }), ...);";

            Stage.AddProperty
            (
                "Header",
                "The `Header` property defines the content displayed in the top section of the component. It typically serves as a title bar or introductory element that summarizes or labels the component’s purpose.",
                "Header = \"Header\"",
                new ControlTile().Add(new ControlTileCard()
                {
                    Header = "Header",
                }
                    .Add(new ControlText() { Text = "With a specified header text." }))
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol displayed in the header section of a tile within the `Tile` control. It serves as a visual identifier, helping users quickly recognize the type or purpose of the item represented by the tile.",
                @"
                new ControlTileCard()
                {
                    Icon = new IconHome()
                }",
                new ControlTile().Add(new ControlTileCard()
                {
                    Icon = new IconHome()
                })
            );

            Stage.AddProperty
            (
                "Color",
                "Sets the color of the tile card, allowing customization for different contexts.",
                "Color = new PropertyColorTile(TypeColorTile.Primary)",
                new ControlTile().Add(new ControlTileCard()
                {
                }.Add(new ControlText() { Text = "Default" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Primary)
                }.Add(new ControlText() { Text = "Primary" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Secondary)
                }.Add(new ControlText() { Text = "Secondary" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Info)
                }.Add(new ControlText() { Text = "Info" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Success)
                }.Add(new ControlText() { Text = "Success" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Warning)
                }.Add(new ControlText() { Text = "Warning" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Danger)
                }.Add(new ControlText() { Text = "Danger" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Dark)
                }.Add(new ControlText() { Text = "Dark" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Light)
                }.Add(new ControlText() { Text = "Light" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.White)
                }.Add(new ControlText() { Text = "White" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile(TypeColorTile.Transparent)
                }.Add(new ControlText() { Text = "Transparent" })),
                new ControlTile().Add(new ControlTileCard()
                {
                    Color = new PropertyColorTile("gold")
                }.Add(new ControlText() { Text = "Custom" }))
            );

            Stage.AddProperty
              (
                  "Movable",
                  @"The `Movable` property in a tile control allows users to rearrange cards interactively. This improves usability by enabling custom ordering of data based on user preferences or workflow requirements.",
                  @"Movable = true",
                  new ControlTile()
                  {
                      Movable = true
                  }
                      .Add(GetCards())
              );

            Stage.AddProperty
              (
                  "AllowRemove",
                  @"The `AllowRemove` property determines whether individual tiles within the `Tile` control can be removed by the user. When set to true, each tile displays a remove button or gesture, enabling interactive deletion of items directly from the interface.",
                  @"AllowRemove = true",
                  new ControlTile()
                  {
                      AllowRemove = true
                  }
                      .Add(GetCards())
              );
        }
        /// <summary>
        /// Returns the 20 influential pre‑1980 game cards as a lazy sequence.
        /// </summary>
        /// <returns>An enumerable of IControlTileCard representing the game cards.</returns>
        private static IEnumerable<IControlTileCard> GetCards()
        {
            yield return Card("game-1962-spacewar", "1962 • Spacewar! – Early real-time vector space duel");
            yield return Card("game-1963-sumerian", "1963 • The Sumerian Game – Educational economic simulation seed");
            yield return Card("game-1968-hammurabi", "1968 • Hammurabi – Text resource management refinement");
            yield return Card("game-1969-spacetravel", "1969 • Space Travel – OS-influencing simulation experiment");
            yield return Card("game-1971-computerspace", "1971 • Computer Space – First commercial arcade video game");
            yield return Card("game-1971-startrek", "1971 • Star Trek (text) – Widely copied BASIC starship tactics");
            yield return Card("game-1972-pong", "1972 • Pong – Arcade mass-market breakthrough");
            yield return Card("game-1972-wumpus", "1972 • Hunt the Wumpus – Early procedural cave logic");
            yield return Card("game-1973-mazewar", "1973 • Maze War – First-person networked multiplayer roots");
            yield return Card("game-1974-dnd", "1974 • dnd (PLATO) – Persistent character RPG dungeon prototype");
            yield return Card("game-1974-grantrak10", "1974 • Gran Trak 10 – Early dedicated racing cabinet design");
            yield return Card("game-1975-gunfight", "1975 • Gun Fight – First microprocessor-based arcade shooter");
            yield return Card("game-1976-breakout", "1976 • Breakout – Paddle reflex design influencing later action");
            yield return Card("game-1976-adventure", "1976 • Colossal Cave Adventure – Text adventure narrative model");
            yield return Card("game-1977-zork", "1977 • Zork (mainframe) – Parser sophistication milestone");
            yield return Card("game-1977-combat", "1977 • Combat (VCS) – Local multiplayer cartridge showcase");
            yield return Card("game-1978-spaceinvaders", "1978 • Space Invaders – Shooter wave design + arcade boom");
            yield return Card("game-1978-adventureland", "1978 • Adventureland – Commercial home micro adventure");
            yield return Card("game-1979-galaxian", "1979 • Galaxian – Color sprite-based formation shooting");
            yield return Card("game-1979-akalabeth", "1979 • Akalabeth – Proto-Ultima first-person RPG groundwork");
        }

        /// <summary>
        /// Creates a ControlTileCard with a single ControlText child.
        /// </summary>
        /// <param name="id">Stable tile identifier.</param>
        /// <param name="text">Displayed full text content.</param>
        /// <returns>Configured ControlTileCard instance.</returns>
        private static ControlTileCard Card(string id, string text)
        {
            var card = new ControlTileCard(id);
            // add main text element
            card.Add(new ControlText() { Text = text });

            return card;
        }
    }
}
