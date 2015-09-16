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
        public string fileName { get; set; }
        public string productLine { get; set; }
        public string documentTitle { get; set; }
        public string authorName { get; set; }
        public string versionNumber { get; set; }
        public string issueDate { get; set; }

        // Introduction
        public string purpose { get; set; }
        public string relatedDocuments { get; set; }
        public string definitions { get; set; }

        // Requirement Influencers
        public string softwareReuse { get; set; }
        public string futureUses { get; set; }

        // Requirements
        public List<RequirementArea> areas { get; set; }

        public GenerateModel()
        {
            fileName = "";
            productLine = "";
            documentTitle = "";
            authorName = "";
            purpose = "";

            areas = new List<RequirementArea>();
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

            areas = new List<RequirementArea>();
        }

        public class RequirementArea
        {
            public string name { get; set; }
            public List<Rqmt> requirements { get; set; }

            public RequirementArea(string p_name = "")
            {
                name = p_name;
                requirements = new List<Rqmt>();
            }
        }

        public class Rqmt
        {
            public string name { get; set; }
            public string text { get; set; }

            public Rqmt(string p_name = "", string p_text = "")
            {
                name = p_name;
                text = p_text;
            }
        }
    }
}
