using System.Collections.Generic;
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
    /// Represents the form control for the tutorial.    
    /// </summary>    
    [Title("Form")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : PageControl
    {
        private readonly IEnumerable<IControlFormItem> _exampleFormItems =
        [
            new ControlFormItemInputText("username")
            {
                Label = _ => "Username",
                Required =_ =>  true,
                Icon = _ => new IconFont(),
                Help = _ => "Enter your desired username."
            }.Validate(x => x.Add(string.IsNullOrWhiteSpace(x.Value.Text), "Username is required. Please enter a valid name.")),
            new ControlFormItemInputText("email")
            {
                Label =_ =>  "Email Address",
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
                Label =_ =>  "Country",
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
        /// <param name="pageContext">The context of the page where the form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Index(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"A `Form` control is used to structure, validate, and submit user input to a server. It organizes various fields such as text boxes, dropdowns, and buttons, ensuring a seamless and user-friendly experience. Additionally, it incorporates validation mechanisms to maintain data accuracy and prevent errors before sending the information for processing.";

            Stage.Control = new ControlForm("myform")
                .Add(new ControlFormItemInputText("regards")
                {
                    Required = _ => true,
                    Label = _ => "Greetings",
                    Icon = _ => new IconFont(),
                    Help = _ => "This is the associated help text."
                }.Initialize(args => args.Value.Text = "Hello World!"))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm(""myform"", new ControlFormItemInputTextBox(""regards"")
            {
                Label = _ => ""Greetings"",
                Value = _ => ""Hello World!"",
                Icon = _ => new IconFont(),
                Help = _ => "" This is the associated help text.""
            })
            {
            }.AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "FormLayout",
                "This property defines the visual positioning of form elements relative to the submit button.",
                "FormLayout = _ => TypeLayoutForm.Inline",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputText("layout1") { Icon = _ => new IconAlignLeft(), Label = _ => "Arrangement", Help = _ => "This is a help text" })
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    FormLayout = _ => TypeLayoutForm.Default
                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = _ => "Inline", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, new ControlFormItemInputText("layout1") { Icon = _ => new IconAlignLeft(), Label = _ => "Arrangement", Help = _ => "This is a help text" })
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    FormLayout = _ => TypeLayoutForm.Inline
                }.AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "ItemLayout",
                "This property defines how the form elements are arranged within the form, ensuring a structured and user-friendly layout.",
                "ItemLayout = _ => TypeLayoutFormItem.Horizontal",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two)

                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = _ => "Horizontal", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    ItemLayout = _ => TypeLayoutFormItem.Horizontal
                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = _ => "Vertical", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    ItemLayout = _ => TypeLayoutFormItem.Vertical
                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = _ => "Mix", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    ItemLayout = _ => TypeLayoutFormItem.Mix
                }.AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "AddButton",
                "This method enables adding buttons to control the behavior of the form, such as submitting, resetting, or canceling actions.",
                "new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset()",
                new ControlText() { Text = _ => "AddPreferencesButton", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two)

                }.AddPreferencesButton(new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset()),
                new ControlText() { Text = _ => "AddPrimaryButton", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two)
                }.AddPrimaryButton(new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset()),
                new ControlText() { Text = _ => "AddSecondaryButton", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two)
                }.AddSecondaryButton(new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset())
            );

            Stage.AddProperty
            (
                "Conformation",
                "The property represents the control that is displayed instead of the original form after the form has been successfully submitted. It provides visual feedback to the user by showing a confirmation element, indicating that the submission was successful. This enhances the user experience by offering clear acknowledgment of the completed action. For example, if the form involves a registration or an order, a thank-you message or a summary of the submitted data can appear in place of the form, allowing the user to immediately recognize that their input has been processed.",
                @"
                Conformation = _ => new ControlAlert() 
                { 
                    Text = _ => ""Thank you!"", 
                    BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackground.Success) 
                }",
                new ControlForm("conformationform", items: [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Conformation = _ => new ControlAlert()
                    {
                        Text = _ => @"Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime.",
                        BackgroundColor = _ => new PropertyColorBackgroundAlert(TypeColorBackgroundAlert.Success)
                    }

                }.AddPreferencesButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "RedirectUri",
                "The `RedirectUri` property specifies the target address to which the user is redirected after the form has been successfully submitted. This can be used, for example, to direct the user to a welcome page after registration or to an order confirmation page after a purchase.",
                @"RedirectUri = _ => pageContext.ApplicationContext.Route.ToUri()",
                new ControlForm(null, [.. _exampleFormItems])
                {
                    Border = _ => new PropertyBorder(true),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = _ => new PropertySpacingPadding(PropertySpacing.Space.Two),
                    RedirectUri = _ => pageContext.ApplicationContext.Route.ToUri()

                }.AddPreferencesButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddItem
            (
                typeof(ControlFormItemGroupTab),
                "ControlFormItemGroupTab",
                "",
                "Add(new ControlFormItemGroupTab())",
                new ControlForm(null)
                {

                }
                    .Add(new ControlFormItemGroupTab()
                        .AddView(new ControlFormItemGroupTabView() { Title = _ => "Tab A" }
                            .Add(new ControlFormItemInputText("regards")
                            {
                                Required = _ => true,
                                Label = _ => "Greetings",
                                Icon = _ => new IconFont(),
                                Help = _ => "This is the associated help text."
                            }))
                        .AddView(new ControlFormItemGroupTabView() { Title = _ => "Tab B" }
                            .Add(new ControlFormItemInputText("regards")
                            {
                                Required = _ => true,
                                Label = _ => "Greetings",
                                Icon = _ => new IconFont(),
                                Help = _ => "This is the associated help text."
                            }))
                        )
                    .AddPreferencesButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
