using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Models;
using BROWSit.Helpers;
using BROWSit.Helpers.SqlHelper;

namespace BROWSit.Areas.Data.Controllers
{
    public class DataController : Controller
    {
        BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        public ActionResult Index(string category = "",
                                string table = "", 
                                string limit = "",
                                string stats = "",
                                string hiddenColumns = "",
                                string show = "",
                                string hide = "",
                                string sortDown = "",
                                string sortUp = "",
                                string showStats = ""
                                )
        {
            // Basic page information
            ViewBag.Title = category + " View";
            ViewBag.Message = "Display table data";

            // DataViewModel
            DataModel model = new DataModel(category, table, limit, showStats, sortUp, sortDown, hiddenColumns);

            if (!String.IsNullOrEmpty(model.parameters.tableName))
            {
                // Update columns
                model.updateHiddenColumnList(hide, show);

                // Because at this point we can confirm that no other control was pressed, by process of elimination, the table was changed.
                if (String.IsNullOrEmpty(hide) && String.IsNullOrEmpty(show) && String.IsNullOrEmpty(sortUp) && String.IsNullOrEmpty(sortDown))
                {
                    // Since the table changed, we should clear the hidden column list 
                    model.hiddenColumnList.Clear();
                }

                // Grab column lists based on the defined table
                List<string> defaultColumns = DataAreaHelper.getDefaultColumnsFromTable(table);
                List<string> allColumns = DataAreaHelper.getAllColumnsFromTable(table);

                // Construct a DataTable to pass to the view
                model.parameters.columns = DataTableHelper.columnsToDisplay(defaultColumns, allColumns, model.hiddenColumnList);
                model.hiddenColumnList = DataTableHelper.columnsToHide(defaultColumns, allColumns, model.hiddenColumnList);

                // Query Reports in traditional SQL... safely
                model.parameters.constructAndGetSqlString(false);
                model.table = model.parameters.getTableFromRawSql();
                //model.error = string.Join<string>("\n", sqlTable.errorStrings);
            }
            return View(model);
        }

        public ActionResult Detail(string category = "",
                                string table = "",
                                int id = 0
                                )
        {
            // Basic page information
            ViewBag.Title = category + " View";
            ViewBag.Message = "Display table data";

            if (category == "Reports")
            {
                // Find the correct report
                Report report = db.Reports.Find(id);

                // Verify that the report is not null
                if (report == null)
                {
                    return HttpNotFound();
                }

                // Get report query
                //SqlParameters parameters = new SqlParameters();
                //parameters.sqlStatement = report.Query;

                // Run query and get datatable
                SqlTable sqlTable = new SqlTable();
                sqlTable.getTableFromRawSql(report.Query);

                // Proceed to Detail view
                return View(sqlTable);
            }

            return View();
        }
    }
}
