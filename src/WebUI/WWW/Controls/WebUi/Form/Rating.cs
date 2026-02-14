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
    /// Represents the rating control for the tutorial.    
    /// </summary>    
    [Title("Rating")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Rating : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the rating control is used.</param>  
        /// <param name="componentHub">The component hub for managing components.</param>  
        public Rating(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.CHANGE_VALUE_EVENT, Event.CLICK_EVENT);

            Stage.Description = @"The `Rating` control provides an intuitive way for users to express feedback using stars. By selecting the desired number of stars, users can quickly and visually communicate their rating, creating a clear and engaging evaluation experience.";

            Stage.Control = new ControlForm("myform", new ControlFormItemInputRating(null)
            {
                Icon = new IconShieldCat(),
                Label = "Rating",
                Help = "Select the desired options here.",
                Name = "mRatingCtrl"
            }
                    .Initialize(args => args.Value.Number = 3)
                    .Process
                    (
                        x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $"Value: {x.Value}"))
                    )
                .AddPrimaryButton(new ControlFormItemButtonSubmit());

            Stage.Code = @"
            new ControlFormItemInputRating(null)
            {
                Icon = new IconShieldCat(),
                Label = ""Rating"",
                Help = ""Select the desired options here."",
                Name = ""mRatingCtrl""
            }
                    .Initialize(args => args.Value.Number = 3)
                    .Process
                    (
                        x => componentHub
                            .GetComponentManager<NotificationManager>()
                            .AddNotification(pageContext.ApplicationContext, $""Value: {x.Value}""))
                    )";

            Stage.AddProperty
            (
                "MaxRating",
                "The `MaxRating` property defines the maximum number of stars available in the `Rating` control. It allows developers to configure how many stars users can select, providing flexibility for different evaluation scales.",
                "new ControlFormItemInputRating(null) { MaxRating = 9 }",
                new ControlForm(null, new ControlFormItemInputRating(null)
                {
                    MaxRating = 9,
                })
            );

            Stage.AddItem
            (
                "Label",
                "The `Label` property of a `Rating` control item serves as a short form of the option text and is displayed in the main area of the control once a selection is made. Instead of showing the full descriptive text of an option, the label ensures a concise and clear representation of the chosen selection. When the label is defined as an internationalization key.",
                "new ControlFormItemInputRating(\"a\") { Label = \"Rating Label\" }",
                new ControlForm(null, new ControlFormItemInputRating("a")
                {
                    Label = "Rating Label"
                })
            );

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the symbol assigned to a rating field.",
                "new ControlFormItemInputRating(\"a\") { Icon = new IconHome() }",
                new ControlForm(null, new ControlFormItemInputRating("a")
                {
                    Icon = new IconHome()
                })
            );
        }
    }
}
