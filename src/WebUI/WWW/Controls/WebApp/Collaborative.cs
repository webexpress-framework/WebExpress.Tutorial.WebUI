using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the collaborative control demo page for the tutorial.
    /// </summary>
    [WebIcon<IconUsers>]
    [Title("Collaborative")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Collaborative : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        public Collaborative(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"The `Collaborative` control wraps the JavaScript collaboration module and enables real-time interaction inside a shared container. Open this page in two browser sessions to manually test presence chips, remote cursor movement and synchronized inputs.

Both kinds of field take part. The plain text field is mirrored per keystroke; the rich-text surface is mirrored as markup, coalesced to one message every 250 ms and applied through the editor's own value API, so tables and add-ons keep their frames and the hidden form input stays in sync. A field the local user is currently typing in is never overwritten - the state converges when they leave it.

The container id is the routing channel: only clients rendering the same id see each other.";

            Stage.Controls =
            [
                new ControlCollaborative("collaborative-demo")
                {
                    Presence = _ => true,
                    Cursor = _ => true,
                    Input = _ => true,
                    ColorMode = _ => "auto"
                }
                .Add
                (
                    new ControlText()
                    {
                        Text = _ => "Open the same page in multiple tabs or browsers. Move the mouse in the area below and type into the fields to observe collaborative updates.",
                        Format = _ => TypeFormatText.Paragraph,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    },
                    new ControlForm("collaborative-form")
                    {
                        Uri = _ => pageContext.Route.ToUri()
                    }
                    .Add
                    (
                        new ControlFormItemInputText("collaborative-subject")
                            .Initialize(x => x.Value.Text = "collaborative demo"),
                        new ControlFormItemInputText("collaborative-notes")
                        {
                            Format = _ => TypeEditTextFormat.Wysiwyg,
                            Rows = _ => 5
                        }
                        .Initialize(x => x.Value.Text = "Type here in one session and watch the markup arrive in the other.")
                    )
                )
            ];

            Stage.Code = @"
            new ControlCollaborative(""collaborative-demo"")
            {
                Presence = _ => true,
                Cursor = _ => true,
                Input = _ => true,
                ColorMode = _ => ""auto""
            }
            .Add
            (
                new ControlForm(""collaborative-form"")
                {
                    Uri = _ => pageContext.Route.ToUri()
                }
                .Add
                (
                    new ControlFormItemInputText(""collaborative-subject"")
                        .Initialize(x => x.Value.Text = ""collaborative demo""),
                    new ControlFormItemInputText(""collaborative-notes"")
                    {
                        Format = _ => TypeEditTextFormat.Wysiwyg,
                        Rows = _ => 5
                    }
                    .Initialize(x => x.Value.Text = ""Test presence, cursor, and input sync together."")
                )
            );";
        }
    }
}
