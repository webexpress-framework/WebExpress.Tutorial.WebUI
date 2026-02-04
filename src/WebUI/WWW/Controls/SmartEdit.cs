using System;
using System.Globalization;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>  
    /// Represents the smart edit control for the tutorial.  
    /// </summary>  
    [Title("SmartEdit")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class SmartEdit : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the tree control is used.</param>
        /// <param name="componentHub">
        /// The component hub instance used to manage components and 
        /// their interactions within the application.
        /// </param>
        public SmartEdit(IPageContext pageContext, IComponentHub componentHub)
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `SmartEdit` is a versatile control for inline editing of values directly within HTML elements. It extends the functionality of conventional display elements with the ability to edit these values comfortably and without changing the editing context. When hovering over a target element with the mouse, a pencil icon appears to the right of the content, serving as an edit button. Clicking the pencil opens an editor form at that exact position, allowing the values to be edited. The input can either be accepted and saved or canceled. The choice of editor is flexible and can be customized, allowing for the use of simple text fields or specialized components like a code editor.";

            Stage.Controls = [
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText().Initialize(x => x.Value.Text = "Hello WebExpress!")
                    .Process(x =>
                    {
                        var notificationManager = componentHub.GetComponentManager<NotificationManager>();
                        notificationManager.AddNotification
                        (
                            pageContext.ApplicationContext,
                            "Changes saved – great job!",
                            type: TypeNotification.Success
                        );
                    }))
            ];

            Stage.DarkControls = [
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText().Initialize(x => x.Value.Text = "Hello WebExpress!")
                    .Process(x =>
                    {
                        var notificationManager = componentHub.GetComponentManager<NotificationManager>();
                        notificationManager.AddNotification
                        (
                            pageContext.ApplicationContext,
                            "Your text has been updated successfully!"
                        );
                    }))
            ];

            Stage.Code = @"
            new ControlSmartEdit()
            {
            }
                .Add(new ControlFormItemInputText().Initialize(x => x.Value = ""Hello WebExpress!""))";

            Stage.AddItem
            (
                "Add",
                "Adds a form input element to the UI. The following input types are supported:",
                "new ControlSmartEdit().Add(new ControlFormItemInputText().Initialize(x => x.Value = \"Hello WebExpress!\"))",
                new ControlText()
                {
                    Text = "ControlFormItemInputText",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText().Initialize(x => x.Value.Text = "Hello WebExpress!")),
                new ControlText()
                {
                    Text = "ControlFormItemInputText (Wysiwyg)",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText() { Format = TypeEditTextFormat.Wysiwyg }
                        .Initialize(x => x.Value.Text = "Hello <b>WebExpress</b>!")),
                new ControlText()
                {
                    Text = "ControlFormItemInputDate",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputDate()
                    {
                        Format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
                    }.Initialize(x => x.Value.Date = DateTime.Now)),
                new ControlText()
                {
                    Text = "ControlFormItemInputCalendar",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputCalendar().Initialize(x => x.Value.Date = DateTime.Now)),
                new ControlText()
                {
                    Text = "ControlFormItemInputTag",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputTag().Initialize(x => x.Value.Add("tag1;tag2"))),
                new ControlText()
                {
                    Text = "ControlFormItemInputCombo",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputCombo()
                        .Add
                        (
                            new ControlFormItemInputComboItem() { Value = "a", Text = "Combo A" },
                            new ControlFormItemInputComboItem() { Value = "b", Text = "Combo B" }
                        )
                        .Initialize(x => x.Value.Text = "Combo B")),
                new ControlText()
                {
                    Text = "ControlFormItemInputSelection",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputSelection()
                        .Add
                        (
                            new ControlFormItemInputSelectionItem("a")
                            {
                                Text = "Selection A",
                                LabelColor = TypeColorSelection.Warning
                            },
                            new ControlFormItemInputSelectionItem("b")
                            {
                                Text = "Selection B",
                                LabelColor = TypeColorSelection.Warning
                            }
                        )
                        .Initialize(x => x.Value.Text = "a")),
                new ControlText()
                {
                    Text = "ControlFormItemInputMove",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputMove()
                        .Add
                        (
                            new ControlFormItemInputMoveItem("a") { Label = "Item A" },
                            new ControlFormItemInputMoveItem("b") { Label = "Item B" },
                            new ControlFormItemInputMoveItem("c") { Label = "Item C" }
                        )
                        .Initialize(x => x.Value.Add("a;c"))),
                new ControlText()
                {
                    Text = "ControlFormItemInputRating",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputRating()
                        .Initialize(x => x.Value.Number = 3)),
                new ControlText()
                {
                    Text = "ControlFormItemInputColor",
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputColor().Initialize(x => x.Value.Text = "#008000"))
            );
        }
    }
}