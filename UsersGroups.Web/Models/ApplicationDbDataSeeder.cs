using System;
using System.Linq;

namespace UsersGroups.Web.Models
{
    public class ApplicationDbDataSeeder
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbDataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Speakers.Any())
            {
                var speaker = new Speaker {Name = "Tim Rayburn"};
                var meeting = new Meeting {Speaker = speaker, Topic = "Dallas C# Sig", StartTime = GetNextMeetingTime() };
                var question1 = new Question {QuestionDescription = "What did you think about the presentation today?"};
                var question2 = new Question {QuestionDescription = "What topics would you like to see covered in future presentations?"};
                var question3 = new Question { QuestionDescription = "Any suggestions to improve the SIG?" };
                var attendee1 = new Attendee {Fullname = "Roberto Carrillo", Email = "Roberto.Carrillo@Improving.com"};
                var attendee2 = new Attendee {Fullname = "Michael Dudley", Email = "Michael.Dudley@Improving.com"};

                _context.Add(speaker);
                _context.Add(meeting);
                _context.Add(question1);
                _context.Add(question2);
                _context.Add(question3);
                _context.Add(attendee1);
                _context.Add(attendee2);
            }
        }

        private static DateTime GetNextMeetingTime()
        {
            var today = DateTime.Today;
            var firstThursdayOfThisMonth = GetFirstThursdayOfMonth(today.Year, today.Month);
            DateTime nextThursday;
            if (today.Day <= firstThursdayOfThisMonth.Day)
                nextThursday = new DateTime(firstThursdayOfThisMonth.Year, firstThursdayOfThisMonth.Month, firstThursdayOfThisMonth.Day);
            else
                nextThursday = GetFirstThursdayOfMonth(today.Year, today.Month + 1);

            return nextThursday.AddHours(18).AddMinutes(30);
        }

        private static DateTime GetFirstThursdayOfMonth(int year, int month)
        {
            DateTime firstThursday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            while (firstThursday.DayOfWeek != DayOfWeek.Thursday)
            {
                firstThursday = firstThursday.AddDays(1);
            }

            return firstThursday;
        }
    }
}
