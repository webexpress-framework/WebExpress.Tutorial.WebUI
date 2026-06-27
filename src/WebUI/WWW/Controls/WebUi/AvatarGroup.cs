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
    /// Represents the avatar group control demo page for the tutorial.
    /// </summary>
    [Title("AvatarGroup")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class AvatarGroup : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public AvatarGroup(IPageContext pageContext)
        {
            Stage.Description = @"The `AvatarGroup` control shows a set of avatars as a compact, overlapping stack. Only the first few avatars are shown inline; the rest collapse into a `+N` overflow chip. An avatar shows an image, or the initials derived from its name on a colored circle.";

            Stage.Controls =
            [
                new ControlAvatarGroup
                (
                    null,
                    new ControlAvatarGroupItem() { Name = _ => "Guybrush Threepwood", Color = _ => new PropertyColorBackground("#1d4ed8") },
                    new ControlAvatarGroupItem() { Name = _ => "Elaine Marley", Color = _ => new PropertyColorBackground("#7c3aed") },
                    new ControlAvatarGroupItem() { Name = _ => "Captain LeChuck", Color = _ => new PropertyColorBackground("#991b1b") }
                )
            ];

            Stage.Code = @"
            new ControlAvatarGroup
            (
                null,
                new ControlAvatarGroupItem() { Name = _ => ""Guybrush Threepwood"", Color = _ => new PropertyColorBackground(""#1d4ed8"") },
                new ControlAvatarGroupItem() { Name = _ => ""Elaine Marley"", Color = _ => new PropertyColorBackground(""#7c3aed"") }
            );";

            Stage.AddProperty
            (
                "MaxVisible",
                "Sets how many avatars are shown before the rest collapse into a +N chip.",
                "MaxVisible = _ => 3",
                new ControlAvatarGroup
                (
                    null,
                    new ControlAvatarGroupItem() { Name = _ => "Guybrush Threepwood", Color = _ => new PropertyColorBackground("#1d4ed8") },
                    new ControlAvatarGroupItem() { Name = _ => "Elaine Marley", Color = _ => new PropertyColorBackground("#7c3aed") },
                    new ControlAvatarGroupItem() { Name = _ => "Captain LeChuck", Color = _ => new PropertyColorBackground("#991b1b") },
                    new ControlAvatarGroupItem() { Name = _ => "Stan S. Stanman", Color = _ => new PropertyColorBackground("#b45309") },
                    new ControlAvatarGroupItem() { Name = _ => "The Voodoo Lady", Color = _ => new PropertyColorBackground("#047857") }
                )
                {
                    MaxVisible = _ => 3
                }
            );
        }
    }
}
