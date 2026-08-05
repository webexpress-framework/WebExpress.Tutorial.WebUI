using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the split button control for the tutorial.
    /// </summary>
    [WebIcon<IconControlSplitButton>]
    [Title("SplitButton")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class SplitButton : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the split button control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public SplitButton(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `SplitButton` control combines a primary button with a dropdown of related secondary actions. Use it wherever one action clearly dominates while its variants should stay within reach - saving with a *save as*, exporting in a second format. Unlike `SplitButtonLink`, whose primary part navigates to a uri, this control triggers an action, which makes it the right choice inside forms and toolbars.";

            Stage.Control = new ControlSplitButton()
            {
                Text = _ => "Save",
                Icon = _ => new IconSave(),
                BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
            }
                .Add
                (
                    new ControlSplitButtonItemLink()
                    {
                        Text = _ => "Save as..."
                    }
                );

            Stage.Code = @"
                new ControlSplitButton()
                {
                    Text = _ => ""Save"",
                    Icon = _ => new IconSave(),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                }
                    .Add
                    (
                        new ControlSplitButtonItemLink()
                        {
                            Text = _ => ""Save as...""
                        }
                    );";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the button.",
                "BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)",
                CreateExample("Default", null),
                CreateExample("Primary", new PropertyColorButton(TypeColorButton.Primary)),
                CreateExample("Secondary", new PropertyColorButton(TypeColorButton.Secondary)),
                CreateExample("Info", new PropertyColorButton(TypeColorButton.Info)),
                CreateExample("Success", new PropertyColorButton(TypeColorButton.Success)),
                CreateExample("Warning", new PropertyColorButton(TypeColorButton.Warning)),
                CreateExample("Danger", new PropertyColorButton(TypeColorButton.Danger)),
                CreateExample("Dark", new PropertyColorButton(TypeColorButton.Dark)),
                CreateExample("Light", new PropertyColorButton(TypeColorButton.Light)),
                CreateExample("Custom", new PropertyColorButton("gold"))
            );

            Stage.AddProperty
            (
                "Outline",
                "Removes the background color from the button and keeps its colored border, which subordinates the button to a filled one next to it.",
                "Outline = _ => true",
                CreateExample("Default", null, x => x.Outline = _ => true),
                CreateExample("Primary", new PropertyColorButton(TypeColorButton.Primary), x => x.Outline = _ => true),
                CreateExample("Success", new PropertyColorButton(TypeColorButton.Success), x => x.Outline = _ => true),
                CreateExample("Danger", new PropertyColorButton(TypeColorButton.Danger), x => x.Outline = _ => true),
                CreateExample("Custom", new PropertyColorButton("gold"), x => x.Outline = _ => true)
            );

            Stage.AddProperty
            (
                "Size",
                "Determines the size of the button.",
                "Size = _ => TypeSizeButton.Small",
                CreateExample("Small", new PropertyColorButton(TypeColorButton.Primary), x => x.Size = _ => TypeSizeButton.Small),
                CreateExample("Default", new PropertyColorButton(TypeColorButton.Primary), x => x.Size = _ => TypeSizeButton.Default),
                CreateExample("Large", new PropertyColorButton(TypeColorButton.Primary), x => x.Size = _ => TypeSizeButton.Large)
            );

            Stage.AddProperty
            (
                "Icon",
                "Adds an icon to the button.",
                "Icon = _ => new IconSave()",
                CreateExample("Save", new PropertyColorButton(TypeColorButton.Warning), x => x.Icon = _ => new IconSave()),
                CreateExample("Custom", new PropertyColorButton(TypeColorButton.Warning), x => x.Icon = _ => new ImageIcon(pageContext.ApplicationContext.Route.Concat("assets/img/webui.svg").ToUri(), new PropertySizeIcon(1, TypeSizeUnit.Em)))
            );

            Stage.AddProperty
            (
               "Block",
               "Spans the button across the entire width.",
               "Block = _ => TypeBlockButton.Block",
               CreateExample("Block", new PropertyColorButton(TypeColorButton.Primary), x => x.Block = _ => TypeBlockButton.Block)
            );

            Stage.AddProperty
            (
                "Active",
                "Sets the activation status of the button. A disabled button rejects both the primary action and the dropdown.",
                "Active = _ => TypeActive.Disabled",
                CreateExample("None", new PropertyColorButton(TypeColorButton.Primary), x => x.Active = _ => TypeActive.None),
                CreateExample("Active", new PropertyColorButton(TypeColorButton.Primary), x => x.Active = _ => TypeActive.Active),
                CreateExample("Disabled", new PropertyColorButton(TypeColorButton.Primary), x => x.Active = _ => TypeActive.Disabled)
            );

            Stage.AddProperty
            (
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = _ => new ActionModal(\"modal\")",
                new ControlSplitButton()
                {
                    Text = _ => "Click me!",
                    PrimaryAction = _ => new ActionModal("modal"),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
                    .Add(new ControlSplitButtonItemLink() { Text = _ => "Action" }),
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddProperty
            (
                "SecondaryAction",
                "Defines the secondary user action, often triggered by a double-click to open a dialog or perform an alternative operation.",
                "SecondaryAction = _ => new ActionModal(\"modal\")",
                new ControlSplitButton()
                {
                    Text = _ => "Double-click me!",
                    SecondaryAction = _ => new ActionModal("modal"),
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
                }
                    .Add(new ControlSplitButtonItemLink() { Text = _ => "Action" }),
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddItem
            (
                typeof(ControlSplitButtonItemLink),
                "ControlSplitButtonItemLink",
                "This item is displayed inside the dropdown section of the split button and carries one of the secondary actions.",
                "new ControlSplitButtonItemLink()",
                new ControlSplitButton()
                {
                    Text = _ => "Save",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                }
                    .Add
                    (
                        new ControlSplitButtonItemLink() { Text = _ => "Save as..." },
                        new ControlSplitButtonItemLink() { Text = _ => "Save a copy" }
                    )
            );

            Stage.AddItem
            (
                typeof(ControlSplitButtonItemHeader),
                "ControlSplitButtonItemHeader",
                "This item is displayed as a non-interactive header inside the dropdown section and is used to group related actions.",
                "new ControlSplitButtonItemHeader()",
                new ControlSplitButton()
                {
                    Text = _ => "Export",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                }
                    .Add
                    (
                        new ControlSplitButtonItemHeader() { Text = _ => "Formats" },
                        new ControlSplitButtonItemLink() { Text = _ => "PDF" },
                        new ControlSplitButtonItemLink() { Text = _ => "CSV" }
                    )
            );

            Stage.AddItem
            (
                typeof(ControlSplitButtonItemDivider),
                "ControlSplitButtonItemDivider",
                "This item is displayed as a visual divider inside the dropdown section and separates groups of related actions.",
                "new ControlSplitButtonItemDivider()",
                new ControlSplitButton()
                {
                    Text = _ => "Export",
                    BackgroundColor = _ => new PropertyColorButton(TypeColorButton.Primary)
                }
                    .Add
                    (
                        new ControlSplitButtonItemLink() { Text = _ => "PDF" },
                        new ControlSplitButtonItemDivider(),
                        new ControlSplitButtonItemLink() { Text = _ => "Print" }
                    )
            );
        }

        /// <summary>
        /// Builds a split button carrying a single dropdown action, so a property act
        /// can vary one aspect while everything else stays identical.
        /// </summary>
        /// <param name="text">The button text.</param>
        /// <param name="backgroundColor">The background color, or null for the default one.</param>
        /// <param name="customize">An optional customization applied to the button.</param>
        /// <returns>The example button.</returns>
        private static ControlSplitButton CreateExample(string text, PropertyColorButton backgroundColor, System.Action<ControlSplitButton> customize = null)
        {
            var button = new ControlSplitButton()
            {
                Text = _ => text,
                BackgroundColor = _ => backgroundColor,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.Two)
            };

            customize?.Invoke(button);
            button.Add(new ControlSplitButtonItemLink() { Text = _ => "Action" });

            return button;
        }
    }
}
