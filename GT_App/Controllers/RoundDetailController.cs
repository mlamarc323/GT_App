using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GT_App.Models;
using GT_App.ViewModel;

namespace GT_App.Controllers
{
    public class RoundDetailController : Controller
    {
        private GT_AppDBEntities2 db = new GT_AppDBEntities2();

        //
        // GET: /RoundDetail/

        public ActionResult Index()
        {
            //var rounddetails = db.RoundDetails.Include(r => r.Course).Include(r => r.Facility).Include(r => r.Golfer).Include(r => r.Hole).Include(r => r.TeeType);
            var rounddetails = db.RoundDetails.Include(r => r.GolferId);
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
        // GET: /Hole/Create

        public ActionResult Create()
        {
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Facility_Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name");
            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name");

            return View();
        }
        

        // POST: /RoundDetail/Create

        [HttpPost]
        public ActionResult Create(RoundDetail rounddetail)
        {
            if (ModelState.IsValid)
            {
                var roundDetailList = CreateListOfRoundDetails();
                foreach (RoundDetail r in roundDetailList)
                {
                    db.RoundDetails.Add(rounddetail);
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rounddetail);
        }

        public List<RoundDetail> CreateListOfRoundDetails()
        {
            var list = new List<RoundDetail>();
            if (ModelState.IsValid)
            {
                
                var detail = new RoundDetail();

                foreach (RoundDetail r in list)
                {
                    detail.GolferId = 1;
                    detail.FacilityId = r.FacilityId; 
                    detail.CourseId = r.CourseId;
                    detail.TeeTypeId = r.TeeTypeId;
                    detail.HoleId = r.HoleId;
                    detail.Date = r.Date;
                    detail.Score = r.Score;
                    detail.Differential = 1.00;
                    list.Add(detail);
                }
                
                //db.RoundDetails.Add();
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return list;

            
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
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name", rounddetail.CourseId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Facility_Name", rounddetail.FacilityId);
            ViewBag.GolferId = new SelectList(db.Golfers, "GolferId", "First_Name", rounddetail.GolferId);
            ViewBag.HoleId = new SelectList(db.Holes, "HoleId", "HoleId", rounddetail.HoleId);
            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name", rounddetail.TeeTypeId);
            return View(rounddetail);
        }

        //
        // POST: /RoundDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(RoundDetail rounddetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rounddetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name", rounddetail.CourseId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Facility_Name", rounddetail.FacilityId);
            ViewBag.GolferId = new SelectList(db.Golfers, "GolferId", "First_Name", rounddetail.GolferId);
            ViewBag.HoleId = new SelectList(db.Holes, "HoleId", "HoleId", rounddetail.HoleId);
            ViewBag.TeeTypeId = new SelectList(db.TeeTypes, "TeeTypeId", "Name", rounddetail.TeeTypeId);
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