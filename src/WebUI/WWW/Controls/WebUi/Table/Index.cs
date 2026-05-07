using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebControl;
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

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi.Table
{
    /// <summary>    
    /// Represents the table control for the tutorial.    
    /// </summary>    
    [Title("Table")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Index : PageControl
    {
        private readonly IEnumerable<ControlTableColumn> _columns =
        [
            new ControlTableColumn("myColumn1")
            {
                Title = _ => "My column 1",
                Icon = _ => new IconBowlingBall()
            },
            new ControlTableColumn("myColumn2")
            {
                Title = _ => "My column 2",
                Icon = _ => new IconBaseball()
            },
            new ControlTableColumn("myColumn3")
            {
                Title = _ => "My column 3",
                Icon = _ => new IconFootball()
            }
        ];

        private readonly IEnumerable<IControlTableRow> _rows =
        [
            new ControlTableRow("myRow1")
                .Add
                (
                    new ControlTableCell() { Text =_ =>  "Row 1 - Cell 1" },
                    new ControlTableCell() { Text = _ => "Row 1 - Cell 2" },
                    new ControlTableCell() { Text = _ => "Row 1 - Cell 3" }
                ),
            new ControlTableRow("myRow2")
                .Add
                (
                    new ControlTableCell() { Text = _ => "Row 2 - Cell 1" },
                    new ControlTableCell() { Text = _ => "Row 2 - Cell 2" },
                    new ControlTableCell() { Text = _ => "Row 2 - Cell 3" }
                ),
            new ControlTableRow("myRow3")
                .Add
                (
                    new ControlTableCell() { Text = _ => "Row 3 - Cell 1" },
                    new ControlTableCell() { Text = _ => "Row 3 - Cell 2" },
                    new ControlTableCell() { Text = _ => "Row 3 - Cell 3" }
                )
        ];

        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the table control is used.</param>  
        /// <param name="componentHub">
        /// The component hub instance used to manage components and 
        /// their interactions within the application.
        /// </param>
        public Index(IPageContext pageContext, IComponentHub componentHub)
        {
            var i = 0;
            var notificationManager = componentHub.GetComponentManager<NotificationManager>();

            Stage.AddEvent(Event.TABLE_SORT_EVENT, Event.START_INLINE_EDIT_EVENT, Event.SAVE_INLINE_EDIT_EVENT, Event.END_INLINE_EDIT_EVENT);

            Stage.Description = @"A `TableControl` is a user interface component designed to display structured data in a tabular format. It organizes information into rows and columns, making it easier for users to view, interact with, and manage data efficiently.";

            Stage.Controls =
            [
                new ControlTable("myTable")
                    .AddColumns(_columns)
                    .AddRows(_rows)
            ];

            Stage.DarkControls =
            [
                new ControlTable("myTableDark")
                    .AddColumns(_columns)
                    .AddRows(_rows)
            ];

            Stage.Code = @"
            new ControlTable(""myTable"")
                .AddColumns(...)
                .AddRows(...)";

            Stage.AddProperty
            (
                "Bordered",
                @"The `Bordered` property of a table control adds visible borders around the entire table and each individual cell. This enhances the table's structure, making it easier to read and visually distinguish its contents.",
                @"TableBorder = _ => TypeBorderTable.Borderless",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    TableBorder = _ => TypeBorderTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Borderless", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    TableBorder = _ => TypeBorderTable.Borderless
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Bordered", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    TableBorder = _ => TypeBorderTable.Bordered
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddProperty
            (
                "Striped",
                @"The `Striped` property of a table control enhances its readability by applying alternating background colors to its rows. This visual distinction makes large datasets easier to scan and improves organization.",
                @"Striped = _ => TypeStripedTable.Row",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Striped = _ => TypeStripedTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Column", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Striped = _ => TypeStripedTable.Column
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Row", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Striped = _ => TypeStripedTable.Row
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Both", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Striped = _ => TypeStripedTable.Both
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)

            );

            Stage.AddProperty
            (
                "Selectable",
                @"The `Selectable` property of a table control determines how users can select elements within the table. It defines whether selection applies to rows, columns, both, or is disabled entirely.",
                @"Selectable = _ => true",

                new ControlTable()
                {
                    Selectable = _ => true
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddProperty
            (
                "Color",
                @"The `Color` property in a table control allows customization of the table’s background color, helping improve readability and design consistency.",
                @"Color = _ => TypeColorTable.Primary",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Primary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Secondary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Info
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Success
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Warning
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Danger
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Light
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    Color = _ => TypeColorTable.Dark
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)

            );

            Stage.AddProperty
            (
                "HeaderColor",
                @"The `HeaderColor` property of a table control allows customization of the table header’s background color, improving visibility and design consistency.",
                @"HeaderColor = _ => TypeColorTable.Primary",
                new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Default
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Primary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Secondary
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Info
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Success
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Warning
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Danger
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Light
                }
                    .AddColumns(_columns)
                    .AddRows(_rows),
                new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                    HeaderColor = _ => TypeColorTable.Dark
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
            );

            Stage.AddProperty
            (
                "SuppressHeaders",
                @"The `SuppressHeaders` property controls the visibility of column headers in a table. When enabled, it ensures that all column headers are hidden, regardless of the table’s structure or content.",
                @"SuppressHeaders = true",
                new ControlTable()
                {
                    SuppressHeaders = _ => true
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
                    Editable = _ => true,
                    Format = _ => ""yyyy-MM-dd""

                })
                {
                    Title = _ => ""Column"",
                    Icon = _ => new IconTableTennisPaddleBall(),
                    Color = _ => TypeColorTable.Warning
                })",
                new ControlText() { Text = "ControlTableColumn", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumn()
                    {
                        Title = _ => "Column",
                        Icon = _ => new IconTableTennisPaddleBall(),
                        Color = _ => TypeColorTable.Warning
                    })
                    .AddRows(_rows.Select
                    (
                        x => new ControlTableRow()
                            .Add(x.Cells)
                            .Add(new ControlTableCell($"myDate_{i}")
                            {
                                Text = _ => DateTime.Now.AddDays(i++).ToString("yyyy-MM-dd")
                            })
                    )),
                new ControlText() { Text = "ControlTableColumnTemplate", TextColor = new PropertyColorText(TypeColorText.Info) },
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumnTemplate("myColumn4", new ControlTableTemplateDate()
                    {
                        Editable = _ => true,
                        Format = _ => "yyyy-MM-dd"

                    })
                    {
                        Title = _ => "Column",
                        Icon = _ => new IconTableTennisPaddleBall(),
                        Color = _ => TypeColorTable.Warning
                    })
                    .AddRows(_rows.Select
                    (
                        x => new ControlTableRow()
                            .Add(x.Cells)
                            .Add(new ControlTableCell($"myDate_{i}")
                            {
                                Text = _ => DateTime.Now.AddDays(i++).ToString("yyyy-MM-dd")
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
                        Color = _ => TypeColorTable.Danger,
                        ExpandState = _ => TypeExpandState.Collapsed
                    }
                        .Add
                        (
                            new ControlTableCell() { Text = _ => "Row 4 - Cell 1" },
                            new ControlTableCell() { Text = _ => "Row 4 - Cell 2" },
                            new ControlTableCell() { Text = _ => "Row 4 - Cell 3" }
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
                    Color = _ => TypeColorTable.Danger,
                    ExpandState = _ => TypeExpandState.Collapsed
                }
                    .Add
                    (
                        new ControlTableCell() { Text = _ => ""Row 4 - Cell 1"" },
                        new ControlTableCell() { Text = _ => ""Row 4 - Cell 2"" },
                        new ControlTableCell() { Text = _ => ""Row 4 - Cell 3"" }
                    )
                    .Add
                    (
                        new ControlTableRow(""myRow4_1"")
                        .Add
                        (
                            new ControlTableCell() { Text = _ => ""Row 4.1 - Cell 1"" },
                            new ControlTableCell() { Text = _ => ""Row 4.1 - Cell 2"" },
                            new ControlTableCell() { Text = _ => ""Row 4.1 - Cell 3"" }
                        ),
                        new ControlTableRow(""myRow4_2"")
                        .Add
                        (
                            new ControlTableCell() { Text = _ => ""Row 4.2 - Cell 1"" },
                            new ControlTableCell() { Text = _ => ""Row 4.2 - Cell 2"" },
                            new ControlTableCell() { Text = _ => ""Row 4.2 - Cell 3"" }
                        )
                    )
                )",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
                    .AddRows(new ControlTableRow("myRow4")
                    {
                        Color = _ => TypeColorTable.Danger,
                        ExpandState = _ => TypeExpandState.Collapsed
                    }
                        .Add
                        (
                            new ControlTableCell() { Text = _ => "Row 4 - Cell 1" },
                            new ControlTableCell() { Text = _ => "Row 4 - Cell 2" },
                            new ControlTableCell() { Text = _ => "Row 4 - Cell 3" }
                        )
                        .Add
                        (
                            new ControlTableRow("myRow4_1")
                            .Add
                            (
                                new ControlTableCell() { Text = _ => "Row 4.1 - Cell 1" },
                                new ControlTableCell() { Text = _ => "Row 4.1 - Cell 2" },
                                new ControlTableCell() { Text = _ => "Row 4.1 - Cell 3" }
                            ),
                            new ControlTableRow("myRow4_2")
                            .Add
                            (
                                new ControlTableCell() { Text = _ => "Row 4.2 - Cell 1" },
                                new ControlTableCell() { Text = _ => "Row 4.2 - Cell 2" },
                                new ControlTableCell() { Text = _ => "Row 4.2 - Cell 3" }
                            )
                        )
                    )
                    .AddRows(new ControlTableRow("myRow5")
                        .Add
                        (
                            new ControlTableCell() { Text = _ => "Row 5 - Cell 1", Color = _ => TypeColorTable.Primary },
                            new ControlTableCell() { Text = _ => "Row 5 - Cell 2", Icon = _ => new IconHome() },
                            new ControlTableCell() { Text = _ => "Row 5 - Cell 3" }
                        )
                        .Add
                        (
                            new ControlDropdownItemHeader() { Text = _ => "Header" },
                            new ControlDropdownItemLink() { Text = _ => "First Entry", Icon = _ => new IconWrench() },
                            new ControlDropdownItemLink() { Text = _ => "Second Entry" },
                            new ControlDropdownItemDivider(),
                            new ControlDropdownItemLink() { Text = _ => "Third Entry" }
                        )
                    )
            );

            Stage.AddItemProperty
            (
                typeof(ControlTableRow),
                "PrimaryAction",
                "Defines the primary user action, typically executed on a standard click to open a dialog or perform the main operation.",
                "PrimaryAction = _ => new ActionModal(\"modal\")",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumnTemplate("myColumn4", new ControlTableTemplateDate()
                    {
                        Editable = _ => true,
                        Format = _ => "yyyy-MM-dd"

                    })
                    {
                        Title = _ => "Column",
                        Icon = _ => new IconTableTennisPaddleBall(),
                        Color = _ => TypeColorTable.Warning
                    })
                    .AddRows(_rows.Select
                    (
                        x => new ControlTableRow()
                        {
                            PrimaryAction = _ => new ActionModal("modal")
                        }
                            .Add(x.Cells)
                            .Add(new ControlTableCell($"myDate_{i}")
                            {
                                Text = _ => DateTime.Now.AddDays(i++).ToString("yyyy-MM-dd")
                            })
                    )),
                new ControlModalExample("modal")
                {
                }
            );

            Stage.AddItemProperty
            (
                typeof(ControlTableRow),
                "SecondaryAction",
                "Defines the secondary user action, often triggered by a double‑click to open a dialog or perform an alternative operation.",
                "SecondaryAction = _ => new ActionModal(\"modal\")",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumnTemplate("myColumn4", new ControlTableTemplateDate()
                    {
                        Editable = _ => true,
                        Format = _ => "yyyy-MM-dd"

                    })
                    {
                        Title = _ => "Column",
                        Icon = _ => new IconTableTennisPaddleBall(),
                        Color = _ => TypeColorTable.Warning
                    })
                    .AddRows(_rows.Select
                    (
                        x => new ControlTableRow()
                        {
                            SecondaryAction = _ => new ActionModal("modal")
                        }
                            .Add(x.Cells)
                            .Add(new ControlTableCell($"myDate_{i}")
                            {
                                Text = _ => DateTime.Now.AddDays(i++).ToString("yyyy-MM-dd")
                            })
                    )),
                new ControlModalExample("modal")
                {
                }
            );
        }
    }
}
