using System.Collections.Generic;
using System.Linq;
using UsersGroups.Web.Models;

namespace UsersGroups.Web.Services
{
    public class UsersGroupsData
    {
        private readonly ApplicationDbContext _context;

        public UsersGroupsData(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Survey> GetSurveysByMeeting(int meetingId)
        {
            return _context.Surveys.Where(x => x.Meeting.MeetingId == meetingId);
        }

        public void AddSurvey(Survey survey)
        {
            _context.Add(survey);
            _context.SaveChanges();
        }
    }
}
