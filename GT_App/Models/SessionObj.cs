using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GT_App.Models
{
    // Used in Views to pass session
    public class SessionObj
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int CourseId { get; set; }

        public SessionObj()
        {

        }
    }
}