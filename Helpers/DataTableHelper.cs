using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Reflection;
using BROWSit.Models;

namespace BROWSit.Helpers
{
    public class DataTableHelper
    {
        public static List<string> columnsToDisplay(List<string> defaultColumns, List<string> allColumns, List<string> hiddenColumns)
        {
            List<string> displayColumns = new List<string>();
            if (hiddenColumns.Count() == 0)
            {
                displayColumns = defaultColumns;
            }
            else
            {
                displayColumns = allColumns;
                displayColumns.RemoveAll(x => hiddenColumns.Contains(x));
            }

            return displayColumns;
        }

        public static List<string> columnsToHide(List<string> defaultColumns, List<string> allColumns, List<string> hiddenColumns)
        {
            List<string> hideColumns = new List<string>();
            if (hiddenColumns.Count() == 0)
            {
                hideColumns = allColumns;
                hideColumns.RemoveAll(x => defaultColumns.Contains(x));
            }
            else
            {
                hideColumns = hiddenColumns;
            }

            return hideColumns;
        }

        public static DataTable listToTable<T>(List<T> list, List<string> columns)
        {
            // Create the datatable
            DataTable dt = new DataTable();

            // Add columns
            foreach (string s in columns)
            {
                dt.Columns.Add(s);
            }

            // Add rows
            foreach (T entity in list)
            {
                DataRow r = dt.NewRow();
                foreach (string s in columns)
                {
                    foreach (PropertyInfo p in entity.GetType().GetProperties())
                    {
                        if (s == p.Name)
                        {
                            r[s] = p.GetValue(entity, null);
                        }
                    }
                }
                dt.Rows.Add(r);
            }

            return dt;
        }
    }
}