using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Demonstrates the dismissible panel control. The page wires a selectable
    /// list to the panel using the <see cref="BindShow"/> bind, so dismissing
    /// the panel via the "x" and picking another list entry brings the panel
    /// back automatically.
    /// </summary>
    [Title("PanelDismissible")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class PanelDismissible : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PanelDismissible()
        {
            Stage.AddEvent(Event.SELECT_ITEM_EVENT, Event.SHOW_EVENT, Event.HIDE_EVENT);

            Stage.Description = @"A `ControlPanelDismissible` is a container with a title bar and an ""x"" close button in the upper-right corner. The user can dismiss the panel at any time; the panel is brought back automatically when a paired source control (e.g. a `ControlList`) raises a selection event - the wiring is declared by attaching a `BindShow` to the panel's `Bind` property.

Click any entry in the list, then close the panel with the ""x"". Selecting another list entry re-opens the panel through the `show` bind.";

            Stage.Controls =
            [
                new ControlList("characters")
                {
                    Selectable = _ => true
                }
                    .Add(new ControlListItem(null) { Text = _ => "Guybrush Threepwood" })
                    .Add(new ControlListItem(null) { Text = _ => "Elaine Marley" })
                    .Add(new ControlListItem(null) { Text = _ => "LeChuck" })
                    .Add(new ControlListItem(null) { Text = _ => "Stan S. Stanman" }),

                new ControlPanelDismissible("detailPanel")
                {
                    Title = _ => "Details",
                    Bind = _ => new Binding().Add(new BindShow { Source = "characters" }),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
                }
                    .Add(new ControlText() { Text = _ => "Pick an entry on the left, then dismiss this panel with the X button - selecting another entry brings the panel back." })
            ];

            Stage.Code = @"
            new ControlList(""characters"")
            {
                Selectable = _ => true
            }
                .Add(new ControlListItem(null) { Text = _ => ""Guybrush Threepwood"" })
                .Add(new ControlListItem(null) { Text = _ => ""Elaine Marley"" });

            new ControlPanelDismissible(""detailPanel"")
            {
                Title = _ => ""Details"",
                Bind = _ => new Binding().Add(new BindShow { Source = ""characters"" })
            }
                .Add(new ControlText() { Text = _ => ""..."" });";

            Stage.AddProperty
            (
                "Title",
                "The `Title` text is rendered in the panel header next to the dismiss button. It accepts an i18n key.",
                "Title = _ => \"Details\"",
                new ControlPanelDismissible()
                {
                    Title = _ => "Details",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Panel with a title." }),
                new ControlPanelDismissible()
                {
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
                }
                    .Add(new ControlText() { Text = _ => "Panel without a title." })
            );

            Stage.AddProperty
            (
                "InitialHidden",
                "When `InitialHidden` is true the panel starts collapsed. Combined with a `BindShow`, the panel only appears after the first selection.",
                "InitialHidden = _ => true",
                new ControlPanelDismissible("initiallyHidden")
                {
                    Title = _ => "Hidden until shown",
                    InitialHidden = _ => true,
                    Bind = _ => new Binding().Add(new BindShow { Source = "characters" })
                }
                    .Add(new ControlText() { Text = _ => "Initially hidden - select a character above to reveal." })
            );

            Stage.AddProperty
            (
                "Bind (BindShow)",
                "Attach a `BindShow` to the `Bind` property to re-open the panel whenever the source control raises an event - by default `SELECT_ITEM_EVENT` (lists, tiles, trees). A custom event and condition can be supplied to filter, e.g. only opening on non-null selections.",
                "Bind = _ => new Binding().Add(new BindShow { Source = \"characters\" })",
                new ControlPanelDismissible()
                {
                    Title = _ => "Paired with the list above",
                    Bind = _ => new Binding().Add(new BindShow { Source = "characters" })
                }
                    .Add(new ControlText() { Text = _ => "Listens to SELECT_ITEM_EVENT on #characters." })
            );
        }
    }
}
