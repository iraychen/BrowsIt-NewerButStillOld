using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Models;
using BROWSit.Helpers;

namespace BROWSit.Areas.Data.Controllers
{
    public class DataController : Controller
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
            ViewBag.Title = "Dataview";
            ViewBag.Message = "Display table data";

            // DataViewModel
            DataModel model = new DataModel(table, limit, showStats, sortUp, sortDown, hiddenColumns);

            if (!String.IsNullOrEmpty(table))
            {
                // Create sqlParameters object
                SqlHelper.HelperSqlParameters parameters = new SqlHelper.HelperSqlParameters(table, limit, sortUp, sortDown);

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
                    case "Requirements":
                        // Build list of display columns and list of hidden columns
                        parameters.columns = DataTableHelper.columnsToDisplay(Requirement.getDefaultColumns, Requirement.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(Requirement.getDefaultColumns, Requirement.getAllColumns, model.hiddenColumnList);
                        break;
                    case "Platforms":
                        // Build list of display columns and list of hidden columns
                        parameters.columns = DataTableHelper.columnsToDisplay(Platform.getDefaultColumns, Platform.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(Platform.getDefaultColumns, Platform.getAllColumns, model.hiddenColumnList);
                        break;
                    case "Targets":
                        // Build list of display columns and list of hidden columns
                        parameters.columns = DataTableHelper.columnsToDisplay(Target.getDefaultColumns, Target.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(Target.getDefaultColumns, Target.getAllColumns, model.hiddenColumnList);
                        break;
                    case "Features":
                        // Build list of display columns and list of hidden columns
                        parameters.columns = DataTableHelper.columnsToDisplay(Feature.getDefaultColumns, Feature.getAllColumns, model.hiddenColumnList);
                        model.hiddenColumnList = DataTableHelper.columnsToHide(Feature.getDefaultColumns, Feature.getAllColumns, model.hiddenColumnList);
                        break;
                    default:
                        break;
                }

                // Query Reports in traditional SQL... safely
                model.rawSqlString = parameters.constructAndGetSqlString(false);
                SqlHelper.SqlTable sqlTable = SqlHelper.getTableFromRawSql(parameters.sqlStatement);
                model.table = sqlTable.contents;
                //model.error = string.Join<string>("\n", sqlTable.errorStrings);
            }
            return View(model);
        }
    }
}
