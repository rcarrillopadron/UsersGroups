using System.Collections.Generic;

namespace UsersGroups.Web.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int SurveyId { get; set; }
        public int AttendeeId { get; set; }
        
        public virtual ICollection<Detail> Details { get; set; } = new HashSet<Detail>();
        public virtual Attendee Attendee { get; set; }
        public virtual Survey Survey { get; set; }
    }
}