using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Table.Templates
{
    /// <summary>
    /// Represents the text template of the REST table control for the tutorial.
    /// </summary>
    [Title("Text-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Text : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">
        /// The context of the page where the table control is used.
        /// </param>
        /// <param name="sitemapManager">
        /// The sitemap manager for managing site navigation.
        /// </param>
        public Text(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Text` template defines how textual values are displayed within a REST table column. The endpoint declares the template on the column, so the client renders a plain text view in ReadOnly mode and a text input in Edit mode without any client-side configuration.";

            Stage.Controls =
            [
                new ControlDataTable("myTable")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableText>(),
            ];

            Stage.DarkControls =
            [
                new ControlDataTable("myTableDark")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableText>()
            ];

            Stage.Code = @"
                new ControlDataTable(""myTable"")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTableText>()";
        }
    }
}
