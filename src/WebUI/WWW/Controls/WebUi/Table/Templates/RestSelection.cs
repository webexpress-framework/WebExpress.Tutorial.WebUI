using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table.Templates
{
    /// <summary>    
    /// Represents the rest selection template of a table control for the tutorial.    
    /// </summary>    
    [Title("RestSelection-Template")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class RestSelection : PageControl
    {
        private readonly ISitemapManager _sitemapManager;
        private readonly IPageContext _pageContext;

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>
        /// <param name="pageContext">The context of the page where the list control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public RestSelection(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            _pageContext = pageContext;
            _sitemapManager = sitemapManager;

            Stage.AddEvent(Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"The `RestSelection` template provides an interactive way to present and choose values within a column. It supports both ReadOnly mode for displaying selections and Edit mode for modifying them. This enables values to be highlighted with tags, icons, or colors while allowing users to view or actively change the selected option.";

            Stage.Controls =
            [
                new ControlTable("myTable")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.DarkControls =
            [
                new ControlTableReorderable("myTableDark")
                    .AddColumns(CreateColumns())
                    .AddRows(CreateRows())
            ];

            Stage.Code = @"
                new ControlTable(""myTable"")
                    .AddColumns(...)
                    .AddRows(...)";

            Stage.AddProperty
            (
                "Editable",
                "The `Editable` property defines whether the template column is displayed in ReadOnly mode or in Edit mode. In ReadOnly mode, values are shown as static tags for clear visualization. In Edit mode, users can directly modify the values within the column, enabling interactive data editing.",
                "Editable = true",
                new ControlText() { Text = "false", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns()).AddRows(CreateRows()),
                new ControlText() { Text = "true", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable().AddColumns(CreateColumns(true)).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
                "Placeholder",
                "The `Placeholder` property defines the default text or tag shown when no value is provided within the `Tag` template column. It helps guide users by indicating the expected input or by visually marking empty fields.",
                "Placeholder = \"Enter value\"",
                new ControlTable().AddColumns(CreateColumns(true, null, "Enter value")).AddRows(CreateRows())
            );

            Stage.AddProperty
            (
               "MultiSelect",
               "The `MultiSelect` property enables selecting multiple values within a `Selection` template column. When activated, users can choose more than one option, allowing the column to represent sets of values instead of a single entry.",
               "MultiSelect = \"true\"",
               new ControlTable().AddColumns(CreateColumns(true, null, null, true)).AddRows(CreateRows())
            );
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
            yield return new ControlTableColumnTemplate("myColumn1", new ControlTableTemplateRestSelection()
            {
                Editable = editable,
                Placeholder = placeholder,
                MultiSelect = multiSelect,
                RestUri = _sitemapManager.GetUri<MonkeyIslandLocationsSelection>(_pageContext.ApplicationContext),
            })
            {
                Title = "My column",
                Icon = new IconBowlingBall()
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
                    new ControlTableCell() { Text = "28DF7324-0DDE-40B3-B6E4-0CDD107D324A;64D99FDF-9828-40EB-92CA-D55DDA6BD9F4" }
                );
            yield return new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = "28DF7324-0DDE-40B3-B6E4-0CDD107D324A" }
                );
            yield return new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = "28DF7324-0DDE-40B3-B6E4-0CDD107D324A" }
                );
        }
    }
}
