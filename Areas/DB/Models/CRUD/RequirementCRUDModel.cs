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
    public class RequirementCRUDModel
    {
        public Requirement requirement { get; set; }
        public Target myTarget { get; set; }
        public SelectList TargetList { get; set; }
        public string message { get; set; }

        public RequirementCRUDModel()
        {
        }
    }
}