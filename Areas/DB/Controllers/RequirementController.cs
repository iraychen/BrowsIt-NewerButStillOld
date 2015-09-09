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
    public class RequirementController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        //
        // GET: /Requirement/

        public ActionResult Index()
        {
            var requirements = db.Requirements.Include(r => r.Prefix).Include(r => r.Release);
            return View(requirements.ToList());
        }

        //
        // GET: /Requirement/Details/5

        public ActionResult Details(int id = 0)
        {
            Requirement requirement = db.Requirements.Find(id);
            if (requirement == null)
            {
                return HttpNotFound();
            }
            return View(requirement);
        }

        //
        // GET: /Requirement/Create

        public ActionResult Create()
        {
            ViewBag.PrefixID = new SelectList(db.Prefixes, "PrefixID", "Name");
            ViewBag.TargetID = new SelectList(db.Targets, "TargetID", "Name");
            return View();
        }

        //
        // POST: /Requirement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                db.Requirements.Add(requirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrefixID = new SelectList(db.Prefixes, "PrefixID", "Name", requirement.PrefixID);
            ViewBag.TargetID = new SelectList(db.Targets, "TargetID", "Name", requirement.TargetID);
            return View(requirement);
        }

        //
        // GET: /Requirement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Requirement requirement = db.Requirements.Find(id);
            if (requirement == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrefixID = new SelectList(db.Prefixes, "PrefixID", "Name", requirement.PrefixID);
            ViewBag.TargetID = new SelectList(db.Targets, "TargetID", "Name", requirement.TargetID);
            return View(requirement);
        }

        //
        // POST: /Requirement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requirement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrefixID = new SelectList(db.Prefixes, "PrefixID", "Name", requirement.PrefixID);
            ViewBag.TargetID = new SelectList(db.Targets, "TargetID", "Name", requirement.TargetID);
            return View(requirement);
        }

        //
        // GET: /Requirement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Requirement requirement = db.Requirements.Find(id);
            if (requirement == null)
            {
                return HttpNotFound();
            }
            return View(requirement);
        }

        //
        // POST: /Requirement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requirement requirement = db.Requirements.Find(id);
            db.Requirements.Remove(requirement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}