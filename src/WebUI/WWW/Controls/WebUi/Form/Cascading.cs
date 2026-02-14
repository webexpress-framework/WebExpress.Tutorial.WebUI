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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Form
{
    /// <summary>    
    /// Represents the cascading control for the tutorial.    
    /// </summary>    
    [Title("Cascading")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Cascading : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the selection control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Cascading(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CHANGE_FILTER_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"A `Cascading` control is a form element that allows users to select multiple options from a predefined list in a cascading or hierarchical manner. It simplifies interactions by enabling smooth transitions between interconnected selection options.";

            Stage.Control = new ControlForm(null, new ControlFormItemInputCascading(null, [.. GetOptions()])
            {

            });

            Stage.Code = @"
            new ControlForm(new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem(""1"") { Label = ""Option 1"" })  
            {  
            });";


            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field – a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = \"Placeholder\"",
                new ControlForm(null, new ControlFormItemInputCascading(null, [.. GetOptions()])
                {
                    Placeholder = "Placeholder"
                })
            );

            Stage.AddItem
            (
                "Text",
                "The `Text` property of a `Cascading` control item serves as a short form of the option text and is displayed in the main area of the control once a selection is made. Instead of showing the full descriptive text of an option, the label ensures a concise and clear representation of the chosen selection. When the label is defined as an internationalization key.",
                "new ControlFormItemInputCascadingItem() { Text = \"Text 1\" }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Text 1" })
                {
                })
            );

            Stage.AddItem
            (
                "Content",
                "The `Content` property of a `Cascading` control item represents the full description of the selection option in the dropdown list. Unlike the Label property, which provides a shortened display in the main area of the control, Content contains the complete text of the option.",
                "new ControlFormItemInputCascadingItem() { Text=\"Text 2\", Content = new ControlText() { Text = \"Full **description** of the selection option\", Format = TypeFormatText.Markdown } }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Text 2", Content = new ControlText() { Text = "Full **description** of the selection option", Format = TypeFormatText.Markdown } })
                {
                })
            );

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a item. It provides a visual representation and identification of a option within the list structure, enhancing user guidance and recognition. Icons can be either system icons or custom icons, allowing flexibility in design and functionality. System icons offer a standardized visual language, ensuring consistency across applications, while custom icons enable tailored representations to meet specific user needs.",
                "new ControlFormItemInputCascadingItem() { Icon = new IconHome() }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Icon = new IconHome() })
                {
                })
            );

            Stage.AddItem
            (
                "LabelColor",
                "The `LabelColor` property defines the signature color of a `Cascading` control item’s label, visually highlighting the selected option. By customizing the color, the label can be styled to match the user interface or a specific design scheme, ensuring a consistent and appealing presentation.",
                "new ControlFormItemInputCascadingItem() { Label = \"Label\", LabelColor = TypeColorSelection.Primary, Selected = true }",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Default })
                {
                }),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Primary })
                {
                }),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Secondary })
                {
                }),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Info })
                {
                }),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Success })
                {
                }),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Warning })
                {
                }),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Danger })
                {
                }),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Light })
                {
                }),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = "Label", LabelColor = TypeColorSelection.Dark })
                {
                })
            );
        }

        /// <summary>
        /// Retrieves a collection of available cascading input options for use in a control form.
        /// </summary>
        /// <returns>
        /// An enumerable collection of <see cref="IControlFormItemInputCascadingItem"/> objects representing the
        /// selectable options. The collection may be empty if no options are available.
        /// </returns>
        private IEnumerable<IControlFormItemInputCascadingItem> GetOptions()
        {
            yield return new ControlFormItemInputCascadingItem("1")
            {
                Text = "Option 1",
                Icon = new IconSquare()
            }
                .Add(new ControlFormItemInputCascadingItem("1.1") { Text = "Option 1.1", Icon = new IconSquare() })
                .Add(new ControlFormItemInputCascadingItem("1.2") { Text = "Option 1.2", Icon = new IconSquare() });

            yield return new ControlFormItemInputCascadingItem("2")
            {
                Text = "Option 2",
                Icon = new IconCar()
            }
                .Add(new ControlFormItemInputCascadingItem("2.1") { Text = "Option 2.1", Icon = new IconCar() });

            yield return new ControlFormItemInputCascadingItem("3")
            {
                Text = "Option 3",
                Icon = new IconAsterisk()
            }
                .Add(new ControlFormItemInputCascadingItem("3.1") { Text = "Option 3.1", Icon = new IconAsterisk() })
                .Add(new ControlFormItemInputCascadingItem("3.2") { Text = "Option 3.2", Icon = new IconAsterisk() })
                .Add(new ControlFormItemInputCascadingItem("3.3") { Text = "Option 3.3", Icon = new IconAsterisk() });

            yield return new ControlFormItemInputCascadingItem("4") { Text = "Option 4", Icon = new IconBaseball() };

            yield return new ControlFormItemInputCascadingItem("5") { Text = "Option 5", Icon = new IconFloppyDisk() };

            yield return new ControlFormItemInputCascadingItem("6") { Text = "Option 6", Icon = new IconSeedling() };

            yield return new ControlFormItemInputCascadingItem("7")
            {
                Text = "Option 7",
                Icon = new IconRoute()
            }
                .Add(new ControlFormItemInputCascadingItem("7.1") { Text = "Option 7.1", Icon = new IconRoute() })
                .Add(new ControlFormItemInputCascadingItem("7.2") { Text = "Option 7.2", Icon = new IconRoute() });

            yield return new ControlFormItemInputCascadingItem("8") { Text = "Option 9", Icon = new IconClipboard() };

            yield return new ControlFormItemInputCascadingItem("10") { Text = "Option 10", Icon = new IconGlobe() };
        }
    }
}
