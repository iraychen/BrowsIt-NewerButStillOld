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
    public class RoleCRUDModel
    {
        public Role role { get; set; }
        public User myUser { get; set; }
        public SelectList UserList { get; set; }
        public Report myReport { get; set; }
        public SelectList ReportList { get; set; }
        public string message { get; set; }

        public RoleCRUDModel()
        {
        }
    }
}