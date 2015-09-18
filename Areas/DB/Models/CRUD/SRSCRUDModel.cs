using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    public class SRSCRUDModel
    {
        // General
        public SRS srs { get; set; }
        public string message { get; set; }
        public string submitType { get; set; }
        public string add { get; set; }
        public string newAreaName { get; set; }

        // Requirements
        public List<RequirementArea> areas { get; set; }
        public List<string> areaNames { get; set; }
        public List<int> mappings { get; set; }
        public List<string> requirementNames { get; set; }
        public List<string> requirementDescriptions { get; set; }

        public SRSCRUDModel()
        {
            areaNames = new List<string>();
            requirementNames = new List<string>();
            requirementDescriptions = new List<string>();
            mappings = new List<int>();
        }
    }
}