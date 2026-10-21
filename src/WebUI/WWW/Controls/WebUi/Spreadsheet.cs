using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebSpreadsheet;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>
    /// Represents the spreadsheet tutorial: a walk through creating a spreadsheet, loading and
    /// saving data, editing, formulas, custom functions, several sheets, undo and redo,
    /// collaboration and the integration into an application.
    /// </summary>
    [WebIcon<IconTableCells>]
    [Title("Spreadsheet")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Spreadsheet : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        /// <param name="componentHub">The component hub.</param>
        public Spreadsheet(IPageContext pageContext, IComponentHub componentHub)
        {
            var budget = componentHub.SitemapManager.GetUri<SpreadsheetBudget>(pageContext.ApplicationContext);

            Stage.Description = @"The `Spreadsheet` control brings a spreadsheet in the manner of Excel, Google Sheets and LibreOffice Calc into WebExpress applications: workbooks with several sheets, cells with text, numbers, dates, truth values, formulas and custom types, number and date formats, fonts, colors, borders and merged cells, the clipboard formats of the common spreadsheets, undo and redo, and real-time collaboration. It is operated with the mouse, by touch and completely by keyboard, and it renders only what is visible, so sheets with hundreds of thousands of rows stay fluent. The steps below build up its use one feature at a time.";

            Stage.Control = new ControlSpreadsheet("spreadsheet-intro")
            {
                Workbook = _ => SpreadsheetSamples.Sales(),
                GridHeight = _ => "18rem"
            };

            Stage.Code = @"
                var workbook = new SpreadsheetWorkbook();
                var sheet = workbook.AddSheet(""Sales"");

                sheet.SetData(
                [
                    [""Customer"", ""Revenue"", ""Cost"", ""Profit"", ""Margin""],
                    [""ACME"", 1250, 800, ""=B2-C2"", ""=D2/B2""],
                    [""Demo Ltd."", 2100, 1300, ""=B3-C3"", ""=D3/B3""],
                    [""Initech"", 1780, 990, ""=B4-C4"", ""=D4/B4""],
                    [""Total"", ""=SUM(B2:B4)"", ""=SUM(C2:C4)"", ""=SUM(D2:D4)"", ""=D5/B5""]
                ]);
                sheet.Format(""B2:D5"", s => s.NumberFormat = ""#,##0.00"");
                sheet.Format(""E2:E5"", s => s.NumberFormat = ""0.0%"");
                sheet.Freeze(1);

                new ControlSpreadsheet()
                {
                    Workbook = _ => workbook,
                    GridHeight = _ => ""18rem""
                };";

            Stage.AddEvent
            (
                Event.CHANGE_VALUE_EVENT,
                Event.SPREADSHEET_SELECTION_CHANGED_EVENT,
                Event.SPREADSHEET_CELL_CHANGED_EVENT,
                Event.SPREADSHEET_FORMULA_CHANGED_EVENT,
                Event.SPREADSHEET_CALCULATED_EVENT,
                Event.SPREADSHEET_SHEET_CREATED_EVENT,
                Event.SPREADSHEET_SHEET_DELETED_EVENT,
                Event.SPREADSHEET_SHEET_RENAMED_EVENT,
                Event.SPREADSHEET_ROW_ADDED_EVENT,
                Event.SPREADSHEET_ROW_REMOVED_EVENT,
                Event.SPREADSHEET_COLUMN_ADDED_EVENT,
                Event.SPREADSHEET_COLUMN_REMOVED_EVENT,
                Event.SPREADSHEET_UNDO_EVENT,
                Event.SPREADSHEET_REDO_EVENT
            );

            Stage.AddProperty
            (
                "Step 1: Create a spreadsheet",
                "A spreadsheet needs nothing but the control: `new ControlSpreadsheet()` shows an empty workbook with one sheet of 1000 rows and 26 columns, a toolbar, the name box and formula bar, the sheet tabs and a status bar. `Rows` and `Columns` set the size of new sheets, `GridHeight` the height of the grid, and `Toolbar`, `FormulaBar`, `SheetTabs` and `StatusBar` hide parts that a page does not need - the second example below is a compact grid without any of them.",
                "new ControlSpreadsheet() { Rows = _ => 50, Columns = _ => 8, GridHeight = _ => \"14rem\" }",
                new ControlSpreadsheet("spreadsheet-empty") { Rows = _ => 50, Columns = _ => 8, GridHeight = _ => "14rem" },
                new ControlSpreadsheet("spreadsheet-compact")
                {
                    Workbook = _ => SpreadsheetSamples.Sales(),
                    Toolbar = _ => false,
                    FormulaBar = _ => false,
                    SheetTabs = _ => false,
                    StatusBar = _ => false,
                    GridHeight = _ => "10rem"
                }
            );

            Stage.AddProperty
            (
                "Step 2: Load and save data",
                "A workbook is JSON, and on the server it is a `SpreadsheetWorkbook`: build it with `AddSheet`, `SetData`, `SetValue`, `SetFormula` and `Format`, and hand it over through `Workbook`. Inside a form, `ControlFormItemInputSpreadsheet` posts the workbook with the form; `GetWorkbook(context)` reads it back, validated, with the results the client computed for every formula. Without a form, `LoadUri` loads the workbook from a REST endpoint and `SaveUri` saves it there - with `Autosave` on its own a moment after every change, otherwise through the `save()` method of the control. The second spreadsheet below is loaded from and saved to the endpoint of this tutorial; change a cell and reload the page.",
                @"
                new ControlForm()
                    .Add(new ControlFormItemInputSpreadsheet(""budget"")
                    {
                        Label = _ => ""Budget"",
                        Required = _ => true,
                        GridHeight = _ => ""14rem""
                    }.Initialize(x => x.Value.Text = SpreadsheetSamples.Sales().ToJson()))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit());

                // read the posted workbook
                var workbook = input.GetWorkbook(context);
                var total = workbook[""Sales""].GetValue(""B5"");

                // load from and save to a REST endpoint
                new ControlSpreadsheet()
                {
                    LoadUri = _ => budgetEndpoint,
                    SaveUri = _ => budgetEndpoint,
                    Autosave = _ => 1500
                };",
                new ControlForm()
                    .Add(new ControlFormItemInputSpreadsheet("spreadsheet-form-input")
                    {
                        Label = _ => "Budget",
                        Required = _ => true,
                        GridHeight = _ => "14rem"
                    }.Initialize(x => x.Value.Text = SpreadsheetSamples.Sales().ToJson()))
                    .AddPrimaryButton(new ControlFormItemButtonSubmit()),
                new ControlSpreadsheet("spreadsheet-rest")
                {
                    LoadUri = _ => budget,
                    SaveUri = _ => budget,
                    Autosave = _ => 1500,
                    GridHeight = _ => "16rem"
                }
            );

            Stage.AddProperty
            (
                "Step 3: Edit cells",
                "Click a cell and type: the typing replaces the content, Enter commits and moves down, Tab moves right, the arrow keys commit and move, Escape cancels. F2, a double click or Ctrl+Enter edit the content instead, Alt+Enter breaks the line. Input is read in the conventions of the language (`Locale`): with `de`, typing `1.234,5`, `15%`, `1.234,50 €` or `20.10.2026` stores a number, a percentage, an amount or a date with a fitting format; a leading apostrophe keeps text as typed. Shift with the arrow keys or a drag selects ranges, Ctrl+click adds ranges, the headers select columns and rows, Ctrl+A the data region and then the sheet. Ctrl+arrow jumps to the edge of the data, Home, End and the page keys move as in the common spreadsheets. Delete clears, Ctrl+C, Ctrl+X and Ctrl+V copy, cut and paste - also between this page and Excel or Google Sheets. The fill handle at the bottom-right of the selection continues series, the border of the selection moves it, the header borders resize columns and rows, and the context menu inserts and deletes rows and columns, merges cells and adds comments. On a touch screen a tap selects, a double tap edits, a long press opens the menu and two fingers zoom.",
                "new ControlSpreadsheet() { Locale = _ => \"de\" }",
                new ControlSpreadsheet("spreadsheet-edit")
                {
                    Locale = _ => "de",
                    Rows = _ => 100,
                    Columns = _ => 10,
                    GridHeight = _ => "16rem"
                }
            );

            Stage.AddProperty
            (
                "Step 4: Use formulas",
                "A formula starts with `=` and computes from references (`A1`, `$A$1`, `A1:C3`, `A:A`, `Sheet2!B2`, named ranges), operators (`+ - * / ^ & = <> < > <= >= %`) and functions. While a formula is typed, the spreadsheet suggests function names and shows the syntax of the function the caret is in; the arrow keys and clicks into the grid insert references (point mode), F4 makes them absolute, and every reference is outlined in its own color. Results update immediately and only where a change reaches; a formula that reaches itself shows `#CIRC!`. The column on the left shows the formula of the result beside it. Built in are, among others, SUM, AVG, AVERAGE, MIN, MAX, COUNT, COUNTA, COUNTIF, SUMIF, IF, IFERROR, AND, OR, NOT, CONCAT, LEFT, RIGHT, MID, LEN, TEXT, ROUND, TODAY, NOW, DATE, YEAR, NETWORKDAYS, VLOOKUP, INDEX and MATCH.",
                @"sheet.SetFormula(""B2"", ""SUM(E2:E5)"");
                sheet.SetFormula(""B6"", ""IF(B2>15,\""high\"",\""low\"")"");",
                new ControlSpreadsheet("spreadsheet-formulas")
                {
                    Workbook = _ => SpreadsheetSamples.Formulas(),
                    GridHeight = _ => "20rem"
                }
            );

            Stage.AddProperty
            (
                "Step 5: Register custom functions",
                "Own functions are registered once per page with `webexpress.webui.SpreadsheetFunctions.register`, the way add-ons are registered with the editor; spreadsheets that exist already recalculate their formulas. A function receives its evaluated arguments - numbers, texts, truth values, ranges - and the helpers of `api.values` convert them as the built-in functions do. `lazy` functions evaluate their arguments on demand, `volatile` ones recalculate on every change. This page registers `VAT(amount, [rate])` and `WORKHOURS(start, end, [break])` in its script `spreadsheet.tutorial.js`.",
                @"
                webexpress.webui.SpreadsheetFunctions.register(""VAT"", {
                    fn: ([amount, rate], api) => {
                        const value = api.values.toNumber(amount);
                        if (api.values.isError(value)) return value;
                        const percent = rate === undefined ? 0.19 : api.values.toNumber(rate);
                        return Math.round(value * percent * 100) / 100;
                    },
                    minArgs: 1,
                    maxArgs: 2,
                    syntax: ""VAT(amount, [rate])"",
                    description: ""Returns the value added tax of an amount.""
                });",
                new ControlSpreadsheet("spreadsheet-functions")
                {
                    Workbook = _ => CustomFunctions(),
                    GridHeight = _ => "12rem"
                }
            );

            Stage.AddProperty
            (
                "Step 6: Work with several sheets",
                "A workbook holds any number of sheets. The + button adds one, a double click on a tab renames it, dragging reorders the tabs, and the context menu of a tab duplicates, moves and deletes it; Ctrl+Page Up and Ctrl+Page Down switch sheets. Formulas read other sheets as `Q1!B5` or `'Sheet name'!A1`, and renaming a sheet updates them. In code, `AddSheet`, `RenameSheet`, `CopySheet`, `MoveSheet` and `RemoveSheet` (JavaScript: `addSheet`, `renameSheet`, `copySheet`, `moveSheet`, `removeSheet`) do the same. The summary below adds up two quarters.",
                @"
                var q1 = workbook.AddSheet(""Q1"");
                var summary = workbook.AddSheet(""Summary"");
                summary.SetFormula(""B2"", ""Q1!B5"");
                workbook.ActiveSheet = ""Summary"";",
                new ControlSpreadsheet("spreadsheet-sheets")
                {
                    Workbook = _ => SpreadsheetSamples.Quarters(),
                    GridHeight = _ => "14rem"
                }
            );

            Stage.AddProperty
            (
                "Step 7: Undo and redo",
                "Every change can be undone with Ctrl+Z and redone with Ctrl+Y or the toolbar: values, formulas, formats, comments, merges, rows, columns and sheets. A paste, a fill, a sort or a formatting of a large range is one step, and changes that belong together - the stages of resizing one column, repeated clicks on more decimal places - merge into one step when they follow within `HistoryMerge` milliseconds. `HistoryLimit` sets how many steps are kept. In JavaScript, `batch(fn, label)` makes several API calls one step, and `undo()`, `redo()`, `canUndo()` and `canRedo()` drive the history.",
                @"
                new ControlSpreadsheet()
                {
                    HistoryLimit = _ => 50,
                    HistoryMerge = _ => 2000
                };

                // JavaScript: several changes as one undo step
                ctrl.batch(() => {
                    ctrl.setValue(""A1"", ""Total"");
                    ctrl.setFormula(""B1"", ""SUM(B2:B10)"");
                }, ""add total"");",
                new ControlSpreadsheet("spreadsheet-history")
                {
                    Workbook = _ => SpreadsheetSamples.Sales(),
                    HistoryLimit = _ => 50,
                    HistoryMerge = _ => 2000,
                    GridHeight = _ => "12rem"
                }
            );

            Stage.AddProperty
            (
                "Step 8: Share a workbook in real time",
                "Several users edit one workbook at the same time. Inside a `ControlCollaborative` of WebApp a spreadsheet is shared without further code: the server sequences the changes, everybody sees the selections and changes of the others, and undo takes back only the own changes - see the Collaborative page of the WebApp controls. Without WebApp, any synchronization mechanism connects through a provider (`SpreadsheetCollaborationProvider`); the two spreadsheets below share one workbook through an in-page hub that delays every message by 120 ms like a network. Type into both: inserted rows, formulas typed against the old rows and concurrent edits of different cells all converge.",
                @"
                // WebApp: share through the server
                new ControlCollaborative(""plan"", new ControlSpreadsheet(""budget""))
                {
                    Document = _ => ""budget-2026""
                };

                // any provider: share through a hub, a WebSocket, a message queue, ...
                const hub = new webexpress.webui.SpreadsheetMemoryHub({ latency: 120 });
                await left.connect(new webexpress.webui.SpreadsheetMemoryProvider(hub), { user: { name: ""Anna"" } });
                await right.connect(new webexpress.webui.SpreadsheetMemoryProvider(hub), { user: { name: ""Ben"" } });",
                new ControlSpreadsheet("spreadsheet-share-anna")
                {
                    Workbook = _ => SpreadsheetSamples.Sales(),
                    Classes = ["tutorial-spreadsheet-share"],
                    UserName = _ => "Anna",
                    GridHeight = _ => "12rem"
                },
                new ControlSpreadsheet("spreadsheet-share-ben")
                {
                    Classes = ["tutorial-spreadsheet-share"],
                    UserName = _ => "Ben",
                    GridHeight = _ => "12rem"
                }
            );

            Stage.AddProperty
            (
                "Step 9: Integrate into an application",
                "The spreadsheet keeps the control contract of WebExpress, so forms, binds and `webexpress.webui.Field` treat it like every field: its `value` is the workbook as JSON, `CHANGE_VALUE_EVENT` announces every change, and `dirty`, `markPristine()` and `reset()` track unsaved work. Its own events tell exactly what changed: selectionChanged, cellChanged, formulaChanged, calculated, sheetCreated, sheetDeleted, sheetRenamed, rowAdded, rowRemoved, columnAdded, columnRemoved, undo and redo - watch them in the event logger at the end of this page while you work in the first spreadsheet. The API reads and writes cells, ranges, formats, names and structure, and a plugin registered with `webexpress.webui.SpreadsheetPlugins` adds its own toolbar group and context menu entries.",
                @"
                const ctrl = webexpress.webui.Controller.getInstanceByElement(document.getElementById(""budget""));

                host.addEventListener(webexpress.webui.Event.SPREADSHEET_CELL_CHANGED_EVENT, (e) => {
                    for (const cell of e.detail.cells) console.log(cell.ref, cell.before, ""->"", cell.after, ""="", cell.value);
                });

                ctrl.setValue(""B2"", 1400);
                ctrl.setStyle(""A1:E1"", { bold: true, fill: ""#eeeeee"" });
                ctrl.insertRows(4, 1);
                const total = ctrl.getValue(""B6"");",
                new ControlSpreadsheet("spreadsheet-integration")
                {
                    Workbook = _ => SpreadsheetSamples.Sales(),
                    UserName = _ => "Guybrush",
                    GridHeight = _ => "12rem"
                }
            );
        }

        /// <summary>
        /// Adds the script of the tutorial, which registers the custom functions and shares the
        /// spreadsheets of the collaboration step.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public override void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            visualTree.AddHeaderScriptLink(renderContext.PageContext.ApplicationContext.Route.Concat("assets/js/spreadsheet.tutorial.js").ToString());

            base.Process(renderContext, visualTree);
        }

        /// <summary>
        /// Returns the workbook of the custom function step.
        /// </summary>
        /// <returns>The workbook.</returns>
        private static SpreadsheetWorkbook CustomFunctions()
        {
            var workbook = new SpreadsheetWorkbook();
            var sheet = workbook.AddSheet("Functions", 30, 6);

            sheet.SetData(
            [
                ["Net", "VAT 19 %", "VAT 7 %", "Gross"],
                [100, "=VAT(A2)", "=VAT(A2,7%)", "=A2+B2"],
                [249.9, "=VAT(A3)", "=VAT(A3,7%)", "=A3+B3"],
                ["Start", "End", "Break (min)", "Hours"],
                [0.333333333333, 0.708333333333, 30, "=WORKHOURS(A5,B5,C5)"]
            ]);
            sheet.Format("A1:D1", s => s.Bold = true);
            sheet.Format("A4:D4", s => s.Bold = true);
            sheet.Format("A2:D3", s => s.NumberFormat = "#,##0.00");
            sheet.Format("A5:B5", s => s.NumberFormat = "hh:mm");
            sheet.Format("D5:D5", s => s.NumberFormat = "0.00");

            return workbook;
        }
    }
}
