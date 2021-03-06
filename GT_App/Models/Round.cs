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
    
    public partial class Round
    {
        public Round()
        {
            this.RoundDetails = new HashSet<RoundDetail>();
        }
    
        public int RoundId { get; set; }
        public Nullable<int> GolferId { get; set; }
        public int FacilityId { get; set; }
        public int CourseId { get; set; }
        public System.DateTime Date { get; set; }
        public bool Is_Official { get; set; }
        public bool Number_Of_Holes { get; set; }
        public bool HBH_Stats { get; set; }
        public Nullable<int> TotalScore { get; set; }
    
        public virtual ICollection<RoundDetail> RoundDetails { get; set; }
    }
}
