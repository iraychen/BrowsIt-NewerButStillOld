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
        public SRS temporarySRS { get; set; }
        public string submitType { get; set; }
        public string add { get; set; }
        public string newAreaName { get; set; }

        // Requirements
        public List<RequirementArea> areas { get; set; }
        public List<string> areaNames { get; set; }
        public List<int> mappings { get; set; }
        public List<string> requirementNames { get; set; }
        public List<string> requirementDescriptions { get; set; }

        public GenerateModel()
        {
            areaNames = new List<string>();
            requirementNames = new List<string>();
            requirementDescriptions = new List<string>();
            mappings = new List<int>();
        }
    }
}
