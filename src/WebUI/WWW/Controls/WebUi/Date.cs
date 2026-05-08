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
                     Date = _ => DateTime.Now
                }
            ];

            Stage.Code = @"
            new ControlDate()
            {
                    Date = _ => DateTime.Now
            };";

            Stage.AddProperty
            (
                "Date",
                "The `Date` property defines the actual date value displayed within the `Date` control. By assigning a `DateTime` value, you can control which date is shown, ensuring clarity and consistency across the user interface.",
                "Date = _ => DateTime.Now.AddDays(-5)",
                new ControlDate() { Date = _ => DateTime.Now.AddDays(-5) }
            );

            Stage.AddProperty
            (
                "Format",
                "The `Format` property defines how the date value is displayed within the `Date` control. By specifying a format string (e.g., `dd.MM.yyyy`), you can control the appearance of the date, ensuring clarity and consistency across the user interface.",
                "Format = _ => \"dd.MM.yyyy\"",
                new ControlDate() { Date = _ => DateTime.Now, Format = _ => "dd.MM.yyyy" }
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property defines the visual color applied to all tags within the `Date` control. This uniform color enhances clarity, improves recognition, and ensures a cohesive user interface experience.",
                "Color = _ => new PropertyColorTag(TypeColorTag.Warning)",
                new ControlText() { Text = _ => "Default", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Default) },
                new ControlText() { Text = _ => "Primary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Primary) },
                new ControlText() { Text = _ => "Secondary", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Secondary) },
                new ControlText() { Text = _ => "Info", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Info) },
                new ControlText() { Text = _ => "Success", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Success) },
                new ControlText() { Text = _ => "Warning", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Warning) },
                new ControlText() { Text = _ => "Danger", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Danger) },
                new ControlText() { Text = _ => "Light", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Light) },
                new ControlText() { Text = _ => "Dark", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Dark) },
                new ControlText() { Text = _ => "Highlight", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate(TypeColorDate.Highlight) },
                new ControlText() { Text = _ => "User defind", TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlDate() { Date = _ => DateTime.Now, Color = _ => new PropertyColorDate("gold") }
            );
        }
    }
}
