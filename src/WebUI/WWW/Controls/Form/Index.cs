using System.Collections.Generic;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the selection control for the tutorial.    
    /// </summary>    
    [Title("Form")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : PageControl
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
        /// <param name="pageContext">The context of the page where the form control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Index(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"A `Form` control is used to structure, validate, and submit user input to a server. It organizes various fields such as text boxes, dropdowns, and buttons, ensuring a seamless and user-friendly experience. Additionally, it incorporates validation mechanisms to maintain data accuracy and prevent errors before sending the information for processing.";

            Stage.Control = new ControlForm("myform")
                .Add(new ControlFormItemInputTextBox("regards")
                {
                    Label = "Greetings",
                    Icon = new IconFont(),
                    Help = "This is the associated help text."
                }.Initialize(args => args.Value = "Hello World!"))
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlForm(""myform"", new ControlFormItemInputTextBox(""regards"")
            {
                Label = ""Greetings"",
                Value = ""Hello World!"",
                Icon = new IconFont(),
                Help = "" This is the associated help text.""
            })
            {
            }.AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "FormLayout",
                "This property defines the visual positioning of form elements relative to the submit button.",
                "FormLayout = TypeLayoutForm.Inline",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTextBox("layout1") { Icon = new IconAlignLeft(), Label = "Arrangement", Help = "This is a help text" })
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    FormLayout = TypeLayoutForm.Default
                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = "Inline", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: new ControlFormItemInputTextBox("layout1") { Icon = new IconAlignLeft(), Label = "Arrangement", Help = "This is a help text" })
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    FormLayout = TypeLayoutForm.Inline
                }.AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "ItemLayout",
                "This property defines how the form elements are arranged within the form, ensuring a structured and user-friendly layout.",
                "ItemLayout = TypeLayoutFormItem.Horizontal",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)

                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = "Horizontal", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    ItemLayout = TypeLayoutFormItem.Horizontal
                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = "Vertical", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    ItemLayout = TypeLayoutFormItem.Vertical
                }.AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlText() { Text = "Mix", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    ItemLayout = TypeLayoutFormItem.Mix
                }.AddPrimaryButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "AddButton",
                "This method enables adding buttons to control the behavior of the form, such as submitting, resetting, or canceling actions.",
                "new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset()",
                new ControlText() { Text = "AddPreferencesButton", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)

                }.AddPreferencesButton(new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset()),
                new ControlText() { Text = "AddPrimaryButton", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)
                }.AddPrimaryButton(new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset()),
                new ControlText() { Text = "AddSecondaryButton", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two)
                }.AddSecondaryButton(new ControlFormItemButtonSubmit(), new ControlFormItemButtonReset())
            );

            Stage.AddProperty
            (
                "Conformation",
                "The property represents the control that is displayed instead of the original form after the form has been successfully submitted. It provides visual feedback to the user by showing a confirmation element, indicating that the submission was successful. This enhances the user experience by offering clear acknowledgment of the completed action. For example, if the form involves a registration or an order, a thank-you message or a summary of the submitted data can appear in place of the form, allowing the user to immediately recognize that their input has been processed.",
                @"
                Conformation = new ControlAlert() 
                { 
                    Text = ""Thank you!"", 
                    BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success) 
                }",
                new ControlForm("conformationform", items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    Conformation = new ControlAlert()
                    {
                        Text = @"Thank you! Your submission has been successfully received. We have received your request and will process it as soon as possible. If you need any further information, feel free to reach out to us anytime.",
                        BackgroundColor = new PropertyColorBackgroundAlert(TypeColorBackground.Success)
                    }

                }.AddPreferencesButton(new ControlFormItemButtonSubmit())
            );

            Stage.AddProperty
            (
                "RedirectUri",
                "The `RedirectUri` property specifies the target address to which the user is redirected after the form has been successfully submitted. This can be used, for example, to direct the user to a welcome page after registration or to an order confirmation page after a purchase.",
                @"RedirectUri = pageContext.ApplicationContext.Route.ToUri()",
                new ControlForm(items: [.. _exampleFormItems])
                {
                    Border = new PropertyBorder(true),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                    RedirectUri = pageContext.ApplicationContext.Route.ToUri()

                }.AddPreferencesButton(new ControlFormItemButtonSubmit())
            );
        }
    }
}
