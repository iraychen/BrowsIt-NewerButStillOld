using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using BROWSit.Models;
using BROWSit.Helpers;
using BROWSit.DAL;

namespace BROWSit.Areas.Reporting.Controllers
{
    public class ReportsController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Reports List";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            ReportingModel model = new ReportingModel();
            List<Report> reportsList = db.Reports.ToList();

            foreach (Report r in reportsList)
            {
                model.idList.Add(r.ID);
            }

            model.table = DataTableHelper.listToTable<Report>(reportsList, Report.getDefaultColumns);

            return View(model);
        }

        public ActionResult Detail(int id = 0)
        {
            ViewBag.Title = "View Report";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            ReportingModel model = new ReportingModel();

            // Find the correct report entity
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }

            // Query Reports in traditional SQL... safely
            //SqlHelper.SqlTable sqlTable = SqlHelper.getTableFromRawSql(report.Query);
            //model.table = sqlTable.contents;
            //model.error = String.Join<string>("\n", sqlTable.errorStrings);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create(string rawSql = "")
        {
            if (!String.IsNullOrEmpty(rawSql))
            {
                Report report = new Report();
                report.Query = rawSql;

                return View(report);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report);
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Title = "View Report";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            // Find the correct report entity
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }

            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
