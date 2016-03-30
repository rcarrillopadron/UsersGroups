using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Entity.Scaffolding.Metadata;

namespace UsersGroups.Web.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }

    public class Meeting
    {
        public int MeetingId { get; set; }

        [Required]
        public string Topic { get; set; }
        public DateTime StartTime { get; set; }
        
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }

    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }

    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        public string QuestionDescription { get; set; }

        public ICollection<Detail> Details { get; set; } = new List<Detail>();

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }

    public class Survey
    {
        public int SurveyId { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }

    public class Response
    {
        public int ResponseId { get; set; }

        public ICollection<Detail> SurveyResponseDetails { get; set; } = new List<Detail>();

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }

    public class Detail
    {
        public int DetailId { get; set; }

        [Required]
        public string Answer { get; set; }

        //public int QuestionId { get; set; }
        //public Question Question { get; set; }

        public int ResponseId { get; set; }
        public virtual Response Response { get; set; }
    }

    public class Prize
    {
        public int PrizeId { get; set; }

        [Required]
        public string PrizeDescription { get; set; }
    }

    public class Winner
    {
        public int WinnerId { get; set; }

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }

        public int PrizeId { get; set; }
        public Prize Prize { get; set; }
    }
}
