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
using System.Xml.Serialization;

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

            GenerateModel model = new GenerateModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(
            GenerateModel model)
        {
            ViewBag.Title = "Generate";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(model.submitType))
                {
                    if (model.submitType == "create")
                    {
                        if (!String.IsNullOrEmpty(model.temporarySRS.Filename))
                        {
                            // Export the model to OpenXML Word Document
                            WordHelper.exportToWord(model);

                            // Save SRS entity to Database
                            BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();
                            db.SRS.Add(model.temporarySRS);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(model.add))
                    {
                        if (model.add == "area")
                        {
                            if (model.areaNames != null)
                            {
                                model.areaNames.Add("New Area");
                                model.mappings.Add(0);
                            }
                        }
                        else
                        {
                            if (model.requirementNames != null)
                            {
                                model.requirementNames.Add("New Requirement Name");
                                model.requirementDescriptions.Add("New Requirement Description");
                                model.mappings[Int32.Parse(model.add)]++;
                            }
                        }
                    }
                }
            }

            return View(model);
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
