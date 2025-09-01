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
    /// Represents the modal form control for the tutorial.    
    /// </summary>    
    [Title("ModalForm")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class ModalForm : PageControl
    {
        private readonly IEnumerable<IControlFormItem> _exampleFormItems =
        [
            new ControlFormItemInputText("username")
            {
                Label = "Username",
                Icon = new IconFont(),
                Help = "Enter your desired username."
            }.Validate(x => x.Add
            (
                string.IsNullOrWhiteSpace(x.Value.Text),
                "Username is required. Please enter a valid name."
            )),
            new ControlFormItemInputText("email")
            {
                Label = "Email Address",
                Icon = new IconAt(),
                Help = "Enter your email address."
            },
            new ControlFormItemInputSelection("country",
            [
                new ControlFormItemInputSelectionItem("1") { Label = "Germany" },
                new ControlFormItemInputSelectionItem("2") { Label = "Austria" },
                new ControlFormItemInputSelectionItem("3") { Label = "Switzerland" }
            ])
            {
                Label = "Country",
                Icon = new IconMapLocationDot(),
                Help = "Select your home country."
            },
            new ControlFormItemInputCheck("terms")
            {
                Label = "I accept the terms and conditions",
                Help = "Please confirm that you have read the terms."
            }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the modal control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public ModalForm(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.MODAL_SHOW_EVENT, Event.MODAL_HIDE_EVENT);

            Stage.Description = @"The `ModalForm` allows direct embedding of forms within a modal dialog, enabling users to enter data without leaving the current view. It ensures a seamless user experience and is ideal for quick interactions such as registrations or configurations. With its integrated structure, external loading is unnecessary, improving performance.";

            Stage.Controls =
            [
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myModal"
                },
                new ControlModalForm("myModal")
                {
                    Header = "My modal",
                    Conformation = new ControlAlert()
                    {
                        Text = @"Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime.",
                        BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                    }
                }
                .Add(_exampleFormItems)
                .AddPreferencesButton(new ControlFormItemButtonSubmit())
            ];

            Stage.DarkControls =
            [
                new ControlButton()
                {
                    Text = "Activator",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = "myDarkModal"
                },
                new ControlModalForm("myDarkModal")
                {
                    Header = "My dark modal",
                    Conformation = new ControlAlert()
                    {
                        Text = @"Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime.",
                        BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                    }
                }
                .Add(_exampleFormItems)
                .AddPreferencesButton(new ControlFormItemButtonSubmit())
            ];

            Stage.Code = @"
            new ControlButton()
                {
                    Text = ""Activator"",
                    Icon = new IconPenToSquare(),
                    BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                    Modal = ""myModal""
                },
                new ControlModalForm(""myModal"")
                {
                    Header = ""My modal"",
                    Conformation = new ControlAlert() 
                    {
                        Text = @""Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime."",
                        BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                    }
                }
                .Add(_exampleFormItems)
                .AddPreferencesButton(new ControlFormItemButtonSubmit())";

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
                     Modal = "myModalHeader"
                 },
                 new ControlModalForm("myModalHeader")
                 {
                     Header = "Header"
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit())
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
                     Modal = "myModalDefault"
                 },
                 new ControlModalForm("myModalDefault")
                 {
                     Header = "Default",
                     Size = TypeModalSize.Default
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = "Small",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalSmall"
                 },
                 new ControlModalForm("myModalSmall")
                 {
                     Header = "Small",
                     Size = TypeModalSize.Small
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = "Large",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalLarge"
                 },
                 new ControlModalForm("myModalLarge")
                 {
                     Header = "Large",
                     Size = TypeModalSize.Large
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = "ExtraLarge",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalExtraLarge"
                 },
                 new ControlModalForm("myModalExtraLarge")
                 {
                     Header = "ExtraLarge",
                     Size = TypeModalSize.ExtraLarge
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = "Fullscreen",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalFullscreen"
                 },
                 new ControlModalForm("myModalFullscreen")
                 {
                     Header = "Fullscreen",
                     Size = TypeModalSize.Fullscreen
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
