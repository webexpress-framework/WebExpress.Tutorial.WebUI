using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the chat control demo for the tutorial. Renders two
    /// <see cref="ControlChat"/> hosts on the same page so the chat round
    /// trip can be exercised in a single browser window.
    /// </summary>
    [Title("Chat")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Chat : PageControl
    {
        private const string GroupChannel = "tutorial-group";
        private const string DirectChannel = "tutorial-direct";

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Chat()
        {
            Stage.Description = @"`ControlChat` provides a real-time chat surface that communicates exclusively through the existing MessageQueue WebSocket (see `WebExpress.WebApp.WebMessageQueue.ChatMessageHandler`). The same control handles both group chats and 1:1 direct conversations — the `ChannelId` selects the routing target. Recent messages are kept in a server-side ring buffer so a client that joins late, reloads the page or briefly drops its connection can request the backlog and continue without losing context.

Manual scenarios:

- **Live messaging** — type into either side, watch the message arrive in the opposite chat simultaneously.
- **Group vs direct** — the first card uses a `group` channel, the second a `direct` channel. Channels are isolated by `ChannelId`.
- **Multiple windows** — open the same URL twice with different `UserId`/`UserName` query parameters or simply different browser sessions; every connected client of the application receives messages for the channels it subscribes to.
- **Reconnect & page navigation** — start a conversation, navigate elsewhere and back (or disable the network briefly): on (re)connect the client requests the channel history and the recent messages are rendered again.";

            Stage.Controls =
            [
                new ControlPanelCard
                (
                    null,
                    new ControlText
                    {
                        Text = _ => "Two clients sharing the same group channel",
                        Format = _ => TypeFormatText.H5,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    },
                    new ControlChat("tutorial-chat-alice")
                    {
                        ChannelId = _ => GroupChannel,
                        UserId = _ => "alice",
                        UserName = _ => "Alice",
                        UserColor = _ => "#3B82F6",
                        Mode = _ => "group",
                        Title = _ => "General (Alice)",
                        Placeholder = _ => "Write something as Alice…"
                    },
                    new ControlChat("tutorial-chat-bob")
                    {
                        ChannelId = _ => GroupChannel,
                        UserId = _ => "bob",
                        UserName = _ => "Bob",
                        UserColor = _ => "#10B981",
                        Mode = _ => "group",
                        Title = _ => "General (Bob)",
                        Placeholder = _ => "Write something as Bob…",
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None)
                    },
                    new ControlText
                    {
                        Text = _ => "Direct conversation between two participants",
                        Format = _ => TypeFormatText.H5,
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Three, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                    },
                    new ControlChat("tutorial-chat-direct-alice")
                    {
                        ChannelId = _ => DirectChannel,
                        UserId = _ => "alice",
                        UserName = _ => "Alice",
                        UserColor = _ => "#3B82F6",
                        Mode = _ => "direct",
                        Title = _ => "Direct → Alice",
                        Placeholder = _ => "Direct message as Alice…"
                    },
                    new ControlChat("tutorial-chat-direct-bob")
                    {
                        ChannelId = _ => DirectChannel,
                        UserId = _ => "bob",
                        UserName = _ => "Bob",
                        UserColor = _ => "#10B981",
                        Mode = _ => "direct",
                        Title = _ => "Direct → Bob",
                        Placeholder = _ => "Direct message as Bob…",
                        Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None)
                    }
                )
            ];

            Stage.Code = @"
            new ControlChat(""group-chat"")
            {
                ChannelId = _ => ""general"",
                UserId = _ => currentUser.Id,
                UserName = _ => currentUser.DisplayName,
                UserColor = _ => currentUser.AccentColor,
                Mode = _ => ""group"",
                Title = _ => ""General""
            }

            // Direct 1:1 — derive the channel from sorted participant ids
            // so both sides resolve to the same channel name.
            new ControlChat(""dm"")
            {
                ChannelId = _ => DirectChannelId(currentUser.Id, partner.Id),
                UserId = _ => currentUser.Id,
                UserName = _ => currentUser.DisplayName,
                Mode = _ => ""direct"",
                Title = _ => $""DM → {partner.DisplayName}""
            }";
        }
    }
}
