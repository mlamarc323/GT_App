using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT_App.Models;

namespace GT_App.Controllers
{
    public class RoundDetailController : Controller
    {
        private GolfStatTrackerEntities db = new GolfStatTrackerEntities();

        //
        // GET: /RoundDetail/

        public ActionResult Index()
        {
            var rounddetails = db.RoundDetails.Include(r => r.Round);
            return View(rounddetails.ToList());
        }

        //
        // GET: /RoundDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            RoundDetail rounddetail = db.RoundDetails.Find(id);
            if (rounddetail == null)
            {
                return HttpNotFound();
            }
            return View(rounddetail);
        }

        //
        // GET: /RoundDetail/Create

        public ActionResult Create()
        {
            ViewBag.RoundId = new SelectList(db.Rounds, "RoundId", "RoundId");
            return View();
        }

        //
        // POST: /RoundDetail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoundDetail rounddetail)
        {
            if (ModelState.IsValid)
            {
                db.RoundDetails.Add(rounddetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoundId = new SelectList(db.Rounds, "RoundId", "RoundId", rounddetail.RoundId);
            return View(rounddetail);
        }

        //
        // GET: /RoundDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RoundDetail rounddetail = db.RoundDetails.Find(id);
            if (rounddetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoundId = new SelectList(db.Rounds, "RoundId", "RoundId", rounddetail.RoundId);
            return View(rounddetail);
        }

        //
        // POST: /RoundDetail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoundDetail rounddetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rounddetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoundId = new SelectList(db.Rounds, "RoundId", "RoundId", rounddetail.RoundId);
            return View(rounddetail);
        }

        //
        // GET: /RoundDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RoundDetail rounddetail = db.RoundDetails.Find(id);
            if (rounddetail == null)
            {
                return HttpNotFound();
            }
            return View(rounddetail);
        }

        //
        // POST: /RoundDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundDetail rounddetail = db.RoundDetails.Find(id);
            db.RoundDetails.Remove(rounddetail);
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