using System.Net;
using WebExpress.Tutorial.WebUI.Model;
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
using WebExpress.WebUI.WebNotification;

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
            Stage.Description = @"The `Collaborative` control wraps the JavaScript collaboration module and enables real-time interaction inside a shared container. Open this page in two browser sessions to test presence chips, remote cursor movement and shared editing. Because the container names a document scope, the rich-text notes, the WQL query and the spreadsheet are shared documents: several users can type into the same paragraph at the same time, changes travel as operations that the server sequences, remote carets follow the text, and undo takes back only the own edits. The plain text field is mirrored by value per keystroke, as before. The scope names what is edited, so everybody rendering the same scope edits the same documents.";

            Stage.Controls =
            [
                new ControlCollaborative("collaborative-demo")
                {
                    Presence = _ => true,
                    Cursor = _ => true,
                    Input = _ => true,
                    ColorMode = _ => "auto",
                    Document = _ => "tutorial-collaborative"
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
                        {
                            Label = _ => "Subject"
                        }
                            .Initialize(x => x.Value.Text = "collaborative demo")
                            .Process(x => componentHub
                                .GetComponentManager<NotificationManager>()
                                .AddNotification(pageContext.ApplicationContext, x.Context.Request, $"Subject: {WebUtility.HtmlEncode(x.Value.Text)}", durability: 5000)),
                        new ControlFormItemInputText("collaborative-notes")
                        {
                            Label = _ => "Notes",
                            Format = _ => TypeEditTextFormat.Wysiwyg,
                            Rows = _ => 5
                        }
                        .Initialize(x => x.Value.Text = "Type here in two sessions at the same time - both edits are kept.")
                    )
                    .AddPrimaryButton(new ControlFormItemButtonSubmit()),
                    new ControlDataWqlPrompt("collaborative-query"),
                    new ControlSpreadsheet("collaborative-sheet")
                    {
                        Workbook = _ => SpreadsheetSamples.Sales(),
                        GridHeight = _ => "14rem"
                    }
                )
            ];

            Stage.Code = @"
            new ControlCollaborative(""collaborative-demo"")
            {
                Presence = _ => true,
                Cursor = _ => true,
                Input = _ => true,
                ColorMode = _ => ""auto"",
                Document = _ => ""tutorial-collaborative""
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
                    {
                        Label = _ => ""Subject""
                    }
                        .Initialize(x => x.Value.Text = ""collaborative demo"")
                        .Process(x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, x.Context.Request, $""Subject: {WebUtility.HtmlEncode(x.Value.Text)}"", durability: 5000)),
                    new ControlFormItemInputText(""collaborative-notes"")
                    {
                        Label = _ => ""Notes"",
                        Format = _ => TypeEditTextFormat.Wysiwyg,
                        Rows = _ => 5
                    }
                    .Initialize(x => x.Value.Text = ""Type here in two sessions at the same time - both edits are kept."")
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlDataWqlPrompt(""collaborative-query""),
                new ControlSpreadsheet(""collaborative-sheet"")
                {
                    Workbook = _ => SpreadsheetSamples.Sales(),
                    GridHeight = _ => ""14rem""
                }
            );";
        }
    }
}
