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


namespace BROWSit.Areas.Upload.Controllers
{
    public class UploadController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Upload";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            // Checker flags
            UploadModel model = new UploadModel();

            // Grab the uploaded file
            HttpPostedFileBase file = Request.Files["doc-file"];
            if (file != null && file.ContentLength > 0)
            {
                model.fileCheck = true;

                // Verify the file type
                if (Path.GetExtension(file.FileName) == ".docx")
                {
                    model.typeCheck = true;
                    model.fileName = file.FileName;

                    //DocX doc = DocX.Load("filename");
                    //string contents = doc.ToString();
                }
            }

            return View(model);
        }

        public ActionResult Create(string fileName = "")
        {
            ViewBag.Title = "Upload";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            DataTable testTable = new DataTable();
            ExcelHelper.exportToWord(testTable, "", fileName);

            return View();
        }
    }
}
