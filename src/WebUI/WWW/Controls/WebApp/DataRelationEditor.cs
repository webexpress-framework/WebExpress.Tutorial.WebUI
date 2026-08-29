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
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the relation editor demo page for the tutorial. Hosts a
    /// <see cref="ControlDataRelationEditor"/> administering the relations the class
    /// 'Quest' may hold, connected to the <see cref="MonkeyIslandRelationType"/>
    /// endpoint. What is defined here is immediately available on the
    /// <see cref="DataRelationView"/> page, because both read the same registry the
    /// endpoint writes.
    /// </summary>
    [WebIcon<IconLinks>]
    [Title("DataRelationEditor")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataRelationEditor : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="sitemapManager">The sitemap manager.</param>
        public DataRelationEditor(IPageContext pageContext, IComponentHub componentHub, ISitemapManager sitemapManager)
        {
            Stage.Description = @"`ControlDataRelationEditor` administers the relation types of a class: how a relation reads from either end, which classes it accepts as a target, how often it may meet at each end (`1:1`, `1:n`, `n:1`, `n:n`), what it does to the workflow, how heavily it is already used and whether it may still be used at all. It is the administrative half of the link system - what is defined here is immediately available to `ControlDataRelationView` and to its add dialog. The control emits only the host element; the table and its editor are built by the client-side `webexpress.webapp.RelationEditorCtrl`.";

            Stage.Controls =
            [
                new ControlDataRelationEditor("tutorial-link-type-quest")
                {
                    Class = _ => "Quest",
                    Sample = _ => MonkeyIslandRelationStore.Subject
                }
                    .DataService<MonkeyIslandRelationType>()
            ];

            Stage.Code = @"
            new ControlDataRelationEditor(""tutorial-link-type-quest"")
            {
                Class = _ => ""Quest"",
                Sample = _ => ""QST-00123""
            }
                .DataService<MonkeyIslandRelationType>();";

            Stage.AddProperty
            (
                "Sample",
                @"The editor previews the relation from both ends, so the person defining it reads the sentence their colleagues will read. `Sample` is the example key the preview is written with; without it the class name is used.",
                @"new ControlDataRelationEditor(""tutorial-relation-editor-preview"")
                {
                    Class = _ => ""Quest"",
                    Sample = _ => ""QST-00123""
                }
                    .DataService<MonkeyIslandRelationType>();",
                new ControlDataRelationEditor("tutorial-relation-editor-preview")
                {
                    Class = _ => "Quest",
                    Sample = _ => MonkeyIslandRelationStore.Subject
                }
                    .DataService<MonkeyIslandRelationType>()
            );

            Stage.AddProperty
            (
                "Readonly",
                @"A read-only surface documents the relations without offering to change them: the define affordance, the editor, the reordering and the activation toggle are suppressed.",
                @"new ControlDataRelationEditor(""tutorial-relation-editor-readonly"")
                {
                    Class = _ => ""Quest"",
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandRelationType>();",
                new ControlDataRelationEditor("tutorial-relation-editor-readonly")
                {
                    Class = _ => "Quest",
                    Readonly = _ => true
                }
                    .DataService<MonkeyIslandRelationType>()
            );

            Stage.AddEvent
            (
                Event.RELATION_TYPE_SAVED_EVENT,
                Event.RELATION_TYPE_REMOVED_EVENT,
                Event.RELATION_TYPE_REORDERED_EVENT
            );
        }
    }
}
