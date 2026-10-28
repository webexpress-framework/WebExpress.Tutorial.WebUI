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
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Table.Templates
{
    /// <summary>
    /// Represents the phone template of the REST table control for the tutorial.
    /// </summary>
    [WebIcon<IconPhone>]
    [Title("Phone-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Phone : PageControl
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
        public Phone(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Phone` template displays telephone numbers within a REST table column: the flag of the country and a link that dials the number in ReadOnly mode, and the phone field with its country picker in Edit mode. A cell holds the number in E.164 form; the endpoint declares the country an empty cell starts in.";

            Stage.Controls =
            [
                new ControlDataTable("myTable")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTablePhone>(),
            ];

            Stage.DarkControls =
            [
                new ControlDataTable("myTableDark")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTablePhone>()
            ];

            Stage.Code = @"
                new ControlDataTable(""myTable"")
                {
                    PageSize = _=> 5
                }
                    .DataService<MonkeyIslandCharacterTablePhone>()

                // in the endpoint
                protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
                    new RestApiTableColumnTemplatePhone(true, ""JM"");";
        }
    }
}
