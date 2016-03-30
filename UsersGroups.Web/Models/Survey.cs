using System.Collections.Generic;

namespace UsersGroups.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public int MeetingId { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public virtual ICollection<Response> Responses { get; set; } = new HashSet<Response>();
        public virtual Meeting Meeting { get; set; }
    }
}