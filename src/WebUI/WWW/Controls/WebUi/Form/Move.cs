using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>    
    /// Represents the move control for the tutorial.    
    /// </summary>    
    [Title("Move")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Move : PageControl
    {
        private readonly IEnumerable<ControlFormItemInputMoveItem> _options =
        [
            new ControlFormItemInputMoveItem("1") { Label = "Option 1", Icon = new IconSquare() },
            new ControlFormItemInputMoveItem("2") { Label = "Option 2", Icon = new IconCar() },
            new ControlFormItemInputMoveItem("3") { Label = "Option 3", Icon = new IconAsterisk() },
            new ControlFormItemInputMoveItem("4") { Label = "Option 4", Icon = new IconBaseball() },
            new ControlFormItemInputMoveItem("5") { Label = "Option 5", Icon = new IconFloppyDisk() },
            new ControlFormItemInputMoveItem("6") { Label = "Option 6", Icon = new IconSeedling() },
            new ControlFormItemInputMoveItem("7") { Label = "Option 7", Icon = new IconRoute() },
            new ControlFormItemInputMoveItem("8") { Label = "Option 8", Icon = new IconReply() },
            new ControlFormItemInputMoveItem("9") { Label = "Option 9", Icon = new IconClipboard() },
            new ControlFormItemInputMoveItem("10") { Label = "Option 10", Icon = new IconGlobe() }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the move control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Move(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CLICK_EVENT);

            Stage.Description = @"The `Move` control allows for an intuitive and dynamic selection of options using drag & drop. Users can easily drag elements to the left to select them, creating a fluid and visually engaging interaction.";

            Stage.Control = new ControlForm("myform", new ControlFormItemInputMove(null, [.. _options])
            {
                Icon = new IconShieldCat(),
                Label = "Options",
                Help = "Select the desired options here.",
                Name = "myMoveCtrl"
            }
                    .Initialize(args => args.Value.Add("2").Add("3"))
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
            )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlFormItemInputMove(null, [.. _options])
            {
                Icon = new IconShieldCat(),
                Label = ""Options"",
                Help = ""Select the desired options here."",
                Name = ""myMoveCtrl""
            }
                    .Initialize(args => args.Value.Add(""2"").Add(""3""))
                    .Process(x => componentHub
                        .GetComponentManager<NotificationManager>()
                        .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
            )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "AvailableHeader",
                "The `AvailableHeader` property serves as a heading for the available options within the `Move` control. It provides a clear label for the selectable elements and supports internationalization, allowing it to be used as an internationalization string.",
                "AvailableHeader = \"Available\"",
                new ControlForm(null, new ControlFormItemInputMove(null, [.. _options])
                {
                    AvailableHeader = "Available",
                })
            );

            Stage.AddProperty
            (
                "SelectedHeader",
                "The `SelectedHeader` property serves as a heading for the selected options within the `Move` control. It provides a clear label for the chosen elements and supports internationalization, allowing it to be used as an internationalization string.",
                "SelectedHeader = \"Selected\"",
                new ControlForm(null, new ControlFormItemInputMove(null, [.. _options])
                {
                    SelectedHeader = "Selected",
                })
            );

            Stage.AddItem
            (
                "Label",
                "The `Label` property of a `Move` control item serves as a short form of the option text and is displayed in the main area of the control once a selection is made. Instead of showing the full descriptive text of an option, the label ensures a concise and clear representation of the chosen selection. When the label is defined as an internationalization key.",
                "new ControlFormItemInputMoveItem(\"1\") { Label = \"Label 1\" }",
                new ControlForm(null, new ControlFormItemInputMove("a", new ControlFormItemInputMoveItem("1") { Label = "Label 1" })
                {
                })
            );

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a item. It provides a visual representation and identification of a option within the list structure, enhancing user guidance and recognition. Icons can be either system icons or custom icons, allowing flexibility in design and functionality. System icons offer a standardized visual language, ensuring consistency across applications, while custom icons enable tailored representations to meet specific user needs.",
                "new ControlFormItemInputMoveItem(\"1\") { Icon = new IconHome() }",
                new ControlForm(null, new ControlFormItemInputMove("a", new ControlFormItemInputMoveItem("1") { Icon = new IconHome() })
                {
                })
            );
        }
    }
}
