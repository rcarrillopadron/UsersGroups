using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersGroups.Web.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Meeting> Meetings { get; set; } = new HashSet<Meeting>();
    }
}
