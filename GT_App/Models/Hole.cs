//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GT_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hole
    {
        public int HoleId { get; set; }
        public int FacilityId { get; set; }
        public int CourseId { get; set; }
        public int Number { get; set; }
        public Nullable<int> Yardage { get; set; }
        public Nullable<int> Par { get; set; }
        public Nullable<int> Handicap { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
