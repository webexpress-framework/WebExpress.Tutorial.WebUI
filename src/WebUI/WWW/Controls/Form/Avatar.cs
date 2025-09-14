using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the avatar control for the tutorial.    
    /// </summary>    
    [Title("Avatar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Avatar : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page on which the CheckBox control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Avatar(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.FILE_SELECTED_EVENT);

            Stage.Description = @"The `Avatar` control is a user-friendly component designed to handle profile image selection, cropping, and previewing. It streamlines the process of uploading a personal avatar and ensures consistent formatting across your application. Ideal for user profile screens, registration flows, or team dashboards.";

            Stage.Control = new ControlForm()
                .Add(new ControlFormItemInputAvatar()
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.DarkControls = [ new ControlForm()
                .Add(new ControlFormItemInputAvatar()
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit())
            ];

            Stage.Code = @"
            new ControlForm()
                .Add(new ControlFormItemInputAvatar()
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
                )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the avatar input control serves as a short description and is displayed prominently next to the avatar icon. It helps identify the purpose or context of the avatar, such as representing a user or role.",
                "Label = \"User\"",
                new ControlForm(items: new ControlFormItemInputAvatar(null)
                {
                    Label = "User"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional guidance on how to interact with the avatar input control. It can clarify the purpose of the avatar, suggest what kind of identity or role to select, or explain how the control integrates with the form.",
                "Help = \"Select or represent the user identity here.\"",
                new ControlForm(items: new ControlFormItemInputAvatar(null)
                {
                    Help = "Select or represent the user identity here."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon displayed alongside the avatar input control. It provides visual context and helps users quickly recognize the type of identity or role being represented, enhancing clarity and user experience.",
                "Icon = new IconUserAstronaut()",
                new ControlForm(items: new ControlFormItemInputAvatar(null)
                {
                    Icon = new IconUserAstronaut(),
                })
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property serves as a hint for the avatar input field. It provides a visual cue for the expected identity or role to be selected or entered, and supports internationalization, allowing it to be defined as a localized string for multilingual interfaces.\r\n",
                "Placeholder = \"Choose a user\"",
                new ControlForm(items: new ControlFormItemInputAvatar()
                {
                    Placeholder = "Choose a user",
                })
            );

            Stage.AddProperty
            (
                "Name",
                "The `Name` property defines the identifier of the avatar input control. It is used to reference the control in form submissions and scripts.",
                "Name = \"avatar\"",
                new ControlForm(items: new ControlFormItemInputAvatar(null)
                {
                    Name = "avatar"
                })
            );

            Stage.AddProperty
            (
                "UploadUri",
                "The `UploadUri` property specifies the endpoint to which the avatar image will be uploaded. It should point to a valid server-side handler.",
                "UploadUri = pageContext.Route.ToUri()",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    Uri = pageContext.Route.ToUri()
                })
            );

            Stage.AddProperty
            (
                "Shape",
                "The `Shape` property defines the clipping shape of the avatar image. Supported values are `circle` and `rect`.",
                "Shape = \"circle\"",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    Shape = TypeAvatarShape.Default
                }),
                new ControlText() { Text = "Circle", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    Shape = TypeAvatarShape.Circle
                }),
                new ControlText() { Text = "Rect", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    Shape = TypeAvatarShape.Rect
                })
            );

            Stage.AddProperty
            (
                "Viewport",
                "The `Viewport` property sets the size of the cropping viewport in pixels. It determines the visible area during avatar selection.",
                "Viewport = 320",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    Viewport = 320
                })
            );

            Stage.AddProperty
            (
                "OutputSize",
                "The `OutputSize` property defines the final resolution of the avatar image in pixels after cropping and export.",
                "OutputSize = 512",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    OutputSize = 512
                })
            );

            Stage.AddProperty
            (
                "OutputFormat",
                "The `OutputFormat` property specifies the MIME type of the exported avatar image. Common values include `image/png`, `image/jpeg`, and `image/webp`.",
                "OutputFormat = ContentType.Jpeg",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    OutputFormat = ContentType.Jpeg
                })
            );

            Stage.AddProperty
            (
                "OutputQuality",
                "The `OutputQuality` property sets the compression quality for formats like JPEG or WebP. It ranges from 0 (lowest) to 1 (highest).",
                "OutputQuality = 0.92",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    OutputQuality = 0.92f
                })
            );

            Stage.AddProperty
            (
                "Accept",
                "The `Accept` property defines the allowed image MIME types for avatar upload. It restricts the file picker to supported formats.",
                "Accept = [ContentType.Png, ContentType.Jpeg, ContentType.WebP]",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    Accept = [ContentType.Png, ContentType.Jpeg, ContentType.WebP]
                })
            );

            Stage.AddProperty
            (
                "OverlayAlpha",
                "The `OverlayAlpha` property sets the transparency level of the cropping overlay. It ranges from 0 (fully transparent) to 1 (fully opaque).",
                "OverlayAlpha = 1",
                new ControlForm(null, new ControlFormItemInputAvatar(null)
                {
                    OverlayAlpha = 1f
                })
            );
        }
    }
}
