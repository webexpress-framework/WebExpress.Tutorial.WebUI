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
            new ControlForm(new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem(""1"") { Label = _ => ""Option 1"" })  
            {  
            });";


            Stage.AddProperty
            (
                "Placeholder",
                "Sets the placeholder of the search field – a temporary text display that informs the user about the expected input. The placeholder disappears once the user starts typing a search query.",
                "Placeholder = _ => \"Placeholder\"",
                new ControlForm(null, new ControlFormItemInputCascading(null, [.. GetOptions()])
                {
                    Placeholder = _ => "Placeholder"
                })
            );


            Stage.AddItem
            (
                typeof(ControlFormItemInputCascadingItem),
                "ControlFormItemInputCascadingItem",
                "A `ControlFormItemInputCascadingItem` represents a single selectable option within a cascading input control. Each item defines the value, label, and optional metadata used to populate hierarchical or dependency‑based selections. Cascading items are typically used when choices depend on previous selections, enabling users to navigate structured option sets step by step. By encapsulating each option as an individual item, `ControlFormItemInputCascadingItem` ensures clear data separation, consistent rendering, and flexible internationalization within complex form inputs.",
                "new ControlFormItemInputCascadingItem() { Text = _ => \"Text 1\" }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Text 1" })
                {
                })
            );

            Stage.AddItemProperty
            (
                typeof(ControlFormItemInputCascadingItem),
                "Text",
                "The `Text` property of a `Cascading` control item serves as a short form of the option text and is displayed in the main area of the control once a selection is made. Instead of showing the full descriptive text of an option, the label ensures a concise and clear representation of the chosen selection. When the label is defined as an internationalization key.",
                "new ControlFormItemInputCascadingItem() { Text = \"Text 1\" }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Text 1" })
                {
                })
            );

            Stage.AddItemProperty
            (
                typeof(ControlFormItemInputCascadingItem),
                "Content",
                "The `Content` property of a `Cascading` control item represents the full description of the selection option in the dropdown list. Unlike the Label property, which provides a shortened display in the main area of the control, Content contains the complete text of the option.",
                "new ControlFormItemInputCascadingItem() { Text = _ => \"Text 2\", Content = _ => new ControlText() { Text = _ => \"Full **description** of the selection option\", Format = _ => TypeFormatText.Markdown } }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Text 2", Content = new ControlText() { Text = _ => "Full **description** of the selection option", Format = _ => TypeFormatText.Markdown } })
                {
                })
            );

            Stage.AddItemProperty
            (
                typeof(ControlFormItemInputCascadingItem),
                "Icon",
                "The `Icon` property defines the symbol assigned to a item. It provides a visual representation and identification of a option within the list structure, enhancing user guidance and recognition. Icons can be either system icons or custom icons, allowing flexibility in design and functionality. System icons offer a standardized visual language, ensuring consistency across applications, while custom icons enable tailored representations to meet specific user needs.",
                "new ControlFormItemInputCascadingItem() { Icon = _ => new IconHome() }",
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Icon = _ => new IconHome() })
                {
                })
            );

            Stage.AddItemProperty
            (
                typeof(ControlFormItemInputCascadingItem),
                "LabelColor",
                "The `LabelColor` property defines the signature color of a `Cascading` control item’s label, visually highlighting the selected option. By customizing the color, the label can be styled to match the user interface or a specific design scheme, ensuring a consistent and appealing presentation.",
                "new ControlFormItemInputCascadingItem() { Label = _ => \"Label\", LabelColor = _ => TypeColorSelection.Primary, Selected = _ => true }",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Default })
                {
                }),
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Primary })
                {
                }),
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Secondary })
                {
                }),
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Info })
                {
                }),
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Success })
                {
                }),
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Warning })
                {
                }),
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Danger })
                {
                }),
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Light })
                {
                }),
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputCascading(null, new ControlFormItemInputCascadingItem() { Text = _ => "Label", LabelColor = _ => TypeColorSelection.Dark })
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
                Text = _ => "Option 1",
                Icon = _ => new IconSquare()
            }
                .Add(new ControlFormItemInputCascadingItem("1.1") { Text = _ => "Option 1.1", Icon = _ => new IconSquare() })
                .Add(new ControlFormItemInputCascadingItem("1.2") { Text = _ => "Option 1.2", Icon = _ => new IconSquare() });

            yield return new ControlFormItemInputCascadingItem("2")
            {
                Text = _ => "Option 2",
                Icon = _ => new IconCar()
            }
                .Add(new ControlFormItemInputCascadingItem("2.1") { Text = _ => "Option 2.1", Icon = _ => new IconCar() });

            yield return new ControlFormItemInputCascadingItem("3")
            {
                Text = _ => "Option 3",
                Icon = _ => new IconAsterisk()
            }
                .Add(new ControlFormItemInputCascadingItem("3.1") { Text = _ => "Option 3.1", Icon = _ => new IconAsterisk() })
                .Add(new ControlFormItemInputCascadingItem("3.2") { Text = _ => "Option 3.2", Icon = _ => new IconAsterisk() })
                .Add(new ControlFormItemInputCascadingItem("3.3") { Text = _ => "Option 3.3", Icon = _ => new IconAsterisk() });

            yield return new ControlFormItemInputCascadingItem("4") { Text = _ => "Option 4", Icon = _ => new IconBaseball() };

            yield return new ControlFormItemInputCascadingItem("5") { Text = _ => "Option 5", Icon = _ => new IconFloppyDisk() };

            yield return new ControlFormItemInputCascadingItem("6") { Text = _ => "Option 6", Icon = _ => new IconSeedling() };

            yield return new ControlFormItemInputCascadingItem("7")
            {
                Text = _ => "Option 7",
                Icon = _ => new IconRoute()
            }
                .Add(new ControlFormItemInputCascadingItem("7.1") { Text = _ => "Option 7.1", Icon = _ => new IconRoute() })
                .Add(new ControlFormItemInputCascadingItem("7.2") { Text = _ => "Option 7.2", Icon = _ => new IconRoute() });

            yield return new ControlFormItemInputCascadingItem("8") { Text = _ => "Option 9", Icon = _ => new IconClipboard() };

            yield return new ControlFormItemInputCascadingItem("10") { Text = _ => "Option 10", Icon = _ => new IconGlobe() };
        }
    }
}
