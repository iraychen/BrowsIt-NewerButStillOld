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
    public class PlatformController : Controller
    {
        private BROWSitContext db = new BROWSitContext();

        //
        // GET: /Platform/

        public ActionResult Index()
        {
            return View(db.Platforms.ToList());
        }

        //
        // GET: /Platform/Details/5

        public ActionResult Details(int id = 0)
        {
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        //
        // GET: /Platform/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Platform/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Platforms.Add(platform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platform);
        }

        //
        // GET: /Platform/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        //
        // POST: /Platform/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platform);
        }

        //
        // GET: /Platform/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        //
        // POST: /Platform/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platform platform = db.Platforms.Find(id);
            db.Platforms.Remove(platform);
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