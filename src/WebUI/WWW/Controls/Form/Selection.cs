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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the selection control for the tutorial.    
    /// </summary>    
    [Title("Selection")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Selection : PageControl
    {
        private readonly IEnumerable<ControlFormItemInputSelectionItem> _options =
        [
            new ControlFormItemInputSelectionItem("1") { Label = "Option 1", Icon = new IconSquare() },
            new ControlFormItemInputSelectionItem("2") { Label = "Option 2", Icon = new IconCar() },
            new ControlFormItemInputSelectionItem("3") { Label = "Option 3", Icon = new IconAsterisk() },
            new ControlFormItemInputSelectionItem("4") { Label = "Option 4", Icon = new IconBaseball() },
            new ControlFormItemInputSelectionItem("5") { Label = "Option 5", Icon = new IconFloppyDisk() },
            new ControlFormItemInputSelectionItem("6") { Label = "Option 6", Icon = new IconSeedling() },
            new ControlFormItemInputSelectionItem("7") { Label = "Option 7", Icon = new IconRoute() },
            new ControlFormItemInputSelectionItem("8") { Label = "Option 8", Icon = new IconReply() },
            new ControlFormItemInputSelectionItem("9") { Label = "Option 9", Icon = new IconClipboard() },
            new ControlFormItemInputSelectionItem("10") { Label = "Option 10", Icon = new IconGlobe() }
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the selection control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Selection(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CHANGE_FILTER_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"A `Selection` control is a form element that allows users to select multiple options from a predefined list. It is commonly used in user interfaces to simplify interactions by enabling users to choose their desired options with simple clicks or markings.";

            Stage.Control = new ControlForm(null, new ControlFormItemInputSelection(null, [.. _options])
            {

            });

            Stage.Code = @"
            new ControlForm(new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem(""1"") { Label = ""Option 1"" })  
            {  
            });";

            Stage.AddProperty
            (
                "Multiselect",
                "The multiselect property is used in a Selection Control to allow users to choose multiple options from a list. By enabling this property, the control is configured to support flexible multi-selection rather than limiting users to a single choice.",
                "MultiSelect = true",
                new ControlForm(null, new ControlFormItemInputSelection(null, [.. _options])
                {
                    MultiSelect = true
                })
            );

            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field – a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = \"Placeholder\"",
                new ControlForm(null, new ControlFormItemInputSelection(null, [.. _options])
                {
                    Placeholder = "Placeholder"
                })
            );

            Stage.AddItem
            (
                "Label",
                "The `Label` property of a `Select` control item serves as a short form of the option text and is displayed in the main area of the control once a selection is made. Instead of showing the full descriptive text of an option, the label ensures a concise and clear representation of the chosen selection. When the label is defined as an internationalization key.",
                "new ControlFormItemInputSelectionItem() { Label = \"Label 1\" }",
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label 1" })
                {
                })
            );

            Stage.AddItem
            (
                "Content",
                "The `Content` property of a `Select` control item represents the full description of the selection option in the dropdown list. Unlike the Label property, which provides a shortened display in the main area of the control, Content contains the complete text of the option.",
                "new ControlFormItemInputSelectionItem() { Label=\"Label\", Content = new ControlText() { Text = \"Full **description** of the selection option\", Format = TypeFormatText.Markdown } }",
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", Content = new ControlText() { Text = "Full **description** of the selection option", Format = TypeFormatText.Markdown } })
                {
                })
            );

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a item. It provides a visual representation and identification of a option within the list structure, enhancing user guidance and recognition. Icons can be either system icons or custom icons, allowing flexibility in design and functionality. System icons offer a standardized visual language, ensuring consistency across applications, while custom icons enable tailored representations to meet specific user needs.",
                "new ControlFormItemInputSelectionItem() { Icon = new IconHome() }",
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Icon = new IconHome() })
                {
                })
            );

            Stage.AddItem
            (
                "Selected",
                "The `Icon` property defines the symbol assigned to a item. It provides a visual representation and identification of a option within the list structure, enhancing user guidance and recognition. Icons can be either system icons or custom icons, allowing flexibility in design and functionality. System icons offer a standardized visual language, ensuring consistency across applications, while custom icons enable tailored representations to meet specific user needs.",
                "new ControlFormItemInputSelectionItem() { Label = \"Label\", Selected = true }",
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", Selected = true })
                {
                })
            );

            Stage.AddItem
            (
                "LabelColor",
                "The `LabelColor` property defines the signature color of a `Select` control item’s label, visually highlighting the selected option. By customizing the color, the label can be styled to match the user interface or a specific design scheme, ensuring a consistent and appealing presentation.",
                "new ControlFormItemInputSelectionItem() { Label = \"Label\", LabelColor = TypeColorSelection.Primary, Selected = true }",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Default, Selected = true })
                {
                }),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Primary, Selected = true })
                {
                }),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Secondary, Selected = true })
                {
                }),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Info, Selected = true })
                {
                }),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Success, Selected = true })
                {
                }),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Warning, Selected = true })
                {
                }),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Danger, Selected = true })
                {
                }),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Light, Selected = true })
                {
                }),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputSelection(null, new ControlFormItemInputSelectionItem() { Label = "Label", LabelColor = TypeColorSelection.Dark, Selected = true })
                {
                })
            );
        }
    }
}
