using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace BROWSit.Helpers.SqlHelper
{
    public enum Direction
    {
        Up,
        Down
    }

    public class SqlParameters
    {
        public List<string> columns;
        public string tableName;
        public string limit;
        public string sortBy;
        public Direction sortDirection;
        public string sqlStatement;

        public SqlParameters()
        {
            columns = new List<string> { "*" };
            tableName = "";
            limit = "";
            sortBy = "";
            sortDirection = Direction.Up;
            sqlStatement = "";
        }

        public SqlParameters(string p_tableName, string p_limit, string p_sortUp, string p_sortDown)
        {
            columns = new List<string> { "*" };
            tableName = p_tableName;
            limit = p_limit;
            if (!String.IsNullOrEmpty(p_sortUp))
            {
                sortBy = p_sortUp;
                sortDirection = Direction.Up;
            }
            else if (!String.IsNullOrEmpty(p_sortDown))
            {
                sortBy = p_sortDown;
                sortDirection = Direction.Down;
            }
            sqlStatement = "";
        }

        public string constructAndGetSqlString(bool allColumns)
        {
            // SELECT [COLUMN 1], [COLUMN 2]
            sqlStatement = "SELECT ";

            // LIMIT [AMOUNT]
            if (!String.IsNullOrEmpty(limit))
            {
                sqlStatement += "TOP " + limit + " ";
            }

            // THIS PART CAUSES ISSUES! ENTITY FRAMEWORK CAN ONLY GRAB ENTITIES OR SINGLE VARIABLES!
            if (allColumns == true || columns.Count() == 0)
            {
                sqlStatement += "* ";
            }
            else
            {
                int count = 1;
                foreach (string column in columns)
                {
                    if (count == 1)
                    {
                        sqlStatement += column + " ";
                    }
                    else
                    {
                        sqlStatement += ", " + column + " ";
                    }
                    count++;
                }
                // ALWAYS grab ID, whether the user wants it displayed or not
                if (!columns.Contains("ID"))
                {
                    sqlStatement += ", ID ";
                }
            }

            // FROM [TABLE]
            sqlStatement += "FROM ";
            sqlStatement += tableName;

            // WHERE [CONDITIONS]

            // LIMIT [AMOUNT]
            /*if (!String.IsNullOrEmpty(limit))
            {
                sqlStatement += " LIMIT " + limit;
            }*/

            // ORDER BY [column_name] ASC|DESC, [column_name2] ASC|DESC;
            if (!String.IsNullOrEmpty(sortBy))
            {
                sqlStatement += " ORDER BY " + sortBy;
                if (sortDirection == Direction.Down)
                {
                    sqlStatement += " DESC";
                }
            }

            return sqlStatement;
        }

        public SqlTable getTableFromRawSql()
        {
            SqlTable sqlTable = new SqlTable();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BROWSitContext"].ConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStatement, connection))
                {
                    try
                    {
                        // Fill the Datatable
                        adapter.Fill(sqlTable.contents);

                        // Store ID's in string list, for row actions
                        sqlTable.idList = sqlTable.contents.Rows
                            .OfType<DataRow>()
                            .Select(r => r.Field<int>("ID"))
                            .ToList();

                        // If we want to remove the ID's from the table...
                        if (!columns.Contains("ID"))
                        {
                            // Remove ID column from Datatable
                            sqlTable.contents.Columns.Remove("ID");
                        }
                    }
                    catch (SqlException e)
                    {
                        //sqlTable.errors = e.Errors;
                        foreach (SqlError se in e.Errors)
                        {
                            sqlTable.errorStrings.Add("Message: " + se.Message
                                + " | Number: " + se.Number
                                + " | Line: " + se.LineNumber
                                + " | Source: " + se.Source
                                + " | Procedure: " + se.Procedure);
                        }
                    }
                }
            }

            return sqlTable;
        }
    }

    public class SqlTable
    {
        //public SqlErrorCollection errors;
        public List<string> errorStrings;
        public List<int> idList;
        public DataTable contents;

        public SqlTable()
        {
            //errors = new SqlErrorCollection();
            idList = new List<int>();
            contents = new DataTable();
            errorStrings = new List<string>();
        }

        public void getTableFromRawSql(string rawSql)
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BROWSitContext"].ConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(rawSql, connection))
                {
                    try
                    {
                        adapter.Fill(contents);
                    }
                    catch (SqlException e)
                    {
                        //sqlTable.errors = e.Errors;
                        foreach (SqlError se in e.Errors)
                        {
                            errorStrings.Add("Message: " + se.Message
                                + " | Number: " + se.Number
                                + " | Line: " + se.LineNumber
                                + " | Source: " + se.Source
                                + " | Procedure: " + se.Procedure);
                        }
                    }
                }
            }
        }
    }
}
