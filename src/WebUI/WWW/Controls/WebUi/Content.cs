using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the content control for the tutorial.
    /// </summary>
    [WebIcon<IconControlContent>]
    [Title("Content")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Content : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Content()
        {
            Stage.Description = @"The `Content` control is the reading view of text that was written with the editor. The editor does not store a document - it stores its whole working surface: an add-on is kept inside the frame that names, moves and configures it, a table is kept framed and with the resize handles in its header cells, and every block that must not be typed into is fenced by the empty paragraphs the caret needs to get past it. Published as it stands, that value shows the reader the scaffolding instead of the text. The `Content` control removes the scaffolding and leaves the document, so a single stored value serves both the author and the reader. It is display only and never contributes a value to a form: it is the read side of `ControlSmartEdit` and of the editor table template, which build the same view on the client whenever their editor is not active.";

            Stage.Controls = [
                new ControlContent()
                {
                    Content = _ => CreateEditorValue()
                }
            ];

            Stage.DarkControls = [
                new ControlContent()
                {
                    Content = _ => CreateEditorValue()
                }
            ];

            Stage.Code = @"
            new ControlContent()
            {
                Content = _ => article.Description
            }";

            Stage.AddProperty
            (
                "Content",
                "The `Content` property carries the value in the raw format the editor stores. It is the value a `ControlFormItemInputText` with the `Wysiwyg` format submits, so it can be handed over unchanged - nothing has to be converted or duplicated on the server. Everything that only serves editing is removed on the client: add-on frames, table column resizers, caret markers and the empty guard paragraphs around non-editable blocks.",
                "Content = _ => \"<p>Hello <b>WebExpress</b>!</p>\"",
                new ControlText() { Text = _ => "Plain rich text", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => "<h4>Hello WebExpress!</h4><p>A paragraph with <b>bold</b>, <i>italic</i> and a <a href=\"https://github.com/webexpress-framework\" target=\"_blank\">link</a>.</p><ul><li>first</li><li>second</li></ul>" },

                new ControlText() { Text = _ => "An add-on, framed by the editor", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => CreateAddOn() },

                new ControlText() { Text = _ => "A table, framed by the editor", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => CreateTable() },

                new ControlText() { Text = _ => "The same value as the editor stores it", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlCode() { Language = _ => TypeLanguage.Xml, Code = _ => CreateAddOn() }
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property names the text that stands in for content that is not set. Without it an empty value renders nothing at all, which is what a display control embedded in a larger layout usually wants; with it the reader learns that the field exists and is simply empty.",
                "Placeholder = _ => \"No description yet\"",
                new ControlText() { Text = _ => "Without a placeholder", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => "" },
                new ControlText() { Text = _ => "With a placeholder", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => "", Placeholder = _ => "No description yet" }
            );

            Stage.AddProperty
            (
                "Instruction",
                "The `Instruction` property decides whether the instruction texts of the editor survive into the reading view. They are notes to whoever writes the document - what still has to be checked, which wording is binding - so they are dropped by default. A proof-reading view is the case for keeping them.",
                "Instruction = _ => true",
                new ControlText() { Text = _ => "false", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => CreateInstruction(), Instruction = _ => false },
                new ControlText() { Text = _ => "true", Margin = _ => new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two), TextColor = _ => new PropertyColorText(TypeColorText.Info) },
                new ControlContent() { Content = _ => CreateInstruction(), Instruction = _ => true }
            );
        }

        /// <summary>
        /// Builds a value the way the editor stores it, with everything the editor adds to
        /// make the document editable.
        /// </summary>
        /// <returns>The raw editor value.</returns>
        private static string CreateEditorValue()
        {
            return "<h4>Release notes</h4>"
                + "<p>The editor stores <b>this</b> value together with everything that makes it editable.</p>"
                + CreateInstruction()
                + CreateAddOn()
                + CreateTable()
                + "<ul><li>the add-on keeps what it renders</li><li>the table keeps the column widths</li></ul>";
        }

        /// <summary>
        /// Builds a paragraph carrying an instruction text for the author.
        /// </summary>
        /// <returns>The raw editor value.</returns>
        private static string CreateInstruction()
        {
            return "<p>The release date is the first of the month "
                + "<span class=\"wx-editor-instruction\" contenteditable=\"false\">check the wording with legal</span>"
                + " and cannot be moved.</p>";
        }

        /// <summary>
        /// Builds a block add-on inside the frame the editor wraps it in.
        /// </summary>
        /// <returns>The raw editor value.</returns>
        private static string CreateAddOn()
        {
            return "<p><br></p>"
                + "<div class=\"wx-addon-frame card my-3 shadow-sm\" contenteditable=\"false\" draggable=\"false\" data-addon-id=\"warning-box\">"
                + "<div class=\"card-header py-1 px-2 d-flex justify-content-between align-items-center\">"
                + "<div class=\"small text-muted fw-bold d-flex align-items-center\">"
                + "<span class=\"wx-addon-drag-handle\"><i class=\"wx-icon-light wx-icon-light-grip-lines-vertical\"></i></span>"
                + "<span>Warning Widget</span></div>"
                + "<div><span class=\"wx-addon-settings-btn\"><i class=\"wx-icon-light wx-icon-light-cog\"></i></span></div>"
                + "</div>"
                + "<div class=\"card-body p-2 wx-addon-body-widget\" contenteditable=\"false\">"
                + "<div class=\"alert alert-warning mb-0\"><strong>Warning:</strong> The interface changes with this release.</div>"
                + "</div></div>"
                + "<p><br></p>";
        }

        /// <summary>
        /// Builds a table inside the frame the editor wraps it in, including the column
        /// resize handles the editor puts into the header cells.
        /// </summary>
        /// <returns>The raw editor value.</returns>
        private static string CreateTable()
        {
            return "<p><br></p>"
                + "<div class=\"wx-addon-frame card my-3 shadow-sm\" contenteditable=\"false\" draggable=\"false\" data-addon-id=\"table-1\" data-type=\"table\">"
                + "<div class=\"card-header py-1 px-2\"><div class=\"small text-muted fw-bold\">"
                + "<span class=\"wx-addon-drag-handle\"><i class=\"wx-icon-light wx-icon-light-grip-lines-vertical\"></i></span>"
                + "<span>Table</span></div></div>"
                + "<div class=\"card-body p-2 wx-addon-body-container\" contenteditable=\"false\">"
                + "<table class=\"table table-striped table-bordered wx-native-table\" contenteditable=\"true\" style=\"table-layout: fixed; width: 100%\">"
                + "<colgroup><col style=\"width: 140px\"><col></colgroup>"
                + "<thead><tr>"
                + "<th style=\"position: relative\">Version<span class=\"wx-col-resizer\" contenteditable=\"false\"></span></th>"
                + "<th style=\"position: relative\">Change</th>"
                + "</tr></thead>"
                + "<tbody>"
                + "<tr><td>2.0.0</td><td>The reading view of the editor arrives.</td></tr>"
                + "<tr><td>1.9.0</td><td>The editor learns add-ons.</td></tr>"
                + "</tbody></table>"
                + "</div></div>"
                + "<p><br></p>";
        }
    }
}
