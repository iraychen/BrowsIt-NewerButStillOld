using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using BROWSit.Models;
using BROWSit.Helpers;
using BROWSit.DAL;
using Novacode;

namespace BROWSit.Areas.Generate.Controllers
{
    public class GenerateController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Generate";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //GenerateModel model = new GenerateModel();

            return View();
        }

        [HttpPost]
        public ActionResult Index(string fileName = "", 
                                    string productLine = "", 
                                    string documentTitle = "", 
                                    string authorName = "", 
                                    string purpose = "")
        {
            ViewBag.Title = "Generate";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            GenerateModel model = new GenerateModel(fileName, productLine, documentTitle, authorName, purpose);


            WordHelper.exportToWord(model);

            

            return View();
        }

        public ActionResult Create(string fileName = "")
        {
            ViewBag.Title = "Generate";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //DataTable testTable = new DataTable();
            //ExcelHelper.exportToWord(testTable, "", fileName);

            return View();
        }
    }
}
