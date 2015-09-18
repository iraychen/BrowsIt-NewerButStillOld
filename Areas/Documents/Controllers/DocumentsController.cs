using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Models;
using BROWSit.Helpers;

namespace BROWSit.Areas.Documents.Controllers
{
    public class DocumentsController : Controller
    {
        BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        public ActionResult Index(string table = "", 
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
            ViewBag.Title = "Documents view";
            ViewBag.Message = "Display table data";

            // DataViewModel
            DocumentsModel model = new DocumentsModel(table, limit, showStats, sortUp, sortDown, hiddenColumns);

            if (!String.IsNullOrEmpty(table))
            {
                // Create sqlParameters object
                //SqlHelper.SqlParameters parameters = new SqlHelper.SqlParameters(table, limit, sortUp, sortDown);

                // Update columns
                model.updateHiddenColumnList(hide, show);

                // Because at this point we can confirm that no other control was pressed, by process of elimination, the table was changed.
                if (String.IsNullOrEmpty(hide) && String.IsNullOrEmpty(show) && String.IsNullOrEmpty(sortUp) && String.IsNullOrEmpty(sortDown))
                {
                    // Since the table changed, we should clear the hidden column list 
                    model.hiddenColumnList.Clear();
                }

                // Depending on the table, construct a DataTable to pass to the view
                switch (table)
                {
                    case "SRS":
                        // Build list of display columns and list of hidden columns
                        //parameters.columns = DataTableHelper.columnsToDisplay(SRS.getDefaultColumns, SRS.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(SRS.getDefaultColumns, SRS.getAllColumns, model.hiddenColumnList);
                        break;
                    case "PRS":
                        // Build list of display columns and list of hidden columns
                        //parameters.columns = DataTableHelper.columnsToDisplay(PRS.getDefaultColumns, PRS.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(PRS.getDefaultColumns, PRS.getAllColumns, model.hiddenColumnList);
                        break;
                    case "TestScripts":
                        // Build list of display columns and list of hidden columns
                        //parameters.columns = DataTableHelper.columnsToDisplay(TestScript.getDefaultColumns, TestScript.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(TestScript.getDefaultColumns, TestScript.getAllColumns, model.hiddenColumnList);
                        break;
                    default:
                        break;
                }

                // Query Reports in traditional SQL... safely
                //model.rawSqlString = parameters.constructAndGetSqlString(false);
                //SqlHelper.SqlTable sqlTable = SqlHelper.getTableFromRawSql(parameters.sqlStatement);
                //model.table = sqlTable.contents;
                //model.error = string.Join<string>("\n", sqlTable.errorStrings);
            }
            return View(model);
        }
    }
}
