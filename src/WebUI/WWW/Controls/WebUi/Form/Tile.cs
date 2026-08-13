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
                "MultiSelect = _ => true",
                new ControlForm()
                    .Add
                    (
                        new ControlFormItemInputTile()
                        {
                            MultiSelect = _ => true
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
                "Label = _ => \"Label 1\"",
                new ControlForm(null, new ControlFormItemInputTile() { Label = _ => "Label 1" }.Add(GetCards()))
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a tile box. It provides a visual representation and identification of the input field, enhancing user guidance and recognition.",
                "Icon = _ => new IconHome()",
                new ControlForm(null, new ControlFormItemInputTile() { Icon = _ => new IconHome() }.Add(GetCards()))
            );

            Stage.AddProperty
            (
               "Help",
               "Provides additional guidance or context for the tile picker.",
               "Help =_ =>  \"This is a help text.\"",
               new ControlForm(null, new ControlFormItemInputTile() { Help = _ => "This is a help text." }.Add(GetCards()))
            );

            Stage.AddProperty
            (
                "LargeIcon",
                @"The `LargeIcon` property controls whether tiles within the `Tile` control are displayed with an enlarged icon. When set to true, the icons appear significantly larger and gain more visual prominence, which is especially useful for image‑focused or highlighted elements.",
                @"LargeIcon = _ => true",
                new ControlForm(null, new ControlFormItemInputTile() { LargeIcon = _ => true }.Add(GetCards()))
            );

            Stage.AddProperty
            (
                "Searchable",
                "The `Searchable` property puts a search box above the tiles that narrows them as the term is typed. It matches the label, the kicker and the content of a card, so a long list stays usable without paging. `SearchPlaceholder` sets the wording of the box and `EmptyText` what is shown when nothing is left.",
                "Searchable = _ => true, SearchPlaceholder = _ => \"Search games…\"",
                new ControlForm(null, new ControlFormItemInputTile()
                {
                    Searchable = _ => true,
                    SearchPlaceholder = _ => "Search games…",
                    EmptyText = _ => "No game matches the search."
                }.Add(GetCards()))
            );

            Stage.AddProperty
            (
                "Columns",
                "The `Columns` property lays the tiles out in a grid with a fixed number of them per row instead of letting them flow at their natural width. This suits cards carrying a description, which read better wide than narrow.",
                "Columns = _ => 2",
                new ControlForm(null, new ControlFormItemInputTile()
                {
                    Columns = _ => 2
                }.Add(GetRichCards()))
            );

            Stage.AddProperty
            (
                "Card anatomy",
                "A tile card is laid out as kicker, title, body and footer. The `Badge` of a card names the kind it belongs to and is coloured by `BadgeColor`; the `Chip` adds a short qualifier at the trailing end of that row; `AddFooter` puts metadata below the description, separated from it. The kind therefore reads before the name of a card and its numbers after its description.",
                "Badge = _ => \"1970s\", Chip = _ => \"Milestone\", card.AddFooter(new ControlText { Text = _ => \"1972\" })",
                new ControlForm(null, new ControlFormItemInputTile()
                {
                    Columns = _ => 2
                }.Add(GetRichCards()))
            );

            Stage.AddProperty
            (
                "FilterSource",
                "The `FilterSource` property narrows the visible tiles to the value of another input, naming the tiles they belong to through `FilterValue`. A tile marked `AlwaysVisible` is exempt from both the filter and the search — use it for the entry that must never fall away because it is the way on, here the \"no preference\" card at the top.",
                "FilterSource = _ => \"Decade\"",
                new ControlForm()
                    .Add(new ControlFormItemInputCombo()
                    {
                        Name = _ => "Decade",
                        Label = _ => "Decade",
                        Placeholder = _ => "Select a decade"
                    }
                        .Add(new ControlFormItemInputComboItem() { Text = _ => "1960s", Value = _ => "1960s" })
                        .Add(new ControlFormItemInputComboItem() { Text = _ => "1970s", Value = _ => "1970s" }) as ControlFormItemInputCombo)
                    .Add(new ControlFormItemInputTile()
                    {
                        Name = _ => "Game",
                        Label = _ => "Game",
                        Columns = _ => 2,
                        Searchable = _ => true,
                        SearchPlaceholder = _ => "Search games…",
                        FilterSource = _ => "Decade"
                    }.Add(GetFilteredCards()))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Bindings",
                "The `Bindings` of a card carry the values behind its label. When the card is selected, each value is written to the form control of that name, to the text of any element marked with `data-wx-bind-text`, and toggles the visibility of any element marked with `data-wx-bind-visible`. A card can therefore stand for more than its label — the references it selects, or a note about what it implies — without a bespoke script. Selecting a game below fills the year field.",
                "Bindings = _ => new Dictionary<string, string> { [\"Year\"] = \"1972\" }",
                new ControlForm()
                    .Add(new ControlFormItemInputTile()
                    {
                        Name = _ => "Game",
                        Label = _ => "Game",
                        Columns = _ => 2
                    }.Add(GetBindingCards()))
                    .Add(new ControlFormItemInputText()
                    {
                        Name = _ => "Year",
                        Label = _ => "Year"
                    })
                    .AddPrimaryButton(new ControlFormItemButtonSubmit())
            );
        }

        /// <summary>
        /// Returns cards using the full card anatomy: a kicker naming the decade, a chip on
        /// the milestones, a description and a footer carrying the year.
        /// </summary>
        /// <returns>An enumerable of IControlTileCard.</returns>
        private static IEnumerable<IControlTileCard> GetRichCards()
        {
            yield return RichCard("game-1962-spacewar", "Spacewar!", "1962", "Early real-time vector space duel.", true);
            yield return RichCard("game-1972-pong", "Pong", "1972", "The arcade mass-market breakthrough.", true);
            yield return RichCard("game-1976-breakout", "Breakout", "1976", "Paddle reflex design influencing later action games.", false);
            yield return RichCard("game-1978-spaceinvaders", "Space Invaders", "1978", "Shooter wave design and the arcade boom.", false);
        }

        /// <summary>
        /// Returns the cards of the filter example: one entry per decade, preceded by the
        /// always visible entry that stays offered whichever decade is selected.
        /// </summary>
        /// <returns>An enumerable of IControlTileCard.</returns>
        private static IEnumerable<IControlTileCard> GetFilteredCards()
        {
            var any = new ControlTileCard("game-any")
            {
                Header = _ => "No preference",
                AlwaysVisible = _ => true
            };
            any.Add(new ControlText() { Text = _ => "Surprise me with any of them." });

            yield return any;

            yield return RichCard("game-1962-spacewar", "Spacewar!", "1962", "Early real-time vector space duel.", true);
            yield return RichCard("game-1968-hammurabi", "Hammurabi", "1968", "Text resource management refinement.", false);
            yield return RichCard("game-1972-pong", "Pong", "1972", "The arcade mass-market breakthrough.", true);
            yield return RichCard("game-1978-spaceinvaders", "Space Invaders", "1978", "Shooter wave design and the arcade boom.", false);
        }

        /// <summary>
        /// Returns cards that project the year they stand for into the form.
        /// </summary>
        /// <returns>An enumerable of IControlTileCard.</returns>
        private static IEnumerable<IControlTileCard> GetBindingCards()
        {
            foreach (var card in new[]
            {
                RichCard("game-1962-spacewar", "Spacewar!", "1962", "Early real-time vector space duel.", true),
                RichCard("game-1972-pong", "Pong", "1972", "The arcade mass-market breakthrough.", true)
            })
            {
                var year = card.Id.Split('-')[1];
                card.Bindings = _ => new Dictionary<string, string> { ["Year"] = year };

                yield return card;
            }
        }

        /// <summary>
        /// Creates a card using the full card anatomy.
        /// </summary>
        /// <param name="id">Stable tile identifier.</param>
        /// <param name="name">The title of the card.</param>
        /// <param name="year">The year, shown in the footer and used as the filter value's decade.</param>
        /// <param name="description">The description shown in the body.</param>
        /// <param name="milestone">Whether the card is marked with a chip.</param>
        /// <returns>Configured ControlTileCard instance.</returns>
        private static ControlTileCard RichCard(string id, string name, string year, string description, bool milestone)
        {
            var decade = year[..3] + "0s";

            var card = new ControlTileCard(id)
            {
                Header = _ => name,
                Icon = _ => new IconGamepad(),
                Badge = _ => decade,
                BadgeColor = _ => new PropertyColorTile(decade == "1960s" ? "#0d6efd" : "#20723d"),
                Chip = _ => milestone ? "Milestone" : null,
                FilterValue = _ => decade
            };

            card.Add(new ControlText() { Text = _ => description });
            card.AddFooter(new ControlText() { Text = _ => year });

            return card;
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
            var card = new ControlTileCard(id)
            {
                Icon = _ => new IconGamepad()
            };
            // add main text element
            card.Add(new ControlText() { Text = _ => text });

            return card;
        }
    }
}
