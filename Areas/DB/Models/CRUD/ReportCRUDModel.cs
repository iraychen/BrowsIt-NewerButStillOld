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
    public class ReportCRUDModel
    {
        public Report report { get; set; }
        public User myUser { get; set; }
        public SelectList UserList { get; set; }
        public Role myRole { get; set; }
        public SelectList RoleList { get; set; }
        public string message { get; set; }

        public ReportCRUDModel()
        {
        }
    }
}