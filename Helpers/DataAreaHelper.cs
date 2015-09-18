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
    public class DataAreaHelper
    {
        public static List<string> getDefaultColumnsFromTable(string table)
        {
            switch (table)
            {
                case "Requirements":
                    return Requirement.getDefaultColumns;
                case "Platforms":
                    return Platform.getDefaultColumns;
                case "Targets":
                    return Target.getDefaultColumns;
                case "Features":
                    return Feature.getDefaultColumns;
                case "SRS":
                    return SRS.getDefaultColumns;
                case "PRS":
                    return PRS.getDefaultColumns;
                case "TestScripts":
                    return TestScript.getDefaultColumns;
                case "Reports":
                    return Report.getDefaultColumns;
                default:
                    List<string> emptyList = new List<string>();
                    return emptyList;
            }
        }

        public static List<string> getAllColumnsFromTable(string table)
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
        }
    }
}