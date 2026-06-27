using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the timeline control demo page for the tutorial.
    /// </summary>
    [Title("Timeline")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Timeline : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Timeline(IPageContext pageContext)
        {
            Stage.Description = @"The `Timeline` control lays out a sequence of entries along a vertical rail, for an activity feed or a chronological history. Each entry has a marker, a title, an optional timestamp and a body of content.";

            Stage.Controls =
            [
                new ControlTimeline
                (
                    null,
                    new ControlTimelineItem(null, new ControlText() { Text = _ => "The quest log was opened." })
                    {
                        Title = _ => "Created",
                        Timestamp = _ => "09:00"
                    },
                    new ControlTimelineItem(null, new ControlText() { Text = _ => "Guybrush joined the crew." })
                    {
                        Title = _ => "Crew assembled",
                        Timestamp = _ => "11:30"
                    },
                    new ControlTimelineItem(null, new ControlText() { Text = _ => "The Sea Monkey set sail." })
                    {
                        Title = _ => "Departure",
                        Timestamp = _ => "14:15"
                    }
                )
            ];

            Stage.Code = @"
            new ControlTimeline
            (
                null,
                new ControlTimelineItem(null, new ControlText() { Text = _ => ""..."" })
                {
                    Title = _ => ""Created"",
                    Timestamp = _ => ""09:00""
                }
            );";

            Stage.AddProperty
            (
                "Color",
                "Colors the marker of an entry with a system or a user-defined color.",
                "Color = _ => new PropertyColorBackground(TypeColorBackground.Success)",
                new ControlTimeline
                (
                    null,
                    new ControlTimelineItem(null, new ControlText() { Text = _ => "A successful step." })
                    {
                        Title = _ => "Success",
                        Color = _ => new PropertyColorBackground(TypeColorBackground.Success)
                    },
                    new ControlTimelineItem(null, new ControlText() { Text = _ => "Something needs attention." })
                    {
                        Title = _ => "Warning",
                        Color = _ => new PropertyColorBackground(TypeColorBackground.Warning)
                    },
                    new ControlTimelineItem(null, new ControlText() { Text = _ => "A user-defined marker color." })
                    {
                        Title = _ => "Custom",
                        Color = _ => new PropertyColorBackground("#7c3aed")
                    }
                )
            );
        }
    }
}
