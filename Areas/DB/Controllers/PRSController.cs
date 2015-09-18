using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Models;
using BROWSit.Helpers;
using BROWSit.Helpers.SqlHelper;

namespace BROWSit.Areas.DB.Controllers
{
    public class PRSController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create()
        {
            PRSCRUDModel model = new PRSCRUDModel()
            {
                prs = new PRS(),
                message = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRSCRUDModel model)
        {
            if (ModelState.IsValid)
            {
                db.PRS.Add(model.prs);
                db.SaveChanges();
                model.message = "Successfully added PRS.";
                return View(model);
            }
            model.message = "Failed to add PRS.";
            return View(model);
        }
    }
}
