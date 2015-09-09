using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BROWSit.Models
{
    public class ReportingModel
    {
        public DataTable table;
        public string sortUp;
        public string sortDown;
        public string error;
        public List<int> idList;

        public ReportingModel()
        {
            table = new DataTable();
            sortUp = "";
            sortDown = "";
            error = "";
            idList = new List<int>();
        }
    }
}
