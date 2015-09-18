using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Helpers;

namespace BROWSit.Models
{
    public class DocumentsModel
    {
        public string tableName;
        public List<SelectListItem> tableNames;
        public string limit;
        public string sortUp;
        public string sortDown;
        public List<string> hiddenColumnList;
        public DataTable table;
        public string rawSqlString;
        public StatsHelper.HelperStatistics stats;

        public DocumentsModel()
        {
            tableName = "";
            tableNames = null;
            limit = "";
            sortUp = "";
            sortDown = "";
            hiddenColumnList = new List<string>();
            rawSqlString = "";
            stats = new StatsHelper.HelperStatistics();
        }

        public DocumentsModel(string p_table, string p_limit, string p_showStats, string p_sortUp, string p_sortDown, string p_columns)
        {
            tableName = p_table;
            tableNames = getTableSelectList();
            limit = p_limit;
            sortUp = p_sortUp;
            sortDown = p_sortDown;
            hiddenColumnList = new List<string>(p_columns.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            rawSqlString = "";
            if (!String.IsNullOrEmpty(p_showStats))
            {
                stats = new StatsHelper.HelperStatistics();
            }
            else
            {
                stats = null;
            }
            
        }

        public List<SelectListItem> getTableSelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem { Text = "--Select Table--", Value = "" });
            list.Add(new SelectListItem { Text = "SRS", Value = "SRS" });
            list.Add(new SelectListItem { Text = "PRS", Value = "PRS" });
            list.Add(new SelectListItem { Text = "Tests", Value = "TestScripts" });

            return list;
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
            table = p_table;

            if (stats != null)
            {
                // Get statistics here
                stats.rowCount = p_table.Rows.Count;
            }
        }
    }
}
