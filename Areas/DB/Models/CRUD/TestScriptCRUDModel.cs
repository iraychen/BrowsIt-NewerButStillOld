using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    public class TestScriptCRUDModel
    {
        public TestScript testScript { get; set; }
        public Requirement myRequirement { get; set; }
        public SelectList RequirementList { get; set; }
        public string message { get; set; }

        public TestScriptCRUDModel()
        {
        }
    }
}