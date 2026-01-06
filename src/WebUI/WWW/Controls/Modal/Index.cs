using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Modal
{
    /// <summary>    
    /// Represents the modal control for the tutorial.    
    /// </summary>    
    [Title("Modal")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : PageControl
    {
        private readonly IEnumerable<IControl> _content =
        [
            new ControlText() { Text = "I'm sure that in 1985, plutonium is available at every corner drug store, but in 1955, it's a little hard to come by. Marty, I'm sorry, but I'm afraid you're stuck here. You do? Whoa, this is heavy. Doc, I'm from the future. I came here in a time machine that you invented. Now, I need your help to get back to the year 1985. I'm really gonna miss you." },
            new ControlText() { Text = "I noticed you band is on the roster for dance auditions after school today. Why even bother Mcfly, you haven't got a chance, you're too much like your own man. No McFly ever amounted to anything in the history of Hill Valley. Marty, don't be such a square. Everybody who's anybody drinks. Huh? Biff. C'mon, c'mon." },
            new ControlText() { Text = "Hi. I have to tell you about the future. Ho ho ho, look at it roll. Now we could watch Jackie Gleason while we eat. Marty, I'm sorry, but the only power source capable of generating one point twenty-one gigawatts of electricity is a bolt of lightning. Hey, hey, keep rolling, keep rolling there. No, no, no, no, this sucker's electrical. But I need a nuclear reaction to generate the one point twenty-one gigawatts of electricity that I need." }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the modal control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Index(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"
            A modal system provides overlaying dialog windows designed for important interactions within an application. To ensure clear structure and functionality, different modal types are defined:

            - **Modal:** A standard dialog window with embedded static content.
            - **ModalForm:** A modal specifically designed for embedded forms within the current page.
            - **ModalRemotePage:** A modal that dynamically loads content from an external source.
            - **ModalRemoteForm:** A modal that retrieves and displays a form from another page.
            
            Modal dialogs are ideal for important notifications, input prompts, or confirmation actions, as they temporarily disable the underlying interface and require direct user interaction.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = new ModalTarget("myModal")
                },
                new ControlModal("myModal") { Header = "My modal" }
                    .Add(_content)
            ];

            Stage.Code = @"
            new ControlButton()
            {
                Text = ""Activator"",
                Icon = new IconPenToSquare(),
                BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                Modal = ""myModal""
            },
            new ControlModal(""myModal"") { Header = ""My modal"" }
                .Add(new ControlText() { Text = ""I'm sure that in 1985...""} )";

            Stage.AddProperty
            (
                "Header",
                 @"The modal header text serves as a descriptive title displayed at the top of the modal. It typically provides context for the modal's purpose or content, helping users quickly understand its function.",
                 "Header = \"Header\"",
                 new ControlButton()
                 {
                     Text = "Activator",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = new ModalTarget("myModalHeader")
                 },
                 new ControlModal("myModalHeader")
                 {
                     Header = "Header"
                 }.Add(_content)
            );

            Stage.AddProperty
            (
                "Header",
                 @"The modal header text serves as a descriptive title displayed at the top of the modal. It typically provides context for the modal's purpose or content, helping users quickly understand its function.",
                 "Header = \"Header\"",
                 new ControlButton()
                 {
                     Text = "Default",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = new ModalTarget("myModalDefault")
                 },
                 new ControlModal("myModalDefault")
                 {
                     Header = "Default",
                     Size = TypeModalSize.Default
                 }.Add(_content),
                 new ControlButton()
                 {
                     Text = "Small",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = new ModalTarget("myModalSmall")
                 },
                 new ControlModal("myModalSmall")
                 {
                     Header = "Small",
                     Size = TypeModalSize.Small
                 }.Add(_content),
                 new ControlButton()
                 {
                     Text = "Large",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = new ModalTarget("myModalLarge")
                 },
                 new ControlModal("myModalLarge")
                 {
                     Header = "Large",
                     Size = TypeModalSize.Large
                 }.Add(_content),
                 new ControlButton()
                 {
                     Text = "ExtraLarge",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = new ModalTarget("myModalExtraLarge")
                 },
                 new ControlModal("myModalExtraLarge")
                 {
                     Header = "ExtraLarge",
                     Size = TypeModalSize.ExtraLarge
                 }.Add(_content),
                 new ControlButton()
                 {
                     Text = "Fullscreen",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = new ModalTarget("myModalFullscreen")
                 },
                 new ControlModal("myModalFullscreen")
                 {
                     Header = "Fullscreen",
                     Size = TypeModalSize.Fullscreen
                 }.Add(_content)
            );
        }
    }
}
