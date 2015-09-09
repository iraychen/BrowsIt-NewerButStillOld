using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace BROWSit.Helpers
{
    public class SqlHelper
    {
        public enum Direction
        {
            Up,
            Down
        }

        public class HelperSqlParameters
        {
            public List<string> columns;
            public string table;
            public string limit;
            public string sortBy;
            public Direction sortDirection;
            public string sqlStatement;

            public HelperSqlParameters()
            {
                columns = new List<string> { "*" };
                table = "";
                limit = "";
                sortBy = "";
                sortDirection = Direction.Up;
                sqlStatement = "";
            }

            public HelperSqlParameters(string p_table, string p_limit, string p_sortUp, string p_sortDown)
            {
                columns = new List<string> { "*" };
                table = p_table;
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
                }

                // FROM [TABLE]
                sqlStatement += "FROM ";
                sqlStatement += table;

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
        }

        public class SqlTable
        {
            //public SqlErrorCollection errors;
            public List<string> errorStrings;
            public DataTable contents;

            public SqlTable()
            {
                //errors = new SqlErrorCollection();
                contents = new DataTable();
                errorStrings = new List<string>();
            }
        }

        public static SqlTable getTableFromRawSql(string rawSql)
        {
            SqlTable sqlTable = new SqlTable();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BROWSitContext"].ConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(rawSql, connection))
                {
                    try
                    {
                        adapter.Fill(sqlTable.contents);
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
}
