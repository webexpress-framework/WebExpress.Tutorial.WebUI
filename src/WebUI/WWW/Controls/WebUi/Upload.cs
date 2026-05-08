using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>    
    /// Represents the tree control for the tutorial.    
    /// </summary>    
    [Title("Upload")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Upload : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>
        public Upload(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.FILE_SELECTED_EVENT, Event.UPLOAD_SUCCESS_EVENT, Event.UPLOAD_ERROR_EVENT, Event.UPLOAD_PROGRESS_EVENT);

            Stage.Description = @"The `Upload` control is used for uploading files via drag-and-drop or manual selection. It provides a user-friendly interface that allows users to drop files directly onto a designated area or choose them through a file picker.";

            Stage.Control = new ControlUpload()
            {
                Uri = _ => pageContext.Route.ToUri()
            }
                .Process(x =>
                {
                    componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}");
                });

            Stage.DarkControls = [new ControlUpload()
            {
                Uri = _ =>pageContext.Route.ToUri()
            }];

            Stage.Code = @"
            new ControlUpload()
            {
                Uri = _ => pageContext.Route.ToUri()
            };";

            Stage.AddProperty
            (
                "Uri",
                "The `Uri` property specifies the destination URL to which the selected files will be uploaded. It defines the endpoint that handles the file transfer on the server side.",
                "Uri = _ => pageContext.Route.ToUri()",
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri()
                }
            );

            Stage.AddProperty
            (
                "Multiple",
                "The `Multiple` property determines whether users can select and upload multiple files at once.",
                "Multiple = _ => true",
                new ControlText() { Text = _ => "false", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Multiple = _ => false
                },
                new ControlText() { Text = _ => "true", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Multiple = _ => true
                }
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property displays a persistent hint or instruction text within the upload area. It serves as a static guide to inform users about the expected file types, size limits, or upload purpose.",
                @"Placeholder = _ => ""Placeholder""",
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Placeholder = _ => "Placeholder"
                }
            );

            Stage.AddProperty
            (
                "Accept",
                "The `Accept` property defines which file types the user is allowed to select when uploading files. It acts as a filter in the file picker dialog, helping guide users to choose appropriate formats.",
                @"Accept = _ => ""image/*""",
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    Accept = _ => "image/*"
                }
            );

            Stage.AddProperty
            (
                "Autoupload",
                "The `AutoUpload` property determines whether a file is automatically uploaded immediately after the user selects it—without requiring an explicit click on an \"Upload\" button.",
                "Autoupload = _ => true",
                new ControlText() { Text = _ => "false", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    AutoUpload = _ => false
                },
                new ControlText() { Text = _ => "true", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    AutoUpload = _ => true
                }
            );

            Stage.AddProperty
            (
                "FullScreenDropzone",
                "The `FullScreenDropzone` property enables a drag-and-drop upload zone that spans the entire screen, allowing users to drop files anywhere within the browser window to initiate an upload.",
                "FullScreenDropzone = _ => true",
                new ControlText() { Text = _ => "false", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    FullScreenDropzone = _ => false
                },
                new ControlText() { Text = _ => "true", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlUpload()
                {
                    Uri = _ => pageContext.Route.ToUri(),
                    FullScreenDropzone = _ => true
                }
            );
        }
    }
}
