using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersGroups.Web.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        [Required]
        public string Topic { get; set; }
        public DateTime StartTime { get; set; }
        
        public int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; } = new HashSet<Survey>();
        public virtual ICollection<Winner> Winners { get; set; } = new HashSet<Winner>();
    }
}