using System.Collections.Generic;
using System.Net.Http;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp.Table.Templates
{
    /// <summary>    
    /// Represents the tag template of a table control for the tutorial.    
    /// </summary>    
    [Title("Tag-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    [Domain<Character>]
    public sealed class Tag : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">
        /// The context of the page where the table control is used.
        /// </param>
        /// <param name="sitemapManager">
        /// The sitemap manager for managing site navigation.
        /// </param>
        public Tag(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `Tag` template defines the visual representation of values within a column. It supports both a ReadOnly mode for displaying data and an Edit mode for directly modifying values. This flexibility allows content to be highlighted with tags, icons, and colors, while enabling users to either view or interactively adjust information as needed.";

            Stage.Controls =
            [
                new ControlDataTable("myTable")
                {
                    PageSize = _=> 5
                }
                    .Service("data", svc => svc
                        .Endpoint<MonkeyIslandCharacterTable>()
                        .Method(HttpMethod.Get)
                        .UpdateMethod(HttpMethod.Put)),
            ];

            Stage.DarkControls =
            [
                new ControlDataTable("myTableDark")
                {
                    PageSize = _=> 5
                }
                    .Service("data", svc => svc
                        .Endpoint<MonkeyIslandCharacterTable>()
                        .Method(HttpMethod.Get)
                        .UpdateMethod(HttpMethod.Put))
            ];

            Stage.Code = @"
                new ControlDataTable(""myTable"")
                {
                    PageSize = _=> 5
                }
                    .Service(""data"", svc => svc
                        .Endpoint<MonkeyIslandCharacterTable>()
                        .Method(HttpMethod.Get)
                        .UpdateMethod(HttpMethod.Put))";
        }

        /// <summary>
        /// Creates a collection of table columns configured with the specified editability 
        /// and color tag.
        /// </summary>
        /// <param name="editable">
        /// A value indicating whether the returned columns are editable. If true, columns 
        /// can be modified by the user; otherwise, they are read-only.
        /// </param>
        /// <param name="color">
        /// An optional color tag to associate with the columns. If color is null,
        /// no color is applied.
        /// </param>
        /// <param name="placeholder">The placeholder text.</param>
        /// <param name="multiSelect">
        /// A value indicating whether multiple selections are allowed.
        /// </param>
        /// <returns>
        /// An enumerable collection of columns objects representing the configured table
        /// columns.
        /// </returns>
        private IEnumerable<IControlTableColumn> CreateColumns(bool editable = false, PropertyColorTag color = null, string placeholder = null, bool multiSelect = false)
        {
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateSelection()
            {
                Editable = _ => editable,
                Placeholder = _ => placeholder,
                MultiSelect = _ => multiSelect
            }
                .Add(new ControlFormItemInputSelectionItem("a") { Text = _ => "Option A", Content = _ => new ControlText() { Text = _ => "Option A" }, Color = _ => TypeColorSelection.Primary })
                .Add(new ControlFormItemInputSelectionItem("b") { Text = _ => "Option B", Content = _ => new ControlText() { Text = _ => "Option B" }, Color = _ => TypeColorSelection.Success })
                .Add(new ControlFormItemInputSelectionItem("c") { Text = _ => "Option C", Content = _ => new ControlText() { Text = _ => "Option C" }, Color = _ => TypeColorSelection.Info })
                .Add(new ControlFormItemInputSelectionItem("d") { Text = _ => "Option D", Content = _ => new ControlText() { Text = _ => "Option D" }, Color = _ => TypeColorSelection.Warning }))
            {
                Title = _ => "My column",
                Icon = _ => new IconBowlingBall()
            };
        }

        /// <summary>
        /// Generates a sequence of control table rows with optional cell text content.
        /// </summary>
        /// <returns>
        /// An enumerable collection of row objects representing the generated rows.
        /// </returns>
        private IEnumerable<IControlTableRow> CreateRows()
        {
            yield return new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = _ => "a;d" }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = _ => "b" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = _ => "c" }
                );
        }
    }
}
