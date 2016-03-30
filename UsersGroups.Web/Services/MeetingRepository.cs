using System.Collections.Generic;
using System.Linq;
using UsersGroups.Web.Models;

namespace UsersGroups.Web.Services
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
    }

    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDbContext _context;

        public MeetingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Meeting item)
        {
            _context.Add(item);
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _context.Meetings;
        }

        public Meeting Find(int id)
        {
            return _context.Meetings.SingleOrDefault(x => x.MeetingId == id);
        }

        public Meeting Remove(int id)
        {
            var meeting = _context.Meetings.SingleOrDefault(x => x.MeetingId == id);
            if (meeting != null)
            {
                return _context.Remove(meeting).Entity;
            }

            return null;
        }

        public void Update(Meeting item)
        {
            _context.Update(item);
        }
    }
}
