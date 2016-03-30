using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using UsersGroups.Web.Models;
using UsersGroups.Web.Services;

namespace UsersGroups.Web.Api
{
    [Route("api/[controller]")]
    public class MeetingsController : Controller
    {
        private readonly IMeetingRepository _repository;

        public MeetingsController(IMeetingRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
