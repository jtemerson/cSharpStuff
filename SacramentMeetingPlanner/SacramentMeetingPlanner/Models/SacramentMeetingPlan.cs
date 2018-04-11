using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeetingPlan
    {
        internal int? ID;

        public int SacramentMeetingPlanID { get; set; }
        public DateTime Date { get; set; }
        public string OpeningPrayer { get; set; }
        public string ClosingPrayer { get; set; }
        public string OpeningHymn { get; set; }
        public string SacramentHymn { get; set; }
        public string ClosingHymn { get; set; }
        public string Talk1 { get; set; }
        public string Talk2 { get; set; }
        public string Talk3 { get; set; }
        public string Topic { get; set; }
        public string LeaderName { get; set; }
        public string Presiding { get; set; }
        public string Announcements { get; set; }

    }
}

//        public ICollection<Enrollment> Enrollments { get; set; }
//    }
//}