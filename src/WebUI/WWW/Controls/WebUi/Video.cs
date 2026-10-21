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
    /// Represents the video control for the tutorial.
    /// </summary>
    [WebIcon<IconControlVideo>]
    [Title("Video")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Video : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="applicationContext">The application context, for the address of the sample files.</param>
        public Video(IApplicationContext applicationContext)
        {
            // the sample clip shows its elapsed time, so a start or end position can be read
            // off the picture
            IUri Media(string file) => applicationContext.Route.Concat($"assets/media/{file}").ToUri();

            Stage.Description = @"The `Video` plays a video inside the page. It embeds the file with a `<video>` element and leaves the playing to the player the browser brings along, so no script and no third-party player are loaded, and playing, seeking, volume, captions, full screen and picture-in-picture work as the viewer knows them from the browser - keyboard and screen reader included. The file is subject to the `media-src` directive of the content security policy, which by default admits the own server and any `https:` source.";

            Stage.Control = new ControlVideo
            (
                null,
                new ControlPlayerSource(Media("sample.webm"), "video/webm"),
                new ControlPlayerSource(Media("sample.mp4"), "video/mp4")
            )
            {
                Poster = _ => Media("sample.png"),
                Label = _ => "WebExpress sample clip"
            }
            .Add(new ControlVideoTrack(Media("sample-en.vtt")) { Language = _ => "en", Label = _ => "English" });

            // the browser's player brings its own colours, and a second copy would only load
            // the same file twice
            Stage.DarkControls = null;

            Stage.Code = @"
            new ControlVideo
            (
                null,
                new ControlPlayerSource(applicationContext.Route.Concat(""assets/media/sample.webm"").ToUri(), ""video/webm""),
                new ControlPlayerSource(applicationContext.Route.Concat(""assets/media/sample.mp4"").ToUri(), ""video/mp4"")
            )
            {
                Poster = _ => applicationContext.Route.Concat(""assets/media/sample.png"").ToUri(),
                Label = _ => ""WebExpress sample clip""
            }
            .Add(new ControlVideoTrack(applicationContext.Route.Concat(""assets/media/sample-en.vtt"").ToUri()) { Language = _ => ""en"", Label = _ => ""English"" });";

            Stage.AddProperty
            (
                "Uri",
                "The `Uri` property is the address of the video file. A single address suits a format every browser plays, such as MP4 with H.264. It also becomes the target of the link the fallback offers to a browser without video support.",
                "Uri = _ => applicationContext.Route.Concat(\"assets/media/sample.mp4\").ToUri()",
                new ControlVideo()
                {
                    Uri = _ => Media("sample.mp4"),
                    Label = _ => "WebExpress sample clip"
                }
            );

            Stage.AddProperty
            (
                "Sources",
                "Several `ControlPlayerSource` entries offer the video in alternative formats. The browser plays the first one whose media type it supports, so the preferred format comes first - here a small WebM file with an MP4 file as the fallback. The sources take precedence over `Uri`.",
                "new ControlVideo(null, new ControlPlayerSource(webm, \"video/webm\"), new ControlPlayerSource(mp4, \"video/mp4\"))",
                new ControlVideo
                (
                    null,
                    new ControlPlayerSource(Media("sample.webm"), "video/webm"),
                    new ControlPlayerSource(Media("sample.mp4"), "video/mp4")
                )
                {
                    Label = _ => "WebExpress sample clip"
                }
            );

            Stage.AddProperty
            (
                "Poster",
                "The `Poster` property is the address of a picture shown until playback starts. Without it the player shows the first frame once it has loaded, or nothing at all when nothing is preloaded.",
                "Poster = _ => applicationContext.Route.Concat(\"assets/media/sample.png\").ToUri()",
                new ControlVideo()
                {
                    Uri = _ => Media("sample.mp4"),
                    Poster = _ => Media("sample.png"),
                    Preload = _ => TypePreloadPlayer.None,
                    Label = _ => "WebExpress sample clip"
                }
            );

            Stage.AddProperty
            (
                "Tracks",
                "A `ControlVideoTrack` adds a WebVTT file of subtitles, captions, descriptions or chapters. The player lists the tracks in its captions menu under their `Label`; `Default` shows a track from the start. The server should answer with the content type `text/vtt`.",
                "new ControlVideo() { ... }.Add(new ControlVideoTrack(vtt) { Language = _ => \"de\", Label = _ => \"Deutsch\", Default = _ => true })",
                new ControlVideo()
                {
                    Uri = _ => Media("sample.mp4"),
                    Label = _ => "WebExpress sample clip"
                }
                .Add
                (
                    new ControlVideoTrack(Media("sample-de.vtt")) { Language = _ => "de", Label = _ => "Deutsch", Default = _ => true },
                    new ControlVideoTrack(Media("sample-en.vtt")) { Language = _ => "en", Label = _ => "English" }
                )
            );

            Stage.AddProperty
            (
                "Start / End",
                "The `Start` and `End` properties play a section of the file. They travel as a media fragment (`#t=4,8`) in the address, which the player interprets without sending it to the server, so the same cached file serves every section. Playback pauses at the end position; the viewer can play on beyond it.",
                "Start = _ => TimeSpan.FromSeconds(4),\nEnd = _ => TimeSpan.FromSeconds(8)",
                new ControlVideo()
                {
                    Uri = _ => Media("sample.mp4"),
                    Label = _ => "WebExpress sample clip, seconds 4 to 8",
                    Start = _ => TimeSpan.FromSeconds(4),
                    End = _ => TimeSpan.FromSeconds(8)
                }
            );

            Stage.AddProperty
            (
                "Autoplay",
                "The `Autoplay` property starts playback on its own. Browsers block autoplay with sound, so an autoplaying video is always rendered muted - the viewer can turn the sound on. Together with `Loop` and without `Controls` it suits a decorative background clip.",
                "Autoplay = _ => true,\nLoop = _ => true,\nControls = _ => false",
                new ControlVideo()
                {
                    Uri = _ => Media("sample.mp4"),
                    Label = _ => "WebExpress sample clip as a loop",
                    Autoplay = _ => true,
                    Loop = _ => true,
                    Controls = _ => false
                }
            );

            Stage.AddProperty
            (
                "Preload",
                "The `Preload` property decides how much of the file the browser loads before playback is requested. `Metadata`, the default, loads the length and the first frame; `None` loads nothing until the viewer presses play, which saves data on a page with many videos; `Auto` allows the browser to load the whole file in advance.",
                "Preload = _ => TypePreloadPlayer.None",
                new ControlVideo()
                {
                    Uri = _ => Media("sample.mp4"),
                    Label = _ => "WebExpress sample clip",
                    Preload = _ => TypePreloadPlayer.None
                }
            );
        }
    }
}
