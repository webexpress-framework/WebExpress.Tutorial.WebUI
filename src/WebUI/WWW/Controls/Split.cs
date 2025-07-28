using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the Split control for the tutorial.    
    /// </summary>    
    [Title("Split")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Split : PageControl
    {
        private readonly ControlAlert _sidePanel = new ControlAlert()
        {
            Head = "Side panel",
            Text = "Side panel content ...",
            Dismissible = TypeDismissibleAlert.None
        };

        private readonly ControlAlert _mainPanel = new ControlAlert()
        {
            Head = "Main panel ",
            Text = "Main panel content ...",
            Dismissible = TypeDismissibleAlert.None
        };


        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the Split control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing page navigation.</param>  
        public Split(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.SHOW_EVENT, Event.HIDE_EVENT, Event.SIZE_CHANGE_EVENT);

            Stage.Description = @"The `Split` element serves as a simple yet effective component for visual separation within a user interface. Typically rendered as a horizontal line, it helps organize content and improve readability by clearly delineating sections or groups of information.";

            Stage.Control = new ControlPanelSplit("mySplit")
            {
            }
                .AddSidePanel(_sidePanel)
                .AddMainPanel(_mainPanel);

            Stage.Code = @"
                new ControlPanelSplit(""mySplit"")
                {
                }
                    .AddSidePanel(new ControlAlert() { Head = ""Panel 1"", Text = ""Panel 1 content ..."", Dismissible = TypeDismissibleAlert.None })
                    .AddMainPanel(new ControlAlert() { Head = ""Panel 2"", Text = ""Panel 2 content ..."", Dismissible = TypeDismissibleAlert.None });";


            Stage.AddProperty
            (
                "Orientation",
                "The `Orientation` property defines the split direction of a splitter control, determining how the side and main panes are arranged relative to each other.",
                "Orientation = TypeOrientationSplit.Horizontal",
                new ControlText() { Text = "Horizontal", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Orientation = TypeOrientationSplit.Horizontal
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Vertical", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Orientation = TypeOrientationSplit.Vertical
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
            );

            Stage.AddProperty
            (
                "SplitterColor",
                "The `SplitterColor` property defines the visual appearance of the splitter bar that separates two panels within a splitter control. It determines the exact color used to render this dividing line, ensuring it stands out or blends in with the overall design of the user interface. This property solely influences the splitter’s appearance and does not affect the behavior or content of the panels it divides.",
                "SplitterColor = new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Default)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Primary)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Info)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Success)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Warning)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Danger)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Dark)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground(TypeColorBackground.Light)
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Custom", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    SplitterColor = new PropertyColorBackground("gold")
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
            );

            Stage.AddProperty
            (
                "SplitterSize",
                "The `SplitterSize` property defines the thickness or width of the splitter bar that separates the two panels in a splitter control. This size determines how much screen space the splitter occupies—horizontally in a vertical layout or vertically in a horizontal layout.",
                "SplitterSize = 20",
                new ControlPanelSplit()
                {
                    SplitterSize = 20
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
             );

            Stage.AddProperty
            (
                "SidePanelInitialSize",
                "The `SidePanelInitialSize` property specifies the default width or height—depending on orientation—of one of the panels within a splitter control when it is first rendered. This size determines how much space the specified panel occupies before the user interacts with the splitter to resize it.",
                "SplitterSize = 100",
                new ControlPanelSplit()
                {
                    SidePanelInitialSize = 100
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
             );

            Stage.AddProperty
            (
                "SidePanelMinSize",
                "The `SidePanelMinSize` property defines the minimum allowable width or height—depending on the layout orientation—of the side panel in a splitter control. Its primary role is to restrict how far the user can collapse or shrink the SidePanel during a resizing operation. This ensures that the content within the panel remains accessible and usable, preventing layout issues or hidden UI elements.",
                "SidePanelMinSize = 100",
                new ControlPanelSplit()
                {
                    SidePanelMinSize = 100
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
            );

            Stage.AddProperty
            (
                "SidePanelMaxSize",
                "The `SidePanelMaxSize` property defines the maximum width or height (depending on orientation) that the side panel in a splitter control can occupy. It sets an upper limit on how far the user can expand the panel when resizing, ensuring that the SidePanel does not consume more screen space than intended.",
                "SidePanelMaxSize = 300",
                new ControlPanelSplit()
                {
                    SidePanelMaxSize = 300
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
            );

            Stage.AddProperty
            (
                "Order",
                "The `Order` property defines the layout sequence of the side and main panes within a splitter control. Depending on the chosen orientation (horizontal or vertical), Order determines whether the Side pane appears before or after themMain pane.",
                "Order = TypeSplitOrder.MainSide",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Order = TypeSplitOrder.Default
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "SideMain", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Order = TypeSplitOrder.SideMain
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "MainSide", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Order = TypeSplitOrder.MainSide
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
            );

            Stage.AddProperty
            (
                "Unit",
                "The `Unit` property specifies the measurement unit used to define the size and positioning values within the splitter control layout. This allows for flexible styling based on fixed or relative dimensions.",
                "Unit = TypeSizeUnit.Percent",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Unit = TypeSizeUnit.Default,
                    SidePanelInitialSize = 10

                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Pixel", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Unit = TypeSizeUnit.Pixel,
                    SidePanelInitialSize = 10
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Percent", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Unit = TypeSizeUnit.Percent,
                    SidePanelInitialSize = 10
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Em", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Unit = TypeSizeUnit.Em,
                    SidePanelInitialSize = 10
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel),
                new ControlText() { Text = "Rem", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlPanelSplit()
                {
                    Unit = TypeSizeUnit.Rem,
                    SidePanelInitialSize = 10
                }.AddSidePanel(_sidePanel).AddMainPanel(_mainPanel)
            );
        }
    }
}
