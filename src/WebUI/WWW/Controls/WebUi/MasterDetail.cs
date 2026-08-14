using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the master-detail control for the tutorial.
    /// </summary>
    [WebIcon<IconControlMasterDetail>]
    [Title("Master Detail")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class MasterDetail : PageControl
    {
        private readonly IPageContext _pageContext;
        private readonly ISitemapManager _sitemapManager;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the master-detail control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public MasterDetail(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            _pageContext = pageContext;
            _sitemapManager = sitemapManager;

            Stage.AddEvent(Event.SELECT_ITEM_EVENT, Event.SHOW_EVENT, Event.HIDE_EVENT, Event.BREAKPOINT_CHANGE_EVENT);

            Stage.Description = @"The `MasterDetail` control turns two independent controls into one master-detail view: an enumeration control on the left, a detail region on the right, and the selection state that ties them together. It owns the layout and the selected id but none of the content - the master side takes any control that renders selectable items and the detail side is a `ControlFrame` that loads its content on demand, so neither half needs to know the other.

The splitter is not reimplemented: the control renders a `ControlPanelSplit`, which contributes dragging, the persisted size and the min/max constraints. Both columns scroll on their own, the selected item is highlighted, and while nothing is selected the detail side shows a placeholder. The detail content spans the full width of its column and carries a close button floating in the top right corner; using it hides the splitter along with the detail and gives the whole container to the master, and selecting an item brings both back at the previous splitter position. The master is the navigation of the view and therefore never collapsible - the splitter stops at `MasterMinSize` instead of dragging it out of sight.

Below the configured breakpoint (768 px of container width by default) the control switches to a sequential single-column mode: the list fills the container, a selection slides the detail in as an overlay, and a back button leads to the list again. Keyboard operation follows the listbox pattern - arrow keys navigate, Enter and Space activate - and the items are exposed as `role=""option""` of a `role=""listbox""`.";

            Stage.Control = CreateMasterDetail("myMasterDetail", withActions: true);
            Stage.DarkControls = [CreateMasterDetail("myMasterDetailDark", withActions: true)];

            Stage.Code = @"
                new ControlMasterDetail(""myMasterDetail"")
                {
                    MasterMinSize = _ => 180,
                    Detail = new ControlFrame(""myMasterDetail-frame"") { Selector = _ => ""#wx-content-main"" }
                }
                    .AddMaster(new ControlList() { Title = _ => ""Characters"", Selectable = _ => true }
                        .Add(ViewModel.MonkeyIslandCharacters.Select(x => new ControlListItem(x.Id.ToString())
                        {
                            Text = _ => x.Name,
                            PrimaryAction = _ => new ActionMasterDetail
                            (
                                ""myMasterDetail"",
                                sitemapManager.GetUri<MasterDetailItem>(pageContext.ApplicationContext)
                                    .Add(new UriQuery(""id"", x.Id.ToString())),
                                x.Id.ToString()
                            )
                        })));";

            Stage.AddProperty
            (
                "Master",
                "The `Master` side accepts any list-based control. It is injected instead of constructed, which is what keeps the composite reusable: the same layout serves a `ControlList`, a `ControlTile` grid, a `ControlTable` or a backlog. The control relies only on the item markup, not on the control that produced it - here the very same detail side is driven by a tile grid.",
                "AddMaster(new ControlTile() { ... })",
                new ControlMasterDetail("myMasterDetailTile")
                {
                    Styles = ["--wx-master-detail-height: 24rem;"],
                    MasterInitialSize = _ => 45,
                    DetailUriTemplate = _ => DetailUri("{id}"),
                    Detail = CreateFrame("myMasterDetailTile-frame")
                }
                    .AddMaster(new ControlTile(null, [.. Characters.Select(x => (IControlTileCard)new ControlTileCard(x.Id.ToString())
                    {
                        Header = _ => x.Name
                    }
                        .Add(new ControlText() { Text = _ => x.Description }))]))
            );

            Stage.AddProperty
            (
                "Detail",
                "The `Detail` side is a `ControlFrame`, so the detail content is fetched only when an item is selected instead of being rendered up front for every row. Arriving content is animated into place, which turns a swap from one item to the next into a transition rather than a jump. Injecting a pre-configured frame is the hook for a detail view that needs its own settings - all examples on this page use a frame whose `Selector` embeds only the main content region of the loaded page rather than the whole document.",
                "Detail = new ControlFrame(\"myDetailFrame\") { Selector = _ => \"#wx-content-main\" }",
                CreateMasterDetail("myMasterDetailFrame")
            );

            Stage.AddProperty
            (
                "DetailUriTemplate",
                "The `DetailUriTemplate` property resolves the detail uri for items that carry an id but no uri of their own. The `{id}` placeholder is replaced by the id of the selected item, which keeps the master control free of any routing knowledge - the list below carries plain ids and no action at all.",
                "DetailUriTemplate = _ => \"/webui/controls/webui/masterdetailitem?id={id}\"",
                CreateMasterDetail("myMasterDetailTemplate", withActions: false)
            );

            Stage.AddProperty
            (
                "EmptyState",
                "The `EmptyState` property defines the placeholder the detail side shows while no item is selected. It is a full `ControlEmptyState`, so an icon, a headline, a message and call-to-action controls are all available; leaving it untouched yields the localized default.",
                "EmptyState = new ControlEmptyState() { Icon = _ => new IconUserAstronaut(), Title = _ => \"No character selected\" }",
                CreateMasterDetail("myMasterDetailEmpty", withActions: false, configure: control =>
                {
                    control.EmptyState = new ControlEmptyState()
                    {
                        Icon = _ => new IconUserAstronaut(),
                        Title = _ => "No character selected",
                        Message = _ => "Pick a pirate from the list to read their story."
                    };
                })
            );

            Stage.AddProperty
            (
                "MasterInitialSize",
                "The `MasterInitialSize`, `MasterMinSize`, `MasterMaxSize` and `Unit` properties are handed to the splitter. The initial size is expressed in the configured unit - percent by default, so the master takes roughly a third of the width - while the minimum and the maximum bound what a drag may reach and are always pixels. `MasterMinSize` is a hard floor rather than a hint: the master is rendered as a non-collapsible pane, so dragging the splitter all the way to the edge leaves the minimum standing instead of taking the list off screen.",
                "MasterInitialSize = _ => 50, Unit = _ => TypeSizeUnit.Percent",
                CreateMasterDetail("myMasterDetailSize", withActions: false, configure: control =>
                {
                    control.MasterInitialSize = _ => 50;
                    control.MasterMinSize = _ => 160;
                    control.MasterMaxSize = _ => 480;
                    control.Unit = _ => TypeSizeUnit.Percent;
                })
            );

            Stage.AddProperty
            (
                "Closable",
                "The detail side carries a close button in its top right corner - the same one the modal and the dismissible panel use - so it can be put away without a control of its own; the master then fills the whole container and a selection brings the detail back at the previous splitter position. The button floats on the pane rather than sitting in a bar, so the detail content keeps the full width. Set `Closable` to false for a view whose detail side must always stay open; the toggle action and the client-side api keep working.",
                "Closable = _ => false",
                CreateMasterDetail("myMasterDetailClosable", withActions: false, configure: control =>
                {
                    control.Closable = _ => false;
                })
            );

            Stage.AddProperty
            (
                "DetailVisible",
                "The `DetailVisible` property decides whether the detail side is shown initially. A hidden detail side takes the splitter with it, so the master alone fills the container; selecting an item - or the `ActionMasterDetailToggle` action on any control, as on the button below - brings both back at the position the splitter had before.",
                "DetailVisible = _ => false",
                new ControlButton()
                {
                    Text = _ => "Show / hide detail",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionMasterDetailToggle("myMasterDetailHidden"),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                },
                CreateMasterDetail("myMasterDetailHidden", withActions: false, configure: control =>
                {
                    control.DetailVisible = _ => false;
                })
            );

            Stage.AddProperty
            (
                "Breakpoint",
                "The `Breakpoint` property sets the width below which the control switches to the sequential single-column mode. The width of the *container* is measured rather than of the viewport, so a control inside a narrow column behaves like one on a narrow screen. The example below uses a deliberately large breakpoint, so the sequential mode - the list first, the detail sliding in as an overlay with a back button - can be seen without resizing the browser.",
                "Breakpoint = _ => 4000",
                CreateMasterDetail("myMasterDetailCompact", withActions: false, configure: control =>
                {
                    control.Breakpoint = _ => 4000;
                })
            );
        }

        /// <summary>
        /// Gets the sample characters shown in the master side.
        /// </summary>
        private static IEnumerable<Character> Characters => ViewModel.MonkeyIslandCharacters.Take(8);

        /// <summary>
        /// Builds one of the example controls. The detail endpoint is a regular
        /// page of this application, so the frame embeds only its main content
        /// region instead of the whole document.
        /// </summary>
        /// <param name="id">The id of the control, which the items and actions target.</param>
        /// <param name="withActions">
        /// True to give every item the selection action, false to let the items
        /// carry only their id and resolve the uri through the template.
        /// </param>
        /// <param name="configure">An optional callback for the property being demonstrated.</param>
        /// <returns>The control.</returns>
        private ControlMasterDetail CreateMasterDetail(string id, bool withActions = false, System.Action<ControlMasterDetail> configure = null)
        {
            var control = new ControlMasterDetail(id)
            {
                Styles = ["--wx-master-detail-height: 24rem;"],
                MasterMinSize = _ => 180,
                DetailUriTemplate = withActions ? null : _ => DetailUri("{id}"),
                Detail = CreateFrame($"{id}-frame")
            }
                .AddMaster(CreateCharacterList(id, withActions)) as ControlMasterDetail;

            configure?.Invoke(control);

            return control;
        }

        /// <summary>
        /// Builds the detail frame.
        /// </summary>
        /// <param name="id">The id of the frame.</param>
        /// <returns>The frame control.</returns>
        private static ControlFrame CreateFrame(string id)
        {
            return new ControlFrame(id)
            {
                Selector = _ => "#wx-content-main"
            };
        }

        /// <summary>
        /// Builds the uri of the detail endpoint for a character.
        /// </summary>
        /// <param name="id">The character id, or the "{id}" placeholder of a uri template.</param>
        /// <returns>The uri as a string.</returns>
        private string DetailUri(string id)
        {
            return _sitemapManager
                .GetUri<MasterDetailItem>(_pageContext.ApplicationContext)
                .Add(new UriQuery("id", id))
                .ToString();
        }

        /// <summary>
        /// Builds the master list.
        /// </summary>
        /// <param name="target">The id of the master-detail control the items belong to.</param>
        /// <param name="withActions">
        /// True to give every item the selection action, which hands the click to
        /// the master-detail control instead of writing to its frame directly, so
        /// the composite stays the single owner of the selection.
        /// </param>
        /// <returns>The list control.</returns>
        private ControlList CreateCharacterList(string target, bool withActions)
        {
            return new ControlList(null, [.. Characters.Select(character => new ControlListItem(character.Id.ToString())
            {
                Text = _ => character.Name,
                PrimaryAction = withActions
                    ? _ => new ActionMasterDetail
                    (
                        target,
                        new UriEndpoint(DetailUri(character.Id.ToString())),
                        character.Id.ToString()
                    )
                    : null
            })])
            {
                Title = _ => "Characters",
                Selectable = _ => true
            };
        }
    }
}
