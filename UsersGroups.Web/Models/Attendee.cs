using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersGroups.Web.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Response> Responses { get; set; } = new HashSet<Response>();
        public ICollection<Winner> Winners { get; set; } = new HashSet<Winner>();
    }
}