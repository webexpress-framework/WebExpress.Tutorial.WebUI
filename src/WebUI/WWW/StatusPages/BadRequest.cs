﻿using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.StatusPages
{
    /// <summary>
    /// Represents the home page for the tutorial.
    /// </summary>
    [WebIcon<IconHome>]
    [Title("webexpress.tutorial.webui:homepage.label")]
    [Icon("fa fa-home")]
    [Scope<IScopeGeneral>]
    public sealed class BadRequest : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public BadRequest()
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            throw new BadRequestException("This is a bad request example.");
        }
    }
}