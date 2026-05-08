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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
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

            Stage.AddProperty
            (
                "Add",
                "Adds a form input element to the UI. The following input types are supported:",
                "new ControlSmartEdit().Add(new ControlFormItemInputText().Initialize(x => x.Value = \"Hello WebExpress!\"))",
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputText",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText().Initialize(x => x.Value.Text = "Hello WebExpress!")),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputText (Wysiwyg)",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputText() { Format = _ => TypeEditTextFormat.Wysiwyg }
                        .Initialize(x => x.Value.Text = "Hello <b>WebExpress</b>!")),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputDate",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputDate()
                    {
                        Format = _ => CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
                    }.Initialize(x => x.Value.Date = DateTime.Now)),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputCalendar",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputCalendar().Initialize(x => x.Value.Date = DateTime.Now)),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputTag",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputTag().Initialize(x => x.Value.Add("tag1;tag2"))),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputCombo",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputCombo()
                        .Add
                        (
                            new ControlFormItemInputComboItem() { Value = _ => "a", Text = _ => "Combo A" },
                            new ControlFormItemInputComboItem() { Value = _ => "b", Text = _ => "Combo B" }
                        )
                        .Initialize(x => x.Value.Text = "Combo B")),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputSelection",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputSelection()
                        .Add
                        (
                            new ControlFormItemInputSelectionItem("a")
                            {
                                Text = _ => "Selection A",
                                Color = _ => TypeColorSelection.Warning
                            },
                            new ControlFormItemInputSelectionItem("b")
                            {
                                Text = _ => "Selection B",
                                Color = _ => TypeColorSelection.Warning
                            }
                        )
                        .Initialize(x => x.Value.Text = "a")),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputMove",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputMove()
                        .Add
                        (
                            new ControlFormItemInputMoveItem("a") { Text = _ => "Item A" },
                            new ControlFormItemInputMoveItem("b") { Text = _ => "Item B" },
                            new ControlFormItemInputMoveItem("c") { Text = _ => "Item C" }
                        )
                        .Initialize(x => x.Value.Add("a;c"))),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputRating",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputRating()
                        .Initialize(x => x.Value.Number = 3)),
                new ControlText()
                {
                    Text = _ => "ControlFormItemInputColor",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two),
                    TextColor = _ => new PropertyColorText(TypeColorText.Info)
                },
                new ControlSmartEdit()
                {
                }
                    .Add(new ControlFormItemInputColor().Initialize(x => x.Value.Text = "#008000"))
            );
        }
    }
}