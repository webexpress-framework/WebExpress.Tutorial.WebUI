using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>    
    /// Represents the tile picker control for the tutorial.    
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
        /// <param name="pageContext">The context of the page where the text box control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Tile(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CLICK_EVENT, Event.CHANGE_VALUE_EVENT);

            Stage.Description = @"The `TilePicker` control is an interactive card-based selection component. It allows users to choose one or multiple items represented as visual tiles. Each tile can contain text, icons, colors, or custom content, making it ideal for dashboards, category selection, or visually guided input.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputTile().Add(GetCards()))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputTile().Add(GetCards()))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "MultiSelect",
                "The `MultiSelect` property enables selecting more than one tile. " +
                "When set to `true`, users can choose multiple cards; otherwise only a single tile is allowed.",
                "MultiSelect = true",
                new ControlForm()
                    .Add
                    (
                        new ControlFormItemInputTile()
                        {
                            MultiSelect = true
                        }
                            .Add(GetCards())
                            .Initialize(x =>
                            {
                                x.Value.Add("game-1972-pong");
                                x.Value.Add("game-1978-spaceinvaders");
                            })
                    )
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of a tile picker control item serves as a short form of the input text and is displayed in the main area of the control. It ensures a concise and clear representation of the input.",
                "Label = \"Label 1\"",
                new ControlForm(null, new ControlFormItemInputTile() { Label = "Label 1" }.Add(GetCards()))
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a tile box. It provides a visual representation and identification of the input field, enhancing user guidance and recognition.",
                "Icon = new IconHome()",
                new ControlForm(null, new ControlFormItemInputTile() { Icon = new IconHome() }.Add(GetCards()))
            );

            Stage.AddProperty
            (
               "Help",
               "Provides additional guidance or context for the tile picker.",
               "Help = \"This is a help text.\"",
               new ControlForm(null, new ControlFormItemInputTile() { Help = "This is a help text." }.Add(GetCards()))
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
