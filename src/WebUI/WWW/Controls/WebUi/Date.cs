using System;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the date control for the tutorial.  
    /// </summary>  
    [Title("Date")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Date : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        public Date(IPageContext pageContext)
        {
            Stage.Description = @"The `DateControl` is a read-only component used to visually represent date values. This makes it ideal for consistently highlighting and displaying dates in applications.";

            Stage.Controls = [
                new ControlDate()
                {
                     Date = DateTime.Now
                }
            ];

            Stage.Code = @"
            new ControlDate()
            {
                    Date = DateTime.Now
            };";

            Stage.AddProperty
            (
                "Date",
                "The `Date` property defines the actual date value displayed within the `Date` control. By assigning a `DateTime` value, you can control which date is shown, ensuring clarity and consistency across the user interface.",
                "Date = DateTime.Now.AddDays(-5)",
                new ControlDate() { Date = DateTime.Now.AddDays(-5) }
            );

            Stage.AddProperty
            (
                "Format",
                "The `Format` property defines how the date value is displayed within the `Date` control. By specifying a format string (e.g., `dd.MM.yyyy`), you can control the appearance of the date, ensuring clarity and consistency across the user interface.",
                "Format = \"dd.MM.yyyy\"",
                new ControlDate() { Date = DateTime.Now, Format = "dd.MM.yyyy" }
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the visual color applied to all tags within the `Date` control. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "Color = new PropertyColorTag(TypeColorTag.Warning)",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Default) },
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Primary) },
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Secondary) },
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Info) },
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Success) },
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Warning) },
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Danger) },
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Light) },
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate(TypeColorDate.Dark) },
                new ControlText() { Text = "User defind", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = DateTime.Now, Color = new PropertyColorDate("gold") }
            );
        }
    }
}
