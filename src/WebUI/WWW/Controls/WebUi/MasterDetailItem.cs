using System;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Serves the detail content of a single character for the master-detail example.
    /// </summary>
    /// <remarks>
    /// The page is deliberately outside every navigation scope: it is not a
    /// destination a user browses to, but the endpoint the detail frame of the
    /// master-detail control fetches for the selected item.
    /// </remarks>
    [Title("Character")]
    public sealed class MasterDetailItem : IPage<VisualTreeWebApp>
    {
        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var id = renderContext.Request?.GetParameter("id")?.Value;
            var character = Guid.TryParse(id, out var guid)
                ? ViewModel.MonkeyIslandCharacters.FirstOrDefault(x => x.Id == guid)
                : null;

            if (character is null)
            {
                visualTree.Content.MainPanel.AddPrimary(new ControlEmptyState()
                {
                    Icon = _ => new IconMagnifyingGlass(),
                    Title = _ => "Unknown character",
                    Message = _ => "No character exists for the requested id."
                });

                return;
            }

            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => character.Name,
                Format = _ => TypeFormatText.H4
            });

            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => character.Description,
                Format = _ => TypeFormatText.Paragraph
            });

            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "Appears in",
                Format = _ => TypeFormatText.H5,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two)
            });

            visualTree.Content.MainPanel.AddPrimary(new ControlList(null,
            [..
                (character.AppearsIn ?? []).Select(game => new ControlListItem() { Text = _ => game.Name })
            ])
            {
                Layout = _ => TypeLayoutList.Default
            });
        }
    }
}
