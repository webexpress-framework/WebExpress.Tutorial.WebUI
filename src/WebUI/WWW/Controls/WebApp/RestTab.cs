using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>    
    /// Represents the tab control for the tutorial.    
    /// </summary>    
    [Title("RestTab")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class RestTab : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public RestTab(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.SELECTED_TAB_EVENT, Event.TAB_ADDED_EVENT, Event.TAB_CLOSED_EVENT);

            Stage.Description = @"The `Tab` control serves as a container for multiple tab views. Each tab is defined through a tab view with metadata such as title and an icon.";

            Stage.Control = new ControlRestTab(RandomId.Create())
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandTab>(pageContext.ApplicationContext),
            }
                .Add
                (
                    new ControlRestTabTemplate()
                        .Add(new ControlText()
                        {
                            Text = "Template"
                        })
                );

            Stage.Code = @"
            new ControlRestTab(RandomId.Create())
            {
                RestUri = sitemapManager.GetUri<MonkeyIslandTab>(pageContext.ApplicationContext),
            }
                .Add
                (
                    new ControlRestTabTemplate()
                        .Add(new ControlText() 
                        { 
                            Text = ""Template"" 
                        })
                );";
        }
    }
}
