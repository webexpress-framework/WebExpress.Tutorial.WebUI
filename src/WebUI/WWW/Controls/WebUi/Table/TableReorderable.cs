using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table
{
    /// <summary>    
    /// Represents the table control for the tutorial.    
    /// </summary>    
    [Title("Reorderable Table")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class TableReorderable : PageControl
    {
        private readonly IEnumerable<ControlTableColumn> _columns =
        [
            new ControlTableColumn("myColumn1")
            {
                Title = "My column 1",
                Icon = new IconBowlingBall()
            },
            new ControlTableColumn("myColumn2")
            {
                Title = "My column 2",
                Icon = new IconBaseball()
            },
            new ControlTableColumn("myColumn3")
            {
                Title = "My column 3",
                Icon = new IconFootball()
            }
        ];

        private readonly IEnumerable<IControlTableRow> _rows =
        [
            new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text = "Row 1 - Cell 1" },
                    new ControlTableCell() { Text = "Row 1 - Cell 2" },
                    new ControlTableCell() { Text = "Row 1 - Cell 3" }
                ),
            new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = "Row 2 - Cell 1" },
                    new ControlTableCell() { Text = "Row 2 - Cell 2" },
                    new ControlTableCell() { Text = "Row 2 - Cell 3" }
                ),
            new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = "Row 3 - Cell 1" },
                    new ControlTableCell() { Text = "Row 3 - Cell 2" },
                    new ControlTableCell() { Text = "Row 3 - Cell 3" }
                )
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        public TableReorderable()
        {
            var i = 0;
            Stage.AddEvent(Event.TABLE_SORT_EVENT, Event.COLUMN_REORDER_EVENT, Event.ROW_REORDER_EVENT, Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT, Event.COLUMN_SEARCH_EVENT);

            Stage.Description = @"A `TableControl` is a user interface component designed to display structured data in a tabular format. It organizes information into rows and columns, making it easier for users to view, interact with, and manage data efficiently.";

            Stage.Controls =
            [
                new ControlTableReorderable("myTable")
                    .AddColumns(_columns)
                    .AddRows(_rows)
            ];

            Stage.DarkControls =
            [
                new ControlTableReorderable("myTableDark")
                    .AddColumns(_columns)
                    .AddRows(_rows)
            ];

            Stage.Code =
            @"
            new ControlTableReorderable(""myTable"")
                .AddColumns(...)
                .AddRows(...)";

            Stage.AddProperty
            (
                "Bordered",
                @"The `Bordered` property of a table control adds visible borders around the entire table and each individual cell. This enhances the table's structure, making it easier to read and visually distinguish its contents.",
                @"TableBorder = TypeBorderTable.Borderless",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    TableBorder = TypeBorderTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Borderless", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    TableBorder = TypeBorderTable.Borderless
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Bordered", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    TableBorder = TypeBorderTable.Bordered
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)

            );

            Stage.AddProperty
            (
                "Striped",
                @"The `Striped` property of a table control enhances its readability by applying alternating background colors to its rows. This visual distinction makes large datasets easier to scan and improves organization.",
                @"Striped = TypeStripedTable.Row",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Striped = TypeStripedTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Column", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Striped = TypeStripedTable.Column
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Row", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Striped = TypeStripedTable.Row
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Both", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Striped = TypeStripedTable.Both
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)

            );

            Stage.AddProperty
            (
                "Color",
                @"The `Color` property in a table control allows customization of the table’s background color, helping improve readability and design consistency.",
                @"Color = TypeColorTable.Primary",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Primary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Secondary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Info
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Success
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Warning
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Danger
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Light
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    Color = TypeColorTable.Dark
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)

            );

            Stage.AddProperty
            (
                "HeaderColor",
                @"The `HeaderColor` property of a table control allows customization of the table header’s background color, improving visibility and design consistency.",
                @"HeaderColor = TypeColorTable.Primary",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Primary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Secondary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Info
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Success
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Warning
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Danger
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Light
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                    HeaderColor = TypeColorTable.Dark
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)

            );

            Stage.AddProperty
            (
                "SuppressHeaders",
                @"The `SuppressHeaders` property controls the visibility of column headers in a table. When enabled, it ensures that all column headers are hidden, regardless of the table’s structure or content.",
                @"SuppressHeaders = true",
                new ControlTableReorderable()
                {
                    SuppressHeaders = true
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddProperty
            (
                "AllowColumnRemove",
                @"The `AllowColumnRemove` property in a table control enables users to remove columns dynamically. This enhances flexibility in data presentation and allows for a more tailored user experience.",
                @"AllowColumnRemove = true",
                new ControlTableReorderable()
                {
                    AllowColumnRemove = true
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddProperty
            (
                "MovableRow",
                @"The `MovableRow` property in a table control allows users to rearrange rows interactively. This improves usability by enabling custom ordering of data based on user preferences or workflow requirements.",
                @"MovableRow = true",
                new ControlTableReorderable()
                {
                    MovableRow = true
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddProperty
            (
                "PersistKey",
                @"The `PersistKey` property in a table control defines a unique identifier used to persist user-specific table settings (such as column order, visibility, widths, and active sort) across sessions. This ensures a consistent and personalized experience every time the table is loaded.",
                @"PersistKey = ""key""",
                new ControlTableReorderable()
                {
                    AllowColumnRemove = true,
                    PersistKey = "764CFD1A-1EDA-47E2-A186-8710666334AB"
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddItem
            (
                typeof(ControlTableColumn),
                "ControlTableColumn",
                "A `ControlTableColumn` defines a vertical structure within a table, specifying how a particular type of data is presented across all rows. Each column can display text, numbers, icons, controls, or custom templates, depending on the table’s configuration. Columns determine alignment, formatting, editing behavior, and overall layout consistency. By separating data into clearly defined columns, `ControlTableColumn` ensures that information remains readable, comparable, and easy to scan, even in complex or data‑rich tables.",
                "new ControlTableColumn()",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
            );

            Stage.AddItemProperty
            (
                typeof(ControlTableColumn),
                "AddColumn",
                "The `AddColumn` function is used to add new columns to a table, allowing for increased data representation and flexibility in table structure.",
                @"
                .AddColumns(new ControlTableColumnTemplate(""myColumn4"", new ControlTableTemplateDate()
                {
                    Editable = true,
                    Format = ""yyyy-MM-dd""

                })
                {
                    Title = ""Column"",
                    Icon = new IconTableTennisPaddleBall(),
                    Color = TypeColorTable.Warning
                })",
                new ControlText() { Text = "ControlTableColumn", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumn()
                    {
                        Title = "Column",
                        Icon = new IconTableTennisPaddleBall(),
                        Color = TypeColorTable.Warning
                    })
                    .AddRows(_rows.Select
                    (
                        x => new ControlTableRow()
                            .Add(x.Cells)
                            .Add(new ControlTableCell($"myDate_{i}")
                            {
                                Text = DateTime.Now.AddDays(i++).ToString("yyyy-MM-dd")
                            })
                    )),
                new ControlText() { Text = "ControlTableColumnTemplate", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTableReorderable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumnTemplate("myColumn4", new ControlTableTemplateDate()
                    {
                        Editable = true,
                        Format = "yyyy-MM-dd"

                    })
                    {
                        Title = "Column",
                        Icon = new IconTableTennisPaddleBall(),
                        Color = TypeColorTable.Warning
                    })
                    .AddRows(_rows.Select
                    (
                        x => new ControlTableRow()
                            .Add(x.Cells)
                            .Add(new ControlTableCell($"myDate_{i}")
                            {
                                Text = DateTime.Now.AddDays(i++).ToString("yyyy-MM-dd")
                            })
                    ))
            );

            Stage.AddItem
            (
                typeof(ControlTableRow),
                "ControlTableRow",
                "A `ControlTableRow` represents a single horizontal entry within a table structure. Each row groups together the cell values that belong to the same record, making it possible to display structured data in a clear and consistent way. Rows can contain static content, interactive controls, or dynamically generated values, depending on the table’s configuration. By organizing information row by row, `ControlTableRow` provides a predictable layout that supports sorting, selection, editing, and other table‑based interactions.",
                @"new ControlTableRow(""id"")",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
                    .AddRows(new ControlTableRow("myRow4")
                    {
                        Color = TypeColorTable.Danger,
                        ExpandState = TypeExpandState.Collapsed
                    }
                        .Add
                        (
                            new ControlTableCell() { Text = "Row 4 - Cell 1" },
                            new ControlTableCell() { Text = "Row 4 - Cell 2" },
                            new ControlTableCell() { Text = "Row 4 - Cell 3" }
                        )
                    )
            );

            Stage.AddItemProperty
            (
                typeof(ControlTableRow),
                "AddRow",
                "The `AddRow` function adds a new row to a table, ensuring structural consistency and proper data integration.",
                @"
                .AddRows(new ControlTableRow(""myRow4"")
                {
                    Color = TypeColorTable.Danger,
                    ExpandState = TypeExpandState.Collapsed
                }
                    .Add
                    (
                        new ControlTableCell() { Text = ""Row 4 - Cell 1"" },
                        new ControlTableCell() { Text = ""Row 4 - Cell 2"" },
                        new ControlTableCell() { Text = ""Row 4 - Cell 3"" }
                    )
                    .Add
                    (
                        new ControlTableRow(""myRow4_1"")
                        .Add
                        (
                            new ControlTableCell() { Text = ""Row 4.1 - Cell 1"" },
                            new ControlTableCell() { Text = ""Row 4.1 - Cell 2"" },
                            new ControlTableCell() { Text = ""Row 4.1 - Cell 3"" }
                        ),
                        new ControlTableRow(""myRow4_2"")
                        .Add
                        (
                            new ControlTableCell() { Text = ""Row 4.2 - Cell 1"" },
                            new ControlTableCell() { Text = ""Row 4.2 - Cell 2"" },
                            new ControlTableCell() { Text = ""Row 4.2 - Cell 3"" }
                        )
                    )
                )",
                new ControlTableReorderable()
                {
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
                    .AddRows(new ControlTableRow("myRow4")
                    {
                        Color = TypeColorTable.Danger,
                        ExpandState = TypeExpandState.Collapsed
                    }
                        .Add
                        (
                            new ControlTableCell() { Text = "Row 4 - Cell 1" },
                            new ControlTableCell() { Text = "Row 4 - Cell 2" },
                            new ControlTableCell() { Text = "Row 4 - Cell 3" }
                        )
                        .Add
                        (
                            new ControlTableRow("myRow4_1")
                            .Add
                            (
                                new ControlTableCell() { Text = "Row 4.1 - Cell 1" },
                                new ControlTableCell() { Text = "Row 4.1 - Cell 2" },
                                new ControlTableCell() { Text = "Row 4.1 - Cell 3" }
                            ),
                            new ControlTableRow("myRow4_2")
                            .Add
                            (
                                new ControlTableCell() { Text = "Row 4.2 - Cell 1" },
                                new ControlTableCell() { Text = "Row 4.2 - Cell 2" },
                                new ControlTableCell() { Text = "Row 4.2 - Cell 3" }
                            )
                        )
                    )
                    .AddRows(new ControlTableRow("myRow5")
                        .Add
                        (
                            new ControlTableCell() { Text = "Row 5 - Cell 1", Color = TypeColorTable.Primary },
                            new ControlTableCell() { Text = "Row 5 - Cell 2", Icon = new IconHome() },
                            new ControlTableCell() { Text = "Row 5 - Cell 3" }
                        )
                        .Add
                        (
                            new ControlDropdownItemHeader() { Text = "Header" },
                            new ControlDropdownItemLink() { Text = "First Entry", Icon = new IconWrench() },
                            new ControlDropdownItemLink() { Text = "Second Entry" },
                            new ControlDropdownItemDivider(),
                            new ControlDropdownItemLink() { Text = "Third Entry" }
                        )
                    )
            );
        }
    }
}
