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
    public class TargetController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        //
        // GET: /Target/

        public ActionResult Index()
        {
            return View(db.Targets.ToList());
        }

        //
        // GET: /Target/Details/5

        public ActionResult Details(int id = 0)
        {
            Target target = db.Targets.Find(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        //
        // GET: /Target/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Target/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Target target)
        {
            if (ModelState.IsValid)
            {
                db.Targets.Add(target);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(target);
        }

        //
        // GET: /Target/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Target target = db.Targets.Find(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        //
        // POST: /Target/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Target target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(target);
        }

        //
        // GET: /Target/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Target target = db.Targets.Find(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        //
        // POST: /Target/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Target target = db.Targets.Find(id);
            db.Targets.Remove(target);
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