using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the relation view demo page for the tutorial. Hosts a
    /// <see cref="ControlDataRelationView"/> for the quest "Become a mighty pirate",
    /// connected to the <see cref="MonkeyIslandRelation"/> endpoint (load, add,
    /// change and remove), the <see cref="MonkeyIslandRelationSystem"/> endpoint
    /// (the systems the add dialog offers) and the
    /// <see cref="MonkeyIslandRelationTarget"/> endpoint (the target search). The
    /// seed relates the quest to a sword fight it blocks, to a treasure hunt
    /// that caused it, to two inventory items it references, to a suspiciously
    /// similar undead pirate and to two addresses outside the game.
    /// </summary>
    [WebIcon<IconLink>]
    [Title("DataRelationView")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataRelationView : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataRelationView(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlDataRelationView` renders the link surface of one object: every semantic relation it holds, grouped by what the relation says, as a list or as a graph. Two categories are supported natively and share one entity - links between two objects of the application and links to an address outside it - and both are listed together. Picking a link opens its detail dialog; `+ Relation` opens the framework sidebar dialog that establishes a new one. The control emits only the host element; the surface is built by the client-side `webexpress.webapp.RelationViewCtrl`, which reads the relations and the linkable systems from the server at request time. A relation or a whole system a plugin contributes therefore appears here without a change to this page.";

            Stage.Controls =
            [
                new ControlDataRelationView("tutorial-link-quest")
                {
                    Subject = _ => MonkeyIslandRelationStore.Subject,
                    SubjectClass = _ => "Quest"
                }
                    .DataService<MonkeyIslandRelation>()
                    .SystemsService<MonkeyIslandRelationSystem>()
                    .TargetsService<MonkeyIslandRelationTarget>()
            ];

            Stage.Code = @"
            new ControlDataRelationView(""tutorial-link-quest"")
            {
                Subject = _ => ""QST-00123"",
                SubjectClass = _ => ""Quest""
            }
                .DataService<MonkeyIslandRelation>()
                .SystemsService<MonkeyIslandRelationSystem>()
                .TargetsService<MonkeyIslandRelationTarget>();";

            Stage.AddProperty
            (
                "Layout",
                @"`Layout` decides whether the surface draws itself as a card or flat as a section of the page it sits in. The flat layout drops the border, the card and the filled toolbar and keeps only the quiet label with its count and a hairline across the remaining width - for a page that reads as one column of sections.",
                @"new ControlDataRelationView(""tutorial-relation-flat"")
                {
                    Layout = _ => TypeLayoutRelationView.Flat
                }
                    .DataService<MonkeyIslandRelation>();",
                new ControlDataRelationView("tutorial-relation-flat")
                {
                    Subject = _ => MonkeyIslandRelationStore.Subject,
                    SubjectClass = _ => "Quest",
                    Layout = _ => TypeLayoutRelationView.Flat
                }
                    .DataService<MonkeyIslandRelation>()
                    .SystemsService<MonkeyIslandRelationSystem>()
                    .TargetsService<MonkeyIslandRelationTarget>()
            );

            Stage.AddProperty
            (
                "Further views",
                @"The surface brings the list and the graph. A page adds a further way of reading the same relations with `Add(...)`, and a plugin adds one through a fragment placed in one of the `SectionRelationView*` sections - without the page hosting the surface knowing about it. A contributed view is rendered on the server and handed to the client as a pane, so it may use any control of the framework.",
                @"new ControlDataRelationView(""tutorial-relation-views"")
                    .Add(new ControlDataRelationViewItem(""crew"")
                    {
                        Label = _ => ""Crew"",
                        Icon = _ => new IconUsers()
                    }
                        .Add(new ControlText() { Text = _ => ""Who sails with this quest."" }))
                    .DataService<MonkeyIslandRelation>();",
                BuildViews()
            );

            Stage.AddProperty
            (
                "View",
                @"The same relations are rendered as a list or as a graph around the object, with the object itself marked. The graph is derived from the links that are already loaded, so switching the presentation costs no round trip and the two views can never disagree.",
                @"new ControlDataRelationView(""tutorial-relation-graph"")
                {
                    View = _ => ""graph""
                }
                    .DataService<MonkeyIslandRelation>();",
                new ControlDataRelationView("tutorial-relation-graph")
                {
                    Subject = _ => MonkeyIslandRelationStore.Subject,
                    SubjectClass = _ => "Quest",
                    View = _ => "graph"
                }
                    .DataService<MonkeyIslandRelation>()
                    .SystemsService<MonkeyIslandRelationSystem>()
                    .TargetsService<MonkeyIslandRelationTarget>()
            );

            Stage.AddProperty
            (
                "Header",
                @"Every part of the header is optional: `HeaderIcon`, `HeaderText` and `HeaderBadge` switch the icon, the caption and the count off one by one. A page that already names the section around the surface turns off what it would otherwise say twice; with all three off the header is left out entirely, so it does not claim the gap of the toolbar, and the presentation switch and the add affordance move up into its place.",
                @"new ControlDataRelationView(""tutorial-relation-header"")
                {
                    HeaderIcon = _ => false,
                    HeaderText = _ => false,
                    HeaderBadge = _ => false
                }
                    .DataService<MonkeyIslandRelation>();",
                new ControlText() { Text = _ => "Without the count", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDataRelationView("tutorial-relation-header-badge")
                {
                    Subject = _ => MonkeyIslandRelationStore.Subject,
                    SubjectClass = _ => "Quest",
                    HeaderBadge = _ => false
                }
                    .DataService<MonkeyIslandRelation>()
                    .SystemsService<MonkeyIslandRelationSystem>()
                    .TargetsService<MonkeyIslandRelationTarget>(),
                new ControlText() { Text = _ => "Without a header at all", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDataRelationView("tutorial-relation-header")
                {
                    Subject = _ => MonkeyIslandRelationStore.Subject,
                    SubjectClass = _ => "Quest",
                    HeaderIcon = _ => false,
                    HeaderText = _ => false,
                    HeaderBadge = _ => false
                }
                    .DataService<MonkeyIslandRelation>()
                    .SystemsService<MonkeyIslandRelationSystem>()
                    .TargetsService<MonkeyIslandRelationTarget>()
            );

            Stage.AddProperty
            (
                "Readonly",
                @"A read-only surface renders the relations for reading alone: the add affordance and the actions of the detail dialog are suppressed.",
                @"new ControlDataRelationView(""tutorial-relation-readonly"")
                {
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandRelation>();",
                new ControlDataRelationView("tutorial-relation-readonly")
                {
                    Subject = _ => MonkeyIslandRelationStore.Subject,
                    SubjectClass = _ => "Quest",
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandRelation>()
                    .SystemsService<MonkeyIslandRelationSystem>()
                    .TargetsService<MonkeyIslandRelationTarget>()
            );

            Stage.AddEvent
            (
                Event.RELATION_ADDED_EVENT,
                Event.RELATION_UPDATED_EVENT,
                Event.RELATION_REMOVED_EVENT
            );
        }

        /// <summary>
        /// Builds the surface of the further views example: the two built-in
        /// presentations plus one the page contributed, which a plugin would add
        /// through a fragment instead.
        /// </summary>
        /// <returns>The surface.</returns>
        private static ControlDataRelationView BuildViews()
        {
            var control = new ControlDataRelationView("tutorial-relation-views")
            {
                Subject = _ => MonkeyIslandRelationStore.Subject,
                SubjectClass = _ => "Quest"
            }
                .DataService<MonkeyIslandRelation>()
                .SystemsService<MonkeyIslandRelationSystem>()
                .TargetsService<MonkeyIslandRelationTarget>();

            control.Add(new ControlDataRelationViewItem("crew")
            {
                Label = _ => "Crew",
                Icon = _ => new IconUsers()
            }
                .Add(new ControlText() { Text = _ => "Who sails with this quest. A contributed view renders on the server, so it may use any control of the framework." }));

            return control;
        }
    }
}
