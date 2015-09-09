using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Models;
using BROWSit.DAL;

namespace BROWSit.Areas.DB.Controllers
{   
    public class ReportController : Controller
    {
        private BROWSitContext context = new BROWSitContext();

        //
        // GET: /Reports/

        public ViewResult Index()
        {
            return View(context.Reports.ToList());
        }

        //
        // GET: /Reports/Details/5

        public ViewResult Details(int id)
        {
            Report report = context.Reports.Single(x => x.ReportID == id);
            return View(report);
        }

        //
        // GET: /Reports/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Reports/Create

        [HttpPost]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                context.Reports.Add(report);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(report);
        }
        
        //
        // GET: /Reports/Edit/5
 
        public ActionResult Edit(int id)
        {
            Report report = context.Reports.Single(x => x.ReportID == id);
            return View(report);
        }

        //
        // POST: /Reports/Edit/5

        [HttpPost]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                context.Entry(report).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report);
        }

        //
        // GET: /Reports/Delete/5
 
        public ActionResult Delete(int id)
        {
            Report report = context.Reports.Single(x => x.ReportID == id);
            return View(report);
        }

        //
        // POST: /Reports/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = context.Reports.Single(x => x.ReportID == id);
            context.Reports.Remove(report);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}