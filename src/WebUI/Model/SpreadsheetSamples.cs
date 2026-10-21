using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebUI.WebSpreadsheet;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// The workbooks of the spreadsheet tutorial, built on the server the way an application
    /// builds them: with <see cref="SpreadsheetWorkbook"/> instead of hand-written JSON.
    /// </summary>
    public static class SpreadsheetSamples
    {
        private static readonly string[] _months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

        /// <summary>
        /// Returns the small sales table of the first steps.
        /// </summary>
        /// <returns>The workbook.</returns>
        public static SpreadsheetWorkbook Sales()
        {
            var workbook = new SpreadsheetWorkbook();
            var sheet = workbook.AddSheet("Sales", 100, 10);

            sheet.SetData(
            [
                ["Customer", "Revenue", "Cost", "Profit", "Margin"],
                ["ACME", 1250, 800, "=B2-C2", "=D2/B2"],
                ["Demo Ltd.", 2100, 1300, "=B3-C3", "=D3/B3"],
                ["Initech", 1780, 990, "=B4-C4", "=D4/B4"],
                ["Total", "=SUM(B2:B4)", "=SUM(C2:C4)", "=SUM(D2:D4)", "=D5/B5"]
            ]);
            Header(sheet, "A1:E1");
            sheet.Format("B2:D5", s => s.NumberFormat = "#,##0.00");
            sheet.Format("E2:E5", s => s.NumberFormat = "0.0%");
            sheet.Format("A5:E5", s => { s.Bold = true; s.BorderTop = "thin #4472c4"; s.BorderBottom = "double #4472c4"; });
            sheet.ColumnWidths[0] = 140;
            sheet.Freeze(1);

            return workbook;
        }

        /// <summary>
        /// Returns the workbook of the formula step: arithmetic, text, logic, dates and lookups.
        /// </summary>
        /// <returns>The workbook.</returns>
        public static SpreadsheetWorkbook Formulas()
        {
            var workbook = new SpreadsheetWorkbook();
            var sheet = workbook.AddSheet("Formulas", 40, 6);

            sheet.SetData(
            [
                ["Formula", "Result", "", "Product", "Price", "Qty"],
                ["=SUM(E2:E5)", "=SUM(E2:E5)", "", "Pen", 1.5, 10],
                ["=AVERAGE(E2:E5)", "=AVERAGE(E2:E5)", "", "Ink", 4, 3],
                ["=MAX(E2:E5)-MIN(E2:E5)", "=MAX(E2:E5)-MIN(E2:E5)", "", "Pad", 2.5, 8],
                ["=COUNTIF(F2:F5,\">5\")", "=COUNTIF(F2:F5,\">5\")", "", "Box", 12, 2],
                ["=SUMIF(F2:F5,\">5\",E2:E5)", "=SUMIF(F2:F5,\">5\",E2:E5)"],
                ["=IF(B2>15,\"high\",\"low\")", "=IF(B2>15,\"high\",\"low\")"],
                ["=CONCAT(D2,\" & \",D3)", "=CONCAT(D2,\" & \",D3)"],
                ["=LEFT(D4,2)&MID(D5,2,2)", "=LEFT(D4,2)&MID(D5,2,2)"],
                ["=VLOOKUP(\"Ink\",D2:F5,2,FALSE)", "=VLOOKUP(\"Ink\",D2:F5,2,FALSE)"],
                ["=TODAY()", "=TODAY()"],
                ["=AND(F2>5,NOT(F5>5))", "=AND(F2>5,NOT(F5>5))"],
                ["=UNKNOWN(1)", "=UNKNOWN(1)"]
            ]);

            // the first column shows the formula of the second as text
            for (var row = 2; row <= 13; row++)
            {
                sheet.SetValue("A" + row, sheet["A" + row].Formula);
            }

            Header(sheet, "A1:B1");
            Header(sheet, "D1:F1");
            sheet.Format("B11:B11", s => s.NumberFormat = "dd.mm.yyyy");
            sheet.ColumnWidths[0] = 230;
            sheet.ColumnWidths[1] = 120;

            return workbook;
        }

        /// <summary>
        /// Returns the workbook of the multiple sheets step: two quarters and a summary that reads them.
        /// </summary>
        /// <returns>The workbook.</returns>
        public static SpreadsheetWorkbook Quarters()
        {
            var workbook = new SpreadsheetWorkbook();

            foreach (var (name, values) in new[] { ("Q1", new[] { 120, 135, 128 }), ("Q2", new[] { 140, 152, 149 }) })
            {
                var sheet = workbook.AddSheet(name, 20, 4);
                sheet.SetData([["Month", "Units"], .. values.Select((v, i) => new object[] { _months[(name == "Q1" ? 0 : 3) + i], v }), ["Total", "=SUM(B2:B4)"]]);
                Header(sheet, "A1:B1");
                sheet.TabColor = name == "Q1" ? "#4472c4" : "#70ad47";
            }

            var summary = workbook.AddSheet("Summary", 20, 4);
            summary.SetData(
            [
                ["Quarter", "Units", "Growth"],
                ["Q1", "=Q1!B5", ""],
                ["Q2", "=Q2!B5", "=B3/B2-1"],
                ["Year to date", "=SUM(B2:B3)", ""]
            ]);
            Header(summary, "A1:C1");
            summary.Format("C3:C3", s => s.NumberFormat = "0.0%");
            summary.TabColor = "#ffc000";
            workbook.ActiveSheet = "Summary";

            return workbook;
        }

        /// <summary>
        /// Returns a financial plan: income and expenses per month with totals, the result and
        /// the cumulated cash.
        /// </summary>
        /// <returns>The workbook.</returns>
        public static SpreadsheetWorkbook Budget()
        {
            var workbook = new SpreadsheetWorkbook();
            var sheet = workbook.AddSheet("Budget 2026", 30, 15);
            var rows = new List<object[]>
            {
                new object[] { "Item" }.Concat(_months).Append("Year").ToArray(),
                Row("Revenue", m => 42000 + m * 1500),
                Row("Services", m => 8000 + (m % 3) * 900),
                Row("Income", m => "=SUM(" + Col(m) + "2:" + Col(m) + "3)"),
                Row("Salaries", m => 26000),
                Row("Rent", m => 4200),
                Row("Marketing", m => m is 2 or 8 ? 9000 : 2500),
                Row("IT", m => 1800 + m * 50),
                Row("Expenses", m => "=SUM(" + Col(m) + "5:" + Col(m) + "8)"),
                Row("Result", m => "=" + Col(m) + "4-" + Col(m) + "9"),
                Row("Cash", m => m == 0 ? "=50000+B10" : "=" + Col(m - 1) + "11+" + Col(m) + "10")
            };

            sheet.SetData(rows);

            // the year column sums each row; the cash takes the last month
            for (var row = 2; row <= 10; row++)
            {
                sheet.SetFormula("N" + row, "SUM(B" + row + ":M" + row + ")");
            }

            sheet.SetFormula("N11", "M11");
            Header(sheet, "A1:N1");
            sheet.Format("B2:N11", s => s.NumberFormat = "#,##0 €;[Red]-#,##0 €");
            sheet.Format("A4:N4", s => { s.Bold = true; s.BorderTop = "thin #7f7f7f"; });
            sheet.Format("A9:N9", s => { s.Bold = true; s.BorderTop = "thin #7f7f7f"; });
            sheet.Format("A10:N10", s => { s.Bold = true; s.Fill = "#e2efda"; s.BorderTop = "medium #70ad47"; });
            sheet.Format("A11:N11", s => s.Italic = true);
            sheet.ColumnWidths[0] = 130;
            sheet.Freeze(1, 1);
            workbook.DefineName("Result", "'Budget 2026'!$B$10:$M$10");
            workbook.Meta["title"] = "Financial plan 2026";

            return workbook;
        }

        /// <summary>
        /// Formats a header row.
        /// </summary>
        /// <param name="sheet">The sheet.</param>
        /// <param name="range">The header range.</param>
        private static void Header(SpreadsheetSheet sheet, string range)
        {
            sheet.Format(range, s => { s.Bold = true; s.Fill = "#1f3864"; s.Color = "#ffffff"; s.BorderBottom = "medium #1f3864"; });
        }

        /// <summary>
        /// Builds a plan row of twelve months.
        /// </summary>
        /// <param name="label">The row label.</param>
        /// <param name="month">The value of a month (0 to 11).</param>
        /// <returns>The row.</returns>
        private static object[] Row(string label, Func<int, object> month)
        {
            return new object[] { label }.Concat(Enumerable.Range(0, 12).Select(month)).ToArray();
        }

        /// <summary>
        /// Returns the column letters of a month in the plan (January is B).
        /// </summary>
        /// <param name="month">The month (0 to 11).</param>
        /// <returns>The letters.</returns>
        private static string Col(int month) => SpreadsheetAddress.ColumnName(month + 1);
    }
}
