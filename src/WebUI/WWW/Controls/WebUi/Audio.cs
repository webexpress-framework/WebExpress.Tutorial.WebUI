using System;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the audio control for the tutorial.
    /// </summary>
    [WebIcon<IconControlAudio>]
    [Title("Audio")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Audio : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="applicationContext">The application context, for the address of the sample files.</param>
        public Audio(IApplicationContext applicationContext)
        {
            IUri Media(string file) => applicationContext.Route.Concat($"assets/media/{file}").ToUri();

            Stage.Description = @"The `Audio` plays a sound file or an audio stream inside the page, such as a podcast episode, a voice message or a recorded call. It embeds the file with an `<audio>` element and leaves the playing to the player the browser brings along, so no script and no third-party player are loaded. It shares its properties with the `Video`: alternative sources, autoplay, loop, muted, preload and a start and end position. The file is subject to the `media-src` directive of the content security policy, which by default admits the own server and any `https:` source.";

            Stage.Control = new ControlAudio
            (
                null,
                new ControlPlayerSource(Media("melody.ogg"), "audio/ogg; codecs=opus"),
                new ControlPlayerSource(Media("melody.mp3"), "audio/mpeg")
            )
            {
                Label = _ => "WebExpress sample melody"
            };

            // the browser's player brings its own colours, and a second copy would only load
            // the same file twice
            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlAudio
            (
                null,
                new ControlPlayerSource(applicationContext.Route.Concat(""assets/media/melody.ogg"").ToUri(), ""audio/ogg; codecs=opus""),
                new ControlPlayerSource(applicationContext.Route.Concat(""assets/media/melody.mp3"").ToUri(), ""audio/mpeg"")
            )
            {
                Label = _ => ""WebExpress sample melody""
            };";

            Stage.AddProperty
            (
                "Uri",
                "The `Uri` property is the address of the sound file. A single address suits a format every browser plays, such as MP3. It also becomes the target of the link the fallback offers to a browser without audio support.",
                "Uri = _ => applicationContext.Route.Concat(\"assets/media/melody.mp3\").ToUri()",
                new ControlAudio()
                {
                    Uri = _ => Media("melody.mp3"),
                    Label = _ => "WebExpress sample melody"
                }
            );

            Stage.AddProperty
            (
                "Label",
                "The `Label` property names the player for assistive technology. Without a name a screen reader would only announce an unnamed audio player. The text may be an internationalization key.",
                "Label = _ => \"Episode 1: Getting started\"",
                new ControlAudio()
                {
                    Uri = _ => Media("melody.mp3"),
                    Label = _ => "Episode 1: Getting started"
                }
            );

            Stage.AddProperty
            (
                "Start / End",
                "The `Start` and `End` properties play a section of the file, for example a quote out of a long recording. They travel as a media fragment (`#t=4,8`) in the address, which the player interprets without sending it to the server.",
                "Start = _ => TimeSpan.FromSeconds(4),\nEnd = _ => TimeSpan.FromSeconds(8)",
                new ControlAudio()
                {
                    Uri = _ => Media("melody.mp3"),
                    Label = _ => "WebExpress sample melody, seconds 4 to 8",
                    Start = _ => TimeSpan.FromSeconds(4),
                    End = _ => TimeSpan.FromSeconds(8)
                }
            );

            Stage.AddProperty
            (
                "Loop",
                "The `Loop` property starts playback over at the end, which suits a background sound. `Autoplay` is possible as well, but unlike a video an audio player is not muted for it: browsers then usually block the start until the visitor has interacted with the site, and the player waits for the play button.",
                "Loop = _ => true",
                new ControlAudio()
                {
                    Uri = _ => Media("melody.mp3"),
                    Label = _ => "WebExpress sample melody as a loop",
                    Loop = _ => true
                }
            );

            Stage.AddProperty
            (
                "Preload",
                "The `Preload` property decides how much of the file the browser loads before playback is requested. `Metadata`, the default, loads the length; `None` loads nothing until the listener presses play, which saves data on a page with a long list of episodes; `Auto` allows the browser to load the whole file in advance.",
                "Preload = _ => TypePreloadPlayer.None",
                new ControlAudio()
                {
                    Uri = _ => Media("melody.mp3"),
                    Label = _ => "WebExpress sample melody",
                    Preload = _ => TypePreloadPlayer.None
                }
            );
        }
    }
}
