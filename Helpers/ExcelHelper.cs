using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using Novacode;

namespace BROWSit.Helpers
{
    public class ExcelHelper
    {
        public static void exportToExcel(DataTable table, string tableName, string workSheetName, string fileName)
        {
            // Create the excel file and add worksheet
            XLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.Worksheets.Add(workSheetName);

            // Hardcode title and contents locations
            IXLCell titleCell = workSheet.Cell(2, 2);
            IXLCell contentsCell = workSheet.Cell(3, 2);

            //Pretty-up the title
            titleCell.Value = tableName;
            titleCell.Style.Font.Bold = true;
            titleCell.Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
            titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Merge cells for title
            workSheet.Range(titleCell, workSheet.Cell(2, table.Columns.Count + 1)).Merge();

            // Insert table contents, and adjust for content width
            contentsCell.InsertTable(table);
            workSheet.Columns().AdjustToContents(1, 75);

            // Create a new response and flush it to a memory stream
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".xlsx;");
            using (MemoryStream stream = new MemoryStream())
            {
                workBook.SaveAs(stream);
                stream.WriteTo(response.OutputStream);
                stream.Close();
            }
            response.End();
        }

        public static void exportToWord(DataTable table, string tableName, string fileName)
        {
            // Create the word file
            DocX doc = DocX.Create(fileName, DocumentTypes.Document); // Defaults to second parameter I think
            
            // Enter file contents here


            // Create a new response and flush it to a memory stream
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".xlsx;");
            using (MemoryStream stream = new MemoryStream())
            {
                doc.SaveAs(stream);
                stream.WriteTo(response.OutputStream);
                stream.Close();
            }
            response.End();
        }
    }
}