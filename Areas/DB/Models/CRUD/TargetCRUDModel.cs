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
    public class TargetCRUDModel
    {
        public Target target { get; set; }
        public string message { get; set; }

        public TargetCRUDModel()
        {
        }
    }
}