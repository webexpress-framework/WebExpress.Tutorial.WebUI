using System;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Tutorial page for manually testing the WebSocket-based popup
    /// notification pipeline. Each button hits the
    /// <see cref="PopupTrigger"/> REST helper which calls
    /// <c>NotificationManager.AddNotification</c>; the
    /// <c>PopupNotificationDispatcher</c> then pushes the notification
    /// through the existing MessageQueue WebSocket so the popup appears on
    /// every connected client without any HTTP roundtrip on the receiver.
    /// </summary>
    [Title("Popup Notification")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class PopupNotification : PageControl
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pageContext">The page context.</param>
        /// <param name="componentHub">The component hub.</param>
        public PopupNotification(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.Description = @"`ControlPopupNotification` hosts the live popup overlay that consumes notifications from the MessageQueue WebSocket. The first card below triggers **server-side** notifications: each click hits the `PopupTrigger` REST helper which calls `NotificationManager.AddNotification`; the `PopupNotificationDispatcher` then forwards the notification to every connected client over the existing WebSocket - no HTTP roundtrip from the receiver is involved.

The second card demonstrates the **client-side `ActionPopup`** (`IAction`): the button itself carries the entire payload as `data-wx-primary-*` attributes and the registered `popup` action synthesizes a notification locally via `MessageQueue.dispatchLocal`. No request reaches the server and no other client sees the popup — ideal for inline UX feedback such as ""copied to clipboard"" or ""form saved"".

Manual scenarios:

- **Multiple windows** - open the same URL in two browsers and trigger a global notification: it appears in both immediately.
- **Page navigation** - trigger a long-lived notification, navigate to another tutorial page and back; the popup is replayed on reconnect.
- **Offline reconnect** - briefly disable the network (DevTools), trigger a notification from a second window, re-enable the network; the popup is delivered as soon as the WebSocket reconnects.
- **Dismiss** - closing the alert sends a dismiss message back to the server so it is no longer replayed.
- **Client-only popups** - trigger any button in the second card; the alert appears only in the current browser tab and never reaches the server.";

            var triggerUri = componentHub
                .SitemapManager
                .GetUri<PopupTrigger>(pageContext.ApplicationContext)?
                .ToString() ?? "";

            var returnUri = pageContext.Route?.ToUri()?.ToString() ?? "/";

            string Url(string type, string heading, string message, int durability, string scope)
            {
                return $"{triggerUri}?type={Uri.EscapeDataString(type)}"
                    + $"&heading={Uri.EscapeDataString(heading)}"
                    + $"&message={Uri.EscapeDataString(message)}"
                    + $"&durability={durability}"
                    + $"&scope={scope}"
                    + $"&return={Uri.EscapeDataString(returnUri)}";
            }

            ControlButtonLink TriggerButton(string label, TypeColorButton color, string url)
            {
                return new ControlButtonLink
                {
                    Text = _ => label,
                    BackgroundColor = _ => new PropertyColorButton(color),
                    Uri = _ => new UriEndpoint(url),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                };
            }

            ControlButton ClientPopupButton(string label, TypeColorButton color, ActionPopup action)
            {
                return new ControlButton
                {
                    Text = _ => label,
                    BackgroundColor = _ => new PropertyColorButton(color),
                    PrimaryAction = _ => action,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.Two, PropertySpacing.Space.None)
                };
            }

            Stage.Controls =
            [
                new ControlText
                {
                    Text = _ => "Server-driven notifications (broadcast)",
                    Format = _ => TypeFormatText.H5,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                },
                new ControlPanelCard
                (
                    null,
                    TriggerButton
                    (
                        "Info (5s, global)",
                        TypeColorButton.Info,
                        Url("Info", "Heads up", "An informational popup that disappears after five seconds.", 5000, "global")
                    ),
                    TriggerButton
                    (
                        "Success (5s, global)",
                        TypeColorButton.Success,
                        Url("Success", "Saved", "Your changes were persisted successfully.", 5000, "global")
                    ),
                    TriggerButton
                    (
                        "Warning (10s, global)",
                        TypeColorButton.Warning,
                        Url("Warning", "Heads up", "A long running operation is about to start.", 10000, "global")
                    ),
                    TriggerButton
                    (
                        "Danger (persistent, global)",
                        TypeColorButton.Danger,
                        Url("Danger", "Failure", "A critical error needs your attention.", -1, "global")
                    ),
                    TriggerButton
                    (
                        "Session-scoped (8s)",
                        TypeColorButton.Primary,
                        Url("Primary", "Just for you", "Visible only inside your current session.", 8000, "session")
                    ),
                    TriggerButton
                    (
                        "Persistent (no auto-expire)",
                        TypeColorButton.Secondary,
                        Url("Secondary", "Pinned", "Stays until you close it manually.", -1, "global")
                    )
                ),
                new ControlText
                {
                    Text = _ => "Client-side ActionPopup (local only, no server roundtrip)",
                    Format = _ => TypeFormatText.H5,
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Three, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                },
                new ControlPanelCard
                (
                    null,
                    ClientPopupButton
                    (
                        "Info (5s, local)",
                        TypeColorButton.Info,
                        new ActionPopup
                        (
                            heading: "Heads up",
                            message: "Triggered locally — never reaches the server.",
                            type: "alert-info",
                            durability: 5000
                        )
                    ),
                    ClientPopupButton
                    (
                        "Success (3s, local)",
                        TypeColorButton.Success,
                        new ActionPopup
                        (
                            heading: "Copied",
                            message: "Value copied to the clipboard.",
                            type: "alert-success",
                            durability: 3000
                        )
                    ),
                    ClientPopupButton
                    (
                        "Warning (8s, local)",
                        TypeColorButton.Warning,
                        new ActionPopup
                        (
                            heading: "Unsaved changes",
                            message: "Don't forget to save before leaving.",
                            type: "alert-warning",
                            durability: 8000
                        )
                    ),
                    ClientPopupButton
                    (
                        "Danger (persistent, local)",
                        TypeColorButton.Danger,
                        new ActionPopup
                        (
                            heading: "Critical",
                            message: "This local popup stays until you close it.",
                            type: "alert-danger",
                            durability: -1
                        )
                    )
                )
            ];

            Stage.Code = @"
            // (A) Server-side trigger (broadcast to every client).
            //     Hooked up to the buttons in the first card via PopupTrigger:
            NotificationManager.AddNotification
            (
                applicationContext,
                ""Your changes were persisted successfully."",
                durability: 5000,
                heading: ""Saved"",
                icon: null,
                type: TypeNotification.Success
            );

            // The PopupNotificationDispatcher picks the notification up and
            // pushes it as a webexpress.webapp.popup.show message through
            // every connected MessageQueueSocket. On (re)connect every
            // still-valid notification is replayed automatically.

            // (B) Client-side ActionPopup (local only, no roundtrip).
            //     Attach to any button via PrimaryAction / SecondaryAction:
            new ControlButton
            {
                Text = _ => ""Save"",
                PrimaryAction = _ => new ActionPopup
                (
                    heading: ""Saved"",
                    message: ""Your changes were stored."",
                    type: ""alert-success"",
                    durability: 4000
                )
            };

            // The action emits data-wx-primary-action=""popup"" plus the
            // data-wx-primary-heading / -message / -type / -durability
            // attributes. The registered ""popup"" JavaScript action
            // synthesizes a notification payload and dispatches it locally
            // through MessageQueue.dispatchLocal, so the existing
            // PopupNotificationCtrl renders it without any HTTP call.";
        }
    }
}
