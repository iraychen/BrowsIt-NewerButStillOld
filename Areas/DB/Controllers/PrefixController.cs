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
    public class PrefixController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        //
        // GET: /Prefix/

        public ActionResult Index()
        {
            return View(db.Prefixes.ToList());
        }

        //
        // GET: /Prefix/Details/5

        public ActionResult Details(int id = 0)
        {
            Prefix prefix = db.Prefixes.Find(id);
            if (prefix == null)
            {
                return HttpNotFound();
            }
            return View(prefix);
        }

        //
        // GET: /Prefix/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Prefix/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prefix prefix)
        {
            if (ModelState.IsValid)
            {
                db.Prefixes.Add(prefix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prefix);
        }

        //
        // GET: /Prefix/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Prefix prefix = db.Prefixes.Find(id);
            if (prefix == null)
            {
                return HttpNotFound();
            }
            return View(prefix);
        }

        //
        // POST: /Prefix/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prefix prefix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prefix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prefix);
        }

        //
        // GET: /Prefix/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Prefix prefix = db.Prefixes.Find(id);
            if (prefix == null)
            {
                return HttpNotFound();
            }
            return View(prefix);
        }

        //
        // POST: /Prefix/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prefix prefix = db.Prefixes.Find(id);
            db.Prefixes.Remove(prefix);
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