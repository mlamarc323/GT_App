using GT_App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GT_App.Controllers
{
    public class BusinessLayerController : Controller
    {
        //
        // GET: /BusinessLayer/
        private GolfTrackerEntities3 db = new GT_AppDBEntities4();

        public ActionResult Index()
        {
            return View();
        }

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
            var courses = db.Courses.Where(f => f.FacilityId == facilityId).ToList();
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

        public string GetTeeTypes(int facilityId, int courseId)
        {
            //var courses = db.Courses.Where(f => f.FacilityId == facilityId).ToList();
            var teeTypes = db.TeeTypes.Where(t => t.FacilityId == facilityId && t.CourseId == courseId).ToList();
            var list = new List<TeeType>();
            foreach (TeeType t in teeTypes)
            {
                var TeeTypeObj = new TeeType();
                TeeTypeObj.TeeTypeId = t.TeeTypeId;
                TeeTypeObj.Name = t.Name;
                list.Add(TeeTypeObj);
            }
            return JsonConvert.SerializeObject(list, Formatting.Indented, JsonSetting);
        }
        public string GetHolesByCourse(int facilityId, int courseId, int teeTypeId)
        {
            var holes = db.Holes.Where(x => x.FacilityId == facilityId && x.CourseId == courseId && x.TeeTypeId == teeTypeId).ToList();
            var list = new List<Hole>();
            foreach (Hole h in holes)
            {
                var holeObj = new Hole();
                holeObj.HoleId = h.HoleId;
                holeObj.Hole_Num = h.Hole_Num;
                holeObj.Yardage = h.Yardage;
                holeObj.Par = h.Par;
                list.Add(holeObj);
            }
            return JsonConvert.SerializeObject(list, Formatting.Indented, JsonSetting);
        }
    }
    
}
