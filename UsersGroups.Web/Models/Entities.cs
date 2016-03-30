using System;
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

    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        public string QuestionDescription { get; set; }
        public int SurveyId { get; set; }

        public virtual ICollection<Detail> Details { get; set; } = new HashSet<Detail>();
        public virtual Survey Survey { get; set; }
    }

    public class Survey
    {
        public int SurveyId { get; set; }
        public int MeetingId { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public virtual ICollection<Response> Responses { get; set; } = new HashSet<Response>();
        public virtual Meeting Meeting { get; set; }
    }

    public class Response
    {
        public int ResponseId { get; set; }
        public int SurveyId { get; set; }
        public int AttendeeId { get; set; }
        
        public virtual ICollection<Detail> Details { get; set; } = new HashSet<Detail>();
        public virtual Attendee Attendee { get; set; }
        public virtual Survey Survey { get; set; }
    }

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

    public class Prize
    {
        public int PrizeId { get; set; }

        [Required]
        public string PrizeDescription { get; set; }

        public virtual ICollection<Winner> Winners { get; set; } = new HashSet<Winner>();
    }

    public class Winner
    {
        public int WinnerId { get; set; }
        public int AttendeeId { get; set; }
        public int MeetingId { get; set; }
        public int PrizeId { get; set; }


        public virtual Attendee Attendee { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual Prize Prize { get; set; }
    }
}
