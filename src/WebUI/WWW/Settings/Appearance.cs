using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSettingPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebPolicies;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Settings
{
    /// <summary>
    /// Makes the tutorial theme preference available within administration.
    /// </summary>
    [WebIcon<IconPalette>]
    [Title("webexpress.tutorial.webui:theme.settings.title")]
    [SettingGroup<SettingGroupSystemGeneral>()]
    [SettingSection(SettingSection.Secondary)]
    [Scope<IScopeAdmin>]
    [Policy<SystemAccessPolicy>]
    public sealed class Appearance : ISettingPage<VisualTreeWebAppSetting>, IScopeAdmin
    {
        /// <summary>
        /// Applies the saved preference and exposes the existing REST-backed selector.
        /// </summary>
        /// <param name="renderContext">The current administration request.</param>
        /// <param name="visualTree">The settings layout receiving the theme selector.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebAppSetting visualTree)
        {
            ThemeStore.Apply(renderContext, visualTree);
            visualTree.Content.MainPanel.AddPrimary(new ControlText()
            {
                Text = _ => "webexpress.tutorial.webui:theme.settings.description",
                Format = _ => TypeFormatText.Paragraph
            });
            visualTree.Content.MainPanel.AddPrimary(new ControlDataSelectionTheme("tutorialThemeSelector")
                .DataService<ThemeApi>());
        }
    }
}
