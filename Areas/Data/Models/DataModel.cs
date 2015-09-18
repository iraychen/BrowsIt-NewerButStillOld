using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Helpers;
using BROWSit.Helpers.SqlHelper;
using BROWSit.Helpers.PermissionsHelper;

namespace BROWSit.Models
{
    public class DataModel
    {
        // General
        public string category;
        public List<SelectListItem> tableNames;

        // SqlHelper
        public SqlParameters parameters;
        public SqlTable table;

        // Permissions
        public TableEntryPermissions permissions;

        // Misc.
        public List<string> hiddenColumnList;
        public StatsHelper.HelperStatistics stats;
        public string error;

        public DataModel()
        {
            category = "";
            tableNames = null;
            parameters = new SqlParameters();
            table = new SqlTable();
            hiddenColumnList = new List<string>();
            stats = new StatsHelper.HelperStatistics();
            error = "";
        }

        public DataModel(string p_category, string p_tableName, string p_limit, string p_showStats, string p_sortUp, string p_sortDown, string p_columns)
        {
            category = p_category;

            string tableName = setTable(p_tableName);
            parameters = new SqlParameters(tableName, p_limit, p_sortUp, p_sortDown);

            permissions = new TableEntryPermissions();
            permissions.setPermissions(p_category, p_tableName);

            table = new SqlTable();
            
            hiddenColumnList = new List<string>(p_columns.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            
            if (!String.IsNullOrEmpty(p_showStats))
            {
                stats = new StatsHelper.HelperStatistics();
            }
            else
            {
                stats = null;
            }

            error = "";
        }

        public string setTable(string p_table)
        {
            if (category == "Data")
            {
                tableNames = new List<SelectListItem>();
                tableNames.Add(new SelectListItem { Text = "--Select Table--", Value = "" });
                tableNames.Add(new SelectListItem { Text = "Requirements", Value = "Requirements" });
                tableNames.Add(new SelectListItem { Text = "Platforms", Value = "Platforms" });
                tableNames.Add(new SelectListItem { Text = "Targets", Value = "Targets" });
                tableNames.Add(new SelectListItem { Text = "Features", Value = "Features" });
            }
            else if (category == "Documents")
            {
                tableNames = new List<SelectListItem>();
                tableNames.Add(new SelectListItem { Text = "--Select Table--", Value = "" });
                tableNames.Add(new SelectListItem { Text = "SRS", Value = "SRS" });
                tableNames.Add(new SelectListItem { Text = "PRS", Value = "PRS" });
                tableNames.Add(new SelectListItem { Text = "TestScripts", Value = "TestScripts" });
            }
            else if (category == "Reports")
            {
                return "Reports";
            }
            return p_table;
        }

        public void updateHiddenColumnList(string hide, string show)
        {
            if (!String.IsNullOrEmpty(hide))
            {
                hiddenColumnList.Add(hide);
            }
            else if (!String.IsNullOrEmpty(show))
            {
                hiddenColumnList.Remove(show);
            }
        }

        public void getStatisticsAndTable(DataTable p_table)
        {
            // Copy over datatable
            table.contents = p_table;

            if (stats != null)
            {
                // Get statistics here
                stats.rowCount = p_table.Rows.Count;
            }
        }
    }
}
