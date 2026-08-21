using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the section control demo page for the tutorial.
    /// </summary>
    [WebIcon<IconControlSection>]
    [Title("Section")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Section : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public Section(IPageContext pageContext)
        {
            Stage.Description = @"The `Section` control is a flat, collapsible section: a quiet label row over a body of content, without the frame, background or shadow of a `ControlPanelCard`. Use it when a page shows **one** subject from many angles - a reading view, a settings page, a detail pane - where a stack of framed boxes would make the borders compete with the content. A section separates by typography and whitespace instead: a small upper-case label, a generous gap to the section above, and a vertical guide line down the left of the body. The folded state is remembered per control id, so a reader who folds away what they never need keeps that view on the next visit.";

            Stage.Controls =
            [
                new ControlSection
                (
                    "tutorialSection",
                    new ControlText() { Text = _ => "The body of a section is any content placed inside it. Click the label row to fold it away." }
                )
                {
                    Header = _ => "Description"
                }
            ];

            Stage.Code = @"
            new ControlSection
            (
                ""tutorialSection"",
                new ControlText() { Text = _ => ""..."" }
            )
            {
                Header = _ => ""Description""
            };";

            Stage.AddProperty
            (
                "Header",
                "The `Header` property defines the section label. It is rendered as a small upper-case line and doubles as the accessible name of the toggle.",
                "Header = _ => \"Attachments\"",
                new ControlSection
                (
                    "tutorialSectionHeader",
                    new ControlText() { Text = _ => "The label is the only thing that names a section." }
                )
                {
                    Header = _ => "Attachments"
                }
            );

            Stage.AddProperty
            (
                "HeaderIcon",
                "The `HeaderIcon` property places an `IIcon` before the label. Any `IIcon` is accepted, so both image-based icons (such as `ImageIcon`) and CSS-based glyphs (such as the bundled icons) work the same way.",
                "HeaderIcon = _ => new IconComments()",
                new ControlSection
                (
                    "tutorialSectionIcon",
                    new ControlText() { Text = _ => "An icon helps a reader find a section again in a long view." }
                )
                {
                    Header = _ => "Comments",
                    HeaderIcon = _ => new IconComments()
                }
            );

            Stage.AddProperty
            (
                "Note",
                "The `Note` property adds a short line at the trailing end of the header row - a count, a state, a date. It stays visible while the section is folded, so a closed section can still report what is inside it.",
                "Note = _ => \"12 comments\"",
                new ControlSection
                (
                    "tutorialSectionNote",
                    new ControlText() { Text = _ => "Fold this section away: the note stays." }
                )
                {
                    Header = _ => "Comments",
                    Note = _ => "12 comments"
                }
            );

            Stage.AddProperty
            (
                "Badge",
                "The `Badge` property puts a filled pill directly after the label. Unlike `Note`, which stays a quiet trailing line, a badge carries a color and is read before the label it follows - use it for something that demands attention, and the note for something that merely informs. Both stay visible while the section is folded.",
                "Badge = _ => \"3 overdue\"",
                new ControlSection
                (
                    "tutorialSectionBadge",
                    new ControlText() { Text = _ => "A badge says what a folded section would otherwise hide." }
                )
                {
                    Header = _ => "Service level",
                    Badge = _ => "3 overdue",
                    Note = _ => "checked a minute ago"
                }
            );

            Stage.AddProperty
            (
                "BadgeColor",
                "The `BadgeColor` property colors the badge. It accepts both system colors (such as `TypeColorBackgroundBadge.Danger`) and user-defined ones (such as `\"gold\"`). Without a color the badge takes a neutral fill.",
                "BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)",
                new ControlSection
                (
                    "tutorialSectionBadgeColor",
                    new ControlText() { Text = _ => "The color is what turns a count into a warning." }
                )
                {
                    Header = _ => "Service level",
                    Badge = _ => "3 overdue",
                    BadgeColor = _ => new PropertyColorBackgroundBadge(TypeColorBackgroundBadge.Danger)
                }
            );

            Stage.AddProperty
            (
                "Color",
                "The `Color` property sets the accent of the section: the label, its icon and the guide line take it, while the body keeps the body color so the content stays readable. An accent groups sections in a way a label alone cannot - every section of one concern in one color. A filled background is deliberately not offered; it would put back the box the section exists to avoid.",
                "Color = _ => new PropertyColorText(TypeColorText.Danger)",
                new ControlSection
                (
                    "tutorialSectionColor",
                    new ControlText() { Text = _ => "The content is not what was accented - only the label and the line." }
                )
                {
                    Header = _ => "Escalation",
                    HeaderIcon = _ => new IconTriangleExclamation(),
                    Color = _ => new PropertyColorText(TypeColorText.Danger)
                }
            );

            Stage.AddProperty
            (
                "Layout",
                "The `Layout` property picks between three arrangements. `Stacked` is the default and reads top to bottom. `Aside` moves the label into a column of its own beside the body and turns the guide line into the divider between the two - it needs the width, so a narrow container falls back to `Stacked`. `Rule` follows the label with a hairline across the remaining width and drops the guide, which is the strongest horizontal break of the three.",
                "Layout = _ => TypeLayoutSection.Aside",
                new ControlSection
                (
                    "tutorialSectionAside",
                    new ControlText() { Text = _ => "In the aside layout the label sits beside its body, and the guide line becomes the divider between the two columns." }
                )
                {
                    Header = _ => "Aside layout",
                    Layout = _ => TypeLayoutSection.Aside
                }
            );

            Stage.AddProperty
            (
                "Layout (Rule)",
                "The `Rule` layout carries the label on a hairline that runs to the far edge, with the note following it. The body sits below without a guide - the rule already separates.",
                "Layout = _ => TypeLayoutSection.Rule",
                new ControlSection
                (
                    "tutorialSectionRule",
                    new ControlText() { Text = _ => "A page whose sections a reader scrolls past wants a horizontal break, not a vertical tie." }
                )
                {
                    Header = _ => "Rule layout",
                    Note = _ => "2026-08-19",
                    Layout = _ => TypeLayoutSection.Rule
                }
            );

            Stage.AddProperty
            (
                "Uppercase",
                "The label is set in upper case, which is what makes it read as structure rather than as content - right for the word that names a part of a page. It is wrong for a label that is a name or a sentence, because upper case turns a name into a shout. Switch `Uppercase` off there and the label keeps the spelling and the size it was given.",
                "Uppercase = _ => false",
                new ControlSection
                (
                    "tutorialSectionVerbatim",
                    new ControlText() { Text = _ => "A name is not a heading, and a sentence even less so." }
                )
                {
                    Header = _ => "Content could not be loaded.",
                    HeaderIcon = _ => new IconTriangleExclamation(),
                    Uppercase = _ => false,
                    Color = _ => new PropertyColorText(TypeColorText.Danger)
                }
            );

            Stage.AddProperty
            (
                "LabelCss",
                "The `LabelCss` property hangs extra classes on the label element alone. It is the escape hatch for a label that needs a class the control does not model - the tint of a host component, a weight a caller insists on. Reach for `Color` first: it colors the label, its icon and the guide line together and keeps the section consistent with every other one.",
                "LabelCss = _ => \"fw-bold\"",
                new ControlSection
                (
                    "tutorialSectionLabelCss",
                    new ControlText() { Text = _ => "Only the label carries the class; nothing else in the control knows about it." }
                )
                {
                    Header = _ => "Emphasised label",
                    LabelCss = _ => "fw-bold"
                }
            );

            Stage.AddProperty
            (
                "Expanded",
                "The `Expanded` property sets the state the section starts in. It applies on first render only - a state the reader chose earlier takes precedence.",
                "Expanded = _ => false",
                new ControlSection
                (
                    "tutorialSectionCollapsed",
                    new ControlText() { Text = _ => "A section that opens folded keeps a long view scannable." }
                )
                {
                    Header = _ => "Advanced settings",
                    Expanded = _ => false
                }
            );

            Stage.AddProperty
            (
                "Collapsible",
                "The `Collapsible` property decides whether the section can be folded away at all. A fixed section renders without a chevron and with an inert label row.",
                "Collapsible = _ => false",
                new ControlSection
                (
                    "tutorialSectionFixed",
                    new ControlText() { Text = _ => "This body cannot be folded away." }
                )
                {
                    Header = _ => "Always shown",
                    Collapsible = _ => false
                }
            );

            Stage.AddProperty
            (
                "Guide",
                "The `Guide` property draws the vertical line down the left of the body that ties the content back to its label. Switch it off for a body that draws its own structure - a table, a board - and would read as doubly framed.",
                "Guide = _ => false",
                new ControlSection
                (
                    "tutorialSectionNoGuide",
                    new ControlText() { Text = _ => "Without the guide line the body starts at the same edge as the label." }
                )
                {
                    Header = _ => "No guide",
                    Guide = _ => false
                }
            );

            Stage.AddProperty
            (
                "Persist",
                "The `Persist` property decides whether the folded state survives a reload. The state is stored per control id, so a section without an id is never remembered regardless of this setting.",
                "Persist = _ => false",
                new ControlSection
                (
                    "tutorialSectionForgetful",
                    new ControlText() { Text = _ => "Fold this away and reload: it comes back open." }
                )
                {
                    Header = _ => "Not remembered",
                    Persist = _ => false
                }
            );
        }
    }
}
