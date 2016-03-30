using System.ComponentModel.DataAnnotations;

namespace UsersGroups.Web.Models
{
    public class Detail
    {
        public int DetailId { get; set; }

        [Required]
        public string Answer { get; set; }

        public int QuestionId { get; set; }
        public int ResponseId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Response Response { get; set; }
    }
}