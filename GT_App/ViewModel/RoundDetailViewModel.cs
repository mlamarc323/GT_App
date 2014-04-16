using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GT_App.Models;
using System.Web.Mvc;

namespace GT_App.ViewModel
{
    public class RoundDetailViewModel
    {    

        public Facility Facilities { get; set; }
        public Course Courses { get; set; }
        public Hole Holes { get; set; }
        public RoundDetail RoundDetails { get; set; }

        public SelectList AvailableFacilities { get; set; }
        public SelectList AvailableCourses { get; set; }
        public SelectList AvailableTeeTypes { get; set; }

        
        public RoundDetailViewModel()
        {
        
            //AvailableFacilities = new SelectList(Enumerable.Empty<Facility>(), "FacilityId", "Facility_Name");
            //AvailableCourses = new SelectList(Enumerable.Empty<Course>(), "CourseId", "Course_Name");
            //AvailableTeeTypes= new SelectList(Enumerable.Empty<TeeType>(), "TeeTypeId", "Name");           
            
        }

        //public IEnumerable<SelectListItem> FacilitiesSearch
        //{
        //    get
        //    {
        //        return Enumerable.Range(1,AvailableFacilities.Count()).Select(x => new SelectListItem
        //        {
        //            Value = x.ToString(),
        //            Text = x.ToString()
        //        });
        //    }
        //}
    }
}