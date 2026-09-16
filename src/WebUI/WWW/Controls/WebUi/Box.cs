using WebExpress.Tutorial.WebUI.WebControl;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the box control demo page for the tutorial.
    /// </summary>
    [WebIcon<IconControlBox>]
    [Title("Box")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Box : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Box(IPageContext pageContext)
        {
            Stage.Description = @"The `Box` control is an enclosing frame around content that belongs together, used to set that content apart from the page, to organize it, or to draw the eye to it. A `ControlPanelCard` is a surface with a filled header bar and a footer, a `ControlPanelCallout` is a colored note, a `ControlSection` draws no frame at all - the box sits between them. It draws **exactly one frame**, chosen through `Layout`, around content it otherwise leaves alone. Which frame is the whole statement: a hairline groups, a dashed line marks something provisional, a raised surface lifts content out of the flow, a bar on the leading edge points at it without enclosing it. The body is composed from three sources - fragments registered for `SectionBoxPreferences` and `SectionBoxPrimary`, the controls added directly, and fragments registered for `SectionBoxSecondary` - and the sections resolve against the runtime type of the box, so a plugin that contributes to a box declares `[Scope<TheBoxType>]` and reaches exactly that box. This is how a page assembles itself from parts that do not know each other. The box is also available as an add-on of the WYSIWYG editor, and the reading view of that add-on is this very control.";

            Stage.Controls =
            [
                new ControlBox
                (
                    "tutorialBox",
                    new ControlText() { Text = _ => "The body of a box is any content placed inside it. The frame is the only thing the box adds." }
                )
                {
                    Header = _ => "Description"
                }
            ];

            Stage.Code = @"
            new ControlBox
            (
                ""tutorialBox"",
                new ControlText() { Text = _ => ""..."" }
            )
            {
                Header = _ => ""Description""
            };";

            Stage.AddProperty
            (
                "Header",
                "The `Header` property defines the label of the box. It is rendered as a small upper-case line above the body, so it reads as the name of the group and not as its first line of content. Without a label (and without an icon) no row is shown at all, and the box is a plain frame.",
                "Header = _ => \"Attachments\"",
                new ControlBox
                (
                    "tutorialBoxHeader",
                    new ControlText() { Text = _ => "The label names the group." }
                )
                {
                    Header = _ => "Attachments",
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                },
                new ControlBox
                (
                    "tutorialBoxNoHeader",
                    new ControlText() { Text = _ => "A box without a label is a plain frame." }
                )
            );

            Stage.AddProperty
            (
                "HeaderIcon",
                "The `HeaderIcon` property places an `IIcon` before the label. Any `IIcon` is accepted, so both image-based icons (such as `ImageIcon`) and CSS-based glyphs (such as the bundled icons) work the same way.",
                "HeaderIcon = _ => new IconPaperClip()",
                new ControlBox
                (
                    "tutorialBoxIcon",
                    new ControlText() { Text = _ => "An icon helps a reader find a box again on a long page." }
                )
                {
                    Header = _ => "Attachments",
                    HeaderIcon = _ => new IconPaperClip()
                }
            );

            Stage.AddProperty
            (
                "Layout",
                "The `Layout` property picks the frame, and the frame is the whole statement. `Solid` is the default hairline. `Dashed` reads as provisional - a draft, a placeholder, a drop zone. `Dotted` is the quietest of the drawn frames. `Double` is the most formal, for content quoted from elsewhere. `Accent` is a bar on the leading edge and no other line, like a margin note. `Raised` draws no line but lifts the content off the page with a shadow, `Inset` sinks it into the page with a subtle fill, and `None` draws nothing at all while keeping the padding and the label, so the box still organizes and lines up with framed boxes beside it.",
                "Layout = _ => TypeLayoutBox.Dashed",
                Sample(TypeLayoutBox.Solid, "Solid", "A hairline around the content. The default: it groups without claiming attention."),
                Sample(TypeLayoutBox.Dashed, "Dashed", "A dashed hairline. Provisional - a draft, a placeholder, an area where something can be dropped."),
                Sample(TypeLayoutBox.Dotted, "Dotted", "A dotted hairline. For a grouping that should be felt rather than seen."),
                Sample(TypeLayoutBox.Double, "Double", "A double line. For content quoted or cited from elsewhere."),
                Sample(TypeLayoutBox.Accent, "Accent", "A bar on the leading edge and no other line. Points at the content without enclosing it."),
                Sample(TypeLayoutBox.Raised, "Raised", "No line, but a shadow that lifts the content off the page."),
                Sample(TypeLayoutBox.Inset, "Inset", "No line, but a subtle fill that sinks the content into the page."),
                Sample(TypeLayoutBox.None, "None", "No frame at all. The padding and the label stay, so the box lines up with the framed ones above.")
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property sets the accent of the box: the frame and the label take it, while the body keeps the body color so the content stays readable. The accent colors whatever the layout draws - the hairline, the bar of `Accent`, the tint of `Inset` - so a box keeps one color property across every layout instead of one per kind of line.",
                "Color = _ => new PropertyColorText(TypeColorText.Danger)",
                new ControlBox
                (
                    "tutorialBoxColor",
                    new ControlText() { Text = _ => "The content is not what was accented - only the frame and the label." }
                )
                {
                    Header = _ => "Escalation",
                    HeaderIcon = _ => new IconTriangleExclamation(),
                    Color = _ => new PropertyColorText(TypeColorText.Danger),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                },
                new ControlBox
                (
                    "tutorialBoxColorAccent",
                    new ControlText() { Text = _ => "On the accent layout the color goes to the bar." }
                )
                {
                    Header = _ => "Note",
                    Layout = _ => TypeLayoutBox.Accent,
                    Color = _ => new PropertyColorText(TypeColorText.Primary),
                    Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
                },
                new ControlBox
                (
                    "tutorialBoxColorInset",
                    new ControlText() { Text = _ => "On the inset layout the color tints the fill." }
                )
                {
                    Header = _ => "Hint",
                    Layout = _ => TypeLayoutBox.Inset,
                    Color = _ => new PropertyColorText(TypeColorText.Success)
                }
            );

            Stage.AddProperty
            (
                "Fragments",
                "The body of a box is composed at runtime from **embedded fragments**. Fragments registered for `SectionBoxPreferences` and `SectionBoxPrimary` come first, then the controls the box adds itself, then the fragments of `SectionBoxSecondary`. The sections resolve against the runtime type of the box, so a contributing fragment declares `[Scope<TheBoxType>]` - here `ControlBoxComposed`, a subclass that exists only to have a type of its own - and reaches exactly that box and no other. This is what lets several plugins fill one box without any of them knowing about the others. Both lines in gray below come from fragments (`SectionBoxPrimaryFragment` and `SectionBoxSecondaryFragment`); the box itself adds only the paragraph between them.",
                @"
                [Section<SectionBoxPrimary>]
                [Scope<ControlBoxComposed>]
                public sealed class SectionBoxPrimaryFragment : FragmentControlText
                {
                    public SectionBoxPrimaryFragment(IFragmentContext fragmentContext)
                        : base(fragmentContext)
                    {
                        Text = _ => ""SectionBoxPrimary - contributed by a fragment."";
                    }
                }

                new ControlBoxComposed(""composed"", new ControlText() { Text = _ => ""..."" })
                {
                    Header = _ => ""Composed from fragments""
                };",
                new ControlBoxComposed
                (
                    "tutorialBoxComposed",
                    new ControlText() { Text = _ => "This paragraph is the content the box adds itself. The lines above and below it were contributed by fragments." }
                )
                {
                    Header = _ => "Composed from fragments",
                    HeaderIcon = _ => new IconPuzzle()
                }
            );

            Stage.AddProperty
            (
                "WYSIWYG add-on",
                "The box is also an add-on of the editor (`Insert AddOn` → `Layout` → `Box`, or `{{`). The author types into it, picks the frame and the label in its property dialog, and sees the frame while editing. The value the editor stores keeps the add-on in the editor's frame; the reading view - a `ControlContent` - strips that frame and hands the block to the box controller, so the reader gets this very control. Below, the same value is shown as the editor stores it and as the reader sees it.",
                "new ControlContent() { Content = _ => article.Description }",
                new ControlText() { Text = _ => "As the reader sees it", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => CreateAddOn() },
                new ControlText() { Text = _ => "As the editor stores it", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Xml, Code = _ => CreateAddOn() }
            );
        }

        /// <summary>
        /// Builds one box of the layout gallery.
        /// </summary>
        /// <param name="layout">The frame to show.</param>
        /// <param name="name">The name of the frame, used as the label.</param>
        /// <param name="text">The line that says what the frame is for.</param>
        /// <returns>The box.</returns>
        private static ControlBox Sample(TypeLayoutBox layout, string name, string text)
        {
            return new ControlBox("tutorialBox" + name, new ControlText() { Text = _ => text })
            {
                Header = _ => name,
                Layout = _ => layout,
                Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
            };
        }

        /// <summary>
        /// Builds a box add-on inside the frame the editor wraps it in, with the frame and the
        /// label persisted on that frame the way the property dialog writes them.
        /// </summary>
        /// <returns>The raw editor value.</returns>
        private static string CreateAddOn()
        {
            return "<p>A paragraph before the box.</p>"
                + "<div class=\"wx-addon-frame card my-3 shadow-sm\" contenteditable=\"false\" draggable=\"false\" data-addon-id=\"box\" data-layout=\"dashed\" data-header=\"Authored in the editor\">"
                + "<div class=\"card-header py-1 px-2 d-flex justify-content-between align-items-center\">"
                + "<div class=\"small text-muted fw-bold d-flex align-items-center\">"
                + "<span class=\"wx-addon-drag-handle\"><i class=\"wx-icon-light wx-icon-light-grip-lines-vertical\"></i></span>"
                + "<span>Box</span></div>"
                + "<div><span class=\"wx-addon-settings-btn\"><i class=\"wx-icon-light wx-icon-light-cog\"></i></span></div>"
                + "</div>"
                + "<div class=\"card-body p-2 wx-addon-body-container\" contenteditable=\"true\">"
                + "<p>The author typed this <b>inside</b> the box and chose the dashed frame in the property dialog.</p>"
                + "</div></div>"
                + "<p>A paragraph after the box.</p>";
        }
    }
}
