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
    public class PRSCRUDModel
    {
        public PRS prs { get; set; }
        public string message { get; set; }

        public PRSCRUDModel()
        {
        }
    }
}