using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebNotification;
using WebUI.Model;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls.Form
{
    /// <summary>    
    /// Represents the date selection field for the tutorial.    
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

            Stage.Control = new ControlForm("myform", new ControlFormItemInputDatepicker(null)
            {
                Icon = new IconCalendar(),
                Label = "Date",
                Help = "Select the desired date here.",
                Name = "myDateCtrl"
            }
                .Initialize(args => args.Value = "2024-06-01")
                .Process(x => componentHub
                    .GetComponentManager<NotificationManager>()
                    .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
            )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
                new ControlForm(""myform"", new ControlFormItemInputDatepicker(null)
                {
                    Icon = new IconCalendar(),
                    Label = ""Date"",
                    Help = ""Select the desired date here."",
                    Name = ""myDateCtrl""
                }
                    .Initialize(args => args.Value = ""2024-06-01"")
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
                new ControlForm(null, new ControlFormItemInputDatepicker(null)
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
                new ControlForm(null, new ControlFormItemInputDatepicker(null)
                {
                    Help = "Select a date."
                })
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property defines the icon associated with the date field. It provides visual support and makes it easier to identify the field.",
                "Icon = new IconCalendarDay()",
                new ControlForm(null, new ControlFormItemInputDatepicker(null)
                {
                    Icon = new IconCalendarDay()
                })
            );
        }
    }
}
