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
    public class HoleController : Controller
    {
        private GolfStatTrackerEntities db = new GolfStatTrackerEntities();

        //
        // GET: /Hole/

        public ActionResult Index()
        {
            var holes = db.Holes.Include(h => h.Course);
            return View(holes.ToList());
        }

        //
        // GET: /Hole/Details/5

        public ActionResult Details(int id = 0)
        {
            Hole hole = db.Holes.Find(id);
            if (hole == null)
            {
                return HttpNotFound();
            }
            return View(hole);
        }

        //
        // GET: /Hole/Create

        public ActionResult Create()
        {
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View();
        }

        //
        // POST: /Hole/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hole hole)
        {
            if (ModelState.IsValid)
            {
                if (Session["FacilityId"] != null || Convert.ToInt32(Session["FacilityId"]) != 0)
                {
                    hole.FacilityId = Convert.ToInt32(Session["FacilityId"]);
                }
                if (Session["CourseId"] != null || Convert.ToInt32(Session["CourseId"]) != 0)
                {
                    hole.CourseId = Convert.ToInt32(Session["CourseId"]);
                }
                db.Holes.Add(hole);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", hole.CourseId);
            return View(hole);
        }

        //
        // GET: /Hole/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hole hole = db.Holes.Find(id);
            if (hole == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", hole.CourseId);
            return View(hole);
        }

        //
        // POST: /Hole/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hole hole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", hole.CourseId);
            return View(hole);
        }

        //
        // GET: /Hole/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hole hole = db.Holes.Find(id);
            if (hole == null)
            {
                return HttpNotFound();
            }
            return View(hole);
        }

        //
        // POST: /Hole/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hole hole = db.Holes.Find(id);
            db.Holes.Remove(hole);
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