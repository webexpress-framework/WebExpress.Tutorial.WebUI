using System.Collections.Generic;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;

namespace WebUI.WWW.Controls.Modal
{
    /// <summary>    
    /// Represents the modal form control for the tutorial.    
    /// </summary>    
    [Title("ModalForm")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    public sealed class ModalForm : PageControl
    {
        private readonly IEnumerable<IControlFormItem> _exampleFormItems =
        [
            new ControlFormItemInputTextBox("username")
            {
                Label = "Username",
                Icon = new IconFont(),
                Help = "Enter your desired username."
            }.Validate(x => x.Add(string.IsNullOrWhiteSpace(x.Value), "Username is required. Please enter a valid name.")),
            new ControlFormItemInputTextBox("email")
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
            new ControlFormItemInputCheckBox("terms")
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
                new ControlModalForm("myModal", [.. _exampleFormItems ])
                {
                    Header = "My modal",
                }
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
                     Modal = "myModalHeader"
                 },
                 new ControlModal("myModalHeader")
                 {
                     Header = "Header"
                 }.Add(_exampleFormItems)
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
                 new ControlModal("myModalDefault")
                 {
                     Header = "Default",
                     Size = TypeModalSize.Default
                 }.Add(_exampleFormItems),
                 new ControlButton()
                 {
                     Text = "Small",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalSmall"
                 },
                 new ControlModal("myModalSmall")
                 {
                     Header = "Small",
                     Size = TypeModalSize.Small
                 }.Add(_exampleFormItems),
                 new ControlButton()
                 {
                     Text = "Large",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalLarge"
                 },
                 new ControlModal("myModalLarge")
                 {
                     Header = "Large",
                     Size = TypeModalSize.Large
                 }.Add(_exampleFormItems),
                 new ControlButton()
                 {
                     Text = "ExtraLarge",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalExtraLarge"
                 },
                 new ControlModal("myModalExtraLarge")
                 {
                     Header = "ExtraLarge",
                     Size = TypeModalSize.ExtraLarge
                 }.Add(_exampleFormItems),
                 new ControlButton()
                 {
                     Text = "Fullscreen",
                     Icon = new IconPenToSquare(),
                     BackgroundColor = new PropertyColorButton(TypeColorButton.Primary),
                     Modal = "myModalFullscreen"
                 },
                 new ControlModal("myModalFullscreen")
                 {
                     Header = "Fullscreen",
                     Size = TypeModalSize.Fullscreen
                 }.Add(_exampleFormItems)
            );
        }
    }
}
