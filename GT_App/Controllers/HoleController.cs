using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT_App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GT_App.Controllers
{
    public class HoleController : Controller
    {
        private GT_AppDBEntities2 db = new GT_AppDBEntities2();

        //
        // GET: /Hole/

        public ActionResult Index()
        {
            var holes = db.Holes.Include(h => h.TeeType);
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
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Facility_Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name");
            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name");

            return View();
        }

        //
        // POST: /Hole/Create

        [HttpPost]
        public ActionResult Create(Hole hole)
        {
            if (ModelState.IsValid)
            {
                db.Holes.Add(hole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name", hole.TeeTypeId);
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
            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name", hole.TeeTypeId);
            return View(hole);
        }

        //
        // POST: /Hole/Edit/5

        [HttpPost]
        public ActionResult Edit(Hole hole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name", hole.TeeTypeId);
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