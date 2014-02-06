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
    public class TeeTypeController : Controller
    {
        private GT_AppDBEntities2 db = new GT_AppDBEntities2();

        //
        // GET: /TeeType/

        public ActionResult Index()
        {
            return View(db.TeeTypes.ToList());
        }

        //
        // GET: /TeeType/Details/5

        public ActionResult Details(int id = 0)
        {
            TeeType teetype = db.TeeTypes.Find(id);
            if (teetype == null)
            {
                return HttpNotFound();
            }
            return View(teetype);
        }

        //
        // GET: /TeeType/Create

        public ActionResult Create()
        {
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Facility_Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name");

            List<SelectListItem> genList = new List<SelectListItem>();
            SelectListItem men = new SelectListItem();
            SelectListItem women = new SelectListItem();
            
            men.Text = "Men";
            men.Value = "M";
            women.Text = "Women";
            women.Value = "W";

            genList.Add(men);
            genList.Add(women);

            SelectList sl = new SelectList(genList,"Value","Text");
            ViewBag.Gender = sl;            

            return View();
        }

        //
        // POST: /TeeType/Create

        [HttpPost]
        public ActionResult Create(TeeType teetype)
        {
            if (ModelState.IsValid)
            {
                db.TeeTypes.Add(teetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> genList = new List<SelectListItem>();
            SelectListItem men = new SelectListItem();
            SelectListItem women = new SelectListItem();

            men.Text = "Men";
            men.Value = "M";
            women.Text = "Women";
            women.Value = "W";

            genList.Add(men);
            genList.Add(women);

            SelectList sl = new SelectList(genList, "Value", "Text");
            ViewBag.Gender = sl;        

            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Facility_Name", teetype.FacilityId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name", teetype.CourseId);
            
            return View(teetype);
        }

        //
        // GET: /TeeType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TeeType teetype = db.TeeTypes.Find(id);
            if (teetype == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name", teetype.CourseId);
            return View(teetype);
        }

        //
        // POST: /TeeType/Edit/5

        [HttpPost]
        public ActionResult Edit(TeeType teetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Course_Name", teetype.CourseId);
            return View(teetype);
        }

        //
        // GET: /TeeType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TeeType teetype = db.TeeTypes.Find(id);
            if (teetype == null)
            {
                return HttpNotFound();
            }
            return View(teetype);
        }

        //
        // POST: /TeeType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TeeType teetype = db.TeeTypes.Find(id);
            db.TeeTypes.Remove(teetype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //Json Serialize setting
        private static JsonSerializerSettings JsonSetting
        {
            get
            {
                var settings = new JsonSerializerSettings();

                settings.ContractResolver = new DefaultContractResolver()
                {
                    IgnoreSerializableAttribute = true,
                    IgnoreSerializableInterface = true
                };
                return settings;
            }
        }

        public string GetFacilities()
        {
            var facilities = db.Facilities.ToList();
            var list = new List<Facility>();
            foreach (Facility f in facilities)
            {
                var facilityObj = new Facility();
                facilityObj.FacilityId = f.FacilityId;
                facilityObj.Facility_Name = f.Facility_Name;
                list.Add(facilityObj);
            }
            return JsonConvert.SerializeObject(list, Formatting.Indented, JsonSetting);
        }

        public string GetCourses(int facilityId)
        {
            var courses = db.Courses.Where(f=>f.FacilityId == facilityId).ToList();
            var list = new List<Course>();
            foreach (Course c in courses)
            {
                var courseObj = new Course();
                courseObj.CourseId = c.CourseId;
                courseObj.Course_Name = c.Course_Name;
                list.Add(courseObj);
            }
            return JsonConvert.SerializeObject(list, Formatting.Indented, JsonSetting);
        }


    }
}