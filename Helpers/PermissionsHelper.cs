using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Reflection;
using BROWSit.Models;

namespace BROWSit.Helpers.PermissionsHelper
{
    public class TableEntryPermissions
    {
        public bool canCreate;
        public bool canView;
        public bool canEdit;
        public bool canDelete;

        public TableEntryPermissions()
        {
            canCreate = false;
            canView = false;
            canEdit = false;
            canDelete = false;
        }

        public void setPermissions(string category, string tableName)
        {
            if (category == "Data")
            {
                canCreate = true;
                canEdit = true;
                canDelete = true;
            }
            else if (category == "Documents")
            {
                canCreate = true;
                canEdit = true;
                canDelete = true;
            }
            else if (category == "Reports")
            {
                canCreate = true;
                canView = true;
                canEdit = true;
                canDelete = true;
            }
        }
    }
        
    /*public static List<string> getAllColumnsFromTable(string table)
    {
        switch (table)
        {
            case "Requirements":
                return Requirement.getAllColumns;
            case "Platforms":
                return Platform.getAllColumns;
            case "Targets":
                return Target.getAllColumns;
            case "Features":
                return Feature.getAllColumns;
            case "SRS":
                return SRS.getAllColumns;
            case "PRS":
                return PRS.getAllColumns;
            case "TestScripts":
                return TestScript.getAllColumns;
            case "Reports":
                return Report.getAllColumns;
            default:
                List<string> emptyList = new List<string>();
                return emptyList;
        }
    }*/
}