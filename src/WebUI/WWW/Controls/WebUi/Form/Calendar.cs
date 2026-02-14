using System;
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
    /// Represents the calendar selection field for the tutorial.    
    /// </summary>    
    [Title("Calendar")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Calendar : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the calendar field is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Calendar(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT);

            Stage.Description = @"The `Calendar` field enables intuitive selection of a date via a calendar. Users can conveniently select a date, providing a user-friendly and efficient interaction.";

            Stage.Control = new ControlForm("myform", new ControlFormItemInputCalendar(null)
            {
                Icon = new IconCalendar(),
                Label = "Calendar",
                Help = "Select the desired date here.",
                Name = "myCalendarCtrl"
            }
                .Initialize(args => args.Value.Date = DateTime.Now)
                .Process(x => componentHub
                    .GetComponentManager<NotificationManager>()
                    .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
            )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
                    new ControlForm(""myform"", new ControlFormItemInputDatepicker(null)
                    {
                        Icon = new IconCalendar(),
                        Label = ""Calendar"",
                        Help = ""Select the desired date here."",
                        Name = ""myCalendarCtrl""
                    }
                        .Initialize(args => args.Value.Date = DateTime.Now)
                        .Process(x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
                    )
                        .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the calendar field serves as a short description and is displayed in the main area of the control. It ensures a clear and concise presentation of the selection.",
                "Label = \"Calendar\"",
                new ControlForm(null, new ControlFormItemInputCalendar(null)
                {
                    Icon = new IconCalendar(),
                    Label = "Calendar",
                    Help = "Select the desired date here.",
                    Name = "myDarkCalendarCtrl"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the calendar field.",
                "Help = \"Select a date.\"",
                new ControlForm(null, new ControlFormItemInputCalendar(null)
                {
                    Help = "Select a date."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the calendar field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconCalendarDay()",
                new ControlForm(null, new ControlFormItemInputCalendar(null)
                {
                    Icon = new IconCalendarDay()
                })
            );

            Stage.AddProperty
            (
                "Format",
                @"The `Format` property specifies the date or time pattern used to display values within the calendar input control. It accepts a format string based on the standard .NET date and time formatting conventions, such as ""YYYY-MM-DD"" for a year-month-day format or ""DD.MM.YYYY"" for a more localized European style. This pattern determines both how the value appears in the user interface and how it is represented as a string internally or in serialized output. If no format is specified, the control automatically uses the short date pattern defined by the current culture, as determined by the system's regional settings.",
                @"Format = ""DD.MM.YYYY""",
                new ControlForm(null, new ControlFormItemInputCalendar(null)
                {
                    Format = "DD.MM.YYYY"
                })
            );

            Stage.AddProperty
            (
                "Range",
                @"The `Range` property indicates whether the calendar control allows selection of a date range instead of a single date. When enabled, the expected input value is a string containing two dates separated by a hyphen (-), such as ""2025-07-01 - 2025-07-10"". The exact date format used for each value in the range depends on the format defined by the Format property—for example, ""DD.MM.YYYY - DD.MM.YYYY"" in a German locale.",
                @"Range = true",
                new ControlForm(null, new ControlFormItemInputCalendar(null)
                {
                    Range = true
                })
            );
        }
    }
}
