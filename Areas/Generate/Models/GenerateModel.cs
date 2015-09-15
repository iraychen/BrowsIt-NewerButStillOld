using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BROWSit.Models
{
    public class GenerateModel
    {
        // General
        public string fileName;
        public string productLine;
        public string documentTitle;
        public string authorName;
        public string versionNumber;
        public string issueDate;

        // Introduction
        public string purpose;
        public string relatedDocuments;
        public string definitions;

        // Requirement Influencers
        public string softwareReuse;
        public string futureUses;

        // Requirements
        public List<RequirementArea> areas;

        public GenerateModel()
        {
            fileName = "";
        }

        public GenerateModel(string p_fileName = "",
                                    string p_productLine = "",
                                    string p_documentTitle = "",
                                    string p_authorName = "",
                                    string p_purpose = "")
        {
            fileName = p_fileName;
            productLine = p_productLine;
            documentTitle = p_documentTitle;
            authorName = p_authorName;
            purpose = p_purpose;
        }

        public class RequirementArea
        {
            public string name;
            public List<Rqmt> requirements;
        }

        public class Rqmt
        {
            public string name;
            public string text;
        }
    }
}
