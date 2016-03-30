using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersGroups.Web.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        public string QuestionDescription { get; set; }
        public int SurveyId { get; set; }

        public virtual ICollection<Detail> Details { get; set; } = new HashSet<Detail>();
        public virtual Survey Survey { get; set; }
    }
}