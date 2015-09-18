using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using BROWSit.Helpers;
using BROWSit.Helpers.SqlHelper;

namespace BROWSit.Areas.Export.Controllers
{
    public class ExportController : Controller
    {
        public ActionResult Index(string exportTo = "", string rawSql = "", string tableName = "")
        {
            // Route user based on requested selection
            if (exportTo == "Report")
            {
                // Route user to reportsController
                return RedirectToAction("Create", "Reports", new { area = "Reporting", rawSql = rawSql });
            }
            else if (exportTo == "Excel")
            {
                ViewBag.Type = exportTo;
                ViewBag.Sql = rawSql;
                ViewBag.Table = tableName;
            }

            return View();
        }

        public ActionResult Create(string rawSql = "", string workSheetName = "", string tableName = "", string fileName = "")
        {
            // Query in traditional SQL... safely
            SqlTable sqlTable = new SqlTable();
            sqlTable.getTableFromRawSql(rawSql);
            ExcelHelper.exportToExcel(sqlTable.contents, tableName, workSheetName, fileName);

            // Does this never get reached?
            return View("Index");
        }

    }
}
