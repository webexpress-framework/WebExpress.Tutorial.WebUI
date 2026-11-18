using System.Net.Http;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the assignment demo page for the tutorial. Hosts a
    /// <see cref="ControlDataAssignment"/> connected to the <see cref="MonkeyIslandAssignment"/>
    /// endpoint, which holds the assignee of the quest log, and to the
    /// <see cref="MonkeyIslandWatcherUsers"/> directory for the "assign to" search. The
    /// visitor plays Guybrush Threepwood; Captain LeChuck refuses every assignment.
    /// </summary>
    [WebIcon<IconUserCheck>]
    [Title("DataAssignment")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataAssignment : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataAssignment(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlDataAssignment` shows the person responsible for an object as one row: a round portrait or the initials, a small caption above the name and the action at the end of the row. A caller who may change the assignment gets ""Assign to me"" or ""Unassign"", and with a bound users service also ""Assign to …"", which opens a live search. The client-side `webexpress.webapp.AssignmentCtrl` stores every change through the REST endpoint, a `RestApiAssignment<TIndexItem>`, and redraws the row from its answer without reloading the page. The row is rendered on the server already and seeded with `Assignee`, `Self` and `MayChange`, so it needs no first request. In this demo you play Guybrush Threepwood; Captain LeChuck refuses every assignment, and the row keeps its assignee while the reason appears.";

            Stage.Controls =
            [
                new ControlDataAssignment("tutorial-assignee-quest")
                {
                    Assignee = _ => MonkeyIslandAssignment.CurrentAssignee,
                    Self = _ => MonkeyIslandAssignment.CurrentSelf,
                    MayChange = _ => true
                }
                    .DataService<MonkeyIslandAssignment>()
                    .UsersService<MonkeyIslandWatcherUsers>()
            ];

            Stage.Code = @"
            new ControlDataAssignment(""tutorial-assignee-quest"")
            {
                Assignee = _ => MonkeyIslandAssignment.CurrentAssignee,
                Self = _ => MonkeyIslandAssignment.CurrentSelf,
                MayChange = _ => true
            }
                .DataService<MonkeyIslandAssignment>()
                .UsersService<MonkeyIslandWatcherUsers>();";

            Stage.AddProperty
            (
                "Readonly",
                "With `Readonly` the row offers no action, whatever the endpoint reports about the caller's rights. Left unseeded, it loads the assignee from the endpoint on mount. It is bound to the same quest, whose changes are announced on its domain, so it follows the row above.",
                @"
                new ControlDataAssignment(""a"")
                {
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandAssignment>()",
                new ControlDataAssignment("tutorial-assignee-quest-ro")
                {
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandAssignment>()
            );

            Stage.AddProperty
            (
                "Texts",
                "`Caption`, `Placeholder`, `AssignToMeText`, `UnassignText` and `AssignToText` replace the default texts; each takes an i18n key or plain text. Without a users service the row offers only assigning and unassigning.",
                @"
                new ControlDataAssignment(""a"")
                {
                    Caption = _ => ""Quest leader"",
                    Placeholder = _ => ""Nobody has the map yet"",
                    AssignToMeText = _ => ""Take the lead"",
                    UnassignText = _ => ""Hand back the map""
                }
                    .DataService<MonkeyIslandAssignment>()",
                new ControlDataAssignment("tutorial-assignee-quest-texts")
                {
                    Caption = _ => "Quest leader",
                    Placeholder = _ => "Nobody has the map yet",
                    AssignToMeText = _ => "Take the lead",
                    UnassignText = _ => "Hand back the map"
                }
                    .DataService<MonkeyIslandAssignment>()
            );

            Stage.AddProperty
            (
                "ViewState binding",
                "`ControlDataAssignment` is ViewState-capable. Bound to a resource of an enclosing `ControlViewState` with `Resource<TResource>()`, the assignment becomes a slice of the ViewState's shared state: the ViewState loads it centrally, a change is stored through the ViewState's service for the resource and the resource is queried again. Here two rows share one `AssignmentResource`; a change in either one shows up in both, and the search uses the users service of the ViewState.",
                @"
                new ControlViewState<DataQueryState>(""assigneeScope"")
                    .State(s => { })
                    .Service<MonkeyIslandAssignment>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Service<MonkeyIslandWatcherUsers>(svc => svc.Method(HttpMethod.Get))
                    .Resource<AssignmentResource>(r => r.Service<MonkeyIslandAssignment>());

                new ControlDataAssignment(""assigneeEdit"")
                    .Resource<AssignmentResource>()
                    .UsersService<MonkeyIslandWatcherUsers>();

                new ControlDataAssignment(""assigneeView"")
                {
                    Caption = _ => ""Also responsible""
                }
                    .Resource<AssignmentResource>()
                    .UsersService<MonkeyIslandWatcherUsers>();",
                new ControlViewState<DataQueryState>("assigneeScope")
                    .State(s => { })
                    .Service<MonkeyIslandAssignment>(svc => svc.Method(HttpMethod.Get).UpdateMethod(HttpMethod.Put))
                    .Service<MonkeyIslandWatcherUsers>(svc => svc.Method(HttpMethod.Get))
                    .Resource<AssignmentResource>(r => r.Service<MonkeyIslandAssignment>()),
                new ControlDataAssignment("assigneeEdit")
                    .Resource<AssignmentResource>()
                    .UsersService<MonkeyIslandWatcherUsers>(),
                new ControlDataAssignment("assigneeView")
                {
                    Caption = _ => "Also responsible"
                }
                    .Resource<AssignmentResource>()
                    .UsersService<MonkeyIslandWatcherUsers>()
            );
        }
    }
}
