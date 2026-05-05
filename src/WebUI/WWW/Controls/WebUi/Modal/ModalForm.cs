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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Modal
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
                Label = _ => "Username",
                Icon = _ => new IconFont(),
                Help = _ => "Enter your desired username."
            }.Validate(x => x.Add
            (
                string.IsNullOrWhiteSpace(x.Value.Text),
                "Username is required. Please enter a valid name."
            )),
            new ControlFormItemInputText("email")
            {
                Label = _ => "Email Address",
                Icon = _ => new IconAt(),
                Help = _ => "Enter your email address."
            },
            new ControlFormItemInputSelection("country",
            [
                new ControlFormItemInputSelectionItem("1") { Text = _ => "Germany" },
                new ControlFormItemInputSelectionItem("2") { Text = _ => "Austria" },
                new ControlFormItemInputSelectionItem("3") { Text = _ => "Switzerland" }
            ])
            {
                Label = _ => "Country",
                Icon = _ => new IconMapLocationDot(),
                Help = _ => "Select your home country."
            },
            new ControlFormItemInputCheck("terms")
            {
                Label = _ => "I accept the terms and conditions",
                Help = _ => "Please confirm that you have read the terms."
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
                    Text = _ => "Activator",
                    Icon = _ => new IconPenToSquare(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("myModal")
                },
                new ControlModalForm("myModal")
                {
                    Header = _ => "My modal",
                    Conformation = _ =>new ControlAlert()
                    {
                        Text = @"Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime.",
                        BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                    }
                }
                .Add(_exampleFormItems)
                .AddPreferencesButton(new ControlFormItemButtonSubmit())
            ];

            Stage.DarkControls =
            [
                new ControlButton()
                {
                    Text = _ =>  "Activator",
                    Icon = _ => new IconPenToSquare(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal("myDarkModal")
                },
                new ControlModalForm("myDarkModal")
                {
                    Header = _ => "My dark modal",
                    Conformation = _ =>new ControlAlert()
                    {
                        Text = @"Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime.",
                        BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                    }
                }
                .Add(_exampleFormItems)
                .AddPreferencesButton(new ControlFormItemButtonSubmit())
            ];

            Stage.Code = @"
            new ControlButton()
                {
                    Text = _ => ""Activator"",
                    Icon = _ => new IconPenToSquare(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    PrimaryAction = _ => new ActionModal(""myModal"")
                },
                new ControlModalForm(""myModal"")
                {
                    Header = _ => ""My modal"",
                    Conformation = _ => new ControlAlert() 
                    {
                        Text = _ => @""Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime."",
                        BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                    }
                }
                .Add(_exampleFormItems)
                .AddPreferencesButton(new ControlFormItemButtonSubmit())";

            Stage.AddProperty
            (
                "Header",
                 @"The modal header text serves as a descriptive title displayed at the top of the modal. It typically provides context for the modal's purpose or content, helping users quickly understand its function.",
                 "Header = _ => \"Header\"",
                 new ControlButton()
                 {
                     Text = _ => "Activator",
                     Icon = _ => new IconPenToSquare(),
                     BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                     PrimaryAction = _ => new ActionModal("myModalHeader")
                 },
                 new ControlModalForm("myModalHeader")
                 {
                     Header = _ => "Header"
                 }
                 .Add(_exampleFormItems)
                 .AddPreferencesButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "Size",
                @"The size property defines the dimensions of the modal. It determines how large the modal appears and helps ensure that the available space fits the content and use case appropriately.",
                 "Size = _ => TypeModalSize.Small",
                 new ControlButton()
                 {
                     Text = _ => "Default",
                     Icon = _ => new IconPenToSquare(),
                     BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                     PrimaryAction = _ => new ActionModal("myModalDefault")
                 },
                 new ControlModalForm("myModalDefault")
                 {
                     Header = _ => "Default",
                     Size = TypeModalSize.Default
                 }
                     .Add(_exampleFormItems)
                     .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = _ => "Small",
                     Icon = _ => new IconPenToSquare(),
                     BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                     PrimaryAction = _ => new ActionModal("myModalSmall")
                 },
                 new ControlModalForm("myModalSmall")
                 {
                     Header = _ => "Small",
                     Size = TypeModalSize.Small
                 }
                     .Add(_exampleFormItems)
                     .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = _ => "Large",
                     Icon = _ => new IconPenToSquare(),
                     BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                     PrimaryAction = _ => new ActionModal("myModalLarge")
                 },
                 new ControlModalForm("myModalLarge")
                 {
                     Header = _ => "Large",
                     Size = TypeModalSize.Large
                 }
                     .Add(_exampleFormItems)
                     .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = _ => "ExtraLarge",
                     Icon = _ => new IconPenToSquare(),
                     BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                     PrimaryAction = _ => new ActionModal("myModalExtraLarge")
                 },
                 new ControlModalForm("myModalExtraLarge")
                 {
                     Header = _ => "ExtraLarge",
                     Size = TypeModalSize.ExtraLarge
                 }
                     .Add(_exampleFormItems)
                     .AddPreferencesButton(new ControlFormItemButtonSubmit()),
                 new ControlButton()
                 {
                     Text = _ => "Fullscreen",
                     Icon = _ => new IconPenToSquare(),
                     BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                     PrimaryAction = _ => new ActionModal("myModalFullscreen")
                 },
                 new ControlModalForm("myModalFullscreen")
                 {
                     Header = _ => "Fullscreen",
                     Size = TypeModalSize.Fullscreen
                 }
                     .Add(_exampleFormItems)
                     .AddPreferencesButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
