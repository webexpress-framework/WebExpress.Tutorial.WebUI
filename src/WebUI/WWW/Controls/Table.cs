using System.Collections.Generic;
using WebExpress.Toutorial.WebUI.Model;
using WebExpress.Toutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Toutorial.WebUI.WebPage;
using WebExpress.Toutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Toutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the table control for the tutorial.    
    /// </summary>    
    [Title("Table")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Table : PageControl
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
        /// <param name="pageContext">The context of the page where the table control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public Table(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.TABLE_SORT_EVENT, Event.COLUMN_REORDER_EVENT);

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
                    @"TableBorder = TypeTableBorder.Borderless",
                    new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        TableBorder = TypeTableBorder.Default
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Borderless", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        TableBorder = TypeTableBorder.Borderless
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Bordered", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        TableBorder = TypeTableBorder.Bordered
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows)

                );

            Stage.AddProperty
                (
                    "Striped",
                    @"The `Striped` property of a table control enhances its readability by applying alternating background colors to its rows. This visual distinction makes large datasets easier to scan and improves organization.",
                    @"Striped = TypeTableStriped.Row",
                    new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Striped = TypeTableStriped.Default
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Column", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Striped = TypeTableStriped.Column
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Row", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Striped = TypeTableStriped.Row
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Both", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Striped = TypeTableStriped.Both
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows)

                );

            Stage.AddProperty
                (
                    "Color",
                    @"The `Color` property in a table control allows customization of the table’s background color, helping improve readability and design consistency.",
                    @"Color = TypeTableColor.Primary",
                    new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Default
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Primary
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Secondary
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Info
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Success
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Warning
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Danger
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Light
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        Color = TypeTableColor.Dark
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows)

                );

            Stage.AddProperty
                (
                    "HeaderColor",
                    @"The `HeaderColor` property of a table control allows customization of the table header’s background color, improving visibility and design consistency.",
                    @"HeaderColor = TypeTableColor.Primary",
                    new ControlText() { Text = "Default", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Default
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Primary", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Primary
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Secondary", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Secondary
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Info", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Info
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Success", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Success
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Warning", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Warning
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Danger", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Danger
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Light", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Light
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows),
                    new ControlText() { Text = "Dark", TextColor = new PropertyColorText(TypeColorText.Info) },
                    new ControlTable()
                    {
                        HeaderColor = TypeTableColor.Dark
                    }
                        .AddColumns(_columns)
                        .AddRows(_rows)

                );

            Stage.AddItem
            (
                "AddColumn",
                "The `AddColumn` function is used to add new columns to a table, allowing for increased data representation and flexibility in table structure.",
                @"
                AddColumns(new ControlTableColumn() 
                { 
                    Title = ""Column"",
                    Icon = new IconTableTennisPaddleBall(),
                    Color = TypeTableColor.Warning
                })",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddColumns(new ControlTableColumn()
                    {
                        Title = "Column",
                        Icon = new IconTableTennisPaddleBall(),
                        Color = TypeTableColor.Warning
                    })
                    .AddRows(_rows)
            );

            Stage.AddItem
            (
                "AddRow",
                "The `AddRow` function adds a new row to a table, ensuring structural consistency and proper data integration.",
                @"
                AddRows(new ControlTableRow(""myRow4"") 
                { 
                    Color = TypeTableColor.Danger 
                }
                    .Add
                    (
                        new ControlTableCell() { Text = ""Row 4 - Cell 1"" },
                        new ControlTableCell() { Text = ""Row 4 - Cell 2"" },
                        new ControlTableCell() { Text = ""Row 4 - Cell 3"" }
                    )
                )
                .AddRows(new ControlTableRow(""myRow4"")
                    .Add
                    (
                        new ControlTableCell() { Text = ""Row 5 - Cell 1"", Color = TypeTableColor.Primary },
                        new ControlTableCell() { Text = ""Row 5 - Cell 2"", Icon = new IconHome() },
                        new ControlTableCell() { Text = ""Row 5 - Cell 3"" }
                    )
                )",
                new ControlTable()
                {
                }
                    .AddColumns(_columns)
                    .AddRows(_rows)
                    .AddRows(new ControlTableRow("myRow4")
                    {
                        Color = TypeTableColor.Danger
                    }
                        .Add
                        (
                            new ControlTableCell() { Text = "Row 4 - Cell 1" },
                            new ControlTableCell() { Text = "Row 4 - Cell 2" },
                            new ControlTableCell() { Text = "Row 4 - Cell 3" }
                        )
                    )
                    .AddRows(new ControlTableRow("myRow4")
                        .Add
                        (
                            new ControlTableCell() { Text = "Row 5 - Cell 1", Color = TypeTableColor.Primary },
                            new ControlTableCell() { Text = "Row 5 - Cell 2", Icon = new IconHome() },
                            new ControlTableCell() { Text = "Row 5 - Cell 3" }
                        )
                        .Add
                        (
                            new ControlDropdownItemHeader() { Text = "Header" },
                            new ControlDropdownItemLink() { Label = "First Entry", Icon = new IconWrench() },
                            new ControlDropdownItemLink() { Label = "Second Entry" },
                            new ControlDropdownItemDivider(),
                            new ControlDropdownItemLink() { Label = "Third Entry" }
                        )
                    )
            );
        }
    }
}
