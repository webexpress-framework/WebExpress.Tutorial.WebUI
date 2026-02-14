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
    /// Represents the date date field for the tutorial.    
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
        /// <param name="pageContext">The context of the page where the date field is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Date(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.DROPDOWN_SHOW_EVENT, Event.DROPDOWN_HIDDEN_EVENT);

            Stage.Description = @"The `Date` field enables intuitive selection of a date via a calendar. Users can conveniently select a date, providing a user-friendly and efficient interaction.";

            Stage.Control = new ControlForm("myform", new ControlFormItemInputDate(null)
            {
                Icon = new IconCalendar(),
                Label = "Date",
                Help = "Select the desired date here.",
                Name = "myDateCtrl"
            }
                .Initialize(args => args.Value.Date = DateTime.Now)
                .Process(x => componentHub
                    .GetComponentManager<NotificationManager>()
                    .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
            )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.DarkControls = [new ControlForm("myform", new ControlFormItemInputDate(null)
              {
                  Icon = new IconCalendar(),
                  Label = "Date",
                  Help = "Select the desired date here.",
                  Name = "myDateCtrl"
              }
                 .Initialize(args => args.Value.Date = DateTime.Now)
                 .Process(x => componentHub
                     .GetComponentManager<NotificationManager>()
                     .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
             )
                 .AddPrimaryButton(new ControlFormItemButtonSubmit())];

            Stage.Code = @"
                  new ControlForm(""myform"", new ControlFormItemInputDate(null)
                  {
                      Icon = new IconCalendar(),
                      Label = ""Date"",
                      Help = ""Select the desired date here."",
                      Name = ""myDateCtrl""
                  }
                      .Initialize(args => args.Value.From = DateTime.Now)
                      .Process(x => componentHub
                          .GetComponentManager<NotificationManager>()
                          .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
                  )
                      .AddPrimaryButton(new ControlFormItemButtonSubmit());";

            Stage.AddProperty
            (
                "Label",
                "The `Label` property of the date field serves as a short description and is displayed in the main area of the control. It ensures a clear and concise presentation of the selection.",
                "Label = \"Date\"",
                new ControlForm(null, new ControlFormItemInputDate(null)
                {
                    Icon = new IconCalendar(),
                    Label = "Date",
                    Help = "Select the desired date here.",
                    Name = "myDarkDateCtrl"
                })
            );

            Stage.AddProperty
            (
                "Help",
                "The `Help` property provides a help text that gives the user additional information on how to use the date field.",
                "Help = \"Select a date.\"",
                new ControlForm(null, new ControlFormItemInputDate(null)
                {
                    Help = "Select a date."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the date field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconCalendarDay()",
                new ControlForm(null, new ControlFormItemInputDate(null)
                {
                    Icon = new IconCalendarDay()
                })
            );

            Stage.AddProperty
            (
                "Format",
                @"The `Format` property specifies the date or time pattern used to display values within the calendar input control. It accepts a format string based on the standard .NET date and time formatting conventions, such as ""yyyy-MM-dd"" for a year-month-day format or ""dd.MM.yyyy"" for a more localized European style. This pattern determines both how the value appears in the user interface and how it is represented as a string internally or in serialized output. If no format is specified, the control automatically uses the short date pattern defined by the current culture, as determined by the system's regional settings.",
                @"Format = ""dd.MM.yyyy""",
                new ControlForm(null, new ControlFormItemInputDate(null)
                {
                    Format = "dd.MM.yyyy"
                })
            );
        }
    }
}
