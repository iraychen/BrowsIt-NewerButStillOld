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
using Newtonsoft.Json;
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

            GenerateModel model = new GenerateModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(
            string json,
            string submitType = "", string add = "", string newAreaName = "")
        {
            ViewBag.Title = "Generate";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            // Deserialize the JSON string
            if (!String.IsNullOrEmpty(json))
            {
                SRS deserializedSRS = JsonConvert.DeserializeObject<SRS>(json);
            }

            //GenerateModel updatedModel = new GenerateModel();

            if (ModelState.IsValid)
            {
                List<string> areaNamesList = new List<string>(areaNames.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries));
                foreach (string s in areaNamesList)
                {
                    GenerateModel.RequirementArea newArea = new GenerateModel.RequirementArea(s);
                    updatedModel.areas.Add(newArea);
                }

                if (!String.IsNullOrEmpty(submitType))
                {
                    if (submitType == "create")
                    {
                        if (!String.IsNullOrEmpty(updatedModel.fileName))
                        {
                            WordHelper.exportToWord(updatedModel);
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(add))
                    {
                        if (add == "area")
                        {
                            GenerateModel.RequirementArea newArea = new GenerateModel.RequirementArea(newAreaName);
                            updatedModel.areas.Add(newArea);
                        }
                    }
                }
            }

            return View(updatedModel);
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
